---
title: PowerPoint-presentaties converteren naar PDF met notities in .NET
linktitle: PowerPoint naar PDF met notities
type: docs
weight: 50
url: /nl/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PDF
- presentatie naar PDF
- dia naar PDF
- PPT naar PDF
- PPTX naar PDF
- presentatie opslaan als PDF
- PPT opslaan als PDF
- PPTX opslaan als PDF
- PPT exporteren naar PDF
- PPTX exporteren naar PDF
- sprekernotities
- PDF met notities
- .NET
- C#
- Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities met behulp van Aspose.Slides voor .NET. Behoud lay-outs en sprekernotities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leer je hoe je PowerPoint‑presentaties kunt converteren naar PDF‑formaat met spreker­notities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kun je:

- Het conversie‑proces implementeren om PowerPoint‑dia's om te zetten naar PDF‑documenten waarbij de sprekernotities behouden blijven.
- Het gegenereerde PDF aanpassen zodat de sprekernotities worden meegenomen en geformatteerd volgens jouw vereisten.

## **PowerPoint converteren naar PDF met notities**

De `Save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met sprekernotities. Met Aspose.Slides laad je eenvoudig de presentatie, configureer je de lay-outopties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om sprekernotities op te nemen, en sla je het bestand vervolgens op als PDF. Het onderstaande code‑fragment toont hoe je een voorbeeldpresentatie converteert naar een PDF in de notities‑diaweergave.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Configureer de PDF-opties voor het renderen van sprekernotities.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Render sprekernotities onder de dia.
        }
    };

    // Sla de presentatie op als PDF met sprekernotities.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Je wilt misschien de Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken. 
{{% /alert %}}