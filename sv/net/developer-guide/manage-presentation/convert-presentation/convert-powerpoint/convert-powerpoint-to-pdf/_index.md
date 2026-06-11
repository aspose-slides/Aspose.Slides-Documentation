---
title: Konvertera PPT och PPTX till PDF i .NET [Avancerade funktioner inkluderade]
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i .NET med Aspose.Slides, med snabba C#-kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint-presentationer (PPT, PPTX, ODP osv.) till PDF-format i C# erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layout och formatering av din presentation. Den här guiden visar hur du konverterar presentationer till PDF-dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF-filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdatafiler.

## **PowerPoint till PDF-konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som argument till klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och spara sedan presentationen som en PDF med metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/). Klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) exponerar metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides för .NET infogar sin API‑information och versionsnummer i utdatafiler. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF Producer-fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Observera** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdatafiler.

{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑erna noggrant matchar originalpresentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitet.

Den här C#‑koden visar hur du konverterar en presentation (PPT, PPTX, ODP osv.) till PDF:

```c#
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.ppt");

// Spara presentationen som en PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose erbjuder en gratis online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med den här konverteraren för en levande implementering av den beskrivna proceduren.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/)—som låter dig anpassa den resulterande PDF‑en, låsa PDF‑en med ett lösenord eller specificera hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Kodexemplet nedan visar hur du konverterar en PowerPoint-presentation till PDF med flera anpassade alternativ.

```c#
// Instansiera PdfOptions-klassen.
var pdfOptions = new PdfOptions
{
    // Ange kvaliteten för JPG-bilder.
    JpegQuality = 90,

    // Ange DPI för bilder.
    SufficientResolution = 300,

    // Ange beteendet för metafiler.
    SaveMetafilesAsPng = true,

    // Ange textkomprimeringsnivån för textinnehåll.
    TextCompression = PdfTextCompression.Flate,

    // Definiera PDF-efterlevnadsläget.
    Compliance = PdfCompliance.Pdf15
};

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.pptx");

// Spara presentationen som ett PDF-dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda egenskapen [ShowHiddenSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/showhiddenslides/) från klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑en.

Den här C#‑koden visar hur du konverterar en PowerPoint-presentation till PDF med dolda bilder inkluderade:

```c#
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.pptx");

// Instansiera PdfOptions-klassen.
var pdfOptions = new PdfOptions();

// Lägg till dolda bilder.
pdfOptions.ShowHiddenSlides = true;

// Spara presentationen som en PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konvertera PowerPoint till lösenordsskyddad PDF**

Den här C#‑koden demonstrerar hur du konverterar en PowerPoint-presentation till en lösenordsskyddad PDF med skyddsparametrarna från klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/):

```c#
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.pptx");

// Instansiera PdfOptions-klassen.
var pdfOptions = new PdfOptions();

// Ange ett PDF-lösenord och åtkomstbehörigheter.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Spara presentationen som en PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Upptäck teckensnittsersättningar**

Aspose.Slides tillhandahåller egenskapen [WarningCallback](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/warningcallback/) under klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/), vilket möjliggör att upptäcka teckensnittsersättningar under konverteringsprocessen från presentation till PDF.

Den här C#‑koden visar hur du upptäcker teckensnittsersättningar:

```c#
public static void Main()
{
    // Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil. 
    using var presentation = new Presentation("sample.pptx");

    // Ange varningsåteruppringning i PDF-alternativ.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Spara presentationen som en PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementering av varningsåteruppringning.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

För mer information om att få återuppringningar för teckensnittsersättningar under renderingsprocessen, se [Getting Warning Callbacks for Fonts Substitution](/slides/sv/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/). För mer information om teckensnittsersättning, se artikeln [Font Substitution](/slides/sv/net/font-substitution/).

{{% /alert %}} 

## **Konvertera utvalda bilder från PowerPoint till PDF**

Den här C#‑koden demonstrerar hur du konverterar endast specifika bilder från en PowerPoint-presentation till PDF:

```c#
// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.pptx");

// Ange en array med bildnummer.
int[] slides = { 1, 3 };

// Spara presentationen som en PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Den här C#‑koden demonstrerar hur du konverterar en PowerPoint-presentation till PDF med en specificerad bildstorlek:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Konvertera PowerPoint till PDF i anteckningsbildsvy**

Den här C#‑koden demonstrerar hur du konverterar en PowerPoint-presentation till en PDF som inkluderar anteckningar:

```c#
// Läs in en PowerPoint-presentation.
using var presentation = new Presentation("NotesFile.pptx");

// Konfigurera PDF-alternativen med notlayout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Spara presentationen till en PDF med anteckningar.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint-dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Den här C#‑koden visar en PowerPoint‑till‑PDF‑konverteringsprocess som skapar flera PDF‑filer baserat på olika efterlevnadsstandarder:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides stöder PDF‑konverteringsoperationer och låter dig konvertera PDF‑filer till populära filformat. Du kan utföra [PDF to HTML](https://products.aspose.com/slides/sv/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/sv/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/sv/net/conversion/pdf-to-jpg/), och [PDF to PNG](https://products.aspose.com/slides/sv/net/conversion/pdf-to-png/) konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF to SVG](https://products.aspose.com/slides/sv/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/sv/net/conversion/pdf-to-tiff/), och [PDF to XML](https://products.aspose.com/slides/sv/net/conversion/pdf-to-xml/)—stöds också.

{{% /alert %}}

> **Obs:** Vid export till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda banor bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och programatiskt tillämpa konverteringsprocessen.

**Är det möjligt att lösenordsskydda den konverterade PDF‑en?**

Absolut. Använd klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑en?**

Ställ in egenskapen `ShowHiddenSlides` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) till `true` för att inkludera dolda bilder i den resulterande PDF‑en.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑en?**

Ja, du kan kontrollera bildkvaliteten genom att sätta egenskaper som `JpegQuality` och `SufficientResolution` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑standarder?**

Ja, Aspose.Slides låter dig exportera PDF‑er som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets‑ och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides för .NET-dokumentation](/slides/sv/net/)
- [Aspose.Slides för .NET API‑referens](https://reference.aspose.com/slides/sv/net/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/sv/conversion)