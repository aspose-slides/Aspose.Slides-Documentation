---
title: Diagrammagyarázatok testreszabása prezentációkban Androidon
linktitle: Diagrammagyarázat
type: docs
url: /hu/androidjava/chart-legend/
keywords:
- diagrammagyarázat
- magyarázat pozíciója
- betűméret
- PowerPoint
- prezentáció
- Android
- Aspose.Slides
description: "Testreszabott diagrammagyarázatok az Aspose.Slides for Android via Java használatával a PowerPoint-prezentációk optimalizálásához, a legendák egyedi formázásával."
---
## **Áttekintés**

Az Aspose.Slides lehetőségeket kínál a diagrammagyarázatok testreszabásához a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy magyarázatot, beállítani a teljes magyarázat betűméretét, valamint formázni egy adott magyarázati elemet.

A GYIK‑ban is több kapcsolódó viselkedést tárgyal, többek között a nem átfedési mód használatát, amely lehetővé teszi, hogy a diagramterület helyet biztosítson a magyarázatnak, a hosszú magyarázati címkék automatikus tördelését vagy sortörések használatát, valamint hogy a magyarázat formázása öröklődjön a prezentáció témájától, ha nem kerülnek megadásra explicit szöveg‑ és kitöltési beállítások.

## **Legenda elhelyezése**
A legenda tulajdonságainak beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze meg a dia hivatkozását.
- Adjon hozzá egy diagramot a diára.
- Állítsa be a legenda tulajdonságait.
- Írja ki a prezentációt PPTX fájlként.

Az alábbi példában beállítottuk a diagrammagyarázat pozícióját és méretét.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Szerezze meg a dia hivatkozását
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adjon hozzá egy klaszterezett oszlopdiagramot a diára
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Állítsa be a legenda tulajdonságait
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Mentse a prezentációt lemezre
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A legenda betűméretének beállítása**
Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára a legenda betűméretének beállítását. Kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályt.
- Hozza létre az alapértelmezett diagramot.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Írja ki a prezentációt lemezre.

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

## **Egy adott legenda betűméretének beállítása**
Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára az egyes legendaelemek betűméretének beállítását. Kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályt.
- Hozza létre az alapértelmezett diagramot.
- Hozzáférés a legendaelemhez.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Írja ki a prezentációt lemezre.

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

## **FAQ**

**Engedélyezhetem a magyarázatot úgy, hogy a diagram automatikusan helyet biztosítson számára ahelyett, hogy átfedné?**

Igen. Használja a nem átfedési módot ([setOverlay(false)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); ebben az esetben a diagramterület összezsugorodik, hogy helyet biztosítson a magyarázatnak.

**Készíthetek több soros legenda címkéket?**

Igen. A hosszú címkék automatikusan tördelődnek, ha nincs elég hely; a kényszerített sortöréseket a sorozat nevében lévő új sor karakterek támogatják.

**Hogyan tehetem, hogy a legenda a prezentáció téma színsémáját kövesse?**

Ne állítson be explicit színeket/kitöltéseket/betűtípusokat a legenda vagy annak szövege számára. Ezek ekkor a témától öröklődnek, és a tervezés változásakor megfelelően frissülnek.