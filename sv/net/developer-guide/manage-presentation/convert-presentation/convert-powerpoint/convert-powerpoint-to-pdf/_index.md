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
- bilaga
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i .NET med Aspose.Slides, med snabba C#-kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i C# erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layout och formatering av din presentation. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittssubstitutioner, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdatafilen.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och spara sedan presentationen som en PDF med hjälp av metoden [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) exponerar metoden [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET inserter sin API‑information och versionsnummer i utdatafiler. Till exempel, när du konverterar en presentation till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF Producer‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdatafiler.

{{% /alert %}}

Aspose.Slides tillåter dig att konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑erna matchar originalpresentationerna noggrant. Element och attribut återges korrekt i konverteringen, inklusive:

* Bilder
* Textlådor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punktlistor
* Tabeller

## **Konvertera PowerPoint till PDF**

Standardprocessen för PowerPoint‑till‑PDF‑konvertering använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitet.

Följande exempel laddar en presentation och sparar alla synliga bilder till PDF med standardexportinställningarna.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose erbjuder en gratis online‑[**PowerPoint till PDF‑omvandlare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna omvandlare för en levande implementering av proceduren som beskrivs här.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ — egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — som låter dig anpassa den resulterande PDF‑en, låsa PDF‑en med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du ange din föredragna kvalitet för rasterbilder, specificera hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Följande exempel exporterar en presentation till PDF 1.5 med JPEG‑kvalitet satt till 90, bildupplösning satt till 300 DPI, metafiler sparade som PNG och Flate‑textkomprimering.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Automatiskt välja bildkomprimering**

När en presentation innehåller många fotografier eller skärmdumpar kan minskning av den exporterade PDF‑ens storlek göra det lättare att e‑posta eller ladda ner. Sätt [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) till `true` för att automatiskt välja den mest lämpliga komprimeringsalgoritmen för varje bild under PDF‑export.

Följande exempel laddar en befintlig presentation, aktiverar automatisk bildkomprimeringsval och sparar den som ett PDF‑dokument. Alla andra PDF‑exportinställningar behåller sina standardvärden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Detta alternativ väljer en komprimeringsalgoritm för varje bild. Att sänka [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) minskar JPEG‑bildkvaliteten, medan att sänka [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) tillåter att bilder nedskalades till en lägre upplösning, vilket kan minska detaljrikedomen. Att aktivera automatisk komprimeringsval sänker i sig inte dessa inställningar.

Att välja bildkomprimeringsalgoritmer kräver extra bearbetningstid och minne. Storleksreduktionen beror på presentationens bilder och exportinställningar; en fast minskning kan inte garanteras för varje presentation.

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagare också får åtkomst till arbetsbokens data samt kan se bilderna. Sätt [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) till `true` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑en.

Standardvärdet är `false`: OLE‑objektets förhandsgranskningsbild eller ikon renderas på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. Att sätta alternativet till `true` inkluderar dessutom filens data. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagare öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑kalkylblad på PDF‑sidan.

Följande exempel laddar en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken bifogad.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

För att kontrollera resultatet:

1. Öppna den exporterade PDF‑en i en visare som stödjer filbilagor, t.ex. Adobe Acrobat Reader.
2. Öppna visarens **Attachments**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separerad från bilagan.

{{% alert color="info" title="Note" %}}

PDF/A‑standarderna ställer restriktioner på bilagor: PDF/A‑1 förbjuder inbäddade filer, PDF/A‑2 tillåter endast PDF/A‑bilagor, och PDF/A‑3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav enligt standarderna, inte restriktioner specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och demonstrerar inte PDF/A‑export.

{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda egenskapen [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) från klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑en.

Följande exempel exporterar en presentation till PDF, inklusive eventuella dolda bilder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konvertera PowerPoint till ett lösenordsskyddat PDF**

Följande exempel exporterar en presentation till ett PDF som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive högkvalitativ utskrift.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Upptäcka teckensnittssubstitutioner**

Aspose.Slides tillhandahåller egenskapen [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) under klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), vilket gör att du kan upptäcka teckensnittssubstitutioner under konverteringsprocessen från presentation till PDF.

Följande exempel exporterar en presentation till PDF och skriver ut varningar om teckensnittssubstitutioner till konsolen. En varning skrivs endast ut när ett otillgängligt teckensnitt ersätts under export.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}

För mer information om teckensnittssubstitution, se artikeln [Font Substitution](/slides/sv/net/font-substitution/).

{{% /alert %}} 

### **Hantera teckensnitt utan dedikerad fet stil**

En presentation kan använda fet formatering på text även när dess teckensnitt saknar en dedikerad fet stil. Texten kan fortfarande visas fet genom syntetisk fetning, vilket artificiellt förtjockar de vanliga glyferna. När den texten ser för tung ut eller på annat sätt avviker från det avsedda utseendet i PDF, prova att sätta [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) till `true`. Detta alternativ renderar den påverkade texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa teckensnitt. Standardvärdet är `false`.

Exempelpresentationen innehåller två textrutor: en med vanlig text och en med fet formatering applicerad på samma teckensnitt, som saknar dedikerad fet stil. Följande exempel laddar presentationen, aktiverar rasterisering av icke‑stödjade teckensnittsstilar och exporterar den till PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Följande förhandsvisningar visar resultatet med alternativet inaktiverat respektive aktiverat. I det här exemplet har den feta texten tjockare streck när alternativet är inaktiverat. Med alternativet aktiverat är strecken ljusare; den vanliga texten förblir oförändrad. Jämför resultaten innan du väljer inställning för din presentation.

| Alternativ inaktiverat (`false`, standard) | Alternativ aktiverat (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

I detta exempel gör aktivering av alternativet endast den feta texten till en bitmap: den kan inte markeras, kopieras eller sökas som text utan OCR, och dess kanter blir mjukare vid 800 % zoom. Den vanliga texten förblir sökbar. Med alternativet inaktiverat förblir båda strängarna text.

Detta alternativ rasteriserar text som är formaterad som fet när dess teckensnitt saknar dedikerad fet stil. [Font substitution](/slides/sv/net/font-substitution/) väljer istället ett annat teckensnitt när originalet inte finns tillgängligt.

## **Konvertera utvalda bilder från PowerPoint till PDF**

Följande exempel exporterar bilderna 1 och 3 från en presentation till PDF. Bildnumren i denna array är 1‑baserade, och den inmatade presentationen måste innehålla minst tre bilder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Följande exempel kopierar den första bilden från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Den skalar bildinnehållet för att passa och exporterar den enda bilden till PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Konvertera PowerPoint till PDF i bildspårsvisning för anteckningar**

Följande exempel exporterar en presentation till PDF och placerar varje bilds talaranteckningar under bilden. Använd en presentation som innehåller talaranteckningar för att se resultatet.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna C#‑kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑er baserade på olika efterlevnadsstandarder:

```csharp
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

{{% alert color="info" title="Note" %}}

Aspose.Slides stödjer PDF‑konverteringsoperationer och gör det möjligt att konvertera PDF‑filer till populära filformat. Du kan utföra [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) och [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format — [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), och [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — stöds också.

{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplexa grafikobjekt såsom SmartArt, diagram och formler som en enda figur. Enskilda bana‑element bevaras inte som separat innehåll och kan markeras som artefakter; alternativtext tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i batch?**

Ja, Aspose.Slides stödjer batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och applicera konverteringsprocessen programatiskt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑en?**

Ja. Använd klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑en?**

Sätt egenskapen [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) i klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) till `true` för att inkludera dolda bilder i den resulterande PDF‑en.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑en?**

Ja, du kan kontrollera bildkvaliteten genom att sätta egenskaper såsom [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) och [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) i klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF‑er som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets‑ och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides for .NET Documentation](/slides/sv/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)