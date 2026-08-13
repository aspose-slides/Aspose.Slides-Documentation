---
title: Lettertype‑selectiesequentie in Aspose.Slides voor .NET
linktitle: Lettertype‑selectie
type: docs
weight: 80
url: /nl/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor .NET lettertypen selecteert, waardoor PPT-, PPTX- en ODP‑bestanden scherp en consistent worden weergegeven — verbeter nu uw dia’s."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, selecteert Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype komt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in overweging genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Er gelden bepaalde regels voor lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (de dia’s) om te zetten naar afbeeldingen, worden de lettertypen van de presentatie gecontroleerd om te verifiëren of de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen als missend worden bevestigd, worden ze vervangen — zie [**Lettertype‑vervanging**](https://docs.aspose.com/slides/nl/net/font-replacement/) en [**Lettertype‑substitutie**](https://docs.aspose.com/slides/nl/net/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype ligt dat PowerPoint zou gebruiken.
3. Als er lettertype‑vervangingsregels zijn ingesteld via [FontSubstRule](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsubstrule/), worden ze toegepast. 

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de applicatie en deze vervolgens te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/net/custom-font/). 

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Ingebedde lettertypen**](https://docs.aspose.com/slides/nl/net/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die alleen op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken in uw systeem en in de ingebedde lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Note" color="info" %}} 
We distribueren geen enkele lettertype, noch betaalde noch gratis. Onze API stelt u in staat om externe lettertypen te laden en deze in documenten in te sluiten, maar u doet dit met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

### Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?

Aspose.Slides stelt u in staat om de gebruikte lettertypen te inspecteren via de [font manager](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/fontsmanager/), zodat u kunt beslissen of u wilt [inbedden](/slides/nl/net/embedded-font/), [vervangen](/slides/nl/net/font-replacement/) of [externe bronnen](/slides/nl/net/custom-font/) wilt toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

### Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?

Ja. U kunt [externe lettertypebronnen](/slides/nl/net/custom-font/) registreren, zoals mappen of in‑memory streams, voor rendering en export. Dit verwijdert de afhankelijkheid van de lettertypen van het host‑systeem en zorgt voor een voorspelbare lay‑out.

### Hoe kan ik voorkomen dat er stilletjes wordt teruggevallen op een ongeschikt lettertype wanneer een glyph ontbreekt?

Definieer expliciete [lettertype‑vervanging](/slides/nl/net/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/net/fallback-font/) vooraf. Door gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en vermijdt u onverwachte resultaten.