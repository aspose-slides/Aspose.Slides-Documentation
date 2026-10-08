---
title: Konvertera PPT och PPTX till PDF på Android [Avancerade funktioner inkluderade]
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i Java med Aspose.Slides för Android, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format på Android erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarandet av layout och formatering i din presentation. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att styra bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittssubstitutioner, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdata‑dokumenten.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som argument till klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) och spara sedan presentationen som en PDF med metoden [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) exponerar metoden [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides för Android via Java infogar sin API‑information och versionsnummer i utdata‑dokumenten. Till exempel, vid konvertering av en presentation till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och fältet PDF Producer med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs!** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdata‑dokumenten.

{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna mycket nära matchar de ursprungliga presentationerna. Element och attribut renderas exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punktlistor
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivå.

Följande exempel läser in en presentation och sparar alla synliga bilder till PDF med standardexportinställningarna.

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

Aspose erbjuder en gratis online‑[**PowerPoint‑till‑PDF‑konverterare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar processen för att konvertera en presentation till PDF. Du kan köra ett test med denna konverterare för en levande implementation av proceduren som beskrivs här.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ – egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) – som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du definiera din föredragna kvalitet för rasterbilder, ange hur metafilformat ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Följande exempel exporterar en presentation till PDF 1.5 med JPEG‑kvalitet satt till 90, bildupplösning satt till 300 DPI, metafilformat sparade som PNG och Flate‑textkomprimering.

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

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagarna får åtkomst till arbetsbokens data samt kan se bilderna. Anropa [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) med `true` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑filen.

Standardvärdet är `false`: OLE‑objektets förhandsgranskningsbild eller ikon renderas på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. När alternativet sätts till `true` inkluderas dessutom filens data. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagarna öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑kalkylblad på PDF‑sidan.

Följande exempel läser in en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken bifogad.

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

1. Öppna den exporterade PDF‑filen i en visare som stöder filbilagor, t.ex. Adobe Acrobat Reader.
2. Öppna visarens **Attachments**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Note" %}}

PDF/A‑standarderna ställer begränsningar på bilagor: PDF/A‑1 förbjuder inbäddade filer, PDF/A‑2 tillåter endast PDF/A‑bilagor och PDF/A‑3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav från standarderna, inte begränsningar specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och visar inte PDF/A‑export.

{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) från klassen [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

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

Följande exempel exporterar en presentation till ett PDF som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive högkvalitativ utskrift.

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

### **Upptäcka teckensnittssubstitutioner**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) under klassen [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), vilket gör att du kan upptäcka teckensnittssubstitutioner under PowerPoint‑till‑PDF‑konverteringsprocessen.

Följande exempel exporterar en presentation till PDF och skriver ut varningar om teckensnittssubstitutioner till konsolen. En varning skrivs endast ut när ett otillgängligt teckensnitt ersätts under export.

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

För mer information om teckensnittssubstitution, se artikeln [Font Substitution](/slides/sv/androidjava/font-substitution/).

{{% /alert %}} 

### **Hantera teckensnitt utan en dedikerad fet stil**

En presentation kan tillämpa fet formatering på text även när teckensnittet saknar en dedikerad fet stil. Texten kan fortfarande visas fet genom syntetisk fetning, vilket artificiellt tjocknar de vanliga glyferna. När den texten ser för tung ut eller på annat sätt avviker från den avsedda utseendet i PDF, prova att anropa [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) med `true`. Detta alternativ renderar den berörda texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa teckensnitt. Standardvärdet är `false`.

Exempelpresentationen innehåller två textrutor: en med vanlig text och en med fet formatering applicerad på samma teckensnitt, som saknar en dedikerad fet stil. Följande exempel läser in presentationen, aktiverar rasterisering av icke‑stödda teckensnittsstilar och exporterar den till PDF:

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

Följande förhandsvisningar visar resultatet med alternativet inaktiverat respektive aktiverat. I detta exempel har den feta texten tjockare streck när alternativet är inaktiverat. Med alternativet aktiverat är strecken lättare; den vanliga texten är oförändrad. Jämför resultaten innan du väljer inställning för din presentation.

| Alternativ inaktiverat (`false`, standard) | Alternativ aktiverat (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

I detta exempel gör aktivering av alternativet endast den feta texten till en bitmap: den kan inte markeras, kopieras eller sökas som text utan OCR, och dess kanter blir mjukare vid 800 % zoom. Den vanliga texten förblir sökbar. Med alternativet inaktiverat förblir båda strängarna som text.

Detta alternativ rasteriserar text som är fet när teckensnittet saknar en dedikerad fet stil. [Font substitution](/slides/sv/androidjava/font-substitution/) väljer i stället ett annat teckensnitt när det ursprungliga är otillgängligt.

## **Konvertera utvalda bilder från PowerPoint till PDF**

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

Följande exempel kopierar den första bilden från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Den skalar bildinnehållet för att passa och exporterar den enda bilden till PDF.

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

## **Konvertera PowerPoint till PDF i bildspårningsläge för anteckningar**

Följande exempel exporterar en presentation till PDF och placerar varje bilds talarnoteringar under bilden. Använd en presentation som innehåller talarnoteringar för att se resultatet.

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

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserat på olika efterlevnadsstandarder:

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

Aspose.Slides stöder PDF‑konverteringsoperationer, vilket gör att du kan konvertera PDF‑filer till populära filformat. Du kan utföra [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) och [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/)‑konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) och [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—stöds också.

{{% /alert %}}

> **Obs!** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik som SmartArt, diagram och formler som en enda figur. Enskilda banelement bevaras inte som separerat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och applicera konverteringsprocessen programatiskt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑filen?**

Ja. Använd klassen [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) för att sätta ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑filen?**

Anropa [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) med `true` i klassen [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) för att inkludera dolda bilder i den resulterande PDF‑filen.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑filen?**

Ja, du kan kontrollera bildkvaliteten genom att använda metoder som [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) och [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) i klassen [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer [various standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets- och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides för Android via Java Documentation](/slides/sv/androidjava/)
- [Aspose.Slides för Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)