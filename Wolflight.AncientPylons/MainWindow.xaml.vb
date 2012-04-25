Class MainWindow
    Public Shared ClickFace As New RoutedCommand
    Public Shared ClickSide As New RoutedCommand
    Public Shared RightClickFace As New RoutedCommand
    Public Shared RightClickSide As New RoutedCommand

    Private Shared ReadOnly cgColors As Integer = [Enum].GetValues(GetType(PylonColor)).GetLength(0)

    Private cgSolver As Solver


    Private Sub AlwaysExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    Private Sub Execute_ClickFace(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)

        Select Case Grid.GetRow(e.OriginalSource)
            Case 0
                cgSolver.Face(4) = GetNextColor(cgSolver.Face(4))

            Case 1
                cgSolver.Face(3) = GetNextColor(cgSolver.Face(3))

            Case 2
                cgSolver.Face(2) = GetNextColor(cgSolver.Face(2))

            Case 3
                cgSolver.Face(1) = GetNextColor(cgSolver.Face(1))

        End Select

        RefreshDisplay()
    End Sub


    Private Sub Execute_RightClickFace(ByVal sender As Object, ByVal e As MouseEventArgs)

        Select Case Grid.GetRow(e.OriginalSource)
            Case 0
                cgSolver.Face(4) = GetNextColor(cgSolver.Face(4), True)

            Case 1
                cgSolver.Face(3) = GetNextColor(cgSolver.Face(3), True)

            Case 2
                cgSolver.Face(2) = GetNextColor(cgSolver.Face(2), True)

            Case 3
                cgSolver.Face(1) = GetNextColor(cgSolver.Face(1), True)

        End Select

        RefreshDisplay()
    End Sub

    Private Sub Execute_ClickSide(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)

        Select Case Grid.GetRow(e.OriginalSource)
            Case 0
                cgSolver.Side(4) = GetNextColor(cgSolver.Side(4))

            Case 1
                cgSolver.Side(3) = GetNextColor(cgSolver.Side(3))

            Case 2
                cgSolver.Side(2) = GetNextColor(cgSolver.Side(2))

            Case 3
                cgSolver.Side(1) = GetNextColor(cgSolver.Side(1))

        End Select

        RefreshDisplay()
    End Sub

    Private Sub Execute_RightClickSide(ByVal sender As Object, ByVal e As MouseEventArgs)

        Select Case Grid.GetRow(e.OriginalSource)
            Case 0
                cgSolver.Side(4) = GetNextColor(cgSolver.Side(4), True)

            Case 1
                cgSolver.Side(3) = GetNextColor(cgSolver.Side(3), True)

            Case 2
                cgSolver.Side(2) = GetNextColor(cgSolver.Side(2), True)

            Case 3
                cgSolver.Side(1) = GetNextColor(cgSolver.Side(1), True)

        End Select

        RefreshDisplay()
    End Sub


    Private Function GetNextColor(ByVal aOriginalColor As PylonColor, Optional ByVal aBackward As Boolean = False) As PylonColor
        If Not aBackward Then
            Return (aOriginalColor + 1) Mod cgColors
        Else
            If aOriginalColor > 0 Then
                Return aOriginalColor - 1
            Else
                Return cgColors - 1
            End If

        End If
    End Function


    Private Sub RefreshDisplay()
        Try
            Dim distance As Integer

            HighestLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(4)))
            HighestFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(4)))
            HighestRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(4)))
            HighestResult.Text = TextForDirection(cgSolver.GetDirection(4, distance), distance)

            HighLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(3)))
            HighFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(3)))
            HighRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(3)))
            HighResult.Text = TextForDirection(cgSolver.GetDirection(3, distance), distance)

            LowLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(2)))
            LowFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(2)))
            LowRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(2)))
            LowResult.Text = TextForDirection(cgSolver.GetDirection(2, distance), distance)

            LowestLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(1)))
            LowestFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(1)))
            LowestRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(1)))
            LowestResult.Text = TextForDirection(cgSolver.GetDirection(1, distance), distance)

        Catch ex As Exception
            Stop
        End Try

    End Sub



    Private Function ImageForPylonColor(ByVal aPylonColor As PylonColor) As Uri
        Select Case aPylonColor
            Case PylonColor.Purple
                Return New Uri("pack://application:,,,/Wolflight.AncientPylons;component/Images/Purple.png")

            Case PylonColor.Red
                Return New Uri("pack://application:,,,/Wolflight.AncientPylons;component/Images/Red.png")

            Case PylonColor.Green
                Return New Uri("pack://application:,,,/Wolflight.AncientPylons;component/Images/Green.png")

            Case PylonColor.Blue
                Return New Uri("pack://application:,,,/Wolflight.AncientPylons;component/Images/Blue.png")

            Case PylonColor.Yellow
                Return New Uri("pack://application:,,,/Wolflight.AncientPylons;component/Images/Yellow.png")

            Case Else
                Return New Uri("pack://application:,,,/Wolflight.AncientPylons;component/Images/White.png")

        End Select
    End Function

    Private Function TextForDirection(ByVal aDirection As PylonDirection, ByVal aDistance As Integer) As String
        Select Case aDirection
            Case PylonDirection.Either
                Return "Either way" & Environment.NewLine & "Distance: " & aDistance
            Case PylonDirection.Left
                Return "Left" & Environment.NewLine & "Distance: " & aDistance
            Case PylonDirection.Right
                Return "Right" & Environment.NewLine & "Distance: " & aDistance
            Case Else
                Return "Lock it in" & Environment.NewLine & "Distance: " & aDistance

        End Select
    End Function

    Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        Try
            cgSolver = New Solver

            RefreshDisplay()
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub Button_CanExecute(ByVal sender As System.Object, ByVal e As System.Windows.Input.CanExecuteRoutedEventArgs)

    End Sub
End Class
