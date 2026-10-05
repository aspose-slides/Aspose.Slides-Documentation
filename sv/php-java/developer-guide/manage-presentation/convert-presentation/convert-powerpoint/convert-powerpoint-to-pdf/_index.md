---
title: "Konvertera PPT och PPTX till PDF i PHP [Avancerade funktioner inkluderade]"
linktitle: "PowerPoint till PDF"
type: docs
weight: 40
url: /sv/php-java/convert-powerpoint-to-pdf/
keywords:
- "konvertera PowerPoint"
- "konvertera presentation"
- "PowerPoint till PDF"
- "presentation till PDF"
- "PPT till PDF"
- "konvertera PPT till PDF"
- "PPTX till PDF"
- "konvertera PPTX till PDF"
- "spara PowerPoint som PDF"
- "spara PPT som PDF"
- "spara PPTX som PDF"
- "exportera PPT till PDF"
- "exportera PPTX till PDF"
- "bilaga"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "PHP"
- "Aspose.Slides"
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i PHP med Aspose.Slides, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i PHP ger flera fördelar, inklusive kompatibilitet över olika enheter samt bevarande av layout och formatering av din presentation. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bildspel, lösenordsskyddar PDF‑filer, upptäcker teckensnittsersättningar, väljer specifika bildspel för konvertering och tillämpar efterlevnadsstandarder på utdatafiler.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som argument till klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) och spara sedan presentationen som PDF med en [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save)-metod. Klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) exponerar [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save)-metoden som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java infogar sin API‑information och versionsnummer i utdokumentsfiler. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och fältet PDF Producer med ett värde i form av "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdokumentsfiler.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bildspel från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna noggrant matchar de ursprungliga presentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den tillhandahållna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Följande exempel läser in en presentation och sparar alla synliga bildspel till PDF med standardexportinställningarna.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose erbjuder en gratis online‑[**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna konverterare för en live‑implementation av proceduren som beskrivs här.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagare också får åtkomst till arbetsbokens data samt kan se bildspelen. Anropa [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) med `true` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑filen.

Standardvärdet är `false`: OLE‑objektets förhandsgranskningsbild eller ikon återges på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. Genom att sätta alternativet till `true` inkluderas dessutom fildata. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagare öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑kalkylblad på PDF‑sidan.

Följande exempel läser in en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken bifogad.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

För att kontrollera resultatet:

1. Öppna den exporterade PDF‑filen i en visare som stöder filbilagor, till exempel Adobe Acrobat Reader.
2. Öppna visarens **Bilagor**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Note" %}}
PDF/A‑standarderna inför begränsningar för bilagor: PDF/A-1 förbjuder inbäddade filer, PDF/A-2 tillåter endast PDF/A‑bilagor, och PDF/A-3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav från standarderna, inte begränsningar specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och demonstrerar inte PDF/A‑export.
{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bildspel**

Om en presentation innehåller dolda bildspel kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) från klassen [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) för att inkludera de dolda bildspelen som sidor i den resulterande PDF‑filen.

Följande exempel exporterar en presentation till PDF, inklusive eventuella dolda bildspel.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konvertera PowerPoint till ett lösenordsskyddat PDF**

Följande exempel exporterar en presentation till ett PDF som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive utskrift av hög kvalitet.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Upptäck teckensnittsersättningar**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) under klassen [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), vilket möjliggör upptäckt av teckensnittsersättningar under konverteringsprocessen från presentation till PDF.

Följande exempel exporterar en presentation till PDF och skriver ut varningar om teckensnittsersättningar till konsolen. En varning skrivs endast ut när ett otillgängligt teckensnitt ersätts under export.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
För mer information om teckensnittsersättning, se artikeln [Teckensnittsersättning](/slides/sv/php-java/font-substitution/).
{{% /alert %}} 

## **Konvertera valda bildspel från PowerPoint till PDF**

Följande exempel exporterar bildspelen 1 och 3 från en presentation till PDF. Bildnumren i denna array är 1‑baserade, och inmatningspresentationen måste innehålla minst tre bildspel.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Följande exempel kopierar den första bildspelen från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Den skalar bildspelsinnehållet för att passa och exporterar den enda bildspelen till PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Ta bort den tomma bilden som den nya presentationen skapades med.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Konvertera PowerPoint till PDF i bildspelsvyn för anteckningar**

Följande exempel exporterar en presentation till PDF, placerar varje bildspels talarnoter under bildspelen. Använd en presentation som innehåller talarnoter för att se resultatet.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Riktlinjer för webbens tillgänglighet (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som skapar flera PDF‑filer baserat på olika efterlevnadsstandarder:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides stödjer PDF‑konverteringsoperationer, så att du kan konvertera PDF‑filer till populära filformat. Du kan utföra [PDF till HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) och [PDF till PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—stöds också.
{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik som SmartArt, diagram och formler som en enda figur. Enskilda banelement bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stödjer batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och programmässigt tillämpa konverteringsprocessen.

**Är det möjligt att lösenordsskydda det konverterade PDF‑filen?**

Ja. Använd klassen [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bildspel i PDF‑filen?**

Anropa [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) med `true` i klassen [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) för att inkludera dolda bildspel i den resulterande PDF‑filen.

**Kan Aspose.Slides bevara hög bildkvalitet i PDF‑filen?**

Ja, du kan kontrollera bildkvaliteten genom att använda metoder såsom [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) och [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) i klassen [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer [olika standarder](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets- och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides för PHP via Java‑dokumentation](/slides/sv/php-java/)
- [Aspose.Slides för PHP via Java API‑referens](https://reference.aspose.com/slides/php-java/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/conversion)