Imports WindowsApplication1.FusionCharts.Charts
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_loadFusionCharts_Click(sender As Object, e As EventArgs) Handles btn_loadFusionCharts.Click

        ' Initiating the display html text
        Dim htmlToDisplay = "<!DOCTYPE html><html><head><meta http-equiv='X-UA-Compatible' content='IE=10' >"

        ' Declaring the libraries links of FusionCharts which are necessary
        Dim fusionChartsLibraryLinks() As String = {"http://static.fusioncharts.com/code/latest/fusioncharts.js", _
                                                    "http://static.fusioncharts.com/code/latest/fusioncharts.charts.js"}

        ' Declaring Chart parameters
        Dim chartType = "column3d"
        Dim chartId = "myChart"
        Dim chartWidth = "600"
        Dim chartHeight = "350"
        Dim dataType = "jsonurl"
        Dim linkToJSONFile = "http://static.fusioncharts.com/data/Data.json"

        ' Calling the wrapper constructor
        Dim sales As New Chart(chartType, chartId, chartWidth, chartHeight, dataType, linkToJSONFile)

        ' Having the output from wrapper
        Dim outputFromWrapper = sales.Render()

        ' Preparing the script tags for every libraries
        Dim fcScriptLink = ""
        For Each link As String In fusionChartsLibraryLinks
            fcScriptLink = fcScriptLink + "<script type='text/javascript' src='" + link + "'></script>"
        Next

        ' preparing the final out put html
        htmlToDisplay += fcScriptLink + "</head><body>" + outputFromWrapper + "</body></html>"


        'WebBrowser1.Width = Convert.ToInt32(chartWidth) + 20
        'WebBrowser1.Height = Convert.ToInt32(chartHeight) + 20

        ' showing the output html to browser tag of windows form
        WebBrowser1.DocumentText = htmlToDisplay

    End Sub
End Class
