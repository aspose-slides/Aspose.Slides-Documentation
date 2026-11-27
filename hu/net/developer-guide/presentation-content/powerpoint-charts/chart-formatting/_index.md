---
title: Diagramok formázása PowerPoint prezentációkban .NET-ben
linktitle: Diagram formázása
type: docs
weight: 60
url: /hu/net/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram entitás
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
description: "Ismerje meg a diagramok formázását az Aspose.Slides .NET verziójában, és emelje a PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni diagramokat PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan lehet testre szabni a diagram kulcsfontosságú elemeit, például a tengelyeket, a rácsvonalakat, a címeket, a legendákat, a rajzterületet és a falak kitöltéseit, hogy javítsuk a diagram adatok megjelenését és olvashatóságát.

Emellett bemutatja, hogyan lehet beállítani a betűtípus‑tulajdonságokat a diagram szövegéhez, előre definiált számalakzatokat alkalmazni a diagram adatokra, valamint lekerekített sarkokat engedélyezni a diagram területén. Ezek a példák együtt mutatják, hogyan irányítható a diagram vizuális stílusa és az adatmegjelenítés egyaránt egy prezentációban.

Külön kitöltések és körvonalak a növekvő és csökkenő intervallumokra a [részvénydiagram példa](/slides/hu/net/create-chart/#create-stock-charts) alatt tekinthetők meg.

## **Diagrammelemek formázása**

Használja az [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) interfészt a diagram címek, tengelyek, rácsvonalak, legendák és a rajzterület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg‑ és vonalstílusokat alkalmaz az érték‑ és kategóriatengelyeken. A betűméreteket és a vonalszélességeket pontban adjuk meg; a kategória‑címkék 45 fokban vannak elforgatva.

Az értéktengely a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) beállítást használja a forráscelláktól függetlenül. Skálája -2‑től 15‑ig terjed, fő intervallumok 2‑esek, mellék‑intervallumok 0,5‑esek. A példa a százalékos formázást kombinálja a [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) ezerre állított beállításával, így ezeket a beállításokat az adatok jelentéséhez és nagyságához igazítsa. A legenda a rajzterület kívül marad, mert a [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) le van tiltva. A hátfal és a padló kitöltései a [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) és a [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) segítségével állíthatók be, de ezek a felületek csak 3D diagramokban láthatók.

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

## **Diagram betűtípus tulajdonságainak beállítása**

Állítsa be a diagram szövegének alapértelmezett betűméretét a [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) segítségével. A példa egy csoportosított oszlopdiagramot hoz létre 20 pontos betűvel, és a [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) használatával engedélyezi az értékcímkéket az első sorozathoz. A saját explicit betűtípus‑beállításokkal rendelkező szövegelemek felülbírálhatják a diagram alapértelmezett beállításait.

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

## **Szövegkeret formázásának újrahasználata diagram legendához**

A legenda a diárcímhez való igazításához állítsa be a betűtípust az első bekezdés [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)‑ben. Hívja meg a [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) metódust a legenda [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) objektumán. Ez beolvassa a szövegkeret beállításait, az első bekezdés formázását, valamint a bekezdés alapértelmezett betűtulajdonságait. Az egyes részekre vagy későbbi bekezdésekre közvetlenül alkalmazott formázás csak a forrásra vonatkozik.

A példa egy félkövér, 26 pontos Calibri címkét használ tengerkék színnel sablonként. A legenda formázása után a [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) segítségével alkalmazza ugyanazt a formázást egy külön feliraton.

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

A mentett prezentációban a legenda és a felirat méret, vastagság és szín tekintetében megegyezik a címmel. A legenda továbbra is a sorozatneveket jeleníti meg, a felirat pedig saját szövegét tartja meg. Ha a felirat egy részében már explicit betűméret van megadva, ez a méret előnyt élvez a másolt bekezdés alapértelmezéséhez képest.

| Másolás előtt | Másolás után |
| --- | --- |
| ![Negyedéves eladási diagram szabályos fekete legendacímkékkel és fekete felirattal](legend-formatting-before.png) | ![Ugyanaz a diagram nagyobb, félkövér tengerkék legendacímkékkel és egyező felirattal](legend-formatting.png) |

## **Számformátum beállítása**

Használja az [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) metódust beépített számformátum alkalmazásához a diagram munkafüzetcelláira. Ez a példa egy csoportosított oszlopdiagramot hoz létre alapértelmezett, cella‑alapú adatokkal, és a 10. formátumindexet (`0.00%`) alkalmazza minden sorozat értékcellájára. Ez megváltoztatja a cellák megjelenített értékét a munkafüzetben anélkül, hogy a tényleges számok módosulnának; például a 0,25 25,00%-ként jelenik meg. A tengely‑ és adatcímke‑formátumok külön konfigurálhatók.

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

Az alábbi táblázat felsorolja a beépített számformátum‑indexeket jellemző Excel‑formátumokkal az angol (Egyesült Államok) helyi beállításokhoz. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és helyi beállításonként eltérhet, különösen a pénznemek és dátumok esetében. Néhány Excel‑formátum eltér az OOXML szabvány alapértelmezéseitől, ahogy azt a [Microsoft számformátum‑implementációs megjegyzéseiben](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírják.

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

## **Diagramtér lekerekített szegélyek beállítása**

Engedélyezze az [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) beállítást a diagram területének sarkainak lekerekítéséhez. A példa egy csoportosított oszlopdiagramot hoz létre, majd a [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) használatával szilárd szürke színt és egyszeres vonalstílust ad a körvonalnak, mielőtt elmentené a prezentációt.

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

## **Létező diagram‑annotációk szerkesztése**

Egy diagram tartalmazhat egyedi alakzatokat, például egy szöveges annotációt, amely a jelentés állapotát magyarázza. Ezeket az alakzatokat az [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) segítségével érheti el, amely a [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) alatti API‑referenciában is szerepel. Az [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) gyűjtemény a diagramhoz tartozó alakzatokat tartalmazza.

Az egy egyszerű szövegdoboz, amely a diagram fölött helyezkedik el, a diára tartozik, még ha úgy is néz ki, mintha a diagram része lenne. A [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) átvizsgálása megtalálja a diagramot és a szokásos diakelem‑alakzatokat, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék külön diagramelemek, nem egyedi annotációk ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első dián egy diagram található egy szétcsoportosított annotációval, amely „Preliminary results” feliratot tartalmaz, egy diagram‑tulajdonú vonallal és egy egyszerű diára helyezett szövegdobozzal, amely „Slide overlay” feliratot mutat. A példa megtalálja az első diagramot ezen a dián, és a jelentés közzététele előtt a annotációt „Final results” szövegre módosítja. Ellenőrzi, hogy a gyűjtemény ne legyen üres, és csak olyan [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet szerkeszt, amelynek nem‑null a [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) és a várt szöveg szerepel benne.

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

A vonal és a diára helyezett szövegdoboz változatlan marad. Az alábbi képek a bemeneti és a mentett, újra megnyitott eredményt mutatják:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagram‑annotáció, amely a „Preliminary results” feliratot jeleníti meg](chart-annotations-before.png) | ![Diagram‑annotáció, amely a „Final results” feliratot jeleníti meg](chart-annotations-after.png) |

{{% alert color="info" title="Megjegyzés" %}}
A példa csak a legfelső szintű, diagram‑tulajdonú alakzatokat vizsgálja. Ha egy annotáció egy [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) belsejében van, akkor vizsgálja meg az adott csoport [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) gyűjteményét is. Ezt rekurzívan ismételje a beágyazott csoportoknál, a szövegellenőrzést ugyanúgy alkalmazva a gyermekalakzatokra. Egy csoport önmagában egy tároló; ne kezelje szövegdobozként.
{{% /alert %}}

## **GYIK**

**Beállíthatok-e félig átlátszó kitöltéseket az oszlopok/területek számára, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és a sűrű adatok olvashatóságának javításához.

**Hogyan kezeljem a feliratokat, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges feliratkomponenseket (például a kategóriákat), állítsa be a felirat helyzetét, szükség esetén csak a kiválasztott pontok feliratait jelenítse meg, vagy válassza a „érték + legenda” formátumot.

**Alkalmazhatok‑e színátmenetes vagy mintás kitöltéseket sorozatokra?**

Igen. A sorozatok támogatják a szilárd, színátmenetes és mintás kitöltéseket. A gyakorlatban használjon színátmeneteket visszafogottan, és kerülje a kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.