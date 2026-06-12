---
title: API-beperkingen
type: docs
weight: 320
url: /nl/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Leer de limieten van Aspose.Slides for PHP: exporten stellen vaste Application/Producer-metadata in PPT, PPTX, ODP en PDF—zodat u integraties kunt plannen zonder verrassingen."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata weggeschreven naar het uitvoerbestand. Dit artikel legt de beperkingen uit met betrekking tot de `Application`, `Creator` en `Producer`‑metadatavelden in PPTX‑ en PDF‑bestanden.

## **Application en Producer**

Wanneer u presentaties maakt of exporteert met Aspose.Slides for PHP via Java, wordt enige technische metadata in het bestand geschreven. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft aangemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for PHP via Java is deze waarde vast en toont de leverancier van de bibliotheek in plaats van de naam van uw applicatie, zelfs als u [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/setnameofapplication/) gebruikt.

**Producer** identificeert de renderengine die het uiteindelijke bestand tijdens de export heeft gegenereerd. Bij **PDF**‑export wordt metadata gebruikt met de velden **Creator** en **Producer**. Met Aspose.Slides for PHP via Java zijn beide velden vast en weerspiegelen ze de bibliotheek en de versie.

**Wat is beperkt**

U kunt deze velden niet overschrijven via de API voor de bovengenoemde formaten. Voor **PPTX** wordt de Application‑eigenschap geschreven als "Aspose.Slides for PHP via Java". Voor **PDF** worden de Creator‑ en Producer‑eigenschappen geschreven als "Aspose.Slides for PHP via Java x.x.x." Dit gedrag is opzettelijk en is van toepassing, ongeacht hoe u het bestand laadt of opslaat, en ongeacht de waarden die u toewijst met [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/setnameofapplication/).