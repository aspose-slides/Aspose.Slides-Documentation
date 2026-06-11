---
title: Skapa diagram med VSTO och Aspose.Slides för .NET
linktitle: Skapa diagram
type: docs
weight: 80
url: /sv/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- skapa diagram
- migrering
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du automatiserar skapandet av PowerPoint-diagram i C#. Denna steg-för-steg-guide visar varför Aspose.Slides för .NET är ett snabbare, mer kraftfullt alternativ till Microsoft.Office.Interop."
---
## **Översikt**

Den här artikeln visar hur man skapar och anpassar diagram i Microsoft PowerPoint‑presentationer programmässigt med C#. Med Aspose.Slides för .NET kan du automatisera genereringen av professionella, datadrivna diagram utan att behöva Microsoft Office eller Interop‑bibliotek. API‑et erbjuder ett rikt urval av funktioner för att bygga stapeldiagram, pajdiagram, linjediagram med mera – med full kontroll över utseende, data och layout. Oavsett om du generar rapporter, instrumentpaneler eller affärspresentationer hjälper Aspose.Slides dig att leverera högkvalitativa visualiseringar direkt från dina .NET‑applikationer.

## **VSTO‑exempel**

Detta avsnitt visar hur man skapar ett diagram i en Microsoft PowerPoint‑presentation med **VSTO (Visual Studio Tools for Office)**. Med VSTO kan du programmässigt generera och anpassa diagram genom att kombinera PowerPoint‑ och Excel‑automation. Exemplet visar hur man lägger till ett **3D‑klustrat stapeldiagram**, fyller det med data från ett Excel‑arbetsblad, justerar formatering och layout samt sparar den slutliga presentationen – allt från en .NET‑applikation.

1. Skapa en instans av en Microsoft PowerPoint‑presentation.
1. Lägg till en tom bild i presentationen.
1. Lägg till ett 3D‑klustrat stapeldiagram och öppna det.
1. Skapa en ny Microsoft Excel‑arbetsbok och läs in diagramdata.
1. Öppna diagramdatabladet med hjälp av Excel‑arbetsboken.
1. Ange diagramområdet i bladet och ta bort serierna 2 och 3 från diagrammet.
1. Ändra diagramkategoridata i diagramdatabladet.
1. Ändra data för serie 1 i diagramdatabladet.
1. Öppna diagramrubriken och ange dess teckensnittsegenskaper.
1. Öppna värdeaxeln för diagrammet och ange huvud‑ och delenhet samt maximalt och minimalt värde.
1. Öppna diagrammets djupaxel (serier) och ta bort den – endast en serie används i detta exempel.
1. Ange diagrammets rotationsvinklar i X‑ och Y‑riktning.
1. Spara presentationen.
1. Stäng Microsoft Excel‑ och PowerPoint‑instanserna.

```c#
EnsurePowerPointIsRunning(true, true);

// Skapa ett bildobjekt.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Åtkomst till den första presentationsbilden.
objSlide = objPres.Slides[1];

// Välj den första bilden och ange dess layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Lägg till ett standarddiagram på bilden.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Åtkomst till det tillagda diagrammet.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Åtkomst till diagramdata.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Skapa en instans av Excel-arbetsboken för att arbeta med diagramdata.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Åtkomst till dataarbetsbladet för diagrammet.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Ange dataområdet för diagrammet.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Tillämpa det angivna området på diagrammets datatabell.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Ange värden för kategorier och respektive seriedata.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Ange diagramrubriken.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Åtkomst till diagrammets värdeaxel.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Ange värden för axelns enheter.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Åtkomst till diagrammets djupaxel.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Set the chart rotation.
ppChart.Rotation = 20;   // Y-värde
ppChart.Elevation = 15;  // X-värde
ppChart.RightAngleAxes = false;

// Spara presentationen som en PPTX‑fil.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Stäng arbetsboken och presentationen.
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

    // Försök att komma åt Name‑egenskapen. Om den kastar ett undantag, starta en ny instans av PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation används för att säkerställa att en presentation är laddad.
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

    // blnAddSlide används för att säkerställa att det finns minst en bild i presentationen.
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

Resultatet:

![Diagrammet skapat med VSTO](chart-created-using-VSTO.png)

## **Aspose.Slides för .NET‑exempel**

Följande exempel visar hur man skapar ett enkelt diagram i en PowerPoint‑presentation med Aspose.Slides för .NET. Koden demonstrerar hur man lägger till ett **3D‑klustrat stapeldiagram**, fyller det med exempeldata och anpassar dess utseende. Med bara några rader kod kan du dynamiskt generera diagram och integrera dem i dina presentationer utan Microsoft Office.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till den första bilden.
1. Lägg till ett 3D‑klustrat stapeldiagram och öppna det.
1. Öppna diagramdata.
1. Ta bort de oanvända serierna 2 och 3.
1. Ändra diagramkategorierna genom att uppdatera etiketterna.
1. Uppdatera värdena för serie 1.
1. Öppna diagramrubriken och ange dess teckensnittsegenskaper.
1. Konfigurera diagrammets värdeaxel, inklusive huvud‑ och delenhet samt maximalt och minimalt värde.
1. Ange diagrammets rotationsvinklar på X‑ och Y‑axlarna.
1. Spara presentationen i PPTX‑format.

```cs
// Skapa en tom presentation.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till ett standarddiagram.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Hämta diagramdata.
    IChartData chartData = chart.ChartData;

    // Ta bort den extra standardserien.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Ändra diagramkategorinamnen.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Ange indexet för diagramdataarbetsbladet.
    int worksheetIndex = 0;

    // Hämta diagramdataarbetsboken.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ändra diagramseriens värden.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Ange diagramrubriken.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Ange axelalternativ.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Ange diagramrotationen.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Spara presentationen som en PPTX-fil.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Diagrammet skapat med Aspose.Slides för .NET](chart-created-using-aspose-slides.png)

## **Vanliga frågor**

**Kan jag skapa andra typer av diagram, t.ex. paj-, linje- eller stapeldiagram med Aspose.Slides?**

Ja. Aspose.Slides för .NET stödjer ett brett urval av [diagramtyper](/slides/sv/net/create-chart/), inklusive pajdiagram, linjediagram, stapeldiagram, spridningsdiagram, bubbeldiagram och mer. Du kan ange önskad diagramtyp med uppräkningen [ChartType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/) när du lägger till ett diagram.

**Kan jag tillämpa anpassade stilar eller teman på diagrammet?**

Ja. Du kan fullt ut anpassa diagrammets utseende, inklusive färger, teckensnitt, fyllningar, konturer, rutnät och layout. Att tillämpa Office‑teman exakt som i PowerPoint kräver dock att du manuellt anger enskilda stilinställningar.

**Kan jag exportera diagrammet som en bild separat från bilden?**

Ja, Aspose.Slides låter dig exportera vilken form som helst – inklusive diagram – som en separat bild (t.ex. PNG, JPEG) med hjälp av metoden `GetImage` på diagrammets [shape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/).