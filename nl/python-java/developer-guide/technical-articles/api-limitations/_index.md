---
title: API-beperkingen
type: docs
weight: 320
url: /nl/python-java/api-limitations/
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
- Python
- Java
- Aspose.Slides
description: "Leer over de beperkingen van Aspose.Slides for Python via Java: vaste Application-, Creator- en Producer-metadata in PPTX- en PDF-bestanden."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata naar het uitvoerbestand geschreven. Dit artikel legt de beperkingen uit met betrekking tot de metadata‑velden `Application`, `Creator` en `Producer` in PPTX‑ en PDF‑bestanden.

## **Application en Producer**

Wanneer u presentaties maakt of exporteert met Aspose.Slides for Python via Java, wordt er enige technische metadata in het bestand geschreven. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft aangemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for Python via Java is deze waarde vast en toont de leverancier van de bibliotheek in plaats van de naam van uw app, zelfs als u [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#setnameofapplication) gebruikt.

**Producer** identificeert de renderengine die het uiteindelijke bestand tijdens het exporteren heeft gegenereerd. Bij **PDF**‑exporten wordt metadata gebruikgemaakt van de velden **Creator** en **Producer**. Met Aspose.Slides for Python via Java zijn beide velden vast en geven ze de bibliotheek en de versie weer.

**Wat is beperkt**

U kunt deze velden niet overschrijven via de API voor de bovenstaande formaten. Voor **PPTX** wordt de Application‑eigenschap geschreven als “Aspose.Slides for Java”. Voor **PDF** worden de Creator‑ en Producer‑eigenschappen geschreven als “Aspose.Slides for Java x.x.x.” Dit gedrag is opzettelijk en geldt ongeacht hoe u het bestand laadt of opslaat, en ongeacht de waarden die zijn toegewezen met behulp van [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Kan ik de Application‑waarde in een PPTX‑bestand vervangen door de naam van mijn app?**

Nee. De waarde is vast, zelfs als u [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#setnameofapplication) gebruikt.

**Kan ik de Creator‑ en Producer‑velden bij PDF‑exporten overschrijven?**

Nee. Beide velden zijn vast en geven de bibliotheek en de versie weer, ongeacht hoe u de presentatie laadt of opslaat.