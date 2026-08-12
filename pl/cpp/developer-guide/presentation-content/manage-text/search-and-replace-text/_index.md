---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w C++
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/cpp/search-and-replace-text/
keywords:
- wyszukiwanie tekstu
- podświetlanie tekstu
- zastępowanie tekstu
- wyrażenie regularne
- callback wyniku
- ramka tekstowa
- raport audytu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie przy użyciu Aspose.Slides for C++."
---
## **Przegląd**

Aspose.Slides for C++ może wyszukiwać, podświetlać i zastępować tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może także powiadomić aplikację o każdym dopasowaniu za pośrednictwem callbacku wyniku. Umożliwia to aktualizację prezentacji i jednoczesne tworzenie ścieżki audytu zawierającej dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redakcji, weryfikacji terminologii, czyszczeniu szablonów oraz zautomatyzowanych przepływach raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [IPresentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/) aby przetworzyć cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl tekst dosłowny | [ITextFrame::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlighttext/) |
| Podświetl dopasowania wyrażenia regularnego | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlightregex/) |
| Zastąp tekst dosłowny | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replacetext/) |
| Zastąp dopasowania wyrażenia regularnego | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Skonfiguruj dopasowywanie tekstu**

Dla operacji na tekście dosłownym użyj [ITextSearchOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/) do kontrolowania dopasowań:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) ogranicza dopasowania do pełnych słów.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) kontroluje, czy wielkość znaków musi się zgadzać.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) uwzględnia notatki slajdów w operacjach wyszukiwania, zastępowania i podświetlania na poziomie prezentacji.

Operacje z wyrażeniami regularnymi używają `System::Text::RegularExpressions::Regex`, więc reguły dopasowywania, takie jak rozróżnianie wielkości znaków i granice słów, są definiowane przez wyrażenie i jego opcje.

## **Zbierz informacje o dopasowaniach za pomocą callbacku**

Zaimplementuj [IFindResultCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifindresultcallback/), aby otrzymywać powiadomienie o każdym dopasowaniu. Jego metoda [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifindresultcallback/foundresult/) dostarcza powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Callback nie otrzymuje bezpośrednio numeru slajdu. Implementacja poniżej wyprowadza go z [ISlideComponent::get_Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecomponent/get_slide/) i obsługuje także tekst znaleziony w notatkach slajdu za pomocą [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotesslide/get_parentslide/). Opcjonalny numer slajdu pozwala temu samemu modelowi wyniku reprezentować tekst powiązany z innymi typami slajdów.

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

Dla operacji zastępowania, `FoundText` zawiera pierwotny dopasowany tekst, więc callback może dokładnie zapisać, które terminy zostały zastąpione.

## **Podświetl tekst**

Użyj metody [ITextFrame::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlighttext/), aby podświetlić dopasowania tekstu dosłownego w ramce tekstowej. Przekaż [ITextSearchOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/) aby kontrolować wyszukiwanie oraz callback do zbierania szczegółów dopasowań.

Poniższy przykład kodu podświetla wszystkie wystąpienia znaków **"try"** i następnie podświetla tylko pełne słowo **"to"**. Oba wyszukiwania zgłaszają swoje dopasowania do tego samego callbacku.

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

Wynik:

![Podświetlony tekst](highlighted_text.png)

## **Podświetl tekst przy użyciu wyrażeń regularnych**

Metoda [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlightregex/) podświetla dopasowania tekstu znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające siedem lub więcej znaków i zbiera każde dopasowanie:

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

Wynik:

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Podświetl tekst w całej prezentacji**

Użyj [IPresentation::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlighttext/) i [IPresentation::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlightregex/), aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla dosłowny termin oraz wszystkie adresy e‑mail, zachowując osobne kolekcje wyników dla obu wyszukiwań.

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

## **Zastąp tekst w ramce tekstowej**

Użyj [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) dla tekstu dosłownego i [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) dla zastępowania opartego na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast przebudowywać ramkę z prostego ciągu znaków.

Poniższy przykład standaryzuje wariant pisowni, a następnie zastępuje etykiety wersji. Ten sam callback rejestruje pierwotne terminy dopasowane przez obie operacje.

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

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zastępczego.

## **Zastąp tekst w całej prezentacji**

Użyj [IPresentation::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replacetext/) i [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replaceregex/), aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii oraz redakcji.

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

## **Grupuj dopasowania dla raportowania**

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania w celu audytu, raportowania lub przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a następnie według ramki tekstowej:

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

## **FAQ**

**Jak mogę przeszukać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Pobierz ramkę tekstową kształtu i wywołaj [ITextFrame::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) lub [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak mogę dopasować pełne słowa z prawidłową kapitalizacją?**

Wywołaj [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) i [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) z wartością `true` i przekaż te opcje do metody podświetlania lub zastępowania tekstu dosłownego. W przypadku wyrażeń regularnych zdefiniuj granice słów i rozróżnianie wielkości znaków bezpośrednio w `System::Text::RegularExpressions::Regex`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Wywołaj [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) z wartością `true` przy używaniu operacji tekstu dosłownego na poziomie prezentacji. Pokazana powyżej implementacja callbacku mapuje dopasowanie w notatce slajdu na jego numer slajdu nadrzędnego.

**Jak mogę stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż implementację [IFindResultCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifindresultcallback/) do operacji podświetlania lub zastępowania. Callback otrzymuje każde dopasowanie w trakcie wykonywania operacji, dzięki czemu aplikacja może przechowywać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową oraz wyprowadzony numer slajdu w celu późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) i [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) modyfikują dopasowany tekst wewnątrz istniejącej ramki tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamieniony tekst używa pożądanego stylu.