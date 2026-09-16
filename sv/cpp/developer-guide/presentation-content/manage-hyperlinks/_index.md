---
title: Hantera presentationshyperlänkar i C++
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/cpp/manage-hyperlinks/
keywords:
- lägga till URL
- lägga till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildspelshyperlänk
- formhyperlänk
- bildhyperlänk
- videohyperlänk
- modifierbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++, med C++-exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller en mediaruta.
* Navigera till en annan bild, till exempel från ett innehållsförteckning.

Aspose.Slides för C++ låter dig lägga till dessa länkar, styra deras utseende och ljud, uppdatera deras inställningar och ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller textrutornivå.

{{% alert color="info" title="Obs" %}}
Du kan även redigera presentationer med den [gratis online Aspose PowerPoint‑redigeraren](https://products.aspose.app/slides/sv/editor).
{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webb‑URL till text, en form eller en mediaruta. Det element du tilldelar hyperlänken bestämmer det klickbara området: en textdel länkar den markerade texten, medan en form eller ruta länkar bildobjektet.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, skapa en [Hyperlink](https://reference.aspose.com/slides/sv/cpp/aspose.slides/hyperlink/) och tilldela den med textdelens [set_HyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/set_hyperlinkclick/)‑metod, som visas nedan. Endast den delen av texten blir klickbar.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
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

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Lägg till URL‑hyperlänkar till former och mediarutor**

För att göra en form eller ruta klickbar, använd dess [set_HyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/set_hyperlinkclick/)‑metod. Hyperlänken tillhör själva objektet snarare än en textdel inuti det.

Samma tillvägagångssätt gäller för bild-, audio‑ och videorutor: tilldela hyperlänken till rutan och använd [set_Tooltip](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_tooltip/) för att lägga till en tipsruta om så önskas.

Följande exempel gör en rektangel klickbar:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [SetInternalHyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) för att länka texten ”Page 2” på den första bilden till den andra bilden.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Formatera hyperlänkar**

### **Färg**

Metoden [set_ColorSource](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_colorsource/) för [IHyperlink](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänksfärg eller textdelens formatering. För att tillämpa en anpassad textfärg, välj [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/hyperlinkcolorsource/) och sätt delens ifyllningsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner använder inte denna inställning.

Följande exempel lägger till två text‑hyperlänkar på samma bild. Den första använder en röd textfyllning, medan den andra behåller standardhyperlänksfärgen.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **Ljud**

En hyperlänk kan spela upp ett ljud vid aktivering eller stoppa ett ljud som redan spelas. Använd följande metoder för att konfigurera dessa beteenden:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_sound/) specificerar ljudet som är associerat med hyperlänken.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) styr om aktivering av hyperlänken stoppar föregående ljud.

#### **Lägg till ett hyperlänksljud**

Följande exempel laddar `sampleaudio.wav` och associerar det med en knapp på den första bilden. När knappen klickas spelas ljudet och presentationen går till nästa bild. En annan form på samma bild stoppar föregående ljud vid klick utan att navigera någonstans.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Extrahera ett hyperlänksljud**

Följande exempel öppnar presentationen som skapades ovan och läser ljudet för den första formens hyperlänk till minnet via [get_Sound](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/get_sound/) och [get_BinaryData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Tipsruta och interaktionsinställningar**

Du kan uppdatera följande [IHyperlink](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/)‑inställningar via dessa metoder efter att du tilldelat en hyperlänk till text eller en form:

- [set_Tooltip](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_tooltip/) anger den text som en betraktare kan visa som en tipsruta för länken.
- [set_TargetFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_targetframe/) specificerar mål‑ramen inom ett föräldra‑HTML‑frameset, när tillämpligt.
- [set_History](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_history/) styr om aktivering av länken lägger till dess destination i listan över visade hyperlänkar.
- [set_HighlightClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/set_highlightclick/) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [GetAnyHyperlinks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) för att samla hyperlänkbehållare, inklusive länkar på textdelar, innan de ändras. Följande exempel tar bort båda aktiveringstyperna från den första bilden. För att bara ta bort en typ, anropa endast [RemoveHyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) eller [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); att ta bort en klickåtgärd tar inte bort dess mus‑över‑motsvarighet.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

För villkorslös borttagning tar [RemoveAllHyperlinks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) bort båda aktiveringstyperna i det valda omfånget i ett anrop. För selektiv rensning och täckning av masters, layouter och anteckningar, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bygg ett komplett hyperlänkinventarium**

Innan en presentation distribueras bör du inventera dess interaktiva åtgärder samt dess webb­länkar. [GetAnyHyperlinks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returnerar [IHyperlinkContainer](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkcontainer/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [get_HyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) och [get_HyperlinkMouseOver](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) på varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att bara skanna hyperlänkar på form‑nivå kan missa länkar som är knutna till textdelar. Gör en sökfråga på lämpligt omfång istället och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentations‑, bild‑ och textrutrums‑omfång**

Gränssnittet [IHyperlinkQueries](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/) är tillgängligt via [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) och [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Varje omfång stödjer samma frågor:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) returnerar behållare med en klickåtgärd.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) returnerar behållare med en mus‑över‑åtgärd.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returnerar behållare med någon av eller båda åtgärderna.

Följande exempel skapar `hyperlink-audit-input.pptx` med en extern klick‑länk, en fil‑mus‑över‑länk, intern bildnavigering, en text‑mus‑över‑länk och en makro‑åtgärd. Det kör inte någon av dessa åtgärder. Samma tre frågor fungerar i varje omfång; räkningarna beskriver behållare, inte totala antalet åtgärder. Textrutrum‑omfånget exkluderar de egna länkarna på den omgivande formen.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

För detta exempel rapporterar presentations‑ och bild‑frågor tre klick‑behållare, två mus‑över‑behållare och tre behållare med någon av åtgärderna. Textrutrum‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [IHyperlink::get_ActionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/get_actiontype/) för att tolka en åtgärd innan du tolkar dess destination. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/hyperlinkactiontype/) täcker mer än webbnavigation:

| Värden | Betydelse för en revision |
| --- | --- |
| `Hyperlink` | Extern hyperlänk; inspektera URL och dess schema. |
| `JumpSpecificSlide` | Intern navigering till en viss bild. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Inbyggd presentatiosnavigering, löst i bildspels‑sammanhang. |
| `JumpEndShow`, `StartCustomSlideShow` | Avsluta aktuellt bildspel eller starta ett anpassat bildspel. |
| `StartMacro` | Utför ett makro. |
| `StartProgram` | Starta ett program. |
| `OpenFile`, `OpenPresentation` | Öppna en fil eller en annan presentation; granska separat från webbadresser. |
| `StartStopMedia` | Starta eller stoppa mediuppspelning. |
| `NoAction`, `Unknown` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer via [get_ExternalUrl](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/get_externalurl/) och specifika interna destinationer via [get_TargetSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/get_targetslide/). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara [get_ExternalUrlOriginal](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) när den skiljer sig från den normaliserade URL:en, och inkludera tipsrutan som returneras av [get_Tooltip](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlink/get_tooltip/) när den finns.

### **Rapportera, sanera och verifiera hyperlänkar**

Följande C++‑exempel läser en befintlig presentation (använd filen som skapades ovan), skriver `hyperlink-audit.json`, tillämpar en policy, sparar `hyperlink-sanitized.pptx` och öppnar den igen för att kontrollera båda aktiveringstyperna igen. Det samlar behållare innan de ändras och använder pekaridentitet för att undvika att bearbeta samma behållare två gånger. Presentationsfrågor täcker vanliga bilder; för ett paket‑omfattande inventarium frågar den också explicit masters, layouter, anteckningar samt antecknings‑ och handout‑masters när de finns.

Rapporten registrerar ett ett‑baserat bildindex och [get_SlideId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/get_slideid/) där det är tillgängligt. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecomponent/get_slide/) levererar den ägande bilden för stödjade behållare. Masters, layouter och anteckningar har inget vanligt bildindex och identifieras av sitt omfång. Form‑behållare och text‑del‑formateringsbehållare märks separat; andra behållartyper behåller sitt kör‑tids‑typnamn. Varje behållare får ett rapport‑lokalt ID så att dess två åtgärder kan korreleras.

Denna avsiktligt restriktiva applikationspolicy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bildmål. Den avvisar makron, program, fil‑åtgärder, andra bildspels‑åtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policy‑beslut, inte ett säkerhets­betyg från Aspose.Slides. HTTPS ensam ger ingen förtroende: lägg till värd‑tillåtelselistor och andra kontroller för din applikation. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För korrigering stöder behållarens [get_HyperlinkManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) och [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Här ersätts förbjudna externa klick‑länkar med en fast HTTPS‑landningssida; andra förbjudna klick‑ och mus‑över‑åtgärder tas bort oberoende. Sätt `replaceExternalClicks` till `false` för att ta bort alla policy‑överträdelser istället. Välj en applikationsägad ersättningssida innan distribution.

Exportflaggan i rapporten använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller specifik bildhopp som potentiellt otillåtet. Det är en gransknings‑hint, inte ett funktions‑test eller en garanti för att o‑flagade länkar överlever export. Stödda [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/)‑ och [HTML](/slides/sv/cpp/convert-powerpoint-to-html/)‑exporter kan bevara hyperlänkar, beroende på åtgärd, exportalternativ och läsare. Raster‑[images](/slides/sv/cpp/convert-powerpoint-to-png/) och [video](/slides/sv/cpp/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid granskning för dessa utdata.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Med den indata som skapades ovan innehåller rapporten fem åtgärdsrader. Fil‑mus‑över‑länken och makro‑klick‑åtgärden tas bort, medan HTTPS‑länkarna och den interna bildnavigeringen kvarstår. Verifieringen skriver ut noll förbjudna åtgärder. En indata som innehåller en förbjuden extern klick‑URL demonstrerar också ersättnings‑grenen. En behållare med en tillåten klick‑åtgärd och en förbjuden mus‑över‑åtgärd behåller sin klick‑åtgärd.

Denna selektiva rensning skiljer sig från [RemoveAllHyperlinks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), som tar bort båda aktiveringstyperna i hela det valda omfånget oavsett policy. Verifieringen här kontrollerar bara hyperlänksåtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **Vanliga frågor**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Avsnitt i PowerPoint grupperar bilder, men en intern hyperlänk riktar sig till en enskild bild. För att skapa navigering till ett avsnitt, länka till den första bilden i avsnittet.

**Kan jag fästa en hyperlänk på element i en master‑bild så att den fungerar på alla bilder?**

Ja. Element i master‑bild och layout stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelet på bilder som använder motsvarande master eller layout.

**Behålls hyperlänkar när man exporterar till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; raster‑bilder och video kan inte. Se export‑överväganden i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).