---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en C++
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/cpp/search-and-replace-text/
keywords:
- texto de búsqueda
- texto resaltado
- texto de reemplazo
- expresión regular
- devolución de llamada de resultados
- cuadro de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint mientras se recopila cada coincidencia con Aspose.Slides para C++."
---
## **Descripción general**

Aspose.Slides for C++ puede buscar, resaltar y reemplazar texto en un cuadro de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia mediante una devolución de llamada de resultado. Esto permite actualizar una presentación y, simultáneamente, generar una pista de auditoría que contenga el texto coincidente, su contexto, posición, cuadro de texto y número de diapositiva.

Estas capacidades son útiles para revisiones, redactado, comprobaciones de terminología, limpieza de plantillas y flujos de trabajo de generación de informes automáticos.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente contenido:

![Texto de ejemplo](sample_text.png)

## **Elegir el alcance de la búsqueda**

Utilice los métodos de [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) para limitar una operación a un cuadro de texto. Utilice los métodos de [IPresentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un cuadro de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [ITextFrame::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlighttext/) |
| Resaltar coincidencias de expresiones regulares | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlightregex/) |
| Reemplazar texto literal | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replacetext/) |
| Reemplazar coincidencias de expresiones regulares | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [ITextSearchOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/) para controlar la coincidencia:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) limita las coincidencias a palabras completas.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) controla si se debe respetar la distinción entre mayúsculas y minúsculas.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_includenotes/) incluye las notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones con expresiones regulares utilizan un `System::Text::RegularExpressions::Regex`, por lo que las reglas de coincidencia, como la distinción entre mayúsculas y minúsculas y los límites de palabras, se definen en la propia expresión y sus opciones.

## **Identificar el propietario de un cuadro de texto**

Los flujos de trabajo genéricos de procesamiento de texto a menudo reciben un [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) al buscar, reemplazar, validar o exportar texto. Utilice [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentshape/) y [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentcell/) para determinar qué objeto de la presentación posee el cuadro de texto.

Los valores esperados dependen del propietario:

| Propietario del cuadro de texto | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Una AutoForma u otra forma que contenga texto | El propietario [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) | `nullptr` |
| Una celda de tabla | `nullptr` | El propietario [ICell](https://reference.aspose.com/slides/es/cpp/aspose.slides/icell/) |

Ambos métodos proporcionan navegación de solo lectura. Llamarlos no mueve el cuadro de texto ni cambia su propietario. El código genérico debe comprobar ambos valores para `nullptr` y gestionar la posibilidad de que ninguno de los propietarios esté disponible.

El siguiente ejemplo utiliza [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/getalltextframes/) para iterar a través de los cuadros de texto de una presentación. Para las formas, muestra el nombre de la forma, el tipo en tiempo de ejecución de C++ y la diapositiva contenedora. Para las celdas de tabla, muestra las coordenadas de columna y fila basadas en cero y la diapositiva contenedora.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

Para el contenido de SmartArt, itere a través de las formas en [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) y acceda a cada [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). El cuadro de texto puede rastrearse hasta su forma asociada mediante [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentshape/), mientras que [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentcell/) devuelve `nullptr`. Por lo tanto, la rama de formas en el ejemplo también gestiona el texto de los nodos SmartArt.

## **Recoger información de coincidencias con una devolución de llamada**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifindresultcallback/) para recibir una notificación de cada coincidencia. Su método [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifindresultcallback/foundresult/) proporciona el cuadro de texto relacionado, el texto origen, el texto coincidente y la posición de la coincidencia.

La devolución de llamada no recibe directamente el número de diapositiva. La implementación a continuación lo obtiene de [ISlideComponent::get_Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecomponent/get_slide/) y también gestiona el texto encontrado en notas de diapositiva a través de [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotesslide/get_parentslide/). Un número de diapositiva nullable permite que el mismo modelo de resultado represente texto asociado a otros tipos de diapositiva.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Para operaciones de reemplazo, `FoundText` contiene el texto original coincidente, por lo que la devolución de llamada puede registrar exactamente qué términos fueron reemplazados.

## **Resaltar texto**

Utilice el método [ITextFrame::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlighttext/) para resaltar coincidencias de texto literal en un cuadro de texto. Pase [ITextSearchOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/) para controlar la búsqueda y una devolución de llamada para recopilar los detalles de la coincidencia.

El ejemplo de código a continuación resalta todas las apariciones de los caracteres **"try"** y luego resalta solo la palabra completa **"to"**. Ambas búsquedas informan sus coincidencias a la misma devolución de llamada.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obtener la primera forma de la primera diapositiva.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![El texto resaltado](highlighted_text.png)

## **Resaltar texto usando expresiones regulares**

El método [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlightregex/) resalta las coincidencias de texto encontradas mediante una expresión regular en un cuadro de texto.

El siguiente código resalta todas las palabras que contienen siete o más caracteres y recopila cada coincidencia:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![El texto resaltado usando la expresión regular](highlighted_text_using_regex.png)

## **Resaltar texto en toda una presentación**

Utilice [IPresentation::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlighttext/) y [IPresentation::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlightregex/) para buscar en todos los cuadros de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico manteniendo colecciones de resultados separadas para ambas búsquedas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Reemplazar texto en un cuadro de texto**

Utilice [ITextFrame::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replacetext/) para texto literal y [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replaceregex/) para reemplazo basado en patrones. Estos métodos actualizan el texto coincidente dentro del cuadro de texto existente, conservando el formato de la porción circundante en lugar de reconstruir el cuadro de texto a partir de una cadena simple.

El siguiente ejemplo estandariza una variante ortográfica y luego reemplaza etiquetas de versión. La misma devolución de llamada registra los términos originales coincidentes en ambas operaciones.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si una coincidencia abarca partes con formatos diferentes, revise el resultado para confirmar qué formato debe aplicarse al texto de reemplazo.

## **Reemplazar texto en toda una presentación**

Utilice [IPresentation::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replacetext/) y [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replaceregex/) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y redactado.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Agrupar coincidencias para informes**

Debido a que cada resultado almacena su número de diapositiva y cuadro de texto, las aplicaciones pueden agrupar coincidencias para auditoría, generación de informes o flujos de revisión. El siguiente ejemplo agrupa los resultados recopilados primero por diapositiva y luego por cuadro de texto:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **Preguntas frecuentes**

**¿Cómo puedo buscar solo en un cuadro de texto en lugar de en toda la presentación?**

Obtenga el cuadro de texto de la forma y llame a [ITextFrame::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replacetext/) o [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replaceregex/) sobre ese cuadro de texto. Los métodos a nivel de presentación procesan todos los cuadros de texto aplicables.

**¿Cómo puedo hacer coincidir palabras completas con la capitalización correcta?**

Llama a [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) y [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) con `true`, y pasa las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, define los límites de palabras y la distinción entre mayúsculas y minúsculas en el propio `System::Text::RegularExpressions::Regex`.

**¿Puede la búsqueda y el reemplazo incluir texto en las notas de diapositiva?**

Sí. Llame a [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_includenotes/) con `true` al usar una operación de texto literal a nivel de presentación. La implementación de la devolución de llamada mostrada arriba asigna una coincidencia en una diapositiva de notas a su número de diapositiva principal.

**¿Cómo puedo crear un informe sin escanear la presentación una segunda vez?**

Pase una implementación de [IFindResultCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifindresultcallback/) a la operación de resaltado o reemplazo. La devolución de llamada recibe cada coincidencia mientras la operación se ejecuta, de modo que la aplicación pueda almacenar el texto origen, el texto coincidente, la posición, el cuadro de texto y el número de diapositiva derivado para su posterior agrupamiento o exportación.

**¿El reemplazo de texto conserva su formato?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replacetext/) y [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replaceregex/) modifican el texto coincidente dentro del cuadro de texto existente y conservan el formato de la porción circundante. Si una coincidencia abarca partes con formatos diferentes, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.