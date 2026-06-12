---
title: OpenDocument-presentaties converteren in .NET
linktitle: OpenDocument converteren
type: docs
weight: 10
url: /nl/net/convert-openoffice-odp/
keywords:
- ODP converteren
- ODP naar afbeelding
- ODP naar GIF
- ODP naar HTML
- ODP naar JPG
- ODP naar MD
- ODP naar PDF
- ODP naar PNG
- ODP naar PPT
- ODP naar PPTX
- ODP naar TIFF
- ODP naar video
- ODP naar Word
- ODP naar XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides voor .NET stelt u in staat ODP eenvoudig te converteren naar PDF, HTML en afbeeldingsformaten. Verhoog de prestaties van uw .NET‑applicaties met snelle en nauwkeurige presentatie‑conversie."
---
## **Inleiding**

[**Aspose.Slides API**](https://products.aspose.com/slides/nl/net/) stelt u in staat OpenDocument-presentaties (ODP) te converteren naar vele formaten (HTML, PDF, TIFF, SWF, XPS, enz.). De API die wordt gebruikt om ODP-bestanden naar andere documentformaten te converteren, is dezelfde als die voor PowerPoint-conversies (PPT en PPTX).

Bijvoorbeeld, als u een ODP-presentatie naar PDF wilt converteren, kunt u dat als volgt doen:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **OpenDocument-presentatie in verschillende toepassingen**

Wanneer een OpenDocument-presentatie (ODP) wordt geopend in PowerPoint, behoudt deze mogelijk niet de oorspronkelijke opmaak van de applicatie waarin ze is gemaakt. Dit komt doordat de OpenDocument-presentatie-app en de PowerPoint-app verschillende functies en weergavegedragingen bieden.

Hier zijn enkele van de verschillen:

- In PowerPoint worden tabellen doorgaans als laatste gerenderd en kunnen ze andere vormen overlappen, ongeacht hun volgorde op de ODP-dia.
- Opvulling met afbeelding voor ODP-tabellen wordt niet ondersteund in PowerPoint.
- Verticale rotatie van tekst (270°, gestapeld) en verdeelde uitlijning worden niet ondersteund in LibreOffice/OpenOffice Impress.
- Opvulling met afbeelding, verloop en patroon voor tekst worden niet ondersteund in LibreOffice/OpenOffice Impress.

MS PowerPoint en LibreOffice/OpenOffice Impress behandelen lijsten ook anders. Een ODP-bestand dat in PowerPoint is gemaakt, wordt mogelijk niet correct weergegeven in LibreOffice/OpenOffice Impress, en omgekeerd.

De afbeelding hieronder toont hoe een lijst er uitziet wanneer deze in LibreOffice Impress is aangemaakt:

![ODP list example](odp-list-example.png)

Aspose.Slides slaat ODP-lijsten op een manier op die ervoor zorgt dat ze correct worden weergegeven in LibreOffice/OpenOffice Impress.

[Meer informatie over het OpenDocument-formaat en PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Veelgestelde vragen**

**Wat gebeurt er als de opmaak van mijn ODP-bestand verandert na conversie?**

ODP en PowerPoint gebruiken verschillende presentatiemodellen, en sommige elementen—zoals tabellen, aangepaste lettertypen of opvulstijlen—kunnen niet exact hetzelfde worden gerenderd. Het wordt aanbevolen de output te controleren en de lay-out of opmaak in de code aan te passen indien nodig.

**Heb ik OpenOffice of LibreOffice nodig om ODP-conversie te gebruiken?**

Nee, Aspose.Slides for .NET is een zelfstandige bibliotheek en vereist geen installatie van OpenOffice of LibreOffice op uw systeem.

**Kan ik het uitvoerformaat aanpassen tijdens ODP-conversie (bijv. PDF-opties instellen)?**

Ja, Aspose.Slides biedt uitgebreide opties voor het aanpassen van de output. Bijvoorbeeld, bij het opslaan als PDF kunt u compressie, beeldkwaliteit, tekstweergave en meer regelen via de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/)‑klasse.

**Is Aspose.Slides geschikt voor server-side of cloud-gebaseerde ODP-verwerking?**

Absoluut. Aspose.Slides for .NET is ontworpen om zowel op desktop- als serveromgevingen te werken, inclusief cloud-platformen zoals Azure, AWS en Docker-containers, zonder enige UI-afhankelijkheid.