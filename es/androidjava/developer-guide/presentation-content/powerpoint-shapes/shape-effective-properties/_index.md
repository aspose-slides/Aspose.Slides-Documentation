---
title: Propiedades Efectivas de Forma
type: docs
weight: 50
url: /es/androidjava/shape-effective-properties/
---

En este tema, discutiremos propiedades **efectivas** y **locales**. Cuando establecemos valores directamente en estos niveles

1. En propiedades de porción en la diapositiva de la porción;
1. En estilo de texto de forma de prototipo en la diapositiva de diseño o maestra (si la forma de marco de texto de la porción tiene uno);
1. En configuraciones de texto global de la presentación;

esos valores se llaman valores **locales**. En cualquier nivel, los valores **locales** pueden ser definidos u omitidos. Pero cuando una aplicación necesita saber cómo debería verse la porción, utiliza valores **efectivos**. Puedes obtener valores efectivos utilizando el método **getEffective()** del formato local.

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
Aspose.Slides para Android a través de Java permite a los desarrolladores obtener propiedades efectivas de la cámara. Para este propósito, se agregó la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) a Aspose.Slides. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de la interfaz [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Este código de muestra muestra cómo obtener propiedades efectivas para la cámara:

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

## **Obteniendo Propiedades Efectivas del Luz Rig**
Aspose.Slides para Android a través de Java permite a los desarrolladores obtener propiedades efectivas del Luz Rig. Para este propósito, se agregó la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) a Aspose.Slides. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) representa un objeto inmutable que contiene propiedades efectivas del luz rig. Una instancia de la interfaz [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Este código de muestra muestra cómo obtener propiedades efectivas del Luz Rig:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Propiedades efectivas del luz rig =");
    System.out.println("Tipo: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Dirección: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Propiedades Efectivas de la Forma Bevel**
Aspose.Slides para Android a través de Java permite a los desarrolladores obtener propiedades efectivas de la Forma Bevel. Para este propósito, se agregó la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) a Aspose.Slides. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) representa un objeto inmutable que contiene propiedades de relieve de cara de la forma. Una instancia de la interfaz [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) se utiliza como parte de la interfaz [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData), que es un par de [valores efectivos](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) para la clase [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat).

Este código de muestra muestra cómo obtener propiedades efectivas para la Forma Bevel:

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
Usando Aspose.Slides para Android a través de Java, puedes obtener propiedades efectivas de un Marco de Texto. Para este propósito, se agregó la interfaz [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) a Aspose.Slides. Contiene propiedades de formato de marco de texto efectivas. 

Este código de muestra te muestra cómo obtener propiedades de formato de marco de texto efectivas:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Tipo de anclaje: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Tipo de autoajuste: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Tipo vertical de texto: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Márgenes");
    System.out.println("   Izquierdo: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Superior: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Derecho: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Inferior: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Propiedades Efectivas de un Estilo de Texto**
Usando Aspose.Slides para Android a través de Java, puedes obtener propiedades efectivas de Estilo de Texto. Para este propósito, se agregó la interfaz [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) a Aspose.Slides. Contiene propiedades efectivas de estilo de texto.

Este código de muestra muestra cómo obtener propiedades efectivas de estilo de texto:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Formato de párrafo efectivo para el nivel de estilo #" + i + " =");

        System.out.println("Profundidad: " + effectiveStyleLevel.getDepth());
        System.out.println("Sangría: " + effectiveStyleLevel.getIndent());
        System.out.println("Alineación: " + effectiveStyleLevel.getAlignment());
        System.out.println("Alineación de fuente: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Valor Efectivo de Altura de Fuente**
Usando Aspose.Slides para Android a través de Java, puedes obtener propiedades efectivas de altura de fuente. Aquí, proporcionamos un código que muestra el valor efectivo de altura de fuente de la porción cambiando después de establecer valores de altura de fuente locales en diferentes niveles de estructura de presentación:

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Texto de muestra con la primera porción");
    IPortion portion1 = new Portion(" y segunda porción.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Altura de fuente efectiva justo después de la creación:");
    System.out.println("Porción #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Porción #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Altura de fuente efectiva después de establecer la altura de fuente predeterminada de la presentación:");
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

    pres.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obteniendo Formato de Relleno Efectivo para Tabla**
Usando Aspose.Slides para Android a través de Java, puedes obtener formato de relleno efectivo para diferentes partes lógicas de la tabla. Para este propósito, se agregó la interfaz [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) en Aspose.Slides. Contiene propiedades de formato de relleno efectivas. Tenga en cuenta esto: el formato de celda siempre tiene prioridad sobre el formato de fila; la fila tiene prioridad sobre la columna; y la columna tiene prioridad sobre toda la tabla.

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