---
title: Propiedades Efectivas de Formas
type: docs
weight: 50
url: /java/shape-effective-properties/
---

En este tema, discutiremos las propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En propiedades de porciones en la diapositiva de la porción;
1. En el estilo de texto de forma prototipo en la diapositiva maestra o de diseño (si la forma del marco de texto de la porción tiene uno);
1. En configuraciones de texto global de la presentación;

esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden definirse u omitirse. Pero cuando una aplicación necesita saber cómo debería verse la porción, utiliza valores **efectivos**. Puedes obtener valores efectivos utilizando el método **getEffective()** del formato local.

Este código de muestra te muestra cómo obtener valores efectivos:

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

## **Obteniendo Propiedades Efectivas de la Cámara**
Aspose.Slides para Java permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este propósito, se agregó la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) a Aspose.Slides. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Este código de muestra te muestra cómo obtener propiedades efectivas para la cámara:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propiedades efectivas de la cámara =");
    System.out.println("Tipo: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Campo de visión: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Propiedades Efectivas de la Luz Rig**
Aspose.Slides para Java permite a los desarrolladores obtener propiedades efectivas de la Luz Rig. Para este propósito, se agregó la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) a Aspose.Slides. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de la luz rig. Una instancia de la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Este código de muestra te muestra cómo obtener propiedades efectivas de la Luz Rig:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propiedades efectivas de la luz rig =");
    System.out.println("Tipo: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Dirección: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Propiedades Efectivas de la Forma Bevel**
Aspose.Slides para Java permite a los desarrolladores obtener propiedades efectivas de la Forma Bevel. Para este propósito, se agregó la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) a Aspose.Slides. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) representa un objeto inmutable que contiene propiedades efectivas del relieve de la cara de la forma. Una instancia de la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)), que es un par de [valores efectivos](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat).

Este código de muestra te muestra cómo obtener propiedades efectivas para la Forma Bevel:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propiedades efectivas del relieve de la cara superior de la forma =");
    System.out.println("Tipo: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Ancho: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Altura: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Propiedades Efectivas de un Marco de Texto**
Usando Aspose.Slides para Java, puedes obtener propiedades efectivas de un Marco de Texto. Para este propósito, se agregó la interfaz [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) a Aspose.Slides. Contiene propiedades efectivas de formato de marco de texto.

Este código de muestra te muestra cómo obtener propiedades de formato de marco de texto efectivas:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Tipo de anclaje: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Tipo de ajuste automático: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Tipo de texto vertical: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Márgenes");
    System.out.println("   Izquierda: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Arriba: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Derecha: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Abajo: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Propiedades Efectivas de un Estilo de Texto**
Usando Aspose.Slides para Java, puedes obtener propiedades efectivas de un Estilo de Texto. Para este propósito, se agregó la interfaz [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) a Aspose.Slides. Contiene propiedades efectivas del estilo de texto.

Este código de muestra te muestra cómo obtener propiedades efectivas del estilo de texto:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Formateo de párrafo efectivo para el nivel de estilo #" + i + " =");

        System.out.println("Profundidad: " + effectiveStyleLevel.getDepth());
        System.out.println("Sangría: " + effectiveStyleLevel.getIndent());
        System.out.println("Alineación: " + effectiveStyleLevel.getAlignment());
        System.out.println("Alineación de fuente: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo el Valor Efectivo de Altura de Fuente**
Usando Aspose.Slides para Java, puedes obtener propiedades efectivas de la Altura de la Fuente. Aquí, estamos proporcionando un código que muestra el valor efectivo de altura de fuente de la porción que cambia después de que se establecen valores de altura de fuente locales en diferentes niveles de la estructura de presentación:

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Texto de ejemplo con primera porción");
    IPortion portion1 = new Portion(" y segunda porción.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Altura de fuente efectiva justo después de la creación:");
    System.out.println("Porción #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Porción #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Altura de fuente efectiva después de establecer la altura de fuente predeterminada de toda la presentación:");
    System.out.println("Porción #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Porción #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Altura de fuente efectiva después de establecer la altura de fuente predeterminada del párrafo:");
    System.out.println("Porción #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Porción #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Altura de fuente efectiva después de establecer la altura de fuente de la porción #0:");
    System.out.println("Porción #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Porción #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Altura de fuente efectiva después de establecer la altura de fuente de la porción #1:");
    System.out.println("Porción #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Porción #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Formato de Relleno Efectivo para Tabla**
Usando Aspose.Slides para Java, puedes obtener el formato de relleno efectivo para diferentes partes lógicas de una tabla. Para este propósito, se agregó la interfaz [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) a Aspose.Slides. Contiene propiedades de formato de relleno efectivas. Ten en cuenta esto: el formato de celda siempre tiene prioridad sobre el formato de fila; la fila tiene prioridad sobre la columna; y la columna tiene prioridad sobre toda la tabla.

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