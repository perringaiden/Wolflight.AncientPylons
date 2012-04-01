Class MainWindow
    Public Shared ClickFace As New RoutedCommand
    Public Shared ClickSide As New RoutedCommand

    Private cgSolver As Solver


    Private Sub AlwaysExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    Private Sub Execute_ClickFace(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Dim colors As Integer = [Enum].GetValues(GetType(PylonColor)).GetLength(0)


        Select Case Grid.GetRow(e.OriginalSource)
            Case 0
                cgSolver.Face(4) = (cgSolver.Face(4) + 1) Mod colors

            Case 1
                cgSolver.Face(3) = (cgSolver.Face(3) + 1) Mod colors

            Case 2
                cgSolver.Face(2) = (cgSolver.Face(2) + 1) Mod colors

            Case 3
                cgSolver.Face(1) = (cgSolver.Face(1) + 1) Mod colors

        End Select

        RefreshDisplay()
    End Sub

    Private Sub Execute_ClickSide(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Dim colors As Integer = [Enum].GetValues(GetType(PylonColor)).GetLength(0)


        Select Case Grid.GetRow(e.OriginalSource)
            Case 0
                cgSolver.Side(4) = (cgSolver.Side(4) + 1) Mod colors

            Case 1
                cgSolver.Side(3) = (cgSolver.Side(3) + 1) Mod colors

            Case 2
                cgSolver.Side(2) = (cgSolver.Side(2) + 1) Mod colors

            Case 3
                cgSolver.Side(1) = (cgSolver.Side(1) + 1) Mod colors

        End Select

        RefreshDisplay()
    End Sub


    Private Sub RefreshDisplay()
        Try

            HighestLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(4)))
            HighestFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(4)))
            HighestRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(4)))
            HighestResult.Text = TextForDirection(cgSolver.GetDirection(4))

            HighLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(3)))
            HighFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(3)))
            HighRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(3)))
            HighResult.Text = TextForDirection(cgSolver.GetDirection(3))

            LowLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(2)))
            LowFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(2)))
            LowRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(2)))
            LowResult.Text = TextForDirection(cgSolver.GetDirection(2))

            LowestLeft.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(1)))
            LowestFacing.Source = New BitmapImage(ImageForPylonColor(cgSolver.Face(1)))
            LowestRight.Source = New BitmapImage(ImageForPylonColor(cgSolver.Side(1)))
            LowestResult.Text = TextForDirection(cgSolver.GetDirection(1))

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

    Private Function TextForDirection(ByVal aDirection As PylonDirection) As String
        Select Case aDirection
            Case PylonDirection.Either
                Return "Either way"
            Case PylonDirection.Left
                Return "Left"
            Case PylonDirection.Right
                Return "Right"
            Case Else
                Return "Once Left, Once Right"

        End Select
    End Function

    Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        Try
            cgSolver = New Solver
            cgSolver.Face(4) = PylonColor.Red
            cgSolver.Side(4) = PylonColor.Blue

            RefreshDisplay()
        Catch ex As Exception
            Stop
        End Try
    End Sub
End Class
