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
- bilaga
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i PHP med Aspose.Slides, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i PHP ger flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layout och formatering i presentationen. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittsökningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdata‑dokument.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑klassen och spara sedan presentationen som en PDF med hjälp av en [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑metod. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑klassen exponerar [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑metoden som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Obs" %}}
Aspose.Slides för PHP via Java infogar sin API‑information och versionsnummer i utdatafiler. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i Application‑fältet med "*Aspose.Slides*" och PDF‑Producer‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdatafiler.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna noggrant matchar originalpresentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punktlistor
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Följande exempel läser in en presentation och sparar alla synliga bilder till PDF med standard­exportinställningarna.

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

{{% alert color="info" title="Obs" %}}
Aspose erbjuder en gratis online‑konverterare för [**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar processen för att konvertera presentationer till PDF. Du kan köra ett test med den här konverteraren för en live‑implementation av den beskrivna proceduren.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ — egenskaper under [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klassen — som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska gå till.

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

### **Välj automatisk bildkomprimering**

När en presentation innehåller många fotografier eller skärmdumpar kan minskning av den exporterade PDF‑filens storlek göra det enklare att e‑posta eller ladda ner. Anropa [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) med `true` för att automatiskt välja den mest lämpliga komprimeringsalgoritmen för varje bild under PDF‑export.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Detta alternativ väljer en komprimeringsalgoritm för varje bild. Att sänka värdet som skickas till [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) minskar JPEG‑bildkvaliteten, medan en sänkning av värdet som skickas till [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) tillåter att bilder samplas ner till en lägre upplösning, vilket kan reducera detaljer. Att aktivera automatisk komprimeringsval sänker i sig inte någon av dessa inställningar.

Att välja bildkomprimeringsalgoritmer kräver extra behandlingstid och minne. Storleksreduktionen beror på presentationens bilder och exportinställningar; en fast reduktion kan inte garanteras för varje presentation.

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagare även får åtkomst till arbetsbokens data. Anropa [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) med `true` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑filen.

Standardvärdet är `false`: OLE‑objektets förhandsgranskningsbild eller ikon renderas på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. Att sätta alternativet till `true` inkluderar dessutom fildata. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagare öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑kalkylblad på PDF‑sidan.

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

1. Öppna den exporterade PDF‑filen i en visare som stöder filbilagor, exempelvis Adobe Acrobat Reader.
2. Öppna visarens **Bilagor**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Obs" %}}
PDF/A‑standarderna inför begränsningar för bilagor: PDF/A‑1 förbjuder inbäddade filer, PDF/A‑2 tillåter endast PDF/A‑bilagor och PDF/A‑3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav från standarderna, inte begränsningar specifika för Aspose.Slides. Detta exempel använder standard‑PDF‑efterlevnadsinställning och demonstrerar inte PDF/A‑export.
{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) från [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klassen för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

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

Följande exempel exporterar en presentation till ett PDF‑dokument som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive utskrift i hög kvalitet.

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

### **Upptäcka teckensnittsökningar**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) under [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klassen, vilket gör att du kan upptäcka teckensnittsökningar under konverteringsprocessen från presentation till PDF.

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

{{% alert color="info" title="Obs" %}}
För mer information om teckensnittsökning, se artikeln [Font Substitution](/slides/sv/php-java/font-substitution/).
{{% /alert %}} 

### **Hantera teckensnitt utan en dedikerad fet stil**

En presentation kan tillämpa fet formatering på text även när teckensnittet saknar en dedikerad fet stil. Texten kan ändå visas fet genom syntetisk fetstil, som artificiellt förtjockar de vanliga tecknen. När den fetstilta texten ser för tung ut eller på annat sätt avviker från den avsedda utseendet i PDF, prova att anropa [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) med `true`. Detta alternativ renderar den påverkade texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa teckensnitt. Standardvärdet är `false`.

Exempelpresentationen innehåller två textrutor: en med vanlig text och en med fet formatering applicerad på samma teckensnitt, som saknar en dedikerad fet stil. Följande exempel läser in presentationen, aktiverar rasterisering av ej stödde teckensnittsstilar och exporterar den till PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Följande förhandsvisningar visar resultatet med alternativet inaktiverat och med det aktiverat. I detta exempel har den feta texten tjockare streck när alternativet är inaktiverat. Med alternativet aktiverat är strecken lättare; den vanliga texten är oförändrad. Jämför resultaten innan du väljer inställning för din presentation.

| Alternativ inaktiverad (`false`, standard) | Alternativ aktiverad (`true`) |
|---|---|
| ![PDF med rasterisering av ej stödde fontstil inaktiverad](unsupported-bold-disabled.png) | ![PDF med rasterisering av ej stödde fontstil aktiverad](unsupported-bold-enabled.png) |

I detta exempel gör aktiveringen av alternativet endast den feta texten till en bitmap: den kan inte markeras, kopieras eller sökas som text utan OCR, och dess kanter blir mjukare vid 800 % zoom. Den vanliga texten förblir sökbar. När alternativet är inaktiverat förblir båda strängarna som text.

Detta alternativ rasteriserar text formaterad som fet när teckensnittet saknar en dedikerad fet stil. [Font Substitution](/slides/sv/php-java/font-substitution/) väljer i stället ett annat teckensnitt när det ursprungliga inte är tillgängligt.

## **Konvertera valda bilder från PowerPoint till PDF**

Följande exempel exporterar bild 1 och 3 från en presentation till PDF. Bildnumren i denna matris är en‑baserade, och den inmatade presentationen måste innehålla minst tre bilder.

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

Följande exempel kopierar den första bilden från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Den skalas för att passa och exporterar den enkla bilden till PDF.

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

## **Konvertera PowerPoint till PDF i notvy för bilder**

Följande exempel exporterar en presentation till PDF, där varje bilds talarnoter placeras under bilden. Använd en presentation som innehåller talarnoter för att se resultatet.

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

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserade på olika efterlevnadsstandarder:

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

{{% alert color="info" title="Obs" %}}
Aspose.Slides stöder PDF‑konverteringsoperationer och låter dig konvertera PDF‑filer till populära filformat. Du kan utföra [PDF till HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) och [PDF till PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format — [PDF till SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — stöds också.
{{% /alert %}}

> **Obs:** Vid export till PDF/UA behandlar Aspose.Slides komplexa grafikobjekt som SmartArt, diagram och formler som en enda figur. Enskilda ban‑element bevaras inte som separat innehåll och kan markeras som artefakter; alternativtext tillhandahålls endast för hela figuren.

## **Vanliga frågor**

**Kan jag konvertera flera PowerPoint‑filer till PDF i batch?**

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera över dina filer och programatiskt tillämpa konverteringsprocessen.

**Är det möjligt att lösenordsskydda den konverterade PDF‑filen?**

Ja. Använd [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klassen för att sätta ett lösenord och definiera åtkomstbehörigheter under konverteringen.

**Hur inkluderar jag dolda bilder i PDF‑filen?**

Anropa [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) med `true` i [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klassen för att inkludera dolda bilder i den resulterande PDF‑filen.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑filen?**

Ja, du kan kontrollera bildkvaliteten genom att använda metoder som [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) och [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) i [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)‑klassen för att säkerställa högkvalitativa bilder i ditt PDF‑dokument.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer [olika standarder](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller krav på tillgänglighet och arkivering.

## **Ytterligare resurser**

- [Aspose.Slides för PHP via Java‑dokumentation](/slides/sv/php-java/)
- [Aspose.Slides för PHP via Java‑API‑referens](https://reference.aspose.com/slides/php-java/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/conversion)