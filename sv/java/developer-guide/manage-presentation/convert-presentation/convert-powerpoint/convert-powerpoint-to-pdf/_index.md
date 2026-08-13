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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF‑filer i Java med Aspose.Slides, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i Java erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layout och formatering i presentationen. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utmatningsdokument.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen och spara sedan presentationen som en PDF med en `save`‑metod. [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen exponerar `save`‑metoden som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java infogar sin API‑information och versionsnummer i output‑dokumenten. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i Application‑fältet med "*Aspose.Slides*" och PDF Producer‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs!** du kan inte instruera Aspose.Slides att ändra eller ta bort denna information från output‑dokumenten.

{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna noggrant matchar originalpresentationerna. Element och attribut renderas exakt i konverteringen, inklusive:

* Bilder
* Textfält och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punktlistor
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitet.

Denna kod visar hur du konverterar en presentation (PPT, PPTX, ODP osv.) till PDF:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Spara presentationen som en PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose erbjuder en gratis online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar presentation‑till‑PDF‑konverteringsprocessen. Du kan köra ett test med denna konverterare för en levande implementering av proceduren som beskrivs här.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/)-klassen—som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du definiera din föredragna kvalitet för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Kodexemplet nedan demonstrerar hur du konverterar en PowerPoint‑presentation till PDF med flera anpassade alternativ.

```java
import com.aspose.slides.*;

// Instansiera PdfOptions-klassen.
PdfOptions pdfOptions = new PdfOptions();

// Ange kvaliteten för JPG-bilder.
pdfOptions.setJpegQuality((byte)90);

// Ange DPI för bilder.
pdfOptions.setSufficientResolution(300);

// Ange beteendet för metafiler.
pdfOptions.setSaveMetafilesAsPng(true);

// Ange komprimeringsnivån för textinnehåll.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definiera PDF‑efterlevnadsläget.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Spara presentationen som ett PDF-dokument.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda `setShowHiddenSlides`‑metoden från [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/)‑klassen för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

Denna kod visar hur du konverterar en PowerPoint‑presentation till PDF med dolda bilder inkluderade:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instansiera PdfOptions-klassen.
    PdfOptions pdfOptions = new PdfOptions();

    // Lägg till dolda bilder.
    pdfOptions.setShowHiddenSlides(true);

    // Spara presentationen som en PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konvertera PowerPoint till lösenordsskyddad PDF**

Denna kod demonstrerar hur du konverterar en PowerPoint‑presentation till en lösenordsskyddad PDF med skyddsparametrarna från [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/)‑klassen:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instansiera PdfOptions-klassen.
    PdfOptions pdfOptions = new PdfOptions();

    // Ange ett PDF-lösenord och åtkomstbehörigheter.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Spara presentationen som en PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detektera teckensnittsersättningar**

Aspose.Slides tillhandahåller `setWarningCallback`‑metoden under [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/)-klassen, vilket gör att du kan upptäcka teckensnittsersättningar under presentation‑till‑PDF‑konverteringsprocessen.

Denna kod visar hur du upptäcker teckensnittsersättningar:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
    Presentation presentation = new Presentation("sample.pptx");

    // Ange varningscallback i PDF-alternativ.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Spara presentationen som en PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementering av varningscallback.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

För mer information om att ta emot callbacks för teckensnittsersättningar under renderingsprocessen, se [Getting Warning Callbacks for Fonts Substitution](/slides/sv/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

För mer information om teckensnittsersättning, se artikeln [Font Substitution](/slides/sv/java/font-substitution/).

{{% /alert %}} 

## **Konvertera valda bilder i PowerPoint till PDF**

Denna kod demonstrerar hur du bara konverterar specifika bilder från en PowerPoint‑presentation till PDF:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Ange en array med bildnummer.
    int[] slides = { 1, 3 };

    // Spara presentationen som en PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Denna kod demonstrerar hur du konverterar en PowerPoint‑presentation till PDF med en specificerad bildstorlek:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Skapa en ny presentation med en justerad bildstorlek.
Presentation resizedPresentation = new Presentation();

try {
    // Ange den anpassade bildstorleken.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Klona den första bilden från den ursprungliga presentationen.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Ta bort den tomma bilden som den nya presentationen skapades med.
    resizedPresentation.getSlides().removeAt(1);

    // Spara den ändrade presentationen som en PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF i anteckningsvyn**

Denna kod demonstrerar hur du konverterar en PowerPoint‑presentation till en PDF som inkluderar anteckningar:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Konfigurera PDF-alternativen med anteckningslayout.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen som en PDF med anteckningar.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserade på olika efterlevnadsstandarder:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides stöder PDF‑konverteringsoperationer, vilket gör att du kan konvertera PDF‑filer till populära filformat. Du kan utföra [PDF to HTML](https://products.aspose.com/slides/sv/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/sv/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/sv/java/conversion/pdf-to-jpg/), och [PDF to PNG](https://products.aspose.com/slides/sv/java/conversion/pdf-to-png/)‑konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF to SVG](https://products.aspose.com/slides/sv/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/sv/java/conversion/pdf-to-tiff/), och [PDF to XML](https://products.aspose.com/slides/sv/java/conversion/pdf-to-xml/)—stöds också.

{{% /alert %}}

> **Obs!** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda sökvägsdelar bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

### Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och programatiskt applicera konverteringsprocessen.

### Är det möjligt att lösenordsskydda den konverterade PDF‑filen?

Absolut. Använd [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/)‑klassen för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

### Hur inkluderar jag dolda bilder i PDF‑filen?

Använd `setShowHiddenSlides`‑metoden i [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/)‑klassen för att inkludera dolda bilder i den resulterande PDF‑filen.

### Kan Aspose.Slides bibehålla hög bildkvalitet i PDF‑filen?

Ja, du kan kontrollera bildkvaliteten genom att använda metoder såsom `setJpegQuality` och `setSufficientResolution` i [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/)‑klassen för att säkerställa högkvalitativa bilder i din PDF.

### Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?

Ja, Aspose.Slides låter dig exportera PDF‑filer som uppfyller [olika standarder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfcompliance/), inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets- och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides for Java Documentation](/slides/sv/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/sv/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/sv/conversion)