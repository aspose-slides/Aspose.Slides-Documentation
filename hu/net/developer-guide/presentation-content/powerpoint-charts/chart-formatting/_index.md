---
title: Prezentációs diagramok formázása .NET-ben
linktitle: Diagramformázás
type: docs
weight: 60
url: /hu/net/chart-formatting/
keywords:
- diagram formázása
- diagramformázás
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerkedjen meg a diagramok formázásával az Aspose.Slides .NET verzióban, és emelje prezentációját PowerPointban egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram kulcsfontosságú elemei, például a tengelyek, a rácsvonalak, a címek, a jelmagyarázatok, a grafikonterület és a fal kitöltései, a diagramadatok megjelenésének és olvashatóságának javítása érdekében.

A cikk továbbá bemutatja, hogyan állíthatók be a betűtípus tulajdonságai a diagram szövegéhez, hogyan alkalmazhatók előre beállított numerikus formátumok a diagram adataihoz, és hogyan engedélyezhetők a lekerekített sarkok a diagramterületen. Ezek a példák együtt megmutatják, hogyan szabályozható a diagramok vizuális stílusa és adatmegjelenítése egy prezentációban.

## **Diagramelemek formázása**

Használja az [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) elemet a diagramcímek, tengelyek, rácsvonalak, jelmagyarázatok és a grafikonterület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg‑ és vonalstílusokat alkalmaz az érték‑ és a kategóriatengelyeire. A betűméretet és a vonalszélességet pontban határozzák meg; a kategóriacímkék 45 fokban vannak elfordítva.

Az értéktengely a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) elemet használja a forráscelláktól függetlenül. Skálája -2-től 15-ig terjed, főintervallumok 2‑esek, mellékintervallumok 0,5‑esek. A példa az százalékos formázást is kombinálja a [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) ezrekkel beállítva, ezért igazítsa ezeket a beállításokat adatai jelentéséhez és nagyságához. A jelmagyarázat a grafikonterületen kívül marad, mivel a [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) le van tiltva. A háttérfal és a padló kitöltései a [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) és a [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) elemekkel vannak beállítva, de ezek a felületek csak 3D diagramokban láthatók.

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

## **A diagram betűtípus tulajdonságainak beállítása**

Állítsa be a diagram szövegeinek alapértelmezett betűméretét a [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) segítségével. A példa egy klaszterezett oszlopdiagramot hoz létre 20‑pontos betűmérettel, és a [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) használatával engedélyezi az értékcímkéket az első sorozatra. A saját explicit betűtípus-beállításokkal rendelkező szövegelemek felülírhatják a diagram alapértelmezett beállítását.

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

## **Numerikus formátum beállítása**

Használja az [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) elemet, hogy beépített számformátumot alkalmazzon a diagram munkafüzetcelláira. Ez a példa egy alapértelmezett, cella‑alapú adatokkal rendelkező klaszterezett oszlopdiagramot hoz létre, és az 10‑es formátumindexet (`0.00%`) minden sorozat értékcellájára alkalmazza. Ez megváltoztatja a cellák megjelenítését a munkafüzetben anélkül, hogy az alapértékek módosulnának; például a 0,25 25,00%-ként jelenik meg. A tengely- és adatcímkeformátumok külön-külön konfigurálhatók.

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
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Az alábbi táblázat felsorolja a beépített számformátum-indexeket a megfelelő Excel-formátumokkal az angol (Egyesült Államok) nyelvterületen. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és nyelvterületenként eltérhet, különösen a pénznemek és dátumok esetében. Egyes Excel-formátumok eltérnek az OOXML szabvány alapértelmezett beállításaitól is, amint azt a [Microsoft számformátum-implementációs megjegyzéseiben](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírják.

| Index | Formátum |
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

## **Grafikonterület lekerekített szegélyeinek beállítása**

Engedélyezze az [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) elemet a grafikonterület sarkainak lekerekítéséhez. A példa egy klaszterezett oszlopdiagramot hoz létre, és a [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) segítségével szilárd szürke színű és egyvonalas körvonalat ad a diagramnak, mielőtt mentené a prezentációt.

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

## **Meglévő diagram annotációk szerkesztése**

Egy diagram egyedi alakzatokat is tartalmazhat, például egy szöveges annotációt, amely a jelentés állapotát magyarázza. Ezekhez az alakzatokhoz az [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) segítségével férhet hozzá, amely a Chart API Referenciában a [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) alatt is fel van sorolva. Az [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) gyűjteménye tartalmazza a diagramhoz tartozó alakzatokat.

Egy egyszerű szövegdoboz, amely egy diagram felett helyezkedik el, a diára tartozik, még ha a diagram részének tűnik is. A [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) bejárásával megtalálható a diagram és a szokásos diaelemek, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék külön diagramelemek, nem egyéni annotációk ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első diáján egy diagram található egy csoportosítatlan „Preliminary results” (Előzetes eredmények) feliratú annotációval, a diagramhoz tartozó vonallal, valamint egy egyszerű „Slide overlay” (Dia átfedés) feliratú szövegdobozzal. A példa megtalálja az első diagramot a dián, és a jelentés közzétételre kész állapotában az annotációt „Final results” (Végleges eredmények) szövegre módosítja. Ellenőrzi, hogy a gyűjtemény nem üres, és csak egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet szerkeszt, amelynek nem null értékű [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) és a várt szövege van.

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

Az vonal és a dia szövegdoboz változatlan marad. A következő képek mutatják a bemenetet és a mentett, újranyitott eredményt:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagram annotáció: Előzetes eredmények](chart-annotations-before.png) | ![Diagram annotáció: Végleges eredmények](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
A példa csak a felső szintű, diagramhoz tartozó alakzatokat vizsgálja. Ha egy annotáció egy [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) belsejében van, akkor vizsgálja meg ennek a csoportnak a [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) gyűjteményét is. Ezt rekurzívan ismételje a beágyazott csoportoknál, ugyanazokat a szövegellenőrzéseket alkalmazva a gyermekalakzatokra. Egy csoport önmagában egy tároló; ne kezelje szövegdobozként.
{{% /alert %}}

## **GYIK**

**Be tudok-e állítani félig átlátszó kitöltéseket az oszlopoknál/területeknél, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációkban.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeösszetevőket (például a kategóriákat), állítsa be a címke pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy váltson a "value + legend" (érték + jelmagyarázat) formátumra.

**Használhatok-e színátmenet vagy minta kitöltéseket a sorozatokhoz?**

Igen. A sorozatok támogatják a szilárd, színátmenetes és mintás kitöltéseket. Gyakorlatban mértékkel használjon színátmeneteket, és kerülje azokat a kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.