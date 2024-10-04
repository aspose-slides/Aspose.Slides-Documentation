---
title: Administrar Configuraciones de Autofit
type: docs
weight: 30
url: /net/manage-autofit-settings/
keywords: "Textbox, Autofit, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Establecer las configuraciones de autofit para el cuadro de texto en PowerPoint en C# o .NET"
---

Por defecto, cuando agregas un cuadro de texto, Microsoft PowerPoint utiliza la configuración de **Redimensionar forma para ajustar texto** para el cuadro de texto; automáticamente redimensiona el cuadro de texto para asegurarse de que su texto siempre quepa en él.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Cuando el texto en el cuadro de texto se vuelve más largo o más grande, PowerPoint automáticamente agranda el cuadro de texto—incrementa su altura—para permitir que contenga más texto.
* Cuando el texto en el cuadro de texto se vuelve más corto o más pequeño, PowerPoint automáticamente reduce el cuadro de texto—disminuye su altura—para eliminar el espacio redundante.

En PowerPoint, estos son los 4 parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto:

* **No Autofit**
* **Reducir texto en desbordamiento**
* **Redimensionar forma para ajustar texto**
* **Ajustar texto en la forma.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides para .NET proporciona opciones similares—algunas propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—que te permiten controlar el comportamiento de autofit para cuadros de texto en presentaciones.

## **Redimensionar Forma para Ajustar Texto**

Si deseas que el texto en un cuadro siempre quepa en ese cuadro después de realizar cambios en el texto, debes utilizar la opción **Redimensionar forma para ajustar texto**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) a `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código en C# te muestra cómo especificar que un texto debe siempre ajustarse a su cuadro en una presentación de PowerPoint:

```c#
 using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumento en altura) para asegurar que todo el texto quepa en él. Si el texto se vuelve más corto, ocurre lo contrario.

## **No Autofit**

Si deseas que un cuadro de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debes utilizar la opción **No Autofit**. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) a `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código en C# te muestra cómo especificar que un cuadro de texto debe siempre mantener sus dimensiones en una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Cuando el texto se vuelve demasiado largo para su cuadro, se desborda.

## **Reducir Texto en Desbordamiento**

Si un texto se vuelve demasiado largo para su cuadro, a través de la opción **Reducir texto en desbordamiento**, puedes especificar que el tamaño y el espaciado del texto deben reducirse para que quepan en su cuadro. Para especificar esta configuración, establece la propiedad [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) a `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código en C# te muestra cómo especificar que un texto debe comprimirse en desbordamiento en una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Información" color="info" %}}

Cuando se utiliza la opción **Reducir texto en desbordamiento**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro.

{{% /alert %}}

## **Ajustar Texto**

Si deseas que el texto en una forma se ajuste dentro de esa forma cuando el texto exceda el borde de la forma (solo ancho), debes utilizar el parámetro **Ajustar texto en la forma**. Para especificar esta configuración, debes establecer la propiedad [WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) (de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) a `true`.

Este código en C# te muestra cómo usar la configuración Ajustar Texto en una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Nota" color="warning" %}}

Si estableces la propiedad `WrapText` como `False` para una forma, cuando el texto dentro de la forma se vuelva más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.

{{% /alert %}}