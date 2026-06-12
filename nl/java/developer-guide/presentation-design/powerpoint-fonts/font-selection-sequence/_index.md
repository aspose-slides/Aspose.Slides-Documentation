---
title: Lettertype-selectiesequentie in Aspose.Slides voor Java
linktitle: Lettertype selectie
type: docs
weight: 80
url: /nl/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Java lettertypen selecteert, waardoor PPT-, PPTX- en ODP-bestanden scherp en consistent worden weergegeven — verbeter nu uw dia's."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de in de presentatie gebruikte lettertypen beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, kiest Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype ligt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingebedde lettertypen uit een presentatie gebruiken of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype selectie**

Bepaalde regels zijn van toepassing op lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u een presentatie (de dia’s) probeert te converteren naar afbeeldingen, worden de lettertypen van de presentatie gecontroleerd om te verifiëren of de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen inderdaad ontbreken, worden ze vervangen — zie [**Lettertypevervanging**](https://docs.aspose.com/slides/nl/java/font-replacement/) en [**Lettertype‑substitutie**](https://docs.aspose.com/slides/nl/java/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het door de presentatie gekozen lettertype. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype ligt dat PowerPoint zou gebruiken.
3. Als er via [FontSubstRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstrule/) vervangingsregels voor lettertypen zijn ingesteld, worden deze toegepast. 

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de applicatie en vervolgens die lettertypen te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/java/custom-font/). 

Wanneer extra lettertypen in een presentatie worden opgenomen, worden ze [**Ingebedde lettertypen**](https://docs.aspose.com/slides/nl/java/embedded-font/) genoemd.

Aspose.Slides maakt het mogelijk om lettertypen toe te voegen die alleen op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken op uw systeem en ingebedde lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Note" color="primary" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API stelt u in staat om externe lettertypen te laden en in documenten in te sluiten, maar u doet dit op eigen risico en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides stelt u in staat de gebruikte lettertypen te onderzoeken via de [font manager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/), zodat u kunt beslissen of u wilt [invoegen](/slides/nl/java/embedded-font/), [vervangen](/slides/nl/java/font-replacement/) of [externe bronnen](/slides/nl/java/custom-font/) toevoegen. Deze mogelijkheid helpt ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/java/custom-font/) registreren, zoals mappen of streams in het geheugen, voor rendering en export. Dit verwijdert de afhankelijkheid van lettertypen op het hostsysteem en houdt de lay‑out voorspelbaar.

**Hoe kan ik een stille fallback naar een ongeschikt lettertype voorkomen wanneer een glyph ontbreekt?**

Definieer vooraf expliciete [lettertypevervanging](/slides/nl/java/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/java/fallback-font/). Door de gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en voorkomt u onverwachte resultaten.