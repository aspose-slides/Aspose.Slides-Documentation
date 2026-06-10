---
title: "Hibasávok testreszabása prezentációs diagramokban Java használatával"
linktitle: "Hibasáv"
type: docs
url: /hu/java/error-bar/
keywords:
- "hibasáv"
- "egyedi érték"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibasávokat a diagramokhoz az Aspose.Slides for Java segítségével – optimalizálja az adatok megjelenítését PowerPoint‑prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet hibasávokkal dolgozni a bemutatók diagramjaiban az Aspose.Slides használatával. Megmutatja, hogyan adhat hibasávokat egy diagram sorozathoz, hogyan konfigurálhatja az X és Y hibasáv beállításait, valamint hogyan alkalmazhat különböző értéktípusokat, például fix, százalékos és egyedi értékeket.

Az is bemutatja, hogyan rendelhet egyedi hibasávértékeket egy sorozat egyes adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Ezenkívül a cikk rövid megjegyzéseket tartalmaz arról, hogyan viselkednek a hibasávok exportálás során, kompatibilitásukról a jelölőkkel és adatcímkékkel, valamint arról, hol találhatók a kapcsolódó API hivatkozási osztályok és felsorolások.

## **Hibasávok hozzáadása**
Aspose.Slides for Java egyszerű API-t biztosít a hibasávértékek kezeléséhez. A példakód egy egyedi értéktípus használatakor alkalmazható. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat [**DataPoints**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeriesCollection) gyűjteményében lévő egy adott adatpontra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy buborékdiagramot a kívánt diára.  
3. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv X formátumát.  
4. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv Y formátumát.  
5. A sávok értékének és formátumának beállítása.  
6. Írja a módosított bemutatót egy PPTX fájlba.

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

    // Prezentáció mentése
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyedi hibasávértékek hozzáadása**
Aspose.Slides for Java egyszerű API-t biztosít egyedi hibasávértékek kezeléséhez. A példakód akkor alkalmazható, ha a [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IErrorBarsFormat#getValue--) tulajdonság **Custom** értékre van állítva. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat [**DataPoints**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartSeriesCollection) gyűjteményében lévő egy adott adatpontra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy buborékdiagramot a kívánt diára.  
3. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv X formátumát.  
4. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv Y formátumát.  
5. Hozzáférés a diagram sorozat egyedi adatpontjaihoz, és az egyes sorozat adatpontok hibasáv értékeinek beállítása.  
6. A sávok értékének és formátumának beállítása.  
7. Írja a módosított bemutatót egy PPTX fájlba.

```java
// Hozzon létre egy Presentation osztály példányt
Presentation pres = new Presentation();
try {
    // Buborékdiagram létrehozása
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Egyedi hibasávok hozzáadása és formátumuk beállítása
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Diagram sorozat adatpontjának elérése és hibasáv értékek beállítása a
    // egyes pont számára
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

    // Prezentáció mentése
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mi történik a hibasávokkal, amikor egy bemutatót PDF-be vagy képekbe exportálunk?**  
A hibasávok a diagram részeként kerülnek renderelésre, és a konverzió során megmaradnak a diagram többi formázásával együtt, feltéve, hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**Kombinálhatók a hibasávok jelölőkkel és adatcímkékkel?**  
Igen. A hibasávok különálló elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfednek, előfordulhat, hogy a formázást módosítani kell.

**Hol találom meg a hibasávokkal kapcsolatos tulajdonságok és osztályok listáját az API-ban?**  
Az API-referencia: a [ErrorBarsFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/errorbarsformat/) osztály és a kapcsolódó osztályok [ErrorBarType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/errorbartype/) és [ErrorBarValueType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/errorbarvaluetype/).