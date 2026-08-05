---
title: Treemap és Sunburst diagramok adatpontjainak testreszabása C++ segítségével
linktitle: Adatpontok a Treemap és Sunburst diagramokban
type: docs
url: /hu/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap diagram
- sunburst diagram
- adatpont
- címke színe
- ág színe
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a treemap és sunburst diagramok adatpontjait az Aspose.Slides for C++ segítségével, amely kompatibilis a PowerPoint formátumokkal."
---
## **Bevezetés**

A PowerPoint diagramok egyéb típusaival együtt két „hierarchikus” típus létezik – **Treemap** és **Sunburst** diagram (más néven Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph vagy Multi Level Pie Chart). Ezek a diagramok hierarchikus adatot jelenítenek meg, amely egy fává rendezett – a levelektől az ág tetejéig. A leveleket a sorozat adatpontjai határozzák meg, és minden további beágyazott csoportosítási szint a megfelelő kategória által definiált. Az Aspose.Slides for C++ lehetővé teszi a Sunburst diagram és a Treemap adatpontjainak formázását C++‑ban.

Itt egy Sunburst diagram, ahol a Series1 oszlop adatai határozzák meg a levélcsúcsokat, míg a többi oszlop a hierarchikus adatpontokat definiálja:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Kezdjük egy új Sunburst diagram hozzáadásával a prezentációhoz:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Lásd még" %}} 
- [**Sunburst diagram létrehozása**](/slides/hu/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Ha szükség van a diagram adatpontjainak formázására, a következőket kell használni:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/) osztályok és [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) metódus hozzáférést biztosít a Treemap és Sunburst diagramok adatpontjainak formázásához.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) a több szintű kategóriák elérésére szolgál – ez a [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/) objektumok tárolóját képviseli. Alapvetően egy wrapper a [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) számára, amely a adatpontokra specifikus tulajdonságokat adja hozzá. [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/) osztálynak két metódusa van: [**get_Format()**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) és [**get_Label()**](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/), amelyek hozzáférést biztosítanak a megfelelő beállításokhoz.

## **Adatpont értékének megjelenítése**
"Leaf 4" adatpont értékének megjelenítése:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Adatpont címkének és színnek beállítása**
"Branch 1" adatcímkét úgy állítsuk be, hogy a sorozat nevét ("Series1") jelenítse meg a kategória neve helyett. Ezután állítsuk a szövegszínt sárgára:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Adatpont ág színének beállítása**
"Stem 4" ág színének módosítása:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **GYIK**

**Módosíthatom a szegmensek sorrendjét (rendezését) a Sunburst/Treemap diagramokban?**

Nem. A PowerPoint automatikusan rendezi a szegmenseket (általában csökkenő értékek szerint, az óramutató járásával megegyező irányban). Az Aspose.Slides ezt a viselkedést tükrözi: a sorrendet nem lehet közvetlenül módosítani; a adat előfeldolgozásával érhető el a kívánt elrendezés.

**Hogyan befolyásolja a prezentáció témája a szegmensek és címkék színeit?**

A diagram színei öröklik a prezentáció [témáját/palettáját](/slides/hu/cpp/presentation-theme/), hacsak nem állítjuk be kifeexplicit módon a kitöltéseket vagy betűtípusokat. Az egységes eredmény érdekében rögzítsünk szilárd kitöltéseket és szövegformázásokat a megfelelő szinteken.

**Megőrzi a PDF/PNG export a saját ágszíneket és címke beállításokat?**

Igen. A prezentáció exportálásakor a diagram beállításai (kitöltések, címkék) megmaradnak a kimeneti formátumokban, mivel az Aspose.Slides a diagram formázásával renderel.

**Kiszámolhatom a címke/elem valódi koordinátáit egy egyéni átfedés elhelyezéséhez a diagram felett?**

Igen. A diagram elrendezésének validálása után a tényleges X és Y koordináták elérhetők az elemekhez (például egy [DataLabel](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/datalabel/)), ami segít a pontos átfedés-pozícionálásban.