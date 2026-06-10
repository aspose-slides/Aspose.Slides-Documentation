---
title: A .NET Treemap és Sunburst diagramok adatpontjainak testreszabása
linktitle: Adatpontok a Treemap és Sunburst diagramokban
type: docs
url: /hu/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap diagram
- sunburst diagram
- adatpont
- címke szín
- ág szín
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a treemap és sunburst diagramok adatpontjait az Aspose.Slides for .NET segítségével, amely kompatibilis a PowerPoint formátumokkal."
---
## **Bevezetés**

A PowerPoint diagramok más típusai mellett két „hierarchikus” típus létezik – **Treemap** és **Sunburst** diagram (más néven Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph vagy Multi Level Pie Chart). Ezek a diagramok hierarchikus adatokat jelenítenek meg, amelyeket fa struktúraként szerveznek – a levelektől a ágak tetejéig. A leveleket a sorozat adatpontjai határozzák meg, és minden további beágyazott csoportosítási szint a megfelelő kategória által definiált. Az Aspose.Slides for .NET lehetővé teszi a Sunburst és Treemap diagram adatpontjainak formázását C#‑ban.

Itt egy Sunburst diagram, ahol a Series1 oszlop adatai határozzák meg a levélcsomópontokat, míg a többi oszlop a hierarchikus adatpontokat definiálja:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Kezdjük el egy új Sunburst diagram hozzáadásával a bemutatóhoz:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Lásd még" %}} 
- [**Sunburst diagram létrehozása**](/slides/hu/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Ha szükség van a diagram adatpontjainak formázására, a következőket kell használni:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointlevel) osztályok 
és [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) tulajdonság 
hozzáférést biztosít a Treemap és a Sunburst diagramok adatpontjainak formázásához. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/IChartDataPointLevelsManager) 
a több szintű kategóriák elérésére szolgál – a 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/IChartDataPointLevel) objektumok tárolóját képviseli. 
Alapvetően egy 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/IChartCategoryLevelsManager) 
csomagolója, a adatpontokra vonatkozó specifikus tulajdonságokkal bővítve. 
A [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/IChartDataPointLevel) osztálynak két tulajdonsága van: [**Format**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointlevel/properties/format) és [**DataLabel**](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointlevel/properties/label), amelyek hozzáférést biztosítanak a megfelelő beállításokhoz.

## **Adatapont értékének megjelenítése**
"Leaf 4" adatpont értékének megjelenítése:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Adatapont címke és szín beállítása**
"Branch 1" adatcímke beállítása, hogy a sorozat nevét ("Series1") jelenítse meg a kategória neve helyett. Ezután a szöveg színét sárgára állítsa:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Adatapont ág színének beállítása**
"Stem 4" ág színének módosítása:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **GYIK**

**Megváltoztathatom a Sunburst/Treemap szegmensek sorrendjét (rendezését)?**

Nem. A PowerPoint automatikusan rendezi a szegmenseket (általában csökkenő értékek szerint, óramutató járásával megegyező irányban). Az Aspose.Slides ezt a viselkedést tükrözi: a sorrendet közvetlenül nem lehet módosítani; a megfelelő adat‑előfeldolgozással érhető el.

**Hogyan befolyásolja a bemutató téma a szegmensek és címkék színeit?**

A diagram színei a bemutató [téma/paletta](/slides/hu/net/presentation-theme/) beállításaiból öröklődnek, hacsak nem állítunk be explicit módon kitöltéseket vagy betűtípusokat. Az egységes eredmény érdekében a szükséges szinteken rögzítsük a szilárd kitöltéseket és a szövegformázást.

**Megőrzi-e a PDF/PNG export a saját ág színeket és címke beállításokat?**

Igen. A bemutató exportálásakor a diagram beállításai (kitöltések, címkék) megmaradnak a kimeneti formátumokban, mivel az Aspose.Slides a diagram formázásával renderel.

**Kiszámíthatom-e egy címke/elem tényleges koordinátáit egy egyéni átfedés elhelyezéséhez a diagram felett?**

Igen. A diagram elrendezésének ellenőrzése után az elemek (például egy [DataLabel](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/datalabel/)) `ActualX`/`ActualY` értékei rendelkezésre állnak, ami segít a pontos átfedéselhelyezésben.