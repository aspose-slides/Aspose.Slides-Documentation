---
title: "Wyszukiwanie i zastępowanie tekstu w prezentacjach PowerPoint w C++"
linktitle: "Wyszukiwanie i zastępowanie tekstu"
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
description: "Wyszukuj, podświetlaj i zastępuj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Aspose.Slides for C++ może wyszukiwać, podświetlać i zastępować tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może również powiadomić aplikację o każdym dopasowaniu za pośrednictwem zwrotnego wywołania wyniku. Umożliwia to aktualizację prezentacji i jednoczesne tworzenie śladu audytu zawierającego dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redakcji, weryfikacji terminologii, czyszczeniu szablonów oraz automatycznych przepływach raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [IPresentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/) aby przetworzyć cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl tekst dosłowny | [ITextFrame::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlighttext/) |
| Podświetl dopasowania wyrażeń regularnych | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlightregex/) |
| Zastąp tekst dosłowny | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replacetext/) |
| Zastąp dopasowania wyrażeń regularnych | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Skonfiguruj dopasowywanie tekstu**

Dla operacji tekstu dosłownego użyj [ITextSearchOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/) do kontrolowania dopasowania:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) ogranicza dopasowania do pełnych słów.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) określa, czy wielkość znaków musi się zgadzać.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) uwzględnia notatki slajdów w operacjach wyszukiwania, zastępowania i podświetlania na poziomie prezentacji.

Operacje wyrażeń regularnych używają `System::Text::RegularExpressions::Regex`, więc zasady dopasowywania, takie jak rozróżnianie wielkości liter i granice wyrazów, są definiowane przez wyrażenie i jego opcje.

## **Identyfikuj właściciela ramki tekstowej**

Ogólne przepływy przetwarzania tekstu często otrzymują [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) podczas wyszukiwania, zastępowania, walidacji lub eksportu tekstu. Użyj [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentshape/) i [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentcell/) aby określić, który obiekt prezentacji jest właścicielem ramki tekstowej.

| Właściciel ramki tekstowej | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| AutoShape lub inny kształt zawierający tekst | Właściciel [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) | `nullptr` |
| Komórka tabeli | `nullptr` | Właściciel [ICell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icell/) |

Obie metody zapewniają nawigację tylko do odczytu. Wywołanie ich nie przenosi ramki tekstowej ani nie zmienia jej właściciela. Ogólny kod powinien sprawdzić oba wartości pod kątem `nullptr` i obsłużyć możliwość, że żaden właściciel nie jest dostępny.

Poniższy przykład używa [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/getalltextframes/) do iteracji przez ramki tekstowe w prezentacji. Dla kształtów raportuje nazwę kształtu, typ w czasie wykonywania C++ oraz slajd, w którym się znajduje. Dla komórek tabeli raportuje współrzędne kolumny i wiersza (liczone od zera) oraz slajd, w którym się znajdują.

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

Dla treści SmartArt iteruj przez kształty w [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) i uzyskaj dostęp do każdego [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Ramka tekstowa może być powiązana z jej kształtem za pomocą [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentshape/), podczas gdy [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentcell/) zwraca `nullptr`. Dlatego gałąź kształtu w przykładzie obsługuje również tekst z węzłów SmartArt.

## **Zbieraj informacje o dopasowaniach za pomocą wywołania zwrotnego**

Zaimplementuj [IFindResultCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifindresultcallback/) aby otrzymywać powiadomienie o każdym dopasowaniu. Jego metoda [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifindresultcallback/foundresult/) dostarcza powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje numeru slajdu bezpośrednio. Implementacja poniżej wyprowadza go z [ISlideComponent::get_Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecomponent/get_slide/) i dodatkowo obsługuje tekst znaleziony w notatkach slajdu poprzez [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotesslide/get_parentslide/). Nullable (pusty) numer slajdu pozwala temu samemu modelowi wyniku reprezentować tekst powiązany z innymi typami slajdów.

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

Dla operacji zastępowania `FoundText` zawiera oryginalny dopasowany tekst, więc wywołanie zwrotne może dokładnie zanotować, które terminy zostały zastąpione.

## **Podświetl tekst**

Użyj metody [ITextFrame::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlighttext/) aby podświetlić dopasowania tekstu dosłownego w ramce tekstowej. Przekaż [ITextSearchOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/) aby kontrolować wyszukiwanie oraz wywołanie zwrotne do zbierania szczegółów dopasowania.

Poniższy przykład podświetla wszystkie wystąpienia znaków **"try"**, a następnie podświetla tylko pełne słowo **"to"**. Oba wyszukiwania raportują swoje dopasowania do tego samego wywołania zwrotnego.

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

Użyj [IPresentation::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlighttext/) i [IPresentation::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/highlightregex/) aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla termin dosłowny oraz wszystkie adresy e‑mail, zachowując oddzielne kolekcje wyników dla obu wyszukiwań.

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

Użyj [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) dla tekstu dosłownego i [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) dla zastępowania opartego na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce, zachowując formatowanie otaczających fragmentów zamiast przebudowywać ramkę z czystego ciągu znaków.

Poniższy przykład standaryzuje wariant pisowni, a następnie zastępuje etykiety wersji. To samo wywołanie zwrotne rejestruje oryginalne terminy dopasowane w obu operacjach.

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

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie ma zostać zastosowane do tekstu zastępczego.

## **Zastąp tekst w całej prezentacji**

Użyj [IPresentation::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replacetext/) i [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/replaceregex/) aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacjach terminologii i redakcji.

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

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania w celu audytu, raportowania lub przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a potem według ramki tekstowej:

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

Uzyskaj ramkę tekstową kształtu i wywołaj [ITextFrame::HighlightText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) lub [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) na tej ramce tekstowej. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe.

**Jak mogę dopasować pełne słowa z prawidłową wielkością liter?**

Wywołaj [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) i [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) z wartością `true`, i przekaż opcje do metody podświetlania lub zastępowania tekstu dosłownego. Dla wyrażeń regularnych zdefiniuj granice słów i rozróżnianie wielkości liter w samym `System::Text::RegularExpressions::Regex`.

**Czy wyszukiwanie i zastępowanie może obejmować tekst w notatkach slajdu?**

Tak. Wywołaj [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextsearchoptions/set_includenotes/) z wartością `true` podczas używania operacji tekstu dosłownego na poziomie prezentacji. Implementacja wywołania zwrotnego przedstawiona powyżej mapuje dopasowanie w notatce slajdu z powrotem na numer slajdu nadrzędnego.

**Jak mogę stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż implementację [IFindResultCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifindresultcallback/) do operacji podświetlania lub zastępowania. Wywołanie zwrotne otrzymuje każde dopasowanie podczas działania operacji, więc aplikacja może przechowywać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową i wyprowadzony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zastępowanie tekstu zachowuje jego formatowanie?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replacetext/) i [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/replaceregex/) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamiana używa pożądanego stylu.