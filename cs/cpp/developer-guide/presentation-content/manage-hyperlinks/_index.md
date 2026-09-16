---
title: Správa hypertextových odkazů v prezentacích v C++
linktitle: Spravovat hypertextové odkazy
type: docs
weight: 20
url: /cs/cpp/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- mutabilní hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++ s využitím příkladů v C++."
---
## **Úvod**

Hyperlink spojuje obsah prezentace s webovou stránkou nebo umístěním v rámci prezentace. V PowerPointu hypertextové odkazy obvykle slouží ke dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo mediálního rámce.
* Přesunout se na jiný snímek, například z obsahu.

Aspose.Slides for C++ vám umožňuje přidávat tyto odkazy, řídit jejich vzhled a zvuk, aktualizovat jejich nastavení a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak získat přístup k odkazům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Poznámka" %}}
Můžete také upravovat prezentace pomocí [bezplatný online editor Aspose PowerPoint](https://products.aspose.app/slides/cs/editor).
{{% /alert %}} 

## **Přidat URL hypertextové odkazy**

Můžete přiřadit URL webové stránky k textu, tvaru nebo mediálnímu rámci. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje klikací oblast: část textu odkazuje na vybraný text, zatímco tvar nebo rámec odkazuje na objekt snímku.

### **Přidat URL hypertextové odkazy do textu**

Pro propojení textu s webovou stránkou vytvořte [Hyperlink](https://reference.aspose.com/slides/cs/cpp/aspose.slides/hyperlink/) a přiřaďte jej metodou [set_HyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portionformat/set_hyperlinkclick/) části textu, jak je ukázáno níže. Klikací bude pouze tato část textu.

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

### **Přidat URL hypertextové odkazy do tvarů a mediálních rámců**

Pro zpřístupnění tvaru nebo rámce použijte jeho metodu [set_HyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/set_hyperlinkclick/). Hypertextový odkaz patří objektu samotnému, nikoli části textu uvnitř něj.

Stejný přístup platí pro obrazy, audio a video rámce: přiřaďte hypertextový odkaz rámci a použijte [set_Tooltip](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_tooltip/) pro přidání nápovědy, pokud je potřeba.

Následující příklad dělá obdélník klikacím:

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

## **Použít hypertextové odkazy k vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) k propojení textu „Page 2“ na prvním snímku s druhým snímkem.

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

## **Formátovat hypertextové odkazy**

### **Barva**

Metoda [set_ColorSource](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_colorsource/) rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/) určuje, zda hypertextový odkaz používá barvu hypertextových odkazů v prezentaci, nebo formátování části textu. Pro použití vlastní barvy textu vyberte [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/hyperlinkcolorsource/) a nastavte barvu výplně části. Tato funkce byla zavedena v PowerPointu 2019; starší verze tuto volbu nepoužívají.

Následující příklad přidává dva hypertextové odkazy do textu na stejném snímku. První používá červenou výplň textu, druhý zachovává výchozí barvu hypertextového odkazu.

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
### **Zvuk**

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit již přehrávaný zvuk. Použijte následující metody k nastavení tohoto chování:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_sound/) určuje audio soubor přiřazený k hypertextovému odkazu.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) řídí, zda aktivace odkazu zastaví předchozí zvuk.

#### **Přidat zvuk hypertextového odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutím na tlačítko se zvuk přehraje a přejde se na další snímek. Druhý tvar na tom snímku při kliknutí zastaví předchozí zvuk, aniž by provedl navigaci.

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

#### **Extrahovat zvuk hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte audio hypertextového odkazu prvního tvaru do paměti pomocí [get_Sound](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/get_sound/) a [get_BinaryData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudio/get_binarydata/).

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

### **Nastavení bublin a interakce**

Po přiřazení hypertextového odkazu k textu nebo tvaru můžete aktualizovat následující nastavení rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/) pomocí těchto metod:

- [set_Tooltip](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_tooltip/) nastaví text, který se zobrazí jako nápověda pro odkaz.
- [set_TargetFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_targetframe/) určuje cílový rámec v rámci rodičovské HTML sady rámců, pokud je to relevantní.
- [set_History](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_history/) určuje, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených hypertextových odkazů.
- [set_HighlightClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/set_highlightclick/) určuje, zda bude hypertextový odkaz zvýrazněn po kliknutí.

## **Odstranit hypertextové odkazy z prezentací**

Použijte [GetAnyHyperlinks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) k získání kontejnerů hypertextových odkazů, včetně odkazů na části textu, před jejich úpravou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Pro odstranění pouze jednoho typu zavolejte jen [RemoveHyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) nebo [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); odstranění akce kliknutí neodstraňuje její protějšek při najetí myší.

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

Pro bezpodmíněné odstranění [RemoveAllHyperlinks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) odstraní oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní úklid a pokrytí hlav, rozvržení a poznámek viz [Zpráva, sanitizace a ověření hypertextových odkazů](#report-sanitize-and-verify-hyperlinks).

## **Vytvořit kompletní inventář hypertextových odkazů**

Před distribucí prezentace si inventarizujte její interaktivní akce i webové odkazy. [GetAnyHyperlinks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) vrací objekty [IHyperlinkContainer](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkcontainer/), nikoli plochý seznam řetězců URL. Prozkoumejte jak [get_HyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/), tak [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) u každého kontejneru. Jsou nezávislé: stejný kontejner může exponovat obě akce, takže kompletní zpráva vyžaduje až dva řádky na kontejner.

Prohledávání pouze hypertextových odkazů na úrovni tvaru může vynechat odkazy připojené k částem textu. Dotazujte se raději na vhodný rozsah a uchovávejte vrácené kontejnery, abyste je později mohli aktualizovat nebo odstranit.

### **Dotázat se na rozsahy prezentace, snímku a textového rámce**

Rozhraní [IHyperlinkQueries](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/) je dostupné přes [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) a [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Každý rozsah podporuje stejné dotazy:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) vrací kontejnery s akcí kliknutí.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) vrací kontejnery s akcí při najetí myší.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím odkazem na kliknutí, odkazem na soubor při najetí, interní navigací mezi snímky, odkazem na text při najetí a akcí makra. Neprovádí žádnou z těchto akcí. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, ne celkový počet akcí. Rozsah textového rámce vylučuje vlastní odkazy zahrnující tvar.

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

Pro tento příklad dotazy na prezentaci a snímek vrací po třech kontejnerech kliknutí, dva kontejnery při najetí a tři kontejnery s libovolnou akcí. Dotaz na textový rámec vrací po jednom kontejneru v každé kategorii.

### **Klasifikovat akce a cíle**

Pomocí [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/get_actiontype/) zjistíte typ akce před interpretací cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/hyperlinkactiontype/) pokrývají více než jen webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; zkontrolujte URL a její schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace prezentace, vyhodnocována v kontextu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončit aktuální prezentaci nebo spustit vlastní prezentaci. |
| `StartMacro` | Spustit makro. |
| `StartProgram` | Spustit program. |
| `OpenFile`, `OpenPresentation` | Otevřít soubor nebo jinou prezentaci; posuzovat odděleně od webových URL. |
| `StartStopMedia` | Spustit nebo zastavit přehrávání médií. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo nerozpoznaná akce vyžadující revizi. |

Externí cíle čtěte z [get_ExternalUrl](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/get_externalurl/) a konkrétní interní cíle z [get_TargetSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/get_targetslide/). Interní akce a vestavěné příkazy nemusí mít externí URL; prázdná URL neznamená, že kontejner nemá akci. Zachovejte [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/get_externalurloriginal/), pokud se liší od normalizované URL, a zahrňte nápovědu vrácenou metodou [get_Tooltip](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlink/get_tooltip/), pokud je k dispozici.

### **Zpráva, sanitizace a ověření hypertextových odkazů**

Následující C++ příklad načte existující prezentaci (použijte soubor vytvořený výše), zapíše `hyperlink-audit.json`, použije politiku, uloží `hyperlink-sanitized.pptx` a znovu jej otevře pro kontrolu obou typů aktivace. Před úpravou sbírá kontejnery a používá identitu ukazatelů, aby nezpracovával stejný kontejner dvakrát. Dotazy na prezentaci pokrývají běžné snímky; pro inventář celého balíčku explicitně dotazují i hlavní snímky, rozvržení, poznámky a jejich mistry, pokud existují.

Zpráva zaznamenává jednorázový index snímku a [get_SlideId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslide/get_slideid/), kde je k dispozici. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecomponent/get_slide/) poskytuje vlastní snímek pro podporované kontejnery. Hlavní snímky, rozvržení a poznámky nemají běžný index snímku a jsou identifikovány svým rozsahem. Kontejnery tvarů a formátovací kontejnery částí textu jsou označeny odděleně; ostatní typy kontejnerů si zachovávají název runtime typu. Každý kontejner získá lokální ID zprávy, aby jeho dvě akce lze korelovat.

Tato záměrně restriktivní aplikační politika povoluje jen absolutní HTTPS URL a platné interní cíle snímků. Odmítá makra, programy, akce souborů, jiné akce prezentace, neznámé akce a jiné schémata URL. Tato odmítnutí jsou rozhodnutí politiky, nikoli bezpečnostní verdikty Aspose.Slides. HTTPS samo o sobě nestanoví důvěru: přidejte seznam povolených hostitelů a další kontroly dle potřeby aplikace. Kontrolují se jak původní, tak normalizované externí URL. Příklad audituje metadata bez následování odkazů nebo spouštění akcí.

Pro opravu kontejnerů [get_HyperlinkManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) podporuje [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) a [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Zde jsou zakázané externí odkazy na kliknutí nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce při najetí jsou odstraněny nezávisle. Nastavte `replaceExternalClicks` na `false` pro odebrání všech porušení politiky. Před nasazením zvolte stránku náhradní, kterou vlastní aplikace.

Exportní příznak zprávy používá konzervativní politiku kontroly PDF: označuje akce při najetí a vše kromě externího odkazu nebo konkrétního skoku na snímek jako potenciálně nepodporované. Jedná se o nápovědu pro revizi, ne o test schopností ani záruku, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/cpp/convert-powerpoint-to-html/) mohou zachovat hypertextové odkazy v závislosti na akci, nastavení exportu a prohlížeči. Rasterové [obrázky](/slides/cs/cpp/convert-powerpoint-to-png/) a [video](/slides/cs/cpp/convert-powerpoint-to-video/) nemohou zachovat interaktivní hypertextové odkazy; při auditu pro tyto výstupy označte každou akci.

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

S výše vytvořeným vstupem zpráva obsahuje pět řádků akcí. Odkaz na soubor při najetí a makro kliknutí jsou odstraněny, zatímco HTTPS odkazy a interní navigace zůstávají. Ověření vytiskne nulu zakázaných akcí. Vstup s zakázanou externí URL také prověří větev nahrazení. Kontejner s povoleným kliknutím a zakázaným najetím si ponechá klikací akci.

Tento selektivní úklid se liší od [RemoveAllHyperlinks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), který odstraní oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje pouze akce hypertextových odkazů; neodstraňuje vložené VBA projekty, OLE objekty ani jiný aktivní obsah a nevaliduje exportovaný PDF ani HTML soubor.

## **Často kladené dotazy**

**Jak mohu propojit sekci nebo její první snímek?**

Sekce v PowerPointu seskupují snímky, ale interní hypertextový odkaz cílí na konkrétní snímek. Pro vytvoření navigace na sekci propojte odkaz na první snímek v této sekci.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozvržení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou dostupné během prezentace na snímcích, které používají daný hlavní snímek nebo rozvržení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou zachovat hypertextové odkazy; rastrové obrázky a video ne. Viz úvahy o exportu v [Zpráva, sanitizace a ověření hypertextových odkazů](#report-sanitize-and-verify-hyperlinks).