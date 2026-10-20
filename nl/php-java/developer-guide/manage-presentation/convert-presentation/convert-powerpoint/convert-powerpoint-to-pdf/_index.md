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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF‑bestanden in PHP met Aspose.Slides, inclusief snelle codevoorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) converteren naar PDF‑formaat in PHP biedt diverse voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de afbeeldingskwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden beveiligt met een wachtwoord, font‑vervangingen detecteert, specifieke dia’s selecteert voor conversie en nalevingsnormen toepast op de uitgangsdocumenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met de [opslaan](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑methode. De [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑klasse biedt de [opslaan](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑methode die gewoonlijk wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides for PHP via Java voegt zijn API‑informatie en versienummer toe aan de gegenereerde documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld **Application** met "*Aspose.Slides*" en het veld **PDF Producer** met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie te wijzigen of te verwijderen uit de gegenereerde documenten.

{{% /alert %}}

Aspose.Slides stelt u in staat om:

* Volledige presentaties naar PDF te converteren
* Specifieke dia’s uit een presentatie naar PDF te converteren

Aspose.Slides exporteert presentaties naar PDF, waarbij de resulterende PDF‑bestanden nauw overeenkomen met de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig weergegeven in de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardinstellingen. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op de hoogste kwaliteitsniveaus.

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

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse — waarmee u het resulterende PDF‑bestand kunt aanpassen, het PDF‑bestand met een wachtwoord kunt beveiligen of kunt specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeurskwaliteit voor raster‑afbeeldingen definiëren, bepalen hoe metafiles moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren en meer.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, afbeeldingresolutie ingesteld op 300 DPI, metafiles opgeslagen als PNG en Flate‑tekstcompressie.

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

### **Automatisch afbeeldingscompressie selecteren**

Wanneer een presentatie veel foto’s of schermafbeeldingen bevat, kan het verkleinen van de grootte van de geëxporteerde PDF het e‑mailen of downloaden vergemakkelijken. Roep [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) aan met `true` om automatisch het meest geschikte compressie‑algoritme voor elke afbeelding te selecteren tijdens de PDF‑export.

Het volgende voorbeeld laadt een bestaande presentatie, schakelt automatische afbeeldingscompressie in en slaat deze op als PDF‑document. Alle andere PDF‑exportinstellingen behouden hun standaardwaarden.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Deze optie selecteert een compressie‑algoritme voor elke afbeelding. Het verlagen van de waarde die wordt doorgegeven aan [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) vermindert in plaats daarvan de JPEG‑beeldkwaliteit, terwijl het verlagen van de waarde die wordt doorgegeven aan [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) toelaat dat afbeeldingen worden teruggesampled naar een lagere resolutie, wat details kan verminderen. Het inschakelen van automatische compressie‑selectie verlaagt op zich geen van beide instellingen.

Het selecteren van compressie‑algoritmen vereist extra verwerkingstijd en geheugen. De grootte‑reductie hangt af van de afbeeldingen in de presentatie en de exportinstellingen; een vaste reductie is niet gegarandeerd voor elke presentatie.

### **Ingebedde OLE‑bestanden behouden als PDF‑bijlagen**

Bevat een presentatie een ingebed Excel‑werkblad, wilt u wellicht dat PDF‑ontvangers zowel de gegevens van het werkblad als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) aan met `true` om ingebedde OLE‑bestanden te behouden als bijlagen in het resulterende PDF‑bestand.

De standaardwaarde is `false`: de preview‑afbeelding of het pictogram van het OLE‑object wordt weergegeven op de PDF‑pagina, maar het ingebedde bestand wordt niet opgenomen als bijlage. Als u de optie op `true` zet, wordt het bestand tevens als bijlage toegevoegd. De preview blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingebedde bestand afzonderlijk te openen of op te slaan. Het OLE‑object wordt niet een interactieve Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingebed Excel‑werkblad bevat en exporteert deze naar PDF met het werkblad als bijlage.

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
2. Open het **Attachments**‑paneel van de viewer en zoek het ingebedde werkblad.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct indien de viewer dat toelaat. De preview op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Opmerking" %}}

De PDF/A‑normen leggen beperkingen op aan bijlagen: PDF/A‑1 verbiedt ingebedde bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen, inclusief Excel‑werkbladen, toe. Dit zijn eisen van de normen, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en demonstreert geen PDF/A‑export.

{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Bevat een presentatie verborgen dia’s, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/)‑methode van de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF‑bestand op te nemen.

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

### **PowerPoint naar een wachtwoord‑beveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die alleen kan worden geopend met het wachtwoord `password`. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

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

### **Font‑vervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse, waarmee u font‑vervangingen tijdens het presentatie‑naar‑PDF‑conversieproces kunt detecteren.

Het volgende voorbeeld exporteert een presentatie naar PDF en geeft waarschuwingen voor font‑vervangingen weer in de console. Een waarschuwing wordt alleen uitgegeven wanneer een niet‑beschikbaar font wordt vervangen tijdens de export.

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

Voor meer informatie over font‑vervanging, zie het artikel [Lettertypevervanging](/slides/nl/php-java/font-substitution/).

{{% /alert %}} 

### **Omgaan met lettertypen zonder eigen vetstijl**

Een presentatie kan vet opmaak toepassen op tekst, zelfs wanneer het gebruikte lettertype geen eigen vetstijl heeft. De tekst kan nog steeds vet lijken via synthetisch vet, waarbij de reguliere glyphs kunstmatig worden verdikt. Wanneer die tekst te zwaar of anders uitziet dan bedoeld in de PDF, kunt u [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) aanroepen met `true`. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF‑export en kan de weergave voor bepaalde lettertypen verbeteren. Standaard is de waarde `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet op hetzelfde lettertype, dat geen eigen vetstijl heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in en exporteert deze naar PDF:

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

De volgende voorbeelden tonen de output met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst zwaardere streken wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de streken lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld maakt het inschakelen van de optie alleen van de vette tekst een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die als vet is opgemaakt wanneer het lettertype geen eigen vetstijl heeft. [Lettertypevervanging](/slides/nl/php-java/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Geselecteerde dia’s uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dia‑nummers in deze array beginnen bij één, en de invoerpresentatie moet minstens drie dia’s bevatten.

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

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

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

## **Toegankelijkheid‑ en nalevingsnormen voor PDF**

Aspose.Slides maakt het mogelijk een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document naar PDF exporteren met een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende nalevingsnormen:

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

Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden naar populaire bestandsformaten kunt converteren. U kunt [PDF naar HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) en [PDF naar XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij export naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele afbeelding. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de volledige afbeelding verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF‑bestand met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe voeg ik verborgen dia’s toe aan de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse om verborgen dia’s op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit behouden in de PDF?**

Ja, u kunt de beeldkwaliteit beheersen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) en [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klasse om afbeeldingen van hoge kwaliteit in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF‑bestanden te exporteren die voldoen aan [diverse standaarden](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), inclusief PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for PHP via Java Documentatie](/slides/nl/php-java/)
- [Aspose.Slides for PHP via Java API‑referentie](https://reference.aspose.com/slides/php-java/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/conversion)