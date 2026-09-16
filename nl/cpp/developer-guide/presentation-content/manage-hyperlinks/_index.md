---
title: Beheer presentatie‑hyperlinks in C++
linktitle: Beheer hyperlinks
type: docs
weight: 20
url: /nl/cpp/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst‑hyperlink
- dia‑hyperlink
- vorm‑hyperlink
- afbeeldings‑hyperlink
- video‑hyperlink
- bewerkbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Hyperlinks toevoegen, opmaken, bijwerken en verwijderen in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor C++, met C++‑voorbeelden."
---
## **Inleiding**

Een hyperlink verbindt presentatiewaarde met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks meestal twee doelen:

* Open een website vanuit tekst, een vorm of een mediaraam.
* Navigeer naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for C++ stelt u in staat deze links toe te voegen, hun uiterlijk en geluid te regelen, hun instellingen bij te werken en ze te verwijderen. De onderstaande voorbeelden tonen hoe u kunt werken met hyperlinks op individuele elementen en hoe u hyperlinks kunt benaderen op presentatie-, dia- of tekstframe‑niveau.

{{% alert color="info" title="Note" %}}
U kunt ook presentaties bewerken met de [gratis online Aspose PowerPoint‑editor](https://products.aspose.app/slides/nl/editor).
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediaraam. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstgedeelte maakt de geselecteerde tekst klikbaar, terwijl een vorm of raam het dia‑object koppelt.

### **URL‑hyperlinks toevoegen aan tekst**

Om tekst aan een website te koppelen, maak een [Hyperlink](https://reference.aspose.com/slides/nl/cpp/aspose.slides/hyperlink/) aan en wijs deze toe via de [set_HyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/set_hyperlinkclick/)‑methode van het tekstgedeelte, zoals hieronder weergegeven. Alleen dat tekstgedeelte wordt klikbaar.

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

### **URL‑hyperlinks toevoegen aan vormen en mediacaders**

Om een vorm of raam klikbaar te maken, gebruik de [set_HyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/set_hyperlinkclick/)‑methode. De hyperlink behoort tot het object zelf en niet tot een tekstgedeelte daarin.

Dezelfde aanpak geldt voor afbeelding‑, audio‑ en video‑frames: wijs de hyperlink toe aan het frame en gebruik [set_Tooltip](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_tooltip/) om indien nodig een tip toe te voegen.

Het volgende voorbeeld maakt een rechthoek klikbaar:

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

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het volgende voorbeeld gebruikt [SetInternalHyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

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

## **Hyperlinks opmaken**

### **Kleur**

De [set_ColorSource](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_colorsource/)‑methode van [IHyperlink](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie gebruikt of de opmaak van het tekstgedeelte. Om een aangepaste tekstkleur toe te passen, selecteer [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/hyperlinkcolorsource/) en stel de vulkleur van het gedeelte in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstvulling, terwijl de tweede de standaard hyperlink‑kleur behoudt.

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
### **Geluid**

Een hyperlink kan een geluid afspelen wanneer geactiveerd of een geluid stoppen dat al afspeelt. Gebruik de volgende methoden om deze gedragingen te configureren:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_sound/) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlink‑geluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Klikken op de knop speelt het geluid af en navigeert naar de volgende dia. Een tweede vorm op die dia stopt het vorige geluid bij klikken, zonder een navigatie‑actie uit te voeren.

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

#### **Een hyperlink‑geluid extraheren**

Het volgende voorbeeld opent de eerder gemaakte presentatie en leest het hyperlink‑audio van de eerste vorm in het geheugen via [get_Sound](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/get_sound/) en [get_BinaryData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iaudio/get_binarydata/).

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

### **Tooltip‑ en interactie‑instellingen**

U kunt de volgende [IHyperlink](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/)‑instellingen bijwerken via deze methoden nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [set_Tooltip](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_tooltip/) stelt de tekst in die een kijker als tip voor de link kan weergeven.
- [set_TargetFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_targetframe/) geeft het doel‑frame binnen een bovenliggend HTML‑frameset op, indien van toepassing.
- [set_History](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_history/) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [set_HighlightClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/set_highlightclick/) bepaalt of de hyperlink wordt gemarkeerd bij klikken.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [GetAnyHyperlinks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) om hyperlink‑containers te verzamelen, inclusief tekst‑gedeelte‑links, vóórdat u ze wijzigt. Het volgende voorbeeld verwijdert beide activeringssoorten van de eerste dia. Om slechts één type te verwijderen, roep alleen [RemoveHyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) of [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) aan; het verwijderen van een klik‑actie verwijdert de mouse‑over‑tegenhanger niet.

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

Voor onvoorwaardelijke verwijdering verwijdert [RemoveAllHyperlinks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) beide activeringssoorten in de geselecteerde scope in één oproep. Voor selectieve opschoning en dekking van masters, lay-outs en notities, zie [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris samenstellen**

Voordat u een presentatie verspreidt, inventariseer u de interactieve acties én de web‑links. [GetAnyHyperlinks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retourneert [IHyperlinkContainer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkcontainer/)‑objecten, geen platte lijst van URL‑strings. Inspecteer zowel [get_HyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) als [get_HyperlinkMouseOver](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties blootleggen, dus een volledig rapport heeft tot twee rijen per container nodig.

Het scannen van alleen hyperlink‑containers op vormniveau kan links missen die aan tekstgedeelten zijn gekoppeld. Vraag in plaats daarvan de juiste scope op en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie‑, dia‑ en tekst‑frame‑scopes opvragen**

De [IHyperlinkQueries](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/)‑interface is beschikbaar via [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) en [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Elke scope ondersteunt dezelfde queries:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) retourneert containers met een klik‑actie.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) retourneert containers met een mouse‑over‑actie.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retourneert containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestand‑mouse‑over‑link, interne dia‑navigatie, een tekst‑mouse‑over‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken op elke scope; de tellingen beschrijven containers, niet het totaal aantal acties. De tekst‑frame‑scope sluit de eigen links van de omvattende vorm uit.

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

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee mouse‑over‑containers en drie containers met één van de acties. De tekst‑frame‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [IHyperlink::get_ActionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/get_actiontype/) om een actie te interpreteren vóórdat u de bestemming interpreteert. De [HyperlinkActionType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/hyperlinkactiontype/)‑waarden omvatten meer dan web‑navigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en het protocol. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, opgelost in diavoorstellingscontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Beëindig de huidige show of start een aangepaste show. |
| `StartMacro` | Voer een macro uit. |
| `StartProgram` | Start een programma. |
| `OpenFile`, `OpenPresentation` | Open een bestand of een andere presentatie; behandel apart van web‑URL's. |
| `StartStopMedia` | Start of stop media‑afspelen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die beoordeling vereist. |

Lees externe bestemmingen uit [get_ExternalUrl](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/get_externalurl/) en specifieke interne bestemmingen uit [get_TargetSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/get_targetslide/). Interne acties en ingebouwde commando's kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar [get_ExternalUrlOriginal](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) wanneer deze afwijkt van de genormaliseerde URL, en neem de tooltip van [get_Tooltip](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlink/get_tooltip/) op wanneer beschikbaar.

### **Hyperlinks rapporteren, saneren en verifiëren**

Het volgende C++‑voorbeeld leest een bestaande presentatie (gebruik het bestand dat hierboven is aangemaakt), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activeringssoorten opnieuw te controleren. Het verzamelt containers voordat ze worden aangepast en gebruikt pointer‑identiteit om te voorkomen dat dezelfde container twee keer wordt verwerkt. Presentatie‑queries dekken gewone dia’s; voor een pakket‑brede inventarisatie worden ook expliciet masters, lay‑outs, notities en de notitie‑ en handout‑masters opgezocht wanneer aanwezig.

Het rapport noteert een één‑gebaseerde dia‑index en [get_SlideId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/get_slideid/) waar beschikbaar. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecomponent/get_slide/) levert de eigende dia voor ondersteunde containers. Masters, lay‑outs en notities hebben geen gewone dia‑index en worden geïdentificeerd door hun scope. Vorm‑containers en tekst‑gedeelte‑opmaak‑containers worden apart gelabeld; andere container‑types behouden hun runtime‑typenaam. Elke container krijgt een lokaal rapport‑ID zodat de twee acties kunnen worden gecorreleerd.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestandsacties, andere diavoorstellingsacties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleidsbeslissingen, geen Aspose.Slides‑veiligheidsverklaring. HTTPS alleen garandeert geen vertrouwen: voeg host‑allowlists en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor herstel ondersteunt de container's [get_HyperlinkManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) en [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden mouse‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids­schendingen te verwijderen. Kies een door de toepassing beheerde vervangingspagina vóór implementatie.

De export‑vlag van het rapport gebruikt een conservatief PDF‑review‑beleid: markeer mouse‑over‑acties en alles wat geen externe link of specifieke dia‑sprong is als potentieel niet‑ondersteund. Het is een review‑hint, geen capaciteitstest of garantie dat ongemarkeerde links behouden blijven bij export. Ondersteunde [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/cpp/convert-powerpoint-to-html/)‑exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[afbeeldingen](/slides/nl/cpp/convert-powerpoint-to-png/) en -[video](/slides/nl/cpp/convert-powerpoint-to-video/) kunnen interactieve hyperlinks niet behouden; markeer elke actie bij het auditen voor die uitvoerformaten.

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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestand‑mouse‑over‑link en macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL oefent ook de vervangings‑tak uit. Een container met een toegestane klik en een verboden mouse‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [RemoveAllHyperlinks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), dat beide activeringssoorten verwijdert in de geselecteerde scope ongeacht beleid. Verificatie hier controleert alleen hyperlink‑acties; het verwijdert geen ingesloten VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerde PDF‑ of HTML‑bestanden.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia daarvan linken?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op een individuele dia. Om navigatie naar een sectie te maken, link naar de eerste dia in die sectie.

**Kan ik een hyperlink toevoegen aan elementen van de master‑dia zodat deze op alle dia’s werkt?**

Ja. Elementen van de master‑dia en lay‑out ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia’s die de betreffende master of lay‑out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de export‑overwegingen in [Hyperlinks rapporteren, saneren en verifiëren](#report-sanitize-and-verify-hyperlinks).