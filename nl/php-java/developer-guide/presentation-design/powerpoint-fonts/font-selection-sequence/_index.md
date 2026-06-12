---
title: Lettertype‑selectiereeks in Aspose.Slides voor PHP
linktitle: Lettertype‑selectie
type: docs
weight: 80
url: /nl/php-java/font-selection-sequence/
keywords:
- lettertype selectie
- lettertype substitutie
- lettertype vervanging
- substitutieregel
- beschikbaar lettertype
- ontbrekend lettertype
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor PHP via Java lettertypen selecteert, waardoor PPT, PPTX en ODP‑bestanden scherp en consistent worden weergegeven — verbeter uw dia's nu."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, selecteert Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij datgene ligt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de toepassing, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Bepaalde regels zijn van toepassing op lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (haar dia's) te converteren naar afbeeldingen, worden de lettertypen van de presentatie gecontroleerd om te verifiëren of de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen bevestigend ontbreken, worden ze vervangen — zie [**Font Replacement**](https://docs.aspose.com/slides/nl/php-java/font-replacement/) en [**Font Substitution**](https://docs.aspose.com/slides/nl/php-java/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij wat PowerPoint zou gebruiken ligt. 
3. Als er vervangingsregels voor lettertypen zijn ingesteld via [FontSubstRule](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsubstrule/), worden deze toegepast.

Aspose.Slides stelt u in staat om lettertypen toe te voegen aan de Aspose-runtime en vervolgens die lettertypen te gebruiken. Zie [**Custom fonts**](https://docs.aspose.com/slides/nl/php-java/custom-font/).

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Embedded fonts**](https://docs.aspose.com/slides/nl/php-java/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die *alleen* op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken op uw systeem en ingebedde lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **External fonts**.

## **FAQ**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides stelt u in staat de gebruikte lettertypen te inspecteren via de [font manager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/), zodat u kunt beslissen of u wilt [ingebed](/slides/nl/php-java/embedded-font/), [vervangen](/slides/nl/php-java/font-replacement/), of [externe bronnen](/slides/nl/php-java/custom-font/) wilt toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/php-java/custom-font/) registreren, zoals mappen of in‑memory‑streams, voor renderen en export. Dit verwijdert de afhankelijkheid van lettertypen op het host‑systeem en houdt de lay‑out voorspelbaar.

**Hoe voorkom ik een stille fallback naar een ongeschikt lettertype wanneer een glyf ontbreekt?**

Definieer vooraf expliciete [lettertype‑vervanging](/slides/nl/php-java/font-replacement/) en [fallback‑regels](/slides/nl/php-java/fallback-font/) voor lettertypen. Door de gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, verzekert u consistente typografie en voorkomt u onverwachte resultaten.