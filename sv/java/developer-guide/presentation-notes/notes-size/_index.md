---
title: Ändra anteckningssidans storlek och orientering i Java
linktitle: Anteckningssidans storlek
type: docs
weight: 10
url: /sv/java/notes-size/
keywords:
- anteckningssidans storlek
- anteckningsorientering
- liggande anteckningar
- stående anteckningar
- utdragsstorlek
- PowerPoint
- presentation
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Läs och ändra anteckningssidans dimensioner i Aspose.Slides för Java, växla orientering, verifiera sparade storlekar och exportera anteckningar eller utdrag till PDF och bilder."
---
## **Översikt**

Använd [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getNotesSize--) för att komma åt presentationens inställningar för anteckningssidan. Den returnerar ett [INotesSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/inotessize/)‑objekt vars [setSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-)‑metod sätter sidans dimensioner. Även om inställningsobjektet i sig inte kan ersättas kan du tilldela nya dimensioner via den metoden.

Bredd och höjd anges i **punkter**, med 72 punkter per tum. Till exempel är 900 × 600 punkter 12,5 × 8⅓ tum. Dessa inställningar gäller för hela presentationen, snarare än för en enskild bilds anteckningar.

| Inställning | Syfte |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getNotesSize--) | Kontrollerar anteckningssidans dimensioner och de siddimensioner som används för utdragsexport. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSlideSize--) | Kontrollerar vanliga presentationsbilders dimensioner via [ISlideSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra anteckningssidans orientering roterar inte heller vanliga bilder. Se [Slide Size](/slides/sv/java/slide-size/) för att ändra storlek på vanliga bilder.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst en bild som innehåller talaranteckningar. Varje exempel kan köras oberoende.

## **Läs anteckningssidans storlek och orientering**

Läs bredd och höjd och jämför dem för att avgöra orienteringen: en bredare sida är liggande, en högre sida är stående och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i punkter utan att anta en standardpappersstorlek.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Växla till liggande utan att ändra pappersstorleken**

För att bara ändra orienteringen, byt plats på den befintliga bredden och höjden. Detta bevarar längderna på båda sidor, även för en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida växlas tillbaka till stående och låter en kvadratisk sida förbli oförändrad.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För stående orientering, använd samma tilldelning när `size.getWidth() > size.getHeight()`. Ersätt inte A4‑ eller Letter‑dimensioner om du inte också vill ändra pappersstorleken.

## **Ställ in och verifiera en anpassad anteckningssidestorlek**

Tilldela båda dimensionerna samtidigt och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) för att skriva presentationen. Detta exempel sätter en 900 × 600‑punkts liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter en tolerans på 0,01 punkt för flyttalsvärden; den är ingen garanti för exakt precision för varje filformat.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Det förväntade resultatet är `900.0 x 600.0 points` och `Size preserved: true`. Att kontrollera en nyöppnad presentation verifierar den sparade filen snarare än endast de minnesbaserade inställningarna.

## **Exportera anteckningar och utdrag**

Sidans dimensioner definierar det tillgängliga området för antecknings‑ eller utdragslayouter. De aktiverar inte dessa layouter i sig; du måste också konfigurera exportalternativen. Export av vanliga bilder fortsätter att använda bildens dimensioner.

### **Exportera anteckningar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/) till [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) för att inkludera anteckningar i PDF‑filen. Detta exempel renderar också den första bilden med anteckningar till PNG med hjälp av [Slide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) och [RenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/renderingoptions/).

[BottomTruncated](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notespositions/)-läget behåller anteckningarna på en sida; anteckningar som inte får plats kan trunkeras. PDF‑filen använder 900 × 600‑punkts sidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Punkter beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

För PDF‑export med långa anteckningar tillåter [BottomFull](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notespositions/) ytterligare sidor efter behov. Använd inte det läget med den enkelsidiga bildanropet ovan, som inte stödjer det. Efter förändring av sidstorlek, kontrollera utdata för avklippta anteckningar och placeringen av befintliga notes‑master‑objekt; att bara ändra sidans dimensioner bör inte betraktas som en garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/java/convert-powerpoint-to-pdf-with-notes/) för mer om export av anteckningar.

### **Exportera utdrag till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handoutlayoutingoptions/) för flera bildminiatyrer på en sida. Följande exempel sätter en 900 × 600‑punkts sida och använder [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/sv/java/com.aspose.slides/handouttype/) för att ordna upp till fyra bilder per sida. Det horisontella förinställningen styr bildordningen; sidans orientering kommer från dess bredd och höjd.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Att ändra sidstorleken ändrar området som är tillgängligt för utdragsrutnätet utan att ändra källbildernas dimensioner. För utdragsbilder, använd [Presentation.getImages](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) med utdragslayouten, snarare än en enskild bilds bildmetod. I Aspose.Slides använder rendering på presentationsnivå anteckningssidans dimensioner, medan enskild bild‑image‑anrop inte genererar utdragsidan. Se [Handout Mode](/slides/sv/java/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Behåll den sparade presentationsstorleken, den exporterade sidstorleken och den utskrivna pappersstorleken separata:

- **Presentationsvisare:** En visare kan visa eller skriva ut anteckningar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna; det programmets formatkonvertering kan normalisera dem.
- **Exportformat:** Antecknings‑ och utdrags‑PDF‑exemplen ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltalspixeldimensioner och en renderingsskala, så bråkdelar av punkter kan avrundas i bildutdata. Export av vanliga bilder tillämpar inte anteckningssidans storlek.
- **Skrivardrivrutiner:** Pappersval, automatisk rotation och anpassa‑till‑sida‑inställningar kan förändra det fysiska resultatet utan att ändra dimensionerna som lagras i presentationen eller PDF‑filen. För en specifik pappersstorlek, matcha skrivarinställningarna och granska utskriftsförhandsgranskningen.

## **Vanliga frågor**

**Kan jag ange anteckningssidans storlek för bara en bild?**

Anteckningssidans storlek är en inställning på presentationsnivå. Enskilda bilder kan ha olika anteckningsinnehåll, men den här egenskapen ger ingen separat sidstorlek för varje bild.

**Varför ändrade inte förändring av anteckningarnas orientering mina bilder?**

Anteckningssidor och vanliga bilder har oberoende dimensioner. Använd inställningarna för vanlig bildstorlek när du vill ändra storleken på själva bilderna.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess anteckningsdimensioner. Om de har förändrats, kontrollera om sparandet eller konverteringen i ett annat program ändrade sidinställningarna. Om de inte har förändrats, granska exportlayouten, bildskalan, visarinställningarna och skrivarens pappersval.