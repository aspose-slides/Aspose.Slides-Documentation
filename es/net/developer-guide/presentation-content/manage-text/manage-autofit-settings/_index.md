---
title: Mejora tus presentaciones con AutoFit en .NET
linktitle: Configuración de Autofit
type: docs
weight: 30
url: /es/net/manage-autofit-settings/
keywords:
- cuadro de texto
- autofit
- no autoajuste
- ajustar texto
- reducir texto
- envolver texto
- redimensionar forma
- PowerPoint
- presentación
- C#
- .NET
- Aspose.Slides
description: "Aprende cómo gestionar la configuración de AutoFit en Aspose.Slides para .NET para optimizar la visualización de texto en tus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

## **Resumen**

Por defecto, cuando añades un cuadro de texto, Microsoft PowerPoint usa la configuración **Redimensionar forma para ajustarse al texto**; redimensiona automáticamente el cuadro de texto para que su contenido siempre quepa.

![Un cuadro de texto en PowerPoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro se vuelve más largo o más grande, PowerPoint amplía automáticamente el cuadro—incrementando su altura—para permitirle contener más texto.
* Cuando el texto del cuadro se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro—disminuyendo su altura—para eliminar el espacio sobrante.

En PowerPoint, estos son los cuatro parámetros u opciones importantes que controlan el comportamiento de ajuste automático para un cuadro de texto:

* **No ajustar automáticamente**
* **Reducir texto en desbordamiento**
* **Redimensionar forma para ajustarse al texto**
* **Ajustar texto en la forma**

![Opciones de ajuste automático en PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET proporciona opciones similares—propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—que permiten controlar el comportamiento de ajuste automático para cuadros de texto en presentaciones.

## **Redimensionar una forma para ajustarse al texto**

Si deseas que el texto de un recuadro siempre quepa dentro de ese recuadro después de modificarlo, debes usar la opción **Redimensionar forma para ajustarse al texto**. Para especificar esta configuración, establece la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `Shape`.

![Redimensionar forma para ajustarse al texto](alwaysfit-setting-powerpoint.png)

Este código C# muestra cómo especificar que el texto siempre debe ajustarse a su recuadro en una presentación de PowerPoint:
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


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentando su altura) para que todo el texto quepa. Si el texto se vuelve más corto, ocurrirá lo contrario.

## **No ajustar automáticamente**

Si deseas que un cuadro de texto o forma conserve sus dimensiones sin importar los cambios realizados en el texto que contiene, debes usar la opción **No ajustar automáticamente**. Para especificar esta configuración, establece la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `None`.

!["No ajustar automáticamente" configuración en PowerPoint](donotautofit-setting-powerpoint.png)

Este código C# muestra cómo especificar que un cuadro de texto debe conservar siempre sus dimensiones en una presentación de PowerPoint:
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


Cuando el texto se vuelve demasiado largo para su recuadro, se desborda.

## **Reducir texto en desbordamiento**

Si el texto se vuelve demasiado largo para su recuadro, mediante la opción **Reducir texto en desbordamiento** puedes especificar que el tamaño y el espaciado del texto deben reducirse para que quepa en su recuadro. Para especificar esta configuración, establece la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `Normal`.

!["Reducir texto en desbordamiento" configuración en PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Este código C# muestra cómo especificar que el texto debe reducirse en caso de desbordamiento en una presentación de PowerPoint:
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
Cuando se usa la opción **Reducir texto en desbordamiento**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su recuadro.
{{% /alert %}}

## **Ajustar texto**

Si deseas que el texto dentro de una forma se ajuste dentro de esa forma cuando el texto exceda el borde de la forma (solo ancho), debes usar el parámetro **Ajustar texto en forma**. Para especificar esta configuración, establece la propiedad `WrapText` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `NullableBool.True`.

Este código C# muestra cómo usar la configuración Ajustar texto en una presentación de PowerPoint:
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
Si estableces la propiedad `WrapText` en `NullableBool.False` para una forma, cuando el texto dentro de la forma se vuelve más largo que el ancho de la forma, el texto se extiende más allá de los bordes de la forma en una sola línea.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Los márgenes internos del marco de texto afectan al AutoFit?**

Sí. El relleno (márgenes internos) reduce el área útil para el texto, por lo que AutoFit se activa antes—reduciendo la fuente o redimensionando la forma antes. Revisa y ajusta los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen, y AutoFit adapta el tamaño de fuente y el espaciado a su alrededor. Eliminar saltos innecesarios a menudo reduce la agresividad con que AutoFit necesita reducir el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifo diferentes cambia el ancho/altura del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuente, vuelve a comprobar las diapositivas.