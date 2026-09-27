---
title: Gestionar texto de la presentación en Node.js vía .NET
linktitle: Gestionar texto
type: docs
weight: 50
url: /es/nodejs-net/manage-text/
keywords:
- texto
- cuadro de texto
- añadir texto
- cambiar texto
- dar formato al texto
- tamaño de fuente
- texto en negrita
- marco de texto
- párrafo
- porción
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Añade un cuadro de texto a una diapositiva y luego cambia su texto, tamaño de fuente y estilo en negrita en JavaScript con Aspose.Slides para Node.js vía .NET."
---
## **Visión general**

En Aspose.Slides, el texto de una diapositiva pertenece a una forma. Una forma automática, como un rectángulo, tiene un marco de texto; el marco de texto contiene párrafos, y cada párrafo contiene porciones, que son secuencias de texto con el mismo formato. Cambia el texto a través del marco de texto y la fuente a través del formato de una porción.

Este artículo añade un cuadro de texto a una diapositiva y guarda la presentación. A continuación abre el archivo guardado y modifica el texto del cuadro, el tamaño de la fuente y el estilo en negrita.

Los ejemplos requieren un proyecto configurado como se describe en [Instalación](/slides/es/nodejs-net/installation/). Guarda cada ejemplo como un archivo `.js` en la carpeta del proyecto y ejecútalo desde esa carpeta con `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET no tiene su propia referencia de API. Refleja la API de Aspose.Slides for .NET con nombres en camelCase, por lo que los enlaces de API en este artículo llevan a las clases y miembros correspondientes en la [referencia de API de Aspose.Slides for .NET](https://reference.aspose.com/slides/es/net/).
{{% /alert %}}

## **Añadir un cuadro de texto**

Para añadir un cuadro de texto, agrega una forma automática a una diapositiva con el método [addAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/shapecollection/addautoshape/) y asígnale texto con el método [addTextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/addtextframe/). El siguiente ejemplo añade un rectángulo a la primera diapositiva de una nueva presentación y guarda la presentación como `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La posición (x, y) y el tamaño (ancho, alto) están en puntos.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

La diapositiva en `text-box.pptx` contiene un rectángulo, de 500 puntos de ancho y 80 puntos de alto, con el texto "Quarterly report" en la fuente y tamaño predeterminados. El siguiente ejemplo modifica este cuadro de texto.

## **Cambiar el texto y su formato**

El siguiente ejemplo abre `text-box.pptx`, creado en el ejemplo anterior, y obtiene la primera forma en la primera diapositiva. Las formas como imágenes y tablas no tienen marco de texto, por lo que el ejemplo comprueba que la forma sea un [AutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/) antes de usar el [textFrame](https://reference.aspose.com/slides/es/net/aspose.slides/autoshape/textframe/) de la forma. A continuación realiza lo siguiente:

1. Reemplaza el texto mediante la propiedad [text](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/text/) del marco de texto. Después de ello, el marco de texto contiene un párrafo con una sola porción.  
1. Obtiene esa porción de las colecciones [paragraphs](https://reference.aspose.com/slides/es/net/aspose.slides/textframe/paragraphs/) y [portions](https://reference.aspose.com/slides/es/net/aspose.slides/paragraph/portions/) y lee su [portionFormat](https://reference.aspose.com/slides/es/net/aspose.slides/portion/portionformat/).  
1. Establece [fontHeight](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/fontheight/), el tamaño de la fuente en puntos, y [fontBold](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/fontbold/), que acepta un valor [NullableBool](https://reference.aspose.com/slides/es/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

En `text-box-updated.pptx`, el cuadro de texto muestra "Quarterly report: third quarter" en negrita de 32 puntos. Como el nuevo texto es una única porción, ambas propiedades de formato se aplican a todo el texto. Sin una licencia, cada guardado añade una marca de agua de evaluación. Como `text-box.pptx` también se guardó en modo de evaluación, `text-box-updated.pptx` contiene dos; consulta [Evaluar Aspose.Slides](/slides/es/nodejs-net/evaluate-aspose-slides/).

## **Preguntas frecuentes**

**¿Por qué `fontBold` recibe un valor `NullableBool` en lugar de `true` o `false`?**

Una porción puede dejar una propiedad sin definir y heredarla del párrafo, de la forma o de la disposición y maestro de la diapositiva. `NullableBool.NotDefined` significa "heredar", mientras que `NullableBool.True` y `NullableBool.False` sobrescriben el valor heredado. Asignar `true` o `false` genera un error. Por la misma razón, `fontHeight` devuelve `NaN` cuando la porción hereda su tamaño de fuente.

**¿Cómo se cambia el color del texto?**

Establece el relleno del formato de la porción: asigna `FillType.Solid` a `portionFormat.fillFormat.fillType` y, a continuación, asigna un color como `"#FF0000"` a `portionFormat.fillFormat.solidFillColor.color`. Añade `FillType` a los nombres que importas del paquete.

**¿Cómo se da formato solo a una parte del texto?**

El formato pertenece a las porciones, por lo que esa parte del texto debe estar en una porción propia. Crea la porción con `Portion.CreatePortionFromText`, añádela a un párrafo con el método `add` de la colección `portions` del párrafo y, después, establece el `portionFormat` de la nueva porción. Añade `Portion` a los nombres que importas del paquete.

**¿Por qué al leer texto aparece “… text has been truncated due to evaluation version limitation”?**

Sin una licencia, Aspose.Slides devuelve solo los primeros cinco caracteres de cualquier texto más largo que leas, como `textFrame.text`, seguido de este aviso. El texto que escribas se guarda completo. Aplica una licencia como se describe en [Licenciamiento](/slides/es/nodejs-net/licensing/) para leer el texto completo.