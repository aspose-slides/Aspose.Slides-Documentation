---
title: Szöveg keresése és cseréje PowerPoint prezentációkban C++-ban
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
description: "Szöveg keresése, kiemelése és cseréje PowerPoint prezentációkban, miközben az Aspose.Slides for C++ minden egyezését gyűjti."
---
## **Áttekintés**

Az Aspose.Slides for C++ kereshet, kiemelhet és cserélhet szöveget egy adott szövegkeretben vagy az egész prezentációban. Minden művelet értesítheti az alkalmazást minden egyezésről egy eredmény‑visszahívással. Ez lehetővé teszi a prezentáció frissítését, miközben audit‑naplót hozunk létre, amely tartalmazza a megtalált szöveget, annak környezetét, pozícióját, a szövegkeretet és a dia számát.

Ezek a lehetőségek hasznosak felülvizsgálat, censúra, terminológiai ellenőrzés, sablon‑tisztítás és automatizált jelentéskészítési munkafolyamatok esetén.

Az alább szereplő első példák egy „sample.pptx” nevű fájlt használnak, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **A keresési hatókör kiválasztása**

Használja az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) metódusait a művelet korlátozásához egy szövegkeretre. Használja az [IPresentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/) metódusait a prezentációban található összes alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Szöveg szó szerinti kiemelése | [ITextFrame::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlighttext/) |
| Reguláris kifejezés egyezéseinek kiemelése | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlightregex/) |
| Szó szerinti szöveg cseréje | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replacetext/) |
| Reguláris kifejezés egyezéseinek cseréje | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Szövegillesztés beállítása**

Szó szerinti szövegű műveletekhez használja az [ITextSearchOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/) lehetőséget a megfelelő illesztés szabályozásához:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) csak teljes szavakra korlátozza az egyezéseket.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) meghatározza, hogy a kis‑ és nagybetűk meg kell-e egyezzenek.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_includenotes/) a diák jegyzeteit is beleveszi a prezentáció‑szintű keresésbe, cserébe és kiemelésbe.

A reguláris kifejezéseken alapuló műveletek egy `System::Text::RegularExpressions::Regex` objektumot használnak, így a kis‑ és nagybetűk érzékenysége, valamint a szóhatárok a kifejezés és annak beállításai által vannak meghatározva.

## **Szövegkeret tulajdonosának meghatározása**

Az általános szövegfeldolgozó munkafolyamatok gyakran kapnak egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumot keresés, csere, érvényesítés vagy exportálás során. Használja a [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentshape/) és a [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentcell/) metódusokat a szövegkeret tulajdonosának megállapításához.

A várt értékek a tulajdonostól függnek:

| Szövegkeret tulajdonosa | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| AutoShape vagy más szöveges alak | A tulajdonos [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) | `nullptr` |
| Táblázat cella | `nullptr` | A tulajdonos [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/) |

Mindkét metódus csak olvasási navigációt biztosít. Meghívásuk nem mozgatja a szövegkeretet, és nem változtatja meg a tulajdonost. Az általános kódnak mindkét értéket ellenőriznie kell `nullptr`‑ra, és fel kell készülnie arra, hogy egyik tulajdonos sem állhat rendelkezésre.

Az alábbi példa a [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/getalltextframes/) segítségével iterál a prezentáció szövegkeretei között. Alakzatok esetén kiírja az alakzat nevét, a C++ futásidejű típusát és a tartalmazó diát. Táblázat cellák esetén a nulla‑bázisú oszlop‑ és sor‑koordinátákat valamint a tartalmazó diát jelzi.

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

SmartArt tartalom esetén iteráljon a [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) alakzatain, és érje el minden [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) elemet. A szövegkeret a [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentshape/) segítségével követhető vissza a kapcsolódó alakzatra, míg a [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr`‑t ad vissza. Emiatt a példában lévő alakzat‑ág is kezeli a SmartArt csomópontok szövegét.

## **Egyezések gyűjtése visszahívással**

Valósítsa meg az [IFindResultCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifindresultcallback/) interfészt, hogy minden egyezésről értesítést kapjon. A [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifindresultcallback/foundresult/) metódus a kapcsolódó szövegkeretet, a forrás‑szöveget, a megtalált szöveget és a pozíciót adja vissza.

A visszahívás nem kap közvetlenül dia‑számot. Az alábbi megvalósítás a [ISlideComponent::get_Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecomponent/get_slide/) alapján állapítja meg azt, és kezeli a diák jegyzeteiben talált szöveget is a [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotesslide/get_parentslide/) segítségével. Egy nullable dia‑szám lehetővé teszi, hogy ugyanaz a result‑modell a más típusú diákhoz kapcsolódó szöveget is reprezentálja.

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

Csere műveleteknél a `FoundText` tartalmazza az eredeti megtalált szöveget, így a visszahívás pontosan rögzítheti, mely kifejezéseket cserélték le.

## **Szöveg kiemelése**

Használja a [ITextFrame::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlighttext/) metódust a szó szerinti egyezések kiemelésére egy szövegkeretben. Adja át az [ITextSearchOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/) beállításait a keresés szabályozásához, és egy visszahívást az egyezések részleteinek gyűjtéséhez.

Az alábbi kódrészlet kiemeli az összes **„try”** karakterelőfordulást, majd csak a teljes **„to”** szót. Mindkét keresés azonos visszahívásra jelenti az egyezéseket.

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

// Az első diáról lekérdezi az első alakzatot.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Kiemeli a "try" minden előfordulását a szövegkeretben.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Kiemeli csak a "to" teljes szót.
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

## **Szöveg kiemelése reguláris kifejezéssel**

A [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlightregex/) metódus kiemeli a reguláris kifejezéssel megtalált szövegegyezéseket egy szövegkeretben.

Az alábbi kód kiemeli a hét vagy több karaktert tartalmazó összes szót, és minden egyezést összegyűjt.

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

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg kiemelése a teljes prezentációban**

Használja a [IPresentation::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlighttext/) és a [IPresentation::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/highlightregex/) metódusokat a prezentáció összes alkalmazható szövegkeretének kereséséhez. Az alábbi példa egy szó szerinti kifejezést és az összes e‑mail címet emeli ki, miközben külön eredménygyűjteményeket tart fenn a két kereséshez.

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

Használja az [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/) metódust szó szerinti szöveghez, valamint az [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/) metódust mintára alapozott cserehez. Ezek a metódusok a megtalált szöveget a meglévő szövegkereten belül módosítják, megőrizve a környező rész formázását a tiszta karakterláncból történő újraépítés helyett.

Az alábbi példa egységesíti egy helyesírási variánst, majd cseréli a verziócímkéket. Ugyanaz a visszahívás naplózza mindkét művelet által megtalált eredeti kifejezéseket.

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

Ha egy egyezés különböző formázású részeket érint, ellenőrizze a kimenetet, hogy megbizonyosodjon, mely formázás legyen alkalmazva a helyettesítő szövegre.

## **Szöveg cseréje a teljes prezentációban**

Használja az [IPresentation::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replacetext/) és az [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/replaceregex/) metódusokat a műveletek prezentáció‑szintű alkalmazásához. Ez hasznos sablon‑tisztításhoz, terminológiai frissítésekhez és censúrához.

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

## **Egyezések csoportosítása jelentéshez**

Mivel minden eredmény tárolja a dia‑számot és a szövegkeretet, az alkalmazások csoportosíthatják az egyezéseket audit, jelentés vagy felülvizsgálati munkafolyamatok céljából. Az alábbi példa a gyűjtött eredményeket először dián, majd szövegkeretenként csoportosítja:

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

## **GYIK**

**Hogyan kereshetek csak egy szövegdobozban az egész prezentáció helyett?**

Szerezze meg az alakzat szövegkeretét, és hívja meg a [ITextFrame::HighlightText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/) vagy [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/) metódust azon a szövegkereten. A prezentáció‑szintű metódusok az összes alkalmazható szövegkeretet feldolgozzák.

**Hogyan illeszthetem csak a teljes szavakat a megfelelő nagybetűkkel?**

Hívja meg a [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) és a [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) metódusokat `true` értékkel, és adja át ezeket a szó szerinti kiemelés vagy csere metódusának. Reguláris kifejezések esetén határozza meg a szóhatárokat és a kis‑nagybetű érzékenységet a `System::Text::RegularExpressions::Regex` kifejezésben.

**Tartalmazhatja a keresés és csere a diák jegyzeteiben lévő szöveget is?**

Igen. Hívja meg a [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextsearchoptions/set_includenotes/) metódust `true`‑val, amikor prezentáció‑szintű szó szerinti műveletet használ. A fent bemutatott visszahívás egy jegyzet‑dián talált egyezést visszafordít a szülő dia‑számra.

**Hogyan készíthetek jelentést anélkül, hogy a prezentációt újra beolvasnám?**

Adjon át egy [IFindResultCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifindresultcallback/) megvalósítást a kiemelés vagy csere műveletnek. A visszahívás minden egyezést megkap a művelet futása közben, így az alkalmazás tárolhatja a forrás‑szöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott dia‑számot későbbi csoportosításhoz vagy exportáláshoz.

**Megőrzi a szöveg cseréje a formázását?**

Az [ITextFrame::ReplaceText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replacetext/) és az [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/replaceregex/) módosítja a megtalált szöveget a meglévő szövegkereten belül, és megtartja a környező rész formázását. Ha egy egyezés különböző formázású részeket fed le, ellenőrizze az eredményt, hogy a helyettesítés a kívánt stílust alkalmazza.