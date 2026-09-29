---
title: Beperkingen van uitvoer‑metadata
type: docs
weight: 320
url: /nl/java/api-limitations/
keywords:
- API-beperkingen
- exportformaat
- applicatie
- producent
- documenteigenschappen
- metadata
- generator
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Aspose.Slides voor Java schrijft vaste applicatie‑, creator‑ en producent‑metadata naar opgeslagen PPTX‑, PDF‑ en ODP‑bestanden, ongeacht de applicatienaam die je instelt."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata in het uitvoerbestand geschreven. Dit artikel legt de beperkingen uit met betrekking tot de metadata‑velden `Application`, `Creator`, `Producer` en generator in PPTX‑, PDF‑ en ODP‑bestanden.

## **Applicatie en Producent**

Wanneer je presentaties maakt of exporteert met Aspose.Slides voor Java, wordt er wat technische metadata in het bestand geschreven. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft aangemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides voor Java is deze waarde vast en toont de bibliotheeknaam in plaats van de naam van jouw applicatie, zelfs wanneer je [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) gebruikt.

**Producer** identificeert de rendering‑engine die het uiteindelijke bestand heeft gegenereerd tijdens het exporteren. Bij **PDF**‑exporten wordt metadata opgeslagen in de velden **Creator** en **Producer**. Met Aspose.Slides voor Java zijn beide velden vast en geven ze de bibliotheek en haar versie weer.

**Wat is beperkt**

Je kunt deze velden niet overschrijven via de API voor de bovengenoemde indelingen. Voor **PPTX** wordt de eigenschap Application geschreven als “Aspose.Slides for Java”. Voor **PDF** worden de eigenschappen Creator en Producer geschreven als “Aspose.Slides for Java” gevolgd door de bibliotheekversie. Voor **ODP** wordt het generator‑veld geschreven als “Aspose.Slides for Java” gevolgd door de bibliotheekversie. Dit gedrag is bewust zo geïmplementeerd en geldt ongeacht hoe je het bestand laadt of opslaat, en ongeacht de waarden die je toekent via [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Deze beperking geldt niet voor **PPT**‑bestanden: in een PPT‑bestand wordt de applicatienaam die je instelt met [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) opgeslagen.