---
title: Low-Code presentatiewerkzaamheden in C++
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/cpp/low-code-presentation-operations/
keywords:
- low-code presentaties API
- presentatie converteren
- presentaties samenvoegen
- "dia's itereren"
- "vormen itereren"
- "tekst itereren"
- "vormen verzamelen"
- "presentatie comprimeren"
- "masterdia's verwijderen"
- "lay-outdia's verwijderen"
- "ingesloten lettertypen comprimeren"
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in C++ om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

De [Aspose::Slides::LowCode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/) namespace biedt statische hulpprogrammaclassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte object‑modelwerkstromen in gerichte methoden, zodat u presentaties kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code‑helpers zijn het meest bruikbaar wanneer de bewerking van toepassing is op een heel bestand of een hele presentatie en de standaardwerkstroom voldoet aan uw eisen. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/cpp/aspose.slides/) wanneer u fijnmazige controle nodig heeft over individuele dia’s, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor te gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/merger/) | Complete presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstgedeelte. |
| [Collect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/collect/) | Vormen uit de volledige presentatie ophalen voor herhaaldelijke verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑gegevens verkleinen. |

## **Een presentatie converteren**

Gebruik [Convert::AutoByExtension](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/autobyextension/) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het benodigde formaat op basis van het uitvoerpad en schrijft het resultaat.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/)‑klasse biedt ook speciale methoden voor PDF, SVG, JPEG, PNG en TIFF output. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of aanpassen vóór export, of wanneer u een exportoptie moet configureren die niet wordt blootgesteld door de gekozen helper. Zie [Convert Presentation](/cpp/convert-presentation/) voor formaat‑specifieke werkstromen en opties.

## **Presentaties samenvoegen**

Gebruik [Merger::Process](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/merger/process/) om complete presentatiebestanden met één aanroep te combineren. De in te voeren presentaties moeten hetzelfde bestandsformaat hebben.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

De helper is geschikt wanneer alle dia’s moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of te remappen. Gebruik het volledige objectmodel wanneer u geselecteerde dia’s wilt samenvoegen, een bestemmings‑master of lay‑out wilt toepassen, secties expliciet wilt behouden, of verschillende dia‑groottes wilt reconcilieren. Zie [Merge Presentations](/cpp/merge-presentation/) voor die scenario’s.

## **Door presentatie‑elementen itereren**

De [ForEach](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/)‑klasse roept een callback op voor elk aangevraagd type presentatie‑element. Ze voorkomt geneste verzamellussen en is handig voor inspectie of formatteringswijzigingen op presentatie‑breed niveau.

Het volgende voorbeeld gebruikt [ForEach::Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/paragraph/) en [ForEach::Portion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/portion/) om de overeenkomstige elementen te inspecteren:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Standaard omvat presentatiewijd vorm‑ en tekst‑traversal normale, master‑ en lay‑out‑dia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe verzamelingslussen wanneer de traversalevolgorde, vroegtijdig stoppen, filteren vóór callback‑aanroep, of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect::Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/collect/shapes/) wanneer u een collectie van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is nuttig wanneer dezelfde set later gefilterd, geteld of meerdere keren verwerkt moet worden.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Gebruik [ForEach::Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/shape/) in plaats daarvan wanneer elke vorm direct kan worden afgehandeld en u de verzamelde resultaten niet hoeft te behouden.

## **Inhoud van presentatie comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑gegevens verkleinen:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) verwijdert lay‑outdia’s waar geen normale dia naar verwijst.  
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwijdert masterdia’s die niet meer worden gebruikt.  
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Verwijder ongebruikte lay‑outs vóór ongebruikte masters, zodat een master die na opschoning van lay‑outs niet meer wordt gerefereerd ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de originele masters, lay‑outs of volledige ingesloten lettertype‑gegevens nodig heeft. Voor meer details, zie [Slide Master](/cpp/slide-master/) en [Embedded Font](/cpp/embedded-font/).

## **FAQ**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code‑helpers wanneer een standaardbewerking op een compleet bestand of een complete presentatie van toepassing is en er geen gedetailleerde controle over individuele elementen nodig is. Gebruik het volledige objectmodel wanneer u specifieke dia’s moet selecteren, master‑ en lay‑out‑relaties moet beheren, de tussenliggende toestand moet inspecteren, of gedrag moet configureren dat de helper niet blootlegt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger::Process](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/merger/process/) vereist dat de invoer‑presentaties hetzelfde formaat hebben. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert::AutoByExtension](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/autobyextension/), en voeg vervolgens de geconverteerde bestanden samen.

**Verwerkt ForEach master-, lay‑out‑ en notitieslides?**

[ForEach::Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/slide/) itereert door normale presentatiedia’s. Presentatiewijd [ForEach::Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/paragraph/) en [ForEach::Portion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/portion/) omvatten standaard normale, master‑ en lay‑out‑dia’s. Gebruik hun overloads met `includeNotes` ingesteld op `true` om notitiedia’s mee te nemen.

**Wat is het verschil tussen ForEach::Shape en Collect::Shapes?**

Gebruik [ForEach::Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/shape/) om elke vorm direct via een callback te verwerken. Gebruik [Collect::Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/collect/shapes/) wanneer u een doorzoekbaar resultaat nodig heeft dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Vermindert Compress altijd de bestandsgrootte van de presentatie?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, zullen de overeenkomstige [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/)‑operaties de bestandsgrootte mogelijk niet verkleinen.

**Worden wijzigingen die door ForEach of Compress worden aangebracht automatisch opgeslagen?**

Nee. Deze helpers opereren op het geladen [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑object in het geheugen. Nadat u elementen in een [ForEach](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/)‑callback hebt gewijzigd of [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/) hebt uitgevoerd, roept u [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) aan om het resultaat naar een bestand te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)