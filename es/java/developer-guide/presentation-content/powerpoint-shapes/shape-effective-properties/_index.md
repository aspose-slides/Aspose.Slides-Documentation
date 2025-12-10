---
title: Obtener propiedades efectivas de forma de presentaciones en Java
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luz
- forma de bisel
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides for Java calcula y aplica las propiedades efectivas de forma para una representación precisa de PowerPoint."
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En las propiedades de la porción en la diapositiva de la porción;
1. En el estilo de texto de la forma prototipo en la diapositiva de diseño o maestra (si la forma del marco de texto de la porción tiene uno);
1. En la configuración global de texto de la presentación;

esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden definirse u omitirse. Pero cuando una aplicación necesita saber cómo debe verse la porción, utiliza los valores **efectivos**. Puede obtener valores efectivos usando el método **getEffective()** del formato local.

Este fragmento de código muestra cómo obtener valores efectivos:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener propiedades efectivas de una cámara**
Aspose.Slides for Java permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este propósito, se agregó la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) a Aspose.Slides. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) se usa como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), que es un par de [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades efectivas para la cámara:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener propiedades efectivas de Light Rig**
Aspose.Slides for Java permite a los desarrolladores obtener propiedades efectivas de Light Rig. Para este propósito, se agregó la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) a Aspose.Slides. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de Light Rig. Una instancia de la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) se usa como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), que es un par de [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades efectivas de Light Rig:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener propiedades efectivas de una forma de bisel**
Aspose.Slides for Java permite a los desarrolladores obtener propiedades efectivas de Bevel Shape. Para este propósito, se agregó la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) a Aspose.Slides. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) representa un objeto inmutable que contiene propiedades efectivas del relieve de la cara de la forma. Una instancia de la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) se usa como parte de la interfaz [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)) , que es un par de [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Este fragmento de código muestra cómo obtener propiedades efectivas para la forma de bisel:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener propiedades efectivas de un marco de texto**
Con Aspose.Slides for Java, puede obtener propiedades efectivas de un Marco de Texto. Para este propósito, se agregó la interfaz [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) a Aspose.Slides. Contiene propiedades de formato efectivo del marco de texto.

Este fragmento de código muestra cómo obtener propiedades de formato efectivas del marco de texto:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener propiedades efectivas de un estilo de texto**
Con Aspose.Slides for Java, puede obtener propiedades efectivas de Estilo de Texto. Para este propósito, se agregó la interfaz [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) a Aspose.Slides. Contiene propiedades efectivas de estilo de texto.

Este fragmento de código muestra cómo obtener propiedades efectivas de estilo de texto:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener el valor efectivo de la altura de fuente**
Con Aspose.Slides for Java, puede obtener propiedades efectivas de la altura de fuente. Aquí ofrecemos un código que muestra cómo el valor efectivo de la altura de fuente de la porción cambia después de establecer valores de altura de fuente locales en diferentes niveles de la estructura de la presentación:
```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener el formato de relleno efectivo para una tabla**
Con Aspose.Slides for Java, puede obtener el formato de relleno efectivo para diferentes partes lógicas de una tabla. Para este propósito, se agregó la interfaz [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) en Aspose.Slides. Contiene propiedades de formato de relleno efectivas. Tenga en cuenta lo siguiente: el formato de celda siempre tiene prioridad sobre el formato de fila; la fila tiene prioridad sobre la columna; y la columna tiene prioridad sobre toda la tabla.
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Cómo puedo saber si obtuve una "instantánea" en lugar de un "objeto en vivo", y cuándo debo leer nuevamente las propiedades efectivas?**  
Los objetos EffectiveData son instantáneas inmutables de los valores calculados en el momento de la llamada. Si cambia la configuración local o heredada de la forma, recupere los datos efectivos nuevamente para obtener los valores actualizados.

**¿Cambiar la diapositiva de diseño/maestra afecta las propiedades efectivas que ya se han recuperado?**  
Sí, pero solo después de volver a leerlas. Un objeto EffectiveData ya obtenido no se actualiza solo; solicítelo nuevamente después de cambiar el diseño o la maestra.

**¿Puedo modificar valores a través de EffectiveData?**  
No. EffectiveData es de solo lectura. Realice cambios en los objetos de formato local (forma/texto/3D, etc.) y luego obtenga nuevamente los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**  
El valor efectivo se determina mediante el mecanismo predeterminado (valores predeterminados de PowerPoint/Aspose.Slides). Ese valor resuelto se convierte en parte de la instantánea EffectiveData.

**¿A partir de un valor de fuente efectivo, puedo saber qué nivel proporcionó el tamaño o la tipografía?**  
No directamente. EffectiveData devuelve el valor final. Para encontrar la fuente, revise los valores locales en la porción/párrafo/marco de texto y los estilos de texto en el diseño/maestra/presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores de EffectiveData a veces se ven idénticos a los locales?**  
Porque el valor local resultó ser el final (no se necesitó herencia de niveles superiores). En esos casos, el valor efectivo coincide con el valor local.

**¿Cuándo debo usar propiedades efectivas y cuándo debo trabajar solo con las locales?**  
Use EffectiveData cuando necesita el resultado "tal como se renderiza" después de aplicar toda la herencia (p. ej., para alinear colores, sangrías o tamaños). Si necesita cambiar el formato en un nivel específico, modifique las propiedades locales y, si es necesario, vuelva a leer EffectiveData para verificar el resultado.