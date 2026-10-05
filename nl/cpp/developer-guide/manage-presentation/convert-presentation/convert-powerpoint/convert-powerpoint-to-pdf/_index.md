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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden in C++ met Aspose.Slides, inclusief snelle codevoorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C++ biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze handleiding laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te beheersen, verborgen dia's kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑substituties kunt detecteren, specifieke dia's kunt selecteren voor conversie, en nalevingsnormen kunt toepassen op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende indelingen naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse en slaat u vervolgens de presentatie op als PDF met behulp van de [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) methode. De [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) klasse biedt de [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor C++ voegt zijn API‑informatie en versienummer toe aan de uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het veld PDF Producer met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit de uitvoerdocumenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF‑bestanden nauw aansluiten bij de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig gerenderd in de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Het onderstaande voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met behulp van de standaard exportinstellingen.

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
Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het PowerPoint‑naar‑PDF‑conversieproces demonstreren. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) klasse—die u in staat stellen het resulterende PDF aan te passen, het PDF te beveiligen met een wachtwoord, of op te geven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met behulp van aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, opgeven hoe metafiles moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het onderstaande voorbeeld exporteert een presentatie naar PDF‑1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie ingesteld op 300 DPI, metafiles opgeslagen als PNG, en Flate‑tekstcompressie.

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

### **Embedded OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebed Excel‑werkboek bevat, wilt u mogelijk dat PDF‑ontvangers zowel toegang hebben tot de gegevens van het werkboek als de dia's kunnen bekijken. Roep [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) aan met `true` om ingebedde OLE‑bestanden te behouden als bijlagen in het resulterende PDF.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt weergegeven op de PDF‑pagina, maar het ingebedde bestand wordt niet toegevoegd als bijlage. Door de optie op `true` te zetten, wordt de bestandsdata bovendien bijgevoegd. Het voorbeeld blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingebedde bestand afzonderlijk te openen of op te slaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

Het onderstaande voorbeeld laadt een presentatie die al een ingebed Excel‑werkboek bevat en exporteert deze naar PDF met het werkboek als bijlage.

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

1. Open het geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Bijlagen**‑paneel van de viewer en zoek het ingebedde werkboek.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toestaat. Het voorbeeld op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingebedde bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkboeken. Dit zijn vereisten van de norm, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en toont geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) methode van de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) klasse gebruiken om de verborgen dia's op te nemen als pagina's in het resulterende PDF.

Het onderstaande voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia's.

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

### **PowerPoint naar een met wachtwoord beveiligd PDF converteren**

Het onderstaande voorbeeld exporteert een presentatie naar een PDF die een wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

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

Aspose.Slides biedt de [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) methode onder de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) klasse, waarmee u lettertype‑substituties kunt detecteren tijdens het PowerPoint‑naar‑PDF‑conversieproces.

Het onderstaande voorbeeld exporteert een presentatie naar PDF en drukt lettertype‑substitutiewaarschuwingen af naar de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet‑beschikbaar lettertype tijdens de export wordt vervangen.

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
Voor meer informatie over lettertype‑substitutie, zie het artikel [Lettertype‑substitutie](/slides/nl/cpp/font-substitution/).
{{% /alert %}} 

## **Geselecteerde dia's uit PowerPoint naar PDF converteren**

Het onderstaande voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dia‑nummers in deze array beginnen bij één, en de invoerpresentatie moet minstens drie dia's bevatten.

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

Het onderstaande voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud om te passen en exporteert de enkele dia naar PDF.

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

## **PowerPoint naar PDF converteren in notitiedia‑weergave**

Het onderstaande voorbeeld exporteert een presentatie naar PDF, waarbij de spreker‑notities van elke dia onder de dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

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

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat om een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met elk van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C++‑code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende nalevingsnormen:

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
U kunt [PDF naar HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe graphics zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de gehele figuur geleverd.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om de geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in de PDF?**

Gebruik de [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) methode in de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) klasse om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit beheersen door methoden zoals [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) en [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) klasse te gebruiken om hoge‑kwaliteit afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides de PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan diverse normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor C++‑documentatie](/slides/nl/cpp/)
- [Aspose.Slides voor C++ API‑referentie](https://reference.aspose.com/slides/cpp/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/conversion)