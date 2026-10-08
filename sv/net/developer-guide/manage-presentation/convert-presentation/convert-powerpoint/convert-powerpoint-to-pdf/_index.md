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

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i C# erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layout och formatering av din presentation. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittssubstitutioner, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdatafiler.

## **PowerPoint till PDF‑konverteringar**

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som argument till klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och spara sedan presentationen som PDF med metoden [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) exponerar metoden [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides för .NET infogar sin API‑information och versionsnummer i utdokument. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF‑producent‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Observera** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdokument.
{{% /alert %}}

Aspose.Slides gör det möjligt att konvertera:
* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna noggrant matchar originalpresentationerna. Element och attribut återges exakt i konverteringen, inklusive:
* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Följande exempel laddar en presentation och sparar alla synliga bilder till PDF med standardexportinställningarna.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose erbjuder en gratis online [**PowerPoint‑till‑PDF‑omvandlare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar processen för att konvertera en presentation till PDF. Du kan köra ett test med denna omvandlare för en live‑implementering av proceduren som beskrivs här.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ — egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — som tillåter dig att anpassa den resulterande PDF‑filen, låsa PDF‑filen med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

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

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagare får åtkomst till arbetsbokens data samt kan se bilderna. Ställ in [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) till `true` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑filen.

Standardvärdet är `false`: OLE‑objektets förhandsgranskningsbild eller ikon renderas på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. Om alternativet ställs in på `true` inkluderas även filens data. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagare öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑kalkylblad på PDF‑sidan.

Följande exempel laddar en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken bifogad.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

För att kontrollera resultatet:
1. Öppna den exporterade PDF‑filen i en visare som stöder filbilagor, till exempel Adobe Acrobat Reader.
2. Öppna visarens **Bilagor**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Note" %}}
PDF/A‑standarderna påför begränsningar för bilagor: PDF/A‑1 förbjuder inbäddade filer, PDF/A‑2 tillåter endast PDF/A‑bilagor och PDF/A‑3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav enligt standarderna, inte begränsningar specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och demonstrerar inte PDF/A‑export.
{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda egenskapen [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) från klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

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

### **Upptäck teckensnittssubstitutioner**

Aspose.Slides tillhandahåller egenskapen [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) under klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), vilket möjliggör att upptäcka teckensnittssubstitutioner under presentation‑till‑PDF‑konverteringsprocessen.

Följande exempel exporterar en presentation till PDF och skriver ut teckensnittssubstitutionsvarningar till konsolen. En varning skrivs ut endast när ett otillgängligt teckensnitt ersätts under export.

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
För mer information om teckensnittssubstitution, se artikeln [Teckensnittssubstitution](/slides/sv/net/font-substitution/).
{{% /alert %}}

### **Hantera teckensnitt utan en dedikerad fet stil**

En presentation kan tillämpa fet formatering på text även när dess teckensnitt saknar en dedikerad fet stil. Texten kan fortfarande visas fet genom syntetisk fetning, vilket konstgjort förtjockar de vanliga glyferna. När texten ser för tung ut eller på annat sätt avviker från den avsedda utseendet i PDF, försök ställa in [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) till `true`. Detta alternativ renderar den påverkade texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa teckensnitt. Standardvärdet är `false`.

Exempelpresentationen innehåller två textrutor: en med normal text och en med fet formatering applicerad på samma teckensnitt, som saknar dedikerad fet stil. Följande exempel laddar presentationen, aktiverar rasterisering av icke‑stödja teckensnittsstilar och exporterar den till PDF:

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

Följande förhandsvisningar visar resultatet med alternativet inaktiverat och aktiverat. I detta exempel har den feta texten tyngre linjer när alternativet är inaktiverat. När alternativet är aktiverat är linjerna lättare; den normala texten förblir oförändrad. Jämför resultaten innan du väljer inställningen för din presentation.

| Alternativ inaktiverat (`false`, standard) | Alternativ aktiverat (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

I det här exemplet gör aktivering av alternativet endast den feta texten till en bitmap: den kan inte väljas, kopieras eller sökas som text utan OCR, och dess kanter blir mjukare vid 800 % zoom. Den normala texten förblir sökbar. När alternativet är inaktiverat förblir båda strängarna som text.

Detta alternativ rasteriserar text formaterad som fet när dess teckensnitt saknar en dedikerad fet stil. [Teckensnittssubstitution](/slides/sv/net/font-substitution/) väljer istället ett annat teckensnitt när originalet är otillgängligt.

## **Konvertera valda bilder från PowerPoint till PDF**

Följande exempel exporterar bilderna 1 och 3 från en presentation till PDF. Bildnumrering i denna array är en‑baserad, och inmatningspresentationen måste innehålla minst tre bilder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Följande exempel kopierar den första bilden från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Det skalar bildinnehållet för att passa och exporterar den enda bilden till PDF.

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

## **Konvertera PowerPoint till PDF i anteckningsvy för bilder**

Följande exempel exporterar en presentation till PDF och placerar varje bilds talaresanteckningar under bilden. Använd en presentation som innehåller talaresanteckningar för att se resultatet.

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

## **Tillgänglighets‑ och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna C#‑kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserade på olika efterlevnadsstandarder:

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
Aspose.Slides stöder PDF‑konverteringsoperationer, vilket gör det möjligt att konvertera PDF‑filer till populära filformat. Du kan utföra konverteringar som [PDF till HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), och [PDF till PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Andra PDF‑konverteringsoperationer till specialiserade format — [PDF till SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — stöds också.
{{% /alert %}}

**Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda ban‑element bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **Vanliga frågor**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera igenom dina filer och tillämpa konverteringsprocessen programmässigt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑filen?**

Ja. Använd klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑filen?**

Ställ in egenskapen [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) i klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) till `true` för att inkludera dolda bilder i den resulterande PDF‑filen.

**Kan Aspose.Slides bibehålla hög bildkvalitet i PDF‑filen?**

Ja, du kan kontrollera bildkvaliteten genom att ställa in egenskaper som [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) och [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) i klassen [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑standarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets‑ och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides för .NET‑dokumentation](/slides/sv/net/)
- [Aspose.Slides för .NET API‑referens](https://reference.aspose.com/slides/net/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/conversion)