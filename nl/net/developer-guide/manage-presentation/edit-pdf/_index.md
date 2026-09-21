---
title: Bewerk PDF-documenten in .NET
linktitle: Bewerk PDF
type: docs
weight: 65
url: /nl/net/edit-pdf/
keywords:
- bewerk PDF
- vervang PDF-tekst
- PDF naar PPTX
- PPTX naar PDF
- .NET
- C#
- Aspose.Slides
description: "Bewerk PDF-documenten in C# door ze te importeren in Aspose.Slides, tekst te vervangen en de aangepaste presentatie terug op te slaan als PDF."
---
## **Overzicht**

Aspose.Slides for .NET stelt u in staat PDF‑inhoud te bewerken door de pagina’s te importeren als dia’s, de presentatie aan te passen en deze terug te exporteren naar PDF. Dit artikel laat een eenvoudige tekenreeksvervanging zien. De presentatie blijft in het geheugen, dus het opslaan van een tussentijds PPTX‑bestand is optioneel.

## **Tekst vervangen in een PDF**

Gebruik [AddFromPdf](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/addfrompdf/) om de pagina’s te importeren, [ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replacetext/) om de tekst bij te werken, en [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) om het resultaat te exporteren.

Het volgende voorbeeld gaat ervan uit dat `input.pdf` het woord “Draft” bevat als bewerkbare tekst na import. Het vervangt dat woord door “Final” en schrijft `edited.pdf`. Het wissen van de eerste dia vóór import voorkomt een extra lege pagina in de uitvoer. De zoekopdracht zoekt naar volledige woorden met dezelfde hoofdlettergevoeligheid; `null` betekent dat er geen resultcallback nodig is.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Voor meer opties, zie [Zoeken en vervangen van tekst](/slides/nl/net/search-and-replace-text/) en [PowerPoint naar PDF converteren](/slides/nl/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Tekstvervanging werkt op geïmporteerde tekst, niet op tekst binnen gescande afbeeldingen. De conversie kan de lay‑out en opmaak beïnvloeden, dus controleer de uitvoer, vooral wanneer de vervangende tekst langer is dan het origineel.

{{% /alert %}}

## **FAQ**

**Moet ik een PPTX‑bestand opslaan voordat ik de PDF exporteer?**

Nee. U kunt dezelfde presentatie in het geheugen bewerken en exporteren. Sla een PPTX‑kopie alleen op als u deze later ook in PowerPoint wilt blijven bewerken; zie [Save Presentations](/slides/nl/net/save-presentation/).

**Waarom blijft sommige tekst onveranderd?**

Het voorbeeld zoekt naar het volledige woord “Draft” met exacte hoofdlettergevoeligheid. Tekst die als afbeelding is geïmporteerd of over meerdere tekstkaders is verdeeld, komt mogelijk niet overeen met de zoekopdracht. Controleer de geïmporteerde inhoud en pas de zoekopdracht aan voor uw document.