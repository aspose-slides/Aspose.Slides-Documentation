---
title: Low-Code presentationsoperationer i PHP
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/php-java/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- slå samman presentationer
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
description: "Använd Aspose.Slides low-code API i PHP för att konvertera och slå samman presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

Namnområdet [aspose.slides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/) tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälpare omsluter ofta använda objekt‑modellarbetsflöden i fokuserade metoder, så att du kan konvertera eller slå samman filer, bearbeta presentationselement, samla former och ta bort oanvänd innehåll med mindre kod.

Low-code-hjälpare är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd den fullständiga [Aspose.Slides object model](https://reference.aspose.com/slides/sv/php-java/aspose.slides/) när du behöver fin‑granulerad kontroll över enskilda bildspel, masterbilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd den för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/php-java/aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/php-java/aspose.slides/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [ForEach_](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/) | Kör en återanrop för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/collect/) | Hämtar former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) | Tar bort oanvända masterbilder och layouter samt minskar inbäddade teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert::autoByExtension](https://reference.aspose.com/slides/sv/php-java/aspose.slides/convert/#autoByExtension) när filändelsen för utdata är tillräcklig för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utdatans sökväg och skriver resultatet.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/sv/php-java/aspose.slides/convert/) tillhandahåller också dedikerade metoder för PDF-, SVG-, JPEG-, PNG- och TIFF‑utdata. Använd den fullständiga objektmodellen när du behöver inspektera eller ändra presentationen innan export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/slides/sv/php-java/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå samman presentationer**

Använd [Merger::process](https://reference.aspose.com/slides/sv/php-java/aspose.slides/merger/#process) för att kombinera kompletta presentationsfiler med ett anrop. Ingångspresentationerna måste ha samma filformat.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller omkartlägga dem individuellt. Använd den fullständiga objektmodellen när du behöver slå samman utvalda bilder, tillämpa en destinations‑master eller -layout, bevara sektioner explicit eller anpassa olika bildstorlekar. Se [Merge Presentations](/slides/sv/php-java/merge-presentation/) för sådana scenarier.

## **Iterera genom presentationselement**

Klassen [ForEach_](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/) anropar ett återanrop för varje begärd typ av presentations‑element. Den undviker nästlade samlingsloopar och är bekväm för presentationsomfattande inspektion eller formateringsändringar.

Följande exempel använder [ForEach_::slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#paragraph) och [ForEach_::portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#portion) för att inspektera de motsvarande elementen:

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

Som standard inkluderar presentationsomfattande form‑ och texttraversering normala, master‑ och layoutbilder. Överlagringar med en `includeNotes`‑parameter kan också bearbeta notisbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avslutning, filtrering före återanrop, eller detaljerad förälder‑barn‑kontroll är viktigt.

## **Samla former**

Använd [Collect::shapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/collect/#shapes) när du behöver en samling av alla former i en presentation snarare än ett återanrop för varje form. Detta är användbart när samma uppsättning kommer att filtreras, räknas eller bearbetas fler än en gång.

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

Använd [ForEach_::shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#shape) istället när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) kan ta bort oanvända strukturella element och minska inbäddade teckensnittsdata:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) tar bort layoutbilder som ingen normal bild refererar till.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedMasterSlides) tar bort masterbilder som inte längre används.
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

Ta bort oanvända layouter innan oanvända masterbilder så att en master som blir overrefererad efter layoutrensning också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga masterbilderna, layouterna eller komplett inbäddad teckensnittsinformation senare. För mer detaljer, se [Slide Master](/slides/sv/php-java/slide-master/) och [Embedded Font](/slides/sv/php-java/embedded-font/).

## **FAQ**

**När bör jag använda low-code‑API:t istället för den fullständiga objektmodellen?**

Använd low-code-hjälpare när en standardoperation gäller en hel fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd den fullständiga objektmodellen när du behöver välja specifika bilder, kontrollera master‑ och layoutrelationer, inspektera mellanliggande tillstånd eller konfigurera beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger::process](https://reference.aspose.com/slides/sv/php-java/aspose.slides/merger/#process) kräver att inmatningspresentationerna har samma format. Konvertera inmatningsfilerna till ett gemensamt format först, till exempel med [Convert::autoByExtension](https://reference.aspose.com/slides/sv/php-java/aspose.slides/convert/#autoByExtension), och slå sedan samman de konverterade filerna.

**Bearbetar ForEach_ master‑, layout‑ och notisbilder?**

[ForEach_::slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#slide) itererar genom normala presentationsbilder. Presentationsomfattande [ForEach_::shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#paragraph) och [ForEach_::portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#portion) operationer inkluderar normala, master‑ och layoutbilder som standard. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera notisbilder.

**Vad är skillnaden mellan ForEach_::shape och Collect::shapes?**

Använd [ForEach_::shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/#shape) för att bearbeta varje form omedelbart via ett återanrop. Använd [Collect::shapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/collect/#shapes) när du behöver ett itererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända masterbilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) operationerna eventuellt inte minska filens storlek.

**Sparas ändringar som görs av ForEach_ eller Compress automatiskt?**

Nej. Dessa hjälpare arbetar på det inlästa [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑objektet i minnet. Efter att ha ändrat element i ett [ForEach_](https://reference.aspose.com/slides/sv/php-java/aspose.slides/foreach_/)‑återanrop eller kört [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/), anropa [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/slides/sv/php-java/convert-presentation/)
- [Slå samman presentationer](/slides/sv/php-java/merge-presentation/)
- [Slide Master](/slides/sv/php-java/slide-master/)
- [Hantera textruta](/slides/sv/php-java/manage-textbox/)
- [Inbäddat teckensnitt](/slides/sv/php-java/embedded-font/)