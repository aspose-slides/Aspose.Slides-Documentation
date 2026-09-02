---
title: Low-Code-presentationer i Java
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
description: "Använd Aspose.Slides low-code API i Java för att konvertera och slå ihop presentationer, iterera genom innehåll, samla former och reducera presentationsstorlek."
---
## **Översikt**

Paketet [com.aspose.slides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/) innehåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälpare omsluter ofta använda objekt‑modellarbetsflöden i fokuserade metoder, så att du kan konvertera eller slå ihop filer, bearbeta presentationselement, samla former och ta bort oanvänt innehåll med mindre kod.

Lågkods‑hjälpare är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd den fullständiga [Aspose.Slides‑objektmodellen](https://reference.aspose.com/slides/sv/java/com.aspose.slides/) när du behöver fin‑maskig kontroll över enskilda bildspel, master‑bilder, layouter, former, exportinställningar eller relationer mellan presentations‑element.

Tabellen nedan sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/java/com.aspose.slides/merger/) | Kombinera hela presentationsfiler i samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/) | Utföra en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/collect/) | Hämta former från hela presentationen för återkommande bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/) | Ta bort oanvända master‑ och layout‑bilder samt minska inbäddade teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert.autoByExtension](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) när filändelsen på utdata räcker för att välja exportformat. Metoden öppnar källpresentationen, bestämmer det nödvändiga formatet från sökvägen och skriver resultatet.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/) erbjuder också dedikerade metoder för PDF, SVG, JPEG, PNG och TIFF. Använd hela objektmodellen när du behöver inspektera eller ändra presentationen före export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/slides/sv/java/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå ihop presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) för att kombinera hela presentationsfiler med ett anrop. Inmatnings‑presentationerna måste ha samma filformat.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska bifogas till ett resultat utan att de behövs väljas eller omkartläggas individuellt. Använd hela objektmodellen när du behöver slå ihop utvalda bilder, tillämpa en mål‑master eller layout, bevara sektioner uttryckligt eller hantera olika bildstorlekar. Se [Merge Presentations](/slides/sv/java/merge-presentation/) för sådana scenarier.

## **Iterera genom presentations‑element**

Klassen [ForEach](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/) anropar en callback för varje begärd typ av presentations‑element. Den undviker nästlade samlingsloopar och är bekväm för inspektion eller formatändringar på hela presentationen.

Följande exempel använder [ForEach.slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), och [ForEach.portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) för att inspektera motsvarande element:

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

Som standard omfattar traversering av former och text på hela presentationen normala, master‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan också bearbeta anteckningsbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före callback‑anrop eller detaljerad föräldra‑barn‑kontroll är viktigt.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) när du behöver en samling av alla former i en presentation snarare än en callback för varje form. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas flera gånger.

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

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) istället när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/) kan ta bort oanvända strukturella element och minska inbäddade teckensnittsdata:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) tar bort layout‑bilder som ingen normal bild refererar.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) tar bort master‑bilder som inte längre används.
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

Ta bort oanvända layouter före oanvända master‑bilder så att en master som blir referenslös efter rensning av layouter också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga master‑bilderna, layouterna eller hela inbäddade teckensnittsdata senare. För mer detaljer, se [Slide Master](/slides/sv/java/slide-master/) och [Embedded Font](/slides/sv/java/embedded-font/).

## **FAQ**

**När bör jag använda lågkods‑API:t istället för den fulla objektmodellen?**

Använd lågkods‑hjälpare när en standardoperation gäller en hel fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd den fulla objektmodellen när du behöver välja specifika bilder, kontrollera relationer mellan master och layout, inspektera mellanliggande tillstånd eller konfigurera beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.process](https://reference.aspose.com/slides/sv/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) kräver att inmatnings‑presentationerna har samma format. Konvertera indatafilerna till ett gemensamt format först, till exempel med [Convert.autoByExtension](https://reference.aspose.com/slides/sv/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), och slå sedan ihop de konverterade filerna.

**Bearbetar ForEach master‑, layout‑ och anteckningsbilder?**

[ForEach.slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itererar genom normala presentationsbilder. På hela presentationen inkluderar [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), och [ForEach.portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) som standard både normala, master‑ och layout‑bilder. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera anteckningsbilder.

**Vad är skillnaden mellan ForEach.shape och Collect.shapes?**

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) för att bearbeta varje form omedelbart via en callback. Använd [Collect.shapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) när du behöver ett itererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master‑bilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/)-operationerna missa att minska filstorleken.

**Sparas ändringar gjorda av ForEach eller Compress automatiskt?**

Nej. Dessa hjälpare arbetar på det laddade [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)-objektet i minnet. Efter att du ändrat element i en [ForEach](https://reference.aspose.com/slides/sv/java/com.aspose.slides/foreach/)-callback eller kört [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/), anropa [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) för att skriva resultatet.

## **Relaterade artiklar**

- [Convert Presentation](/slides/sv/java/convert-presentation/)
- [Merge Presentations](/slides/sv/java/merge-presentation/)
- [Slide Master](/slides/sv/java/slide-master/)
- [Manage Text Box](/slides/sv/java/manage-textbox/)
- [Embedded Font](/slides/sv/java/embedded-font/)