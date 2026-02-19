---
title: Animation
type: docs
weight: 100
url: /de/nodejs-java/examples/elements/animation/
keywords:
- Codebeispiel
- Animation
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Animationsbeispiele von Aspose.Slides für Node.js: Hinzufügen, Sequenzieren und Anpassen von Effekten und Übergängen mit JavaScript für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man einfache Animationen erstellt und ihre Reihenfolge mit **Aspose.Slides for Node.js via Java** verwaltet.

## **Animation hinzufügen**

Erstellen Sie eine Rechteckform und wenden Sie einen Fade-Effekt an, der bei einem Klick ausgelöst wird.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // Fade-Effekt.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Animation abrufen**

Rufen Sie den ersten Animationseffekt aus der Folientimeline ab.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zugriff auf den ersten Animationseffekt.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Animation entfernen**

Entfernen Sie einen Animationseffekt aus der Sequenz.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // Entferne den ersten Effekt.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Animationen sequenzieren**

Fügen Sie mehrere Effekte hinzu und zeigen Sie die Reihenfolge, in der die Animationen auftreten.

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