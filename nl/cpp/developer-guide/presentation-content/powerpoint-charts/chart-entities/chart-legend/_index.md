---
title: "Grafieklegenda's aanpassen in presentaties met C++"
linktitle: "Grafieklegenda"
type: docs
url: /nl/cpp/chart-legend/
keywords:
- "grafieklegenda"
- "legenda positie"
- "lettergrootte"
- "PowerPoint"
- "presentatie"
- "C++"
- "Aspose.Slides"
description: "Pas grafieklegenda's aan met Aspose.Slides voor C++ om PowerPoint‑presentaties te optimaliseren met op maat gemaakte legenda‑opmaak."
---
## **Overzicht**

Aspose.Slides biedt opties om de legenda's van grafieken in PowerPoint‑presentaties aan te passen. In dit artikel wordt getoond hoe je de positie en grootte van een legenda instelt, de lettergrootte voor de volledige legenda bepaalt en opmaak toepast op een afzonderlijk legenda‑item.

Het behandelt ook verschillende verwante zaken in de FAQ, waaronder het gebruik van de niet‑overlappingmodus zodat het plotgebied plaats maakt voor de legenda, het laten afbreken of gebruiken van regeleinden voor lange legendarabels, en het laten overerven van legenda‑opmaak vanuit het themakleurenschema wanneer er geen expliciete tekst‑ en vulinstellingen worden opgegeven.

## **Legenda positionering**
Om de legenda‑eigenschappen in te stellen, volg je de onderstaande stappen:

- Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
- Verkrijg de referentie van de dia.
- Voeg een grafiek toe aan de dia.
- Stel de eigenschappen van de legenda in.
- Schrijf de presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we de positie en grootte van de grafieklegenda ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Lettergrootte van een legenda instellen**
Aspose.Slides voor C++ maakt het mogelijk de lettergrootte van de legenda in te stellen. Volg de onderstaande stappen:

- Instantieer de Presentation‑klasse.
- Maak de standaardgrafiek aan.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Lettergrootte van een individuele legenda instellen**
Aspose.Slides voor C++ maakt het mogelijk de lettergrootte van individuele legenda‑items in te stellen. Volg de onderstaande stappen:

- Instantieer de Presentation‑klasse.
- Maak de standaardgrafiek aan.
- Toegang tot het legenda‑item.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Kan ik de legenda inschakelen zodat de grafiek automatisch ruimte voor de legenda vrijmaakt in plaats van deze te overlappen?**

Ja. Gebruik de niet‑overlappingmodus ([set_Overlay(false)](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/legend/set_overlay/)); in dit geval krimpt het plotgebied zodat er plaats is voor de legenda.

**Kan ik meerregelige legenda‑labels maken?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via newline‑tekens in de seriesnaam.

**Hoe kan ik ervoor zorgen dat de legenda het kleurschema van het themakleurenschema van de presentatie volgt?**

Stel geen expliciete kleuren/vullingen/lettertypen in voor de legenda of de tekst ervan. Ze zullen dan overerven van het thema en correct worden bijgewerkt wanneer het ontwerp verandert.