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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in C++ met Aspose.Slides, inclusief snelle codevoorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C++ biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia's kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑substituties kunt detecteren, specifieke dia's kunt selecteren voor conversie en nalevingsnormen kunt toepassen op de uitvoerdocumenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van een [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑methode. De [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse stelt de [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑methode beschikbaar die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor C++ voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld met “*Aspose.Slides*” en het PDF‑Producer‑veld met een waarde in de vorm “*Aspose.Slides v XX.XX*”. **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie te wijzigen of te verwijderen uit uitvoerdocumenten.
{{% /alert %}}

Aspose.Slides maakt het mogelijk om te converteren:

* Gehele presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij wordt gegarandeerd dat de resulterende PDF‑bestanden nauw aansluiten bij de originele presentaties. Elementen en attributen worden accuraat gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op maximaal kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met behulp van de standaard exportinstellingen.

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
Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF aan te passen, het PDF met een wachtwoord te beveiligen, of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeurinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metafiles worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

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

### **Automatisch afbeeldingcompressie selecteren**

Wanneer een presentatie veel foto’s of screenshots bevat, kan het verkleinen van de export‑PDF de moeite van e‑mailen of downloaden verminderen. Roep [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) aan met `true` om automatisch het meest geschikte compressie‑algoritme voor elke afbeelding te selecteren tijdens de PDF‑export.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Deze optie selecteert een compressie‑algoritme voor elke afbeelding. Het verlagen van JPEG‑kwaliteit met [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) vermindert de JPEG‑beeldkwaliteit, terwijl het verlagen van de resolutie met [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) afbeeldingen laat downsamplen naar een lagere resolutie, wat details kan verminderen. Het inschakelen van automatische compressie‑selectie verlaagt op zich geen van deze instellingen.

Het selecteren van compressie‑algoritmen vereist extra verwerkingstijd en geheugen. De mate van verkleining hangt af van de afbeeldingen in de presentatie en de export‑instellingen; een vaste verkleining kan niet voor elke presentatie worden gegarandeerd.

### **Ingebedde OLE‑bestanden behouden als PDF‑bijlagen**

Bevat een presentatie een ingebed Excel‑werkboek, wilt u dat PDF‑ontvangers zowel de gegevens van het werkboek als de dia's kunnen bekijken. Roep [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) aan met `true` om ingebedde OLE‑bestanden als bijlagen in de resulterende PDF te behouden.

De standaardwaarde is `false`: de voorbeeld‑afbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina weergegeven, maar het ingebedde bestand wordt niet als bijlage toegevoegd. Door de optie op `true` te zetten wordt het bestand ook toegevoegd. Het voorbeeld blijft een visuele weergave; de bijlage laat ontvangers het ingebedde bestand afzonderlijk openen of opslaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

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

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek het ingebedde werkboek.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toelaat. Het voorbeeld op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op voor bijlagen: PDF/A‑1 staat ingebedde bestanden niet toe, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, inclusief Excel‑werkboeken. Dit zijn vereisten van de normen, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑conformiteit en demonstreert geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Bevat een presentatie verborgen dia's, kunt u de [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)‑methode van de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse gebruiken om de verborgen dia's als pagina’s in de resulterende PDF op te nemen.

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

### **PowerPoint naar een met wachtwoord beveiligde PDF converteren**

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

Aspose.Slides biedt de [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse, waarmee u lettertype‑substituties kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

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

### **Omgaan met lettertypen zonder een eigen vet stijl**

Een presentatie kan vette opmaak toepassen op tekst, zelfs wanneer het gekozen lettertype geen eigen vet stijl heeft. De tekst kan dan synthetisch vet worden gemaakt, waardoor de reguliere glyphs kunstmatig dikker worden. Wanneer die tekst te zwaar of anderszins niet overeenkomt met de beoogde weergave in PDF, kunt u [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) aanroepen met `true`. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF‑export en kan de weergave van bepaalde lettertypen verbeteren. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vetgedrukte opmaak toegepast op hetzelfde lettertype, dat geen eigen vet stijl heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in en exporteert deze naar PDF:

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

De volgende voorbeelden tonen de uitvoer met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst zwaardere streken met de optie uitgeschakeld. Met de optie ingeschakeld zijn de streken lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld zorgt het inschakelen van de optie er alleen voor dat de vette tekst wordt gerasterd: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen verschijnen zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die als vet is opgemaakt wanneer het lettertype geen eigen vette stijl heeft. [Font substitution](/slides/nl/cpp/font-substitution/) kiest in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Geselecteerde dia's uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dia‑nummers in deze array zijn één‑gebaseerd, en de invoerpresentatie moet minimaal drie dia's bevatten.

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

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke dia onder de dia worden geplaatst. Gebruik een presentatie met aantekeningen om het resultaat te zien.

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

## **Toegankelijkheids‑ en conformiteitsnormen voor PDF**

Aspose.Slides maakt het mogelijk een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze conformiteitsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C++‑code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden maakt op basis van verschillende conformiteitsnormen:

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
Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) en [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑bewerkingen naar gespecialiseerde formaten—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), en [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—worden eveneens ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, grafieken en formules als één enkele figuur. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de gehele figuur opgegeven.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in de PDF?**

Gebruik de [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)‑methode in de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen door methoden zoals [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) en [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)‑klasse te gebruiken om hoogwaardige beelden in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑conformiteitsnormen?**

Ja, Aspose.Slides maakt het mogelijk PDF‑bestanden te exporteren die voldoen aan diverse normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for C++ Documentation](/slides/nl/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)