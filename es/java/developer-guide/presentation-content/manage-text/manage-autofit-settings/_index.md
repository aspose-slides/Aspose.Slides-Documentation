---
title: Gestionar la Configuración de Autofit
type: docs
weight: 30
url: /java/manage-autofit-settings/
keywords: "Textbox, Autofit, presentación de PowerPoint, Java, Aspose.Slides para Java"
description: "Establecer la configuración de autofit para el cuadro de texto en PowerPoint en Java"
---

Por defecto, cuando añades un cuadro de texto, Microsoft PowerPoint utiliza la configuración de **Cambiar el tamaño de la forma para ajustar el texto** para el cuadro de texto: automáticamente ajusta el tamaño del cuadro de texto para asegurar que su texto siempre quepa en él. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto en el cuadro de texto se vuelve más largo o más grande, PowerPoint automáticamente amplía el cuadro de texto—aumenta su altura—para permitirle contener más texto. 
* Cuando el texto en el cuadro de texto se vuelve más corto o más pequeño, PowerPoint automáticamente reduce el cuadro de texto—disminuye su altura—para deshacerse del espacio redundante. 

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto: 

* **No ajustar automáticamente**
* **Reducir texto en desbordamiento**
* **Cambiar el tamaño de la forma para ajustar el texto**
* **Ajustar texto en la forma.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides para Java proporciona opciones similares—algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)—que te permiten controlar el comportamiento de autofit para cuadros de texto en presentaciones. 

## **Cambiar el Tamaño de la Forma para Ajustar el Texto**

Si deseas que el texto en un cuadro siempre ajuste dentro de ese cuadro después de realizar cambios en el texto, debes usar la opción **Cambiar el tamaño de la forma para ajustar el texto**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código Java te muestra cómo especificar que un texto siempre debe ajustar dentro de su cuadro en una presentación de PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumento de altura) para asegurar que todo el texto quepa en él. Si el texto se vuelve más corto, ocurre lo contrario. 

## **No Ajustar Automáticamente**

Si deseas que un cuadro de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debes usar la opción **No ajustar automáticamente**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código Java te muestra cómo especificar que un cuadro de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cuando el texto se vuelve demasiado largo para su cuadro, se desborda. 

## **Reducir Texto en Desbordamiento**

Si un texto se vuelve demasiado largo para su cuadro, a través de la opción **Reducir texto en desbordamiento**, puedes especificar que el tamaño y el espaciado del texto deben reducirse para ajustarse en su cuadro. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Java te muestra cómo especificar que un texto debe reducirse en desbordamiento en una presentación de PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Cuando se utiliza la opción **Reducir texto en desbordamiento**, la configuración solo se aplica cuando el texto se vuelve demasiado largo para su cuadro. 

{{% /alert %}}

## **Ajustar Texto**

Si deseas que el texto en una forma se ajuste dentro de esa forma cuando el texto sobrepase el borde de la forma (solo ancho), debes usar el parámetro **Ajustar texto en la forma**. Para especificar esta configuración, debes establecer la propiedad [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `true`. 

Este código Java te muestra cómo utilizar la configuración Ajustar Texto en una presentación de PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 

Si estableces la propiedad `WrapText` en `False` para una forma, cuando el texto dentro de la forma se vuelva más largo que el ancho de la forma, el texto se extenderá más allá de los bordes de la forma en una sola línea. 

{{% /alert %}}