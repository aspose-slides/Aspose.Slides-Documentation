---
title: Lettertype-selectiesequentie in Aspose.Slides voor Node.js via Java
linktitle: Lettertype-selectie
type: docs
weight: 80
url: /nl/nodejs-java/font-selection-sequence/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Node.js via Java lettertypen selecteert, en zorgt voor een scherpe, consistente weergave van PPT-, PPTX- en ODP-bestanden - verbeter nu uw dia's."
---
## **Overzicht**

Wanneer een presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat, controleert Aspose.Slides of de gebruikte lettertypen beschikbaar zijn in het besturingssysteem. Als een vereist lettertype ontbreekt, kiest Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij het lettertype ligt dat PowerPoint zou gebruiken.

Aspose.Slides zoekt eerst naar het geselecteerde lettertype in het besturingssysteem. Als het lettertype wordt gevonden, wordt het gebruikt. Als het niet wordt gevonden, wordt een geschikt vervangend lettertype toegepast. Wanneer vervangingsregels voor lettertypen zijn gedefinieerd via `FontSubstRule`, worden die regels ook in aanmerking genomen.

U kunt ook lettertypen toevoegen tijdens de uitvoering van de applicatie, ingesloten lettertypen uit een presentatie gebruiken, of externe lettertypen laden voor uitvoerdocumenten zoals PDF‑bestanden.

## **Lettertype‑selectie**

Er gelden bepaalde regels voor lettertypen in een presentatie wanneer de presentatie wordt geladen, gerenderd of geconverteerd naar een ander formaat. Bijvoorbeeld, wanneer u een presentatie (de dia's) naar afbeeldingen probeert te converteren, worden de lettertypen van de presentatie gecontroleerd om te verifiëren dat de gekozen lettertypen beschikbaar zijn in het besturingssysteem. Als de lettertypen als ontbrekend worden aangemerkt, worden ze vervangen — zie [**Lettertypevervanging**](https://docs.aspose.com/slides/nl/nodejs-java/font-replacement/) en [**Lettertypesubstitutie**](https://docs.aspose.com/slides/nl/nodejs-java/font-substitution/).

Dit is het proces dat Aspose.Slides volgt bij het omgaan met lettertypen:

1. Aspose.Slides zoekt in het besturingssysteem naar een lettertype dat overeenkomt met het gekozen lettertype in de presentatie.  
2. Als het gekozen lettertype wordt gevonden, gebruikt Aspose.Slides het. Anders gebruikt Aspose.Slides een vervangend lettertype dat zo dicht mogelijk bij wat PowerPoint zou gebruiken ligt.  
3. Als er vervangingsregels voor lettertypen zijn ingesteld via [FontSubstRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsubstrule/), worden deze toegepast.

Aspose.Slides stelt u in staat om lettertypen toe te voegen tijdens de uitvoering van de applicatie en daarna die lettertypen te gebruiken. Zie [**Aangepaste lettertypen**](https://docs.aspose.com/slides/nl/nodejs-java/custom-font/).

Wanneer extra lettertypen in een presentatie zijn geplaatst, worden ze [**Ingesloten lettertypen**](https://docs.aspose.com/slides/nl/nodejs-java/embedded-font/) genoemd.

Aspose.Slides maakt het mogelijk om lettertypen toe te voegen die *alleen* op uitvoerdocumenten van toepassing zijn. Bijvoorbeeld, als een presentatie die u wilt converteren naar PDF lettertypen bevat die ontbreken op uw systeem en er geen ingesloten lettertypen zijn, kunt u de benodigde lettertypen toevoegen of laden als **externe lettertypen**.

{{% alert title="Opmerking" color="primary" %}} 
We distribueren geen lettertypen, noch betaald noch gratis. Onze API stelt u in staat externe lettertypen te laden en in documenten in te sluiten, maar u doet dit met lettertypen naar eigen inzicht en verantwoordelijkheid.
{{% /alert %}}

## **FAQ**

**Hoe kan ik bepalen welke lettertypen daadwerkelijk worden gebruikt in een presentatie vóór conversie?**

Aspose.Slides biedt de mogelijkheid om de gebruikte lettertypen te inspecteren via de [lettertype‑beheerder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getfontsmanager/), zodat u kunt beslissen of u wilt [insluiten](/slides/nl/nodejs-java/embedded-font/), [vervangen](/slides/nl/nodejs-java/font-replacement/) of extra [bronnen toevoegen](/slides/nl/nodejs-java/custom-font/). Dit helpt ongewenste substituties tijdens het renderen en exporteren te voorkomen.

**Kan ik extra lettertype‑mappen toevoegen zonder ze op het besturingssysteem te installeren?**

Ja. U kunt [externe lettertype‑bronnen](/slides/nl/nodejs-java/custom-font/) registreren, zoals mappen of in‑memory streams, voor renderen en exporteren. Hierdoor vervalt de afhankelijkheid van de host‑systeemlettertypen en blijft de lay‑out voorspelbaar.

**Hoe voorkom ik een stille terugval op een ongeschikt lettertype wanneer een glyph ontbreekt?**

Definieer vooraf expliciete [lettertypevervanging](/slides/nl/nodejs-java/font-replacement/) en lettertype‑[fallback‑regels](/slides/nl/nodejs-java/fallback-font/). Door gebruikte lettertypen te analyseren en een gecontroleerde prioriteit voor substituten in te stellen, zorgt u voor consistente typografie en vermijdt u onverwachte resultaten.