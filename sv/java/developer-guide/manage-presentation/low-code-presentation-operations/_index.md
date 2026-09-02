---
title: Low-Code presentationsoperationer i Java
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/java/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- slå ihop presentationer
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
- Java
- Aspose.Slides
description: "Använd Aspose.Slides low-code API i Java för att konvertera och slå ihop presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

Paketet [com.aspose.slides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/) tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälparklasser omsluter ofta använda objektmodellsarbetsflöden i fokuserade metoder, så att du kan konvertera eller slå ihop filer, bearbeta presentationselement, samla former och ta bort oanvänt innehåll med mindre kod.

Low-code-hjälparprogram är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd den fullständiga [Aspose.Slides objektmodellen](https://reference.aspose.com/slides/sv/java/com.aspose.slides/) när du behöver finmaskig kontroll över enskilda bilder, master, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparprogrammen:

| Hjälparprogram | Använd för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil-till-fil-anrop. |
| [Merger](https://reference.aspose.com/slides/sv/java/com.aspose.slides/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/) | Köra en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/collect/) | Hämta former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/) | Ta bort oanvända master- och layout-bilder samt minska inbäddade teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert.autoByExtension](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) när filändelsen på utdata är tillräcklig för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utdatavägen och skriver resultatet.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/) erbjuder också dedikerade metoder för PDF, SVG, JPEG, PNG och TIFF-utmatning. Använd hela objektmodellen när du behöver granska eller modifiera presentationen innan export eller konfigurera ett exportalternativ som den valda hjälparprogrammet inte exponeras. Se [Convert Presentation](/java/convert-presentation/) för format-specifika arbetsflöden och alternativ.

## **Slå ihop presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) för att kombinera kompletta presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Hjälparprogrammet är lämpligt när alla bilder ska läggas till i ett resultat utan att välja eller ommappa dem individuellt. Använd hela objektmodellen när du behöver slå ihop utvalda bilder, tillämpa ett mål-master- eller layout-objekt, bevara sektioner explicit eller anpassa olika bildstorlekar. Se [Merge Presentations](/java/merge-presentation/) för dessa scenarier.

## **Iterera igenom presentationselement**

Klassen [ForEach](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/) anropar en återuppringning för varje begärt typ av presentationselement. Den undviker nästlade samlingsloopar och är bekväm för presentationsomfattande inspektion eller formateringsändringar.

Följande exempel använder [ForEach.slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), och [ForEach.portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) för att inspektera de motsvarande elementen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Som standard inkluderar presentationsomfattande form- och texttraversering normala, master- och layout-bilder. Överlagringar med en `includeNotes`-parameter kan även bearbeta notisbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avslutning, filtrering innan återuppringning eller detaljerad föräldra-barn-kontroll är viktig.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning kommer att filtreras, räknas eller bearbetas flera gånger.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) i stället när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/) kan ta bort oanvända strukturella element och minska inbäddade teckensnittsdata:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) tar bort layoutbilder som ingen normal bild refererar till.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) tar bort master-bilder som inte längre används.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) tar bort oanvända tecken från inbäddade teckensnitt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ta bort oanvända layouter innan oanvända master-bilder så att en master som blir orefererad efter layout-rengöring också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga master-bilderna, layouterna eller komplett inbäddad teckensnittsdata senare. För mer detaljer, se [Slide Master](/java/slide-master/) och [Embedded Font](/java/embedded-font/).

## **Vanliga frågor**

**När bör jag använda low-code‑API:t istället för hela objektmodellen?**

Använd low‑code‑hjälparprogram när en standardoperation gäller en hel fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd hela objektmodellen när du behöver välja specifika bilder, kontrollera master- och layout-relationer, inspektera mellanliggande tillstånd eller konfigurera beteende som hjälparprogrammet inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.process](https://reference.aspose.com/slides/sv/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) kräver att inmatningspresentationerna har samma format. Konvertera först indatafilerna till ett gemensamt format, till exempel med [Convert.autoByExtension](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), och slå sedan ihop de konverterade filerna.

**Bearbetar ForEach master-, layout- och notisbilder?**

[ForEach.slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itererar genom vanliga presentationsbilder. Presentationsomfattande [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), och [ForEach.portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) operationer inkluderar vanliga, master- och layout-bilder som standard. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera notisbilder.

**Vad är skillnaden mellan ForEach.shape och Collect.shapes?**

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) för att behandla varje form omedelbart via en återuppringning. Använd [Collect.shapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) när du behöver ett itererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master-bilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/) operationerna kanske inte minska filens storlek.

**Sparas ändringar gjorda av ForEach eller Compress automatiskt?**

Nej. Dessa hjälparprogram arbetar på det inlästa [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑objektet i minnet. Efter att ha ändrat element i en [ForEach](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/)‑återuppringning eller kört [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/), anropa [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/java/convert-presentation/)
- [Slå ihop presentationer](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Hantera textruta](/java/manage-textbox/)
- [Inbäddat teckensnitt](/java/embedded-font/)