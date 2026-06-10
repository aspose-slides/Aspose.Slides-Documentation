---
title: Alakzat-hatások alkalmazása prezentációkban Java használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/java/shape-effect/
keywords:
- alakzat-hatás
- árnyékhatás
- tükröző hatás
- fénylő hatás
- lágy szélű hatás
- hatásformátum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat-hatásokkal az Aspose.Slides for Java segítségével – hozza létre másodpercek alatt a látványos, profi diákot."
---
## **Bevezetés**

Miközben a PowerPoint‑ban a hatásokat arra használhatjuk, hogy egy alakzat kitűnjön, eltérnek a [kitöltésektől](/slides/hu/java/shape-formatting/#gradient-fill) vagy a kontúroktól. A PowerPoint‑hatások segítségével meggyőző tükröződéseket hozhat létre egy alakzaton, szórhatja az alakzat fénylő hatását stb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra. 

* Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint beállításai a **Preset** alatt. Az előre beállított lehetőségek lényegében egy jól kinéző, két vagy több hatásból álló kombinációt jelentenek. Így egy előre beállítást kiválasztva nem kell időt pazarolni a különböző hatások tesztelésére vagy kombinálására a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/EffectFormat) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Ez a Java‑kód megmutatja, hogyan alkalmazhatja a külső árnyékhatást ([OuterShadowEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) egy téglalapra:

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

## **Tükröző hatás alkalmazása**

Ez a Java‑kód megmutatja, hogyan alkalmazhatja a tükröződés hatását egy alakzatra:

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

## **Fénylő hatás alkalmazása**

Ez a Java‑kód megmutatja, hogyan alkalmazhatja a fénylő hatást egy alakzatra:

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

Ez a Java‑kód megmutatja, hogyan alkalmazhatja a lágy szélű hatást egy alakzatra:

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

Igen, kombinálhat különböző hatásokat, például árnyékot, tükröződést és fénylést egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Hatásokat különféle alakzatokra lehet alkalmazni, többek között automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és még sok másra.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat hatásokat. A hatás az egész csoportra lesz érvényes.