---
title: Low-Code Presentatiebewerkingen in C++
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/cpp/low-code-presentation-operations/
keywords:
- low-code presentatie API
- presentatie converteren
- presentaties samenvoegen
- dia's itereren
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- ongebruikte master-dia's verwijderen
- ongebruikte layout-dia's verwijderen
- ingebedde lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in C++ om presentaties te converteren en samen te voegen, door de inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

De [Aspose::Slides::LowCode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/) namespace biedt statische hulpprogramma‑klassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte object‑model workflows in gerichte methoden, zodat je bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code helpers zijn het meest bruikbaar wanneer de bewerking wordt toegepast op een volledig bestand of presentatie en de standaard workflow voldoet aan je eisen. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/cpp/aspose.slides/) wanneer je fijnmazige controle nodig hebt over individuele dia’s, masters, layouts, vormen, exportinstellingen of relaties tussen presentatiet elementen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Gebruik het voor |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/merger/) | Complete presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/) | Een actie uitvoeren voor elke dia, vorm, alinea of tekstdelen. |
| [Collect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/collect/) | Vormen ophalen uit de volledige presentatie voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/) | Ongebruikte masters en layouts verwijderen en ingebedde lettertype‑data verkleinen. |

## **Presentatie converteren**

Gebruik [Convert::AutoByExtension](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/autobyextension/) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat aan de hand van het uitvoerpad en schrijft het resultaat.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

De [Convert](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/) klasse biedt ook speciale methoden voor PDF, SVG, JPEG, PNG en TIFF output. Gebruik het volledige object model wanneer je de presentatie moet inspecteren of aanpassen vóór export of een exportoptie moet configureren die niet wordt blootgesteld door de geselecteerde helper. Zie [Convert Presentation](/slides/nl/cpp/convert-presentation/) voor formaat‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger::Process](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/merger/process/) om volledige presentatiebestanden met één aanroep te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

De helper is geschikt wanneer alle dia’s aan één resultaat moeten worden toegevoegd zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige object model wanneer je geselecteerde dia’s moet samenvoegen, een bestemmings‑master of layout moet toepassen, secties expliciet moet behouden of verschillende dia‑groottes moet harmoniseren. Zie [Merge Presentations](/slides/nl/cpp/merge-presentation/) voor die scenario’s.

## **Door presentatie‑elementen itereren**

De [ForEach](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/) klasse roept een callback aan voor elk aangevraagd type presentatie‑element. Dit voorkomt geneste verzameling‑lussen en is handig voor inspectie of opmaakwijzigingen op presentatie‑niveau.

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

Standaard omvat de traversering van vormen en tekst door de hele presentatie normale, master‑ en layout‑dia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe verzamelings‑lussen wanneer de volgorde van traversering, voortijdig beëindigen, filteren vóór de callback‑aanroep of gedetailleerde ouder‑kind‑besturing belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect::Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/collect/shapes/) wanneer je een verzameling van alle vormen in een presentatie nodig hebt in plaats van een callback voor elke vorm. Dit is nuttig wanneer dezelfde set later gefilterd, geteld of meermaals verwerkt zal worden.

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

Gebruik [ForEach::Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/shape/) in plaats daarvan wanneer elke vorm direct kan worden afgehandeld en je het verzamelde resultaat niet hoeft te bewaren.

## **Inhoud van presentatie comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/) klasse kan ongebruikte structurele elementen verwijderen en ingebedde lettertype‑data verkleinen:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) verwijdert layout‑dia’s die door geen normale dia worden gerefereerd.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) verwijdert master‑dia’s die niet langer gebruikt worden.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) verwijdert ongebruikte tekens uit ingebedde lettertypen.

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

Verwijder eerst ongebruikte layouts vóór ongebruikte masters, zodat een master die na het opschonen van layouts niet meer wordt gerefereerd eveneens kan worden verwijderd. Sla de geoptimaliseerde presentatie op naar een nieuw bestand als je later de originele masters, layouts of volledige ingebedde lettertype‑data nodig zou kunnen hebben. Voor meer details, zie [Slide Master](/slides/nl/cpp/slide-master/) en [Embedded Font](/slides/nl/cpp/embedded-font/).

## **Veelgestelde vragen**

**Wanneer moet ik de low‑code API gebruiken in plaats van het volledige object model?**

Gebruik low‑code helpers wanneer een standaardbewerking van toepassing is op een compleet bestand of presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige object model wanneer je specifieke dia’s moet selecteren, relaties tussen master en layout moet beheren, een tussentijdse staat moet inspecteren of gedrag moet configureren dat de helper niet blootstelt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger::Process](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/merger/process/) vereist dat invoer‑presentaties hetzelfde formaat hebben. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert::AutoByExtension](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/convert/autobyextension/), en merge vervolgens de geconverteerde bestanden.

**Verwerkt ForEach master‑, layout‑ en notitiedia’s?**

[ForEach::Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/slide/) iterereert door normale presentatiedia’s. Presentatie‑brede [ForEach::Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/paragraph/) en [ForEach::Portion](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/portion/) operaties omvatten standaard normale, master‑ en layout‑dia’s. Gebruik hun overloads met `includeNotes` op `true` om notitiedia’s mee te nemen.

**Wat is het verschil tussen ForEach::Shape en Collect::Shapes?**

Gebruik [ForEach::Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/shape/) om elke vorm direct via een callback te verwerken. Gebruik [Collect::Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/collect/shapes/) wanneer je een doorzoekbaar resultaat nodig hebt dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd het presentatie‑bestand kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte layouts, ongebruikte masters of ingebedde lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, zullen de corresponderende [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/) operaties mogelijk de bestandsgrootte niet verkleinen.

**Worden wijzigingen die door ForEach of Compress worden aangebracht automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) object in het geheugen. Na het wijzigen van elementen in een [ForEach](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/foreach/) callback of het uitvoeren van [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/), roep je [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/slides/nl/cpp/convert-presentation/)
- [Merge Presentations](/slides/nl/cpp/merge-presentation/)
- [Slide Master](/slides/nl/cpp/slide-master/)
- [Manage Text Box](/slides/nl/cpp/manage-textbox/)
- [Embedded Font](/slides/nl/cpp/embedded-font/)