---
title: Converteer PPTX naar PPT in .NET
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/net/convert-pptx-to-ppt/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPTX converteren
- PPTX naar PPT
- PPTX opslaan als PPT
- PPTX exporteren naar PPT
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Converteer eenvoudig PPTX naar PPT met Aspose.Slides voor .NET - zorg voor naadloze compatibiliteit met PowerPoint-formats terwijl u de lay-out en kwaliteit van uw presentatie behoudt."
---
## **Overzicht**

Dit artikel legt uit hoe u een PowerPoint-presentatie in PPTX-formaat kunt omzetten naar PPT-formaat met C#. Het volgende onderwerp wordt behandeld.

- Converteer PPTX naar PPT in C#

## **Converteer PPTX naar PPT in .NET**

Voor voorbeeldcode in C# om PPTX naar PPT te converteren, zie de onderstaande sectie, namelijk [Converteer PPTX naar PPT](#convert-pptx-to-ppt). Het laadt simpelweg het PPTX‑bestand en slaat het op in PPT‑formaat. Door verschillende opslagformaten op te geven, kunt u het PPTX‑bestand ook opslaan in vele andere indelingen, zoals PDF, XPS, ODP, HTML enzovoort, zoals besproken in deze artikelen. 

- [Converteer PPTX naar PDF in .NET](/slides/nl/net/convert-powerpoint-to-pdf/)
- [Converteer PPTX naar XPS in .NET](/slides/nl/net/convert-powerpoint-to-xps/)
- [Converteer PPTX naar HTML in .NET](/slides/nl/net/convert-powerpoint-to-html/)
- [Converteer PPTX naar ODP in .NET](/slides/nl/net/save-presentation/)
- [Converteer PPTX naar PNG in .NET](/slides/nl/net/convert-powerpoint-to-png/)

## **Converteer PPTX naar PPT**
Om een PPTX naar PPT te converteren geeft u eenvoudig de bestandsnaam en het opslagformaat door aan de [**Save**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode van de klasse [**Presentation**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/). Het C#‑codevoorbeeld hieronder converteert een Presentation van PPTX naar PPT met de standaardopties.

```c#
// Maak een Presentation-object aan dat een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation("presentation.pptx");

// Sla de PPTX-presentatie op in PPT-formaat
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **Veelgestelde vragen**

**Blijven alle PPTX‑effecten en -functies behouden bij het opslaan naar het oude PPT‑formaat (97–2003)?**

Niet altijd. Het PPT‑formaat mist enkele nieuwere mogelijkheden (bijv. bepaalde effecten, objecten en gedragingen), waardoor functies tijdens de conversie kunnen worden vereenvoudigd of gerasterd.

**Kan ik alleen geselecteerde dia’s naar PPT converteren in plaats van de volledige presentatie?**

Direct opslaan richt zich op de volledige presentatie. Om specifieke dia’s te converteren, maakt u een nieuwe presentatie met alleen die dia’s en slaat u deze op als PPT; u kunt ook een service/API gebruiken die per‑dia‑conversie‑parameters ondersteunt.

**Worden met wachtwoord beveiligde presentaties ondersteund?**

Ja. U kunt detecteren of een bestand beveiligd is, het met een wachtwoord openen, en tevens [beschermings‑/versleutelingsinstellingen configureren](/slides/nl/net/password-protected-presentation/) voor de opgeslagen PPT.