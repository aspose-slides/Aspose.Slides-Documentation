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
description: "Converteer PowerPoint PPT/PPTX naar PDF's van hoge kwaliteit, doorzoekbaar in PHP met Aspose.Slides, met snelle codevoorbeelden en geavanceerde conversieopties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in PHP biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te beheren, verborgen dia’s opneemt, PDF‑bestanden met wachtwoord beveiligt, lettertype‑substitutie detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint naar PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende indelingen naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met behulp van de [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑methode. De [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑klasse biedt de [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides for PHP via Java voegt zijn API‑informatie en versienummer toe aan de uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Let op** dat u Aspose.Slides niet kunt instrueren deze informatie te wijzigen of te verwijderen uit de uitvoer‑documenten.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Complete presentaties naar PDF te converteren
* Specifieke dia’s uit een presentatie naar PDF te exporteren

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF‑bestanden nauw aansluiten bij de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaardproces voor PowerPoint‑naar‑PDF‑conversie gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met de standaard exportinstellingen.

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

{{% alert color="info" title="Opmerking" %}}

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse — die u toelaten het resulterende PDF aan te passen, het PDF met een wachtwoord te beveiligen, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metafiles verwerkt moeten worden, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enz.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, afbeeldingsresolutie op 300 DPI, metafiles opgeslagen als PNG en Flate‑tekstcompressie.

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

### **Ingebedde OLE‑bestanden behouden als PDF‑bijlagen**

Bevat een presentatie een ingebedde Excel‑werkmap, wilt u waarschijnlijk dat PDF‑ontvangers zowel de gegevens van de werkmap als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) aan met `true` om ingebedde OLE‑bestanden als bijlagen in de resulterende PDF te behouden.

Standaard is de waarde `false`: de voorbeeld‑afbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina gerenderd, maar het ingebedde bestand wordt niet als bijlage toegevoegd. Het instellen van de optie op `true` voegt bovendien de bestandsdata toe. Het voorbeeld blijft een visuele weergave; de bijlage laat ontvangers het ingebedde bestand afzonderlijk openen of opslaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die reeds een ingebedde Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

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

1. Open de geëxporteerde PDF in een viewer die bestand‑bijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de ingebedde werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dit toelaat. Het voorbeeld op de PDF‑pagina is los van de bijlage.

{{% alert color="info" title="Opmerking" %}}

De PDF/A‑normen leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingebedde bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, inclusief Excel‑werkmappen. Dit zijn eisen van de normen, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en toont geen PDF/A‑export.

{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Bevat een presentatie verborgen dia’s, dan kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/)‑methode van de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse aanroepen om de verborgen dia’s als pagina’s in de resulterende PDF op te nemen.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia’s.

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

Het volgende voorbeeld exporteert een presentatie naar een PDF die geopend moet worden met het wachtwoord `password`. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

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

### **Lettertype‑substitutie detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse, waarmee u lettertype‑substitutie kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en geeft waarschuwingen over lettertype‑substitutie weer op de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet‑beschikbaar lettertype wordt vervangen tijdens de export.

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

{{% alert color="info" title="Opmerking" %}}

Voor meer informatie over lettertype‑substitutie, zie het artikel [Font Substitution](/slides/nl/php-java/font-substitution/).

{{% /alert %}} 

### **Omgaan met lettertypen zonder een eigen vet‑type**

Een presentatie kan vet­opmaak toepassen op tekst zelfs wanneer het gebruikte lettertype geen eigen vet‑type heeft. De tekst kan nog steeds vet verschijnen via synthetische vetting, die de gewone glyphs kunstmatig verdikt. Wanneer die tekst te zwaar of anderszinnig lijkt in de PDF, probeer dan [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) aan te roepen met `true`. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF‑export en kan de weergave voor bepaalde lettertypen verbeteren. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet­opmaak toegepast op hetzelfde lettertype, dat geen eigen vet‑type heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

De volgende voorbeelden tonen de uitvoer met de optie uitgeschakeld en met de optie ingeschakeld. In dit voorbeeld heeft de vetgedrukte tekst dikkere lijnen wanneer de optie uitgeschakeld is. Met de optie ingeschakeld zijn de lijnen lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld zet het inschakelen van de optie alleen de vetgedrukte tekst om in een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen verschijnen zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen eigen vet‑type heeft. [Font substitution](/slides/nl/php-java/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Selectieve dia’s van PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dia‑nummers in dit array beginnen bij één, en de invoer‑presentatie moet minstens drie dia’s bevatten.

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

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud om te passen en exporteert de enkele dia naar PDF.

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

    // Verwijder de lege dia die bij het maken van de nieuwe presentatie is aangemaakt.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint naar PDF in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke dia onder de dia worden geplaatst. Gebruik een presentatie met aantekeningen om het resultaat te zien.

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

## **Toegankelijkheid en nalevingsstandaarden voor PDF**

Aspose.Slides maakt het mogelijk een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF’s genereert op basis van verschillende nalevingsstandaarden:

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

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt converteren naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — worden eveneens ondersteund.

{{% /alert %}}

> **Let op:** Wanneer u exporteert naar PDF/UA, behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als aparte inhoud en kunnen als artefacten gemarkeerd worden; alternatieve tekst wordt alleen voor de gehele figuur geleverd.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia’s op in de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse om verborgen dia’s in de resulterende PDF op te nemen.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit beheersen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) en [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse om hoogwaardige afbeeldingen in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides maakt het mogelijk PDF‑bestanden te exporteren die voldoen aan [verschillende standaarden](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for PHP via Java Documentation](/slides/nl/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)