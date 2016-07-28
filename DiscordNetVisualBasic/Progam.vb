' Discord.Net Example Bot (for Visual Basic)
' by foxbot
'
' I don't know VB so this is probably awful, forgive me.
'
' Licensed under WTFPL
Imports Discord

Module Program

    ' Convert our synchronus main to an asynchronus method.
    Sub Main()
        Dim main = New Task(AddressOf Start)
        main.Start()
        main.Wait()
    End Sub

    Private WithEvents client As DiscordSocketClient

    Async Sub Start()
        ' Create a new DiscordSocketClient
        client = New DiscordSocketClient(New DiscordSocketConfig())
        ' Define the token the bot will use to connect with
        Dim token = "token"
        ' Login and connect to Discord
        Await client.LoginAsync(TokenType.Bot, token)
        Await client.ConnectAsync()
        ' Create the commands handler
        Dim commands = New CommandHandler()
        commands.Install(client)
        ' Block this method until the application is terminated
        Await Task.Delay(-1)
    End Sub

    ' Write log messages to console
    Function Log(ByVal message As LogMessage) As Task Handles client.Log
        Console.Write(message.ToString())
        Return Task.CompletedTask
    End Function

End Module
