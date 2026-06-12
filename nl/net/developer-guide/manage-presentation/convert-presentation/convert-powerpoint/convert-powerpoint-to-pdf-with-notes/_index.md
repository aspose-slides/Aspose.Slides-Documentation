---
title: Convert PowerPoint Presentaties naar PDF met Notities in .NET
linktitle: PowerPoint naar PDF met Notities
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
  - spreker notities
  - PDF met notities
  - .NET
  - C#
  - Aspose.Slides
description: "Converteer de formaten PPT en PPTX naar PDF met notities met behulp van Aspose.Slides voor .NET. Behoud de lay-outs en spreker-notities voor professionele presentaties."
---
## **Overzicht**

In dit artikel leert u hoe u PowerPoint‑presentaties kunt converteren naar PDF‑formaat met spreker­notities met behulp van Aspose.Slides. Deze gids behandelt de benodigde stappen en biedt code‑voorbeelden om deze taak efficiënt uit te voeren. Aan het einde van dit artikel kunt u:

- Het conversieproces implementeren om PowerPoint‑dia’s om te zetten in PDF‑documenten, waarbij de spreker­notities behouden blijven.
- De uitvoer‑PDF aanpassen zodat de spreker­notities worden opgenomen en opgemaakt volgens uw wensen.

## **PowerPoint naar PDF converteren met notities**

De `Save`‑methode in de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse kan worden gebruikt om een PPT‑ of PPTX‑presentatie te converteren naar een PDF met spreker­notities. Met Aspose.Slides laadt u eenvoudig de presentatie, configureert u de lay‑outopties met behulp van de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/notescommentslayoutingoptions/)‑klasse om spreker­notities op te nemen, en slaat u vervolgens het bestand op als PDF. Het volgende code‑fragment toont hoe u een voorbeeldpresentatie kunt omzetten naar een PDF in de Notities‑diaweergave.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Configureer PDF-opties voor het renderen van spreker-notities.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Render spreker-notities onder de dia.
        }
    };

    // Sla de presentatie op als PDF met spreker-notities.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 

U wilt misschien de Aspose [Online PowerPoint naar PDF Converter](https://products.aspose.app/slides/nl/conversion) bekijken. 

{{% /alert %}}