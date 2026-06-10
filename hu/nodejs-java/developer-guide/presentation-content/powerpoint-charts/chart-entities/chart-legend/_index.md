---
title: Diagramlegendák testreszabása bemutatókban JavaScript használatával
linktitle: Diagramlegenda
type: docs
url: /hu/nodejs-java/chart-legend/
keywords:
- diagram legenda
- legend pozíció
- betűméret
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabott diagramlegendák JavaScript és Aspose.Slides for Node.js segítségével a PowerPoint bemutatók optimalizálásához, a legendák egyedi formázásával."
---
## **Áttekintés**

Aspose.Slides lehetőségeket kínál a diagramlegendák testreszabására PowerPoint bemutatókban. Ez a cikk bemutatja, hogyan állítható be a legenda pozíciója és mérete, hogyan állítható be a teljes legenda betűmérete, és hogyan alkalmazható formázás egy egyedi legendabejegyzésre.

Továbbá a GYIK-ben számos kapcsolódó viselkedést tárgyal, többek között a nem‑átfedés mód használatát, amelyben a diagramterület helyet biztosít a legendának, a hosszú legendacímkék automatikus tördelését vagy sorvégek használatát, valamint azt, hogy a legenda formázása öröklődjön a bemutató témájától, ha nem kerülnek megadva explicit szöveg- és kitöltésbeállítások.

## **Legenda elhelyezése**

A legenda tulajdonságainak beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
- Szerezze be a dia referenciáját.
- Hozzon létre egy diagramot a dián.
- Állítsa be a legenda tulajdonságait.
- Írja ki a bemutatót PPTX fájlként.

Az alább bemutatott példában beállítottuk a diagram legenda pozícióját és méretét.

```javascript
// Presentation osztály példányának létrehozása
var pres = new aspose.slides.Presentation();
try {
    // Diára való hivatkozás lekérése
    var slide = pres.getSlides().get_Item(0);
    // Csoportos oszlopdiagram hozzáadása a diára
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Legend tulajdonságok beállítása
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Bemutató mentése lemezre
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Legenda betűméretének beállítása**

Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára a legenda betűméretének beállítását. Kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály példányt.
- Hozzon létre egy alapértelmezett diagramot.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Írja ki a bemutatót a lemezre.

```javascript
// Presentation osztály példányának létrehozása
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Egyedi legendabejegyzés betűméretének beállítása**

Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára az egyedi legendabejegyzések betűméretének beállítását. Kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály példányt.
- Hozzon létre egy alapértelmezett diagramot.
- Hozzáférés a legendabejegyzéshez.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Írja ki a bemutatót a lemezre.

```javascript
// Presentation osztály példányának létrehozása
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Bekapcsolhatom a legendát úgy, hogy a diagram automatikusan helyet biztosítson számára a felülírás helyett?**

Igen. Használja a nem‑átfedés módot ([setOverlay(false)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/legend/setoverlay/)); ebben az esetben a diagramterület zsugorodni fog, hogy helyet adjon a legendának.

**Készíthetek több soros legendacímkéket?**

Igen. A hosszú címkék automatikusan megtörnek, ha a hely nem elegendő; a kényszerített sortöréseket a soron belüli újsor karakterek támogatják a sorozat nevében.

**Hogyan tehetem, hogy a legenda a bemutató téma színsémáját kövesse?**

Ne állítson be explicit színeket/kitöltéseket/betűtípusokat a legendához vagy annak szövegéhez. Ezek ilyenkor a témából öröklődnek, és a tervezés változásakor megfelelően frissülnek.