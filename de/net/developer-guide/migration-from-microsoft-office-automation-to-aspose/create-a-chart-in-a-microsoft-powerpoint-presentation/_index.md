---
title: Erstellen eines Diagramms in einer Microsoft PowerPoint-Präsentation
type: docs
weight: 80
url: /de/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Diagramme sind visuelle Darstellungen von Daten, die in Präsentationen häufig verwendet werden. Dieser Artikel zeigt den Code zum programmgesteuerten Erstellen eines Diagramms in Microsoft PowerPoint mit [VSTO](/slides/de/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) und [Aspose.Slides für .NET](/slides/de/net/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Einen Diagramm erstellen**
Die folgenden Codebeispiele beschreiben den Prozess zum Hinzufügen eines einfachen 3D-Clusterdiagramms mit VSTO. Sie erstellen eine Präsentationsinstanz, fügen ein Standarddiagramm hinzu. Dann verwenden Sie das Microsoft Excel-Arbeitsbuch, um auf die Diagrammdaten zuzugreifen und diese zu ändern sowie die Diagrammeigenschaften festzulegen. Schließlich speichern Sie die Präsentation.
## **VSTO-Beispiel**
Mit VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Fügen Sie ein **3D-Clusterdiagramm** hinzu und greifen Sie darauf zu.
1. Erstellen Sie eine neue Microsoft Excel-Arbeitsmappe und laden Sie die Diagrammdaten.
1. Greifen Sie auf das Diagrammdatenarbeitsblatt über die Microsoft Excel-Arbeitsmappe zu.
1. Legen Sie den Diagrammbereich im Arbeitsblatt fest und entfernen Sie die Serien 2 und 3 aus dem Diagramm.
1. Ändern Sie die Kategoriedaten im Diagrammdatenarbeitsblatt.
1. Ändern Sie die Daten der Diagrammserie 1 im Diagrammdatenarbeitsblatt.
1. Greifen Sie nun auf den Diagrammtitel zu und legen Sie die Schriftarteigenschaften fest.
1. Greifen Sie auf die Werteachse des Diagramms zu und legen Sie die Haupt- und Nebenwerte, den Maximal- und Minimalwert fest.
1. Greifen Sie auf die Tiefen- oder Serienachse des Diagramms zu und entfernen Sie diese, da in diesem Beispiel nur eine Serie verwendet wird.
1. Setzen Sie nun die Drehwinkel des Diagramms in X- und Y-Richtung.
1. Speichern Sie die Präsentation.
1. Schließen Sie die Instanzen von Microsoft Excel und PowerPoint.

**Die Ausgabpräsentation, erstellt mit VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



```c#
EnsurePowerPointIsRunning(true, true);

//Instantiate slide object
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

//Access the first slide of presentation
objSlide = objPres.Slides[1];

//Select firs slide and set its layout
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

//Add a default chart in slide
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

//Access the added chart
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

//Access the chart data
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

//Create instance to Excel workbook to work with chart data
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

//Accessing the data worksheet for chart
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

//Setting the range of chart
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

//Applying the set range on chart data table
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

//Setting values for categories and respective series data

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Fahrräder";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Zubehör";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Reparaturen";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Bekleidung";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//Setting chart title
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "Umsätze 2007";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

//Accessing Chart value axis
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

//Setting values axis units
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

//Accessing Chart Depth axis
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

//Setting chart rotation
ppChart.Rotation = 20; //Y-Value
ppChart.Elevation = 15; //X-Value
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX
objPres.SaveAs("C:\\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
//objPres.SaveAs(@"..\..\..\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

//Close Workbook and presentation
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```



```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;
    //
    //Try accessing the name property. If it causes an exception then
    //start a new instance of PowerPoint
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }
    //
    //blnAddPresentation is used to ensure there is a presentation loaded
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }
    //
    //BlnAddSlide is used to ensure there is at least one slide in the
    //presentation
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```




## **Aspose.Slides für .NET Beispiel**
Mit Aspose.Slides für .NET werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Fügen Sie ein **3D-Clusterdiagramm** hinzu und greifen Sie darauf zu.
1. Greifen Sie auf das Diagrammdatenarbeitsblatt über eine Microsoft Excel-Arbeitsmappe zu.
1. Entfernen Sie die ungenutzten Serien 2 und 3.
1. Greifen Sie auf die Diagrammkategorien zu und ändern Sie die Beschriftungen.
1. Greifen Sie auf Serie 1 zu und ändern Sie die Serienwerte.
1. Greifen Sie nun auf den Diagrammtitel zu und legen Sie die Schriftarteigenschaften fest.
1. Greifen Sie auf die Werteachse des Diagramms zu und legen Sie die Haupt- und Nebenwerte, den Maximal- und Minimalwert fest.
1. Setzen Sie nun die Drehwinkel des Diagramms in X- und Y-Richtung.
1. Speichern Sie die Präsentation im PPTX-Format.

**Die Ausgabpräsentation, erstellt mit Aspose.Slides**

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

```csharp
//Create empty presentation
using (Presentation pres = new Presentation())
{

    //Accessing first slide
    ISlide slide = pres.Slides[0];

    //Addding default chart
    IChart ppChart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20F, 30F, 400F, 300F);

    //Getting Chart data
    IChartData chartData = ppChart.ChartData;

    //Removing Extra default series
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    //Modifying chart categories names
    chartData.Categories[0].AsCell.Value = "Fahrräder";
    chartData.Categories[1].AsCell.Value = "Zubehör";
    chartData.Categories[2].AsCell.Value = "Reparaturen";
    chartData.Categories[3].AsCell.Value = "Bekleidung";

    //Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;


    //Getting the chart data worksheet
    IChartDataWorkbook fact = ppChart.ChartData.ChartDataWorkbook;

    //Modifying chart series values for first category
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, 3000));

    //Setting Chart title
    ppChart.HasTitle = true;
    ppChart.ChartTitle.AddTextFrameForOverriding("Umsätze 2007");
    IPortionFormat format = ppChart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;


    ////Setting Axis values
    ppChart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    ppChart.Axes.VerticalAxis.MaxValue = 4000.0F;
    ppChart.Axes.VerticalAxis.MinValue = 0.0F;
    ppChart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    ppChart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    ppChart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    //Setting Chart rotation
    ppChart.Rotation3D.RotationX = 15;
    ppChart.Rotation3D.RotationY = 20;

    //Saving Presentation
    pres.Save("AsposeSampleChart.pptx", SaveFormat.Pptx);
}
```



{{% alert color="primary" %}} 

## **Ressourcen**
Die in diesem Artikel verwendeten Projekte und Dateien können von unserer Website heruntergeladen werden:

- [Laden Sie die mit VSTO erstellte Präsentation herunter](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx).
- [Laden Sie das mit Aspose.Slides erstellte Beispieldiagramm herunter](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx).

{{% /alert %}}