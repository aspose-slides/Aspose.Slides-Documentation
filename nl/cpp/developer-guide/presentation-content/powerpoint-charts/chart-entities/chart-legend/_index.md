---
title: "Pas diagramlegenda's aan in presentaties met C++"
linktitle: "Diagramlegenda"
type: docs
url: /nl/cpp/chart-legend/
keywords:
- diagramlegenda
- legenda positie
- lettergrootte
- PowerPoint
- presentatie
- С++
- Aspose.Slides
description: "Pas diagramlegenda's aan met Aspose.Slides voor C++ om PowerPoint-presentaties te optimaliseren met op maat gemaakte legenda-opmaak."
---
## **Overzicht**

Aspose.Slides biedt opties om de legenda van een diagram in PowerPoint‑presentaties aan te passen. In dit artikel staat hoe u de positie en grootte van een legenda kunt instellen, de lettergrootte voor de hele legenda kunt bepalen en opmaak kunt toepassen op een afzonderlijk legenda‑item.

Het behandelt ook diverse gerelateerde zaken in de FAQ, waaronder het gebruik van de niet‑overlay‑modus zodat het plot‑gebied ruimte maakt voor de legenda, het toestaan van lange legenda‑labels om te omsluiten of regelbreuken te gebruiken, en het laten overerven van de legenda‑opmaak van het presentatiethema wanneer expliciete tekst‑ en opvulinstellingen niet zijn toegepast.

## **Legenda‑positionering**
Om de legenda‑eigenschappen in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
- Haal de referentie van de dia op.
- Voeg een diagram toe aan de dia.
- Stel de eigenschappen van de legenda in.
- Schrijf de presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we de positie en grootte van de diagramlegenda ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Lettergrootte van een legenda instellen**
Aspose.Slides voor C++ stelt ontwikkelaars in staat de lettergrootte van de legenda in te stellen. Volg de onderstaande stappen:

- Maak een instantie van de Presentatie‑klasse.
- Maak het standaarddiagram aan.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Lettergrootte van een afzonderlijk legenda‑item instellen**
Aspose.Slides voor C++ laat ontwikkelaars de lettergrootte van individuele legenda‑items instellen. Volg de onderstaande stappen:

- Maak een instantie van de Presentatie‑klasse.
- Maak het standaarddiagram aan.
- Benader het legenda‑item.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Kan ik de legenda inschakelen zodat het diagram automatisch ruimte voor de legenda maakt in plaats van deze te overlappen?**

Ja. Gebruik de niet‑overlay‑modus ([set_Overlay(false)](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/legend/set_overlay/)); in dat geval wordt het plot‑gebied verkleind om de legenda te huisvesten.

**Kan ik legenda‑labels met meerdere regels maken?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via nieuweregel‑tekens in de serienaam.

**Hoe laat ik de legenda het kleurenschema van het presentatiethema volgen?**

Stel geen expliciete kleuren/opvullingen/lettertypen in voor de legenda of de tekst ervan. Ze zullen dan overerven van het thema en correct worden bijgewerkt wanneer het ontwerp verandert.