---
title: Diagrammen in presentaties formatteren in .NET
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
description: "Leer diagramopmaak in Aspose.Slides voor .NET en verbeter uw PowerPoint-presentatie met aangepaste assen, lettertypen, getalformaten en afgeronde diagramranden."
---
## **Overzicht**

Dit artikel legt uit hoe je diagrammen in PowerPoint‑presentaties kunt opmaken met behulp van Aspose.Slides. Het laat zien hoe je belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en vulvlakken van wanden kunt aanpassen om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het laat ook zien hoe je lettertype‑eigenschappen voor diagramtekst instelt, vooraf ingestelde numerieke formaten op diagramgegevens toepast en afgeronde hoeken voor het diagramgebied inschakelt. Samen tonen deze voorbeelden hoe je zowel de visuele stijl als de gegevenspresentatie van diagrammen in een presentatie kunt beheersen.

Voor afzonderlijke vullingen en contouren bij stijgende en dalende intervallen, zie het [stapeldiagramvoorbeeld](/slides/nl/net/create-chart/#create-stock-charts).

## **Diagramonderdelen opmaken**

Gebruik [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) om diagramtitels, assen, rasterlijnen, legenda’s en het plotgebied op te maken. Dit voorbeeld maakt een lijndiagram met markeringen en standaardgegevens, en past vervolgens afzonderlijke tekst‑ en lijntstijlen toe op de waarden‑ en categorie‑assen. Lettergroottes en lijndiktes worden gespecificeerd in punten; categorie‑labels worden 45 graden gedraaid.

De waardenas gebruikt [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) onafhankelijk van de broncellen. De schaal loopt van -2 tot 15, met hoofdintervallen van 2 en subintervallen van 0,5. Het voorbeeld combineert ook procentopmaak met [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) ingesteld op duizenden, dus pas deze instellingen aan op de betekenis en omvang van je gegevens. De legenda blijft buiten het plotgebied omdat [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) is uitgeschakeld. Achterwand‑ en vloervullingen worden geconfigureerd via [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) en [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), maar deze oppervlakken zijn alleen zichtbaar in 3D‑diagrammen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Lettertype‑eigenschappen voor een diagram instellen**

Stel de standaardlettergrootte voor diagramtekst in via [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). Het voorbeeld maakt een gegroepeerd kolomdiagram met een lettertype van 20 punten en schakelt waardelabels in voor de eerste serie via [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Tekstelementen met hun eigen expliciete lettertype‑instellingen kunnen de standaard van het diagram overschrijven.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Tekstvakopmaak hergebruiken voor een diagramlegenda**

Om een legenda aan te passen aan een dia‑kop, stel je het lettertype in van de eerste alinea's [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/). Roep [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) aan op de legenda's [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/). Het leest de tekstvak‑instellingen, de opmaak van de eerste alinea en de standaardlettertype‑eigenschappen van die alinea. Opmaak die rechtstreeks op individuele delen of op latere alinea's wordt toegepast, blijft lokaal voor de bron.

Het voorbeeld gebruikt een vet, 26‑punten Calibri‑kop in marineblauw als sjabloon. Na het stijlen van de legenda wordt [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) gebruikt om dezelfde opmaak toe te passen op een afzonderlijk bijschrift.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

In de opgeslagen presentatie komen de legenda en het bijschrift overeen met de kop in grootte, gewicht en kleur. De legenda toont nog steeds de serienaam​en, en het bijschrift behoudt zijn eigen tekst. Als een deel in het bijschrift al een expliciete lettergrootte heeft, heeft die grootte voorrang op de gekopieerde alinea‑standaard.

| Voor kopiëren | Na kopiëren |
| --- | --- |
| ![Kwartaalverkoopdiagram met gewone zwarte legenda‑labels en een zwart bijschrift](legend-formatting-before.png) | ![Hetzelfde diagram met grotere, vette marineblauwe legenda‑labels en een passend bijschrift](legend-formatting.png) |

## **Numeriek formaat instellen**

Gebruik [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) om een ingebouwd getalformaat toe te passen op diagram‑werkbladcellen. Dit voorbeeld maakt een gegroepeerd kolomdiagram met standaard, cel‑ondersteunde gegevens en past formaat‑index 10 (`0.00%`) toe op elke seriewaarde‑cel. Dit verandert hoe de waarden worden weergegeven in het werkblad zonder de onderliggende getallen te wijzigen; bijvoorbeeld, 0.25 wordt weergegeven als 25,00 %. As‑ en gegevens‑label‑formaten kunnen afzonderlijk worden geconfigureerd.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

De volgende tabel geeft ingebouwde getalformaat‑indices weer met representatieve Excel‑formaten voor de Engelse (Verenigde Staten) locale. De exacte opmaak‑strings en hun weergave kunnen variëren per toepassing en locale, met name voor valuta en datums. Sommige Excel‑formaten verschillen ook van de standaarden in de OOXML‑specificatie, zoals beschreven in [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Opmaak |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Afgeronde randen van diagramgebied instellen**

Schakel [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) in om de hoeken van het diagramgebied af te ronden. Het voorbeeld maakt een gegroepeerd kolomdiagram en gebruikt [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) om de omtrek een effen grijze kleur en een enkel‑lijn‑stijl te geven voordat de presentatie wordt opgeslagen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Bestaande diagramannotaties bewerken**

Een diagram kan aangepaste vormen bevatten, zoals een tekstannotatie die de status van een rapport uitlegt. Toegang tot deze vormen krijg je via [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), ook vermeld onder [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) in de Chart‑API‑referentie. De [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑collectie bevat de diagram‑eigendomsvormen.

Een gewone tekstvak die boven een diagram wordt geplaatst, behoort tot de dia, zelfs als het lijkt op een onderdeel van het diagram. Door te itereren via [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) worden het diagram en gewone dia‑vormen gevonden, maar niet de afzonderlijke vormen binnen het diagram. Diagramtitels en gegevenslabels zijn afzonderlijke diagramonderdelen, geen aangepaste annotaties in deze collectie.

Download [chart-annotations.pptx](chart-annotations.pptx) en plaats het in de werkmap van de applicatie. De eerste dia bevat een diagram met een niet‑gegroepeerde annotatie met de tekst "Preliminary results", een diagram‑eigendomslijn, en een gewone dia‑tekstvak met de tekst "Slide overlay". Het voorbeeld vindt het eerste diagram op die dia en wijzigt de annotatie naar "Final results" wanneer het rapport klaar is voor publicatie. Het controleert op een lege collectie en bewerkt alleen een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) met een niet‑null [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) en de verwachte tekst.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

De lijn en het dia‑tekstvak blijven ongewijzigd. De volgende afbeeldingen tonen de invoer en het opgeslagen, opnieuw geopende resultaat:

| Voor bewerken | Na bewerken |
| --- | --- |
| ![Diagramannotatie met tekst Preliminary results](chart-annotations-before.png) | ![Diagramannotatie met tekst Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Het voorbeeld inspecteert alleen de diagram‑eigendomsvormen op het hoogste niveau. Als een annotatie zich binnen een [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) bevindt, inspecteer dan ook de [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑collectie van die groep. Herhaal dit recursief voor geneste groepen, en pas dezelfde tekstcontroles toe op hun onderliggende vormen. Een groep zelf is een container; beschouw het niet als een tekstvak.
{{% /alert %}}

## **Veelgestelde vragen**

**Kan ik semi‑transparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**  
Ja. De vultransparantie en de omlijning worden apart geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe kan ik omgaan met gegevenslabels wanneer ze elkaar overlappen?**  
Verklein de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), pas de labelpositie aan, toon labels alleen voor geselecteerde punten indien nodig, of wijzig het formaat naar "waarde + legenda".

**Kan ik verloop‑ of patroonvullingen toepassen op series?**  
Ja. Series ondersteunen solide, verloop‑ en patroonvullingen. Gebruik in de praktijk verloop voorzichtig en vermijd combinaties die het contrast met het raster en de tekst verminderen.