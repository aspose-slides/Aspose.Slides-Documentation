---
title: Formatera presentationsdiagram i .NET
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/net/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensnittsegenskaper
- rundade kanter
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för .NET och förbättra din PowerPoint-presentation med professionell, iögonfallande stil."
---
## **Översikt**

Denna artikel förklarar hur du formaterar diagram i PowerPoint-presentationer med hjälp av Aspose.Slides. Den visar hur du anpassar viktiga diagramkomponenter såsom axlar, rutnätlinjer, rubriker, förklaringar, plot‑området och väggfyllningar för att förbättra utseendet och läsbarheten för diagramdata.

Den visar också hur du anger teckensnittsegenskaper för diagramtext, använder fördefinierade och anpassade numeriska format för diagramdata samt aktiverar rundade hörn för diagramområdet. Tillsammans demonstrerar dessa exempel hur du styr både den visuella stilen och datapresentationen för diagram i en presentation.

## **Formatera diagramobjekt**
Aspose.Slides for .NET låter utvecklare lägga till anpassade diagram i sina bilder från grunden. Denna artikel förklarar hur du formaterar olika diagramobjekt inklusive diagrammets kategori‑ och värdeaxel.

Aspose.Slides for .NET tillhandahåller ett enkelt API för att hantera olika diagramobjekt och formatera dem med egna värden:

1. Skapa en instans av klassen **Presentation**.
1. Hämta en slidas referens via dess index.
1. Lägg till ett diagram med standarddata och någon av de önskade typerna (i detta exempel använder vi ChartType.LineWithMarkers).
1. Åtkomst till diagrammets **Value Axis** och ställ in följande egenskaper:
   1. Ställ in **Linjeformat** för värdeaxelns huvudrutnätlinjer
   1. Ställ in **Linjeformat** för värdeaxelns sekundära rutnätlinjer
   1. Ställ in **Number Format** för värdeaxeln
   1. Ställ in **Min, Max, Major och Minor‑enheter** för värdeaxeln
   1. Ställ in **Text Properties** för värdeaxelns data
   1. Ställ in **Title** för värdeaxeln
   1. Ställ in **Line Format** för värdeaxeln
1. Åtkomst till diagrammets **Category Axis** och ställ in följande egenskaper:
   1. Ställ in **Linjeformat** för kategori‑axelns huvudrutnätlinjer
   1. Ställ in **Linjeformat** för kategori‑axelns sekundära rutnätlinjer
   1. Ställ in **Text Properties** för kategori‑axelns data
   1. Ställ in **Title** för kategori‑axeln
   1. Ställ in **Label Positioning** för kategori‑axeln
   1. Ställ in **Rotation Angle** för kategori‑axelns etiketter
1. Åtkomst till diagrammets **Legend** och ställ in **Text Properties** för den
1. Ställ in att visa diagramförklaringar utan att de överlappar diagrammet
1. Åtkomst till diagrammets **Secondary Value Axis** och ställ in följande egenskaper:
   1. Aktivera den sekundära **Value Axis**
   1. Ställ in **Line Format** för sekundär värdeaxel
   1. Ställ in **Number Format** för sekundär värdeaxel
   1. Ställ in **Min, Max, Major och Minor‑enheter** för sekundär värdeaxel
1. Plotta nu den första diagramserien på den sekundära värdeaxeln
1. Ställ in diagrammets bakväggs fyllningsfärg
1. Ställ in diagrammets plot‑områdes fyllningsfärg
1. Skriv den modifierade presentationen till en PPTX‑fil

```c#
// Instansierar presentation// Instansierar presentation
Presentation pres = new Presentation();

// Åtkomst till den första sliden
ISlide slide = pres.Slides[0];

// Lägger till exempeldiagrammet
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Ställer in diagramtitel
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Ställer in format för huvudrutnätlinjer för värdeaxeln
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Ställer in format för sekundära rutnätlinjer för värdeaxeln
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Ställer in numeriskt format för värdeaxeln
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Ställer in diagrammets max- och minvärden
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Ställer in textegenskaper för värdeaxel
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Ställer in titel för värdeaxel
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Ställer in linjeformat för värdeaxel : Nu föråldrad
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Ställer in format för huvudrutnätlinjer för kategoriaxeln
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Ställer in format för sekundära rutnätlinjer för kategoriaxeln
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Ställer in textegenskaper för kategoriaxeln
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Ställer in kategori titel
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Ställer in position för kategori-axelns etikett
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Ställer in roteringsvinkel för kategori-axelns etikett
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Ställer in textegenskaper för förklaringar
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Ställ in att visa diagramförklaringar utan att överlappa diagrammet

chart.Legend.Overlay = true;
            
// Plottar första serien på sekundär värdeaxel
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Ställer in färg för diagrammets bakvägg
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Ställer in färg för plot‑området
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **Ange teckensnittsegenskaper för ett diagram**
Aspose.Slides for .NET erbjuder stöd för att ange teckensnittsegenskaper för diagrammet. Följ stegen nedan för att ange teckensnittsegenskaper för diagrammet.

- Instansiera objektet **Presentation**.
- Lägg till ett diagram på sliden.
- Ange teckensnittshöjd.
- Spara den modifierade presentationen.

Nedan ges ett exempel.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **Ange numeriskt format**
Aspose.Slides for .NET tillhandahåller ett enkelt API för att hantera diagramdatas format:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en slidas referens via dess index.
1. Lägg till ett diagram med standarddata och någon av de önskade typerna (detta exempel använder **ChartType.ClusteredColumn**).
1. Ställ in det fördefinierade nummerformatet från de möjliga fördefinierade värdena.
1. Gå igenom varje diagramserie och ställ in diagramdatas nummerformat för varje cell.
1. Spara presentationen.
1. Ställ in ett eget nummerformat.
1. Gå igenom varje diagramserie och ange ett annat nummerformat för varje cell.
1. Spara presentationen.

```c#
// Instansierar presentation// Instansierar presentation
Presentation pres = new Presentation();

// Åtkomst till den första presentationssliden
ISlide slide = pres.Slides[0];

// Lägger till ett standardklustrat kolumndiagram
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Åtkomst till diagramseriens samling
IChartSeriesCollection series = chart.ChartData.Series;

// Ställer in fördefinierat nummerformat
// Iterera genom varje diagramserie
foreach (ChartSeries ser in series)
{
    // Iterera genom varje datacell i serien
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Ställer in nummerformatet
        cell.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

// Sparar presentationen
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

De möjliga fördefinierade nummerformatvärdena tillsammans med deras index anges nedan:

|**0**|General|
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

## **Ange avrundade kanter för diagramområde**
Aspose.Slides for .NET erbjuder stöd för att ange diagramområde. Egenskaperna **IChart.HasRoundedCorners** och **Chart.HasRoundedCorners** har lagts till i Aspose.Slides.

1. Instansiera objektet `Presentation`.
1. Lägg till ett diagram på sliden.
1. Ange fyllningstyp och fyllningsfärg för diagrammet.
1. Ställ in egenskapen för rundade hörn till **True**.
1. Spara den modifierade presentationen.

Nedan ges ett exempel.

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

## **Vanliga frågor**

**Kan jag ange halvgenomskinliga fyllningar för kolumner/områden samtidigt som kanten förblir opak?**

Ja. Fyllningens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera datapaket när de överlappar?**

Minska teckensnittsstorleken, inaktivera icke‑nödvändiga etikettkomponenter (t.ex. kategorier), justera etikettens förskjutning/position, visa etiketter endast för utvalda punkter om det behövs, eller byt format till ”värde + förklaring”.

**Kan jag tillämpa gradient‑ eller mönsterfyllningar på serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör gradienter användas sparsamt och kombinationer som minskar kontrasten mot rutnätet och text undvikas.