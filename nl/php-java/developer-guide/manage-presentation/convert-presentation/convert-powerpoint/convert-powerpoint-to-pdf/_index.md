---
title: Converteer PPT en PPTX naar PDF in PHP [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF‑bestanden in PHP met behulp van Aspose.Slides, met snelle code‑voorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in PHP biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behoud van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia's kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertypevervangingen kunt detecteren, specifieke dia's voor conversie kunt selecteren en nalevingsnormen kunt toepassen op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam door als argument aan de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van een `save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse biedt de `save`‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides voor PHP via Java voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie in uitvoerdocumenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF’s nauwkeurig overeenkomen met de originele presentaties. Elementen en attributen worden tijdens de conversie nauwkeurig gerenderd, waaronder:

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

Deze code toont hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF kunt converteren:

```php
# Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Sla de presentatie op als PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose biedt een gratis online **PowerPoint‑naar‑PDF‑converter**(https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het PowerPoint‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides levert aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PdfOptions)‑klasse — waarmee u het resulterende PDF kunt aanpassen, het PDF kunt vergrendelen met een wachtwoord, of kunt bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitinstelling voor raster‑afbeeldingen definiëren, aangeven hoe metafiles moeten worden afgehandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

De code‑voorbeeld hieronder toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met meerdere aangepaste opties.

```php
# Instantieer de PdfOptions-klasse.
$pdfOptions = new PdfOptions();

# Stel de kwaliteit in voor JPG-afbeeldingen.
$pdfOptions->setJpegQuality(90);

# Stel de DPI in voor afbeeldingen.
$pdfOptions->setSufficientResolution(300);

# Stel het gedrag voor metafiles in.
$pdfOptions->setSaveMetafilesAsPng(true);

# Stel het compressieniveau voor tekstinhoud in.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definieer de PDF-nalevingsmodus.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Sla de presentatie op als een PDF-document.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Bevat een presentatie verborgen dia's, dan kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PdfOptions)‑klasse gebruiken om de verborgen dia's als pagina's in het resulterende PDF op te nemen.

Deze code toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met verborgen dia's inbegrepen:

```php
# Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instantieer de PdfOptions-klasse.
    $pdfOptions = new PdfOptions();

    # Voeg verborgen dia's toe.
    $pdfOptions->setShowHiddenSlides(true);

    # Sla de presentatie op als PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint naar PDF converteren met wachtwoordbeveiliging**

Deze code demonstreert hoe u een PowerPoint‑presentatie kunt omzetten in een met wachtwoord beveiligde PDF met behulp van de beschermingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/)‑klasse:

```php
# Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instantieer de PdfOptions-klasse.
    $pdfOptions = new PdfOptions();

    # Stel een PDF-wachtwoord en toegangsrechten in.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Sla de presentatie op als PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Lettertypevervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/#setWarningCallback)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/)‑klasse, waarmee u tijdens het PowerPoint‑naar‑PDF‑conversieproces lettertypevervangingen kunt detecteren.

Deze code toont hoe u lettertypevervangingen kunt detecteren:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Stel de waarschuwingscallback in de PDF-opties in.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("sample.pptx");
try {
    // Sla de presentatie op als PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 
Voor meer informatie over lettertypevervanging, zie het artikel [Font Substitution](/slides/nl/php-java/font-substitution/).
{{% /alert %}} 

## **Selecte dia's uit PowerPoint naar PDF converteren**

Deze code demonstreert hoe u alleen specifieke dia's uit een PowerPoint‑presentatie naar PDF kunt converteren:

```php
# Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Stel een array met dia‑nummers in.
    $slides = array(1, 3);

    # Sla de presentatie op als PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze code demonstreert hoe u een PowerPoint‑presentatie naar PDF kunt converteren met een opgegeven dia‑grootte:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("SelectedSlides.pptx");

# Maak een nieuwe presentatie met een aangepaste dia-grootte.
$resizedPresentation = new Presentation();

try {
    # Stel de aangepaste dia-grootte in.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Kloon de eerste dia uit de originele presentatie.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Sla de verkleinde presentatie op als PDF met notities.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Deze code demonstreert hoe u een PowerPoint‑presentatie kunt converteren naar een PDF die notities bevat:

```php
# Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Configureer de PDF-opties met notitie‑lay-out.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Sla de presentatie op als een PDF met notities.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met één van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF’s oplevert op basis van verschillende nalevingsnormen:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF to HTML](https://products.aspose.com/slides/nl/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/nl/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/nl/php-java/conversion/pdf-to-jpg/) en [PDF to PNG](https://products.aspose.com/slides/nl/php-java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF to SVG](https://products.aspose.com/slides/nl/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nl/php-java/conversion/pdf-to-tiff/), en [PDF to XML](https://products.aspose.com/slides/nl/php-java/conversion/pdf-to-xml/) — worden eveneens ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele afbeelding. Individuele paden worden niet bewaard als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de volledige afbeelding geleverd.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om de geconverteerde PDF te beveiligen met een wachtwoord?**

Absoluut. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in de PDF?**

Gebruik de `setShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/)‑klasse om verborgen dia's op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals `setJpegQuality` en `setSufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/)‑klasse om hoge‑kwaliteit beelden in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan verschillende normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten aan toegankelijkheids‑ en archiveringsvereisten voldoen.

## **Aanvullende bronnen**

- [Aspose.Slides voor PHP via Java Documentatie](/slides/nl/php-java/)
- [Aspose.Slides voor PHP via Java API‑referentie](https://reference.aspose.com/slides/nl/php-java/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)