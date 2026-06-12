---
title: Lettertypekeuzevolgorde in Aspose.Slides voor С++
linktitle: Lettertypekeuze
type: docs
weight: 80
url: /nl/cpp/font-selection-sequence/
keywords:
- lettertypekeuze
- lettertype-substitutie
- lettertypevervanging
- substitutieregel
- beschikbaar lettertype
- ontbrekend lettertype
- PowerPoint
- OpenDocument
- presentatie
- С++
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor С++ lettertypen selecteert, waardoor PPT, PPTX en ODP bestanden scherp en consistent worden weergegeven—verbeter uw dia's nu."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de lettertypen die in de presentatie worden gebruikt beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, selecteert Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype komt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer lettertype‑substitutieregels zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, embedded lettertypen uit een presentatie gebruiken of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertypekeuze**

Er gelden bepaalde regels voor lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u probeert een presentatie (de dia's) naar afbeeldingen te converteren, worden de lettertypen van de presentatie gecontroleerd om te verifiëren dat de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen ontbreken, worden ze vervangen — zie [**Lettertypevervanging**](https://docs.aspose.com/slides/nl/cpp/font-replacement/) en [**Lettertype‑substitutie**](https://docs.aspose.com/slides/nl/cpp/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt naar lettertypen in het besturingssysteem om het lettertype te vinden dat overeenkomt met het gekozen lettertype van de presentatie. 
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype komt dat PowerPoint zou gebruiken.
3. Als er lettertype‑vervangingsregels zijn ingesteld via [FontSubstRule](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsubstrule/), worden die toegepast. 

Aspose.Slides stelt u in staat lettertypen toe te voegen aan de runtime van de applicatie en die vervolgens te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/cpp/custom-font/). 

Wanneer extra lettertypen binnen een presentatie worden geplaatst, worden ze **Ingesloten lettertypen** genoemd ([**Ingesloten lettertypen**](https://docs.aspose.com/slides/nl/cpp/embedded-font/)).

Aspose.Slides stelt u in staat lettertypen toe te voegen die *alleen* op uitvoerdocumenten worden toegepast. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken op uw systeem en in de presentatie niet zijn ingesloten, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**. 

{{% alert title="Opmerking" color="primary" %}} 
We distribueren geen lettertypen, noch betaalde noch gratis. Onze API stelt u in staat externe lettertypen te laden en in documenten in te sluiten, maar u doet dit met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **Veelgestelde vragen**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk in een presentatie worden gebruikt vóór conversie?**

Aspose.Slides laat u de gebruikte lettertypen inspecteren via de [lettertypebeheer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/), zodat u kunt beslissen of u wilt [inbedden](/slides/nl/cpp/embedded-font/), [vervangen](/slides/nl/cpp/font-replacement/) of extra [externe bronnen](/slides/nl/cpp/custom-font/) toevoegen. Dit helpt ongewenste substituties tijdens rendering en export te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze te installeren op het besturingssysteem?**

Ja. U kunt [externe lettertypebronnen](/slides/nl/cpp/custom-font/) registreren, zoals mappen of in‑memory streams, voor rendering en export. Dit verwijdert de afhankelijkheid van de lettertypen van het host‑systeem en houdt de lay‑out voorspelbaar.

**Hoe voorkom ik een stille fallback naar een ongepast lettertype wanneer een glyph ontbreekt?**

Definieer vooraf expliciete [lettertypevervanging](/slides/nl/cpp/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/cpp/fallback-font/). Door gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en vermijdt u onverwachte resultaten.