' Discord.Net Example Bot (for Visual Basic)
' by foxbot
'
' I don't know VB so this is probably awful, forgive me.
'
' Licensed under WTFPL
Imports Discord
Imports Discord.Commands

Public Class PublicModule
    Private _client As DiscordSocketClient

    Sub New(ByVal client As DiscordSocketClient)
        _client = client
    End Sub

    <Command("join")>
    <Description("Returns the Invite URL of the bot.")>
    Async Sub Join(ByVal msg As IMessage)
        Dim application = Await _client.GetApplicationInfoAsync()
        Await msg.Channel.SendMessageAsync($"A user with `MANAGE SERVER` can invite me to your server here: <https://discordapp.com/oauth2/authorize?client_id={application.Id}&scope=bot>")
    End Sub

    ' TODO: This module could use some more examples.

End Class
