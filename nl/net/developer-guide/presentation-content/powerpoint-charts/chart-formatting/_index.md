---
title: Diagrammen in presentaties opmaken in .NET
linktitle: Diagramopmaak
type: docs
weight: 60
url: /nl/net/chart-formatting/
keywords:
- diagram opmaken
- diagramopmaak
- diagramonderdeel
- diagrameigenschappen
- diagraminstellingen
- diagramopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides voor .NET en til uw PowerPoint-presentatie naar een professioneel, opvallend gestyled niveau."
---
## **Overzicht**

Dit artikel legt uit hoe je diagrammen in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het toont hoe je belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wand‑vullingen kunt aanpassen om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het laat ook zien hoe je lettertype‑eigenschappen voor diagramtekst instelt, vooraf‑ingestelde en aangepaste numerieke opmaak op diagramgegevens toepast, en afgeronde hoeken voor het diagramgebied inschakelt. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de gegevenspresentatie van diagrammen in een presentatie kunt beheersen.

## **Diagramonderdelen opmaken**
Aspose.Slides for .NET stelt ontwikkelaars in staat om vanaf nul aangepaste diagrammen aan hun dia’s toe te voegen. Dit artikel legt uit hoe je verschillende diagramonderdelen opmaakt, inclusief de categorie‑ en waardenas van een diagram.

Aspose.Slides for .NET biedt een eenvoudige API voor het beheren van verschillende diagramonderdelen en het opmaken ervan met aangepaste waarden:

1. Maak een instantie van de **Presentation**‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en het gewenste type (in dit voorbeeld gebruiken we ChartType.LineWithMarkers).
1. Toegang tot de Value Axis van het diagram en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor Value Axis Major Grid‑lines
   1. Instellen van **Line format** voor Value Axis Minor Grid‑lines
   1. Instellen van **Number Format** voor Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor Value Axis
   1. Instellen van **Text Properties** voor Value Axis‑gegevens
   1. Instellen van **Title** voor Value Axis
   1. Instellen van **Line Format** voor Value Axis
1. Toegang tot de Category Axis van het diagram en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor Category Axis Major Grid‑lines
   1. Instellen van **Line format** voor Category Axis Minor Grid‑lines
   1. Instellen van **Text Properties** voor Category Axis‑gegevens
   1. Instellen van **Title** voor Category Axis
   1. Instellen van **Label Positioning** voor Category Axis
   1. Instellen van **Rotation Angle** voor Category Axis‑labels
1. Toegang tot de Legend van het diagram en stel de **Text Properties** hiervoor in
1. Toon diagramlegenda’s zonder de diagrammen te overlappen
1. Toegang tot de **Secondary Value Axis** van het diagram en stel de volgende eigenschappen in:
   1. Schakel de secundaire **Value Axis** in
   1. Instellen van **Line Format** voor Secondary Value Axis
   1. Instellen van **Number Format** voor Secondary Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor Secondary Value Axis
1. Plot nu de eerste diagramreeks op de Secondary Value Axis
1. Stel de vulkleur van de achterwand van het diagram in
1. Stel de vulkleur van het plotgebied van het diagram in
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

```c#
// Presentatie instantieren// Presentatie instantieren
Presentation pres = new Presentation();

// Toegang tot de eerste dia
ISlide slide = pres.Slides[0];

// Voorbeelddiagram toevoegen
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Diagramtitel instellen
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Opmaak van hoofd‑rasterlijnen voor waardenas instellen
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Opmaak van kleine rasterlijnen voor waardenas instellen
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Nummeropmaak voor waardenas instellen
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Maximum‑ en minimumwaarden voor diagram instellen
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Teksteigenschappen voor waardenas instellen
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Titel voor waardenas instellen
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Lijnopmaak voor waardenas instellen: nu verouderd
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Opmaak van hoofd‑rasterlijnen voor categoriemodus instellen
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Opmaak van kleine rasterlijnen voor categoriemodus instellen
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Teksteigenschappen voor categoriemodus instellen
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Categoriatitel instellen
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Labelpositie van categoriemodus instellen
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Rotatiehoek van categoriemodus‑labels instellen
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Teksteigenschappen voor legenda instellen
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Legenda’s weergeven zonder het diagram te overlappen

chart.Legend.Overlay = true;
            
// Eerste reeks plotten op secundaire waardenas
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Achterwandkleur van diagram instellen
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Kleur van plot‑gebied instellen
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Lettertype‑eigenschappen instellen voor een diagram**
Aspose.Slides for .NET biedt ondersteuning voor het instellen van lettertype‑gerelateerde eigenschappen voor een diagram. Volg de onderstaande stappen om de lettertype‑eigenschappen voor een diagram in te stellen.

- Maak een **Presentation**‑object.
- Voeg een diagram toe op de dia.
- Stel de lettertype‑hoogte in.
- Sla de aangepaste presentatie op.

Hieronder staat een voorbeeld.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **Numerieke opmaak instellen**
Aspose.Slides for .NET biedt een eenvoudige API voor het beheren van de opmaak van diagramgegevens:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en het gewenste type (dit voorbeeld gebruikt **ChartType.ClusteredColumn**).
1. Stel de vooraf‑ingestelde nummeropmaak in uit de beschikbare preset‑waarden.
1. Doorloop elke cel in de diagramgegevens van elke diagramreeks en stel de nummeropmaak van de diagramgegevens in.
1. Sla de presentatie op.
1. Stel een aangepaste nummeropmaak in.
1. Doorloop de diagramgegevenscellen in elke reeks en stel een andere nummeropmaak in.
1. Sla de presentatie op.

```c#
// Instantieer de presentatie// Instantieer de presentatie
Presentation pres = new Presentation();

// Toegang tot de eerste presentatiedia
ISlide slide = pres.Slides[0];

// Een standaard gegroepeerde kolomdiagram toevoegen
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Toegang tot de collecties van grafiekreeksen
IChartSeriesCollection series = chart.ChartData.Series;

// Vooraf ingestelde nummeropmaak instellen
// Doorloop elke grafiekreeks
foreach (ChartSeries ser in series)
{
    // Doorloop elke gegevenscel in de reeks
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Nummeropmaak instellen
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Presentatie opslaan
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

De mogelijke vooraf‑ingestelde nummeropmaak‑waarden, inclusief hun preset‑index, die je kunt gebruiken, staan hieronder:

|**0**|Algemeen|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Afgeronde hoeken voor diagramgebied instellen**
Aspose.Slides for .NET ondersteunt het instellen van het diagramgebied. De eigenschappen **IChart.HasRoundedCorners** en **Chart.HasRoundedCorners** zijn toegevoegd in Aspose.Slides.

1. Maak een `Presentation`‑object.
1. Voeg een diagram toe op de dia.
1. Stel het vultype en de vulkleur van het diagram in.
1. Schakel de eigenschap voor afgeronde hoeken in op **True**.
1. Sla de aangepaste presentatie op.

Hieronder staat een voorbeeld.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Veelgestelde vragen**

**Kan ik halftransparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. Transparantie van de vulling en de omtrek worden afzonderlijk geconfigureerd. Dit is handig om de leesbaarheid van rasterlijnen en gegevens in dichte visualisaties te verbeteren.

**Hoe ga ik om met gegevenslabels die elkaar overlappen?**

Verklein de lettertypegrootte, schakel niet‑essentiële labelonderdelen uit (bijv. categorieën), stel de offset/positie van het label in, toon alleen labels voor geselecteerde punten indien nodig, of wijzig het formaat naar “waarde + legenda”.

**Kan ik een verloop‑ of patroonvulling op een reeks toepassen?**

Ja. Zowel effen als verloop‑/patroonvullingen zijn meestal beschikbaar. In de praktijk gebruik je verlopen spaarzaam en vermijd je combinaties die het contrast met rasterlijnen en tekst verminderen.