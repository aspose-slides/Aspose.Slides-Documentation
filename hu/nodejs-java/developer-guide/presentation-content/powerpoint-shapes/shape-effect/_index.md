---
title: Alakzat effektusok alkalmazása prezentációkban JavaScript segítségével
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/nodejs-java/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- tükröződés effektus
- fénylődés effektus
- lágy szélek effektus
- effektus formátum
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat effektusokkal JavaScript és a Node.js-hez készült Aspose.Slides használatával - hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Míg a PowerPoint‑ban lévő effektusokat lehet használni egy alakzat kiemelésére, különböznek a [kitöltések](/slides/hu/nodejs-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. PowerPoint‑effektusokkal meggyőző tükröződéseket hozhat létre egy alakzaton, szétterítheti az alakzat fénylődését stb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* A PowerPoint hat effektust kínál, amelyek alakzatokra alkalmazhatók. Egy vagy több effektust is alkalmazhat egy alakzatra. 

* Bizonyos effektuskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint a **Preset** alatt kínál opciókat. Az előre beállított opciók lényegében egy jól kinéző, két vagy több effektusból álló kombinációt jelentenek. Így egy előre beállított kiválasztásával nem kell időt vesztegetni a különböző effektusok tesztelésével vagy kombinálásával a megfelelő megjelenés megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/EffectFormat) osztályban biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik ugyanazoknak az effektusoknak az alkalmazását a PowerPoint‑prezentációk alakzataira.

## **Árnyék effektus alkalmazása**

Ez a JavaScript‑kód megmutatja, hogyan kell alkalmazni a külső árnyék effektust ([getOuterShadowEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) egy téglalapra:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tükröződés effektus alkalmazása**

Ez a JavaScript‑kód megmutatja, hogyan kell alkalmazni a tükröződés effektust egy alakzatra:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Fénylődés effektus alkalmazása**

Ez a JavaScript‑kód megmutatja, hogyan kell alkalmazni a fénylődés effektust egy alakzatra:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lágy szélek effektus alkalmazása**

Ez a JavaScript‑kód megmutatja, hogyan kell alkalmazni a lágy széleket egy alakzatra:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, több különböző effektust, például árnyékot, tükröződést és fénylődést is kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különféle alakzatokra alkalmazhat effektusokat, például automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyéb elemkre.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra lesz hatással.