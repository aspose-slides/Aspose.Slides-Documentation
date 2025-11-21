---
title: Texto animado
type: docs
weight: 60
url: /es/nodejs-java/animated-text/
keywords: "Texto animado en PowerPoint"
description: "Texto animado en PowerPoint con Java"
---

## **Agregar efectos de animación a los párrafos**

Añadimos el método [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) a las clases [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) y [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence). Este método le permite agregar efectos de animación a un solo párrafo. El siguiente código de ejemplo muestra cómo agregar un efecto de animación a un solo párrafo:
```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // seleccionar párrafo para agregar efecto
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // agregar efecto de animación Fly al párrafo seleccionado
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Obtener los efectos de animación en los párrafos**

Es posible que desee averiguar los efectos de animación agregados a un párrafo; por ejemplo, en un caso, quiere obtener los efectos de animación de un párrafo porque planea aplicar esos efectos a otro párrafo o forma.

Aspose.Slides for Node.js a través de Java le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). El siguiente código de ejemplo muestra cómo obtener los efectos de animación en un párrafo:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```


## **Preguntas frecuentes**

**¿En qué se diferencian las animaciones de texto de las transiciones de diapositiva, y pueden combinarse?**

Las animaciones de texto controlan el comportamiento de los objetos a lo largo del tiempo en una diapositiva, mientras que [transitions](/slides/es/nodejs-java/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo determina la línea de tiempo de la animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. Los PDF y las imágenes rasterizadas son estáticos, por lo que verá un único estado de la diapositiva sin movimiento. Para conservar el movimiento, utilice la exportación a [video](/slides/es/nodejs-java/convert-powerpoint-to-video/) o a [HTML](/slides/es/nodejs-java/export-to-html5/).

**¿Funcionan las animaciones de texto en los diseños y en la diapositiva maestra?**

Los efectos aplicados a objetos de diseño/maestra se heredan en las diapositivas, pero su temporización e interacción con las animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.