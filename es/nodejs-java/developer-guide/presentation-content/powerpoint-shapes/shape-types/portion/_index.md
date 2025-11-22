---
title: Porción
type: docs
weight: 70
url: /es/nodejs-java/portion/
---

## **Obtener coordenadas de posición de la Porción**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) método se ha añadido a la clase [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) que permite obtener las coordenadas del comienzo de la porción.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Remodelar el contexto de la presentación
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un solo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/nodejs-java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué anula una Porción y qué se toma del Párrafo/TextFrame?**

Las propiedades a nivel de Porción tienen la precedencia más alta. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/); si tampoco está establecida allí, la toma del [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una Porción no está presente en la máquina/servidor de destino?**

Se aplican las [Reglas de sustitución de fuentes](/slides/es/nodejs-java/font-selection-sequence/). El texto puede reajustarse: las métricas, la guionización y el ancho pueden cambiar, lo que es importante para un posicionamiento preciso.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico de una Porción independiente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.