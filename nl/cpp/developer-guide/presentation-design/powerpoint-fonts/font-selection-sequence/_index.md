---
title: Lettertype-selectiesequentie in Aspose.Slides voor C++
linktitle: Lettertype-selectie
type: docs
weight: 80
url: /nl/cpp/font-selection-sequence/
keywords:
- lettertype-selectie
- lettertype-substitutie
- lettertype-vervanging
- substitutieregel
- beschikbaar lettertype
- ontbrekend lettertype
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor C++ lettertypen selecteert, waardoor PPT-, PPTX- en ODP-bestanden scherp en consistent worden gepresenteerd - verbeter nu uw dia's."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de in de presentatie gebruikte lettertypen beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, kiest Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype ligt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de runtime van de applicatie, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Bepaalde regels zijn van toepassing op lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (de dia’s) om te zetten naar afbeeldingen, worden de lettertypen van de presentatie gecontroleerd om te verifiëren of de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen definitief ontbreken, worden ze vervangen — zie [**Font Replacement**](https://docs.aspose.com/slides/nl/cpp/font-replacement/) en [**Font Substitution**](https://docs.aspose.com/slides/nl/cpp/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij wat PowerPoint zou gebruiken ligt.
3. Als er via [FontSubstRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstrule/) vervangingsregels voor lettertypen zijn ingesteld, worden deze toegepast. 

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de runtime van de applicatie en vervolgens die lettertypen te gebruiken. Zie [**Custom fonts**](https://docs.aspose.com/slides/nl/cpp/custom-font/). 

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Embedded fonts**](https://docs.aspose.com/slides/nl/cpp/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die alleen op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken op uw systeem en ingebedde lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **external fonts**. 

{{% alert title="Note" color="info" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API stelt u in staat om externe lettertypen te laden en in documenten in te sluiten, maar u doet dit met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

### Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?

Aspose.Slides stelt u in staat de gebruikte lettertypen te inspecteren via de [font manager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/), zodat u kunt beslissen of u wilt [embed](/slides/nl/cpp/embedded-font/), [replace](/slides/nl/cpp/font-replacement/) of [external sources](/slides/nl/cpp/custom-font/) wilt toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

### Kan ik extra lettertype‑mappen toevoegen zonder ze op het besturingssysteem te installeren?

Ja. U kunt [external font sources](/slides/nl/cpp/custom-font/) registreren, zoals mappen of in‑memory‑streams, voor renderen en export. Dit verwijdert de afhankelijkheid van de lettertypen van het host‑systeem en houdt de lay‑out voorspelbaar.

### Hoe voorkom ik een stille fallback naar een ongeschikt lettertype wanneer een glyph ontbreekt?

Definieer vooraf expliciete [font replacement](/slides/nl/cpp/font-replacement/) en lettertype‑[fallBack rules](/slides/nl/cpp/fallback-font/). Door de gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en voorkomt u onverwachte resultaten.