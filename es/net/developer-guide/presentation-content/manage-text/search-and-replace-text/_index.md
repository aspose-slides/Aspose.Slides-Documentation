---
title: Buscar y reemplazar texto en presentaciones PowerPoint en .NET
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/net/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- callback de resultados
- marco de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones PowerPoint mientras se recopila cada coincidencia con Aspose.Slides para .NET."
---
## **Descripción general**

Aspose.Slides for .NET puede buscar, resaltar y reemplazar texto en un marco de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante una devolución de llamada de resultados. Esto permite actualizar una presentación y, al mismo tiempo, crear un registro de auditoría que contenga el texto coincidido, su contexto, posición, marco de texto y número de diapositiva.

Estas capacidades son útiles para revisiones, redactado, comprobaciones de terminología, depuración de plantillas y flujos de trabajo de generación de informes automatizados.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Seleccionar el alcance de la búsqueda**

Utilice los métodos de [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) para limitar una operación a un único marco de texto. Utilice los métodos de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un marco de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [ITextFrame.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlighttext/) |
| Resaltar coincidencias de expresiones regulares | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlightregex/) |
| Reemplazar texto literal | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replacetext/) |
| Reemplazar coincidencias de expresiones regulares | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replaceregex/) |

## **Configurar la coincidencia de texto**

Para operaciones con texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/wholewordsonly/) limita las coincidencias a palabras completas.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/casesensitive/) controla si la capitalización debe coincidir.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/includenotes/) incluye notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones con expresiones regulares utilizan un `Regex` de .NET, por lo que reglas como la sensibilidad a mayúsculas y los límites de palabras se definen en la propia expresión y sus opciones.

## **Recopilar información de coincidencias con una devolución de llamada**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/es/net/aspose.slides/ifindresultcallback/) para recibir una notificación por cada coincidencia. Su método [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/es/net/aspose.slides/ifindresultcallback/foundresult/) proporciona el marco de texto relacionado, el texto fuente, el texto coincidido y la posición de la coincidencia.

La devolución de llamada no recibe directamente el número de diapositiva. La implementación a continuación lo deriva de la diapositiva padre y también gestiona el texto encontrado en notas de diapositiva. Un número de diapositiva nullable permite que el mismo modelo de resultado represente texto asociado a otros tipos de diapositiva.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Para operaciones de reemplazo, `FoundText` contiene el texto original coincidido, de modo que la devolución de llamada puede registrar exactamente qué términos fueron sustituidos.

## **Resaltar texto**

Utilice el método [ITextFrame.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlighttext/) para resaltar coincidencias de texto literal en un marco de texto. Pase [TextSearchOptions](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/) para controlar la búsqueda y una devolución de llamada para recopilar los detalles de las coincidencias.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**. Ambas búsquedas informan sus coincidencias a la misma devolución de llamada.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Obtener la primera forma de la primera diapositiva.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Resaltar cada aparición de "try" en el marco de texto.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Resaltar solo la palabra completa "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

El resultado:

![El texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlightregex/) resalta las coincidencias de texto encontradas mediante una expresión regular en un marco de texto.

El siguiente código resalta todas las palabras que contengan siete o más caracteres y recopila cada coincidencia:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

El resultado:

![El texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Resaltar texto en toda la presentación**

Utilice [Presentation.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlighttext/) y [Presentation.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlightregex/) para buscar en todos los marcos de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico, manteniendo colecciones de resultados separadas para ambas búsquedas.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Reemplazar texto en un marco de texto**

Utilice [ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) para texto literal y [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) para reemplazos basados en patrones. Estos métodos actualizan el texto coincidido dentro del marco de texto existente, conservando el formato de la porción circundante en lugar de reconstruir el marco a partir de una cadena simple.

El siguiente ejemplo normaliza una variante ortográfica y luego sustituye etiquetas de versión. La misma devolución de llamada registra los términos originales coincididos por ambas operaciones.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Si una coincidencia abarca porciones con formatos diferentes, revise la salida para confirmar qué formato debe aplicarse al texto reemplazado.

## **Reemplazar texto en toda la presentación**

Utilice [Presentation.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replacetext/) y [Presentation.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replaceregex/) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la depuración de plantillas, actualizaciones de terminología y redactado.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Agrupar coincidencias para informes**

Dado que cada resultado almacena su número de diapositiva y marco de texto, las aplicaciones pueden agrupar coincidencias para auditorías, informes o flujos de revisión. El siguiente ejemplo agrupa los resultados recopilados primero por diapositiva y luego por marco de texto:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **Preguntas frecuentes**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el marco de texto de la forma y llame a [ITextFrame.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) o [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) en ese marco de texto. Los métodos a nivel de presentación procesan todos los marcos de texto aplicables.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/wholewordsonly/) y [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/casesensitive/) en `true`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabra y la sensibilidad a mayúsculas en el propio `Regex` de .NET.

**¿Puede la búsqueda y el reemplazo incluir texto en notas de diapositiva?**

Sí. Establezca [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/includenotes/) en `true` al utilizar una operación de texto literal a nivel de presentación. La implementación de la devolución de llamada mostrada arriba asigna una coincidencia encontrada en una diapositiva de notas al número de diapositiva padre.

**¿Cómo puedo crear un informe sin volver a escanear la presentación?**

Pase una implementación de [IFindResultCallback](https://reference.aspose.com/slides/es/net/aspose.slides/ifindresultcallback/) a la operación de resaltado o reemplazo. La devolución de llamada recibe cada coincidencia mientras se ejecuta la operación, de modo que la aplicación puede almacenar el texto fuente, el texto coincidido, la posición, el marco de texto y el número de diapositiva derivado para agrupar o exportar posteriormente.

**¿El reemplazo de texto conserva su formato?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) y [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) modifican el texto coincidido dentro del marco de texto existente y conservan el formato de la porción circundante. Si una coincidencia abarca porciones con diferentes formatos, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.