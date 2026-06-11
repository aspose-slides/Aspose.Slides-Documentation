---
title: Animation
type: docs
weight: 100
url: /sv/nodejs-java/examples/elements/animation/
keywords:
- kodexempel
- animation
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Utforska Aspose.Slides för Node.js animationsexempel: lägg till, sekvensera och anpassa effekter och övergångar med JavaScript för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man skapar enkla animationer och hanterar deras sekvens med hjälp av **Aspose.Slides for Node.js via Java**.

## **Lägg till en animation**

Skapa en rektangelform och tillämpa en toningseffekt som triggas vid klick.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // Toningseffekt.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till en animation**

Hämta den första animationseffekten från bildens tidslinje.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Åtkomst till den första animationseffekten.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en animation**

Ta bort en animationseffekt från sekvensen.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // Ta bort den första effekten.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sekvensanimationer**

Lägg till flera effekter och visa i vilken ordning animationerna sker.

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