---
title: Beperkingen van outputmetadata
type: docs
weight: 320
url: /nl/net/api-limitations/
keywords:
- API-beperkingen
- exportformaat
- applicatie
- producer
- documenteigenschappen
- metadata
- generator
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET schrijft vaste applicatie-, maker- en producer‑metadata naar opgeslagen PPTX-, PDF- en ODP‑bestanden, ongeacht welke applicatienaam u instelt."
---
## **Overzicht**

Wanneer presentaties worden aangemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata naar het uitvoerbestand geschreven. Dit artikel legt de beperkingen uit met betrekking tot de `Application`, `Creator`, `Producer` en generator‑metadata‑velden in PPTX-, PDF- en ODP‑bestanden.

## **Application en Producer**

Wanneer u presentaties maakt of exporteert met Aspose.Slides for .NET, wordt er technische metadata in het bestand geschreven. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft aangemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for .NET is deze waarde vast en toont de bibliotheeknaam in plaats van de naam van uw applicatie, zelfs als u [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) instelt.

**Producer** identificeert de renderengine die het definitieve bestand tijdens het exporteren heeft gegenereerd. In **PDF**‑exports gebruikt de metadata de velden **Creator** en **Producer**. Met Aspose.Slides for .NET zijn beide velden vast en geven ze de bibliotheek en de versie weer.

**Wat is beperkt**

U kunt deze velden niet overschrijven via de API voor de bovenstaande formaten. Voor **PPTX** wordt de Application‑eigenschap weggeschreven als "Aspose.Slides for .NET". Voor **PDF** worden de Creator‑ en Producer‑eigenschappen weggeschreven als "Aspose.Slides for .NET" gevolgd door de versie van de bibliotheek. Voor **ODP** wordt het generator‑veld weggeschreven als "Aspose.Slides for .NET" gevolgd door de versie van de bibliotheek. Dit gedrag is zo ontworpen en geldt ongeacht hoe u het bestand laadt of opslaat, en ongeacht de waarden die zijn toegewezen aan [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

Deze beperking is niet van toepassing op **PPT**‑bestanden: in een PPT‑bestand wordt de applicatienaam die u instelt in [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) opgeslagen.