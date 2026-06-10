---
title: Adatpontok testreszabása Treemap és Sunburst diagramokban JavaScript használatával
linktitle: Adatpontok Treemap és Sunburst diagramokban
type: docs
url: /hu/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- adatpont
- címke színe
- ág színe
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhetők az adatpontok treemap és sunburst diagramokban JavaScript és Aspose.Slides for Node.js via Java segítségével, kompatibilis a PowerPoint formátumokkal."
---
## **Bevezetés**

A PowerPoint diagramok közül két „hierarchikus” típus létezik – a **Treemap** és a **Sunburst** diagram (más néven Sunburst grafikon, Sunburst diagram, Radiális diagram, Radiális grafikon vagy Többszintű kördiagram). Ezek a diagramok hierarchikus adatokat jelenítenek meg fa struktúrában – a levelektől az ág tetejéig. A leveleket a sorozat adatpontjai definiálják, és minden további egymásba ágyazott csoportosítási szint a megfelelő kategóriával határozható meg. Az Aspose.Slides for Node.js via Java lehetővé teszi a Sunburst és Treemap diagram adatpontjainak formázását JavaScriptben.

Itt egy Sunburst diagram, ahol a Series1 oszlop adatai határozzák meg a levélcsomópontokat, míg a többi oszlop a hierarchikus adatpontokat definiálja:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Kezdjük egy új Sunburst diagram hozzáadásával a prezentációhoz:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="See also" %}} 
- [**PowerPoint prezentáció diagramok létrehozása vagy frissítése JavaScriptben**](/slides/hu/nodejs-java/create-chart/)
{{% /alert %}}

Ha szükség van a diagram adatpontjainak formázására, a következőket kell használni:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPointLevel) osztályok 
és [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) metódus biztosítja a Treemap és Sunburst diagramok adatpontjainak formázásához való hozzáférést. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPointLevelsManager) a több szintű kategóriák elérésére szolgál – ez a 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPointLevel) objektumok tárolója. 
Lényegében egy [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartCategoryLevelsManager) csomagoló, amely az adatpontokra specifikus tulajdonságokat ad hozzá. 
A [**ChartDataPointLevel**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPointLevel) osztálynak két metódusa van: [**getFormat**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) és [**getDataLabel**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) , amelyek hozzáférést biztosítanak a megfelelő beállításokhoz.

## **Adatpont értékének megjelenítése**
„Leaf 4” adatpont értékének megjelenítése:

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Adatpont címke és szín beállítása**
Állítsa be a „Branch 1” adatcímkét úgy, hogy a sorozat neve („Series1”) jelenjen meg a kategória neve helyett. Ezután állítsa a szövegszínt sárgára:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Adatpont ág színének beállítása**
„Steam 4” ág színének módosítása:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **GYIK**

**Módosíthatom a szegmensek sorrendjét (rendezését) a Sunburst/Treemap diagramokban?**

Nincs. A PowerPoint automatikusan rendezi a szegmenseket (általában csökkenő értékek szerint, az óramutató járásával megegyező irányban). Az Aspose.Slides ezt a viselkedést tükrözi: a sorrendet közvetlenül nem lehet módosítani; ezt az adatok előfeldolgozásával érheti el.

**Hogyan befolyásolja a prezentáció témája a szegmensek és címkék színeit?**

A diagram színei öröklik a prezentáció [téma/paletta](/slides/hu/nodejs-java/presentation-theme/) beállításait, hacsak nem állítja be kifeexplicit módon a kitöltéseket/fontokat. A konzisztens eredmények eléréséhez rögzítse a szilárd kitöltéseket és a szövegformázást a szükséges szinteken.

**A PDF/PNG exportálás megőrzi az egyedi ág színeket és címke beállításokat?**

Igen. A prezentáció exportálásakor a diagram beállításai (kitöltések, címkék) megmaradnak a kimeneti formátumokban, mivel az Aspose.Slides a diagram formázását alkalmazva renderel.

**Kiszámíthatom a címke/elem tényleges koordinátáit az egyéni átfedés elhelyezéséhez a diagram felett?**

Igen. A diagram elrendezésének ellenőrzése után az elemek (például egy [DataLabel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabel/)) tényleges X és tényleges Y koordinátái elérhetők, ami segíti a pontos átfedések elhelyezését.