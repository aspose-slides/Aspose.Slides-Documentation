---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint v C++
linktitle: Vyhledávání a nahrazování textu
type: docs
weight: 55
url: /cs/cpp/search-and-replace-text/
keywords:
- vyhledat text
- zvýraznit text
- nahradit text
- regulární výraz
- zpětné volání výsledku
- textový rámec
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint a současně shromažďujte každou shodu pomocí Aspose.Slides pro C++."
---
## **Přehled**

Aspose.Slides pro C++ umí vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámečku nebo v celé prezentaci. Každá operace může také upozornit aplikaci na každý výsledek pomocí zpětného volání s výsledkem. To umožňuje aktualizovat prezentaci a současně vytvořit auditní záznam obsahující nalezený text, jeho kontext, pozici, textový rámec a číslo snímku.

Tyto možnosti jsou užitečné pro revizi, redakci, kontrolu terminologie, úklid šablon a automatizované pracovní postupy reportování.

V prvních příkladech níže používáme soubor nazvaný "sample.pptx", který obsahuje jedinou textovou položku na prvním snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) k omezení operace na jeden textový rámec. Použijte metody na [IPresentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/) ke zpracování veškerého relevantního textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Základní zvýraznění textu | [ITextFrame::HighlightText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/highlighttext/) |
| Zvýraznění shod regulárního výrazu | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/highlightregex/) |
| Nahrazení doslovného textu | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/replacetext/) |
| Nahrazení shod regulárního výrazu | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Nastavení shody textu**

Pro operace s doslovným textem použijte [ITextSearchOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/) k řízení shody:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) omezuje shody na celá slova.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) řídí, zda se musí shodovat velikost písmen.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/set_includenotes/) zahrnuje poznámky ke snímkům do vyhledávání, nahrazování a zvýrazňování na úrovni celé prezentace.

Operace s regulárním výrazem používají `System::Text::RegularExpressions::Regex`, takže pravidla shody, jako je rozlišování velikosti písmen a hranice slov, jsou definována výrazem a jeho možnostmi.

## **Sbírat informace o shodách pomocí zpětného volání**

Implementujte [IFindResultCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifindresultcallback/) pro získání oznámení o každé shodě. Jeho metoda [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifindresultcallback/foundresult/) poskytuje související textový rámec, zdrojový text, nalezený text a pozici shody.

Zpětné volání nedostává číslo snímku přímo. Níže uvedená implementace jej odvozuje z [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecomponent/get_slide/) a také zpracovává text nalezený v poznámkách ke snímku prostřednictvím [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inotesslide/get_parentslide/). Číselná hodnota, která může být null, umožňuje stejnému modelu výsledku reprezentovat text spojený s jinými typy snímků.

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

Pro operace nahrazování `FoundText` obsahuje původní nalezený text, takže zpětné volání může přesně zaznamenat, které termíny byly nahrazeny.

## **Zvýraznit text**

Použijte metodu [ITextFrame::HighlightText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlighttext/) k zvýraznění doslovných shod v textovém rámci. Předávejte [ITextSearchOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/) pro řízení vyhledávání a zpětné volání pro sběr podrobností o shodách.

Ukázkový kód níže zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**. Obě vyhledávání zaznamenají své shody do stejného zpětného volání.

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

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznit text pomocí regulárních výrazů**

Metoda [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlightregex/) zvýrazní textové shody nalezené regulárním výrazem v textovém rámci.

Následující kód zvýrazní všechna slova obsahující sedm a více znaků a shromáždí každou shodu:

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

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Zvýraznit text v celé prezentaci**

Použijte [IPresentation::HighlightText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/highlighttext/) a [IPresentation::HighlightRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/highlightregex/) k prohledání všech relevantních textových rámců v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy, přičemž zachová oddělené kolekce výsledků pro obě vyhledávání.

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

## **Nahradit text v textovém rámci**

Použijte [ITextFrame::ReplaceText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replacetext/) pro doslovný text a [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replaceregex/) pro nahrazování na základě vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámci, který si zachovává formátování okolních částí místo přestavby rámce z prostého řetězce.

Následující příklad standardizuje variantu pravopisu a poté nahradí štítky verzí. Stejné zpětné volání zaznamenává původní termíny, které byly nalezeny v obou operacích.

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

Pokud jedna shoda zahrnuje části s různým formátováním, zkontrolujte výstup a potvrďte, které formátování by se mělo použít na nahrazený text.

## **Nahradit text v celé prezentaci**

Použijte [IPresentation::ReplaceText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/replacetext/) a [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/replaceregex/) k provedení stejných operací v celé prezentaci. To je užitečné pro úklid šablon, aktualizaci terminologie a redakci.

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

## **Seskupit shody pro reportování**

Protože každý výsledek ukládá číslo snímku a textový rámec, mohou aplikace shody seskupit pro audit, reportování nebo revizní workflow. Následující příklad seskupí shromážděné výsledky nejprve podle snímku a poté podle textového rámce:

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

## **Často kladené otázky**

**Jak mohu hledat pouze v jednom textovém poli místo celé prezentace?**

Získejte textový rámec daného tvaru a zavolejte na něm [ITextFrame::HighlightText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replacetext/) nebo [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replaceregex/). Metody na úrovni celé prezentace zpracovávají všechny relevantní textové rámy.

**Jak mohu shodovat celá slova se správnou kapitalizací?**

Zavolejte [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) a [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) s hodnotou `true` a předávejte tyto možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte hranice slov a citlivost na velikost písmen přímo v `System::Text::RegularExpressions::Regex`.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Zavolejte [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextsearchoptions/set_includenotes/) s hodnotou `true` při použití operace doslovného textu na úrovni celé prezentace. Implementace zpětného volání uvedená výše mapuje shodu v poznámce snímku zpět na číslo jeho nadřazeného snímku.

**Jak mohu vytvořit report bez druhého procházení prezentace?**

Předávejte implementaci [IFindResultCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifindresultcallback/) do operace zvýraznění nebo nahrazení. Zpětné volání obdrží každou shodu během provádění operace, takže aplikace může uložit zdrojový text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupení nebo export.

**Zachovává nahrazování textu jeho formátování?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replacetext/) a [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/replaceregex/) upravují nalezený text v existujícím textovém rámci a zachovávají formátování okolních částí. Pokud shoda zahrnuje části s různým formátováním, zkontrolujte výsledek, aby bylo zajištěno, že nahrazený text použije požadovaný styl.