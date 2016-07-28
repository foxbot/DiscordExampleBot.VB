' Discord.Net Example Bot (for Visual Basic)
' by foxbot
'
' I don't know VB so this is probably awful, forgive me.
'
' Licensed under WTFPL

Imports Discord
Imports Discord.Commands
Imports System.Reflection



Public Class CommandHandler

    Private WithEvents client As DiscordSocketClient
    Private commands As CommandService
    Private self As ISelfUser

    Async Sub Install(ByVal c As DiscordSocketClient)
        client = c
        ' Create the Command Service
        commands = New CommandService()
        ' Retrieve the Bot User for later use
        self = Await client.GetCurrentUserAsync()

        ' Setup the dependency map
        Dim map = New DependencyMap()
        map.Add(client)
        map.Add(self)

        ' Load modules
        Await commands.LoadAssembly(Assembly.GetEntryAssembly(), map)
    End Sub

    ' Create an async function that hooks the MessageReceived event
    Async Function HandleCommand(ByVal msg As IMessage) As Task Handles client.MessageReceived
        ' Set the index of the command prefix to 0
        Dim argPos = 0
        ' Determine if the message starts with '@bot' or '~', and set argPos to that index
        If (msg.HasMentionPrefix(self, argPos) Or msg.HasCharPrefix("~"c, argPos)) Then
            ' Execute the command
            Dim result = Await commands.Execute(msg, argPos)
            ' If the command failed, notify the user
            If (Not result.IsSuccess) Then
                Await msg.Channel.SendMessageAsync(result.ErrorReason)
            End If
        End If

    End Function

End Class
