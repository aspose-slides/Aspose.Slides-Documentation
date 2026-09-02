---
title: Low-Code-presentationer i PHP
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/php-java/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- sammanfoga presentationer
- iterera bilder
- iterera former
- iterera text
- samla former
- komprimera presentation
- ta bort oanvända masterbilder
- ta bort oanvända layoutbilder
- komprimera inbäddade teckensnitt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Använd Aspose.Slides low-code-API i PHP för att konvertera och sammanfoga presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

Namnområdet [aspose.slides] tillhandahåller statiska hjälparklasser för vanliga presentationer. Dessa hjälparklasser kapslar in ofta använda objekt‑modellarbetsflöden i fokuserade metoder, så att du kan konvertera eller sammanfoga filer, bearbeta presentationselement, samla former och ta bort oanvänd innehåll med mindre kod.

Low‑code‑hjälparna är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet uppfyller dina krav. Använd hela [Aspose.Slides‑objektmodell] när du behöver fin‑granulerad kontroll över enskilda bilder, master‑bilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Användning för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/php-java/aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/php-java/aspose.slides/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [ForEach_](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/) | Kör en återuppringning för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/collect/) | Hämtar former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) | Tar bort oanvända master‑bilder och layouter samt minskar inbäddad teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert::autoByExtension](https://reference.aspose.com/slides/sv/php-java/aspose.slides/convert/#autoByExtension) när filändelsen för utdata räcker för att välja exportformat. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utdatasökvägen och skriver resultatet.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert] erbjuder även dedikerade metoder för PDF-, SVG-, JPEG-, PNG- och TIFF‑utdata. Använd hela objektmodellen när du behöver inspektera eller ändra presentationen innan export eller konfigurera ett exportalternativ som den valda hjälparen inte exponerar. Se [Konvertera presentation](/php-java/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Sammanfoga presentationer**

Använd [Merger::process](https://reference.aspose.com/slides/sv/php-java/aspose.slides/merger/#process) för att kombinera kompletta presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller ommappa dem individuellt. Använd hela objektmodellen när du behöver sammanfoga utvalda bilder, tillämpa ett mål‑master‑ eller layout, behålla sektioner explicit eller hantera olika bildstorlekar. Se [Sammanfoga presentationer](/php-java/merge-presentation/) för dessa scenarier.

## **Iterera genom presentationselement**

Klassen [ForEach_] anropar en återuppringning för varje begärd typ av presentationselement. Den undviker nästlade samlingsloopar och är praktisk för presentation‑omfattande inspektion eller formateringsändringar.

Följande exempel använder [ForEach_::slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#paragraph) och [ForEach_::portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#portion) för att inspektera motsvarande element:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Som standard inkluderar presentation‑omfattande form‑ och texttraversering normala, master‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan också bearbeta notisbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före återuppringning eller detaljerad förälder‑barn‑kontroll är viktig.

## **Samla former**

Använd [Collect::shapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/collect/#shapes) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas flera gånger.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Använd istället [ForEach_::shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#shape) när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress] kan ta bort oanvända strukturella element och minska inbäddad teckensnittsdata:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) tar bort layout‑bilder som ingen normal bild refererar till.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedMasterSlides) tar bort master‑bilder som inte längre används.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#compressEmbeddedFonts) tar bort oanvända tecken från inbäddade teckensnitt.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ta bort oanvända layouter innan oanvända master‑bilder så att en master‑bild som blir orefererad efter rensning av layouter också kan tas bort. Spara den optimerade presentationen till en ny fil om du eventuellt behöver de ursprungliga master‑bilderna, layouterna eller komplett inbäddad teckensnittsdata senare. För mer detaljer, se [Slide Master](/php-java/slide-master/) och [Embedded Font](/php-java/embedded-font/).

## **FAQ**

**När bör jag använda low‑code‑API:t istället för hela objektmodellen?**

Använd low‑code‑hjälparna när en standardoperation gäller en komplett fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd hela objektmodellen när du behöver välja specifika bilder, styra master‑ och layout‑relationer, inspektera mellansteg eller konfigurera beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger::process] kräver att inmatningspresentationerna har samma format. Konvertera först indatafilerna till ett gemensamt format, till exempel med [Convert::autoByExtension], och sammanfoga sedan de konverterade filerna.

**Behandlar ForEach_ master‑, layout‑ och notisbilder?**

[ForEach_::slide] itererar genom vanliga presentationsbilder. Presentation‑omfattande [ForEach_::shape], [ForEach_::paragraph] och [ForEach_::portion]-operationer inkluderar normala, master‑ och layout‑bilder som standard. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera notisbilder.

**Vad är skillnaden mellan ForEach_::shape och Collect::shapes?**

Använd [ForEach_::shape] för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect::shapes] när du behöver ett itererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master‑bilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande [Compress]-operationerna kanske inte minska filens storlek.

**Sparas ändringar gjorda av ForEach_ eller Compress automatiskt?**

Nej. Dessa hjälparbeten arbetar på det inlästa [Presentation]-objektet i minnet. Efter att ha ändrat element i ett [ForEach_]-återuppringningskript eller kört [Compress], anropa [Presentation::save] för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/php-java/convert-presentation/)
- [Sammanfoga presentationer](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Hantera textruta](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)