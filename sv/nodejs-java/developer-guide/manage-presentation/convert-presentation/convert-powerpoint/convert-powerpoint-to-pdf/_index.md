---
title: Konvertera PPT och PPTX till PDF i JavaScript [Avancerade funktioner inkluderade]
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer med Aspose.Slides för Node.js, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint- och OpenDocument-presentationer (PPT, PPTX, ODP osv.) till PDF-format i JavaScript erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layouten och formateringen av din presentation. Denna guide visar hur man konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdata‑dokument.

## **PowerPoint till PDF‑konverteringar**

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och spara sedan presentationen som en PDF med hjälp av en `save`‑metod. Klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) exponerar `save`‑metoden som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides för Node.js via Java infogar sin API‑information och versionsnummer i utdata‑dokument. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och fältet PDF Producer med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdata‑dokument.

{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF, vilket säkerställer att de resulterande PDF‑filerna matchar originalpresentationerna nära. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardmässiga PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides att konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Denna kod visar hur du konverterar en presentation (PPT, PPTX, ODP osv.) till PDF:

```js
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Spara presentationen som en PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose erbjuder en gratis online **PowerPoint till PDF‑konverterare**(https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna konverterare för en levande implementering av proceduren som beskrivs här.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ – egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/) – som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du ange din föredragna kvalitet för rasterbilder, specificera hur metafilformat ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Kodexemplet nedan visar hur du konverterar en PowerPoint-presentation till PDF med flera anpassade alternativ.

```js
// Instansiera PdfOptions-klassen.
let pdfOptions = new aspose.slides.PdfOptions();

// Ange kvaliteten för JPG-bilder.
pdfOptions.setJpegQuality(java.newByte(90));

// Ange DPI för bilder.
pdfOptions.setSufficientResolution(300);

// Ange beteendet för metafiler.
pdfOptions.setSaveMetafilesAsPng(true);

// Ange komprimeringsnivån för textinnehåll.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definiera PDF-efterlevnadsläget.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Spara presentationen som ett PDF-dokument.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) från klassen [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PdfOptions) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

Denna JavaScript‑kod visar hur du konverterar en PowerPoint-presentation till PDF med dolda bilder inkluderade:

```js
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instansiera PdfOptions-klassen.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Lägg till dolda bilder.
    pdfOptions.setShowHiddenSlides(true);

    // Spara presentationen som en PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konvertera PowerPoint till lösenordsskyddad PDF**

Denna JavaScript‑kod demonstrerar hur du konverterar en PowerPoint-presentation till en lösenordsskyddad PDF med hjälp av skyddsparametrarna från klassen [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PdfOptions):

```js
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instansiera PdfOptions-klassen.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Ange ett PDF-lösenord och åtkomstbehörigheter.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Spara presentationen som en PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detektera teckensnittsersättningar**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) under klassen [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PdfOptions), vilket gör det möjligt att upptäcka teckensnittsersättningar under konverteringsprocessen från presentation till PDF.

Denna JavaScript‑kod visar hur du upptäcker teckensnittsersättningar:

```js
// Ange varningsåteranropet i PDF-alternativen.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Spara presentationen som en PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

För mer information om teckensnittsersättning, se artikeln [Font Substitution](/slides/sv/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Konvertera valda bilder i PowerPoint till PDF**

Denna JavaScript‑kod visar hur du konverterar endast specifika bilder från en PowerPoint-presentation till PDF:

```js
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Ange en array med bildnummer.
    let slides = java.newArray("int", [1, 3]);

    // Spara presentationen som en PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Denna JavaScript‑kod visar hur du konverterar en PowerPoint-presentation till PDF med en angiven bildstorlek:

```js
const slideWidth = 612;
const slideHeight = 792;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Skapa en ny presentation med en justerad bildstorlek.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Ange den anpassade bildstorleken.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Klona den första bilden från originalpresentationen.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Spara den omformade presentationen som en PDF med anteckningar.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konvertera PowerPoint till PDF i anteckningsvysläge**

Denna JavaScript‑kod visar hur du konverterar en PowerPoint-presentation till en PDF som inkluderar anteckningar:

```js
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Konfigurera PDF-alternativen med anteckningslayout.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Spara presentationen som en PDF med anteckningar.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna JavaScript‑kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserat på olika efterlevnadsstandarder:

```js
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides stöder PDF‑konverteringsoperationer, vilket gör att du kan konvertera PDF‑filer till populära filformat. Du kan utföra konverteringar [PDF till HTML](https://products.aspose.com/slides/sv/nodejs-java/conversion/pdf-to-html/), [PDF till JPG](https://products.aspose.com/slides/sv/nodejs-java/conversion/pdf-to-jpg/) och [PDF till PNG](https://products.aspose.com/slides/sv/nodejs-java/conversion/pdf-to-png/). Andra PDF‑konverteringsoperationer till specialiserade format – [PDF till SVG](https://products.aspose.com/slides/sv/nodejs-java/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/sv/nodejs-java/conversion/pdf-to-tiff/) – stöds också.

{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda bana‑element bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT- eller PPTX‑filer till PDF. Du kan iterera genom dina filer och tillämpa konverteringsprocessen programatiskt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑filen?**

Absolut. Använd klassen [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PdfOptions) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑filen?**

Använd metoden `setShowHiddenSlides` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PdfOptions) för att inkludera dolda bilder i den resulterande PDF‑filen.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑filen?**

Ja, du kan kontrollera bildkvaliteten genom att använda metoder såsom `setJpegQuality` och `setSufficientResolution` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PdfOptions) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑standarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller krav på tillgänglighet och arkivering.

## **Ytterligare resurser**

- [Aspose.Slides för Node.js via Java-dokumentation](/slides/sv/nodejs-java/)
- [Aspose.Slides för Node.js via Java API‑referens](https://reference.aspose.com/slides/sv/nodejs-java/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/sv/conversion)