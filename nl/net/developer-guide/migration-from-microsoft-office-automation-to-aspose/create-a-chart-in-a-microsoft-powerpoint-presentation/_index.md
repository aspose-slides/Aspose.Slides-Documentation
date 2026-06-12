---
title: Grafieken maken met VSTO en Aspose.Slides voor .NET
linktitle: Grafiek maken
type: docs
weight: 80
url: /nl/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- grafiek maken
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe je het maken van PowerPoint-grafieken kunt automatiseren in C#. Deze stapsgewijze handleiding toont waarom Aspose.Slides voor .NET een snellere, krachtigere alternatief is voor Microsoft.Office.Interop."
---
## **Overzicht**

Dit artikel laat zien hoe je grafieken kunt maken en aanpassen in Microsoft PowerPoint‑presentaties via code met C#. Met Aspose.Slides voor .NET kun je de generatie van professionele, data‑gedreven grafieken automatiseren zonder Microsoft Office of Interop‑bibliotheken. De API biedt een uitgebreide reeks functies voor het bouwen van kolomgrafieken, taartgrafieken, lijngrafieken en meer — met volledige controle over uiterlijk, gegevens en lay‑out. Of je nu rapporten, dashboards of zakelijke presentaties genereert, Aspose.Slides helpt je hoogwaardige visualisaties te leveren rechtstreeks vanuit je .NET‑applicaties.

## **VSTO‑voorbeeld**

Deze sectie demonstreert hoe je een grafiek maakt in een Microsoft PowerPoint‑presentatie met **VSTO (Visual Studio Tools for Office)**. Met VSTO kun je programmatisch grafieken genereren en aanpassen door PowerPoint‑ en Excel‑automatisering te combineren. Het voorbeeld toont hoe je een **3D gegroepeerde kolomgrafiek** toevoegt, deze vult met gegevens uit een Excel‑werkblad, de opmaak en lay‑out aanpast en de uiteindelijke presentatie opslaat — alles vanuit een .NET‑applicatie.

1. Maak een instantie van een Microsoft PowerPoint‑presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een 3D gegroepeerde kolomgrafiek toe en krijg er toegang toe.
1. Maak een nieuw Microsoft Excel‑werkboek en laad de grafiekgegevens.
1. Open het werkblad met de grafiekgegevens via de Excel‑werkboek‑instantie.
1. Stel het grafiekbereik in het werkblad in en verwijder serie 2 en 3 uit de grafiek.
1. Wijzig de categorie‑gegevens van de grafiek in het werkblad met grafiekgegevens.
1. Wijzig de gegevens van serie 1 in het werkblad met grafiekgegevens.
1. Open de grafiektitel en stel de lettertype‑eigenschappen in.
1. Open de waardenas van de grafiek en stel de hoofd‑, onder‑, maximale en minimale eenheid in.
1. Open de diepte‑as (series) van de grafiek en verwijder deze — er wordt slechts één serie gebruikt in dit voorbeeld.
1. Stel de rotatiehoeken van de grafiek in de X‑ en Y‑richting in.
1. Sla de presentatie op.
1. Sluit de Microsoft Excel‑ en PowerPoint‑instanties.

```c#
EnsurePowerPointIsRunning(true, true);

// Instantieer een slide‑object.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Toegang tot de eerste presentatiedia.
objSlide = objPres.Slides[1];

// Selecteer de eerste dia en stel de lay‑out in.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Voeg een standaardgrafiek toe aan de dia.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Toegang tot de toegevoegde grafiek.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Toegang tot de grafiekgegevens.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Maak een instantie van het Excel‑werkboek om met de grafiekgegevens te werken.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Toegang tot het gegevenswerkblad voor de grafiek.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Stel het gegevensbereik voor de grafiek in.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Pas het opgegeven bereik toe op de grafiek‑datatabel.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Stel waarden in voor categorieën en bijbehorende seriesgegevens.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Stel de grafiektitel in.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Toegang tot de waardenas van de grafiek.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Stel de waarden voor de as‑eenheden in.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Toegang tot de diepte‑as van de grafiek.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Stel de rotatie van de grafiek in.
ppChart.Rotation = 20;   // Y-waarde
ppChart.Elevation = 15;  // X-waarde
ppChart.RightAngleAxes = false;

// Sla de presentatie op als een PPTX‑bestand.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Sluit het werkboek en de presentatie.
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

    // Probeer de Name‑eigenschap te benaderen. Als er een uitzondering wordt opgegooid, start een nieuwe instantie van PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation wordt gebruikt om te garanderen dat er een presentatie is geladen.
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

    // blnAddSlide wordt gebruikt om te garanderen dat er minstens één dia in de presentatie bestaat.
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

Het resultaat:

![De grafiek gemaakt met VSTO](chart-created-using-VSTO.png)

## **Aspose.Slides voor .NET‑voorbeeld**

Het volgende voorbeeld laat zien hoe je een eenvoudige grafiek maakt in een PowerPoint‑presentatie met Aspose.Slides voor .NET. Deze code demonstreert hoe je een **3D gegroepeerde kolomgrafiek** toevoegt, vult met voorbeeldgegevens en het uiterlijk aanpast. Met slechts een paar regels code kun je dynamisch grafieken genereren en integreren in je presentaties zonder Microsoft Office te gebruiken.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar de eerste dia.
1. Voeg een 3D gegroepeerde kolomgrafiek toe en krijg er toegang toe.
1. Open de grafiekgegevens.
1. Verwijder de ongebruikte Serie 2 en Serie 3.
1. Pas de grafieccategorieën aan door de labels bij te werken.
1. Werk de waarden van Serie 1 bij.
1. Open de grafiektitel en stel de lettertype‑eigenschappen in.
1. Configureer de waardenas van de grafiek, inclusief hoofd‑, onder‑, maximale en minimale waarden.
1. Stel de rotatiehoeken van de grafiek in op de X‑ en Y‑assen.
1. Sla de presentatie op in PPTX‑formaat.

```cs
// Maak een lege presentatie.
using (Presentation presentation = new Presentation())
{
    // Toegang tot de eerste dia.
    ISlide slide = presentation.Slides[0];

    // Voeg een standaardgrafiek toe.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Haal de grafiekgegevens op.
    IChartData chartData = chart.ChartData;

    // Verwijder de extra standaardseries.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Wijzig de categorienamen van de grafiek.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Stel de index van het werkblad met grafiekgegevens in.
    int worksheetIndex = 0;

    // Haal het werkboek met grafiekgegevens op.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Wijzig de waarden van de grafiekseries.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Stel de grafiektitel in.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Stel de asopties in.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Stel de rotatie van de grafiek in.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Sla de presentatie op als een PPTX-bestand.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De grafiek gemaakt met Aspose.Slides voor .NET](chart-created-using-aspose-slides.png)

## **FAQ**

**Kan ik andere soorten grafieken maken, zoals taart-, lijn‑ of staafgrafieken met Aspose.Slides?**

Ja. Aspose.Slides voor .NET ondersteunt een breed scala aan [grafiektype](/slides/nl/net/create-chart/), waaronder taartgrafieken, lijngrafieken, staafgrafieken, spreidingsdiagrammen, bubbelgrafieken en meer. Je kunt het gewenste grafiektype opgeven met de [ChartType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/)‑enumeratie bij het toevoegen van een grafiek.

**Kan ik aangepaste stijlen of thema's toepassen op de grafiek?**

Ja. Je kunt het uiterlijk van de grafiek volledig aanpassen, inclusief kleuren, lettertypen, vul‑ en lijnstijlen, rasterlijnen en lay‑out. Het exact toepassen van Office‑thema’s zoals in PowerPoint vereist echter handmatig instellen van afzonderlijke stijlen.

**Kan ik de grafiek los exporteren als afbeelding van de dia?**

Ja, Aspose.Slides maakt het mogelijk om elke vorm — inclusief grafieken — als een aparte afbeelding (bijv. PNG, JPEG) te exporteren met de `GetImage`‑methode op de grafiek‑[shape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/).