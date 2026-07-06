---
title: Obtener los límites de la porción de texto en presentaciones con JavaScript
linktitle: Límites de la porción
type: docs
weight: 47
url: /es/nodejs-java/portion-bounds/
keywords:
- límites de porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo obtener los límites de la porción de texto en presentaciones de PowerPoint utilizando Aspose.Slides para Node.js mediante Java."
---
## **Visión general**

Una porción de texto representa un fragmento específico de texto dentro de un párrafo y le permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando necesita obtener los límites de un fragmento de texto, aplicar formato solo a una parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción usando [Portion.getRect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/getrect/). También muestra cómo obtener las coordenadas del comienzo de una porción usando [Portion.getCoordinates](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/getcoordinates/). Además, destaca escenarios comunes relacionados con porciones, como aplicar un hipervínculo a un único fragmento de texto, comprender cómo se resuelve el formato a través de la herencia de porción, párrafo, marco de texto y tema, y gestionar casos en los que una fuente especificada no está disponible.

## **Obtener los límites de una porción de texto**

Utilice [Portion.getRect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/getrect/) para obtener el rectángulo delimitador de una porción de texto:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obtener las coordenadas de una porción de texto**

Utilice [Portion.getCoordinates](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/getcoordinates/) para obtener las coordenadas del comienzo de una porción de texto:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puede [asignar un hipervínculo](/slides/es/nodejs-java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una porción y qué se toma de un párrafo o de un marco de texto?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/), Aspose.Slides la toma del [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/). Si tampoco está establecida allí, Aspose.Slides usa el estilo del [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una porción no está disponible en la máquina o servidor de destino?**

Se aplican las [Reglas de sustitución de fuentes](/slides/es/nodejs-java/font-selection-sequence/). El texto puede refluenciar: las métricas, la guionización y el ancho pueden cambiar, lo que afecta al posicionamiento preciso.

**¿Puedo establecer la transparencia o un degradado de relleno de texto específicos de una porción de forma independiente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/) pueden ser diferentes de los fragmentos vecinos.