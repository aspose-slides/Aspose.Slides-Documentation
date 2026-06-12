---
title: API-beperkingen
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
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer de limieten van Aspose.Slides for .NET kennen: exporten stellen vaste Application/Producer-metadata in PPT, PPTX, ODP en PDF in - zodat u integraties kunt plannen zonder verrassingen."
---
## **Overzicht**

Wanneer presentaties worden aangemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata naar het uitvoerbestand geschreven. Dit artikel legt de beperkingen uit met betrekking tot de metadata‑velden `Application`, `Creator` en `Producer` in PPTX‑ en PDF‑bestanden.

## **Application en Producer**

Wanneer u presentaties maakt of exporteert met Aspose.Slides for .NET, wordt enige technische metadata in het bestand geschreven. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft aangemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for .NET is deze waarde vast en toont de leverancier van de bibliotheek in plaats van de naam van uw toepassing, zelfs als u [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/nl/net/aspose.slides/documentproperties/nameofapplication/) instelt.

**Producer** identificeert de rendering‑engine die het uiteindelijke bestand tijdens het exporteren heeft gegenereerd. Bij **PDF**‑exporten gebruikt de metadata de velden **Creator** en **Producer**. Met Aspose.Slides for .NET zijn beide velden vast en geven ze de bibliotheek en de versie weer.

**Wat beperkt is**

U kunt deze velden niet overschrijven via de API voor de hierboven genoemde formaten. Voor **PPTX** wordt de Application‑eigenschap geschreven als "Aspose.Slides for .NET". Voor **PDF** worden de Creator‑ en Producer‑eigenschappen geschreven als "Aspose.Slides for .NET x.x.x". Dit gedrag is opzettelijk en geldt ongeacht hoe u het bestand laadt of opslaat, en ongeacht de waarden die aan [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/nl/net/aspose.slides/documentproperties/nameofapplication/) zijn toegekend.