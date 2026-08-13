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

Att konvertera PowerPoint-presentationer (PPT, PPTX, ODP osv.) till PDF-format i C# erbjuder flera fördelar, inklusive kompatibilitet på olika enheter och bevarande av layout och formatering av din presentation. Denna guide visar hur man konverterar presentationer till PDF-dokument, använder olika alternativ för att styra bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF-filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdatafiler.

## **PowerPoint till PDF-konverteringar**

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och spara sedan presentationen som en PDF med hjälp av metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/). Klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) exponerar metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides för .NET infogar sin API-information och versionsnummer i utdatafiler. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF Producer-fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdatafiler.

{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF-filerna noggrant matchar de ursprungliga presentationerna. Element och attribut återges korrekt i konverteringen, inklusive:

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

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.ppt");

// Spara presentationen som en PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose erbjuder en gratis online **PowerPoint‑till‑PDF‑konverterare**(https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna konverterare för en realtidsimplementation av proceduren som beskrivs här.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/)—som låter dig anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska fortskrida.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du ange din föredragna kvalitetsinställning för rasterbilder, specificera hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera PdfOptions-klassen.
var pdfOptions = new PdfOptions
{
    // Ställ in kvaliteten för JPG-bilder.
    JpegQuality = 90,

    // Ställ in DPI för bilder.
    SufficientResolution = 300,

    // Ställ in beteendet för metafiler.
    SaveMetafilesAsPng = true,

    // Ställ in komprimeringsnivån för textinnehåll.
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

Om en presentation innehåller dolda bilder kan du använda egenskapen [ShowHiddenSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/showhiddenslides/) från klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

C#‑koden visar hur man konverterar en PowerPoint-presentation till en lösenordsskyddad PDF med hjälp av skyddsparametrarna från klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.pptx");

// Instansiera PdfOptions-klassen.
var pdfOptions = new PdfOptions();

// Ställ in ett PDF-lösenord och åtkomstbehörigheter.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Spara presentationen som en PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Upptäck teckensnittsersättningar**

Aspose.Slides tillhandahåller egenskapen [WarningCallback](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveoptions/warningcallback/) under klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/), vilket möjliggör att upptäcka teckensnittsersättningar under konverteringsprocessen från presentation till PDF.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil. 
    using var presentation = new Presentation("sample.pptx");

    // Ställ in varningsåteruppringning i PDF-alternativen.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Spara presentationen som en PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementering av varningsåteruppringningen.
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

{{%  alert color="info"  %}} 

För mer information om att ta emot återuppringningar för teckensnittsersättningar under renderingsprocessen, se [Getting Warning Callbacks for Fonts Substitution](/slides/sv/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

För mer information om teckensnittsersättning, se artikeln [Font Substitution](/slides/sv/net/font-substitution/).

{{% /alert %}} 

## **Konvertera valda bilder från PowerPoint till PDF**

C#‑koden visar hur man bara konverterar specifika bilder från en PowerPoint-presentation till PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
using var presentation = new Presentation("PowerPoint.pptx");

// Ställ in array med bildnummer.
int[] slides = { 1, 3 };

// Spara presentationen som en PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

C#‑koden visar hur man konverterar en PowerPoint-presentation till PDF med en specificerad bildstorlek:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Läs in en PowerPoint-presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Skapa en ny presentation med justerad bildstorlek.
using var resizedPresentation = new Presentation();

// Ställ in den anpassade bildstorleken.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Klona den första bilden från originalpresentationen.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Ta bort den tomma bilden som den nya presentationen skapades med.
resizedPresentation.Slides.RemoveAt(1);

// Spara den anpassade presentationen som en PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Konvertera PowerPoint till PDF i noteringsbildsvy**

C#‑koden visar hur man konverterar en PowerPoint-presentation till en PDF som inkluderar anteckningar:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides låter dig använda en konverteringsprocedur som uppfyller [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint-dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

C#‑koden visar en PowerPoint‑till‑PDF‑konverteringsprocess som skapar flera PDF‑filer baserat på olika efterlevnadsstandarder:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides stöder PDF‑konverteringsoperationer, vilket gör att du kan konvertera PDF‑filer till populära filformat. Du kan utföra konverteringar som [PDF till HTML](https://products.aspose.com/slides/sv/net/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/sv/net/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/sv/net/conversion/pdf-to-jpg/) och [PDF till PNG](https://products.aspose.com/slides/sv/net/conversion/pdf-to-png/). Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/sv/net/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/sv/net/conversion/pdf-to-tiff/) och [PDF till XML](https://products.aspose.com/slides/sv/net/conversion/pdf-to-xml/)—stöds också.

{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik som SmartArt, diagram och formler som en enda figur. Enskilda banor bevaras inte som separat innehåll och kan märkas som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **Vanliga frågor**

### Kan jag konvertera flera PowerPoint‑filer till PDF på en gång?

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera igenom dina filer och tillämpa konverteringsprocessen programmässigt.

### Är det möjligt att lösenordsskydda den konverterade PDF‑filen?

Absolut. Använd klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

### Hur inkluderar jag dolda bilder i PDF‑filen?

Ställ in egenskapen `ShowHiddenSlides` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) till `true` för att inkludera dolda bilder i den resulterande PDF‑filen.

### Kan Aspose.Slides behålla hög bildkvalitet i PDF‑filen?

Ja, du kan kontrollera bildkvaliteten genom att ställa in egenskaper som `JpegQuality` och `SufficientResolution` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

### Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller krav på tillgänglighet och arkivering.

## **Ytterligare resurser**

- [Aspose.Slides för .NET-dokumentation](/slides/sv/net/)
- [Aspose.Slides för .NET API‑referens](https://reference.aspose.com/slides/sv/net/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/sv/conversion)