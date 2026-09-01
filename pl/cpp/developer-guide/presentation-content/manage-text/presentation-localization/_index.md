---
title: Automatyzacja lokalizacji prezentacji w C++
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/cpp/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- wyłączenie sprawdzania pisowni
- język korekty
- identyfikator języka
- tekst wielojęzyczny
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Ustaw języki korekty dla tekstu prezentacji PowerPoint i OpenDocument w C++ przy użyciu Aspose.Slides, w tym domyślne oraz wielojęzyczne akapity."
---
## **Przegląd**

Aspose.Slides for C++ umożliwia konfigurowanie metadanych korekty dla poszczególnych fragmentów tekstu. Użyj [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_languageid/) aby określić język korekty, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_spellcheck/) aby zezwolić lub wyłączyć sprawdzanie pisowni oraz [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_proofdisabled/) aby kontrolować szerszy stan „nie korygować”. Ponieważ te ustawienia są stosowane na poziomie fragmentu, jeden akapit może zawierać wiele języków i różnych reguł korekty.

W tym artykule wyjaśniamy, jak przypisać język do określonego tekstu, ustawić domyślny język dla nowego tekstu za pomocą [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), tworzyć wielojęzyczne akapity, wybierać pomiędzy `SpellCheck` a `ProofDisabled` oraz zachować zamierzone ustawienia przy użyciu [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Właściwości te przechowują metadane dla aplikacji prezentacyjnych; nie tłumaczą tekstu, nie wykonują sprawdzania pisowni opartego na słownikach ani nie zwracają słów z błędami.

## **Ustaw język korekty dla tekstu**

Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), uzyskaj dostęp do wymaganego fragmentu tekstu poprzez [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/get_portionformat/), i przypisz jego identyfikator języka. W poniższym przykładzie tworzony jest kształt, ustawiany jest brytyjski angielski jako język korekty oraz zapisywany jest wynik za pomocą [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/):

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

## **Ustaw domyślny język dla nowego tekstu**

Użyj [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) aby określić język korekty, który Aspose.Slides przypisuje nowo tworzonemu tekstowi. To ustawienie jest przydatne, gdy większość lub cały nowy tekst w prezentacji używa tego samego języka. Nie zmienia ono metadanych językowych tekstu, który już ma explicite określony język.

Poniższy przykład tworzy prezentację, w której nowy tekst używa reguł korekty niemieckiej:

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

## **Użyj wielu języków w jednym akapicie**

[IParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraph/) zawiera kolekcję fragmentów tekstu. Utwórz osobny [Portion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portion/) dla każdego języka i ustaw jego `LanguageId` niezależnie.

Ten przykład tworzy jeden akapit z fragmentami w języku angielskim i francuskim:

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

## **Włącz lub wyłącz sprawdzanie pisowni dla poszczególnych fragmentów**

[IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/) dziedziczy wspólne właściwości tekstu zdefiniowane w [IBasePortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/). Uzyskaj dostęp do formatu fragmentu przez [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/get_portionformat/) i wywołaj [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_spellcheck/) aby kontrolować, czy aplikacja prezentacyjna może sprawdzać pisownię tego fragmentu. Wartość domyślna to `false`: `true` zezwala na sprawdzanie pisowni, a `false` je wyłącza.

Ustawienie dotyczy pojedynczych fragmentów tekstu. Różne fragmenty w tym samym akapicie mogą więc mieć różne wartości. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_languageid/) i `SpellCheck` spełniają uzupełniające się role: `LanguageId` określa język korekty, natomiast `SpellCheck` decyduje, czy sprawdzanie pisowni jest dozwolone dla fragmentu.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_proofdisabled/) również kontroluje korektę, ale reprezentuje szerszy stan „nie korygować” jako [NullableBool](https://reference.aspose.com/slides/pl/cpp/aspose.slides/nullablebool/). Używaj `SpellCheck`, gdy potrzebujesz bezpośredniego przełącznika Boolean specjalnie dla sprawdzania pisowni. Używaj `ProofDisabled`, gdy musisz zachować lub explicite kontrolować metadane „brak korekty” prezentacji, w tym stan `NullableBool::NotDefined`. Jeśli ustawisz oba właściwości, utrzymuj ich wartości spójne; nie łącz `SpellCheck = true` z `ProofDisabled = NullableBool::True`.

Te właściwości konfigurują metadane korekty używane przez PowerPoint i inne aplikacje prezentacyjne. Aspose.Slides nie używa ich do uruchamiania sprawdzania pisowni opartego na słownikach ani do zwracania listy słów z błędami.

Poniższy kompletny przykład tworzy prezentację wejściową, wczytuje ją, przypisuje różne ustawienia sprawdzania pisowni i języki korekty dwóm fragmentom w tym samym akapicie, zapisuje wynik, ponownie go otwiera i weryfikuje zapisane wartości:

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

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/joinportionswithsameformatting/) łączy sąsiadujące fragmenty, które mają takie samo formatowanie. Różnica w samym `SpellCheck` nie utrzymuje ich osobno; po połączeniu wynikowy fragment zachowuje wartość `SpellCheck` pierwszego fragmentu. Jeśli fragmenty wymagają różnych ustawień sprawdzania pisowni, wywołaj `JoinPortionsWithSameFormatting` przed przypisaniem tych ustawień lub sprawdź granice wynikowych fragmentów i ponownie zastosuj ustawienia po połączeniu. Fragmenty z różnymi wartościami `LanguageId` pozostają osobne, ponieważ ich formatowanie języka korekty się różni.

## **FAQ**

**Czy identyfikator języka tłumaczy tekst?**

Nie. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_languageid/) przechowuje metadane korekty dla pisowni i gramatyki; nie zmienia treści tekstu. Przetłumacz tekst oddzielnie, a następnie ustaw odpowiedni identyfikator języka dla każdego przetłumaczonego fragmentu.

**Czy język korekty kontroluje czcionki, dzielenie wyrazów lub zawijanie linii?**

Nie. Identyfikator języka służy wyłącznie korekcie. Renderowanie i układ tekstu zależą głównie od dostępnych [fonts](/slides/pl/cpp/powerpoint-fonts/), systemu pisma oraz ustawień ramki tekstowej. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [font substitution](/slides/pl/cpp/font-substitution/) lub [embed fonts](/slides/pl/cpp/embedded-font/) w prezentacji.

**Czy jeden akapit może używać kilku języków korekty?**

Tak. Przypisz każdy język do osobnego fragmentu, jak pokazano w przykładzie wielojęzycznego akapitu.

**Czy powinienem używać `DefaultTextLanguage` czy `LanguageId`?**

Używaj [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), gdy chcesz mieć domyślny język dla nowo tworzonego tekstu. Używaj [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_languageid/), gdy konkretny fragment wymaga explicite określonego języka korekty lub gdy akapit zawiera wiele języków.