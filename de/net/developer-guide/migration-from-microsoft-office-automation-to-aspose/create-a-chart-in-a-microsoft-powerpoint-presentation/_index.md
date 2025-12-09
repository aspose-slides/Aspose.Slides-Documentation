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
description: "Erfahren Sie, wie Sie die Erstellung von PowerPoint-Diagrammen in C# automatisieren. Diese Schritt-für-Schritt-Anleitung zeigt, warum Aspose.Slides für .NET eine schnellere und leistungsstärkere Alternative zu Microsoft.Office.Interop ist."
---

## **Übersicht**

Dieser Artikel demonstriert, wie man Diagramme in Microsoft PowerPoint‑Präsentationen programmgesteuert mit C# erstellt und anpasst. Mit Aspose.Slides für .NET können Sie die Erstellung professioneller, datengetriebener Diagramme automatisieren, ohne Microsoft Office oder Interop‑Bibliotheken zu verwenden. Die API bietet einen umfangreichen Funktionsumfang zum Erstellen von Säulendiagrammen, Kreisdiagrammen, Liniendiagrammen und mehr – alles mit voller Kontrolle über Aussehen, Daten und Layout. Egal, ob Sie Berichte, Dashboards oder Geschäfts‑präsentationen erstellen, hilft Aspose.Slides Ihnen, hochwertige Visualisierungen direkt aus Ihren .NET‑Anwendungen bereitzustellen.

## **VSTO‑Beispiel**

Dieser Abschnitt demonstriert, wie man ein Diagramm in einer Microsoft PowerPoint‑Präsentation mithilfe von **VSTO (Visual Studio Tools for Office)** erstellt. Mit VSTO können Sie programmgesteuert Diagramme erzeugen und anpassen, indem Sie PowerPoint‑ und Excel‑Automatisierung kombinieren. Das bereitgestellte Beispiel zeigt, wie man ein **3D gruppiertes Säulendiagramm** hinzufügt, es mit Daten aus einem Excel‑Arbeitsblatt füllt, Formatierung und Layout anpasst und die fertige Präsentation speichert – alles innerhalb einer .NET‑Anwendung.

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint‑Präsentation.  
1. Fügen Sie der Präsentation eine leere Folie hinzu.  
1. Fügen Sie ein 3D gruppiertes Säulendiagramm hinzu und greifen Sie darauf zu.  
1. Erstellen Sie eine neue Microsoft Excel‑Arbeitsmappendatei‑Instanz und laden Sie die Diagrammdaten.  
1. Greifen Sie mit der Excel‑Arbeitsmappendatei‑Instanz auf das Diagrammdaten‑Arbeitsblatt zu.  
1. Legen Sie den Diagrammbereich im Arbeitsblatt fest und entfernen Sie Serie 2 und 3 aus dem Diagramm.  
1. Ändern Sie die Diagrammkategorien im Diagrammdaten‑Arbeitsblatt.  
1. Ändern Sie die Daten von Serie 1 im Diagrammdaten‑Arbeitsblatt.  
1. Greifen Sie auf den Diagrammtitel zu und setzen Sie dessen schriftenbezogene Eigenschaften.  
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die Haupteinheit, Nebeneinheit, den Maximalwert und den Minimalwert.  
1. Greifen Sie auf die Tiefen‑ (Serien‑)Achse des Diagramms zu und entfernen Sie sie – in diesem Beispiel wird nur eine Serie verwendet.  
1. Setzen Sie die Rotationswinkel des Diagramms in X‑ und Y‑Richtung.  
1. Speichern Sie die Präsentation.  
1. Schließen Sie die Microsoft Excel‑ und PowerPoint‑Instanzen.  

```c#
EnsurePowerPointIsRunning(true, true);

// Instanziieren Sie ein Folienobjekt.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Greifen Sie auf die erste Folie der Präsentation zu.
objSlide = objPres.Slides[1];

// Wählen Sie die erste Folie aus und setzen Sie ihr Layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Fügen Sie der Folie ein Standarddiagramm hinzu.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Greifen Sie auf das hinzugefügte Diagramm zu.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Greifen Sie auf die Diagrammdaten zu.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Erstellen Sie eine Instanz der Excel-Arbeitsmappe, um mit den Diagrammdaten zu arbeiten.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Greifen Sie auf das Datenarbeitsblatt für das Diagramm zu.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Setzen Sie den Datenbereich für das Diagramm.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Wenden Sie den angegebenen Bereich auf die Diagrammdaten‑Tabelle an.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Setzen Sie Werte für Kategorien und zugehörige Seriendaten.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Setzen Sie den Diagrammtitel.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Greifen Sie auf die Werte‑Achse des Diagramms zu.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Setzen Sie die Werte für die Achseneinheiten.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Greifen Sie auf die Tiefen‑Achse des Diagramms zu.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Setzen Sie die Diagrammdrehung.
ppChart.Rotation = 20;   // Y‑Wert
ppChart.Elevation = 15;  // X‑Wert
ppChart.RightAngleAxes = false;

// Speichern Sie die Präsentation als PPTX‑Datei.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Schließen Sie die Arbeitsmappe und die Präsentation.
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

    // Versuchen Sie, die Name‑Eigenschaft zuzugreifen. Wenn sie eine Ausnahme wirft, starten Sie eine neue PowerPoint‑Instanz.
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

![Das Diagramm erstellt mit VSTO](chart-created-using-VSTO.png)

## **Aspose.Slides für .NET Beispiel**

Das folgende Beispiel zeigt, wie man ein einfaches Diagramm in einer PowerPoint‑Präsentation mit Aspose.Slides für .NET erstellt. Dieser Code demonstriert, wie ein **3D gruppiertes Säulendiagramm** hinzugefügt, mit Beispieldaten gefüllt und sein Erscheinungsbild angepasst wird. Mit nur wenigen Codezeilen können Sie Diagramme dynamisch erzeugen und in Ihre Präsentationen integrieren, ohne Microsoft Office zu verwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie eine Referenz zur ersten Folie.  
1. Fügen Sie ein 3D gruppiertes Säulendiagramm hinzu und greifen Sie darauf zu.  
1. Greifen Sie auf die Diagrammdaten zu.  
1. Entfernen Sie die nicht verwendeten Serien 2 und 3.  
1. Ändern Sie die Diagrammkategorien, indem Sie die Beschriftungen aktualisieren.  
1. Aktualisieren Sie die Werte von Serie 1.  
1. Greifen Sie auf den Diagrammtitel zu und setzen Sie dessen Schriftarteigenschaften.  
1. Konfigurieren Sie die Werte‑Achse des Diagramms, einschließlich Haupteinheit, Nebeneinheit, Maximal‑ und Minimalwert.  
1. Setzen Sie die Rotationswinkel des Diagramms auf den X‑ und Y‑Achsen.  
1. Speichern Sie die Präsentation im PPTX‑Format.  

```cs
// Erstelle eine leere Präsentation.
using (Presentation presentation = new Presentation())
{
    // Greifen Sie auf die erste Folie zu.
    ISlide slide = presentation.Slides[0];

    // Fügen Sie ein Standarddiagramm hinzu.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Holen Sie die Diagrammdaten.
    IChartData chartData = chart.ChartData;

    // Entfernen Sie die zusätzlichen Standardserien.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Ändern Sie die Diagrammkategorienamen.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Setzen Sie den Index des Diagrammdatentabellenblatts.
    int worksheetIndex = 0;

    // Holen Sie die Diagrammdatentabelle.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ändern Sie die Diagrammserienwerte.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Setzen Sie den Diagrammtitel.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Setzen Sie die Achsenoptionen.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Setzen Sie die Diagrammdrehung.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Speichern Sie die Präsentation als PPTX-Datei.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Das Diagramm erstellt mit Aspose.Slides für .NET](chart-created-using-aspose-slides.png)

## **FAQ**

**Kann ich mit Aspose.Slides andere Diagrammtypen wie Kreis-, Linien- oder Balkendiagramme erstellen?**

Ja. Aspose.Slides für .NET unterstützt eine breite Palette von [Diagrammtypen](https://docs.aspose.com/slides/net/create-chart/), einschließlich Kreisdiagrammen, Liniendiagrammen, Balkendiagrammen, Streudiagrammen, Blasendiagrammen und mehr. Sie können den gewünschten Diagrammtyp mithilfe der [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)-Enumeration beim Hinzufügen eines Diagramms angeben.

**Kann ich benutzerdefinierte Stile oder Designs auf das Diagramm anwenden?**

Ja. Sie können das Erscheinungsbild des Diagramms vollständig anpassen, einschließlich Farben, Schriftarten, Füllungen, Konturen, Gitternetzlinien und Layout. Das exakte Anwenden von Office‑Designs, wie sie in PowerPoint zu sehen sind, erfordert jedoch das manuelle Festlegen einzelner Stile.

**Kann ich das Diagramm als Bild getrennt von der Folie exportieren?**

Ja, Aspose.Slides ermöglicht den Export jeder Form – einschließlich Diagrammen – als separates Bild (z. B. PNG, JPEG) über die `GetImage`‑Methode auf dem Diagramm‑[shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).