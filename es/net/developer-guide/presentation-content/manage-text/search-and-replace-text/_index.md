---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en .NET
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
- cuadro de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint mientras se recopila cada coincidencia con Aspose.Slides para .NET."
---
## **Visión general**

Aspose.Slides for .NET puede buscar, resaltar y reemplazar texto en un único cuadro de texto o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante una devolución de resultados. Esto permite actualizar una presentación y, simultáneamente, crear una pista de auditoría que contiene el texto coincidente, su contexto, posición, cuadro de texto y número de diapositiva.

Estas capacidades son útiles para la revisión, la redacción, la comprobación de terminología, la limpieza de plantillas y los flujos de trabajo de generación de informes automáticos.

En los primeros ejemplos a continuación, usamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Texto de ejemplo](sample_text.png)

## **Seleccionar el ámbito de la búsqueda**

Utilice los métodos de [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) para limitar una operación a un único cuadro de texto. Utilice los métodos de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un cuadro de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [ITextFrame.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlighttext/) |
| Resaltar coincidencias de expresiones regulares | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlightregex/) |
| Reemplazar texto literal | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replacetext/) |
| Reemplazar coincidencias de expresiones regulares | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replaceregex/) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [TextSearchOptions](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/) para controlar la coincidencia:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/wholewordsonly/) limita las coincidencias a palabras completas.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/casesensitive/) controla si se debe respetar mayúsculas y minúsculas.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/includenotes/) incluye notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones con expresiones regulares utilizan un `Regex` de .NET, por lo que reglas de coincidencia como la sensibilidad a mayúsculas y los límites de palabra se definen mediante la expresión y sus opciones.

## **Identificar el propietario de un cuadro de texto**

Los flujos de trabajo genéricos de procesamiento de texto a menudo reciben un [ITextFrame] al buscar, reemplazar, validar o exportar texto. Utilice [ITextFrame.ParentShape](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/parentshape/) y [ITextFrame.ParentCell](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/parentcell/) para determinar qué objeto de la presentación es el propietario del cuadro de texto.

Los valores esperados dependen del propietario:

| Propietario del cuadro de texto | `ParentShape` | `ParentCell` |
|---|---|---|
| Una AutoShape u otra forma que contenga texto | El [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/) propietario | `null` |
| Una celda de tabla | `null` | El [ICell](https://reference.aspose.com/slides/es/net/aspose.slides/icell/) propietario |

Ambas propiedades son de solo lectura y de navegación. Leerlas no mueve el cuadro de texto ni cambia su propietario. El código genérico debe comprobar ambos valores para `null` y manejar la posibilidad de que ninguno de los propietarios esté disponible.

El siguiente ejemplo utiliza [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/getalltextframes/) para iterar sobre los cuadros de texto de una presentación. Para las formas, informa del nombre de la forma, el tipo de forma y la diapositiva contenedora. Para las celdas de tabla, informa de las coordenadas de columna y fila basadas en cero y de la diapositiva contenedora.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Para el contenido de SmartArt, itere a través de las formas en [ISmartArtNode.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartartnode/shapes/) y acceda a cada [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartartshape/textframe/). El cuadro de texto puede rastrearse a su forma asociada mediante [ITextFrame.ParentShape](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/parentshape/), mientras que [ITextFrame.ParentCell](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/parentcell/) es `null`. Por lo tanto, la rama de forma en el ejemplo también maneja texto de nodos SmartArt.

## **Recopilar información de coincidencias con una devolución de llamada**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/es/net/aspose.slides/ifindresultcallback/) para recibir una notificación por cada coincidencia. Su método [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/es/net/aspose.slides/ifindresultcallback/foundresult/) proporciona el cuadro de texto relacionado, el texto fuente, el texto coincidente y la posición de la coincidencia.

La devolución de llamada no recibe directamente el número de diapositiva. La implementación a continuación lo deriva de la diapositiva padre y también gestiona texto encontrado en notas de diapositiva. Un número de diapositiva nullable permite que el mismo modelo de resultado represente texto asociado a otros tipos de diapositiva.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

Para operaciones de reemplazo, `FoundText` contiene el texto coincidido original, de modo que la devolución de llamada puede registrar exactamente qué términos fueron reemplazados.

## **Resaltar texto**

Utilice el método [ITextFrame.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlighttext/) para resaltar coincidencias de texto literal en un cuadro de texto. Pase [TextSearchOptions](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/) para controlar la búsqueda y una devolución de llamada para recopilar los detalles de la coincidencia.

El siguiente ejemplo de código resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**. Ambas búsquedas informan sus coincidencias a la misma devolución de llamada.

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

// Resaltar cada aparición de "try" en el cuadro de texto.
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

El método [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlightregex/) resalta coincidencias de texto encontradas mediante una expresión regular en un cuadro de texto.

El siguiente código resalta todas las palabras que contienen siete o más caracteres y recopila cada coincidencia:

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

Utilice [Presentation.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlighttext/) y [Presentation.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/highlightregex/) para buscar en todos los cuadros de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico, manteniendo colecciones de resultados separadas para ambas búsquedas.

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

## **Reemplazar texto en un cuadro de texto**

Utilice [ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) para texto literal y [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del cuadro de texto existente, que conserva el formato de la parte circundante en lugar de reconstruir el cuadro de texto a partir de una cadena simple.

El siguiente ejemplo normaliza una variante ortográfica y luego reemplaza etiquetas de versión. La misma devolución de llamada registra los términos originales coincidentes en ambas operaciones.

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

Si una coincidencia abarca partes con formato diferente, revise el resultado para confirmar qué formato debe aplicarse al texto de reemplazo.

## **Reemplazar texto en toda la presentación**

Utilice [Presentation.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replacetext/) y [Presentation.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replaceregex/) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, la actualización de terminología y la redacción.

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

Debido a que cada resultado almacena su número de diapositiva y cuadro de texto, las aplicaciones pueden agrupar coincidencias para auditorías, informes o flujos de trabajo de revisión. El siguiente ejemplo agrupa los resultados recopilados primero por diapositiva y luego por cuadro de texto:

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

## **FAQ**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el cuadro de texto de la forma y llame a [ITextFrame.HighlightText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) o [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) en ese cuadro de texto. Los métodos a nivel de presentación procesan todos los cuadros de texto aplicables.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Establezca [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/wholewordsonly/) y [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/casesensitive/) en `true`, y pase las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, defina los límites de palabras y la sensibilidad a mayúsculas en el propio `Regex` de .NET.

**¿Puede la búsqueda y el reemplazo incluir texto en las notas de la diapositiva?**

Sí. Establezca [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/es/net/aspose.slides/textsearchoptions/includenotes/) en `true` al usar una operación de texto literal a nivel de presentación. La implementación de la devolución de llamada mostrada arriba asigna una coincidencia en una diapositiva de notas al número de diapositiva padre.

**¿Cómo puedo crear un informe sin volver a escanear la presentación?**

Pase una implementación de [IFindResultCallback](https://reference.aspose.com/slides/es/net/aspose.slides/ifindresultcallback/) a la operación de resaltado o reemplazo. La devolución de llamada recibe cada coincidencia mientras la operación se ejecuta, de modo que la aplicación puede almacenar el texto fuente, el texto coincidente, la posición, el cuadro de texto y el número de diapositiva derivado para su posterior agrupación o exportación.

**¿El reemplazo de texto conserva su formato?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replacetext/) y [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/replaceregex/) modifican el texto coincidente dentro del cuadro de texto existente y conservan el formato de la parte circundante. Si una coincidencia abarca partes con formato diferente, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.