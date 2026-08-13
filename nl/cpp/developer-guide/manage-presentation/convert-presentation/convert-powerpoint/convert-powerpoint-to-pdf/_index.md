---
title: PPT en PPTX naar PDF converteren in C++ [Geavanceerde functies inbegrepen]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's converteren in C++ met Aspose.Slides, met snelle codevoorbeelden en geavanceerde conversieopties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C++ biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behoud van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden met wachtwoord beveiligt, lettertype‑vervangingen detecteert, specifieke dia’s voor conversie selecteert en nalevingsstandaarden toepast op uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse en slaat u de presentatie vervolgens op als PDF met behulp van een `Save`‑methode. De [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse biedt de `Save`‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het veld Application in met "*Aspose.Slides*" en het PDF Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoerdocumenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides maakt het mogelijk:

* Hele presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF‑bestanden nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het maximum aan kwaliteit.

Deze C++‑code laat zien hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF converteert:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose biedt een gratis online **PowerPoint‑naar‑PDF‑converter**(https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse — die u in staat stellen het resulterende PDF aan te passen, het PDF te beveiligen met een wachtwoord, of op te geven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, opgeven hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

Het onderstaande code‑voorbeeld laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verschillende aangepaste opties.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de PdfOptions‑klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Stel de kwaliteit in voor JPG‑afbeeldingen.
pdfOptions->set_JpegQuality(90);

// Stel DPI in voor afbeeldingen.
pdfOptions->set_SufficientResolution(300);

// Stel het gedrag voor metafiles in.
pdfOptions->set_SaveMetafilesAsPng(true);

// Stel het tekstcompressieniveau in voor tekstuele inhoud.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definieer de PDF‑nalevingsmodus.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instantieer de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Sla de presentatie op als PDF‑document.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [set_ShowHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse gebruiken om de verborgen dia’s op te nemen als pagina’s in het resulterende PDF.

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar PDF converteert met verborgen dia’s:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instantieer de PdfOptions-klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Voeg verborgen dia's toe.
pdfOptions->set_ShowHiddenSlides(true);

// Sla de presentatie op als PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint naar PDF met wachtwoordbeveiliging converteren**

Deze C++‑code laat zien hoe u een PowerPoint‑presentatie converteert naar een wachtwoordbeveiligd PDF met behulp van de beveiligingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instantieer de PdfOptions-klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Stel een PDF-wachtwoord en toegangsrechten in.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Sla de presentatie op als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Lettertype‑vervangingen detecteren**

Aspose.Slides biedt de [set_WarningCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_warningcallback/)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse, waarmee u lettertype‑vervangingen kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Deze C++‑code laat zien hoe u lettertype‑vervangingen detecteert:

```c++
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

// Implementatie van de waarschuwingscallback.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Stel de waarschuwingscallback in de PDF-opties in.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Sla de presentatie op als PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

Voor meer informatie over het ontvangen van callbacks voor lettertype‑vervangingen tijdens het renderen, zie [Getting Warning Callbacks for Fonts Substitution](/slides/nl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑substitutie, zie het artikel [Font Substitution](/slides/nl/cpp/font-substitution/).

{{% /alert %}} 

## **Geselecteerde dia’s uit PowerPoint naar PDF converteren**

Deze C++‑code laat zien hoe u alleen specifieke dia’s uit een PowerPoint‑presentatie naar PDF converteert:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Stel een array van dia‑nummers in.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Sla de presentatie op als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze C++‑code laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met een opgegeven dia‑grootte:

```C++
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

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Maak een nieuwe presentatie met een aangepaste dia‑grootte.
auto resizedPresentation = MakeObject<Presentation>();

// Stel de aangepaste dia‑grootte in.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Kloon de eerste dia van de oorspronkelijke presentatie.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Sla de aangepast grootte presentatie op als PDF met notities.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Deze C++‑code laat zien hoe u een PowerPoint‑presentatie naar een PDF converteert dat notities bevat:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configureer de PDF-opties met notities‑lay‑out.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sla de presentatie op als PDF met notities.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Toegankelijkheid en nalevingsstandaarden voor PDF**

Aspose.Slides maakt het mogelijk een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C++‑code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende nalevingsstandaarden:

```C++
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-xml/)—worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkel figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor het gehele figuur geleverd.

## **FAQ**

### Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

### Is het mogelijk om het geconverteerde PDF te beveiligen met een wachtwoord?

Absoluut. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

### Hoe neem ik verborgen dia’s op in het PDF?

Gebruik de `set_ShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om verborgen dia’s op te nemen in het resulterende PDF.

### Kan Aspose.Slides een hoge beeldkwaliteit behouden in het PDF?

Ja, u kunt de beeldkwaliteit regelen met methoden zoals `set_JpegQuality` en `set_SufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om hoge‑kwaliteit afbeeldingen in uw PDF te waarborgen.

### Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan verschillende standaarden, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor C++ Documentatie](/slides/nl/cpp/)
- [Aspose.Slides voor C++ API‑referentie](https://reference.aspose.com/slides/nl/cpp/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/nl/conversion)