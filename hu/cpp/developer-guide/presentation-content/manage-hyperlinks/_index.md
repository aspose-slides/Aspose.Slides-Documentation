---
title: C++ prezentációs hiperhivatkozások kezelése
linktitle: Hiperhivatkozások kezelése
type: docs
weight: 20
url: /hu/cpp/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- dia hiperhivatkozás
- alakzati hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ segítségével, C++ példákkal."
---
## **Bevezetés**

A hiperhivatkozás a bemutató tartalmát kapcsolja össze egy weboldallal vagy a bemutatón belüli helyre. A PowerPoint-ban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for C++ lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk szabályozását, beállításaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}
A bemutatókat a [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/hu/editor) segítségével is szerkesztheti.
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t adhat szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrész a kiválasztott szöveget kapcsolja, míg egy alakzat vagy keret a dia objektumát kapcsolja.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalra való hivatkozásához hozzon létre egy [Hyperlink](https://reference.aspose.com/slides/hu/cpp/aspose.slides/hyperlink/) objektumot, és rendelje azt a szövegrész [set_HyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/set_hyperlinkclick/) metódusával, az alábbiakban látható módon. Csak az adott szövegrész lesz kattintható.

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz és média keretekhez**

Az alakzat vagy keret kattinthatóvá tételéhez használja annak [set_HyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/set_hyperlinkclick/) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem a benne lévő szövegrészhez.

Ez a megközelítés a kép-, audio- és videókeretekre is vonatkozik: rendelje a hiperhivatkozást a kerethez, és ha szükséges, használja a [set_Tooltip](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_tooltip/) metódust a tipp hozzáadásához.

A következő példa egy téglalapot tesz kattinthatóvá:

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

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [SetInternalHyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) metódust használja, hogy az első dián lévő „Page 2” szöveget a második diára linkelje.

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

## **Hiperhivatkozások formázása**

### **Szín**

A [set_ColorSource](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_colorsource/) metódus a [IHyperlink](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/) esetén határozza meg, hogy a hiperhivatkozás a bemutató hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egy egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/hyperlinkcolorsource/) lehetőséget, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019-ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

A következő példa két szöveges hiperhivatkozást ad ugyanahhoz a diához. Az első piros szövegtöltést használ, míg a második megtartja az alapértelmezett hiperhivatkozás színét.

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
### **Hang**

Hiperhivatkozás aktiváláskor lejátszhat hangot, vagy leállíthat egy már lejátszódó hangot. Az alábbi módszerekkel állíthatja be ezeket a viselkedéseket:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_sound/) határozza meg a hiperhivatkozáshoz társított hangot.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) szabályozza, hogy a hiperhivatkozás aktiválása leállítsa-e az előző hangot.

#### **Hiperhivatkozási hang hozzáadása**

A következő példa betölti a `sampleaudio.wav` fájlt, és egy első dián lévő gombhoz rendeli. A gombra kattintva lejátszódik a hang és a következő diára navigál. A dián lévő második alakzat kattintásra leállítja az előző hangot, anélkül, hogy navigációs műveletet végezne.

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

#### **Hiperhivatkozási hang kinyerése**

A következő példa megnyitja a fent létrehozott bemutatót, és a [get_Sound](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/get_sound/) és a [get_BinaryData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iaudio/get_binarydata/) segítségével beolvassa az első alakzat hiperhivatkozás hangját a memóriába.

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

### **Buborékablak és interakciós beállítások**

Miután hiperhivatkozást rendelt szöveghez vagy alakzathoz, a következő [IHyperlink](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/) beállításokat módosíthatja ezekkel a módszerekkel:

- [set_Tooltip](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_tooltip/) beállítja a szöveget, amelyet a néző a hivatkozás tippjeként jeleníthet meg.
- [set_TargetFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_targetframe/) meghatározza a célkeretet a szülő HTML keretcsoportban, ha alkalmazható.
- [set_History](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_history/) szabályozza, hogy a hivatkozás aktiválása felveszi-e a célját a megtekintett hiperhivatkozások listájába.
- [set_HighlightClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/set_highlightclick/) szabályozza, hogy a hiperhivatkozás ki legyen-e emelve kattintáskor.

## **Hiperhivatkozások eltávolítása a bemutatókból**

A [GetAnyHyperlinks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) használatával gyűjtheti össze a hiperhivatkozás konténereket, beleértve a szövegrész hivatkozásokat is, a módosításuk előtt. Az alábbi példa eltávolítja mindkét aktiválási típust az első diáról. Ha csak egy típust szeretne eltávolítani, hívja csak a [RemoveHyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) vagy a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metódust; a kattintási művelet eltávolítása nem távolítja el az egér‑felül eseményt.

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

Feltétlen eltávolításhoz a [RemoveAllHyperlinks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) mindkét aktiválási típust eltávolítja a kiválasztott körben egy hívással. Szelektív tisztításhoz és a mester‑, elrendezés‑ és jegyzet‑diák lefedéséhez lásd a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás leltár felépítése**

A bemutató közzététele előtt készítsen leltárt az interaktív műveleteiről és webes hivatkozásairól. A [GetAnyHyperlinks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy egyszerű URL karakterláncok listáját. Minden konténeren ellenőrizze mind a [get_HyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) , mind a [get_HyperlinkMouseOver](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) metódust. Függetlenek: ugyanaz a konténer is tartalmazhatja mindkét műveletet, ezért egy teljes jelentéshez egy konténerre akár két sor is szükséges.

Csak az alakzatszintű hiperhivatkozások beolvasása kihagyhatja a szövegrészekhez csatolt hivatkozásokat. Inkább a megfelelő körben kérdezze le, és őrizze meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa azok műveleteit.

### **Bemutató, dia és szövegkeret körök lekérdezése**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/) felület elérhető az [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) és [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) metódusokon keresztül. Minden kör ugyanazokat a lekérdezéseket támogatja:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) konténereket ad vissza kattintásos művelettel.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) konténereket ad vissza egér‑felül művelettel.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) konténereket ad vissza, amelyek bármelyik vagy mindkét műveletet tartalmazzák.

A következő példa létrehozza a `hyperlink-audit-input.pptx` fájlt, amely egy külső kattintási hivatkozást, egy fájl egér‑felül hivatkozást, belső dia navigációt, egy szöveg egér‑felül hivatkozást és egy makró műveletet tartalmaz. Ezek egyikét sem hajtja végre. Ugyanaz a három lekérdezés minden körben működik; a számlálók konténereket írnak le, nem a műveletek összegét. A szövegkeret kör kizárja a körülvevő alakzat saját hivatkozásait.

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

Ebben a példában a bemutató és a dia lekérdezések három kattintási konténert, két egér‑felül konténert, és három konténert jelentettek, amelyek bármelyik művelettel rendelkeznek. A szövegkeret lekérdezés egy konténert jelent mindhárom kategóriában.

### **Műveletek és célok osztályozása**

A [IHyperlink::get_ActionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/get_actiontype/) használatával értelmezze a műveletet, mielőtt a célját vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is kiterjednek:

| Értékek | Jelentés az auditban |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; vizsgálja meg az URL-t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyéni bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik bemutató megnyitása; külön kell vizsgálni a webes URL-eket. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy egy ismeretlen művelet, amely felülvizsgálatot igényel. |

Az external célpontokat a [get_ExternalUrl](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/get_externalurl/) segítségével, a konkrét belső célpontokat pedig a [get_TargetSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/get_targetslide/) metódussal olvassa ki. Belső műveletek és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs művelete. Tartsa meg a [get_ExternalUrlOriginal](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) értékét, ha az eltér a normalizált URL-től, és vegye fel a [get_Tooltip](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlink/get_tooltip/) által visszaadott buborékablakot, ha elérhető.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

A következő C++ példa beolvas egy meglévő bemutatót (használja a fent létrehozott fájlt), kiírja a `hyperlink-audit.json`-t, egy szabályzatot alkalmaz, elmenti a `hyperlink-sanitized.pptx`-t, majd újra megnyitja, hogy újra ellenőrizze mindkét aktiválási típust. A módosítás előtt összegyűjti a konténereket, és pointer‑identitást használ, hogy elkerülje ugyanazon konténer kétszeri feldolgozását. A bemutató lekérdezések a szokásos diákra vonatkoznak; csomagszintű leltár esetén kifejezetten lekérdezi a mestereket, elrendezéseket, jegyzeteket, valamint a jegyzet‑ és szórólap‑mestereket, ha jelen vannak.

A jelentés egy egytől kezdődő dia indexet és a [get_SlideId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_slideid/) értéket rögzíti, ha elérhető. Az [ISlideComponent::get_Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecomponent/get_slide/) a támogatott konténerekhez a tulajdonos diát adja meg. A mesterek, elrendezések és jegyzetek nem rendelkeznek hagyományos dia indexszel, és a körük alapján azonosíthatók. Az alakzat konténereket és a szövegrész formázási konténereket külön jelölik; más konténer típusok megtartják a futási időbeli típusnevüket. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két művelete összekapcsolható legyen.

Ez a szándékosan szigorú alkalmazási szabályzat csak abszolút HTTPS URL-eket és érvényes belső dia célpontokat engedélyez. Elutasítja a makrókat, programokat, fájl műveleteket, egyéb diavetítési műveleteket, ismeretlen műveleteket és más URL sémákat. Ezek az elutasítások szabályzat döntések, nem az Aspose.Slides biztonsági ítélete. A HTTPS önmagában nem teremt bizalmat: adjon hozzá host engedélylistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL-ek ellenőrzésre kerülnek. A példa metaadatokat auditál anélkül, hogy linkeket követne vagy műveleteket hajtana végre.

A javításhoz a konténer [get_HyperlinkManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) és [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metódusokat támogatja. Itt a tiltott külső kattintási hivatkozásokat egy rögzített HTTPS kezdőoldallal helyettesítik; a többi tiltott kattintást és egér‑felül műveletet külön-külön eltávolítják. Állítsa a `replaceExternalClicks` értékét `false`‑ra, ha az összes szabályzat‑sértést el akarja távolítani. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés exportálási jelzője egy konzervatív PDF felülvizsgálati szabályzatot használ: egér‑felül műveleteket és mindent, ami nem külső hivatkozás vagy konkrét dia ugrás, potenciálisan nem támogatottként jelöl. Ez egy felülvizsgálati tipp, nem képességteszt vagy garancia arra, hogy a jelöletlen hivatkozások megmaradnak az exportálás során. A támogatott [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/cpp/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, export beállításoktól és a megjelenítőtől függően. A raszteres [képek](/slides/hu/cpp/convert-powerpoint-to-png/) és [videók](/slides/hu/cpp/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; az ilyen kimenetek auditálásakor minden műveletet jelöljön.

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

A fent létrehozott bemenettel a jelentés öt műveleti sort tartalmaz. A fájl egér‑felül hivatkozás és a makró kattintás eltávolításra kerül, míg a HTTPS hivatkozások és a belső dia navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL-t tartalmazó bemenet a helyettesítő ágat is végrehajtja. Egy olyan konténer, amelynek engedélyezett a kattintás, de tiltott az egér‑felül, megtartja a kattintási műveletét.

Ez a szelektív tisztítás különbözik a [RemoveAllHyperlinks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) módszertől, amely a kiválasztott körben mindkét aktiválási típust eltávolítja a szabályzattól függetlenül. Az itt végzett ellenőrzés csak a hiperhivatkozás műveleteket vizsgálja; nem távolítja el a beágyazott VBA projekteket, OLE objektumokat vagy egyéb aktív tartalmakat, és nem validálja az exportált PDF vagy HTML fájlt.

## **GYIK**

**Hogyan linkelhetek egy szakaszra vagy annak első diájára?**

A PowerPoint szakaszok a diákat csoportosítják, de egy belső hiperhivatkozás egyetlen diát céloz meg. Egy szakasz navigációjának létrehozásához a szakasz első diájára kell hivatkozni.

**Csatolhatok hiperhivatkozást a mester dia elemeihez, hogy minden dián működjön?**

Igen. A mester diák és elrendezés elemei támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő hivatkozások a diavetítés során elérhetők azokon a diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó formátumba exportáláskor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és videók nem. Tekintse meg az exportálási szempontokat a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részben.