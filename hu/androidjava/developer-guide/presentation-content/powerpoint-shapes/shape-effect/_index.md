---
title: Alakzat hatások alkalmazása Android prezentációkban
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/androidjava/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükrözés hatás
- ragyogás hatás
- lágy szélű hatás
- hatás formátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alakítsa át a PPT és PPTX fájljait fejlett alakzat hatásokkal az Aspose.Slides for Android Java használatával — hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint effektusait arra lehet használni, hogy egy alakzat kitűnjön, különböznek a [kitöltésektől](/slides/hu/androidjava/shape-formatting/#gradient-fill) vagy szegélyektől. A PowerPoint effektusok segítségével meggyőző tükröződéseket hozhat létre egy alakzaton, szórhatja az alakzat ragyogását stb.

<img src="shape-effect.png" alt="alakzat-effektus" style="zoom:50%;" />

* A PowerPoint hat hatást biztosít, amelyek alakzatokra alkalmazhatók. Egy alakzatra egy vagy több hatást is alkalmazhat.

* Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint lehetőségei a **Preset** alatt találhatók. A Preset beállítások lényegében egy jól kinéző, két vagy több hatásból álló kombináció. Így egy előre beállított sablont kiválasztva nem kell időt pazarolni a különböző hatások tesztelésével vagy kombinálásával, hogy jó kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/EffectFormat) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik ugyanazon hatások alkalmazását PowerPoint‑prezentációk alakzataira.

## **Árnyék hatás alkalmazása**

Ez a Java kód bemutatja, hogyan kell a külső árnyék hatást ([OuterShadowEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) alkalmazni egy téglalapra:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tükrözés hatás alkalmazása**

Ez a Java kód bemutatja, hogyan kell a tükrözés hatást egy alakzatra alkalmazni:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ragyogás hatás alkalmazása**

Ez a Java kód bemutatja, hogyan kell a ragyogás hatást egy alakzatra alkalmazni:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lágy szélű hatás alkalmazása**

Ez a Java kód bemutatja, hogyan kell a lágy széleket egy alakzatra alkalmazni:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükrözést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Hatásokat különféle alakzatokra alkalmazhat, többek között automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyebekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, a hatások csoportosított alakzatokra is alkalmazhatók. A hatás az egész csoportra vonatkozik.