---
title: Konvertera PPT och PPTX till PDF i Java [Avancerade funktioner inkluderade]
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/java/convert-powerpoint-to-pdf/
keywords:
- konvertera PowerPoint
- konvertera presentation
- PowerPoint till PDF
- presentation till PDF
- PPT till PDF
- konvertera PPT till PDF
- PPTX till PDF
- konvertera PPTX till PDF
- spara PowerPoint som PDF
- spara PPT som PDF
- spara PPTX som PDF
- exportera PPT till PDF
- exportera PPTX till PDF
- bilaga
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i Java med Aspose.Slides, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint-presentationer (PPT, PPTX, ODP etc.) till PDF-format i Java erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layouten och formateringen av din presentation. Denna guide visar hur man konverterar presentationer till PDF-dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF-filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på de genererade dokumenten.

## **PowerPoint till PDF-konverteringar**

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)-klassen och spara sedan presentationen som en PDF med hjälp av [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)-metoden. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)-klassen exponerar [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)-metoden som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides för Java infogar sin API‑information och versionsnummer i utdata‑dokument. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i Application‑fältet med "*Aspose.Slides*" och PDF‑Producer‑fältet med ett värde i formen "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdata‑dokument.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑erna överensstämmer nära med de ursprungliga presentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides att konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitet.

Följande exempel laddar en presentation och sparar alla synliga bilder till PDF med standardexportinställningarna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose erbjuder en gratis online [**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna konverterare för en live‑implementation av proceduren som beskrivs här.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ – egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) – som låter dig anpassa den resulterande PDF‑en, låsa PDF‑en med ett lösenord, eller ange hur konverteringsprocessen ska fortlöpa.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du ange din föredragna kvalitetsinställning för rasterbilder, specificera hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Följande exempel exporterar en presentation till PDF 1.5 med JPEG‑kvalitet satt till 90, bildupplösning satt till 300 DPI, metafiler sparade som PNG och Flate‑textkomprimering.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Välj automatiskt bildkomprimering**

När en presentation innehåller många fotografier eller skärmdumpar kan minskning av den exporterade PDF‑ens storlek göra det enklare att e‑posta eller ladda ner. Anropa [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) med `true` för att automatiskt välja den mest lämpliga komprimeringsalgoritmen för varje bild under PDF‑exporten.

Följande exempel laddar en befintlig presentation, aktiverar automatiskt val av bildkomprimering och sparar den som ett PDF‑dokument. Alla andra PDF‑exportinställningar behåller sina standardvärden.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Detta alternativ väljer en komprimeringsalgoritm för varje bild. Att sänka värdet som skickas till [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) minskar JPEG‑bildkvaliteten, medan en sänkning av värdet som skickas till [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) tillåter att bilder nedskalades till en lägre upplösning, vilket kan minska detaljer. Aktivering av automatiskt komprimeringsval sänker i sig inte någon av dessa inställningar.

Val av bildkomprimeringsalgoritmer kräver extra bearbetningstid och minne. Storleksreduktionen beror på presentationens bilder och exportinställningar; en fast reducering garanteras inte för varje presentation.

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagare också får åtkomst till arbetsbokens data samt kan se bilderna. Anropa [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) med `true` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑en.

Standardvärdet är `false`: OLE‑objektets förhandsgranskningsbild eller ikon återges på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. Att sätta alternativet till `true` inkluderar dessutom filens data. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagare öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑blad på PDF‑sidan.

Följande exempel laddar en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken bifogad.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

För att kontrollera resultatet:

1. Öppna den exporterade PDF‑en i en visare som stöder filbilagor, till exempel Adobe Acrobat Reader.
2. Öppna visarens **Bilagor**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Note" %}}
PDF/A‑standarderna inför restriktioner för bilagor: PDF/A‑1 förbjuder inbäddade filer, PDF/A‑2 tillåter endast PDF/A‑bilagor, och PDF/A‑3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav från standarderna, inte restriktioner specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och visar inte PDF/A‑export.
{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) från klassen [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑en.

Följande exempel exporterar en presentation till PDF, inklusive eventuella dolda bilder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konvertera PowerPoint till ett lösenordsskyddat PDF**

Följande exempel exporterar en presentation till ett PDF som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive utskrift i hög kvalitet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Upptäcka teckensnittsersättningar**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) under klassen [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), vilket gör att du kan upptäcka teckensnittsersättningar under konverteringsprocessen från presentation till PDF.

Följande exempel exporterar en presentation till PDF och skriver ut varningar om teckensnittsersättningar till konsolen. En varning skrivs endast ut när ett otillgängligt teckensnitt ersätts under exporten.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
För mer information om teckensnittsersättning, se artikeln [Teckensnittsersättning](/slides/sv/java/font-substitution/).
{{% /alert %}}

### **Hantera teckensnitt utan en dedikerad fet stil**

En presentation kan tillämpa fet formatering på text även när teckensnittet saknar en dedikerad fet stil. Texten kan fortfarande visas fet genom syntetisk fetstil, som artificiellt förtjockar de vanliga tecknen. När den texten ser för tung ut eller på annat sätt avviker från den avsedda utformningen i PDF, försök att anropa [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) med `true`. Detta alternativ renderar den berörda texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa teckensnitt. Standardvärdet är `false`.

Exempelpresentationen innehåller två textrutor: en med vanlig text och en med fet formatering applicerad på samma teckensnitt, som saknar en dedikerad fet stil. Följande exempel laddar presentationen, aktiverar rasterisering av icke‑stödda teckensnittsstilar och exporterar den till PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Följande förhandsgranskningar visar den inaktiverade och den aktiverade utdata. I detta exempel har den feta texten tjockare linjer när alternativet är inaktiverat. När alternativet är aktiverat är linjerna lättare; den vanliga texten förblir oförändrad. Jämför resultaten innan du väljer inställningen för din presentation.

| Alternativ inaktiverat (`false`, standard) | Alternativ aktiverat (`true`) |
|---|---|
| ![PDF med rasterisering av ej‑stödd teckensnittsstil inaktiverad](unsupported-bold-disabled.png) | ![PDF med rasterisering av ej‑stödd teckensnittsstil aktiverad](unsupported-bold-enabled.png) |

I detta exempel omvandlar aktivering av alternativet endast den feta texten till en bitmap: den kan inte väljas, kopieras eller sökas som text utan OCR, och dess kanter ser mjukare ut vid 800 % zoom. Den vanliga texten förblir sökbar. När alternativet är inaktiverat förblir båda strängarna text.

Detta alternativ rasteriserar text som är formaterad som fet när dess teckensnitt saknar en dedikerad fet stil. [Teckensnittsersättning](/slides/sv/java/font-substitution/) väljer istället ett annat teckensnitt när det ursprungliga inte är tillgängligt.

## **Konvertera valda bilder från PowerPoint till PDF**

Följande exempel exporterar bilderna 1 och 3 från en presentation till PDF. Bildnumren i denna array är 1‑baserade, och inmatningspresentationen måste innehålla minst tre bilder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Följande exempel kopierar den första bilden från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Den skalar bildens innehåll för att passa och exporterar den enda bilden till PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Ta bort den tomma bilden som den nya presentationen skapades med.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF i anteckningsvyn**

Följande exempel exporterar en presentation till PDF och placerar varje bilds talarnoter under bilden. Använd en presentation som innehåller talarnoter för att se resultatet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tillgänglighets- och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Den här koden demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑er baserat på olika efterlevnadsstandarder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides stöder PDF‑konverteringsoperationer, vilket gör att du kan konvertera PDF‑filer till populära filformat. Du kan utföra [PDF till HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), och [PDF till PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—stöds också.
{{% /alert %}}

**Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda banor bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**  
Ja, Aspose.Slides stöder batchkonvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och tillämpa konverteringsprocessen programmässigt.

**Är det möjligt att lösenordsskydda det konverterade PDF‑et?**  
Ja. Använd klassen [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑en?**  
Anropa [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) med `true` i klassen [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) för att inkludera dolda bilder i den resulterande PDF‑en.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑en?**  
Ja, du kan kontrollera bildkvaliteten genom att använda metoder som [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) och [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) i klassen [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**  
Ja, Aspose.Slides låter dig exportera PDF‑er som följer [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets‑ och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides för Java dokumentation](/slides/sv/java/)
- [Aspose.Slides för Java API‑referens](https://reference.aspose.com/slides/java/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/conversion)