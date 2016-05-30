Public Class BallotBatchDialog
    Public Enum EnumState
        Start
        Midway
        Finished
    End Enum
    Private _state As enumState

    Public Property State As enumState
        Get
            Return _state
        End Get
        Set(value As enumState)
            _state = value
            Select Case _state
                Case enumState.Start
                    pnlFirst.Visible = True
                    pnlMidway.Visible = False
                    pnlFinished.Visible = False
                Case enumState.Midway
                    pnlFirst.Visible = False
                    pnlMidway.Visible = True
                    pnlFinished.Visible = False
                Case enumState.Finished
                    pnlFirst.Visible = False
                    pnlMidway.Visible = False
                    pnlFinished.Visible = True
            End Select
        End Set
    End Property

End Class