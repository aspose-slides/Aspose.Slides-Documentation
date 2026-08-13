---
title: Lettertype‑selectiesequentie in Aspose.Slides voor Java
linktitle: Lettertype‑selectie
type: docs
weight: 80
url: /nl/java/font-selection-sequence/
keywords:
- lettertype‑selectie
- lettertype‑substitutie
- lettertype‑vervanging
- substitutieregel
- beschikbaar lettertype
- ontbrekend lettertype
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Java lettertypen selecteert, waardoor een scherpe, consistente weergave van PPT-, PPTX- en ODP‑bestanden gegarandeerd is — verbeter nu uw dia's."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, selecteert Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij dat van PowerPoint ligt.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend type toegepast. Wanneer lettertype‑vervangingsregels zijn gedefinieerd via `FontSubstRule`, worden die regels eveneens in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de toepassing, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Bepaalde regels gelden voor lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (de dia's) om te zetten naar afbeeldingen, worden de lettertypen van de presentatie gecontroleerd om te verifiëren dat de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen inderdaad ontbreken, worden ze vervangen — zie [**Lettertype‑vervanging**](https://docs.aspose.com/slides/nl/java/font-replacement/) en [**Lettertype‑substitutie**](https://docs.aspose.com/slides/nl/java/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij dat van PowerPoint ligt.
3. Als lettertype‑vervangingsregels zijn ingesteld via [FontSubstRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstrule/), worden ze toegepast. 

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de toepassing en vervolgens die lettertypen te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/java/custom-font/). 

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Ingebedde lettertypen**](https://docs.aspose.com/slides/nl/java/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die *alleen* op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken op uw systeem en ingebedde lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Note" color="info" %}} 
We distribueren geen lettertypen, noch betaalde noch gratis. Onze API stelt u in staat om externe lettertypen te laden en ze in documenten in te sluiten, maar u doet dit met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

### Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?

Aspose.Slides laat u de gebruikte lettertypen inspecteren via de [lettertype‑manager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/), zodat u kunt beslissen of u wilt [inbedden](/slides/nl/java/embedded-font/), [vervangen](/slides/nl/java/font-replacement/), of [externe bronnen](/slides/nl/java/custom-font/) toevoegen. Dit helpt ongewenste substituties tijdens het renderen en exporteren te voorkomen.

### Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?

Ja. U kunt [externe lettertypebronnen](/slides/nl/java/custom-font/) registreren, zoals mappen of in‑memory‑streams, voor rendering en export. Dit verwijdert de afhankelijkheid van lettertypen van het host‑systeem en houdt de lay-out voorspelbaar.

### Hoe voorkom ik een stille fallback naar een ongeschikt lettertype wanneer een glyf ontbreekt?

Definieer expliciete [lettertype‑vervanging](/slides/nl/java/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/java/fallback-font/) vooraf. Door gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en voorkomt u onverwachte resultaten.