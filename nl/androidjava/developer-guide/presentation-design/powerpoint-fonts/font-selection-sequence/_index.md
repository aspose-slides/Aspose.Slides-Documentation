---
title: Lettertype‑selectiereeks in Aspose.Slides voor Android via Java
linktitle: Lettertype‑selectie
type: docs
weight: 80
url: /nl/androidjava/font-selection-sequence/
keywords:
- lettertype selectie
- lettertype substitutie
- lettertype vervanging
- substitutieregel
- beschikbare lettertype
- ontbrekend lettertype
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Android via Java lettertypen selecteert, waardoor een scherpe, consistente weergave van PPT-, PPTX- en ODP‑bestanden gegarandeerd is — verbeter nu uw dia's."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of omgezet naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, kiest Aspose.Slides een vervangend lettertype dat zoveel mogelijk overeenkomt met het lettertype dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑vervangingsregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoer‑documenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Bepaalde regels gelden voor lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of omgezet naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (zijn dia’s) om te zetten naar afbeeldingen, worden de lettertypen van de presentatie gecontroleerd om te verifiëren of de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen ontbreken, worden ze vervangen — zie [**Lettertype‑vervanging**](https://docs.aspose.com/slides/nl/androidjava/font-replacement/) en [**Lettertype‑substitutie**](https://docs.aspose.com/slides/nl/androidjava/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zoveel mogelijk overeenkomt met wat PowerPoint zou gebruiken.
3. Als er via [FontSubstRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsubstrule/) vervangingsregels voor lettertypen zijn ingesteld, worden deze toegepast.

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de applicatie en deze vervolgens te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/androidjava/custom-font/).

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Ingebedde lettertypen**](https://docs.aspose.com/slides/nl/androidjava/embedded-font/).

Aspose.Slides stelt u in staat om lettertypen toe te voegen die *alleen* op uitvoer‑documenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt omzetten naar PDF lettertypen bevat die ontbreken op uw systeem en in de presentatie niet ingebed zijn, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Opmerking" color="info" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API stelt u in staat om externe lettertypen te laden en in documenten in te sluiten, maar u doet dit op eigen risico en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

### Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?

Aspose.Slides stelt u in staat de gebruikte lettertypen te inspecteren via de [lettertype‑beheerder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/), zodat u kunt beslissen of u wilt [inbedden](/slides/nl/androidjava/embedded-font/), [vervangen](/slides/nl/androidjava/font-replacement/) of [externe bronnen](/slides/nl/androidjava/custom-font/) toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

### Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/androidjava/custom-font/) registreren, zoals mappen of streams in het geheugen, voor renderen en exporteren. Dit verwijdert de afhankelijkheid van lettertypen op het host‑systeem en zorgt voor een voorspelbare lay-out.

### Hoe voorkom ik een stille fallback naar een ongeschikt lettertype wanneer een glyph ontbreekt?

Definieer vooraf expliciete [lettertype‑vervangings](/slides/nl/androidjava/font-replacement/) en [fallback‑regels](/slides/nl/androidjava/fallback-font/). Door de gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, waarborgt u consistente typografie en voorkomt u onverwachte resultaten.