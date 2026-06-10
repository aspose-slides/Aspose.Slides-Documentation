---
title: "Hibasávok testreszabása a prezentációs diagramokban JavaScript használatával"
linktitle: "Hibasáv"
type: docs
url: /hu/nodejs-java/error-bar/
keywords:
- hibasáv
- egyéni érték
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibasávokat a diagramokban JavaScript és az Aspose.Slides for Node.js via Java segítségével—optimalizálja az adatvizualizációt PowerPoint-prezentációkban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk hibasávokkal a prezentációs diagramokban az Aspose.Slides segítségével. Bemutatja, hogyan adhatunk hibasávokat egy diagram sorozathoz, hogyan konfigurálhatjuk az X és Y hibasáv beállításait, és hogyan alkalmazhatunk különböző értéktípusokat, például rögzített, százalékos és egyéni értékeket. A cikk azt is bemutatja, hogyan rendelhetünk egyéni hibasávértékeket a sorozat egyedi adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Emellett a cikk rövid megjegyzéseket tartalmaz arról, hogyan viselkednek a hibasávok exportálás során, kompatibilitásukról a jelölőkkel és adatcímkékkel, valamint ahol megtalálhatók a kapcsolódó API referencia osztályok és felsorolások.

## **Hibasáv hozzáadása**

Az Aspose.Slides for Node.js via Java egyszerű API-t biztosít a hibasáv értékek kezelésére. A példakód akkor alkalmazható, amikor egyéni értéktípust használunk. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot egy adott adatpontnál a sorozat [**DataPoints**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeriesCollection) gyűjteményében:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Hozzáfér az első diagram sorozathoz, és beállítja a hibasáv X formátumát.
1. Hozzáfér az első diagram sorozathoz, és beállítja a hibasáv Y formátumát.
1. A sávok értékeinek és formátumának beállítása.
1. Írja a módosított prezentációt egy PPTX fájlba.

```javascript
// Hozzon létre egy Presentation osztály példányt
var pres = new aspose.slides.Presentation();
try {
    // Buborék diagram létrehozása
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Hibasávok hozzáadása és formátumának beállítása
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Prezentáció mentése
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Egyéni hibasáv érték hozzáadása**

Az Aspose.Slides for Node.js via Java egyszerű API-t biztosít az egyéni hibasáv értékek kezelésére. A példakód akkor alkalmazható, amikor a [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) tulajdonság **Custom** értékre van állítva. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot egy adott adatpontnál a sorozat [**DataPoints**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartSeriesCollection) gyűjteményében:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Hozzáfér az első diagram sorozathoz, és beállítja a hibasáv X formátumát.
1. Hozzáfér az első diagram sorozathoz, és beállítja a hibasáv Y formátumát.
1. Hozzáfér a diagram sorozat egyedi adatpontjaihoz, és beállítja a hibasáv értékeket az egyes sorozat adatpontokhoz.
1. A sávok értékeinek és formátumának beállítása.
1. Írja a módosított prezentációt egy PPTX fájlba.

```javascript
// Hozzon létre egy Presentation osztály példányt
var pres = new aspose.slides.Presentation();
try {
    // Buborék diagram létrehozása
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Egyéni hibasávok hozzáadása és formátumának beállítása
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Diagram sorozat adatpontjának elérése és hibasáv értékek beállítása
    // egyedi ponthoz
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Hibasávok beállítása a diagram sorozat pontjaihoz
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Prezentáció mentése
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Mi történik a hibasávokkal, amikor a prezentációt PDF-re vagy képekre exportálják?**

A hibasávok a diagram részeként kerülnek renderelésre, és a konverzió során a diagram többi formázásával együtt megmaradnak, feltéve, hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**Kombinálhatóak a hibasávok jelölőkkel és adatcímkékkel?**

Igen. A hibasávok különálló elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfedik egymást, előfordulhat, hogy a formázást módosítani kell.

**Hol található a hibasávokkal való munkához szükséges tulajdonságok és felsorolások listája az API-ban?**

Az API referenciában: az [ErrorBarsFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/errorbarsformat/) osztály és a kapcsolódó felsorolások [ErrorBarType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/errorbartype/) valamint [ErrorBarValueType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/errorbarvaluetype/).