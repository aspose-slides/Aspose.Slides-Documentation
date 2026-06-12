---
title: API-beperkingen
type: docs
weight: 210
url: /nl/python-net/api-limitations/
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
- Python
- Aspose.Slides
description: "Leer de beperkingen van Aspose.Slides for Python: exporten stellen vaste Application/Producer-metadata in PPT, PPTX, ODP en PDF in — zodat u integraties kunt plannen zonder verrassingen."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata naar het uitvoerbestand geschreven. Dit artikel verklaart de beperkingen met betrekking tot de `Application`, `Creator` en `Producer` metadata‑velden in PPTX‑ en PDF‑bestanden.

## **Applicatie en Producer**

Wanneer u presentaties maakt of exporteert met Aspose.Slides for Python via .NET, wordt enige technische metadata in het bestand geschreven. Twee velden roepen vaak vragen op:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft gemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for Python via .NET is deze waarde vast en toont de leverancier van de bibliotheek in plaats van de naam van uw app, zelfs als u [DocumentProperties.name_of_application](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/name_of_application/) instelt.

**Producer** identificeert de renderengine die het uiteindelijke bestand tijdens de export heeft gegenereerd. Bij **PDF**‑exporten wordt metadata gebruikgemaakt van de velden **Creator** en **Producer**. Met Aspose.Slides for Python via .NET zijn beide vaste waarden die de bibliotheek en de versie weergeven.

**Wat is beperkt**

U kunt deze velden niet overschrijven via de API voor de bovengenoemde formaten. Voor **PPTX** wordt de Application‑eigenschap geschreven als "Aspose.Slides for Python via .NET". Voor **PDF** worden de Creator‑ en Producer‑eigenschappen geschreven als "Aspose.Slides for Python via .NET x.x.x". Dit gedrag is opzettelijk en geldt ongeacht hoe u het bestand laadt of opslaat, en ongeacht de waarden die aan [DocumentProperties.name_of_application](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/name_of_application/) zijn toegekend.