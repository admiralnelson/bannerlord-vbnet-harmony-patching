Imports HarmonyLib
Imports TaleWorlds.CampaignSystem
Imports TaleWorlds.Core
Imports TaleWorlds.MountAndBlade

Namespace Global.MyVBPatchProject
    Public Class Main
        Inherits MBSubModuleBase

        Protected Overrides Sub OnSubModuleLoad()
            MyBase.OnSubModuleLoad()
            Dim harmony = New Harmony("calradia.MyVBPatchProject.example")
            harmony.PatchAll()
        End Sub

        Protected Overrides Sub OnGameStart(game As Game, gameStarterObject As IGameStarter)
            Dim campaign = game.GameType
            If (campaign Is Nothing) Then
                Debug.WriteLine("oops!")
                Exit Sub
            End If
            Dim campaignStarter = CType(gameStarterObject, CampaignGameStarter)
            AddBehaviour(campaignStarter)
        End Sub

        Private Sub AddBehaviour(gameInit As CampaignGameStarter)
            'gameInit.AddBehavior(New SimpleDayCounter)
        End Sub


        Protected Overrides Sub OnBeforeInitialModuleScreenSetAsRoot()
            MyBase.OnBeforeInitialModuleScreenSetAsRoot()
            DeveloperConsole.LoadTheHotkeys() '<---- 
            Dim ver = System.Environment.Version
            InformationManager.ShowInquiry(New InquiryData(
                "Net Enviroment",
                $"running on version {ver}",
                True,
                False,
                "Accept",
                "",
                Sub()
                    'Environment.Exit(1)
                End Sub,
                Sub()

                End Sub))
        End Sub

    End Class

End Namespace