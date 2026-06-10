---
title: Animáció
type: docs
weight: 100
url: /hu/nodejs-java/examples/elements/animation/
keywords:
- kódrészlet
- animáció
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js animációs példákat: adjon hozzá, sorozzon, és testreszabja a hatásokat és átmeneteket JavaScript‑ben PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan hozhatunk létre egyszerű animációkat, és kezelhetjük azok sorrendjét az **Aspose.Slides for Node.js via Java** használatával.

## **Animáció hozzáadása**

Hozzon létre egy téglalap alakzatot, és alkalmazzon egy kattintáskor elinduló elhalványulási hatást.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // Elhalványulási effektus.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Animáció elérése**

Szerezze meg az első animációs hatást a diavonal idővonalából.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Az első animációs hatás elérése.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Animáció eltávolítása**

Távolítson el egy animációs hatást a sorozatból.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // Az első hatás eltávolítása.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Animációk sorozata**

Adjon hozzá több hatást, és mutassa be, milyen sorrendben zajlanak az animációk.

```js
function sequenceAnimations() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 200, 50, 100, 100);

        let sequence = slide.getTimeline().getMainSequence();
        sequence.addEffect(
            shape1, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
        sequence.addEffect(
            shape2, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation_sequence.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```