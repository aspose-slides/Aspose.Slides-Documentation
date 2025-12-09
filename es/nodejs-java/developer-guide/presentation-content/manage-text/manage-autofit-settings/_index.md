---
title: "Administrar configuraciones de Autofit"
type: docs
weight: 30
url: /es/nodejs-java/manage-autofit-settings/
keywords: "Cuadro de texto, Autofit, presentación de PowerPoint, Java, Aspose.Slides para Node.js a través de Java"
description: "Establecer la configuración de autofit para cuadro de texto en PowerPoint con JavaScript"
---

Por defecto, cuando añades un cuadro de texto, Microsoft PowerPoint utiliza la configuración **Resize shape to fix text** para el cuadro de texto: redimensiona automáticamente el cuadro de texto para garantizar que su contenido siempre encaje.

![cuadro-de-texto-en-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—incrementa su altura—para permitir que contenga más texto.  
* Cuando el texto del cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuye su altura—para eliminar el espacio redundante.

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![opciones-autofit-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java ofrece opciones similares—algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)—que permiten controlar el comportamiento de autofit para los cuadros de texto en presentaciones.

## **Resize Shape to Fit Text**

Si deseas que el texto de un cuadro siempre encaje en él después de modificarlo, debes usar la opción **Resize shape to fix text**. Para especificar esta configuración, llama al método [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) de la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) con el valor `Shape`.

![ajuste-automatico-powerpoint](alwaysfit-setting-powerpoint.png)

Este código JavaScript muestra cómo especificar que un texto siempre debe encajar en su cuadro en una presentación de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para asegurarse de que todo el texto encaje. Si el texto se vuelve más corto, ocurrirá lo contrario.

## **Do Not Autofit**

Si deseas que un cuadro de texto o una forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debes usar la opción **Do not Autofit**. Para especificar esta configuración, llama al método [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) de la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) con el valor `None`.

![sin-autofit-powerpoint](donotautofit-setting-powerpoint.png)

Este código JavaScript muestra cómo especificar que un cuadro de texto debe conservar siempre sus dimensiones en una presentación de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Cuando el texto se vuelve demasiado largo para su cuadro, se desborda.

## **Shrink Text on Overflow**

Si un texto se vuelve demasiado largo para su cuadro, mediante la opción **Shrink text on overflow** puedes especificar que el tamaño y el espaciado del texto se reduzcan para que quepa dentro del cuadro. Para especificar esta configuración, llama al método [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) de la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) con el valor `Normal`.

![encoger-texto-overflow-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código JavaScript muestra cómo especificar que un texto debe encogerse al desbordarse en una presentación de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
Cuando se utiliza la opción **Shrink text on overflow**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro.
{{% /alert %}}

## **Wrap Text**

Si deseas que el texto de una forma se envuelva dentro de ella cuando el texto supera el borde de la forma (solo el ancho), debes usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debes llamar al método [setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) de la clase [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) con el valor `true`.

Este código JavaScript muestra cómo usar la configuración Wrap Text en una presentación de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}}
Si llamas al método `setWrapText` con el valor `False` para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.
{{% /alert %}}

## **FAQ**

**¿Los márgenes internos del marco de texto afectan a AutoFit?**

Sí. El padding (márgenes internos) reduce el área utilizable para el texto, por lo que AutoFit se activará antes—encogiendo la fuente o redimensionando la forma más pronto. Verifica y ajusta los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen, y AutoFit adapta el tamaño de fuente y el espaciado alrededor de ellos. Eliminar saltos innecesarios suele reducir la agresividad con la que AutoFit necesita encoger el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifos diferentes cambia el ancho/alto del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuente, vuelve a comprobar las diapositivas.