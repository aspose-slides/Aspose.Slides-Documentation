---
title: Diagramme mit VSTO und Aspose.Slides für .NET erstellen
linktitle: Diagramm erstellen
type: docs
weight: 80
url: /de/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- Diagramm erstellen
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Erstellung von PowerPoint-Diagrammen in C# automatisieren. Dieser Schritt-für-Schritt-Leitfaden zeigt, warum Aspose.Slides für .NET eine schnellere und leistungsstärkere Alternative zu Microsoft.Office.Interop ist."
---

## **Übersicht**

Dieser Artikel zeigt, wie Diagramme in Microsoft PowerPoint‑Präsentationen programmgesteuert mit C# erstellt und angepasst werden können. Mit Aspose.Slides für .NET können Sie die Erstellung professioneller, datenbasierter Diagramme automatisieren, ohne Microsoft Office oder Interop‑Bibliotheken zu benötigen. Die API bietet einen umfangreichen Funktionsumfang zum Erstellen von Säulendiagrammen, Kreisdiagrammen, Liniendiagrammen und mehr – mit voller Kontrolle über Aussehen, Daten und Layout. Egal, ob Sie Berichte, Dashboards oder geschäftliche Präsentationen erstellen, Aspose.Slides unterstützt Sie dabei, hochwertige Visualisierungen direkt aus Ihren .NET‑Anwendungen zu liefern.

## **VSTO-Beispiel**

Dieser Abschnitt demonstriert, wie ein Diagramm in einer Microsoft PowerPoint‑Präsentation mit **VSTO (Visual Studio Tools for Office)** erstellt wird. Mit VSTO können Sie diagramme programmgesteuert erzeugen und anpassen, indem Sie PowerPoint‑ und Excel‑Automatisierung kombinieren. Das Beispiel zeigt, wie ein **3D gruppiertes Säulendiagramm** hinzugefügt, mit Daten aus einem Excel‑Arbeitsblatt gefüllt, Formatierung und Layout angepasst und die fertige Präsentation gespeichert wird – alles aus einer .NET‑Anwendung heraus.

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint‑Präsentation.  
2. Fügen Sie der Präsentation eine leere Folie hinzu.  
3. Fügen Sie ein 3D gruppiertes Säulendiagramm hinzu und greifen Sie darauf zu.  
4. Erstellen Sie eine neue Microsoft Excel‑Arbeitsmappenin­stanz und laden Sie die Diagrammdaten.  
5. Greifen Sie über die Excel‑Arbeitsmappenin­stanz auf das Diagrammdaten‑Arbeitsblatt zu.  
6. Legen Sie den Diagrammbereich im Arbeitsblatt fest und entfernen Sie Serie 2 und 3 aus dem Diagramm.  
7. Ändern Sie die Diagramm‑Kategoriedaten im Diagrammdaten‑Arbeitsblatt.  
8. Ändern Sie die Daten von Serie 1 im Diagrammdaten‑Arbeitsblatt.  
9. Greifen Sie auf den Diagrammtitel zu und setzen Sie dessen Schriftart‑bezogene Eigenschaften.  
10. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die Haupt‑Einheit, Neben‑Einheit, den Maximal‑ und Minimalwert.  
11. Greifen Sie auf die Tiefen‑Achse (Serien‑Achse) des Diagramms zu und entfernen Sie sie – in diesem Beispiel wird nur eine Serie verwendet.  
12. Legen Sie die Rotationswinkel des Diagramms in X‑ und Y‑Richtung fest.  
13. Speichern Sie die Präsentation.  
14. Schließen Sie die Microsoft Excel‑ und PowerPoint‑Instanzen.

```c#
EnsurePowerPointIsRunning(true, true);

// Instantiate a slide object.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Access the first presentation slide.
objSlide = objPres.Slides[1];

// Select the first slide and set its layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Add a default chart to the slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Access the added chart.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Access the chart data.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Create an instance of the Excel workbook to work with the chart data.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Access the data worksheet for the chart.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Set the data range for the chart.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Apply the specified range to the chart data table.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Set values for categories and respective series data.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Set the chart title.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Access the chart value axis.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Set the values for the axis units.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Access the chart depth axis.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Set the chart rotation.
ppChart.Rotation = 20;   // Y-Wert
ppChart.Elevation = 15;  // X-Wert
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX file.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Close the workbook and presentation.
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

    // Versuchen Sie, die Name-Eigenschaft zu lesen. Wenn dabei eine Ausnahme geworfen wird, starten Sie eine neue PowerPoint-Instanz.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation wird verwendet, um sicherzustellen, dass eine Präsentation geladen ist.
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

    // blnAddSlide wird verwendet, um sicherzustellen, dass mindestens eine Folie in der Präsentation vorhanden ist.
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


Das Ergebnis:

![Das mit VSTO erstellte Diagramm](chart-created-using-VSTO.png)

## **Aspose.Slides für .NET Beispiel**

Das folgende Beispiel zeigt, wie ein einfaches Diagramm in einer PowerPoint‑Präsentation mit Aspose.Slides für .NET erstellt wird. Der Code demonstriert das Hinzufügen eines **3D gruppierten Säulendiagramms**, das Befüllen mit Beispieldaten und das Anpassen des Erscheinungsbildes. Mit nur wenigen Codezeilen können Sie Diagramme dynamisch erzeugen und in Ihre Präsentationen integrieren, ohne Microsoft Office zu verwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz zur ersten Folie.  
3. Fügen Sie ein 3D gruppiertes Säulendiagramm hinzu und greifen Sie darauf zu.  
4. Greifen Sie auf die Diagrammdaten zu.  
5. Entfernen Sie die ungenutzten Serien 2 und 3.  
6. Ändern Sie die Diagramm‑Kategorien, indem Sie die Beschriftungen aktualisieren.  
7. Aktualisieren Sie die Werte von Serie 1.  
8. Greifen Sie auf den Diagrammtitel zu und setzen Sie dessen Schriftart‑Eigenschaften.  
9. Konfigurieren Sie die Werte‑Achse des Diagramms, einschließlich Haupt‑Einheit, Neben‑Einheit, Maximal‑ und Minimalwert.  
10. Legen Sie die Rotationswinkel des Diagramms auf den X‑ und Y‑Achsen fest.  
11. Speichern Sie die Präsentation im PPTX‑Format.

```cs
// Erstelle eine leere Präsentation.
using (Presentation presentation = new Presentation())
{
    // Greife auf die erste Folie zu.
    ISlide slide = presentation.Slides[0];

    // Füge ein Standarddiagramm hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Hole die Diagrammdaten.
    IChartData chartData = chart.ChartData;

    // Entferne die zusätzlichen Standardserien.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Ändere die Diagrammkategorienamen.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Setze den Index des Diagrammdaten-Arbeitsblatts.
    int worksheetIndex = 0;

    // Hole die Diagrammdaten-Arbeitsmappe.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ändere die Werte der Diagrammserien.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Setze den Diagrammtitel.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Setze die Achsenoptionen.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Setze die Diagrammrotation.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Speichere die Präsentation als PPTX-Datei.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das mit Aspose.Slides für .NET erstellte Diagramm](chart-created-using-aspose-slides.png)

## **FAQ**

**Kann ich mit Aspose.Slides andere Diagrammtypen wie Kreis-, Linien‑ oder Balkendiagramme erstellen?**

Ja. Aspose.Slides für .NET unterstützt eine breite Palette von [Diagrammtypen](https://docs.aspose.com/slides/net/create-chart/), darunter Kreisdiagramme, Liniendiagramme, Balkendiagramme, Punkt‑ und Blasendiagramme und mehr. Den gewünschten Diagrammtyp können Sie beim Hinzufügen eines Diagramms über die [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑Aufzählung angeben.

**Kann ich benutzerdefinierte Stile oder Designs auf das Diagramm anwenden?**

Ja. Sie können das Aussehen des Diagramms vollständig anpassen, einschließlich Farben, Schriftarten, Füllungen, Konturen, Gitternetzlinien und Layout. Das exakte Anwenden von Office‑Designs, wie sie in PowerPoint zu sehen sind, erfordert jedoch das manuelle Setzen einzelner Stile.

**Kann ich das Diagramm separat als Bild aus der Folie exportieren?**

Ja, Aspose.Slides ermöglicht das Exportieren jeder Form – einschließlich Diagrammen – als separates Bild (z. B. PNG, JPEG) über die `GetImage`‑Methode auf dem Diagramm‑[shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).