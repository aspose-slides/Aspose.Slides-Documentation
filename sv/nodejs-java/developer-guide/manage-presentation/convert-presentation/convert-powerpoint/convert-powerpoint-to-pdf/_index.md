---
title: "Konvertera PPT och PPTX till PDF i JavaScript [Avancerade funktioner inkluderade]"
linktitle: "PowerPoint till PDF"
type: docs
weight: 40
url: /sv/nodejs-java/convert-powerpoint-to-pdf/
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
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer med Aspose.Slides för Node.js, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint- och OpenDocument-presentationer (PPT, PPTX, ODP osv.) till PDF-format i JavaScript erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layout och formatering av din presentation. Denna guide visar hur man konverterar presentationer till PDF-dokument, använder olika alternativ för att styra bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF-filer, upptäcker teckensnittsbyten, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdata-dokumenten.

## **PowerPoint till PDF-konverteringar**

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) och spara sedan presentationen som en PDF med metoden [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) exponerar metoden [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides för Node.js via Java infogar sin API-information och versionsnummer i utmatningsdokument. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i Application‑fältet med "*Aspose.Slides*" och PDF‑Producer‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utmatningsdokument.
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

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides att konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Följande exempel laddar en presentation och sparar alla synliga bilder till PDF med standardexportinställningarna.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose erbjuder en gratis online [**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar presentation‑till‑PDF‑konverteringsprocessen. Du kan köra ett test med denna konverterare för en live‑implementering av proceduren som beskrivs här.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska fortsätta.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Följande exempel exporterar en presentation till PDF 1.5 med JPEG‑kvalitet satt till 90, bildupplösning satt till 300 DPI, metafiler sparade som PNG och Flate‑textkomprimering.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Välj automatiskt bildkomprimering**

När en presentation innehåller många fotografier eller skärmbilder kan minskning av storleken på den exporterade PDF‑filen göra det enklare att e‑posta eller ladda ner den. Anropa [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) med `true` för att automatiskt välja den mest lämpliga komprimeringsalgoritmen för varje bild under PDF‑export.

Följande exempel laddar en befintlig presentation, aktiverar automatisk bildkomprimeringsval och sparar den som ett PDF‑dokument. Alla andra PDF‑exportinställningar behåller sina standardvärden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Detta alternativ väljer en komprimeringsalgoritm för varje bild. Att sänka värdet som skickas till [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) minskar JPEG‑bildkvaliteten, medan att sänka värdet som skickas till [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) tillåter att bilderna nedstrandas till en lägre upplösning, vilket kan minska detaljer. Aktivering av automatisk komprimeringsval sänker i sig inte någon av dessa inställningar.

Att välja bildkomprimeringsalgoritmer kräver extra bearbetningstid och minne. Storleksreduceringen beror på presentationens bilder och exportinställningar; en fast reduktion kan inte garanteras för varje presentation.

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagare får tillgång till arbetsbokens data samt kan se bilderna. Anropa [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) med `true` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑filen.

Standardvärdet är `false`: OLE‑objektets förhandsgranskningsbild eller ikon renderas på PDF‑sidan, men dess inbäddade fil inkluderas inte som en bilaga. Att sätta alternativet till `true` inkluderar dessutom filens data. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagarna öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑arbetsblad på PDF‑sidan.

Följande exempel laddar en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken som bilaga.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

För att kontrollera resultatet:

1. Öppna den exporterade PDF‑filen i en visare som stödjer filbilagor, t.ex. Adobe Acrobat Reader.
2. Öppna visarens **Attachments**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Note" %}}
PDF/A‑standarderna påför begränsningar för bilagor: PDF/A‑1 förbjuder inbäddade filer, PDF/A‑2 tillåter endast PDF/A‑bilagor och PDF/A‑3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav från standarderna, inte begränsningar specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och demonstrerar inte PDF/A‑export.
{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) från klassen [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

Följande exempel exporterar en presentation till PDF och inkluderar eventuella dolda bilder.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konvertera PowerPoint till ett lösenordsskyddat PDF**

Följande exempel exporterar en presentation till en PDF som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive högkvalitativ utskrift.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Upptäck teckensnittsbyten**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) under klassen [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) som gör det möjligt att upptäcka teckensnittsbyten under presentation‑till‑PDF‑konverteringsprocessen.

Följande exempel exporterar en presentation till PDF och skriver ut varningar om teckensnittsbyten till konsolen. En varning skrivs endast ut när ett otillgängligt teckensnitt byts ut under export.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
För mer information om teckensnittsbyte, se artikeln [Font Substitution](/slides/sv/nodejs-java/font-substitution/).
{{% /alert %}}

### **Hantera teckensnitt utan en dedikerad fet stil**

En presentation kan applicera fet formatering på text även när teckensnittet saknar en dedikerad fet stil. Texten kan ändå visas fet genom syntetisk fetning, som konstgjort förtjockar de vanliga glyferna. När den texten ser för tung ut eller på annat sätt avviker från den avsedda utseendet i PDF kan du prova att anropa [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) med `true`. Detta alternativ renderar den påverkade texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa teckensnitt. Standardvärdet är `false`.

Exempelpresentationen innehåller två textrutor: en med vanlig text och en med fet formatering applicerad på samma teckensnitt, som saknar en dedikerad fet stil. Följande exempel laddar presentationen, aktiverar rasterisering av ej stödda teckensnittsstilar och exporterar den till PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Följande förhandsvisningar visar den inaktiverade och den aktiverade utdata. I detta exempel har den feta texten tjockare linjer när alternativet är inaktiverat. När alternativet är aktiverat är linjerna lättare; den vanliga texten förblir oförändrad. Jämför resultaten innan du väljer inställningen för din presentation.

| Alternativ inaktiverat (`false`, standard) | Alternativ aktiverat (`true`) |
|---|---|
| ![PDF med rasterisering av ej stödd teckensnittsstil inaktiverad](unsupported-bold-disabled.png) | ![PDF med rasterisering av ej stödd teckensnittsstil aktiverad](unsupported-bold-enabled.png) |

I detta exempel gör aktivering av alternativet att endast den feta texten blir en bitmap: den kan inte väljas, kopieras eller sökas som text utan OCR, och dess kanter blir mjukare vid 800 % zoom. Den vanliga texten förblir sökbar. När alternativet är inaktiverat förblir båda strängarna text.

Detta alternativ rasteriserar text som är formaterad som fet när teckensnittet saknar en dedikerad fet stil. [Font substitution](/slides/sv/nodejs-java/font-substitution/) väljer i stället ett annat teckensnitt när det ursprungliga inte är tillgängligt.

## **Konvertera valda bilder från PowerPoint till PDF**

Följande exempel exporterar bilderna 1 och 3 från en presentation till PDF. Bildnumren i denna array är ett‑baserade, och inmatningspresentationen måste innehålla minst tre bilder.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Följande exempel kopierar den första bilden från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Det skalär bildinnehållet för att passa och exporterar den enda bilden till PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Ta bort den tomma bilden som den nya presentationen skapades med.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF i anteckningsvy**

Följande exempel exporterar en presentation till PDF och placerar varje bilds talarnoter under bilden. Använd en presentation som innehåller talarnoter för att se resultatet.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tillgänglighets‑ och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserade på olika efterlevnadsstandarder:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides stödjer PDF‑konverteringsoperationer, vilket gör det möjligt att konvertera PDF‑filer till populära filformat. Du kan utföra konverteringar från [PDF till HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF till JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) och [PDF till PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—stöds också.
{{% /alert %}}

> **Obs:** Vid export till PDF/UA behandlar Aspose.Slides komplex grafik som SmartArt, diagram och formler som en enda figur. Individuella banelement bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **Vanliga frågor**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**  
Ja, Aspose.Slides stödjer batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och tillämpa konverteringsprocessen programmässigt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑filen?**  
Ja. Använd klassen [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) för att sätta ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑filen?**  
Anropa [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) med `true` i klassen [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) för att inkludera dolda bilder i den resulterande PDF‑filen.

**Kan Aspose.Slides bevara hög bildkvalitet i PDF‑filen?**  
Ja, du kan kontrollera bildkvaliteten genom att använda metoder såsom [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) och [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) i klassen [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**  
Ja, Aspose.Slides låter dig exportera PDF‑filer som följer [olika standarder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller krav på tillgänglighet och arkivering.

## **Ytterligare resurser**

- [Aspose.Slides för Node.js via Java-dokumentation](/slides/sv/nodejs-java/)
- [Aspose.Slides för Node.js via Java API‑referens](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/conversion)