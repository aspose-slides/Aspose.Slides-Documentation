---
title: Obtener propiedades efectivas de forma desde presentaciones en JavaScript
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/nodejs-java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- sistema de iluminación
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a utilizar Aspose.Slides para Node.js mediante Java para distinguir el formato local, heredado y efectivo de formas en presentaciones de PowerPoint."
---
## **Comprender las propiedades locales, heredadas y efectivas**

El formato de PowerPoint puede provenir de varios lugares. El valor almacenado directamente en un objeto es su **valor local**. Si ese valor no está establecido, PowerPoint busca fuentes de formato padre, como el valor predeterminado de un párrafo, un estilo de texto, una diapositiva de diseño o maestra, un tema o los valores predeterminados a nivel de presentación. Esos valores son **valores heredados**. El valor que queda después de que se resuelve toda la jerarquía es el **valor efectivo**—el valor utilizado para renderizar el objeto.

Por ejemplo, una porción de texto puede no definir su propia altura de fuente. Su valor local [getFontHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/#getFontHeight) es entonces `NaN`, lo que significa "no establecido aquí". La porción puede heredar una altura de su párrafo, del estilo de texto predeterminado de la presentación o de otra fuente aplicable. Llamar a [getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/#getEffective) en el formato de la porción devuelve la altura final resuelta.

Utiliza los dos tipos de datos de formato para diferentes propósitos:

- Leer o cambiar un objeto de formato local, como [PortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/), cuando necesites controlar dónde se define un valor.
- Leer los [datos efectivos devueltos por PortionFormat.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/#getEffective) cuando necesites el resultado final renderizado. Los datos efectivos son de solo lectura.

Antes de ejecutar los ejemplos, [instale Aspose.Slides para Node.js vía Java](/slides/es/nodejs-java/installation/).

## **Comparar valores locales, heredados y efectivos**

El siguiente ejemplo completo crea una forma y aplica alturas de fuente a nivel de presentación, párrafo y porción. Cada paso imprime los valores definidos en esos niveles y el valor efectivo resultante para la misma porción de texto. También muestra por qué los datos efectivos deben leerse nuevamente después de los cambios de formato.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Leer los datos efectivos después de los cambios anteriores.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Definir valores heredados en dos niveles diferentes.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Un valor local en la porción sobrescribe ambos valores heredados.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Cambiar un valor heredado no sobrescribe un valor local existente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Borrar el valor local. La porción vuelve a heredar del párrafo.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Borrar el valor del párrafo. El valor predeterminado de la presentación proporciona ahora el resultado.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La prioridad en este ejemplo es el formato local de la porción, luego el formato del párrafo, y después el predeterminado de la presentación. Otros objetos pueden tener cadenas de herencia diferentes, pero el principio es el mismo: un valor explícito más específico prevalece, y [getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/#getEffective) devuelve el resultado final.

## **Obtener propiedades de texto efectivas**

El formato de texto se divide entre varios objetos:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/#getEffective) resuelve propiedades del marco de texto como márgenes, anclaje, ajuste automático y dirección vertical del texto.
- [TextStyle.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textstyle/#getEffective) resuelve el formato de párrafo para cada nivel de estilo de texto.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/#getEffective) resuelve propiedades del párrafo como alineación, sangría y viñetas.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/#getEffective) resuelve propiedades de carácter como altura de fuente, tipografía, color, negrita y cursiva.

Para el siguiente ejemplo, `text-formatting.pptx` debe contener al menos una diapositiva y una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) con un marco de texto no vacío. La AutoShape puede aparecer en cualquier posición de la colección de formas; el código busca un objeto adecuado y lo valida antes de usarlo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades 3D efectivas**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getEffective) devuelve un objeto de datos efectivo que agrupa todas las configuraciones 3D resueltas. Sus métodos [getCamera](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getBevelTop) y [getBevelBottom](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/#getBevelBottom) exponen los datos efectivos correspondientes. Leer estos ajustes relacionados juntos facilita la comprensión de la apariencia 3D final de una forma.

Para este ejemplo, `shape-3d.pptx` debe contener al menos una forma en su primera diapositiva. Aplique ajustes de cámara 3D, iluminación o bisel a esa forma si desea que la salida contenga valores diferentes a los predeterminados.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Obtener formato de tabla efectivo**

El formato de tabla puede provenir del estilo de tabla y de los formatos aplicados a toda la tabla, a una columna, a una fila o a una celda individual. Ante conflictos entre rellenos definidos explícitamente, la prioridad es celda, fila, columna y luego tabla completa. El formato efectivo de una celda es el formato final utilizado para dibujar esa celda.

Para este ejemplo, `table-formatting.pptx` debe contener al menos una tabla en su primera diapositiva. La tabla debe tener al menos una fila y una columna. El código busca una [Table](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/table/) en lugar de asumir que `getShapes().get_Item(0)` es una tabla.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Si necesita el color en lugar de solo el tipo de relleno, primero compruebe el [getFillType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fillformat/#getFillType) efectivo, y luego lea el método que corresponde a ese tipo—por ejemplo, [getSolidFillColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) para un relleno sólido.

## **Volver a leer los datos efectivos después de los cambios**

Los datos efectivos describen la jerarquía de formato en el momento en que se resuelve. Llame a `getEffective` de nuevo después de cambiar cualquier elemento que pueda participar en esa jerarquía, incluyendo:

- el formato local del objeto;
- los valores predeterminados de párrafo o marco de texto;
- un estilo de tabla, tabla, columna, fila o formato de celda;
- el formato de diseño o diapositiva maestra;
- los datos del tema o los valores predeterminados a nivel de presentación;
- el diseño o la maestra asignados a una diapositiva.

No mantenga un objeto de datos efectivo como una instantánea permanente. Aspose.Slides puede almacenar en caché algunos datos efectivos internamente, y una llamada posterior a `getEffective` puede refrescar esos datos. Si necesita comparar valores antes y después de un cambio, copie los valores escalares que necesite—como la altura de fuente, color, alineación o ancho del bisel—en sus propias variables antes de realizar el cambio.

Para cambiar un valor, actualice el objeto de formato local correspondiente y luego llame a `getEffective` para verificar el resultado. Los objetos de datos efectivos son de solo lectura.

## **Preguntas frecuentes**

**¿Cómo puedo saber qué nivel proporcionó un valor efectivo?**

Los datos efectivos contienen el valor final, no su origen. Inspeccione los objetos locales aplicables desde el nivel más específico hacia afuera. Para texto, esto puede incluir la porción, el párrafo, el marco de texto, el diseño, la maestra, el tema y los valores predeterminados de la presentación. Los valores indefinidos como `NaN` o `null` indican que la búsqueda continúa en otro nivel.

**¿Qué ocurre cuando ningún nivel define una propiedad?**

Aspose.Slides resuelve el valor predeterminado apropiado de PowerPoint o de la biblioteca. Ese valor resuelto aparece en los datos efectivos aunque ningún objeto local lo defina explícitamente.

**¿Por qué a veces un valor efectivo es igual al valor local?**

El valor local ganó el cálculo de herencia. Esto es esperable cuando la propiedad está explícitamente establecida en el objeto y ninguna regla más específica la sobrescribe.

**¿Cuándo debo usar datos locales en lugar de datos efectivos?**

Use datos locales para inspeccionar o editar un nivel de formato específico. Use datos efectivos cuando necesite la apariencia final tras la herencia, reglas de tema y estilos aplicables. El [ejemplo completo de comparación](#compare-local-inherited-and-effective-values) demuestra ambos en el mismo flujo de trabajo.