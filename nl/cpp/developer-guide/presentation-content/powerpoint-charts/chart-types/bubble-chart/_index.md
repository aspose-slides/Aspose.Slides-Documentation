---
title: Aanpassen van bubbelgrafieken in presentaties met C++
linktitle: Bubbelgrafiek
type: docs
url: /nl/cpp/bubble-chart/
keywords:
- bubbelgrafiek
- bubbelgrootte
- grootteschaling
- grootteweergave
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak en personaliseer krachtige bubbelgrafieken in PowerPoint met Aspose.Slides voor C++ om uw gegevensvisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel laat zien hoe je met bubbelgrafieken werkt in Aspose.Slides. Het behandelt twee specifieke aanpassingsopties: de grootte van de bellen schalen via de `set_BubbleSizeScale`‑methode en de weergave van de waarden voor de belformaat regelen via de `set_BubbleSizeRepresentation`‑methode.

De voorbeelden laten zien hoe je een bubbelgrafiek maakt, de schaal van de grootte aanpast en de weergave van de belformaat omschakelt om breedte te gebruiken. Het artikel bevat ook een korte FAQ‑sectie die de ondersteuning voor het grafiektype “Bubble with 3‑D” verduidelijkt, opmerkt dat praktische limieten van grafieken afhangen van de prestaties en de doel‑PowerPoint‑versie, en uitlegt dat export de weergave van de grafiek behoudt via de renderengine van Aspose.Slides.

## **Schaal van bubbelgrafiekgrootte**
Aspose.Slides voor C++ biedt ondersteuning voor het schalen van de grootte van bubbelgrafieken. In Aspose.Slides voor **C++ IChartSeries.BubbleSizeScale** en **IChartSeriesGroup.BubbleSizeScale** eigenschappen zijn toegevoegd. Hieronder staat een voorbeeld. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Gegevens weergeven als bubbelformaat**
Er is een nieuwe **get_BubbleSizeRepresentation()**‑methode toegevoegd aan de klassen **IChartSeries** en **ChartSeries**. **BubbleSizeRepresentation** geeft aan hoe de waarden voor de bubbelformaat worden weergegeven in de bubbelgrafiek. Mogelijke waarden zijn: **BubbleSizeRepresentationType.Area** en **BubbleSizeRepresentationType.Width**. Dienovereenkomstig is de enum **BubbleSizeRepresentationType** toegevoegd om de mogelijke manieren te specificeren om gegevens weer te geven als bubbelformaat in een grafiek. Hieronder staat de voorbeeldcode.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Wordt een “bubbelgrafiek met 3‑D‑effect” ondersteund, en hoe verschilt die van een gewone?**

Ja. Er bestaat een apart grafiektype, “Bubble with 3‑D”. Het past 3‑D‑styling toe op de bellen, maar voegt geen extra as toe; de gegevens blijven X‑Y‑S (grootte). Het type is beschikbaar in de [chart type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/)‑enumeratie.

**Is er een limiet op het aantal series en punten in een bubbelgrafiek?**

Er is geen harde limiet op API‑niveau; de beperkingen worden bepaald door de prestaties en de doel‑PowerPoint‑versie. Het wordt aanbevolen het aantal punten redelijk te houden voor leesbaarheid en render‑snelheid.

**Hoe beïnvloedt export de weergave van een bubbelgrafiek (PDF, afbeeldingen)?**

Export naar ondersteunde formaten behoudt de weergave van de grafiek; de weergave wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑/vectorformaten gelden de algemene regels voor weergave van grafische elementen (resolutie, anti‑aliasing), dus kies een voldoende DPI voor afdrukken.