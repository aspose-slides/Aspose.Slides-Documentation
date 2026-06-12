---
title: API-beperkingen
type: docs
weight: 320
url: /nl/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Ken de beperkingen van Aspose.Slides voor Android: exporten stellen vaste Application/Producer-metadata in PPT, PPTX, ODP en PDF—zodat je integraties kunt plannen zonder verrassingen."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata in het uitvoerbestand weggeschreven. Dit artikel legt de beperkingen uit met betrekking tot de metadata‑velden `Application`, `Creator` en `Producer` in PPTX‑ en PDF‑bestanden.

## **Application en Producer**

Wanneer je presentaties maakt of exporteert met Aspose.Slides for Android via Java, wordt er technische metadata in het bestand weggeschreven. Twee velden roepen vaak vragen op:

**Application** geeft aan welk programma de **PPTX**‑presentatie heeft aangemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for Android via Java is deze waarde vast en toont de leverancier van de bibliotheek in plaats van de naam van jouw app, zelfs als je [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) gebruikt.

**Producer** geeft aan welke renderengine het uiteindelijke bestand heeft gegenereerd tijdens het exporteren. Bij **PDF**‑exporten wordt metadata opgeslagen in de velden **Creator** en **Producer**. Met Aspose.Slides for Android via Java zijn beide velden vast en geven ze de bibliotheek en haar versie weer.

**Wat is beperkt**

Je kunt deze velden niet overschrijven via de API voor de bovenstaande formaten. Voor **PPTX** wordt de Application‑eigenschap weggeschreven als "Aspose.Slides for Android via Java". Voor **PDF** worden de Creator‑ en Producer‑eigenschappen weggeschreven als "Aspose.Slides for Android via Java x.x.x." Dit gedrag is volgens ontwerp en geldt ongeacht hoe je het bestand laadt of opslaat, en ongeacht de waarden die je toekent via [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).