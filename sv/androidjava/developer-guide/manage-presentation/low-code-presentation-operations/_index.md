---
title: Low-Code-presentationoperationer på Android
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/androidjava/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- slå ihop presentationer
- iterera bilder
- iterera former
- iterera text
- samla former
- komprimera presentation
- ta bort oanvända master-bilder
- ta bort oanvända layout-bilder
- komprimera inbäddade typsnitt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Använd Aspose.Slides low-code API på Android för att konvertera och slå ihop presentationer, iterera genom innehåll, samla former och minska presentationens storlek."
---
## **Översikt**

Paketet [com.aspose.slides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/) tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälpare omsluter ofta använda objektmodellarbetsflöden i fokuserade metoder, så att du kan konvertera eller slå ihop filer, bearbeta presentationselement, samla former och ta bort oanvänd innehåll med mindre kod.

Low-code-hjälpare är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet motsvarar dina krav. Använd hela [Aspose.Slides-objektmodellen](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/) när du behöver finstämma kontroll över enskilda bilder, master, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/) | Kör en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/collect/) | Hämta former från hela presentationen för återkommande bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/) | Ta bort oanvända master‑ och layout‑bilder samt minska inbäddad teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert.autoByExtension](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) när filändelsen för utdata är tillräcklig för att välja exportformat. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utsökvägen och skriver resultatet.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/convert/) tillhandahåller även dedikerade metoder för PDF-, SVG‑, JPEG‑, PNG‑ och TIFF‑utdata. Använd hela objektmodellen när du behöver inspektera eller modifiera presentationen innan export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/androidjava/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå ihop presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) för att kombinera kompletta presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller ommappa dem individuellt. Använd hela objektmodellen när du behöver slå ihop utvalda bilder, tillämpa ett mål‑master‑ eller layout‑objekt, bevara sektioner explicit, eller anpassa olika bildstorlekar. Se [Merge Presentations](/androidjava/merge-presentation/) för dessa scenarier.

## **Iterera genom presentations‑element**

Klassen [ForEach](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/) anropar en återuppringning för varje begärd typ av presentations‑element. Den undviker nästlade samlingsloopar och är bekväm för presentations‑omfattande inspektion eller formateringsändringar.

Följande exempel använder [ForEach.slide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), och [ForEach.portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) för att inspektera motsvarande element:

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

Som standard inkluderar presentations‑omfattande form‑ och text‑traversering normala, master‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan även bearbeta notes‑bilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före återuppringning eller detaljerad föräldra‑barn‑kontroll är viktig.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas mer än en gång.

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

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) istället när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/) kan ta bort oanvända strukturella element och minska inbäddad teckensnittsdata:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) tar bort layout‑bilder som ingen normal bild refererar till.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) tar bort master‑bilder som inte längre används.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) tar bort oanvända tecken från inbäddade teckensnitt.

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

Ta bort oanvända layouter innan oanvända master‑bilder så att en master som blir orefererad efter layout‑rensning också kan tas bort. Spara den optimerade presentationen i en ny fil om du kan behöva de ursprungliga master‑bilderna, layouterna eller fullständig inbäddad teckensnittsdata senare. För mer detaljer, se [Slide Master](/androidjava/slide-master/) och [Embedded Font](/androidjava/embedded-font/).

## **Vanliga frågor**

**När bör jag använda low-code‑API:t istället för hela objektmodellen?**

Använd low-code‑hjälpare när en standardoperation gäller en komplett fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd hela objektmodellen när du behöver välja specifika bilder, kontrollera master‑ och layout‑relationer, inspektera mellanliggande tillstånd eller konfigurera beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.process](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) kräver att inmatningspresentationerna har samma format. Konvertera indatafilerna till ett gemensamt format först, till exempel med [Convert.autoByExtension](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), och slå sedan ihop de konverterade filerna.

**Bearbetar ForEach master‑, layout‑ och notes‑bilder?**

[ForEach.slide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itererar genom normala presentationsbilder. Presentations‑omfattande [ForEach.shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), och [ForEach.portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) inkluderar normala, master‑ och layout‑bilder som standard. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera notes‑bilder.

**Vad är skillnaden mellan ForEach.shape och Collect.shapes?**

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect.shapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) när du behöver ett itererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master‑bilder eller inbäddade teckensnitt med oanvända tecken. Om inga av dessa finns kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/)-operationerna eventuellt inte minska filstorleken.

**Sparas ändringar som görs av ForEach eller Compress automatiskt?**

Nej. Dessa hjälpare arbetar på det inlästa [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-objektet i minnet. Efter att ha ändrat element i ett [ForEach](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/foreach/)-callback eller kört [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/), anropa [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/androidjava/convert-presentation/)
- [Slå ihop presentationer](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Hantera textruta](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)