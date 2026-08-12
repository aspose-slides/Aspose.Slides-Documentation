---
title: Buscar y reemplazar texto en presentaciones de PowerPoint en C++
linktitle: Buscar y reemplazar texto
type: docs
weight: 55
url: /es/cpp/search-and-replace-text/
keywords:
- buscar texto
- resaltar texto
- reemplazar texto
- expresión regular
- devolución de llamada de resultado
- cuadro de texto
- informe de auditoría
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Buscar, resaltar y reemplazar texto en presentaciones de PowerPoint mientras se recopilan todas las coincidencias con Aspose.Slides para C++."
---
## **Visión general**

Aspose.Slides for C++ puede buscar, resaltar y reemplazar texto en un cuadro de texto individual o en toda una presentación. Cada operación también puede notificar a una aplicación sobre cada coincidencia a través de una devolución de llamada de resultado. Esto permite actualizar una presentación y, simultáneamente, generar una pista de auditoría que contiene el texto coincidente, su contexto, posición, cuadro de texto y número de diapositiva.

Estas capacidades son útiles para la revisión, la censura, la comprobación de terminología, la limpieza de plantillas y los flujos de trabajo de generación de informes automatizados.

En los primeros ejemplos a continuación, utilizamos un archivo llamado "sample.pptx", que contiene un único cuadro de texto en la primera diapositiva con el siguiente texto:

![Sample text](sample_text.png)

## **Elegir el alcance de la búsqueda**

Utilice los métodos de [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) para limitar una operación a un cuadro de texto. Utilice los métodos de [IPresentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/) para procesar todo el texto aplicable en la presentación.

| Operación | Un cuadro de texto | Presentación completa |
|---|---|---|
| Resaltar texto literal | [ITextFrame::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlighttext/) |
| Resaltar coincidencias de expresión regular | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlightregex/) |
| Reemplazar texto literal | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replacetext/) |
| Reemplazar coincidencias de expresión regular | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Configurar la coincidencia de texto**

Para operaciones de texto literal, utilice [ITextSearchOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/) para controlar la coincidencia:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) limita las coincidencias a palabras completas.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) controla si debe coincidir la capitalización de los caracteres.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_includenotes/) incluye las notas de diapositiva en las operaciones de búsqueda, reemplazo y resaltado a nivel de presentación.

Las operaciones de expresiones regulares utilizan un `System::Text::RegularExpressions::Regex`, por lo que las reglas de coincidencia como la distinción de mayúsculas y minúsculas y los límites de palabras se definen en la expresión y sus opciones.

## **Recopilar información de coincidencias con una devolución de llamada**

Implemente [IFindResultCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifindresultcallback/) para recibir una notificación por cada coincidencia. Su método [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifindresultcallback/foundresult/) proporciona el cuadro de texto relacionado, el texto fuente, el texto coincidente y la posición de la coincidencia.

La devolución de llamada no recibe directamente el número de diapositiva. La implementación a continuación lo obtiene de [ISlideComponent::get_Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecomponent/get_slide/) y también maneja el texto encontrado en notas de diapositiva mediante [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotesslide/get_parentslide/). Un número de diapositiva nullable permite que el mismo modelo de resultados represente texto asociado a otros tipos de diapositivas.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
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
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
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

Para las operaciones de reemplazo, `FoundText` contiene el texto original coincidente, por lo que la devolución de llamada puede registrar exactamente qué términos fueron reemplazados.

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

// Get the first shape from the first slide.
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

![The highlighted text](highlighted_text.png)

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Resaltar texto en toda una presentación**

Utilice [IPresentation::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlighttext/) y [IPresentation::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/highlightregex/) para buscar en todos los cuadros de texto aplicables de una presentación. El siguiente ejemplo resalta un término literal y todas las direcciones de correo electrónico, manteniendo colecciones de resultados independientes para ambas búsquedas.

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

El siguiente ejemplo normaliza una variante ortográfica y luego reemplaza las etiquetas de versión. La misma devolución de llamada registra los términos originales coincidentes en ambas operaciones.

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

Si una coincidencia abarca porciones con diferente formato, revise la salida para confirmar qué formato debe aplicarse al texto reemplazado.

## **Reemplazar texto en toda una presentación**

Utilice [IPresentation::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replacetext/) y [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/replaceregex/) para aplicar las mismas operaciones en toda la presentación. Esto es útil para la limpieza de plantillas, actualizaciones de terminología y censura.

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

## **Agrupar coincidencias para generar informes**

Debido a que cada resultado almacena su número de diapositiva y cuadro de texto, las aplicaciones pueden agrupar coincidencias para auditorías, generación de informes o flujos de trabajo de revisión. El siguiente ejemplo agrupa los resultados recopilados primero por diapositiva y luego por cuadro de texto:

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

Obtenga el cuadro de texto de la forma y llame a [ITextFrame::HighlightText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replacetext/) o [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replaceregex/) en ese cuadro de texto. Los métodos a nivel de presentación procesan todos los cuadros de texto aplicables.

**¿Cómo puedo coincidir palabras completas con la capitalización correcta?**

Llama a [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) y [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) con `true`, y pasa las opciones a un método de resaltado o reemplazo de texto literal. Para expresiones regulares, define los límites de palabra y la sensibilidad a mayúsculas en el propio `System::Text::RegularExpressions::Regex`.

**¿Pueden la búsqueda y el reemplazo incluir texto en las notas de diapositiva?**

Sí. Llame a [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextsearchoptions/set_includenotes/) con `true` al usar una operación de texto literal a nivel de presentación. La implementación de la devolución de llamada mostrada arriba asigna una coincidencia en una diapositiva de notas a su número de diapositiva principal.

**¿Cómo puedo crear un informe sin volver a escanear la presentación?**

Pase una implementación de [IFindResultCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifindresultcallback/) a la operación de resaltado o reemplazo. La devolución de llamada recibe cada coincidencia mientras se ejecuta la operación, de modo que la aplicación puede almacenar el texto fuente, el texto coincidente, la posición, el cuadro de texto y el número de diapositiva derivado para agrupar o exportar posteriormente.

**¿El reemplazo de texto conserva su formato?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replacetext/) y [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/replaceregex/) modifican el texto coincidente dentro del cuadro de texto existente y conservan el formato de la porción circundante. Si una coincidencia abarca porciones con diferente formato, inspeccione el resultado para asegurarse de que el reemplazo utilice el estilo deseado.