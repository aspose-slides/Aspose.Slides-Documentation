---
title: Extracción avanzada de texto de presentaciones en C#
linktitle: Extraer texto
type: docs
weight: 90
url: /es/net/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de diapositiva
- extraer texto de presentación
- extraer texto de PowerPoint
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- C#
- .NET
- Aspose.Slides
description: "Aprenda cómo extraer texto de presentaciones PowerPoint de forma rápida y sencilla usando Aspose.Slides para .NET. Siga nuestra guía simple, paso a paso, para ahorrar tiempo y acceder eficientemente al contenido de las diapositivas en sus aplicaciones."
---

## **Descripción general**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Ya sea que estés manejando archivos de Microsoft PowerPoint en formato PPT o PPTX, o presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser crítico para análisis, automatización, indexación o propósitos de migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de manera eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, usando Aspose.Slides para .NET. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para recuperar con precisión el contenido de texto que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides para .NET proporciona el espacio de nombres [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) que incluye la clase [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, usa el método [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/). Este método acepta un objeto del tipo [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) como parámetro. Al ejecutarse, el método recorre toda la diapositiva en busca de texto y devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), conservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:
```cs
int slideIndex = 0;

// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
using Presentation presentation = new Presentation("demo.pptx");

// Get a reference to the slide.
ISlide slide = presentation.Slides[slideIndex];

// Get an array of text frames from the slide.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Loop through the array of the text frames.
for (int i = 0; i < textFrames.Length; i++)
{
    // Recorrer los párrafos en el marco de texto actual.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Recorrer las porciones de texto en el párrafo actual.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Mostrar el texto en la porción de texto actual.
            Console.WriteLine(portion.Text);

            // Mostrar la altura de la fuente del texto.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Mostrar el nombre de la fuente del texto.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Extraer texto de una presentación**

Para escanear texto de toda la presentación, usa el método estático [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). Acepta dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) que representa una presentación de PowerPoint o OpenDocument de la cual se extraerá el texto.  
1. Segundo, un valor `Boolean` que indica si las diapositivas maestras deben incluirse al escanear el texto de la presentación.

El método devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), incluyendo información de formato del texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.
```cs
// Instanciar la clase Presentation que representa un archivo de presentación (PPT, PPTX, ODP, etc.).
using Presentation presentation = new Presentation("demo.pptx");

// Obtener una matriz de marcos de texto de todas las diapositivas de la presentación.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// Recorrer la matriz de marcos de texto.
for (int i = 0; i < textFrames.Length; i++)
{
    // Recorrer los párrafos del marco de texto actual.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Recorrer las porciones de texto del párrafo actual.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Mostrar el texto de la porción de texto actual.
            Console.WriteLine(portion.Text);

            // Mostrar la altura de la fuente del texto.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Mostrar el nombre de la fuente del texto.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) también proporciona métodos estáticos para extraer todo el texto de presentaciones:
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


El argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) indica el modo para organizar el resultado de la extracción de texto y puede establecerse en los siguientes valores:

- `Unarranged` - El texto crudo sin considerar su posición en la diapositiva.  
- `Arranged` - El texto se organiza en el mismo orden que en la diapositiva.

El modo sin organizar (`Unarranged`) puede usarse cuando la velocidad es crítica; es más rápido que el modo organizado.

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) representa el texto crudo extraído de la presentación. Contiene la propiedad [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) del espacio de nombres [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/), que devuelve una matriz de objetos del tipo [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/). Cada objeto representa el texto en la diapositiva correspondiente. El objeto del tipo [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) tiene las siguientes propiedades:

- `Text` - El texto dentro de las formas de la diapositiva.  
- `MasterText` - El texto dentro de las formas de la diapositiva maestra asociada a esta diapositiva.  
- `LayoutText` - El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.  
- `NotesText` - El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.  
- `CommentsText` - El texto dentro de los comentarios asociados a esta diapositiva.
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y procesa de manera eficiente incluso presentaciones grandes, lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de las presentaciones?**

Sí, Aspose.Slides admite plenamente la extracción de texto de tablas, gráficos y otros elementos complejos de la diapositiva, lo que le permite acceder y analizar todo el contenido textual fácilmente.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puedes extraer texto usando la versión de prueba gratuita de Aspose.Slides, aunque tendrá ciertas limitaciones, como procesar solo un número limitado de diapositivas. Para un uso sin restricciones y manejar presentaciones más grandes, se recomienda adquirir una licencia completa.