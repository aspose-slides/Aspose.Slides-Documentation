---
title: Automatizar la localización de presentaciones en C++
linktitle: Localización de Presentaciones
type: docs
weight: 100
url: /es/cpp/presentation-localization/
keywords:
- cambiar idioma
- revisión ortográfica
- suprimir revisión ortográfica
- idioma de corrección
- id de idioma
- texto multilingüe
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Establezca los idiomas de corrección para el texto de presentaciones PowerPoint y OpenDocument en C++ con Aspose.Slides, incluyendo valores predeterminados y párrafos multilingües."
---
## **Resumen**

Aspose.Slides for C++ le permite configurar los metadatos de corrección para porciones de texto individuales. Use [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_languageid/) para identificar el idioma de corrección, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_spellcheck/) para permitir o suprimir la comprobación ortográfica, y [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_proofdisabled/) para controlar el estado más amplio de «no corregir». Como estas configuraciones se aplican a nivel de porción, un párrafo puede contener varios idiomas y diferentes reglas de corrección.

Este artículo explica cómo asignar un idioma a texto específico, establecer el idioma predeterminado para texto nuevo con [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), crear párrafos multilingües, elegir entre `SpellCheck` y `ProofDisabled`, y mantener la configuración deseada al usar [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Estas propiedades almacenan metadatos para aplicaciones de presentación; no traducen texto, no realizan una revisión ortográfica basada en diccionario ni devuelven palabras mal escritas.

## **Establecer el idioma de corrección para el texto**

Cree o cargue una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/), acceda a la porción de texto requerida mediante [IPortion::get_PortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/get_portionformat/), y asigne su identificador de idioma. El siguiente ejemplo crea una forma, establece el inglés británico como idioma de corrección y guarda el resultado con [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Establecer el idioma predeterminado para texto nuevo**

Use [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) para especificar el idioma de corrección que Aspose.Slides asigna al texto recién creado. Esta configuración es útil cuando la mayor parte o todo el texto nuevo en una presentación utiliza el mismo idioma. No modifica los metadatos de idioma del texto que ya posee un idioma explícito.

El siguiente ejemplo crea una presentación cuyo texto nuevo usa reglas de corrección en alemán:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usar varios idiomas en un solo párrafo**

Un [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/) contiene una colección de porciones de texto. Cree una [Portion](https://reference.aspose.com/slides/es/cpp/aspose.slides/portion/) separada para cada idioma y establezca su `LanguageId` de forma independiente.

Este ejemplo crea un párrafo con porciones en inglés y francés:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Habilitar o suprimir la comprobación ortográfica para porciones individuales**

[IPortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportionformat/) hereda las propiedades de texto comunes definidas por [IBasePortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/). Acceda al formato de una porción mediante [IPortion::get_PortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/get_portionformat/) y llame a [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_spellcheck/) para controlar si una aplicación de presentación puede revisar la ortografía de esa porción. El valor predeterminado es `false`: `true` permite la revisión ortográfica, mientras que `false` la suprime.

La configuración se aplica a porciones de texto individuales. Por tanto, diferentes porciones en el mismo párrafo pueden usar valores distintos. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_languageid/) y `SpellCheck` cumplen propósitos complementarios: `LanguageId` identifica el idioma de corrección, mientras que `SpellCheck` determina si se permiten las revisiones ortográficas para la porción.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_proofdisabled/) también controla la corrección, pero representa el estado más amplio de «no corregir» como un [NullableBool](https://reference.aspose.com/slides/es/cpp/aspose.slides/nullablebool/). Use `SpellCheck` cuando necesite un conmutador booleano directo específicamente para revisiones ortográficas. Use `ProofDisabled` cuando necesite preservar o controlar explícitamente los metadatos de «no corrección» de la presentación, incluido su estado `NullableBool::NotDefined`. Si establece ambas propiedades, mantenga sus valores coherentes; no combine `SpellCheck = true` con `ProofDisabled = NullableBool::True`.

Estas propiedades configuran metadatos de corrección utilizados por PowerPoint y otras aplicaciones de presentación. Aspose.Slides no los usa para ejecutar revisiones ortográficas basadas en diccionario ni para devolver una lista de palabras mal escritas.

El siguiente ejemplo completo crea una presentación de entrada, la carga, asigna diferentes configuraciones de revisión ortográfica e idiomas de corrección a dos porciones del mismo párrafo, guarda el resultado, lo vuelve a abrir y verifica los valores almacenados:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/joinportionswithsameformatting/) combina porciones adyacentes que tienen el mismo formato. Una diferencia solo en `SpellCheck` no mantiene esas porciones separadas; tras la combinación, la porción resultante conserva el valor `SpellCheck` de la primera porción. Si las porciones requieren configuraciones de revisión distintas, llame a `JoinPortionsWithSameFormatting` antes de asignar esas configuraciones, o inspeccione los límites de la porción resultante y vuelva a aplicar los ajustes después. Las porciones con valores diferentes de `LanguageId` permanecen separadas porque su formato de idioma de corrección difiere.

## **Preguntas frecuentes**

**¿El ID de idioma traduce el texto?**

No. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_languageid/) almacena metadatos de corrección para ortografía y gramática; no altera el contenido del texto. Traduzca el texto por separado y luego establezca el identificador de idioma apropiado para cada porción traducida.

**¿El idioma de corrección controla fuentes, guionización o ajuste de línea?**

No. El identificador de idioma es solo para corrección. La renderización y el diseño del texto dependen principalmente de las [fuentes](/slides/es/cpp/powerpoint-fonts/) disponibles, del sistema de escritura y de la configuración del marco de texto. Para un renderizado fiable, proporcione las fuentes necesarias, configure la [sustitución de fuentes](/slides/es/cpp/font-substitution/) o [incorpore fuentes](/slides/es/cpp/embedded-font/) en la presentación.

**¿Puede un párrafo usar varios idiomas de corrección?**

Sí. Asigne cada idioma a una porción separada, como se muestra en el ejemplo de párrafo multilingüe.

**¿Debo usar `DefaultTextLanguage` o `LanguageId`?**

Use [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) cuando necesite un valor predeterminado para el texto recién creado. Use [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_languageid/) cuando una porción específica requiera un idioma de corrección explícito o cuando un párrafo contenga varios idiomas.