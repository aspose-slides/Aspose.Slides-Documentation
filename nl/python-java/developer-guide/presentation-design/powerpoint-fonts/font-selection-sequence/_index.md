---
title: Lettertype‑selectiesequentie in Aspose.Slides voor Python via Java
linktitle: Lettertype‑selectie
type: docs
weight: 80
url: /nl/python-java/font-selection-sequence/
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
- Python
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Python via Java lettertypen selecteert, zodat PPT-, PPTX- en ODP‑bestanden scherp en consistent worden gepresenteerd—verbeter nu uw dia's."
---
## **Overview**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de in de presentatie gebruikte lettertypen beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, kiest Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype ligt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑vervangingsregels zijn gedefinieerd via [FontSubstRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstrule/), worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Bepaalde regels gelden voor lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u een presentatie (haar dia's) naar afbeeldingen probeert te converteren, worden de lettertypen van de presentatie gecontroleerd om te verifiëren dat de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen als ontbrekend worden bevestigd, worden ze vervangen — zie [Lettertype‑vervanging](/slides/nl/python-java/font-replacement/) en [Lettertype‑substitutie](/slides/nl/python-java/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie.  
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij wat PowerPoint zou gebruiken ligt.  
3. Als lettertype‑vervangingsregels via [FontSubstRule](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsubstrule/) zijn ingesteld, worden ze toegepast.

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de applicatie en deze vervolgens te gebruiken. Zie [Aangepaste lettertypen](/slides/nl/python-java/custom-font/).

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [Ingebedde lettertypen](/slides/nl/python-java/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die *alleen* op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen gebruikt die niet op uw systeem zijn geïnstalleerd en niet in de presentatie zijn ingebed, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**.

{{% alert title="Opmerking" color="info" %}}
Wij distribueren geen lettertypen, noch betaald noch gratis. Onze API stelt u in staat om externe lettertypen te laden en in documenten in te sluiten, maar u doet dit op eigen risico en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides stelt u in staat om de gebruikte lettertypen te inspecteren via de [font manager](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/), zodat u kunt beslissen of u wilt [inbedden](/slides/nl/python-java/embedded-font/), [vervangen](/slides/nl/python-java/font-replacement/), of [externe bronnen](/slides/nl/python-java/custom-font/) toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/python-java/custom-font/) registreren, zoals mappen of in‑memory‑streams, voor rendering en export. Dit verwijdert de afhankelijkheid van host‑systeemlettertypen en houdt de lay‑out voorspelbaar.

**Hoe voorkom ik een stille fallback naar een ongeschikt lettertype wanneer een glyph ontbreekt?**

Definieer vooraf expliciete [lettertype‑vervanging](/slides/nl/python-java/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/python-java/fallback-font/). Door gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, verzekert u consistente typografie en vermijdt u onverwachte resultaten.