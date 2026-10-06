---
title: Ändra notssidans storlek och orientering i PHP
linktitle: Notssidans storlek
type: docs
weight: 10
url: /sv/php-java/notes-size/
keywords:
- notssidans storlek
- notssidorientering
- liggande anteckningar
- stående anteckningar
- handout‑storlek
- PowerPoint
- presentation
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Läs och ändra notssidans dimensioner i Aspose.Slides för PHP via Java, byt orientering, verifiera sparade storlekar och exportera anteckningar eller handouts till PDF och bilder."
---
## **Översikt**

Använd [Presentation::getNotesSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getnotessize/) för att få åtkomst till presentationens inställningar för notssidan. Den returnerar ett [NotesSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notessize/)‑objekt vars [setSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notessize/setsize/)‑metod anger sidans dimensioner. Även om inställningsobjektet självt inte kan ersättas, kan du tilldela nya dimensioner via denna metod.

Bredd och höjd anges i **punkter**, med 72 punkter per tum. Till exempel motsvarar 900 × 600 punkter 12,5 × 8⅓ tum. Dessa inställningar gäller för presentationen, snarare än för en enskild slides anteckningar.

| Inställning | Syfte |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getnotessize/) | Styr dimensionerna för notssidan och sidmåtten som används vid handouts‑export. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getslidesize/) | Styr vanliga presentationsslides dimensioner via [SlideSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra notssidans orientering roterar inte de vanliga slides. Se [Slide Size](/slides/sv/php-java/slide-size/) för att ändra storlek på vanliga slides.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst en slide som innehåller presentatörsanteckningar. Varje exempel kan köras oberoende efter att PHP/Java‑bron och Aspose.Slides PHP‑omslaget har laddats. Numeriska värden som returneras av Java konverteras till PHP‑värden med `java_values` innan jämförelse eller beräkning.

## **Läs notssidans storlek och orientering**

Läs bredd och höjd och jämför dem för att avgöra orienteringen: en bredare sida är liggande, en högre sida är stående och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i punkter, utan att anta ett standardpappersformat.

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

## **Byt till liggande utan att ändra pappersstorleken**

För att bara ändra orienteringen, byt plats på den befintliga bredden och höjden. Detta bevarar längden på båda sidor, inklusive de för en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida byts tillbaka till stående och lämnar en kvadratisk sida oförändrad.

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

För stående orientering, använd samma tilldelning när `java_values($size->getWidth()) > java_values($size->getHeight())`. Byt inte ut A4- eller Letter-dimensioner om du inte också vill ändra pappersstorleken.

## **Ställ in och verifiera en anpassad notssidans storlek**

Tilldela båda dimensionerna tillsammans och använd sedan [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/save/) för att skriva presentationen. Detta exempel sätter en 900 × 600‑punkts liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter en tolerans på 0,01 punkt för flyttalsvärden; det är ingen garanti för precision för varje filformat.

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

Det förväntade resultatet är `900 x 600 points` och `Size preserved: true`. Att kontrollera en nyöppnad presentation verifierar den sparade filen, snarare än endast de minnesbaserade inställningarna.

## **Exportera anteckningar och handouts**

Sidans dimensioner definierar det tillgängliga området för anteckningar eller handout‑layouter. De aktiverar inte dessa layouter av sig själva: exportalternativen måste också konfigureras. Vanlig slide‑export fortsätter att använda slide‑dimensionerna.

### **Exportera anteckningar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/) till [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) för att inkludera anteckningar i PDF‑filen. Detta exempel renderar också den första sliden med anteckningar till PNG med [Slide::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) och [RenderingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/).

[BottomTruncated](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notespositions/)‑läget behåller anteckningarna på en sida; anteckningar som inte får plats kan trunkeras. PDF‑filen använder 900 × 600‑punktssidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Punkter beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

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

För PDF‑export med långa anteckningar tillåter [BottomFull](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notespositions/) extra sidor vid behov. Använd inte det läget med bildanropet för en enda slide ovan, eftersom det inte stödjer det. Efter storleksändring, granska utdata för avklippta anteckningar och placeringen av befintliga notes‑master‑objekt; att bara ändra sidans dimensioner bör inte betraktas som en garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/php-java/convert-powerpoint-to-pdf-with-notes/) för mer om anteckningsexport.

### **Exportera handouts till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/handoutlayoutingoptions/) för flera slide‑miniatyrer på en sida. Följande exempel sätter en 900 × 600‑punktssida och använder [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/sv/php-java/aspose.slides/handouttype/) för att ordna upp till fyra slides per sida. Det horisontella förinställningen styr slide‑ordningen; sidans orientering hämtas från dess bredd och höjd.

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

Att ändra sidans storlek förändrar området som är tillgängligt för handout‑rutnätet utan att förändra källslidarnas dimensioner. För handout‑bilder, använd [Presentation::getImages](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getimages/) med handout‑layouten, snarare än en enskild slides bildmetod. I Aspose.Slides använder rendering på presentationsnivå handout‑dimensionerna från notssidan, medan det enskilda slide‑bildanropet inte producerar handout‑sidan. Se [Handout Mode](/slides/sv/php-java/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Håll presentationens lagrade storlek, den exporterade sidstorleken och den utskrivna pappersstorleken separat:

- **Presentationvisare:** En visare kan visa eller skriva ut anteckningar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna på nytt; programmets formatkonvertering kan normalisera dem.
- **Exportformat:** Exempeln för antecknings‑ och handout‑PDF ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltalspixeldimensioner och en renderingsskala, så bråkdelar av punktvärden kan avrundas i bildutdata. Export av vanliga slides tillämpas inte på notssidans storlek.
- **Skrivardrivrutiner:** Pappersval, automatisk rotation och anpassning till sida kan förändra det fysiska utskriftsresultatet utan att ändra de dimensioner som lagras i presentationen eller PDF‑filen. För en specifik pappersstorlek, matcha skrivarinställningarna och granska utskriftsförhandsgranskningen.

## **FAQ**

**Kan jag ställa in notssidans storlek för endast en slide?**

Notssidans storlek är en inställning på presentationsnivå. Enskilda slides kan ha olika anteckningsinnehåll, men denna egenskap ger inte en separat sidstorlek för varje slide.

**Varför ändrade inte ändring av notssidans orientering mina slides?**

Notssidor och vanliga slides har oberoende dimensioner. Använd inställningarna för vanliga slides när du vill ändra storlek på själva slides.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess notsdimensioner. Om de har ändrats, kontrollera om sparande eller konvertering av filen i ett annat program ändrade sidinställningarna. Om de inte gjorde det, granska exportlayouten, bildskalan, visarens inställningar och skrivarens pappersval.