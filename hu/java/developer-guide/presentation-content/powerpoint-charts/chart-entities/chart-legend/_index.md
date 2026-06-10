---
title: Diagram legendák testreszabása prezentációkban Java használatával
linktitle: Diagram legend
type: docs
url: /hu/java/chart-legend/
keywords:
- diagram legenda
- legend pozíció
- betűméret
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Testreszabott diagram legendákat hozhat létre az Aspose.Slides for Java segítségével, hogy a PowerPoint prezentációk a sajátos legend formázással optimalizáltak legyenek."
---
## **Áttekintés**

Az Aspose.Slides lehetőséget biztosít a diagrammagyarázat testreszabására PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet beállítani a legend pozícióját és méretét, hogyan állítható be a teljes legend betűmérete, valamint hogyan formázható egyedi legendabejegyzés.

A GYIK-ben további kapcsolódó viselkedéseket is tárgyalunk, többek között a nem‑átfedő mód használatát, hogy a diagramterület helyet biztosítson a legendnek, a hosszú legendacímkék tördelését vagy sortörésekkel való használatát, valamint azt, hogy a legend formázása a prezentáció témájából öröklődjön, ha nincs megadva explicit szöveg‑ és kitöltés‑beállítás.

## **Legend Pozicionálása**
A legend tulajdonságainak beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Szerezze meg a dia hivatkozását.
- Adjon hozzá egy diagramot a diára.
- Állítsa be a legend tulajdonságait.
- Írja ki a prezentációt PPTX fájlként.

Az alább bemutatott példában beállítottuk a diagramlegend pozícióját és méretét.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Szerezze meg a dia hivatkozását
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adjon hozzá egy csoportosított oszlopdiagramot a diára
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Állítsa be a legend tulajdonságait
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Írja ki a prezentációt a lemezre
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A Legend Betűméretének Beállítása**
Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára a legend betűméretének beállítását. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Hozza létre az alapértelmezett diagramot.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Írja ki a prezentációt a lemezre.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyedi Legendabejegyzés Betűméretének Beállítása**
Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára egyedi legendabejegyzések betűméretének beállítását. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Hozza létre az alapértelmezett diagramot.
- Hozzáférés a legendabejegyzéshez.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Írja ki a prezentációt a lemezre.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Engedélyezhetem a legendet úgy, hogy a diagram automatikusan helyet biztosítson neki ahelyett, hogy átfedné?**

Igen. Használja a nem‑átfedő módot ([setOverlay(false)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/legend/#setOverlay-boolean-)); ebben az esetben a diagramterület zsugorodni fog, hogy helyet adjon a legendnek.

**Készíthetek többsoros legendacímkéket?**

Igen. A hosszú címkék automatikusan tördelődnek, ha nincs elegendő hely; a kényszerített sortöréseket a sorvégi karakterekkel a sorozat nevében lehet megadni.

**Hogyan tehetem, hogy a legend a prezentáció téma színsémáját kövesse?**

Ne állítson be explicit színeket/kitöltéseket/betűtípusokat a legend vagy annak szövege számára. Ebben az esetben a beállítások öröklődnek a témából, és helyesen frissülnek, ha a dizájn változik.