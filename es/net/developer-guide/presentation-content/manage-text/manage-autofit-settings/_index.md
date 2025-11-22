---
title: Mejora tus presentaciones con AutoFit en C#
linktitle: Gestionar ajustes de AutoFit
type: docs
weight: 30
url: /es/net/manage-autofit-settings/
keywords:
- cuadro de texto
- ajuste automático
- no ajuste automático
- ajustar texto
- reducir texto
- envolver texto
- redimensionar forma
- PowerPoint
- presentación
- C#
- .NET
- Aspose.Slides
description: "Aprende a gestionar los ajustes de AutoFit en Aspose.Slides para .NET para optimizar la visualización del texto en tus presentaciones de PowerPoint y OpenDocument y mejorar la legibilidad del contenido."
---

## **Descripción general**

De forma predeterminada, cuando añades un cuadro de texto, Microsoft PowerPoint usa la configuración **Redimensionar forma para ajustarse al texto** del cuadro de texto: redimensiona automáticamente el cuadro para que su texto siempre quepa en él.

![Un cuadro de texto en PowerPoint](textbox-in-powerpoint.png)

* Cuando el texto del cuadro de texto se vuelve más largo o más grande, PowerPoint aumenta automáticamente el cuadro—incrementando su altura—para permitir que contenga más texto.  
* Cuando el texto del cuadro de texto se vuelve más corto o más pequeño, PowerPoint reduce automáticamente el cuadro—disminuyendo su altura—para eliminar el espacio redundante.

En PowerPoint, estos son los cuatro parámetros u opciones importantes que controlan el comportamiento de ajuste automático para un cuadro de texto:

* **No ajustar automáticamente**
* **Reducir texto en desbordamiento**
* **Redimensionar forma para ajustarse al texto**
* **Ajustar texto en la forma**

![Opciones de ajuste automático en PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET ofrece opciones similares—propiedades bajo la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—que le permiten controlar el comportamiento de ajuste automático para cuadros de texto en presentaciones.

## **Redimensionar forma para ajustarse al texto**

Si deseas que el texto en un cuadro siempre quepa dentro de ese cuadro después de realizar cambios, debes usar la opción **Redimensionar forma para ajustarse al texto**. Para especificar esta configuración, establece la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `Shape`.

![Redimensionar forma para ajustarse al texto](alwaysfit-setting-powerpoint.png)

Este código C# muestra cómo especificar que el texto debe siempre caber en su cuadro en una presentación de PowerPoint:
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


Si el texto se vuelve más largo o más grande, el cuadro de texto se redimensionará automáticamente (aumentará su altura) para asegurar que todo el texto quepa en él. Si el texto se vuelve más corto, ocurre lo contrario.

## **No ajustar automáticamente**

Si deseas que un cuadro de texto o forma mantenga sus dimensiones sin importar los cambios realizados en el texto que contiene, debes usar la opción **No ajustar automáticamente**. Para especificar esta configuración, establece la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `None`.

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

Este código C# muestra cómo especificar que un cuadro de texto debe siempre conservar sus dimensiones en una presentación de PowerPoint:
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

## **Reducir texto en desbordamiento**

Si el texto se vuelve demasiado largo para su cuadro, mediante la opción **Reducir texto en desbordamiento** puedes especificar que el tamaño y el espaciado del texto deben reducirse para que quepan en su cuadro. Para especificar esta configuración, establece la propiedad `AutofitType` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `Normal`.

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

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

Al usar la opción **Reducir texto en desbordamiento**, la configuración se aplica solo cuando el texto se vuelve demasiado largo para su cuadro.

{{% /alert %}}

## **Ajustar texto**

Si deseas que el texto en una forma se ajuste dentro de esa forma cuando el texto supera el borde de la forma (solo en anchura), debes usar el parámetro **Ajustar texto en la forma**. Para especificar esta configuración, debes establecer la propiedad `WrapText` de la clase [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) en `NullableBool.True`.

Este código C# muestra cómo utilizar la configuración Ajustar Texto en una presentación de PowerPoint:
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

**¿Los márgenes internos del marco de texto afectan el AutoFit?**

Sí. El relleno (márgenes internos) reduce el área utilizable para el texto, por lo que AutoFit se activa antes—reduciendo la fuente o redimensionando la forma más pronto. Revisa y ajusta los márgenes antes de afinar AutoFit.

**¿Cómo interactúa AutoFit con los saltos de línea manuales y suaves?**

Los saltos forzados permanecen en su lugar, y AutoFit adapta el tamaño de fuente y el espaciado a su alrededor. Eliminar saltos innecesarios suele reducir la agresividad con la que AutoFit necesita reducir el texto.

**¿Cambiar la fuente del tema o activar la sustitución de fuentes afecta los resultados de AutoFit?**

Sí. Sustituir a una fuente con métricas de glifos diferentes cambia el ancho/alto del texto, lo que puede alterar el tamaño final de la fuente y el ajuste de líneas. Después de cualquier cambio o sustitución de fuente, vuelve a comprobar las diapositivas.