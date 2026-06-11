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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i Java med Aspose.Slides för Android, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint-presentationer (PPT, PPTX, ODP osv.) till PDF-format på Android ger flera fördelar, inklusive kompatibilitet mellan olika enheter och bevarande av layout och formatering i din presentation. Denna guide visar hur du konverterar presentationer till PDF-dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF-filer, upptäcker teckensnittsbyten, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdokument‑dokument.

## **PowerPoint till PDF-konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och spara sedan presentationen som en PDF med hjälp av en `save`‑metod. Klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) exponerar `save`‑metoden som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides för Android via Java infogar sin API‑information och versionsnummer i utdokument. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF‑Producer‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdokument.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna noggrant matchar de ursprungliga presentationerna. Element och attribut renderas exakt vid konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckesformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I det här fallet försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Denna kod visar hur du konverterar en presentation (PPT, PPTX, ODP osv.) till PDF:

```java
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Spara presentationen som en PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose erbjuder en gratis online‑[**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna konverterare för en live‑implementation av den beskrivna proceduren.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/)—som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Kodexemplet nedan demonstrerar hur du konverterar en PowerPoint-presentation till PDF med flera anpassade alternativ.

```java
// Instansiera PdfOptions-klassen.
PdfOptions pdfOptions = new PdfOptions();

// Ställ in kvaliteten för JPG-bilder.
pdfOptions.setJpegQuality((byte)90);

// Ställ in DPI för bilder.
pdfOptions.setSufficientResolution(300);

/// Ställ in beteendet för metafiler.
pdfOptions.setSaveMetafilesAsPng(true);

// Ställ in textkomprimeringsnivån för textinnehåll.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definiera PDF‑efterlevnadsläge.
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

Om en presentation innehåller dolda bilder kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) från klassen [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

Denna kod visar hur du konverterar en PowerPoint-presentation till PDF med dolda bilder inkluderade:

```java
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

Denna kod demonstrerar hur du konverterar en PowerPoint-presentation till en lösenordsskyddad PDF med skyddsparametrarna från klassen [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/):

```java
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instansiera PdfOptions-klassen.
    PdfOptions pdfOptions = new PdfOptions();

    // Ställ in ett PDF-lösenord och åtkomstbehörigheter.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Spara presentationen som en PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Upptäck teckensnittsbyten**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) under klassen [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/), vilket gör det möjligt att upptäcka teckensnittsbyten under konverteringsprocessen från presentation till PDF.

Denna kod visar hur du upptäcker teckensnittsbyten:

```java
public static void main(String[] args) {
    // Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
    Presentation presentation = new Presentation("sample.pptx");

    // Ställ in varningsåterkallningsmetoden i PDF-alternativen.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Spara presentationen som en PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementering av varningsåterkallningsmetoden.
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

{{%  alert color="primary"  %}} 
För mer information om teckensnittsbyte, se artikeln [Font Substitution](/slides/sv/androidjava/font-substitution/).
{{% /alert %}} 

## **Konvertera utvalda bilder från PowerPoint till PDF**

Denna kod demonstrerar hur du konverterar endast specifika bilder från en PowerPoint-presentation till PDF:

```java
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

Denna kod visar hur du konverterar en PowerPoint-presentation till PDF med en specificerad bildstorlek:

```java
float slideWidth = 612;
float slideHeight = 792;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Skapa en ny presentation med en justerad bildstorlek.
Presentation resizedPresentation = new Presentation();

try {
    // Ställ in den anpassade bildstorleken.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Klona den första bilden från den ursprungliga presentationen.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Spara den omjusterade presentationen till en PDF med anteckningar.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF i bildvisning för anteckningar**

Denna kod demonstrerar hur du konverterar en PowerPoint-presentation till en PDF som inkluderar anteckningar:

```java
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Konfigurera PDF-alternativen med anteckningslayout.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen till en PDF med anteckningar.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint-dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserade på olika efterlevnadsstandarder:

```java
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
Aspose.Slides stödjer PDF‑konverteringsoperationer och låter dig konvertera PDF‑filer till populära filformat. Du kan utföra konverteringar [PDF till HTML](https://products.aspose.com/slides/sv/java/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/sv/java/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/sv/java/conversion/pdf-to-jpg/) och [PDF till PNG](https://products.aspose.com/slides/sv/java/conversion/pdf-to-png/). Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/sv/java/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/sv/java/conversion/pdf-to-tiff/) och [PDF till XML](https://products.aspose.com/slides/sv/java/conversion/pdf-to-xml/)—stöds också.
{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda ban‑element bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **Vanliga frågor**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stödjer batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och tillämpa konverteringsprocessen programmässigt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑filen?**

Absolut. Använd klassen [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑filen?**

Använd metoden `setShowHiddenSlides` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/) för att inkludera dolda bilder i den resulterande PDF‑filen.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑filen?**

Ja, du kan kontrollera bildkvaliteten genom att använda metoder såsom `setJpegQuality` och `setSufficientResolution` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller krav på tillgänglighet och arkivering.

## **Ytterligare resurser**

- [Aspose.Slides för Android via Java-dokumentation](/slides/sv/androidjava/)
- [Aspose.Slides för Android via Java API‑referens](https://reference.aspose.com/slides/sv/androidjava/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/sv/conversion)