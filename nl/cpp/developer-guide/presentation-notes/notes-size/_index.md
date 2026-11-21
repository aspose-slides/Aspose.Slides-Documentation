---
title: Notitiepagina-grootte en -oriëntatie wijzigen in C++
linktitle: Notitiepagina-grootte
type: docs
weight: 10
url: /nl/cpp/notes-size/
keywords:
- notitiepagina-grootte
- notitie-oriëntatie
- liggende notities
- staande notities
- hand-out-grootte
- PowerPoint
- presentatie
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Lees en wijzig de notitiepagina-afmetingen in Aspose.Slides voor C++, wijzig de oriëntatie, controleer de opgeslagen groottes, en exporteer notities of hand-outs naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation::get_NotesSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_notessize/) om de notitiepagina‑instellingen van de presentatie te benaderen. Het retourneert een [INotesSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotessize/) object waarvan de [set_Size](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inotessize/set_size/) methode de afmetingen instelt. Hoewel het notitie‑instellingsobject niet kan worden vervangen, kun je de grootte wel wijzigen.

Breedte en hoogte worden opgegeven in **punten**, met 72 punten per inch. Bijvoorbeeld, 900 × 600 punten is 12,5 × 8⅓ inch. Deze instellingen gelden voor de presentatie, niet voor de notities van een individuele dia.

| Instelling | Doel |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_notessize/) | Beheert de afmetingen van de notitiepagina en de paginagrootte die wordt gebruikt voor handout‑export. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_slidesize/) | Beheert de afmetingen van de reguliere presentatiedia’s via [ISlideSize](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidesize/). |

Het wijzigen van één van de instellingen wijzigt de andere niet automatisch. Het wijzigen van de oriëntatie van de notitiepagina roteert de reguliere dia’s ook niet. Zie [Slide Size](/slides/nl/cpp/slide-size/) om de reguliere dia’s te herschalen.

De voorbeelden hieronder gebruiken een bestaande `sample.pptx`. Voor de exportvoorbeelden gebruik je een presentatie met minstens één dia die sprekernotities bevat. Elk voorbeeld kan onafhankelijk worden uitgevoerd.

## **Lees de notitiepagina‑grootte en -oriëntatie**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen beschrijven een vierkante pagina. Dit voorbeeld drukt de werkelijke afmetingen in punten af, zonder uit te gaan van een standaard papierformaat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Schakel over naar liggend zonder het papierformaat te wijzigen**

Om alleen de oriëntatie te wijzigen, verwissel je de bestaande breedte en hoogte. Hierdoor blijven de lengtes van beide zijden behouden, inclusief die van een aangepast papierformaat. De onderstaande voorwaarde voorkomt dat een reeds liggende pagina weer wordt omgezet naar staand en laat een vierkante pagina onveranderd.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Voor staande oriëntatie gebruik je dezelfde toewijzing wanneer `size.get_Width() > size.get_Height()`. Vervang geen A4‑ of Letter‑afmetingen, tenzij je ook het papierformaat wilt wijzigen.

## **Stel een aangepaste notitiepagina‑grootte in en verifieer deze**

Ken beide afmetingen tegelijk toe en gebruik vervolgens [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) om de presentatie op te slaan. Dit voorbeeld stelt een liggende pagina van 900 × 600 punten in, slaat deze op als PPTX en opent het opgeslagen bestand opnieuw om de persistente waarden te controleren. De vergelijking staat een tolerantie van 0,01 punt toe voor zwevend‑komma‑waarden; dit is geen garantie voor precisie in elk bestandsformaat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Het verwachte resultaat is `900 x 600 points` en `Size preserved: True`. Het openen van een nieuw geladen presentatie controleert het opgeslagen bestand, in plaats van alleen de in‑memory‑instellingen.

## **Exporteer notities en hand-outs**

De paginagrootte bepaalt het beschikbare gebied voor notities of hand‑out‑lay‑outs. Ze activeren die lay‑outs niet vanzelf: configureer ook de exportopties. Export van reguliere dia’s blijft de dia‑afmetingen gebruiken.

### **Exporteer notities naar PDF en PNG**

Ken [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notescommentslayoutingoptions/) toe aan [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) om notities in de PDF op te nemen. Dit voorbeeld rendert tevens de eerste dia met notities naar PNG met behulp van [Slide::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/getimage/) en [RenderingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/renderingoptions/).

De [BottomTruncated](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notespositions/) modus houdt de notities op één pagina; notities die niet passen kunnen worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 punten. Bij de beeldschaal van 1 × 1 die hieronder wordt gebruikt, is de PNG 900 × 600 pixels. Punten beschrijven de paginageometrie; pixels beschrijven de rasteroutput, waarvan de afmetingen ook afhangen van de render‑schaal.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Voor PDF‑export met lange notities laat [BottomFull](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/notespositions/) extra pagina’s toe indien nodig. Gebruik die modus niet met de enkele‑dia‑beeldaanroep hierboven, die dit niet ondersteunt. Na het aanpassen van de grootte, inspecteer de output op afgekapt notities en de plaatsing van bestaande notes‑master‑objecten; alleen de paginagrootte wijzigen, is geen garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/cpp/convert-powerpoint-to-pdf-with-notes/) voor meer informatie over notitie‑export.

### **Exporteer hand‑outs naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handoutlayoutingoptions/) voor meerdere dia‑miniaturen op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 punten in en gebruikt [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/handouttype/) om tot vier dia’s per pagina te rangschikken. De horizontale preset bepaalt de volgorde van de dia’s; de paginoriëntatie komt voort uit de breedte en hoogte.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Het wijzigen van de paginagrootte verandert het beschikbare gebied voor het hand‑out‑raster zonder de afmetingen van de bron‑dia’s te wijzigen. Voor hand‑out‑beelden gebruik je [Presentation::GetImages](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/getimages/) met de hand‑out‑lay‑out, in plaats van de afbeeldingsmethode van een individuele dia. In Aspose.Slides gebruikt de rendering op presentatieniveau de notitiepagina‑afmetingen, terwijl de individuele dia‑beeldaanroep niet de hand‑out‑pagina produceert. Zie [Handout Mode](/slides/nl/cpp/convert-powerpoint-in-handout-mode/) voor lay‑outopties.

## **Paginagrootte in viewers, export en afdrukken**

Houd de opgeslagen presentatiegrootte, de geëxporteerde paginagrootte en de afgedrukte papiergrootte gescheiden:

- **Presentatie‑viewers:** Een viewer kan notities weergeven of afdrukken volgens zijn eigen lay‑outrichtlijnen. Als een andere toepassing het bestand opslaat, open het opnieuw en controleer de afmetingen; de bestandsconversie van die toepassing kan ze normaliseren.
- **Exportformaten:** De notitie‑ en hand‑out‑PDF‑voorbeelden hierboven gebruiken de geconfigureerde paginagrootte. Rasterafbeeldingen gebruiken gehele pixelafmetingen en een render‑schaal, waardoor fractionele puntwaarden afgerond kunnen worden in de beeldoutput. Export van reguliere dia’s past de notitiepagina‑grootte niet toe.
- **Printer‑stuurprogramma’s:** Papierselectie, automatische rotatie en “fit‑to‑page” instellingen kunnen de fysieke output wijzigen zonder de in de presentatie of PDF opgeslagen afmetingen te veranderen. Voor een specifiek papierformaat, stem de printerinstellingen af en controleer de afdrukvoorbeeld.

## **FAQ**

**Kan ik de notitiegrootte alleen voor één dia instellen?**

De notitiepagina‑grootte is een instelling op presentatieniveau. Individuele dia’s kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen aparte paginagrootte per dia.

**Waarom heeft het wijzigen van de notitie‑oriëntatie mijn dia’s niet beïnvloed?**

Notitie‑pagina’s en reguliere dia’s hebben onafhankelijke afmetingen. Gebruik de instellingen voor de reguliere dia‑grootte wanneer je de dia’s zelf wilt herschalen.

**Waarom heeft mijn opgeslagen of afgedrukte resultaat een andere grootte?**

Open eerst de opgeslagen presentatie opnieuw en vergelijk de notitie‑afmetingen. Als die zijn gewijzigd, controleer dan of het opslaan of converteren van het bestand in een andere toepassing de paginainstellingen heeft aangepast. Als dat niet het geval is, controleer dan de export‑lay‑out, beeldschaal, viewer‑instellingen en papiersoort van de printer.