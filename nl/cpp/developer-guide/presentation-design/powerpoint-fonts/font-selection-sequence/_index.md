---
title: Lettertype selectievolgorde in Aspose.Slides voor C++
linktitle: Lettertype selectie
type: docs
weight: 80
url: /nl/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor C++ lettertypen selecteert, waardoor PPT, PPTX en ODP-bestanden scherp en consistent worden weergegeven — verbeter uw dia's nu."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, kiest Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype komt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in acht genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingesloten lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype selectie**

Er gelden bepaalde regels voor lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (de dia's) te converteren naar afbeeldingen, worden de lettertypen van de presentatie gecontroleerd om te verifiëren dat de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen als ontbrekend worden bevestigd, worden ze vervangen — zie [**Lettertypevervanging**](https://docs.aspose.com/slides/nl/cpp/font-replacement/) en [**Lettertype‑substitutie**](https://docs.aspose.com/slides/nl/cpp/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het geselecteerde lettertype van de presentatie. 
2. Als het geselecteerde lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij wat PowerPoint zou gebruiken ligt.
3. Als er lettertype‑vervangingsregels zijn ingesteld via [FontSubstRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstrule/), worden ze toegepast. 

Aspose.Slides staat u toe om lettertypen toe te voegen tijdens de uitvoering van de applicatie en vervolgens die lettertypen te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/cpp/custom-font/). 

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Ingesloten lettertypen**](https://docs.aspose.com/slides/nl/cpp/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die alleen op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken op uw systeem en ingesloten lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Opmerking" color="primary" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API staat u toe om externe lettertypen te laden en ze in documenten in te sluiten, maar dit moet u doen met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides laat u de gebruikte lettertypen inspecteren via de [lettertype‑manager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/), zodat u kunt beslissen of u wilt [insluiten](/slides/nl/cpp/embedded-font/), [vervangen](/slides/nl/cpp/font-replacement/), of [externe bronnen](/slides/nl/cpp/custom-font/) toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertypebronnen](/slides/nl/cpp/custom-font/) registreren, zoals mappen of in‑memory‑streams, voor renderen en export. Dit verwijdert de afhankelijkheid van de lettertypen van het host‑systeem en zorgt voor een voorspelbare lay-out.

**Hoe voorkom ik een stille fallback naar een ongeschikt lettertype wanneer een glyph ontbreekt?**

Definieer vooraf expliciete [lettertype‑vervanging](/slides/nl/cpp/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/cpp/fallback-font/). Door gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, garandeert u consistente typografie en voorkomt u onverwachte resultaten.