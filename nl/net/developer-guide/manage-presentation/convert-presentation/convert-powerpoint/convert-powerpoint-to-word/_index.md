---
title: PowerPoint‑presentaties omzetten naar Word‑documenten in .NET
linktitle: PowerPoint naar Word
type: docs
weight: 110
url: /nl/net/convert-powerpoint-to-word/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar Word
- presentatie naar Word
- dia naar Word
- PPT naar Word
- PPTX naar Word
- PowerPoint naar DOCX
- presentatie naar DOCX
- dia naar DOCX
- PPT naar DOCX
- PPTX naar DOCX
- PowerPoint naar DOC
- presentatie naar DOC
- dia naar DOC
- PPT naar DOC
- PPTX naar DOC
- PPT opslaan als DOCX
- PPTX opslaan als DOCX
- PPT exporteren naar DOCX
- PPTX exporteren naar DOCX
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint PPT‑ en PPTX‑dia’s naar bewerkbare Word‑documenten in C# met Aspose.Slides voor .NET, met behoud van nauwkeurige lay‑out, afbeeldingen en opmaak."
---
## **Overzicht**

Dit artikel biedt een oplossing voor ontwikkelaars om PowerPoint- en OpenDocument‑presentaties om te zetten naar Word‑documenten met behulp van Aspose.Slides voor .NET en Aspose.Words voor .NET. De stapsgewijze handleiding leidt u door elke fase van het conversieproces.

## **Een presentatie converteren naar een Word‑document**

Volg de onderstaande instructies om een PowerPoint‑ of OpenDocument‑presentatie naar een Word‑document te converteren:

1. Instantieer de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) en laad een presentatiebestand.  
2. Instantieer de klassen [Document](https://reference.aspose.com/words/net/aspose.words/document/) en [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) om een Word‑document te genereren.  
3. Stel de paginagrootte van het Word‑document in zodat deze overeenkomt met die van de presentatie met behulp van de eigenschap [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
4. Stel de marges in het Word‑document in met behulp van de eigenschap [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
5. Doorloop alle dia's van de presentatie met de eigenschap [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/):
    - Genereer een dia‑afbeelding met de methode `GetImage` van de interface [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) en sla deze op in een geheugen‑stream.  
    - Voeg de dia‑afbeelding toe aan het Word‑document met de methode `InsertImage` van de klasse [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) .
6. Sla het Word‑document op naar een bestand.

Stel dat we een presentatie “sample.pptx” hebben die er als volgt uitziet:

![PowerPoint‑presentatie](PowerPoint.png)

De volgende C#‑codevoorbeeld toont hoe u de PowerPoint‑presentatie naar een Word‑document kunt converteren:

```cs
// Laad een presentatiebestand.
using var presentation = new Presentation("sample.pptx");

// Maak Document- en DocumentBuilder-objecten aan.
var document = new Document();
var builder = new DocumentBuilder(document);

// Stel de paginagrootte in het Word‑document in.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Stel de marges in het Word‑document in.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Doorloop alle dia's van de presentatie.
foreach (var slide in presentation.Slides)
{
    // Genereer een dia‑afbeelding en sla deze op in een geheugen‑stream.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Voeg de dia‑afbeelding toe aan het Word‑document.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Sla het Word‑document op naar een bestand.
document.Save("output.docx");
```

Het resultaat:

![Word‑document](Word.png)

{{% alert color="primary" %}} 

Probeer onze **Online PPT‑naar‑Word‑converter**[https://products.aspose.app/slides/nl/conversion/ppt-to-word] om te zien wat u kunt winnen door PowerPoint- en OpenDocument‑presentaties naar Word‑documenten te converteren. 

{{% /alert %}}

## **FAQ**

**Welke componenten moeten worden geïnstalleerd om PowerPoint- en OpenDocument‑presentaties naar Word‑documenten te converteren?**

U hoeft alleen de bijbehorende NuGet‑pakketten voor [Aspose.Slides voor .NET](https://www.nuget.org/packages/Aspose.Slides.NET) en [Aspose.Words voor .NET](https://www.nuget.org/packages/Aspose.Words/) toe te voegen aan uw C#‑project. Beide bibliotheken functioneren als zelfstandige API’s, en er is geen vereiste om Microsoft Office te installeren.

**Worden alle PowerPoint- en OpenDocument‑presentatieformaten ondersteund?**

Aspose.Slides voor .NET ondersteunt alle presentatiefomaten, inclusief PPT, PPTX, ODP en andere gangbare bestandstypen. Hierdoor kunt u werken met presentaties die in verschillende versies van Microsoft PowerPoint zijn gemaakt. [/slides/nl/net/supported-file-formats/]