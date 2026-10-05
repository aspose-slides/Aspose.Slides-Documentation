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
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in PHP met Aspose.Slides, inclusief snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint-presentaties (PPT, PPTX, ODP, enz.) naar PDF-formaat in PHP biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behoud van de lay-out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF-documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te controleren, verborgen dia's kunt opnemen, PDF-bestanden kunt beveiligen met een wachtwoord, lettertypevervangingen kunt detecteren, specifieke dia's kunt selecteren voor conversie, en nalevingsnormen kunt toepassen op de gegenereerde documenten.

## **PowerPoint naar PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse en slaat u vervolgens de presentatie op als PDF met behulp van de [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) methode. De [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse biedt de [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java voegt zijn API-informatie en versienummer toe aan de gegenereerde documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF Producer-veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie te wijzigen of te verwijderen uit de uitgangsdocumenten.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF-bestanden nauwkeurig overeenkomen met de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig weergegeven tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea-opmaak
* Hyperlinks
* Kop- en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint-naar-PDF-conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Het onderstaande voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met behulp van de standaard exportinstellingen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint-naar-PDF-converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie-naar-PDF-conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties-eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) klasse die u in staat stellen het resulterende PDF aan te passen, het PDF te beveiligen met een wachtwoord, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met behulp van aangepaste conversie-opties kunt u uw voorkeurstoestand voor de kwaliteit van rasterafbeeldingen definiëren, aangeven hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Ingesloten OLE-bestanden behouden als PDF-bijlagen**

Als een presentatie een ingesloten Excel-werkmap bevat, wilt u wellicht dat PDF-ontvangers zowel de gegevens van de werkmap als de dia's kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) aan met `true` om ingesloten OLE-bestanden als bijlagen te behouden in de resulterende PDF.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE-object wordt op de PDF-pagina weergegeven, maar het ingesloten bestand wordt niet toegevoegd als bijlage. Het instellen van de optie op `true` voegt bovendien de bestandsgegevens toe. De voorbeeldweergave blijft een visuele representatie; de bijlage stelt ontvangers in staat het ingesloten bestand afzonderlijk te openen of op te slaan. Het OLE-object wordt geen interactieve Excel-werkblad op de PDF-pagina.

Het onderstaande voorbeeld laadt een presentatie die al een ingesloten Excel-werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Bijlagen**-paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toestaat. De voorbeeldweergave op de PDF-pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A-normen leggen beperkingen op voor bijlagen: PDF/A-1 verbiedt ingesloten bestanden, PDF/A-2 staat alleen PDF/A-bijlagen toe, en PDF/A-3 staat andere bestandstypen toe, waaronder Excel-werkmappen. Dit zijn eisen van de normen, geen beperkingen die specifiek zijn voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF-nalevingsinstelling en demonstreert geen PDF/A-export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) methode van de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) klasse gebruiken om de verborgen dia's op te nemen als pagina's in de resulterende PDF.

Het onderstaande voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia's.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint naar een met wachtwoord beveiligde PDF converteren**

Het onderstaande voorbeeld exporteert een presentatie naar een PDF die wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken in hoge kwaliteit.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Lettertype-vervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) methode onder de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) klasse, waardoor u lettertype-vervangingen kunt detecteren tijdens het presentatie-naar-PDF-conversieproces.

Het onderstaande voorbeeld exporteert een presentatie naar PDF en print waarschuwingen voor lettertype-vervangingen naar de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet-beschikbaar lettertype wordt vervangen tijdens de export.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Voor meer informatie over lettertype-vervanging, zie het artikel [Lettertype-vervanging](/slides/nl/php-java/font-substitution/).
{{% /alert %}} 

## **Geselecteerde dia's uit PowerPoint naar PDF converteren**

Het onderstaande voorbeeld exporteert dia's 1 en 3 uit een presentatie naar PDF. Dia-nummers in deze array beginnen bij één, en de invoerpresentatie moet minstens drie dia's bevatten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia-grootte**

Het onderstaande voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia-grootte van 612 x 792 points (8.5 x 11 inch). Het schaalt de dia-inhoud zodat deze past en exporteert de enkele dia naar PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Verwijder de lege dia die bij het maken van de nieuwe presentatie werd aangemaakt.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint naar PDF converteren in notities-dia-weergave**

Het onderstaande voorbeeld exporteert een presentatie naar PDF, waarbij de spreker-notities van elke dia onder de dia worden geplaatst. Gebruik een presentatie met spreker-notities om het resultaat te zien.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Toegankelijkheid en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint-document exporteren naar PDF met elk van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code demonstreert een PowerPoint-naar-PDF-conversieproces dat meerdere PDF-bestanden genereert op basis van verschillende nalevingsnormen:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides ondersteunt PDF-conversie-operaties, waarmee u PDF-bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF-conversie-operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één figuur. Individuele paden worden niet behouden als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de gehele figuur geleverd.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint-bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch-conversie van meerdere PPT- of PPTX-bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in het PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) klasse om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit behouden in het PDF?**

Ja, u kunt de beeldkwaliteit controleren met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) en [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) in de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) klasse om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides de PDF/A-nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF-bestanden te exporteren die voldoen aan [verschillende normen](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids- en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor PHP via Java Documentatie](/slides/nl/php-java/)
- [Aspose.Slides voor PHP via Java API-referentie](https://reference.aspose.com/slides/php-java/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)