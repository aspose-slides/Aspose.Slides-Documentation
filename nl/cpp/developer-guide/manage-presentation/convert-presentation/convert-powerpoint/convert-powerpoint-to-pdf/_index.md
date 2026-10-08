---
title: Converteer PPT en PPTX naar PDF in C++ [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint converteren
- presentatie converteren
- PowerPoint naar PDF
- presentatie naar PDF
- PPT naar PDF
- PPT converteren naar PDF
- PPTX naar PDF
- PPTX converteren naar PDF
- PowerPoint opslaan als PDF
- PPT opslaan als PDF
- PPTX opslaan als PDF
- PPT exporteren naar PDF
- PPTX exporteren naar PDF
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in C++ met Aspose.Slides, met snelle codevoorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C++ biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behoud van de lay‑out en opmaak van uw presentatie. Deze handleiding toont hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia’s kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑substituties kunt detecteren, specifieke dia’s voor conversie kunt selecteren en nalevingsstandaarden kunt toepassen op de gegenereerde documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende indelingen naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentatie](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met de [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑methode. De [Presentatie](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse biedt de [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑methode die gewoonlijk wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Let op** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoer‑documenten te verwijderen of te wijzigen.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Complete presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij de resulterende PDF‑bestanden nauwkeurig overeenkomen met de originele presentaties. Elementen en attributen worden correct gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op maximale kwaliteit.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met de standaard export‑instellingen.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatiet‑naar‑PDF‑proces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties – eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse – waarmee u het resulterende PDF‑bestand kunt aanpassen, het PDF‑bestand met een wachtwoord kunt beveiligen of kunt aangeven hoe het conversie‑proces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metafiles worden afgehandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie op 300 DPI, metafiles opgeslagen als PNG en Flate‑tekstcompressie.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Ingesloten OLE‑bestanden behouden als PDF‑bijlagen**

Bevat een presentatie een ingesloten Excel‑werkmap, wilt u mogelijk dat PDF‑ontvangers zowel de gegevens van de werkmap als de dia’s kunnen bekijken. Roep [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) aan met `true` om ingesloten OLE‑bestanden te behouden als bijlagen in het resulterende PDF.

Standaard is de waarde `false`: de preview‑afbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina weergegeven, maar het ingesloten bestand wordt niet als bijlage toegevoegd. Als u de optie op `true` zet, wordt de bestandsdata bovendien bijgevoegd. De preview blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingesloten bestand apart te openen of op te slaan. Het OLE‑object wordt niet een interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingesloten Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Om het resultaat te controleren:

1. Open het geëxporteerde PDF‑bestand in een viewer die bestands‑bijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dit toelaat. De preview op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}

De PDF/A‑standaarden leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, inclusief Excel‑werkmappen. Dit zijn eisen van de standaarden, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en toont geen PDF/A‑export.

{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Bevat een presentatie verborgen dia’s, dan kunt u de [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)‑methode van de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF‑bestand op te nemen.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief alle verborgen dia’s.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **PowerPoint naar een wachtwoord‑beveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die geopend moet worden met het wachtwoord `password`. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Lettertype‑substituties detecteren**

Aspose.Slides biedt de [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse, waarmee u lettertype‑substituties tijdens het PowerPoint‑naar‑PDF‑conversieproces kunt detecteren.

Het volgende voorbeeld exporteert een presentatie naar PDF en schrijft waarschuwingen over lettertype‑substituties naar de console. Een waarschuwing wordt alleen weergegeven wanneer een niet‑beschikbaar lettertype wordt vervangen tijdens de export.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Voor meer informatie over lettertype‑substitutie, zie het artikel [Font Substitution](/slides/nl/cpp/font-substitution/).

{{% /alert %}} 

### **Omgaan met lettertypen zonder een toegewijd vette stijl**

Een presentatie kan vette opmaak toepassen op tekst zelfs wanneer het gebruikte lettertype geen aparte vette stijl heeft. De tekst kan nog steeds vet lijken door synthetische verdikking, waarbij de normale glyphs kunstmatig worden verdikt. Wanneer die tekst te zwaar of anderszins afwijkt van het beoogde uiterlijk in PDF, kunt u [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) aanroepen met `true`. Deze optie rendert de getroffen tekst als bitmap tijdens de PDF‑export en kan de weergave voor bepaalde lettertypen verbeteren. Standaard is de waarde `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vette opmaak toegepast op hetzelfde lettertype, dat geen eigen vette stijl heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

De volgende voorbeelden tonen de uitvoer met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst zwaardere lijntjes wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de lijntjes lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling kiest voor uw presentatie.

| Optie uitgeschakeld (`false`, standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld zet het inschakelen van de optie alleen de vette tekst om in een bitmap: deze kan niet worden geselecteerd, gekopieerd of gezocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide tekststrengen tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen aparte vette stijl heeft. [Lettertype‑substitutie](/slides/nl/cpp/font-substitution/) kiest in plaats daarvan een ander lettertype wanneer het origineel niet beschikbaar is.

## **Geselecteerde dia’s uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. Dia‑nummers in deze array beginnen bij één, en de invoer‑presentatie moet ten minste drie dia’s bevatten.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud om te passen en exporteert de enkele dia naar PDF.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint naar PDF converteren in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de spreker‑notities onder elke dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Toegankelijkheids‑ en nalevingsstandaarden voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze C++‑code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden genereert op basis van verschillende nalevingsstandaarden:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt omzetten naar veelgebruikte bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/) en [PDF naar XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de hele figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatic aanroepen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia’s op in de PDF?**

Gebruik de [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)‑methode in de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse om verborgen dia’s in de resulterende PDF op te nemen.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen door methoden te gebruiken zoals [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) en [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse om hoge‑kwaliteit afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides de PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides stelt u in staat PDF‑bestanden te exporteren die voldoen aan diverse standaarden, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten aan toegankelijkheids‑ en archiveringsvereisten voldoen.

## **Aanvullende bronnen**

- [Aspose.Slides for C++ Documentation](/slides/nl/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)