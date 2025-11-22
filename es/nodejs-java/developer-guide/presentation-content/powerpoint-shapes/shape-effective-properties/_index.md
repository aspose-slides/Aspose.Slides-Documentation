---
title: Propiedades Efectivas de Forma
type: docs
weight: 50
url: /es/nodejs-java/shape-effective-properties/
---

En este tema, analizaremos las propiedades **effective** y **local**. Cuando establecemos valores directamente en estos niveles

1. En las propiedades de la porción en la diapositiva de la porción;
1. En el estilo de texto de forma prototipo en la diapositiva de diseño o maestra (si la forma del marco de texto de la porción tiene uno);
1. En la configuración global de texto de la presentación;

esos valores se denominan valores **local**. En cualquier nivel, los valores **local** pueden definirse u omitirse. Pero cuando una aplicación necesita saber cómo debe verse la porción, utiliza los valores **effective**. Puede obtener los valores **effective** usando el método **getEffective()** del formato local.

Este fragmento de código muestra cómo obtener los valores **effective**:
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


## **Obtención de propiedades **effective** de la cámara**
Aspose.Slides for Node.js via Java permite a los desarrolladores obtener propiedades **effective** de la cámara. Para este fin, se añadió la clase [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) a Aspose.Slides. La clase [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) representa un objeto inmutable que contiene propiedades **effective** de la cámara. Una instancia de la clase [**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) se usa como parte de la clase [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData), que es un par de [valores **effective**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [**ThreeDFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades **effective** para la cámara:
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


## **Obtención de propiedades **effective** del sistema de iluminación**
Aspose.Slides for Node.js via Java permite a los desarrolladores obtener propiedades **effective** del Light Rig. Para este fin, se añadió la clase [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) a Aspose.Slides. La clase [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) representa un objeto inmutable que contiene propiedades **effective** del Light Rig. Una instancia de la clase [**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) se usa como parte de la clase [**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData), que es un par de [valores **effective**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [**ThreeDFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades **effective** del Light Rig:
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


## **Obtención de propiedades **effective** de la forma biselada**
Aspose.Slides for Node.js via Java permite a los desarrolladores obtener propiedades **effective** de la forma biselada. Para este fin, se añadió la clase [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) a Aspose.Slides. La clase [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) representa un objeto inmutable que contiene propiedades **effective** del relieve de la forma. Una instancia de la clase [**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) se usa como parte de la clase [**ThreeDFormatEffectiveData**]([**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)), que es un par de [valores **effective**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) para la clase [**ThreeDFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades **effective** para la forma biselada:
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


## **Obtención de propiedades **effective** de un marco de texto**
Usando Aspose.Slides for Node.js via Java, puede obtener propiedades **effective** de un Text Frame. Para este fin, se añadió la clase [**TextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormatEffectiveData) a Aspose.Slides. Contiene propiedades **effective** de formato del marco de texto.

Este fragmento de código muestra cómo obtener propiedades **effective** de formato del marco de texto:
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


## **Obtención de propiedades **effective** de un estilo de texto**
Usando Aspose.Slides for Node.js via Java, puede obtener propiedades **effective** de Text Style. Para este fin, se añadió la clase [**TextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextStyleEffectiveData) a Aspose.Slides. Contiene propiedades **effective** del estilo de texto.

Este fragmento de código muestra cómo obtener propiedades **effective** del estilo de texto:
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


## **Obtención del valor **effective** de la altura de fuente**
Usando Aspose.Slides for Node.js via Java, puede obtener propiedades **effective** de la altura de fuente. Aquí proporcionamos un código que muestra cómo cambia el valor **effective** de la altura de fuente de la porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación:
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


## **Obtención del formato de relleno **effective** para tablas**
Usando Aspose.Slides for Node.js via Java, puede obtener el formato de relleno **effective** para distintas partes lógicas de una tabla. Para este fin, se añadió la clase [**CellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellFormatEffectiveData) a Aspose.Slides. Contiene propiedades **effective** de formato de relleno. Tenga en cuenta lo siguiente: el formato de celda siempre tiene prioridad sobre el formato de fila; la fila tiene prioridad sobre la columna; y la columna tiene prioridad sobre la tabla completa.
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


## **Preguntas frecuentes**

**¿Cómo puedo saber si obtuve una "instantánea" en lugar de un "objeto en vivo", y cuándo debo volver a leer las propiedades **effective**?**

Los objetos EffectiveData son instantáneas inmutables de los valores calculados en el momento de la llamada. Si cambia la configuración local o heredada de la forma, recupere los datos **effective** nuevamente para obtener los valores actualizados.

**¿Cambiar la diapositiva de diseño/maestra afecta a las propiedades **effective** que ya se recuperaron?**

Sí, pero solo después de volver a leerlas. Un objeto EffectiveData ya obtenido no se actualiza por sí mismo; solicítelo nuevamente después de cambiar el diseño o la maestra.

**¿Puedo modificar valores a través de EffectiveData?**

No. EffectiveData es de solo lectura. Realice los cambios en los objetos de formato local (forma/texto/3D, etc.) y luego obtenga nuevamente los valores **effective**.

**¿Qué ocurre si una propiedad no está definida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor **effective** se determina mediante el mecanismo predeterminado (valores predeterminados de PowerPoint/Aspose.Slides). Ese valor resuelto forma parte de la instantánea EffectiveData.

**¿A partir de un valor **effective** de fuente, puedo saber qué nivel proporcionó el tamaño o la tipografía?**

No directamente. EffectiveData devuelve el valor final. Para encontrar la fuente, revise los valores locales en la porción/párrafo/marco de texto y los estilos de texto en el diseño/maestra/presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores EffectiveData a veces se ven idénticos a los locales?**

Porque el valor local resultó ser el final (no se necesitó herencia de nivel superior). En esos casos, el valor **effective** coincide con el local.

**¿Cuándo debo usar propiedades **effective**, y cuándo trabajar solo con las locales?**

Use EffectiveData cuando necesite el resultado "tal como se renderiza" después de aplicar toda la herencia (p. ej., para alinear colores, sangrías o tamaños). Si necesita cambiar el formato en un nivel específico, modifique las propiedades locales y, si es necesario, vuelva a leer EffectiveData para verificar el resultado.