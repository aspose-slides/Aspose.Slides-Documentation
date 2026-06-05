---
title: Obtener propiedades efectivas de forma de presentaciones en Android
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/androidjava/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Android mediante Java calcula y aplica las propiedades efectivas de forma para una renderización precisa de PowerPoint."
---
## **Descripción general**

Este tema explica la diferencia entre propiedades **locales** y **efectivas**. Los valores locales son los que se establecen directamente en un nivel concreto de formato, como:

1. Propiedades de porción en una diapositiva.
1. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción tiene uno.
1. Configuraciones de texto globales en una presentación.

Los valores locales pueden definirse o omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final “tal como se muestra”, resuelve la cadena de herencia y devuelve los valores **efectivos**. Puede obtenerlos llamando al método `getEffective()` sobre el objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Se asume que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) con un marco de texto y al menos una porción.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Los datos de formato efectivo representan el formato calculado actual después de aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportionformateffectivedata/), pueden estar almacenados en caché internamente. Volver a llamar a `getEffective()` después de cambiar el formato heredado o del padre puede actualizar la caché, y un objeto obtenido previamente puede ya no representar el estado anterior. Si necesita conservar valores efectivos para reutilizarlos más tarde, copie las propiedades necesarias, como altura de fuente, color de relleno, estilo de fuente o alineación, en su propio objeto de datos.

{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides permite obtener las propiedades efectivas de una cámara. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icameraeffectivedata/) representa un objeto inmutable que contiene las propiedades efectivas de la cámara. Una instancia de [ICameraEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icameraeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para la cámara. Se asume que la primera forma de la primera diapositiva tiene formato 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un conjunto de luces**

Aspose.Slides permite obtener las propiedades efectivas de un conjunto de luces. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilightrigeffectivedata/) representa un objeto inmutable que contiene las propiedades efectivas del conjunto de luces. Una instancia de [ILightRigEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilightrigeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el conjunto de luces. Se asume que la primera forma de la primera diapositiva tiene formato 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un bisel de forma**

Aspose.Slides permite obtener las propiedades efectivas de un bisel de forma. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapebeveleffectivedata/) representa un objeto inmutable que contiene las propiedades efectivas de relieve de una forma. Una instancia de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapebeveleffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas para el bisel superior de una forma. Se asume que la primera forma de la primera diapositiva tiene formato 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un marco de texto**

Con Aspose.Slides, puede obtener las propiedades efectivas de un marco de texto. La interfaz [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformateffectivedata/) contiene las propiedades efectivas de formato del marco de texto.

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas de formato del marco de texto. Se asume que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) con un marco de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

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
    presentation.dispose();
}
```

## **Obtener propiedades efectivas de un estilo de texto**

Con Aspose.Slides, puede obtener las propiedades efectivas de un estilo de texto. La interfaz [ITextStyleEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextstyleeffectivedata/) contiene las propiedades efectivas del estilo de texto.

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas del estilo de texto. Se asume que la primera forma de la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) con un marco de texto.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Obtener el valor efectivo de la altura de fuente**

Con Aspose.Slides, puede obtener la altura de fuente efectiva. El siguiente código demuestra cómo cambia la altura de fuente efectiva de una porción después de establecer valores locales de altura de fuente en distintos niveles de la estructura de la presentación.

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

Con Aspose.Slides, puede obtener el formato de relleno efectivo para diferentes partes de una tabla. La interfaz [IFillFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifillformateffectivedata/) contiene las propiedades efectivas de formato de relleno. El formato de la celda tiene mayor prioridad que el formato de la fila, el de la fila tiene mayor prioridad que el de la columna, y el de la columna tiene mayor prioridad que el formato de tabla completa.

Como resultado, se utilizan las propiedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icellformateffectivedata/) para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener el formato de relleno efectivo para distintas partes de la tabla. Se asume que la primera forma de la primera diapositiva es un [ITable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿`getEffective()` devuelve una instantánea?**

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden estar almacenados en caché internamente. Una llamada posterior a `getEffective()` puede recalcular el formato y actualizar la caché, por lo que un objeto obtenido previamente no debe considerarse una instantánea duradera.

**¿Cuándo debo volver a leer las propiedades efectivas?**

Llame a `getEffective()` nuevamente después de cambiar el formato local, los estilos del padre, el formato del diseño, el formato de la maestra o los valores predeterminados a nivel de presentación. La siguiente llamada vuelve a evaluar la jerarquía de formato y devuelve el resultado efectivo actual.

**¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas ya obtenidas?**

Sí, pero el cambio se refleja en la siguiente llamada a `getEffective()`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden quedar obsoletos. Una vez llamado de nuevo a `getEffective()`, Aspose.Slides reevalúa el árbol de formato y los valores resultantes de fuentes, colores, tamaños u otros pueden cambiar.

**¿Puedo modificar valores a través de los objetos de datos efectivos?**

No. Los objetos de datos efectivos exponen valores calculados. Realice los cambios en los objetos de formato local y, a continuación, obtenga nuevamente los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo predeterminado, que incluye los valores por defecto de PowerPoint y de Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

**Desde un valor de fuente efectivo, ¿puedo saber qué nivel proporcionó el tamaño o el tipo de letra?**

No directamente. Los datos efectivos devuelven el valor final. Para encontrar la fuente, revise los valores locales en la porción, el párrafo, el marco de texto y los estilos de texto en el diseño, la maestra y la presentación, para ver dónde aparece la primera definición explícita.

**¿Por qué a veces los valores efectivos se ven idénticos a los locales?**

Porque el valor local resultó ser el final (no se necesitó herencia de niveles superiores). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?**

Utilice los datos efectivos cuando necesite el resultado “tal como se muestra” después de aplicar toda la herencia, por ejemplo, para alinear colores, sangrías o tamaños. Si necesita conservar esos valores independientemente de cambios posteriores en el formato, copie las propiedades necesarias en su propio objeto. Si desea modificar el formato en un nivel concreto, cambie las propiedades locales y, si es preciso, lea nuevamente los datos efectivos para verificar el resultado.