---
title: Lettertype-selectiesequentie in Aspose.Slides voor Android via Java
linktitle: Lettertype-selectie
type: docs
weight: 80
url: /nl/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Android via Java lettertypen selecteert, waardoor PPT-, PPTX- en ODP-bestanden scherp en consistent worden weergegeven — verbeter nu uw dia's."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, selecteert Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype komt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingebedde lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerbestanden zoals PDF‑bestanden.

## **Lettertype selectie**

Bepaalde regels zijn van toepassing op lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (zijn dia's) naar afbeeldingen te converteren, worden de lettertypen van de presentatie gecontroleerd om te verifiëren dat de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen inderdaad ontbreken, worden ze vervangen — zie [**Lettertypevervanging**](https://docs.aspose.com/slides/nl/androidjava/font-replacement/) en [**Lettertype‑substitutie**](https://docs.aspose.com/slides/nl/androidjava/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het door de presentatie gekozen lettertype. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij wat PowerPoint zou gebruiken ligt.
3. Als er lettertype‑vervangingsregels zijn ingesteld via [FontSubstRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsubstrule/), worden ze toegepast.

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de applicatie en vervolgens die lettertypen te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/androidjava/custom-font/).

Wanneer extra lettertypen in een presentatie worden geplaatst, worden ze [**Ingebedde lettertypen**](https://docs.aspose.com/slides/nl/androidjava/embedded-font/) genoemd.

Aspose.Slides stelt u in staat om lettertypen toe te voegen die *alleen* op uitvoerbestanden worden toegepast. Bijvoorbeeld, als een presentatie die u naar PDF wilt converteren lettertypen bevat die ontbreken in uw systeem en ingebedde lettertypen, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Note" color="primary" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API maakt het mogelijk om externe lettertypen te laden en in documenten in te sluiten, maar u doet dit met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **Veelgestelde vragen**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides stelt u in staat de gebruikte lettertypen te inspecteren via de [lettertype‑beheerder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/), zodat u kunt beslissen of u wilt [inbedden](/slides/nl/androidjava/embedded-font/), [vervangen](/slides/nl/androidjava/font-replacement/), of [externe bronnen](/slides/nl/androidjava/custom-font/) wilt toevoegen. Dit helpt u ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/androidjava/custom-font/) registreren, zoals mappen of streams in het geheugen, voor renderen en export. Dit verwijdert de afhankelijkheid van de lettertypen van het host‑systeem en houdt de lay‑out voorspelbaar.

**Hoe voorkom ik een stilzwijgende fallback naar een ongepast lettertype wanneer een glyph ontbreekt?**

Definieer vooraf expliciete [lettertype‑vervanging](/slides/nl/androidjava/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/androidjava/fallback-font/). Door de gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor vervangers in te stellen, zorgt u voor consistente typografie en voorkomt u onverwachte resultaten.