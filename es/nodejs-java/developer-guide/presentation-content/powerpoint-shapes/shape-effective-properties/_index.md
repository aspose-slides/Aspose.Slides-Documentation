---
title: Obtener propiedades efectivas de forma de presentaciones en JavaScript
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/nodejs-java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luz
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
description: "Descubra cómo Aspose.Slides para Node.js mediante Java calcula y aplica propiedades efectivas de forma para una representación precisa de PowerPoint."
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En las propiedades de porción en la diapositiva de la porción;
1. En el estilo de texto de forma prototipo en la diapositiva de diseño o maestra (si la forma del marco de texto de la porción tiene uno);
1. En la configuración global de texto de la presentación;

esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden definirse o omitirse. Pero cuando una aplicación necesita saber cómo debe verse la porción, utiliza los valores **efectivos**. Puedes obtener valores efectivos mediante el método **getEffective()** del formato local.

Este fragmento de código muestra cómo obtener valores efectivos:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
    var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    var effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtención de propiedades efectivas de la cámara**
Aspose.Slides para Node.js mediante Java permite a los desarrolladores obtener propiedades efectivas de la cámara. Con este fin, se añadió la clase **CameraEffectiveData** a Aspose.Slides. La clase **CameraEffectiveData** representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la clase **CameraEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de [valores efectivos](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades efectivas de la cámara:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective camera properties =");
    console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
    console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtención de propiedades efectivas del Light Rig**
Aspose.Slides para Node.js mediante Java permite a los desarrolladores obtener propiedades efectivas del Light Rig. Con este fin, se añadió la clase **LightRigEffectiveData** a Aspose.Slides. La clase **LightRigEffectiveData** representa un objeto inmutable que contiene propiedades efectivas del rig de luz. Una instancia de la clase **LightRigEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de [valores efectivos](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades efectivas del Light Rig:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective light rig properties =");
    console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
    console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtención de propiedades efectivas de la forma biselada**
Aspose.Slides para Node.js mediante Java permite a los desarrolladores obtener propiedades efectivas de la forma biselada. Con este fin, se añadió la clase **ShapeBevelEffectiveData** a Aspose.Slides. La clase **ShapeBevelEffectiveData** representa un objeto inmutable que contiene propiedades efectivas del relieve de la cara de la forma. Una instancia de la clase **ShapeBevelEffectiveData** se usa como parte de la clase **ThreeDFormatEffectiveData**, que es un par de [valores efectivos](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades efectivas de la forma biselada:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtención de propiedades efectivas de un marco de texto**
Usando Aspose.Slides para Node.js mediante Java, puedes obtener propiedades efectivas de un marco de texto. Con este fin, se añadió la clase **TextFrameFormatEffectiveData** a Aspose.Slides. Contiene propiedades de formato efectivas del marco de texto.

Este fragmento de código muestra cómo obtener propiedades de formato efectivas del marco de texto:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
    console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    console.log("Margins");
    console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
    console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
    console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtención de propiedades efectivas de un estilo de texto**
Usando Aspose.Slides para Node.js mediante Java, puedes obtener propiedades efectivas del estilo de texto. Con este fin, se añadió la clase **TextStyleEffectiveData** a Aspose.Slides. Contiene propiedades efectivas del estilo de texto.

Este fragmento de código muestra cómo obtener propiedades efectivas del estilo de texto:
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    for (var i = 0; i <= 8; i++) {
        var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        console.log(("= Effective paragraph formatting for style level #" + i) + " =");
        console.log("Depth: " + effectiveStyleLevel.getDepth());
        console.log("Indent: " + effectiveStyleLevel.getIndent());
        console.log("Alignment: " + effectiveStyleLevel.getAlignment());
        console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtención del valor efectivo de la altura de fuente**
Usando Aspose.Slides para Node.js mediante Java, puedes obtener propiedades efectivas de la altura de fuente. Aquí proporcionamos un código que muestra cómo cambia el valor efectivo de la altura de fuente de la porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
    var portion0 = new aspose.slides.Portion("Sample text with first portion");
    var portion1 = new aspose.slides.Portion(" and second portion.");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    console.log("Effective font height after setting entire presentation default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtención del formato de relleno efectivo para tablas**
Usando Aspose.Slides para Node.js mediante Java, puedes obtener el formato de relleno efectivo para distintas partes lógicas de una tabla. Con este fin, se añadió la clase **CellFormatEffectiveData** a Aspose.Slides. Contiene propiedades de formato de relleno efectivas. Ten en cuenta lo siguiente: el formato de celda siempre tiene prioridad sobre el formato de fila; la fila tiene prioridad sobre la columna; y la columna tiene prioridad sobre toda la tabla.
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var tableFormatEffective = tbl.getTableFormat().getEffective();
    var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
    var tableFillFormatEffective = tableFormatEffective.getFillFormat();
    var rowFillFormatEffective = rowFormatEffective.getFillFormat();
    var columnFillFormatEffective = columnFormatEffective.getFillFormat();
    var cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**How can I tell that I got a "snapshot" rather than a "live object," and when should I read effective properties again?**

Los objetos EffectiveData son instantáneas inmutables de los valores calculados en el momento de la llamada. Si cambias la configuración local o heredada de la forma, vuelve a obtener los datos efectivos para obtener los valores actualizados.

**Does changing the layout/master slide affect effective properties that have already been retrieved?**

Sí, pero solo después de volver a leerlos. Un objeto EffectiveData ya obtenido no se actualiza por sí mismo; solicítalo nuevamente después de cambiar el diseño o la diapositiva maestra.

**Can I modify values through EffectiveData?**

No. EffectiveData es de solo lectura. Realiza los cambios en los objetos de formato local (forma/texto/3D, etc.) y luego vuelve a obtener los valores efectivos.

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

El valor efectivo se determina mediante el mecanismo predeterminado (valores por defecto de PowerPoint/Aspose.Slides). Ese valor resuelto pasa a formar parte de la instantánea EffectiveData.

**From an effective font value, can I tell which level provided the size or typeface?**

No directamente. EffectiveData devuelve el valor final. Para encontrar el origen, revisa los valores locales en la porción/párrafo/marco de texto y los estilos de texto en el diseño/maestra/presentación para ver dónde aparece la primera definición explícita.

**Why do EffectiveData values sometimes look identical to the local ones?**

Porque el valor local resultó ser el final (no se necesitó herencia de un nivel superior). En esos casos, el valor efectivo coincide con el local.

**When should I use effective properties, and when should I work only with local ones?**

Usa EffectiveData cuando necesites el resultado “como se renderiza” después de aplicar toda la herencia (p. ej., para alinear colores, sangrías o tamaños). Si necesitas cambiar el formato en un nivel específico, modifica las propiedades locales y, si es necesario, vuelve a leer EffectiveData para verificar el resultado.