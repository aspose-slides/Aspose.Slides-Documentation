---
title: ODP naar PPTX converteren in .NET
linktitle: ODP naar PPTX
type: docs
weight: 10
url: /nl/net/convert-odp-to-pptx/
keywords:
- OpenDocument converteren
- presentatie converteren
- dia converteren
- ODP converteren
- OpenDocument naar PPTX
- ODP naar PPTX
- ODP opslaan als PPTX
- ODP exporteren naar PPTX
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Converteer ODP naar PPTX met Aspose.Slides voor .NET. Schone C# codevoorbeelden, batchtips en resultaten van hoge kwaliteit—geen PowerPoint nodig."
---
## **Overzicht**

Dit artikel legt uit hoe u een ODP-presentatie naar PPTX-formaat converteert met behulp van Aspose.Slides.

## **ODP naar PPTX Conversie**

Aspose.Slides voor .NET biedt de klasse Presentation die een presentatiebestand vertegenwoordigt. De klasse [**Presentation**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) kan nu ook ODP openen via de Presentation-constructor wanneer het object wordt geïnstantiëerd. Het volgende voorbeeld laat zien hoe u een ODP-presentatie kunt converteren naar een PPTX-presentatie.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Stappen: ODP naar PPTX converteren in C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Stappen: ODP naar PowerPoint converteren in C#</strong></a>

```c#
// Open het ODP-bestand
Presentation pres = new Presentation("AccessOpenDoc.odp");

// De ODP-presentatie opslaan in PPTX-indeling
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Live voorbeeld**

U kunt de webapp [**Aspose.Slides Conversie**](https://products.aspose.app/slides/nl/conversion/) bezoeken, die is gebouwd met **Aspose.Slides API.** De app toont hoe ODP-naar-PPTX-conversie kan worden geïmplementeerd met de Aspose.Slides API.

## **Veelgestelde vragen**

**Moet ik Microsoft PowerPoint of LibreOffice installeren om ODP naar PPTX te converteren?**

Nee. Aspose.Slides werkt zelfstandig en vereist geen externe applicaties om ODP/PPTX te lezen of te schrijven.

**Worden master-dia's, layouts en thema's behouden tijdens de conversie?**

Ja. De bibliotheek maakt gebruik van een volledig presentatie-objectmodel en behoudt de structuur, inclusief master-dia's en layouts, zodat het ontwerp correct blijft na de conversie.

**Kan ik wachtwoord-beveiligde ODP-bestanden converteren?**

Ja. Aspose.Slides ondersteunt het detecteren van bescherming, het openen en werken met [beveiligde presentaties](/slides/nl/net/password-protected-presentation/) (inclusief ODP) wanneer u het wachtwoord opgeeft, evenals het configureren van versleuteling en toegang tot documenteigenschappen.

**Is Aspose.Slides geschikt voor cloud-of REST-gebaseerde conversiediensten?**

Ja. U kunt de lokale bibliotheek in uw eigen backend gebruiken of [Aspose.Slides Cloud](https://products.aspose.cloud/slides/nl/family/) (REST API); beide opties ondersteunen ODP -> PPTX-conversie.