---
title: Crear presentaciones en Node.js a través de .NET
linktitle: Crear presentación
type: docs
weight: 10
url: /es/nodejs-net/create-presentation/
keywords:
- crear presentación
- nueva presentación
- crear PowerPoint
- crear PPTX
- añadir cuadro de texto
- añadir diapositiva
- tamaño de diapositiva
- panorámica
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear presentaciones de PowerPoint en JavaScript con Aspose.Slides for Node.js a través de .NET: añadir un cuadro de texto y diapositivas, establecer un tamaño de diapositiva 16:9 y guardar el resultado como PPTX."
---
## **Descripción general**

Este artículo muestra cómo crear una presentación con Aspose.Slides for Node.js via .NET, añadir un cuadro de texto a su primera diapositiva y guardar el resultado como un archivo PPTX. También muestra cómo añadir más diapositivas y cómo cambiar la presentación a diapositivas panorámicas (16:9).

Los ejemplos requieren un proyecto configurado como se describe en [Installation](/slides/es/nodejs-net/installation/). Guarde cada ejemplo como un archivo `.js` en la carpeta del proyecto y ejecútelo desde esa carpeta con `node`, por ejemplo `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET no tiene una referencia de API propia. Refleja la API de Aspose.Slides for .NET con nombres camelCase, por lo que los enlaces de API en este artículo llevan a las clases y miembros correspondientes en la [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/es/net/).
{{% /alert %}}

## **Crear una presentación con un cuadro de texto**

Para crear una presentación y colocar un cuadro de texto en su primera diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
1. Obtenga esa diapositiva de la colección [slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/). Las colecciones en este paquete se leen con `get(index)`, y los índices comienzan en 0.
1. Añada un rectángulo con el método [addAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/shapecollection/addautoshape/) y establezca el [text](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/text/) de su [textFrame](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/textframe/).
1. Guarde la presentación con el método [save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) y el valor `SaveFormat.Pptx`.
1. Llame a `dispose` en un bloque `finally` para liberar los recursos .NET que respaldan la presentación.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La posición (x, y) y el tamaño (ancho, alto) están en puntos.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

El script escribe `new-presentation.pptx` en la carpeta del proyecto. El archivo tiene una diapositiva con un rectángulo relleno cuyo vértice superior izquierdo está a 50 puntos de los bordes izquierdo y superior de la diapositiva. El rectángulo mide 400 puntos de ancho y 100 puntos de alto, y su texto está centrado. Un punto equivale a 1/72 de pulgada. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a la diapositiva; consulte [Licensing](/slides/es/nodejs-net/licensing/).

## **Agregar diapositivas**

Una nueva presentación tiene una diapositiva. Para añadir más, pase una diapositiva de diseño al método [addEmptySlide](https://reference.aspose.com/slides/es/net/aspose.slides/slidecollection/addemptyslide/) de la colección `slides`. El método [getByType](https://reference.aspose.com/slides/es/net/aspose.slides/layoutslidecollection/getbytype/) de la colección [layoutSlides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/layoutslides/) devuelve el primer diseño de un determinado [SlideLayoutType](https://reference.aspose.com/slides/es/net/aspose.slides/slidelayouttype/).

El siguiente ejemplo añade dos diapositivas con el diseño Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El script muestra `Slide count: 3` y escribe `three-slides.pptx`. Las nuevas diapositivas se añaden al final de la primera y no contienen formas. Una nueva presentación siempre tiene un diseño Blank, pero una presentación que abra desde un archivo puede no tener un diseño del tipo solicitado; en ese caso `getByType` devuelve `null`, por lo que debe comprobar el resultado antes de usarlo.

## **Establecer el tamaño de la diapositiva**

Una nueva presentación usa diapositivas 4:3 que miden 720 × 540 puntos (10 × 7,5 pulgadas). Para crear diapositivas panorámicas, llame al método [setSize](https://reference.aspose.com/slides/es/net/aspose.slides/slidesize/setsize/) de la propiedad [slideSize](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slidesize/) de la presentación, con un valor de [SlideSizeType](https://reference.aspose.com/slides/es/net/aspose.slides/slidesizetype/) y un valor de [SlideSizeScaleType](https://reference.aspose.com/slides/es/net/aspose.slides/slidesizescaletype/). El tipo de escala indica a Aspose.Slides qué hacer con las formas que ya están en las diapositivas; `DoNotScale` las deja tal cual, lo que es la opción adecuada para una presentación que aún no tiene contenido.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El script muestra `Slide size: 960 x 540 points`, que equivale a 13,33 × 7,5 pulgadas, y escribe `widescreen.pptx`. `SlideSizeType.OnScreen16x9` tiene la misma relación de aspecto 16:9 pero es más pequeño: 720 × 405 puntos.

## **Preguntas frecuentes**

**¿En qué unidades se miden las posiciones y tamaños?**

En puntos. Una pulgada son 72 puntos, por lo que la diapositiva 4:3 predeterminada es de 720 × 540 puntos, y una diapositiva panorámica 16:9 es de 960 × 540 puntos.

**¿En qué formatos puedo guardar una nueva presentación?**

Cualquier valor de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/), por ejemplo `SaveFormat.Ppt` para PowerPoint 97–2003, `SaveFormat.Odp` para OpenDocument o `SaveFormat.Pdf`. Para salida PDF, consulte [Convert PowerPoint to PDF](/slides/es/nodejs-net/convert-powerpoint-to-pdf/).

**¿Por qué la presentación guardada contiene el texto "Evaluation only"?**

Sin una licencia, Aspose.Slides añade una marca de agua de evaluación a las diapositivas que guarda. Aplique una licencia como se describe en [Licensing](/slides/es/nodejs-net/licensing/) para eliminarla.

**¿Por qué debería llamar a `dispose`?**

Un objeto `Presentation` está respaldado por un objeto .NET que ocupa memoria y otros recursos. Llamar a `dispose` los libera en cuanto ya no necesite la presentación, y hacerlo en un bloque `finally` los libera incluso si se produce un error.