---
title: Konvertera PPT och PPTX till PDF i PHP [Avancerade funktioner inkluderade]
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i PHP med Aspose.Slides, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i PHP erbjuder flera fördelar, inklusive kompatibilitet på olika enheter och bevarande av layout och formatering av din presentation. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering samt tillämpar efterlevnadsstandarder på utdatatfiler.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation)-klassen och spara sedan presentationen som en PDF med hjälp av en `save`‑metod. [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation)-klassen exponerar `save`‑metoden som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides för PHP via Java infogar sin API‑information och versionsnummer i utdatatdokumenten. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF Producer‑fältet med ett värde i formen "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdatatdokumenten.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna nära matchar de ursprungliga presentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I det här fallet försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Den här koden visar hur du konverterar en presentation (PPT, PPTX, ODP osv.) till PDF:

```php
# Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Spara presentationen som en PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose erbjuder en gratis online [**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna konverterare för en live‑implementation av den beskrivna proceduren.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides erbjuder anpassade alternativ—egenskaper under [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PdfOptions)-klassen—som låter dig skräddarsy den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller specificera hur konverteringsprocessen ska fortskrida.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Kodexemplet nedan demonstrerar hur du konverterar en PowerPoint‑presentation till PDF med flera anpassade alternativ.

```php
# Instansiera PdfOptions-klassen.
$pdfOptions = new PdfOptions();

# Ställ in kvaliteten för JPG-bilder.
$pdfOptions->setJpegQuality(90);

# Ställ in DPI för bilder.
$pdfOptions->setSufficientResolution(300);

# Ställ in beteendet för metafiler.
$pdfOptions->setSaveMetafilesAsPng(true);

# Ställ in textkomprimeringsnivån för textinnehåll.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definiera PDF-efterlevnadsläget.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Spara presentationen som ett PDF-dokument.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda [setShowHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides)-metoden från [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PdfOptions)-klassen för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

Den här koden visar hur du konverterar en PowerPoint‑presentation till PDF med dolda bilder inkluderade:

```php
# Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instansiera PdfOptions-klassen.
    $pdfOptions = new PdfOptions();

    # Lägg till dolda bilder.
    $pdfOptions->setShowHiddenSlides(true);

    # Spara presentationen som en PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konvertera PowerPoint till lösenordsskyddad PDF**

Den här koden demonstrerar hur du konverterar en PowerPoint‑presentation till en lösenordsskyddad PDF med hjälp av skyddsparametrarna från [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/)-klassen:

```php
# Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instansiera PdfOptions-klassen.
    $pdfOptions = new PdfOptions();

    # Ställ in ett PDF-lösenord och åtkomstbehörigheter.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Spara presentationen som en PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Upptäcka teckensnittsersättningar**

Aspose.Slides tillhandahåller [setWarningCallback](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setWarningCallback)-metoden under [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/)-klassen, vilket möjliggör att upptäcka teckensnittsersättningar under konverteringen från presentation till PDF.

Den här koden visar hur du upptäcker teckensnittsersättningar:

```php
// Ange varningsåterkallning i PDF-alternativ.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("sample.pptx");
try {
    // Spara presentationen som en PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 
För mer information om teckensnittsersättning, se artikeln [Font Substitution](/slides/sv/php-java/font-substitution/).
{{% /alert %}} 

## **Konvertera valda bilder i PowerPoint till PDF**

Den här koden demonstrerar hur du konverterar endast specifika bilder från en PowerPoint‑presentation till PDF:

```php
# Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Ställ in array med bildnummer.
    $slides = array(1, 3);

    # Spara presentationen som en PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Den här koden demonstrerar hur du konverterar en PowerPoint‑presentation till PDF med en specificerad bildstorlek:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("SelectedSlides.pptx");

# Skapa en ny presentation med en justerad bildstorlek.
$resizedPresentation = new Presentation();

try {
    # Ställ in den anpassade bildstorleken.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Klona den första bilden från den ursprungliga presentationen.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Spara den storleksändrade presentationen till en PDF med anteckningar.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Konvertera PowerPoint till PDF i anteckningsvy**

Den här koden demonstrerar hur du konverterar en PowerPoint‑presentation till en PDF som inkluderar anteckningar:

```php
# Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Konfigurera PDF-alternativen med anteckningslayout.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Spara presentationen till en PDF med anteckningar.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Den här koden demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som skapar flera PDF‑filer baserat på olika efterlevnadsstandarder:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides stöder PDF‑konverteringsoperationer och gör det möjligt att konvertera PDF‑filer till populära filformat. Du kan utföra konverteringar från [PDF till HTML](https://products.aspose.com/slides/sv/php-java/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/sv/php-java/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/sv/php-java/conversion/pdf-to-jpg/), och [PDF till PNG](https://products.aspose.com/slides/sv/php-java/conversion/pdf-to-png/). Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/sv/php-java/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/sv/php-java/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/sv/php-java/conversion/pdf-to-xml/)—stöds också.
{{% /alert %}}

> **Obs:** Vid export till PDF/UA behandlar Aspose.Slides komplex grafik som SmartArt, diagram och formler som en enda figur. Enskilda banaelement bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och programmässigt tillämpa konverteringsprocessen.

**Är det möjligt att lösenordsskydda den konverterade PDF‑filen?**

Absolut. Använd [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/)-klassen för att sätta ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑filen?**

Använd `setShowHiddenSlides`‑metoden i [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/)-klassen för att inkludera dolda bilder i den resulterande PDF‑filen.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑filen?**

Ja, du kan kontrollera bildkvaliteten genom att använda metoder som `setJpegQuality` och `setSufficientResolution` i [PdfOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfoptions/)-klassen för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller krav på tillgänglighet och arkivering.

## **Ytterligare resurser**

- [Aspose.Slides för PHP via Java‑dokumentation](/slides/sv/php-java/)
- [Aspose.Slides för PHP via Java‑API‑referens](https://reference.aspose.com/slides/sv/php-java/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/sv/conversion)