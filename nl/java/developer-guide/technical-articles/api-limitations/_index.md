---
title: API-beperkingen
type: docs
weight: 320
url: /nl/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Ontdek de beperkingen van Aspose.Slides for Java: exporten stellen vaste Application/Producer-metadata in PPT, PPTX, ODP en PDF—zodat u integraties kunt plannen zonder verrassingen."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata weggeschreven naar het uitvoerbestand. Dit artikel legt de beperkingen uit die betrekking hebben op de metadata‑velden `Application`, `Creator` en `Producer` in PPTX‑ en PDF‑bestanden.

## **Application en Producer**

Wanneer je presentaties maakt of exporteert met Aspose.Slides for Java, wordt er wat technische metadata in het bestand geschreven. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft gemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for Java is deze waarde vast en toont de bibliotheekleverancier in plaats van de naam van je eigen applicatie, zelfs als je [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) gebruikt.

**Producer** identificeert de renderengine die het uiteindelijke bestand heeft gegenereerd tijdens het exporteren. Bij **PDF**‑exports wordt metadata gebruikt via de velden **Creator** en **Producer**. Met Aspose.Slides for Java zijn beide velden vast en geven ze de bibliotheek en de versie weer.

**Wat is beperkt**

Je kunt deze velden niet overschrijven via de API voor de bovengenoemde formaten. Voor **PPTX** wordt de Application‑eigenschap weggeschreven als “Aspose.Slides for Java”. Voor **PDF** worden de Creator‑ en Producer‑eigenschappen weggeschreven als “Aspose.Slides for Java x.x.x.” Dit gedrag is opzettelijk en geldt ongeacht hoe je het bestand laadt of opslaat, en ongeacht de waarden die zijn toegewezen met [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).