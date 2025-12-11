---
title: Animar texto de PowerPoint en Android
linktitle: Texto animado
type: docs
weight: 60
url: /es/androidjava/animated-text/
keywords:
- texto animado
- animación de texto
- párrafo animado
- animación de párrafo
- efecto de animación
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Cree texto animado dinámico en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Android, con ejemplos de código Java optimizados y fáciles de seguir."
---

## **Agregar efectos de animación a los párrafos**

Agregamos el método [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) a las clases [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) y [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). Este método le permite agregar efectos de animación a un solo párrafo. El siguiente código de ejemplo muestra cómo agregar un efecto de animación a un solo párrafo:
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


## **Obtener efectos de animación de los párrafos**

Puede que desee averiguar los efectos de animación añadidos a un párrafo; por ejemplo, en un caso, quiere obtener los efectos de animación de un párrafo porque planea aplicar esos efectos a otro párrafo o forma.

Aspose.Slides para Android mediante Java le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). El siguiente código de ejemplo muestra cómo obtener los efectos de animación en un párrafo:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo difieren las animaciones de texto de las transiciones de diapositiva, y pueden combinarse?**

Las animaciones de texto controlan el comportamiento de los objetos a lo largo del tiempo en una diapositiva, mientras que las [transitions](/slides/es/androidjava/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo determina la línea de tiempo de la animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. Los PDF y las imágenes rasterizadas son estáticos, por lo que verá un único estado de la diapositiva sin movimiento. Para conservar el movimiento, use la exportación a [video](/slides/es/androidjava/convert-powerpoint-to-video/) o a [HTML](/slides/es/androidjava/export-to-html5/).

**¿Funcionan las animaciones de texto en diseños y en la diapositiva maestra?**

Los efectos aplicados a objetos de diseño/maestro se heredan en las diapositivas, pero su sincronización e interacción con las animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.