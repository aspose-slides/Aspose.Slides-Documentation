---
title: Mejore sus presentaciones con AutoFit en .NET
linktitle: Configuración de Autofit
type: docs
weight: 30
url: /es/net/manage-autofit-settings/
keywords:
- cuadro de texto
- ajuste automático
- no ajustar automáticamente
- ajustar texto
- reducir texto
- ajuste de texto
- redimensionar forma
- PowerPoint
- presentación
- C#
- .NET
- Aspose.Slides
description: "Aprenda a gestionar la configuración de AutoFit en Aspose.Slides para .NET para optimizar la visualización del texto en sus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

## **Descripción general**

De forma predeterminada, cuando agrega un cuadro de texto, Microsoft PowerPoint usa la configuración **Resize shape to fit text** para el cuadro de texto; redimensiona automáticamente el cuadro de texto para garantizar que su texto siempre quepa en él.

![Un cuadro de texto en PowerPoint](textbox-in-powerpoint.png)

* Cuando el texto en el cuadro de texto se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro de texto—incrementando su altura—para permitir que contenga más texto.
* Cuando el texto en el cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro de texto—disminuyendo su altura—para eliminar el espacio redundante.

En PowerPoint, estos son los cuatro parámetros u opciones importantes que controlan el comportamiento de autofit para un cuadro de texto:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Opciones de Autofit en PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides para .NET ofrece opciones similares—propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—que le permiten controlar el comportamiento de autofit para los cuadros de texto en presentaciones.

## **Redimensionar forma para ajustar texto**

Si desea que el texto en un cuadro siempre quepa en ese cuadro después de realizar cambios en el texto, debe usar la opción **Resize shape to fit text**. Para especificar esta configuración, establezca la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) a `Shape`.

![Redimensionar forma para ajustar texto](alwaysfit-setting-powerpoint.png)

Este código C# muestra cómo especificar que el texto siempre debe ajustarse a su cuadro en una presentación de PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentando su altura) para garantizar que todo el texto quepa en él. Si el texto se vuelve más corto, ocurre lo contrario.

## **No Autoajustar**

Si desea que un cuadro de texto o una forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debe usar la opción **Do not Autofit**. Para especificar esta configuración, establezca la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) a `None`.

!["Configuración \"Do not Autofit\" en PowerPoint"](donotautofit-setting-powerpoint.png)

Este código C# muestra cómo especificar que un cuadro de texto debe mantener siempre sus dimensiones en una presentación de PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Cuando el texto se vuelve demasiado largo para su cuadro, se desborda.

## **Reducir texto al desbordarse**

Si el texto se vuelve demasiado largo para su cuadro, a través de la opción **Shrink text on overflow** puede especificar que el tamaño y el espaciado del texto deben reducirse para que quepan en su cuadro. Para especificar esta configuración, establezca la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) a `Normal`.

!["Reducir texto al desbordarse" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Este código C# muestra cómo especificar que el texto debe reducirse al desbordarse en una presentación de PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Info" color="info" %}}
Cuando se usa la opción **Shrink text on overflow**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro.
{{% /alert %}}

## **Ajustar texto**

Si desea que el texto en una forma se ajuste dentro de esa forma cuando el texto supera el borde de la forma (solo ancho), debe usar el parámetro **Wrap text in shape**. Para especificar esta configuración, debe establecer la propiedad `WrapText` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) a `NullableBool.True`.

Este código C# muestra cómo usar la configuración Wrap Text en una presentación de PowerPoint:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}} 
Si establece la propiedad `WrapText` en `NullableBool.False` para una forma, cuando el texto dentro de la forma supera el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Afectan los márgenes internos del marco de texto a AutoFit?**

Sí. El relleno (márgenes internos) reduce el área utilizable para el texto, por lo que AutoFit se activará antes—encogiendo la fuente o redimensionando la forma más pronto. Revise y ajuste los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen en su lugar, y AutoFit adapta el tamaño de fuente y el espaciado a su alrededor. Eliminar saltos innecesarios a menudo reduce la agresividad con la que AutoFit necesita encoger el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifos diferentes cambia el ancho/alto del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de línea. Después de cualquier cambio o sustitución de fuente, vuelva a comprobar las diapositivas.