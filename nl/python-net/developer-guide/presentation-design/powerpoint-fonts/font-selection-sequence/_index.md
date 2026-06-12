---
title: Lettertype selectievolgorde in Aspose.Slides voor Python
linktitle: Lettertype selectie
type: docs
weight: 80
url: /nl/python-net/font-selection-sequence/
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
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Python via .NET lettertypen selecteert, waardoor PPT-, PPTX- en ODP‑bestanden scherp en consistent worden weergegeven — verbeter uw dia's nu."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, selecteert Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype komt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingesloten lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype selectie**

Bepaalde regels zijn van toepassing op lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (de dia's) naar afbeeldingen te converteren, worden de lettertypen van de presentatie gecontroleerd om te verifiëren dat de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als wordt bevestigd dat de lettertypen ontbreken, worden ze vervangen — zie [**Lettervervanging**](https://docs.aspose.com/slides/nl/python-net/font-replacement/) en [**Lettertype substitutie**](https://docs.aspose.com/slides/nl/python-net/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij wat PowerPoint zou gebruiken ligt.
3. Als er via [FontSubstRule](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsubstrule/) vervangingsregels voor lettertypen zijn ingesteld, worden deze toegepast. 

Aspose.Slides stelt u in staat lettertypen toe te voegen tijdens de uitvoering van de applicatie en die vervolgens te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/python-net/custom-font/). 

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Ingesloten lettertypen**](https://docs.aspose.com/slides/nl/python-net/embedded-font/) genoemd.

Aspose.Slides stelt u in staat lettertypen toe te voegen die *alleen* op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u naar PDF wilt converteren lettertypen bevat die ontbreken op uw systeem en in de presentatie zijn ingesloten, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Note" color="primary" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API stelt u in staat externe lettertypen te laden en ze in documenten in te sluiten, maar u doet dat met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **Veelgestelde vragen**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides stelt u in staat de gebruikte lettertypen te onderzoeken via de [lettertype‑beheerder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/fonts_manager/), zodat u kunt beslissen of u wilt [insluiten](/slides/nl/python-net/embedded-font/), [vervangen](/slides/nl/python-net/font-replacement/) of [externe bronnen](/slides/nl/python-net/custom-font/) toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/python-net/custom-font/) registreren, zoals mappen of in‑memory streams, voor het renderen en exporteren. Dit verwijdert de afhankelijkheid van de lettertypen van het host‑systeem en houdt de lay‑out voorspelbaar.

**Hoe voorkom ik een stille terugval naar een ongeschikt lettertype wanneer een glyph ontbreekt?**

Definieer vooraf expliciete [lettertype‑vervanging](/slides/nl/python-net/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/python-net/fallback-font/). Door de gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en voorkomt u onverwachte resultaten.