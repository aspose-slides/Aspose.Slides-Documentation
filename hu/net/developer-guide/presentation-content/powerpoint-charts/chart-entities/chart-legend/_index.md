---
title: Diagram jelmagyarázatok testreszabása bemutatókban .NET-ben
linktitle: Diagram jelmagyarázat
type: docs
url: /hu/net/chart-legend/
keywords:
- diagram jelmagyarázat
- jelmagyarázat helye
- betűméret
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Testreszabja a diagram jelmagyarázatokat az Aspose.Slides for .NET segítségével, hogy optimalizálja a PowerPoint bemutatókat egyedi jelmagyarázati formázással."
---
## **Áttekintés**

Aspose.Slides for .NET lehetőségeket biztosít a diagram jelmagyarázatainak testreszabásához PowerPoint bemutatókban. Ez a cikk bemutatja, hogyan helyezze el és méretezze a jelmagyarázatot, hogyan állítsa be a teljes jelmagyarázat betűméretét, hogyan formázzon egyedi jelmagyarázati bejegyzést, valamint hogyan rejtsen el vagy állítson vissza kiválasztott bejegyzéseket.

A GYIK kapcsolódó viselkedéseket tárgyal, többek között a jelmagyarázat számára fenntartott helyet, a több soros címkék megjelenítését és a formázás öröklését a bemutató témájából.

## **Jelmagyarázat elhelyezése**

Használja a jelmagyarázat [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), és [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) tulajdonságait a pozíció és méret megadásához a diagram méretének tört részeként.

Ez a példa egy bemutatót hoz létre, és az első diára egy csoportosított oszlopdiagramot ad hozzá alapértelmezett adatokkal. A kívánt jelmagyarázati eltolásokat és méreteket a diagram szélességével és magasságával való osztással relatív értékekké konvertálja: a jelmagyarázat 50 ponttal van eltolva a diagram bal‑felső sarkától, és 100 × 100 pont méretű.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Ábrázolja a jelmagyarázat pozícióját és méretét a diagramhoz viszonyítva.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **A jelmagyarázat betűméretének beállítása**

Használja a jelmagyarázat [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) tulajdonságát a szöveg formázásához, és állítsa be a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) pontban.

Ez a példa egy diagramot hoz létre alapértelmezett adatokkal, és a jelmagyarázat szövegét 20 pontra állítja. Emellett letiltja a függőleges tengely automatikus határait, és a tartományt -5‑től 10‑ig állítja be.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Egyedi jelmagyarázati bejegyzés betűméretének beállítása**

Használja a jelmagyarázat [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) gyűjteményét egy konkrét bejegyzés formázásához. A bejegyzés indexek nullától indulnak, így a `1` index a második bejegyzést jelöli.

Ez a példa egy csoportosított oszlopdiagramot hoz létre, amelynek alapértelmezett adatai legalább két sorozatot tartalmaznak. A második jelmagyarázati bejegyzést félkövér, dőlt és 20 pontos kék szöveggel formázza.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Egyedi jelmagyarázati bejegyzések elrejtése**

Egy segédsorosozat kizárásához a jelmagyarázatból, miközben a adatai láthatóak maradnak, állítsa be a [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) értékét `true`-ra a [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) segítségével. Ez csak a kiválasztott jelmagyarázati bejegyzést rejti el; nem távolítja el a sorozatot vagy adatpontjait. Ezzel szemben a [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) `false` értékre állítása az egész jelmagyarázatot rejti el.

Az alábbi példa egy több sorozatos csoportosított oszlopdiagramot hoz létre alapértelmezett adatokkal. Elrejti a második sorozat jelmagyarázati bejegyzését (index `1`), és elmenti a bemutatót. Ezután a `Hide` értékét `false`-ra állítva visszaállítja a bejegyzést, és elment egy második példányt. Az oszlopok mindkét fájlban láthatóak maradnak.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Állítsa vissza ugyanazt a bejegyzést a diagram adatainak módosítása nélkül.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Az alábbi összehasonlítás ugyanazt a diagramot mutatja, ahol minden bejegyzés látható, illetve ahol a második bejegyzés rejtve van. A második sorozat oszlopai változatlanok maradnak.

![A diagram összehasonlítása, ahol minden jelmagyarázati bejegyzés látható, és ahol a 2. sorozat rejtve van a jelmagyarázatból; minden oszlop látható.](hide-legend-entry.png)

Az oszlop-, sáv- és vonaldiagramokban a jelmagyarázati bejegyzések a sorozatokat azonosítják. Pie-diagramok esetén egyedi adatpontokat (szeleteket) azonosítanak, ezért használja a [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) hivatkozást a kiválasztott szeletnél. Az API ezt a adatpont‑tulajdonságot dokumentálja a `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` és `BarOfPie` diagramtípusokhoz. Ne feltételezze, hogy ez a tulajdonság a pogácsa diagramokra is érvényes, mivel azok nincsenek a listán.

## **GYIK**

**Készíthetek úgy, hogy a diagram helyet foglaljon a jelmagyarázatnak ahelyett, hogy átfedné?**

Igen. Állítsa a [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) értékét `false`‑ra, hogy a jelmagyarázat számára helyet tartson fenn, ahelyett, hogy átfedné a rajzterületet.

**Készíthetek több soros jelmagyarázati címkéket?**

Igen. A hosszú címkék megtörhetnek, ha a rendelkezésre álló szélesség nem elegendő. Sorozatneveknél is használhat új sor karaktereket a sortörések kéréséhez.

**Hogyan tudom, hogy a jelmagyarázat a bemutató téma színsémáját kövesse?**

Hagyja a jelmagyarázat színeit, kitöltéseit és betűtípusait beállítatlanul, hogy örökölje a téma formázását. Az explicit formázás felülírja a megfelelő téma beállításokat.