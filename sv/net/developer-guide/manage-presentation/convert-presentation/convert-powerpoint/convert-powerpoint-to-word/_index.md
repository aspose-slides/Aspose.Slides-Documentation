---
title: Konvertera PowerPoint-presentationer till Word-dokument i .NET
linktitle: PowerPoint till Word
type: docs
weight: 110
url: /sv/net/convert-powerpoint-to-word/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till Word
- presentation till Word
- bild till Word
- PPT till Word
- PPTX till Word
- PowerPoint till DOCX
- presentation till DOCX
- bild till DOCX
- PPT till DOCX
- PPTX till DOCX
- PowerPoint till DOC
- presentation till DOC
- bild till DOC
- PPT till DOC
- PPTX till DOC
- spara PPT som DOCX
- spara PPTX som DOCX
- exportera PPT till DOCX
- exportera PPTX till DOCX
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint PPT- och PPTX-bilder till redigerbara Word-dokument i C# med Aspose.Slides för .NET, med exakt layout, bilder och formatering bevarade."
---
## **Översikt**

Den här artikeln ger en lösning för utvecklare för att konvertera PowerPoint‑ och OpenDocument‑presentationer till Word‑dokument med hjälp av Aspose.Slides för .NET och Aspose.Words för .NET. Den steg‑för‑steg guide går dig igenom varje steg i konverteringsprocessen.

## **Konvertera en presentation till ett Word-dokument**

Följ instruktionerna nedan för att konvertera en PowerPoint‑ eller OpenDocument‑presentation till ett Word‑dokument:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och ladda en presentationsfil.
2. Instansiera klasserna [Document](https://reference.aspose.com/words/net/aspose.words/document/) och [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) för att skapa ett Word‑dokument.
3. Ställ in sidstorleken för Word‑dokumentet så att den matchar presentationens med egenskapen [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Ställ in marginaler i Word‑dokumentet med hjälp av egenskapen [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Gå igenom alla presentationsbilder med egenskapen [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/).
    - Generera en bild av bilden med metoden `GetImage` från gränssnittet [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/) och spara den till ett minnesström.
    - Lägg till bildfiler i Word‑dokumentet med metoden `InsertImage` från klassen [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Spara Word‑dokumentet till en fil.

Låt oss säga att vi har en presentation "sample.pptx" som ser ut så här:

![PowerPoint presentation](PowerPoint.png)

Följande C#‑kodexempel visar hur man konverterar PowerPoint‑presentationen till ett Word‑dokument:

```cs
// Ladda en presentationsfil.
using var presentation = new Presentation("sample.pptx");

// Skapa Document- och DocumentBuilder-objekt.
var document = new Document();
var builder = new DocumentBuilder(document);

// Ställ in sidstorleken i Word-dokumentet.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Ställ in marginaler i Word-dokumentet.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Gå igenom alla presentationsbilder.
foreach (var slide in presentation.Slides)
{
    // Generera en bild av bilden och spara den till ett minnesström.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Lägg till bildfilen i Word-dokumentet.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Spara Word-dokumentet till en fil.
document.Save("output.docx");
```

Resultatet:

![Word document](Word.png)

{{% alert color="primary" %}} 
Prova vår [**Online PPT to Word Converter**](https://products.aspose.app/slides/sv/conversion/ppt-to-word) för att se vad du kan få genom att konvertera PowerPoint‑ och OpenDocument‑presentationer till Word‑dokument. 
{{% /alert %}}

## **Vanliga frågor**

**Vilka komponenter behöver installeras för att konvertera PowerPoint‑ och OpenDocument‑presentationer till Word‑dokument?**

Du behöver bara lägga till de respektive NuGet‑paketen för [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) och [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) i ditt C#‑projekt. Båda biblioteken fungerar som fristående API:er och det krävs ingen Microsoft Office‑installation.

**Stöds alla PowerPoint‑ och OpenDocument‑presentationformat?**

Aspose.Slides for .NET [stödjer alla presentationsformat](/slides/sv/net/supported-file-formats/), inklusive PPT, PPTX, ODP och andra vanliga filtyper. Detta säkerställer att du kan arbeta med presentationer skapade i olika versioner av Microsoft PowerPoint.