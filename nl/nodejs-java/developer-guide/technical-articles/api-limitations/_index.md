---
title: API-beperkingen
type: docs
weight: 320
url: /nl/nodejs-java/api-limitations/
keywords:
- API-beperkingen
- exportformaat
- applicatie
- producent
- documenteigenschappen
- metadata
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer de beperkingen van Aspose.Slides for Node.js: exporten stellen vaste Application/Producer-metadata in PPT, PPTX, ODP en PDF in — zodat u integraties kunt plannen zonder verrassingen."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata naar het uitvoerbestand geschreven. Dit artikel legt de beperkingen uit met betrekking tot de metadata‑velden `Application`, `Creator` en `Producer` in PPTX‑ en PDF‑bestanden.

## **Application en Producer**

Wanneer u presentaties maakt of exporteert met Aspose.Slides for Node.js via Java, wordt een deel van de technische metadata in het bestand opgeslagen. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft gemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for Node.js via Java is deze waarde vast en toont de leveranciersnaam van de bibliotheek in plaats van de naam van uw applicatie, zelfs als u [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) gebruikt.

**Producer** identificeert de renderengine die het uiteindelijke bestand tijdens export heeft gegenereerd. Bij **PDF**‑export wordt metadata opgeslagen in de velden **Creator** en **Producer**. Met Aspose.Slides for Node.js via Java zijn beide velden vast en geven ze de bibliotheek en haar versie weer.

**Wat is beperkt**

U kunt deze velden niet overschrijven via de API voor de bovenstaande formaten. Voor **PPTX** wordt de Application‑eigenschap geschreven als "Aspose.Slides for Node.js via Java". Voor **PDF** worden de Creator‑ en Producer‑eigenschappen geschreven als "Aspose.Slides for Node.js via Java x.x.x." Dit gedrag is opzettelijk en geldt ongeacht hoe u het bestand laadt of opslaat, en ongeacht de waarden die u hebt toegewezen met [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).