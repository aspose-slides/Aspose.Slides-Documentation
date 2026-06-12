---
title: API-beperkingen
type: docs
weight: 320
url: /nl/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Ken de beperkingen van Aspose.Slides for C++: export stelt vaste Application/Producer-metadata in PPT, PPTX, ODP en PDF in – zodat u integraties kunt plannen zonder verrassingen."
---
## **Overzicht**

Wanneer presentaties worden gemaakt of geëxporteerd met Aspose.Slides, wordt bepaalde technische metadata naar het uitvoerbestand geschreven. Dit artikel legt de beperkingen uit die verband houden met de metadata‑velden `Application`, `Creator` en `Producer` in PPTX‑ en PDF‑bestanden.

## **Application en Producer**

Wanneer u presentaties maakt of exporteert met Aspose.Slides for C++, wordt er wat technische metadata in het bestand geschreven. Twee velden veroorzaken vaak vragen:

**Application** identificeert het programma dat een **PPTX**‑presentatie heeft gemaakt of voor het laatst heeft opgeslagen. In Aspose.Slides for C++ is deze waarde vast en toont de leverancier van de bibliotheek in plaats van uw applicatienaam, zelfs als u [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/nl/cpp/aspose.slides/documentproperties/set_nameofapplication/) gebruikt.

**Producer** identificeert de render‑engine die het uiteindelijke bestand heeft gegenereerd tijdens export. Bij **PDF**‑exporten gebruikt de metadata de velden **Creator** en **Producer**. Met Aspose.Slides for C++ zijn beide velden vast en geven ze de bibliotheek en de versie weer.

**Wat er beperkt is**

U kunt deze velden niet overschrijven via de API voor de bovenstaande formaten. Voor **PPTX** wordt de eigenschap Application geschreven als "Aspose.Slides for C++". Voor **PDF** worden de eigenschappen Creator en Producer geschreven als "Aspose.Slides for C++ x.x.x". Dit gedrag is opzettelijk en geldt ongeacht hoe u het bestand laadt of opslaat, en ongeacht de waarden die via [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/nl/cpp/aspose.slides/documentproperties/set_nameofapplication/) zijn toegewezen.