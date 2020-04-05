Imports HarmonyLib
Imports TaleWorlds.CampaignSystem.SandBox.GameComponents.Party
Imports TaleWorlds.Core

Namespace Global.MyVBPatchProject
    <HarmonyPatch(GetType(DefaultPartySizeLimitModel), "ShowPartySizeDetail")>
    Friend Class Patch
        Public Shared Sub Postfix(strings As List(Of String), ByRef __result As String)
            InformationManager.ShowInquiry(New InquiryData(
                "Patch works",
                "if you see this, the patch works",
                True,
                False,
                "Accept",
                "",
                Sub()
                    'Environment.Exit(1)
                End Sub,
                Sub()

                End Sub))
            __result = "hello world"
        End Sub
    End Class
End Namespace