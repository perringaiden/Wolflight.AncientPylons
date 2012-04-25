Imports System.ComponentModel

Public Enum PylonColor
    White
    Purple
    Red
    Green
    Blue
    Yellow
End Enum

Public Enum PylonDirection
    None = 0
    Left
    Right
    Either
End Enum


Public Class Solver
    Private cgFace As New Dictionary(Of Integer, PylonColor)
    Private cgSide As New Dictionary(Of Integer, PylonColor)


    Public Sub New()
        '        
    End Sub

    Public Property Face(ByVal aIndex As Integer) As PylonColor
        Get
            If Not cgFace.ContainsKey(aIndex) Then
                cgFace.Add(aIndex, PylonColor.White)
            End If

            Return cgFace(aIndex)
        End Get
        Set(ByVal aValue As PylonColor)
            cgFace(aIndex) = aValue
        End Set
    End Property


    Public Property Side(ByVal aIndex As Integer) As PylonColor
        Get
            If Not cgSide.ContainsKey(aIndex) Then
                cgSide.Add(aIndex, PylonColor.White)
            End If

            Return cgSide(aIndex)
        End Get
        Set(ByVal aValue As PylonColor)
            cgSide(aIndex) = aValue
        End Set
    End Property


    Public Function GetDirection(ByVal aIndex As Integer, ByRef aDistance As Integer) As PylonDirection
        Dim faceValue As PylonColor = Face(aIndex)
        Dim sideValue As PylonColor = Side(aIndex)

        aDistance = 0

        If faceValue = sideValue Then
            aDistance = 0
            Return PylonDirection.None

        ElseIf faceValue > sideValue Then
            Dim dist As Integer = faceValue - sideValue


            Select Case dist
                Case Is = 3
                    aDistance = 3
                    Return PylonDirection.Either

                Case Is < 3
                    aDistance = dist
                    Return PylonDirection.Right

                Case Is > 3
                    aDistance = 6 - dist
                    Return PylonDirection.Left

            End Select

        Else
            Dim dist As Integer = sideValue - faceValue


            Select Case dist
                Case Is = 3
                    aDistance = 3
                    Return PylonDirection.Either

                Case Is < 3
                    aDistance = dist
                    Return PylonDirection.Left

                Case Is > 3
                    aDistance = 6 - dist
                    Return PylonDirection.Right

            End Select

        End If


        Return PylonDirection.None

    End Function


End Class
