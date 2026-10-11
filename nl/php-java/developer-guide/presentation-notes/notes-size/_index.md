---
title: Notitiepagina's grootte en oriëntatie wijzigen in PHP
linktitle: Notitiepagina grootte
type: docs
weight: 10
url: /nl/php-java/notes-size/
keywords:
- grootte van notitiepagina
- oriëntatie van notities
- liggende notities
- staande notities
- grootte van handout
- PowerPoint
- presentatie
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lees en wijzig de afmetingen van de notitiepagina in Aspose.Slides for PHP via Java, wijzig de oriëntatie, controleer de opgeslagen afmetingen, en exporteer notities of handouts naar PDF en afbeeldingen."
---
## **Overzicht**

Gebruik [Presentation::getNotesSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getnotessize/) om de instellingen van de notitiepagina van de presentatie te benaderen. Het retourneert een [NotesSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notessize/)‑object waarvan de [setSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notessize/setsize/)‑methode de paginadimensies instelt. Hoewel het instellingen‑object zelf niet kan worden vervangen, kun je via deze methode nieuwe afmetingen toewijzen.

Breedte en hoogte worden opgegeven in **punten**, met 72 punten per duim. Bijvoorbeeld, 900 × 600 punten is 12,5 × 8⅓ duim. Deze instellingen gelden voor de presentatie, niet voor de notities van een enkele dia.

| Instelling | Doel |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getnotessize/) | Bepaalt de afmetingen van de notitiepagina en de paginagrootte die wordt gebruikt bij handout‑export. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getslidesize/) | Bepaalt de afmetingen van de gewone presentatiedia's via [SlideSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/). |

Het wijzigen van één instelling verandert de andere niet automatisch. Het aanpassen van de oriëntatie van de notitiepagina draait de gewone dia's ook niet. Zie [Slide Size](/slides/nl/php-java/slide-size/) om de reguliere dia's van grootte te veranderen.

De voorbeelden hieronder gebruiken een bestaande `sample.pptx`. Voor de exportvoorbeelden gebruik je een presentatie met ten minste één dia die spreektekst‑notities bevat. Elk voorbeeld kan onafhankelijk worden uitgevoerd na het laden van de PHP/Java Bridge en de Aspose.Slides PHP‑wrapper. Numerieke waarden die door Java worden geretourneerd, worden geconverteerd naar PHP‑waarden met `java_values` vóór vergelijking of berekening.

## **Lees de grootte en oriëntatie van de notitiepagina**

Lees de breedte en hoogte en vergelijk ze om de oriëntatie te bepalen: een bredere pagina is liggend, een hogere pagina is staand, en gelijke afmetingen beschrijven een vierkante pagina. Dit voorbeeld print de werkelijke afmetingen in punten, zonder uit te gaan van een standaard papierformaat.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Omschakelen naar liggend zonder de papiergrootte te wijzigen**

Om alleen de oriëntatie te veranderen, verwissel je de bestaande breedte en hoogte. Dit behoudt de lengtes van beide zijden, inclusief die van een aangepast papierformaat. De onderstaande voorwaarde voorkomt dat een reeds liggende pagina weer naar staand wordt omgeschakeld en laat een vierkante pagina ongemoeid.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Voor staande oriëntatie gebruik je dezelfde toewijzing wanneer `java_values($size->getWidth()) > java_values($size->getHeight())`. Vervang A4‑ of Letter‑afmetingen niet, tenzij je ook de papiergrootte wilt wijzigen.

## **Stel een aangepaste notitiepagina‑grootte in en controleer deze**

Wijs beide afmetingen tegelijk toe en gebruik vervolgens [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/save/) om de presentatie weg te schrijven. Dit voorbeeld stelt een liggende pagina van 900 × 600 punten in, slaat deze op als PPTX en opent het opgeslagen bestand opnieuw om de permanente waarden te controleren. De vergelijking staat een toleranties van 0,01 punt toe voor zwevend‑kommagetallen; dit is geen garantie voor precisie bij elk bestandsformaat.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Het verwachte resultaat is `900 x 600 points` en `Size preserved: true`. Het openen van een nieuw geladen presentatie controleert het opgeslagen bestand, niet alleen de instellingen in het geheugen.

## **Exporteren van notities en handouts**

De paginadimensies bepalen het beschikbare gebied voor notities‑ of handout‑lay‑outs. Ze activeren die lay‑outs niet automatisch: configureer ook de exportopties. Export van gewone dia's blijft de dia‑afmetingen gebruiken.

### **Exporteren van notities naar PDF en PNG**

Wijs [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/) toe aan [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) om notities in de PDF op te nemen. Dit voorbeeld rendert ook de eerste dia met notities naar PNG met behulp van [Slide::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) en [RenderingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/).

De [BottomTruncated](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notespositions/)‑modus houdt de notities op één pagina; notities die niet passen, kunnen worden afgekapt. De PDF gebruikt pagina’s van 900 × 600 punten. Bij de gebruikte afbeelding‑schaal van 1 × 1 is de PNG 900 × 600 pixels. Punten beschrijven de paginageometrie; pixels beschrijven de rasteruitvoer, waarvan de afmetingen ook afhangen van de render‑schaal.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Voor PDF‑export met lange notities maakt [BottomFull](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notespositions/) extra pagina’s mogelijk. Gebruik die modus niet bij de enkele‑dia‑afbeeldingsaanroep hierboven, die dat niet ondersteunt. Na het wijzigen van de paginagrootte controleer je de uitvoer op afgekorte notities en de plaatsing van bestaande notes‑master‑objecten; alleen de paginagrootte wijzigen biedt geen garantie dat alle inhoud past. Zie [Convert PowerPoint to PDF with Notes](/slides/nl/php-java/convert-powerpoint-to-pdf-with-notes/) voor meer informatie over notitie‑export.

### **Exporteren van handouts naar PDF**

Gebruik [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/handoutlayoutingoptions/) voor meerdere dia‑miniaturen op één pagina. Het volgende voorbeeld stelt een pagina van 900 × 600 punten in en gebruikt [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/nl/php-java/aspose.slides/handouttype/) om tot vier dia’s per pagina te rangschikken. De horizontale preset bepaalt de volgorde van de dia’s; de pagina‑oriëntatie komt voort uit de breedte en hoogte.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Het wijzigen van de paginagrootte verandert het beschikbare gebied voor het handout‑rooster zonder de afmetingen van de bron‑dia’s te wijzigen. Voor handout‑afbeeldingen gebruik je [Presentation::getImages](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getimages/) met de handout‑lay‑out, in plaats van de afbeelding‑methode van een enkele dia. In Aspose.Slides gebruikt rendering op presentatieniveau de notitiepagina‑afmetingen, terwijl de afbeelding‑aanroep van een individuele dia geen handout‑pagina genereert. Zie [Handout Mode](/slides/nl/php-java/convert-powerpoint-in-handout-mode/) voor lay‑outopties.

## **Paginagrootte in viewers, export en afdrukken**

Houd de opgeslagen presentatiegrootte, de geëxporteerde paginagrootte en de afgedrukte papiergrootte gescheiden:

- **Presentatieviewers:** Een viewer kan notities weergeven of afdrukken met zijn eigen lay‑outrichtlijnen. Als een andere applicatie het bestand opslaat, open het dan opnieuw en controleer de afmetingen; die applicatie kan bij conversie de waarden normaliseren.
- **Exportformaten:** De notities‑ en handout‑PDF‑voorbeelden hierboven gebruiken de geconfigureerde paginagrootte. Rasterafbeeldingen gebruiken gehele pixelafmetingen en een render‑schaal, zodat fractionele puntwaarden kunnen worden afgerond in de afbeelding. Export van reguliere dia's past de notitiepagina‑grootte niet toe.
- **Printerstuurprogramma's:** Papiervoordeling, automatische rotatie en fit‑to‑page‑instellingen kunnen de fysieke uitvoer wijzigen zonder de in de presentatie of PDF opgeslagen afmetingen te veranderen. Voor een specifiek papierformaat moet je de printerinstellingen afstemmen en de afdrukvoorbeeld controleren.

## **FAQ**

**Kan ik de notitiepagina‑grootte voor slechts één dia instellen?**

De notitiepagina‑grootte is een instelling op presentatieniveau. Individuele dia’s kunnen verschillende notitie‑inhoud hebben, maar deze eigenschap biedt geen aparte paginagrootte per dia.

**Waarom heeft het wijzigen van de notitie‑oriëntatie mijn dia's niet beïnvloed?**

Notitiepagina’s en gewone dia’s hebben onafhankelijke afmetingen. Gebruik de instellingen voor de reguliere dia‑grootte wanneer je de dia’s zelf wilt aanpassen.

**Waarom heeft mijn opgeslagen of afgedrukte resultaat een andere grootte?**

Open eerst de opgeslagen presentatie opnieuw en vergelijk de notitie‑afmetingen. Als die zijn veranderd, controleer dan of het opslaan of converteren van het bestand in een andere applicatie de paginainstellingen heeft gewijzigd. Als dat niet het geval is, controleer dan de export‑lay‑out, afbeeldingschaal, viewer‑instellingen en de papierselectie van de printer.