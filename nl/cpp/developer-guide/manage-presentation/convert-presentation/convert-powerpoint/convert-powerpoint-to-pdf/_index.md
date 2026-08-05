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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in C++ met Aspose.Slides, inclusief snelle codevoorbeelden en geavanceerde conversieopties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑indeling in C++ biedt verschillende voordelen, waaronder compatibiliteit met verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑substituties detecteert, specifieke dia’s selecteert voor conversie en nalevingsnormen toepast op de uitvoer‑documenten.

## **PowerPoint naar PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van een `Save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse biedt de `Save`‑methode die gewoonlijk wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides voor C++ voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie uit uitvoerdocumenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
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

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Deze C++‑code toont hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF converteert:
```c++
// Instantieer de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Sla de presentatie op als PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
Aspose biedt een gratis online **PowerPoint‑naar‑PDF‑converter**(https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse—die u in staat stellen om het resulterende PDF aan te passen, het PDF met een wachtwoord te beveiligen, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met behulp van aangepaste conversie‑opties kunt u uw voorkeurskwaliteitsinstelling voor raster‑afbeeldingen definiëren, opgeven hoe metafiles moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het onderstaande code‑voorbeeld laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verschillende aangepaste opties.
```c++
// Instantieer de PdfOptions‑klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Stel de kwaliteit in voor JPG‑afbeeldingen.
pdfOptions->set_JpegQuality(90);

// Stel de DPI in voor afbeeldingen.
pdfOptions->set_SufficientResolution(300);

// Stel het gedrag in voor metafiles.
pdfOptions->set_SaveMetafilesAsPng(true);

// Stel het compressieniveau in voor tekstuele inhoud.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definieer de PDF‑nalevingsmodus.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instantieer de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Sla de presentatie op als een PDF‑document.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [set_ShowHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse gebruiken om de verborgen dia’s op te nemen als pagina’s in het resulterende PDF.

Deze C++‑code toont hoe u een PowerPoint‑presentatie naar PDF converteert met inbegrepen verborgen dia’s:
```c++
// Instantieer de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instantieer de PdfOptions‑klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Voeg verborgen dia’s toe.
pdfOptions->set_ShowHiddenSlides(true);

// Sla de presentatie op als PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint naar PDF met wachtwoordbeveiliging converteren**

Deze C++‑code laat zien hoe u een PowerPoint‑presentatie converteert naar een met wachtwoord beveiligd PDF met behulp van de beveiligingsparameters uit de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse:
```c++
// Instantieer de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instantieer de PdfOptions‑klasse.
auto pdfOptions = MakeObject<PdfOptions>();

// Stel een PDF‑wachtwoord en toegangsrechten in.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Sla de presentatie op als PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Lettertype‑substituties detecteren**

Aspose.Slides biedt de [set_WarningCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_warningcallback/)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse, waarmee u lettertype‑substituties kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

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
    // Instantieer de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand vertegenwoordigt.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Stel de waarschuwingscallback in PDF‑opties in.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Sla de presentatie op als PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 
Voor meer informatie over het ontvangen van callbacks voor lettertype‑substituties tijdens het renderproces, zie [Getting Warning Callbacks for Fonts Substitution](/slides/nl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑substitutie, zie het artikel [Font Substitution](/slides/nl/cpp/font-substitution/).
{{% /alert %}} 

## **Geselecteerde dia’s van PowerPoint naar PDF converteren**

Deze C++‑code laat zien hoe u alleen specifieke dia’s van een PowerPoint‑presentatie naar PDF converteert:
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

Deze C++‑code laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met een opgegeven dia‑grootte:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantieer de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Maak een nieuwe presentatie met een aangepaste dia‑grootte.
auto resizedPresentation = MakeObject<Presentation>();

// Stel de aangepaste dia‑grootte in.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Kloon de eerste dia van de originele presentatie.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Sla de verkleinde presentatie op als PDF met notities.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Deze C++‑code laat zien hoe u een PowerPoint‑presentatie naar PDF converteert waarbij notities worden meegenomen:
```C++
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configureer de PDF-opties met notitie-layout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Sla de presentatie op als PDF met notities.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Toegankelijkheid en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat om een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C++‑code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF’s genereert op basis van verschillende nalevingsnormen:
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

{{% alert title="Note" color="warning" %}} 
Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt conversies uitvoeren naar [PDF to HTML](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-jpg/), en [PDF to PNG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-png/). Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF to SVG](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-tiff/), en [PDF to XML](https://products.aspose.com/slides/nl/cpp/conversion/pdf-to-xml/)—worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA beschouwt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen gemarkeerd worden als artefacten; alternatieve tekst wordt alleen voor de hele figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om het geconverteerde PDF te beveiligen met een wachtwoord?**

Zeker. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia’s op in het PDF?**

Gebruik de `set_ShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse om verborgen dia’s op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in het PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen door methoden zoals `set_JpegQuality` en `set_SufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/)‑klasse te gebruiken om afbeeldingen van hoge kwaliteit in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat om PDF’s te exporteren die voldoen aan diverse normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids- en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor C++ Documentatie](/slides/nl/cpp/)
- [Aspose.Slides voor C++ API‑referentie](https://reference.aspose.com/slides/nl/cpp/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/nl/conversion)