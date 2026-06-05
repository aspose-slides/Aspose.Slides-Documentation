---
title: Extracción avanzada de texto de presentaciones en .NET
linktitle: Extraer texto
type: docs
weight: 90
url: /es/net/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de la diapositiva
- extraer texto de la presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- recuperar texto
- recuperar texto de la diapositiva
- recuperar texto de la presentación
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Extraiga rápidamente texto de presentaciones PowerPoint y OpenDocument utilizando Aspose.Slides para .NET. Siga nuestra guía simple, paso a paso, para ahorrar tiempo."
---
## **Visión general**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Tanto si se trata de archivos de Microsoft PowerPoint en formato PPT o PPTX, como de presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser fundamental para análisis, automatización, indexación o migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de forma eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, utilizando Aspose.Slides para .NET. Aprenderá a iterar sistemáticamente por los elementos de la presentación para obtener con precisión el contenido de texto que necesita.

## **Extraer texto de una diapositiva**

Aspose.Slides para .NET proporciona el espacio de nombres [Aspose.Slides.Util](https://reference.aspose.com/slides/es/net/aspose.slides.util/), que incluye la clase [SlideUtil](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utilice el método [GetAllTextBoxes](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/getalltextboxes/). Este método acepta como parámetro un objeto del tipo [IBaseSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/). Al ejecutarse, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/), conservando cualquier formato del texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Extraer texto de una presentación**

Para escanear texto de toda la presentación, use el método estático [GetAllTextFrames](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/getalltextframes/) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/). Acepta dos parámetros:

1. Primero, un objeto [IPresentation](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/) que representa una presentación PowerPoint u OpenDocument de la que se extraerá el texto.
1. Segundo, un valor `Boolean` que indica si se deben incluir las diapositivas master al escanear el texto de la presentación.

El método devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/), incluida la información de formato del texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas master.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/) también ofrece métodos para extraer todo el texto de las presentaciones:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

El argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/es/net/aspose.slides/textextractionarrangingmode/) indica el modo de organización del resultado de la extracción de texto y puede establecerse en los siguientes valores:
- `Unarranged` - El texto crudo sin tener en cuenta su posición en la diapositiva.
- `Arranged` - El texto se organiza en el mismo orden que aparece en la diapositiva.

El modo sin organizar puede usarse cuando la velocidad es crítica; es más rápido que el modo organizado.

[IPresentationText](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationtext/) representa el texto crudo extraído de la presentación. Su propiedad `SlidesText` devuelve una matriz de objetos del tipo [ISlideText](https://reference.aspose.com/slides/es/net/aspose.slides/islidetext/). Cada objeto representa el texto de la diapositiva correspondiente. El objeto del tipo [ISlideText](https://reference.aspose.com/slides/es/net/aspose.slides/islidetext/) tiene las siguientes propiedades:

- `Text` - El texto dentro de las formas de la diapositiva.
- `MasterText` - El texto dentro de las formas de la diapositiva master asociada a esta diapositiva.
- `LayoutText` - El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.
- `NotesText` - El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.
- `CommentsText` - El texto dentro de los comentarios asociados a esta diapositiva.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y puede procesar incluso [large presentations](/slides/es/net/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de las presentaciones?**

Sí. Aspose.Slides puede extraer texto de muchos elementos de diapositiva, incluidas tablas y objetos relacionados con gráficos, de modo que pueda acceder y analizar el contenido textual en estructuras de presentación comunes.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puede extraer texto utilizando la versión de prueba gratuita de Aspose.Slides, aunque tendrá [certain limitations](/slides/es/net/licensing/), como procesar solo un número limitado de diapositivas. Para un uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.