---
title: Diagram adat táblák testreszabása prezentációkban .NET-ben
linktitle: Adat tábla
type: docs
url: /hu/net/chart-data-table/
keywords:
- diagram adat
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Diagram adat tábla betűtípusainak, szegélyeinek és jelmagyarázat kulcsainak testreszabása PowerPoint prezentációkban az Aspose.Slides for .NET és C# használatával."
---
## **Áttekintés**

Az Aspose.Slides for .NET lehetővé teszi, hogy megjelenítse egy diagram adat tábláját, és testreszabja a szövegformázását, a szegélyeket és a jelmagyarázat kulcsait. Ez a cikk elmagyarázza, hogyan engedélyezze a táblát, formázza a szöveget, kezelje az egyes szegélytípusokat, és hogyan jelenítse meg vagy rejtse el a jelmagyarázat kulcsait. A példák a konfigurált diagramokat PPTX fájlokba mentik.

## **Betűtípus tulajdonságok beállítása**

A diagram adat táblájának megjelenítéséhez állítsa a [HasDataTable](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/hasdatatable/) értékét `true`-ra. Használja a [ChartDataTable](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/chartdatatable/) osztályt a tábla eléréséhez és a szövegformázás konfigurálásához.

1. Töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály segítségével.  
1. Adjon hozzá egy csoportosított oszlopdiagramot az első diára.  
1. Engedélyezze a diagram adat tábláját.  
1. Engedélyezze a félkövér szöveget a [FontBold](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontbold/) segítségével, és állítsa a [FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontheight/) értékét `20`-ra a 20 pontos szöveghez.  
1. Mentse el a módosított bemutatót.

A következő példa a munkakönyvtárban `test.pptx` fájlt igényel, amely legalább egy diát tartalmaz. Egy alapértelmezett adatokkal rendelkező diagramot ad a (50, 50) pozícióba, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` a diagramot, valamint a bekapcsolt adat táblát és a megadott betűtípus beállításokat tartalmazza.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Adattábla szegélyek testreszabása**

A táblát a [IChart.HasDataTable](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/hasdatatable/) használatával engedélyezheti, és a [IChart.ChartDataTable](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/chartdatatable/) segítségével érheti el. Három típusú szegélyt vezérelhet önállóan:

- [HasBorderHorizontal](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatatable/hasborderhorizontal/) a vízszintes cellaszegélyeket vezérli.  
- [HasBorderVertical](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatatable/hasbordervertical/) a függőleges cellaszegélyeket vezérli.  
- [HasBorderOutline](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatatable/hasborderoutline/) a tábla külső szegélyét vezérli.

Állítsa az egyes tulajdonságokat `true`-ra a szegélyek megjelenítéséhez, vagy `false`-ra azok elrejtéséhez. A következő példa egy alapértelmezett adatokkal rendelkező csoportosított oszlopdiagramot hoz létre, megjeleníti a vízszintes szegélyeket és a külső szegélyt, és elrejti a függőleges szegélyeket. Nem igényel bemeneti fájlt. A diagram pozíciója és mérete pontban van megadva.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Az alábbi összehasonlítás minden négy esetben ugyanazt a diagram adatot és a jelmagyarázat kulcs beállítást használja. Kiindulva az összes szegély engedélyezett állapotból, minden további változat egyetlen szegélytulajdonságot kapcsol ki. A bal alsó változat egyezik a példában lévő szegélybeállításokkal.

![Diagram adat táblák minden szegéllyel engedélyezve, vízszintes szegélyek nélkül, függőleges szegélyek nélkül, és külső szegély nélkül](data-table-borders.png)

## **Jelmagyarázat kulcsok megjelenítése vagy elrejtése**

A jelmagyarázat kulcsok kis színes jelölők a sornevek mellett az adat táblában. Segítik az olvasókat, hogy összepárosítsák a táblasorokat a diagram sorozataival. Állítsa a [ShowLegendKey](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatatable/showlegendkey/) értékét `true`-ra a jelölők megjelenítéséhez vagy `false`-ra az elrejtésükhöz.

A diagram különálló jelmagyarázata a [IChart.HasLegend](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/haslegend/) segítségével szabályozható. Ezek a beállítások függetlenek: a különálló jelmagyarázat elrejtése nem rejti el a táblán belüli kulcsokat, és a tábla kulcsainak elrejtése nem rejti el a különálló jelmagyarázatot.

A következő példa egy alapértelmezett adatokkal rendelkező diagramot hoz létre, engedélyezi az adat táblát, és megjeleníti a jelmagyarázat kulcsokat benne, miközben elrejti a különálló jelmagyarázatot. Minden tábla szegély kifejezetten engedélyezett. Nem szükséges bemeneti bemutató. Ahhoz, hogy csak a tábla kulcsait rejtse el, változtassa meg a `dataTable.ShowLegendKey` értékét `false`-ra.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Az alábbi összehasonlítás ugyanazt a táblát mutatja a jelmagyarázat kulcsokkal engedélyezve és letiltva. Minden szegély engedélyezve marad, és a különálló diagram jelmagyarázata mindkét esetben el van rejtve.

![Diagram adat táblák bal oldalon megjelenített jelmagyarázat kulcsokkal és jobb oldalon elrejtve](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetek jelmagyarázat kulcsokat egy diagram adat táblájában?**

Igen. Állítsa a [ShowLegendKey](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/datatable/showlegendkey/) értékét `true`-ra a jelmagyarázat kulcsok megjelenítéséhez vagy `false`-ra a rejtésükhöz.

**Megmarad az adat tábla a bemutató PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat táblát a dia részének rendereli, amikor [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), [HTML](/slides/hu/net/convert-powerpoint-to-html/) vagy [képek](/slides/hu/net/convert-powerpoint-to-png/) formátumba exportál.

**Dolgozhatok adat táblákkal olyan diagramokban, amelyeket sablonból töltöttek be?**

Igen. Egy meglévő bemutatóból vagy sablonból betöltött diagram esetén használja a [HasDataTable](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/hasdatatable/) metódust annak ellenőrzésére vagy módosítására, hogy megjelenik-e az adat tábla.

**Hogyan találhatók azok a diagramok, amelyeknek az adat tábla engedélyezve van?**

Iteráljon végig a diák alakzatain, azonosítsa a diagramokat, és ellenőrizze azok [HasDataTable](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/hasdatatable/) tulajdonságát. A `true` érték azt jelzi, hogy az adat tábla engedélyezve van.