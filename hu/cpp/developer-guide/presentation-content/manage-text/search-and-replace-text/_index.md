---
title: Szöveg keresése és cseréje PowerPoint prezentációkban C++
linktitle: Szöveg keresése és cseréje
type: docs
weight: 55
url: /hu/cpp/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- eredmény visszahívás
- szövegkeret
- audit jelentés
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Keresés, kiemelés és szövegcsere PowerPoint prezentációkban, miközben minden egyezést összegyűjt az Aspose.Slides for C++ használatával."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes keresni, kiemelni és cserélni a szöveget egyetlen szövegkeretben vagy egy egész prezentációban. Minden művelet értesítheti az alkalmazást minden egyezésről egy eredmény‑visszahívással. Ez lehetővé teszi a prezentáció frissítését, miközben egy audit‑nyomot építünk, amely tartalmazza a megtalált szöveget, annak környezetét, pozícióját, szövegkeretét és a dia számát.

Ezek a képességek hasznosak felülvizsgálat, pirosítás, terminológiai ellenőrzés, sablon‑tisztítás és automatizált jelentéskészítési munkafolyamatok során.

Az első példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **A keresés hatókörének kiválasztása**

Használja az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) metódusait, hogy egy műveletet egy szövegkeretre korlátozzon. Használja az [IPresentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/) metódusait, hogy a prezentáció minden alkalmazható szövegét feldolgozza.

| Művelet | Egy szövegkeret | Teljes bemutató |
|---|---|---|
| Literalszöveg kiemelése | [ITextFrame::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlighttext/) |
| Reguláris kifejezés találatainak kiemelése | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlightregex/) |
| Literalszöveg cseréje | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replacetext/) |
| Reguláris kifejezés találatainak cseréje | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Szövegillesztés beállítása**

Literalszöveg‑műveletekhez használja az [ITextSearchOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/)‑t a találatok szabályozásához:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) korlátozza a találatokat teljes szavakra.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) szabályozza, hogy a betűkészlet-érzékenység kötelező legyen-e.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_includenotes/) belefoglalja a dia megjegyzéseit a prezentációszintű keresés, csere és kiemelés műveletekbe.

A reguláris‑kifejezés műveletek egy `System::Text::RegularExpressions::Regex`‑et használnak, ezért a szabályok (például nagybetű‑érzékenység és szóhatárok) a kifejezésben és annak beállításaiban vannak definiálva.

## **Gyűjtse össze a találatinformációkat visszahívással**

Valósítsa meg az [IFindResultCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifindresultcallback/)‑t, hogy minden találatról értesítést kapjon. A [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifindresultcallback/foundresult/) metódusa visszaadja a kapcsolódó szövegkeretet, a forrásszöveget, a megtalált szöveget és a találat helyét.

A visszahívás nem kap közvetlenül dia‑számot. Az alábbi megvalósítás a [ISlideComponent::get_Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecomponent/get_slide/)‑ból nyeri ki, és kezeli a dia megjegyzéseiben található szöveget is a [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotesslide/get_parentslide/) segítségével. Egy nullable dia‑szám lehetővé teszi, hogy ugyanaz a modell más dia‑típusok szövegét is reprezentálja.

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

Csere‑műveletek esetén a `FoundText` az eredeti megtalált szöveget tartalmazza, így a visszahívás pontosan rögzítheti, mely kifejezések lettek cserélve.

## **Szöveg kiemelése**

Használja az [ITextFrame::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlighttext/) metódust, hogy literál szöveggel megegyező darabokat kiemeljen egy szövegkeretben. Adja át az [ITextSearchOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/)‑t a keresés szabályozásához, valamint egy visszahívást a találati adatok gyűjtéséhez.

Az alábbi kódrészlet kiemeli a **„try”** karakterlánc összes előfordulását, majd csak a teljes **„to”** szót. Mindkét keresés ugyanarra a visszahívásra jelenti be a találatokat.

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

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

Az [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlightregex/) metódus kiemeli a reguláris kifejezéssel megtalált szövegeket egy szövegkeretben.

Az alábbi kód kiemeli az összes olyan szót, amely legalább hét karaktert tartalmaz, és minden találatot gyűjt:

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

Az eredmény:

![A kiemelt szöveg reguláris kifejezéssel](highlighted_text_using_regex.png)

## **Szöveg kiemelése egy prezentációban**

Használja a [IPresentation::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlighttext/) és a [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlightregex/) metódusokat, hogy a prezentáció összes alkalmazható szövegkeretét átvizsgálja. Az alábbi példa egy literál kifejezést és az összes e‑mail címet emeli ki, miközben külön gyűjti az eredményeket a két kereséshez.

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

## **Szöveg cseréje egy szövegkeretben**

Használja az [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/)‑t literál szöveghez, illetve az [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/)‑t mintával alapú cserehez. Ezek a metódusok a megtalált szöveget a meglévő szövegkereten belül módosítják, megőrizve a környező rész formázását a nyers karakterláncról való újraépítés helyett.

Az alábbi példa egységesíti egy helyesírási változatot, majd verziócímkéket cserél. Ugyanaz a visszahívás rögzíti az eredeti, mindkét művelet által megtalált kifejezéseket.

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

Ha egy találat különböző formázású részeket fed le, ellenőrizze a kimenetet, hogy melyik formázást kell alkalmazni a csere‑szövegre.

## **Szöveg cseréje egy prezentációban**

Használja a [IPresentation::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replacetext/) és a [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replaceregex/) metódusokat, hogy ugyanazokat a műveleteket a teljes prezentáción végrehajtsa. Ez hasznos sablon‑tisztításhoz, terminológiai frissítésekhez és pirosításhoz.

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

## **Találatok csoportosítása jelentéshez**

Mivel minden eredmény tárolja a dia számát és a szövegkeretet, az alkalmazások csoportosíthatják a találatokat audit, jelentés vagy felülvizsgálati munkafolyamatok céljából. Az alábbi példa először dián, majd szövegkeretenként csoportosítja a gyűjtött eredményeket:

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

**Hogyan kereshetek csak egy szövegdobozban a teljes prezentáció helyett?**

Szerezze meg a forma szövegkeretét, és hívja meg az [ITextFrame::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/) vagy [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/) metódusokat azon a szövegkereten. A prezentáció‑szintű metódusok az összes alkalmazható szövegkeretet dolgozzák fel helyette.

**Hogyan illeszthetek teljes szavakat a helyes nagybetűkkel?**

Hívja meg a [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) és a [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) metódusokat `true` értékkel, majd adja át az opciókat egy literalszöveg‑kiemelő vagy -csere metódusnak. Reguláris kifejezéseknél határozza meg a szóhatárokat és a nagybetű‑érzékenységet magában a `System::Text::RegularExpressions::Regex`‑ben.

**A keresés és csere magában foglalhatja a diák megjegyzéseiben lévő szöveget?**

Igen. Hívja meg a [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_includenotes/)‑t `true` értékkel, amikor prezentáció‑szintű literalszöveg‑műveletet használ. A fent bemutatott visszahívás‑megvalósítás egy megjegyzés‑dián található egyezést visszavezet a szülődia számához.

**Hogyan készíthetek jelentést anélkül, hogy a prezentációt újra átnézném?**

Adjon át egy [IFindResultCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifindresultcallback/) megvalósítást a kiemelő vagy csere műveletnek. A visszahívás minden találatot megkap a művelet futása közben, így az alkalmazás el tudja tárolni a forrásszöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott dia‑számot a későbbi csoportosításhoz vagy exportáláshoz.

**Megőrzi-e a szöveg formázása a csere során?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/) és [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/) a megtalált szöveget a meglévő szövegkereten belül módosítják, és megtartják a környező rész formázását. Ha egy találat különböző formázású részeket fed le, ellenőrizze az eredményt, hogy a csere a kívánt stílust használja.