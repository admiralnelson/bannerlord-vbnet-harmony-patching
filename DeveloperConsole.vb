
Imports System.Runtime.InteropServices
Imports BannerLib.Input
Imports TaleWorlds.InputSystem

Namespace Global.MyVBPatchProject
    Public Module DeveloperConsole
        Private m_IsStarted = False
        Private Declare Sub toggle_imgui_console_visibility Lib "Rgl.dll" Alias "?toggle_imgui_console_visibility@rglCommand_line_manager@@QEAAXXZ" (x As UIntPtr)
        Public Sub LoadTheHotkeys()
            If (m_IsStarted) Then Exit Sub
            m_IsStarted = True
            Dim hotkey = HotKeys.Create("MyVBPatchProject")
            Dim key = hotkey.Add("MyVBPatchProject_DeveloperConsole",
                InputKey.Tilde,
                HotKeyCategory.Action,
                "Developer console",
                "Toggles a developer console"
            )

            Dim lambda As Func(Of Boolean) =
            Function()
                Return True
            End Function
            key.WithPredicate(
                lambda
            )
            key.WithOnPressedAction(
                Sub()
                    toggle_imgui_console_visibility(New UIntPtr(1))
                End Sub)
            hotkey.Build()
        End Sub
    End Module
End Namespace