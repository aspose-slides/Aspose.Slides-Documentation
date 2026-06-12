---
title: Aplikace efektů tvarů v prezentacích pomocí JavaScriptu
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/nodejs-java/shape-effect/
keywords:
- efekt tvaru
- stínový efekt
- odrazový efekt
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v JavaScriptu a Aspose.Slides pro Node.js - vytvořte úchvatné, profesionální snímky během několika vteřin."
---
## **Úvod**

Zatímco efekty v PowerPointu mohou být použity k zvýraznění tvaru, liší se od [výplní](/slides/cs/nodejs-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů. 

* Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu jsou v PowerPointu možnosti pod **Preset**. Možnosti Preset jsou v podstatě ověřená dobře vypadající kombinace dvou nebo více efektů. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli pěknou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/EffectFormat), které vám umožní použít stejné efekty na tvary v prezentacích PowerPointu.

## **Použití stínového efektu**

Tento JavaScriptový kód vám ukazuje, jak aplikovat efekt vnějšího stínu ([getOuterShadowEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) na obdélník:

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

## **Použití odrazového efektu**

Tento JavaScriptový kód vám ukazuje, jak aplikovat odrazový efekt na tvar:

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

## **Použití efektu záře**

Tento JavaScriptový kód vám ukazuje, jak aplikovat efekt záře na tvar:

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

## **Použití efektu měkkých okrajů**

Tento JavaScriptový kód vám ukazuje, jak aplikovat měkké okraje na tvar:

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

## **FAQ**

**Mohu aplikovat více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako je stín, odraz a záře, na jediném tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete aplikovat na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.