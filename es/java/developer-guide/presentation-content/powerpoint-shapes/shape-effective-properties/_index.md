---
title: Obtener propiedades efectivas de formas de presentaciones en Java
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luz
- bisel de forma
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides for Java calcula y aplica propiedades efectivas de forma para una renderización precisa de PowerPoint."
---
## **Resumen**

Este tema explica la diferencia entre propiedades **locales** y **efectivas**. Los valores locales son valores que se establecen directamente en un nivel de formato específico, como:

1. Propiedades de porción en una diapositiva.
1. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción tiene uno.
1. Configuraciones de texto globales en una presentación.

Los valores locales pueden definirse u omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final "tal como se muestra", resuelve la cadena de herencia y devuelve valores **efectivos**. Puede obtenerlos llamando al método `getEffective` del objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Supone que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAutoShape) con un marco de texto y al menos una porción.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Los datos de formato efectivo representan el formato calculado actual después de aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPortionFormatEffectiveData), pueden almacenarse en caché internamente. Llamar a `getEffective` de nuevo después de cambiar el formato padre o heredado puede refrescar los datos en caché, y un objeto obtenido previamente puede ya no representar el estado anterior. Si necesita conservar los valores efectivos para reutilizarlos más tarde, copie las propiedades necesarias, como la altura de fuente, el color de relleno, el estilo de fuente o la alineación, en su propio objeto de datos.
{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides le permite obtener las propiedades efectivas de una cámara. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ICameraEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de la cámara. Una instancia de [ICameraEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ICameraEffectiveData) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IThreeDFormatEffectiveData), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/IThreeDFormat).

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas de la cámara. Supone que la primera forma de la primera diapositiva tiene formato 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un rig de luz**

Aspose.Slides le permite obtener las propiedades efectivas de un rig de luz. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ILightRigEffectiveData) representa un objeto inmutable que contiene propiedades efectivas del rig de luz. Una instancia de [ILightRigEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ILightRigEffectiveData) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IThreeDFormatEffectiveData), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/IThreeDFormat).

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas del rig de luz. Supone que la primera forma de la primera diapositiva tiene formato 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un bisel de forma**

Aspose.Slides le permite obtener las propiedades efectivas de un bisel de forma. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShapeBevelEffectiveData) representa un objeto inmutable que contiene propiedades efectivas de relieve de cara para una forma. Una instancia de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShapeBevelEffectiveData) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IThreeDFormatEffectiveData), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/IThreeDFormat).

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas del bisel superior de una forma. Supone que la primera forma de la primera diapositiva tiene formato 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un marco de texto**

Con Aspose.Slides, puede obtener las propiedades efectivas de un marco de texto. La interfaz [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITextFrameFormatEffectiveData) contiene propiedades efectivas de formato de marco de texto.

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas de formato de marco de texto. Supone que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAutoShape) con un marco de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un estilo de texto**

Con Aspose.Slides, puede obtener las propiedades efectivas de un estilo de texto. La interfaz [ITextStyleEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITextStyleEffectiveData) contiene propiedades efectivas de estilo de texto.

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas de estilo de texto. Supone que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAutoShape) con un marco de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Obtener el valor efectivo de la altura de fuente**

Con Aspose.Slides, puede obtener la altura de fuente efectiva. El siguiente código muestra cómo la altura de fuente efectiva de una porción cambia después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtener el formato de relleno efectivo para una tabla**

Con Aspose.Slides, puede obtener el formato de relleno efectivo para diferentes partes de una tabla. La interfaz [IFillFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/IFillFormatEffectiveData) contiene propiedades efectivas de formato de relleno. El formato de celda tiene mayor prioridad que el de fila, el de fila tiene mayor prioridad que el de columna y el de columna tiene mayor prioridad que el formato de tabla completa.

Como resultado, se utilizan las propiedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ICellFormatEffectiveData) para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener el formato de relleno efectivo para diferentes partes de la tabla. Supone que la primera forma de la primera diapositiva es un [ITable](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿`getEffective` devuelve una instantánea?**

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden almacenarse en caché internamente. Una llamada posterior a `getEffective` puede recalcular el formato y refrescar los datos en caché, por lo que un objeto obtenido previamente no debería considerarse una instantánea duradera.

**¿Cuándo debería volver a leer las propiedades efectivas?**

Llame a `getEffective` de nuevo después de cambiar el formato local, los estilos padre, el formato del diseño, el formato de la diapositiva maestra o los valores predeterminados a nivel de presentación. La siguiente llamada vuelve a evaluar la jerarquía de formato y devuelve el resultado efectivo actual.

**¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas que ya se han obtenido?**

Sí, pero el cambio se refleja en la siguiente llamada a `getEffective`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden quedar anticuados. Cuando se vuelve a llamar a `getEffective`, Aspose.Slides vuelve a evaluar el árbol de formato y las fuentes, colores, tamaños u otros valores resultantes pueden cambiar.

**¿Puedo modificar valores a través de los objetos de datos efectivos?**

No. Los objetos de datos efectivos exponen valores calculados. Realice los cambios en los objetos de formato local y luego obtenga de nuevo los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo predeterminado, que incluye los valores predeterminados de PowerPoint y Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

**¿A partir de un valor de fuente efectivo, puedo saber qué nivel proporcionó el tamaño o la tipografía?**

No directamente. Los datos efectivos devuelven el valor final. Para encontrar la fuente, compruebe los valores locales en la porción, el párrafo, el marco de texto y los estilos de texto en los niveles de diseño, maestra y presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores efectivos a veces se ven idénticos a los locales?**

Porque el valor local resultó ser el final (no se necesitó herencia de un nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?**

Utilice los datos efectivos cuando necesite el resultado "tal como se muestra" después de aplicar toda la herencia, por ejemplo para alinear colores, sangrías o tamaños. Si necesita conservar esos valores independientemente de cambios posteriores de formato, copie las propiedades necesarias en su propio objeto. Si necesita cambiar el formato en un nivel específico, modifique las propiedades locales y luego, si es necesario, vuelva a leer los datos efectivos para verificar el resultado.