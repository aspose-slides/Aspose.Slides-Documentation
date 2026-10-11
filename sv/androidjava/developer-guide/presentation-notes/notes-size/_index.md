---
title: Ändra notesidans storlek och orientering på Android
linktitle: Notesidans storlek
type: docs
weight: 10
url: /sv/androidjava/notes-size/
keywords:
- storlek på notesida
- orientering för notes
- liggande anteckningar
- stående anteckningar
- handout-storlek
- PowerPoint
- presentation
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Läs och ändra dimensions för notesidan i Aspose.Slides för Android via Java, byt orientering, verifiera sparade storlekar och exportera anteckningar eller handouts till PDF och bilder."
---
## **Översikt**

Använd [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getNotesSize--) för att komma åt presentationens inställningar för notesidan. Den returnerar ett [INotesSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/inotessize/)‑objekt vars [setSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-)‑metod anger sidans dimensioner. Även om inställningsobjektet själv inte kan ersättas kan du tilldela nya dimensioner via denna metod.

Bredd och höjd anges i **points**, med 72 points per tum. Till exempel är 900 × 600 points 12,5 × 8⅓ tum. Dessa inställningar gäller för hela presentationen, inte för en enskild slides notes.

| Inställning | Syfte |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Styr dimensions för notesidan och siddimensionerna som används för handout‑export. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Styr vanliga presentationsbilddimensioner via [ISlideSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra notesidans orientering roterar inte heller vanliga bilder. Se [Slide Size](/slides/sv/androidjava/slide-size/) för att ändra storlek på vanliga bilder.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst en slide som innehåller talarnoter. Varje exempel kan köras oberoende.

## **Läs notesidans storlek och orientering**

Läs bredd och höjd och jämför dem för att bestämma orienteringen: en bredare sida är liggande, en högre sida är stående och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i points, utan att anta en standard pappersstorlek.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

För att endast ändra orienteringen, byt plats på den befintliga bredden och höjden. Detta bevarar längden på båda sidor, inklusive en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida byts tillbaka till stående och lämnar en kvadratisk sida oförändrad.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För stående orientering, använd samma tilldelning när `size.getWidth() > size.getHeight()`. Byt inte ut A4‑ eller Letter‑dimensioner om du inte även vill ändra pappersstorleken.

## **Ställ in och verifiera en anpassad notesidestorlek**

Tilldela båda dimensionerna samtidigt och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) för att skriva presentationen. Detta exempel sätter en 900 × 600‑point liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter en tolerans på 0,01 point för flyttalsvärden; den är ingen garanti för precision i varje filformat.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Det förväntade resultatet är `900.0 x 600.0 points` och `Size preserved: true`. Att kontrollera en nyöppnad presentation verifierar den sparade filen, snarare än endast de minnesbaserade inställningarna.

## **Exportera anteckningar och handouts**

Sidimensionerna definierar det tillgängliga området för antecknings‑ eller handout‑layouter. De aktiverar inte dessa layouter i sig; konfigurera även exportalternativen. Export av vanliga slides fortsätter att använda slide‑dimensionerna.

### **Exportera anteckningar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notescommentslayoutingoptions/) till [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) för att inkludera anteckningar i PDF‑filen. Detta exempel renderar även den första sliden med anteckningar till PNG med [Slide.getImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) och [RenderingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/renderingoptions/).

[BottomTruncated](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notespositions/)‑läget behåller anteckningarna på en sida; anteckningar som inte får plats kan trunkeras. PDF‑filen använder 900 × 600‑point sidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Points beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

För PDF‑export med långa anteckningar, låter [BottomFull](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notespositions/) till extra sidor efter behov. Använd inte det läget med det enkelslides‑bildanropet ovan, som inte stöder det. Efter storleksändring, inspektera utdata för trunkerade anteckningar och placeringen av befintliga notes‑master‑objekt; att enbart ändra siddimensionerna är ingen garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/androidjava/convert-powerpoint-to-pdf-with-notes/) för mer om anteckningsexport.

### **Exportera handouts till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handoutlayoutingoptions/) för flera slide‑miniatyrer på en sida. Följande exempel sätter en 900 × 600‑point sida och använder [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/handouttype/) för att arrangera upp till fyra slides per sida. Det horisontella förinställningsvärdet styr slide‑ordningen; sidans orientering kommer från dess bredd och höjd.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Att ändra sidstorleken ändrar området som är tillgängligt för handout‑rutnätet utan att ändra källslide‑dimensionerna. För handout‑bilder, använd [Presentation.getImages](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) med handout‑layouten, snarare än en enskild slides bildmetod. I Aspose.Slides använder rendering på presentationsnivå handout‑dimensionerna för notes‑sidan, medan den enskilda slide‑bildmetoden inte producerar handout‑sidan. Se [Handout Mode](/slides/sv/androidjava/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Behåll den lagrade presentationsstorleken, den exporterade sidstorleken och den utskrivna pappersstorleken åtskilda:

- **Presentation viewers:** En visare kan visa eller skriva ut anteckningar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna på nytt; det programmets formatkonvertering kan normalisera dem.
- **Export formats:** Antecknings‑ och handout‑PDF‑exemplen ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltals‑pixeldimensioner och en renderingsskala, så bråkdelar av point‑värden kan avrundas i bildutdata. Export av vanliga slides tillämpas inte på notesidans storlek.
- **Printer drivers:** Pappersval, automatisk rotation och anpassa‑till‑sida‑inställningar kan förändra det fysiska resultatet utan att ändra dimensionerna som lagras i presentationen eller PDF‑filen. För en specifik pappersstorlek, matcha skrivarinställningarna och inspektera utskriftsförhandsvisningen.

## **FAQ**

**Kan jag ange notesstorleken för bara en slide?**

Notesidans storlek är en presentations‑nivåinställning. Enskilda slides kan ha olika anteckningsinnehåll, men den här egenskapen ger ingen separat sidstorlek per slide.

**Varför ändrade inte förändringen av notes‑orientering mina slides?**

Notesidor och vanliga slides har oberoende dimensioner. Använd inställningarna för vanlig slide‑storlek när du vill ändra storleken på själva slides.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess notes‑dimensioner. Om de har ändrats, kontrollera om sparandet eller konverteringen i ett annat program ändrade sidinställningarna. Om de inte har ändrats, granska exportlayouten, bildskalan, visarens inställningar och skrivarens pappersval.