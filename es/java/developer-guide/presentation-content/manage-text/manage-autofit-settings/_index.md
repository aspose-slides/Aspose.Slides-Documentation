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
- encoger texto
- envolver texto
- redimensionar forma
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprende a gestionar la configuración de AutoFit en Aspose.Slides para Java para optimizar la visualización del texto en tus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

De forma predeterminada, cuando añades un cuadro de texto, Microsoft PowerPoint utiliza la configuración **Resize shape to fix text** para el cuadro de texto: redimensiona automáticamente el cuadro de texto para que su contenido siempre quepa dentro de él. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—incrementa su altura—para permitir que contenga más texto.  
* Cuando el texto del cuadro se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuye su altura—para eliminar el espacio sobrante.  

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de ajuste automático (autofit) de un cuadro de texto:  

* **Do not Autofit**  
* **Shrink text on overflow**  
* **Resize shape to fit text**  
* **Wrap text in shape.**  

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java ofrece opciones similares—algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)—que permiten controlar el comportamiento de autofit de los cuadros de texto en presentaciones. 

## **Resize Shape to Fit Text**

Si deseas que el texto de una caja siempre quepa dentro de esa caja después de modificarlo, debes usar la opción **Resize shape to fix text**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `Shape`.  

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código Java muestra cómo especificar que un texto debe ajustarse siempre a su caja en una presentación de PowerPoint:
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


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (incrementará su altura) para asegurar que todo el texto quepa en él. Si el texto se acorta, ocurrirá lo inverso.  

## **Do Not Autofit**

Si deseas que un cuadro de texto o forma conserve sus dimensiones sin importar los cambios realizados en el texto que contiene, debes usar la opción **Do not Autofit**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `None`.  

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código Java muestra cómo especificar que un cuadro de texto debe conservar siempre sus dimensiones en una presentación de PowerPoint:
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


Cuando el texto se vuelve demasiado largo para su caja, se desborda.  

## **Shrink Text on Overflow**

Si un texto se vuelve demasiado largo para su caja, mediante la opción **Shrink text on overflow** puedes especificar que el tamaño y el espaciado del texto deben reducirse para que quepan dentro de la caja. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `Normal`.  

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Java muestra cómo especificar que un texto debe encogerse al desbordarse en una presentación de PowerPoint:
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

Cuando se usa la opción **Shrink text on overflow**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su caja.  

{{% /alert %}}

## **Wrap Text**

Si deseas que el texto dentro de una forma se ajuste (envuelva) dentro de esa forma cuando el texto supera el borde de la forma (solo en ancho), debes usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debes establecer la propiedad [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) en `true`.  

Este código Java muestra cómo usar la configuración Wrap Text en una presentación de PowerPoint:
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

Si estableces la propiedad `WrapText` en `False` para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.  

{{% /alert %}}

## **FAQ**

**¿Los márgenes internos del marco de texto afectan a AutoFit?**

Sí. El relleno (márgenes internos) reduce el área usable para el texto, por lo que AutoFit se activará antes—encogiendo la fuente o redimensionando la forma con mayor rapidez. Revisa y ajusta los márgenes antes de afinar AutoFit.  

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen en su lugar, y AutoFit adapta el tamaño de fuente y el espaciado alrededor de ellos. Eliminar saltos innecesarios suele reducir la agresividad con la que AutoFit necesita encoger el texto.  

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifos diferentes modifica el ancho/alto del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuente, vuelve a comprobar las diapositivas.