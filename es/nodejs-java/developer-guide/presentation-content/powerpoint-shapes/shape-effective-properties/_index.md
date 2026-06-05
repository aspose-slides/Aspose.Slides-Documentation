---
title: Obtener propiedades efectivas de formas en presentaciones con JavaScript
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/nodejs-java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- bisel de forma
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Node.js mediante Java calcula y aplica propiedades efectivas de forma para una renderización precisa de PowerPoint."
---
## **Descripción general**

Este tema explica la diferencia entre propiedades **locales** y **efectivas**. Los valores locales son valores que se establecen directamente en un nivel de formato específico, como:

1. Propiedades de porción en una diapositiva.
1. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción tiene uno.
1. Configuraciones de texto globales en una presentación.

Los valores locales pueden definirse u omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final “tal como se renderiza”, resuelve la cadena de herencia y devuelve valores **efectivos**. Puedes obtenerlos llamando al método `getEffective` del objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Asume que la primera forma en la primera diapositiva es un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) con un marco de texto y al menos una porción.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Los datos de formato efectivo representan el formato calculado actual después de aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos pueden almacenarse en caché internamente. Llamar a `getEffective` de nuevo después de cambiar el formato padre o heredado puede refrescar la caché, y un objeto obtenido anteriormente puede ya no representar el estado anterior. Si necesitas conservar los valores efectivos para reutilizarlos más tarde, copia las propiedades requeridas, como altura de fuente, color de relleno, estilo de fuente o alineación, en tu propio objeto de datos.
{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides permite obtener propiedades efectivas de una cámara. El objeto de datos de cámara efectiva contiene propiedades de cámara inmutables y se expone a través de los valores efectivos devueltos por [ThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la cámara. Asume que la primera forma en la primera diapositiva tiene formato 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de una Light Rig**

Aspose.Slides permite obtener propiedades efectivas de una Light Rig. El objeto de datos de Light Rig efectivo contiene propiedades de Light Rig inmutables y se expone a través de los valores efectivos devueltos por [ThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la Light Rig. Asume que la primera forma en la primera diapositiva tiene formato 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un bisel de forma**

Aspose.Slides permite obtener propiedades efectivas de un bisel de forma. El objeto de datos de bisel de forma efectivo contiene propiedades inmutables de relieve de caras para una forma y se expone a través de los valores efectivos devueltos por [ThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el bisel superior de una forma. Asume que la primera forma en la primera diapositiva tiene formato 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un marco de texto**

Con Aspose.Slides, puedes obtener propiedades efectivas de un marco de texto. El objeto de datos efectivo devuelto contiene propiedades de formato del marco de texto.

El siguiente fragmento de código muestra cómo obtener propiedades de formato efectivas del marco de texto. Asume que la primera forma en la primera diapositiva es un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) con un marco de texto.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un estilo de texto**

Con Aspose.Slides, puedes obtener propiedades efectivas de un estilo de texto. El objeto de datos efectivo devuelto contiene propiedades de estilo de texto.

El siguiente fragmento de código muestra cómo obtener propiedades efectivas de estilo de texto. Asume que la primera forma en la primera diapositiva es un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) con un marco de texto.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Obtener el valor efectivo de la altura de la fuente**

Con Aspose.Slides, puedes obtener la altura de fuente efectiva. El siguiente código demuestra cómo la altura de fuente efectiva de una porción cambia después de establecer valores locales de altura de fuente en distintos niveles de la estructura de la presentación.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Obtener el formato de relleno efectivo para una tabla**

Con Aspose.Slides, puedes obtener formato de relleno efectivo para diferentes partes de una tabla. El objeto de datos efectivo devuelto contiene propiedades de formato de relleno. El formato de celda tiene mayor prioridad que el de fila, el de fila tiene mayor prioridad que el de columna y el de columna tiene mayor prioridad que el formato de tabla completa.

Como resultado, se utilizan las propiedades de formato de celda efectivas para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener formato de relleno efectivo para diferentes partes de la tabla. Asume que la primera forma en la primera diapositiva es una [Table](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿`getEffective` devuelve una instantánea?**

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden almacenarse en caché internamente. Una llamada subsiguiente a `getEffective` puede recalcular el formato y refrescar la caché, por lo que un objeto obtenido previamente no debe considerarse una instantánea duradera.

**¿Cuándo debo volver a leer las propiedades efectivas?**

Llama a `getEffective` de nuevo después de cambiar el formato local, los estilos padre, el formato de diseño, el formato maestro o los valores predeterminados a nivel de presentación. La siguiente llamada reevalúa la jerarquía de formato y devuelve el resultado efectivo actual.

**¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas ya obtenidas?**

Sí, pero el cambio se refleja en la siguiente llamada a `getEffective`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden estar obsoletos. Una vez que `getEffective` se invoque nuevamente, Aspose.Slides reevalúa el árbol de formato y los tipos de letra, colores, tamaños u otros valores resultantes pueden cambiar.

**¿Puedo modificar valores a través de los objetos de datos efectivos?**

No. Los objetos de datos efectivos exponen valores calculados. Realiza los cambios en los objetos de formato local y, a continuación, vuelve a obtener los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo predeterminado, que incluye los valores por defecto de PowerPoint y Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

**¿A partir de un valor de fuente efectivo, puedo saber qué nivel proporcionó el tamaño o la tipografía?**

No directamente. Los datos efectivos devuelven el valor final. Para descubrir la fuente, revisa los valores locales en la porción, párrafo, marco de texto y estilos de texto en el diseño, maestro y nivel de presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores efectivos a veces se ven idénticos a los locales?**

Porque el valor local resultó ser el final (no fue necesaria herencia de nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?**

Utiliza los datos efectivos cuando necesites el resultado “tal como se renderiza” tras aplicar toda la herencia, por ejemplo para alinear colores, sangrías o tamaños. Si necesitas preservar esos valores independientemente de cambios posteriores en el formato, copia las propiedades requeridas en tu propio objeto. Si necesitas cambiar el formato en un nivel específico, modifica las propiedades locales y, si es necesario, vuelve a leer los datos efectivos para verificar el resultado.