---
title: Androidon a bemutatódiagramok hibasávjainak testreszabása
linktitle: Hibasáv
type: docs
url: /hu/androidjava/error-bar/
keywords:
- hibasáv
- egyéni érték
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és testreszabhat hibasávokat diagramokhoz az Aspose.Slides for Android via Java segítségével—optimalizálja az adatvizualizációt PowerPoint bemutatókban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell hibasávokat kezelni az előadásdiagramokban az Aspose.Slides használatával. Megmutatja, hogyan adhat hibasávokat egy diagram sorozathoz, hogyan konfigurálhatja az X és Y hibasáv beállításait, valamint hogyan alkalmazhat különböző értéktípusokat, például rögzített, százalékos és egyéni értékeket.

Emellett bemutatja, hogyan lehet egyes adatpontokhoz egyéni hibasáv értékeket rendelni a sorozat megfelelő adatpontgyűjteményének használatával. Továbbá a cikk rövid megjegyzéseket tartalmaz arról, hogy a hibasávok hogyan viselkednek exportálás során, kompatibilitásuk a jelzőkkel és adatcímkékkel, valamint hogy hol találhatók a kapcsolódó API referenciaosztályok és felsorolások.

## **Hibasávok hozzáadása**
Az Aspose.Slides for Android via Java egyszerű API‑t kínál a hibasáv értékek kezelésére. A minta kód akkor alkalmazandó, amikor egy egyéni értéktípust használunk. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat [**DataPoints**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeriesCollection) gyűjteményének egy adott adatpontján:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Érjen el az első diagram sorozatát, és állítsa be az X hibasáv formátumát.
1. Érjen el az első diagram sorozatát, és állítsa be az Y hibasáv formátumát.
1. Állítsa be a sávok értékeit és formátumát.
1. Írja a módosított bemutatót egy PPTX fájlba.

```java
// Hozzon létre egy Presentation osztály példányt
Presentation pres = new Presentation();
try {
    // Buborékdiagram létrehozása
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hibasávok hozzáadása és formátumuk beállítása
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Bemutató mentése
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyéni hibasáv értékek hozzáadása**
Az Aspose.Slides for Android via Java egyszerű API‑t kínál az egyéni hibasáv értékek kezelésére. A minta kód akkor alkalmazandó, amikor a [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) tulajdonság **Custom** értékre van állítva. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat [**DataPoints**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartSeriesCollection) gyűjteményének egy adott adatpontján:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Érjen el az első diagram sorozatát, és állítsa be az X hibasáv formátumát.
1. Érjen el az első diagram sorozatát, és állítsa be az Y hibasáv formátumát.
1. Érjen el a diagram sorozat egyéni adatpontjait, és állítsa be az egyes adatpontok hibasáv értékeit.
1. Állítsa be a sávok értékeit és formátumát.
1. Írja a módosított bemutatót egy PPTX fájlba.

```java
// Hozzon létre egy Presentation osztály példányt
Presentation pres = new Presentation();
try {
    // Buborékdiagram létrehozása
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Egyéni hibasávok hozzáadása és formátumuk beállítása
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Diagram sorozat adatpontjának elérése és hibasáv értékek beállítása
    // egyedi ponthoz
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Hibasávok beállítása a diagram sorozat pontjaihoz
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Bemutató mentése
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mi történik a hibasávokkal, amikor egy bemutatót PDF‑be vagy képekbe exportálunk?**

A hibasávok a diagram részeként kerülnek renderelésre, és a konverzió során megmaradnak a diagram formázásával együtt, feltéve hogy kompatibilis verzió vagy renderelő van használatban.

**Kombinálhatóak a hibasávok jelzőkkel és adatcímkékkel?**

Igen. A hibasávok különálló elemként léteznek, és kompatibilisek a jelzőkkel és adatcímkékkel; ha az elemek átfednek, akkor a formázást módosítani kell.

**Hol találom a hibasávokkal kapcsolatos tulajdonságok és osztályok listáját az API‑ban?**

Az API‑referenciában: a [ErrorBarsFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/errorbarsformat/) osztály és a kapcsolódó osztályok [ErrorBarType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/errorbartype/) valamint [ErrorBarValueType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/errorbarvaluetype/).