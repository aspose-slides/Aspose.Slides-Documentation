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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in C++ met behulp van Aspose.Slides, met snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C++ biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay-out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia's kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑substituties kunt detecteren, specifieke dia's kunt selecteren voor conversie, en nalevingsnormen op de uitvoerdocumenten kunt toepassen.

## **PowerPoint naar PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met behulp van de `Save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse biedt de `Save`‑methode die gewoonlijk wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="OPMERKING"  color="warning"   %}} 

Aspose.Slides voor C++ voegt zijn API‑informatie en versienummer toe aan de uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Let op** dat u Aspose.Slides niet kunt instrueren om deze informatie te wijzigen of te verwijderen uit uitvoerdocumenten.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij wordt gegarandeerd dat de resulterende PDF's nauw aansluiten bij de originele presentaties. Elementen en attributen worden tijdens de conversie nauwkeurig gerenderd, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alineaopmaak
* Hyperlinks
* Kop- en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Deze C++‑code toont hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF kunt converteren:

```c++
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Sla de presentatie op als PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online **PowerPoint‑naar‑PDF‑converter**(https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het PowerPoint‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF aan te passen, het PDF te beveiligen met een wachtwoord, of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor rasterafbeeldingen definiëren, bepalen hoe metagegevensbestanden moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het onderstaande code‑voorbeeld toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met verschillende aangepaste opties.

```c++
// Instantieer de PdfOptions-klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Stel de kwaliteit in voor JPG-afbeeldingen.
pdfOptions->set_JpegQuality(90);

// Stel de DPI in voor afbeeldingen.
pdfOptions->set_SufficientResolution(300);

// Stel het gedrag in voor metabestanden.
pdfOptions->set_SaveMetafilesAsPng(true);

// Stel het compressieniveau voor tekst in voor tekstuele inhoud.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definieer de PDF-nalevingsmodus.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Sla de presentatie op als PDF-document.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [set_ShowHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse gebruiken om de verborgen dia's als pagina's in het resulterende PDF op te nemen.

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met inbegrepen verborgen dia's:

```c++
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

### **PowerPoint naar PDF converteren met wachtwoordbeveiliging**

Deze C++‑code demonstreert hoe u een PowerPoint‑presentatie kunt omzetten naar een met wachtwoord beveiligd PDF met behulp van de beveiligingsparameters uit de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse:

```c++
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

### **Lettertype‑substituties detecteren**

Aspose.Slides biedt de [set_WarningCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_warningcallback/)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse, waarmee u tijdens het PowerPoint‑naar‑PDF‑conversieproces lettertype‑substituties kunt detecteren.

Deze C++‑code toont hoe u lettertype‑substituties kunt detecteren:

```c++
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

    // Stel de waarschuwingscallback in in PDF-opties.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Sla de presentatie op als PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Voor meer informatie over het ontvangen van callbacks voor lettertype‑substituties tijdens het renderen, zie [Waarschuwingen ontvangen voor lettertype‑substitutie](/slides/nl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑substitutie, zie het artikel [Lettertype‑substitutie](/slides/nl/cpp/font-substitution/).

{{% /alert %}} 

## **Selectieve dia's van PowerPoint naar PDF converteren**

Deze C++‑code toont hoe u alleen specifieke dia's uit een PowerPoint‑presentatie naar PDF kunt converteren:

```C++
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Stel een array van dia-nummers in.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Sla de presentatie op als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met een opgegeven dia‑grootte:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar een PDF kunt converteren dat notities bevat:

```C++
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configureer de PDF-opties met notitie‑lay-out.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sla de presentatie op als PDF met notities.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Toegankelijkheid en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met behulp van een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C++‑code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF's produceert op basis van verschillende nalevingsnormen:

```C++
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

{{% alert title="Opmerking" color="warning" %}} 

Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑bewerkingen naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-xml/)—worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkel object. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor het gehele object verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om het geconverteerde PDF te beveiligen met een wachtwoord?**

Absoluut. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsmachtigingen te definiëren tijdens het conversieproces.

**Hoe voeg ik verborgen dia's toe aan het PDF?**

Gebruik de `set_ShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om verborgen dia's in het resulterende PDF op te nemen.

**Kan Aspose.Slides een hoge beeldkwaliteit behouden in het PDF?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals `set_JpegQuality` en `set_SufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan verschillende normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids- en archiveringsvereisten.

## **Additional Resources**

- [Aspose.Slides voor C++ Documentatie](/slides/nl/cpp/)
- [Aspose.Slides voor C++ API‑referentie](https://reference.aspose.com/slides/nl/cpp/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/nl/conversion)