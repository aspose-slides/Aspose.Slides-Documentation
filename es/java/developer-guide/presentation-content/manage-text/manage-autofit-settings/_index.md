---
title: Mejora tus presentaciones con AutoFit en Java
linktitle: Configuración de Autofit
type: docs
weight: 30
url: /es/java/manage-autofit-settings/
keywords:
- cuadro de texto
- ajuste automático
- no ajustar automáticamente
- ajustar texto
- reducir texto
- envolver texto
- redimensionar forma
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo gestionar la configuración de AutoFit en Aspose.Slides para Java para optimizar la visualización del texto en sus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

Por defecto, cuando añades un cuadro de texto, Microsoft PowerPoint utiliza la configuración **Resize shape to fix text** para el cuadro de texto: redimensiona automáticamente el cuadro para asegurar que su texto siempre quepa dentro de él. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro de texto se alarga o hace más grande, PowerPoint amplía automáticamente el cuadro —aumenta su altura— para permitir que contenga más texto. 
* Cuando el texto del cuadro de texto se acorta o hace más pequeño, PowerPoint reduce automáticamente el cuadro —disminuye su altura— para eliminar el espacio redundante. 

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java proporciona opciones similares—algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)—que le permiten controlar el comportamiento de autofit para cuadros de texto en presentaciones. 

## **Redimensionar una forma para que se ajuste al texto**

Si desea que el texto en un cuadro siempre quepa dentro de ese cuadro después de realizar cambios en el texto, debe usar la opción **Resize shape to fix text**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) a `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código Java le muestra cómo especificar que un texto siempre debe caber en su cuadro en una presentación de PowerPoint:
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


Si el texto se alarga o hace más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para asegurar que todo el texto quepa. Si el texto se acorta, ocurre lo contrario. 

## **Do Not Autofit**

Si desea que un cuadro de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debe usar la opción **Do not Autofit**. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) a `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código Java le muestra cómo especificar que un cuadro de texto siempre debe mantener sus dimensiones en una presentación de PowerPoint:
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

## **Shrink Text on Overflow**

Si un texto se vuelve demasiado largo para su cuadro, mediante la opción **Shrink text on overflow** puede especificar que el tamaño y el espaciado del texto deben reducirse para que quepan en su cuadro. Para especificar esta configuración, establezca la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) a `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Java le muestra cómo especificar que un texto debe reducirse al desbordarse en una presentación de PowerPoint:
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
Cuando se usa la opción **Shrink text on overflow**, el ajuste se aplica solo cuando el texto se vuelve demasiado largo para su cuadro. 
{{% /alert %}}

## **Wrap Text**

Si desea que el texto en una forma se envuelva dentro de esa forma cuando el texto supera el borde de la forma (solo el ancho), debe usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debe establecer la propiedad [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) a `true`. 

Este código Java le muestra cómo usar la configuración Wrap Text en una presentación de PowerPoint:
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


{{% alert title="Note" color="warning" %}} 
Si establece la propiedad `WrapText` en `False` para una forma, cuando el texto dentro de la forma supera el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea. 
{{% /alert %}}

## **FAQ**

**¿Los márgenes internos del marco de texto afectan al AutoFit?**

Sí. El relleno (márgenes internos) reduce el área usable para el texto, por lo que AutoFit se activará antes, reduciendo la fuente o redimensionando la forma más pronto. Revise y ajuste los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen en su lugar, y AutoFit adapta el tamaño de fuente y el espaciado a su alrededor. Eliminar saltos innecesarios suele reducir la agresividad con la que AutoFit necesita reducir el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifos diferentes cambia el ancho/altura del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuente, vuelva a comprobar las diapositivas.