---
title: Texto Animado
type: docs
weight: 60
url: /java/animated-text/
keywords: "Texto animado en PowerPoint"
description: "Texto animado en PowerPoint con Java"
---

## Agregar Efectos de Animación a los Párrafos

Agregamos el [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) método a las clases [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) y [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence). Este método permite agregar efectos de animación a un solo párrafo. Este código de muestra muestra cómo agregar un efecto de animación a un solo párrafo:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // seleccionar párrafo para agregar efecto
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // agregar efecto de animación Fly al párrafo seleccionado
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## Obtener los Efectos de Animación en los Párrafos

Puede decidir averiguar los efectos de animación añadidos a un párrafo; por ejemplo, en un escenario, desea obtener los efectos de animación en un párrafo porque planea aplicar esos efectos a otro párrafo o forma.

Aspose.Slides para Java le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). Este código de muestra muestra cómo obtener los efectos de animación en un párrafo:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("El párrafo \"" + paragraph.getText() + "\" tiene el efecto " + effects[0].getType() + ".");
    }
} finally {
    pres.dispose();
}
```