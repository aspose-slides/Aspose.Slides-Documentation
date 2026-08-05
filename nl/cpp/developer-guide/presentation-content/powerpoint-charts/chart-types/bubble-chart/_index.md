---
title: "Pas bubbelgrafieken aan in presentaties met C++"
linktitle: "Bubbelgrafiek"
type: docs
url: /nl/cpp/bubble-chart/
keywords:
- "bubbelgrafiek"
- "bubbelformaat"
- "formaat schalen"
- "formaatweergave"
- "PowerPoint"
- "presentatie"
- "C++"
- "Aspose.Slides"
description: "Maak en pas krachtige bubbelgrafieken aan in PowerPoint met Aspose.Slides voor C++ om uw gegevensvisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel laat zien hoe u met bubbelgrafieken werkt in Aspose.Slides. Het behandelt twee specifieke aanpassingsopties: het schalen van bubbelformaten via de `set_BubbleSizeScale`‑methode en het bepalen hoe bubbelformaatwaarden worden weergegeven via de `set_BubbleSizeRepresentation`‑methode.

De voorbeelden demonstreren hoe u een bubbelgrafiek maakt, de schaal van de grootte aanpast, en de weergave van de bubbelformaat wijzigt om de breedte te gebruiken. Het artikel bevat ook een korte FAQ‑sectie die verduidelijkt dat het type “Bubble with 3‑D” wordt ondersteund, opmerkt dat praktische grafieklimieten afhankelijk zijn van prestaties en de doel‑PowerPoint‑versie, en uitlegt dat export de weergave van de grafiek behoudt via de Aspose.Slides‑renderengine.

## **Schaal van bubbelgrafiekgrootte**
Aspose.Slides for C++ biedt ondersteuning voor het schalen van de grootte van bubbelgrafieken. In Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** en **IChartSeriesGroup.BubbleSizeScale** eigenschappen zijn toegevoegd. Hieronder staat een voorbeeld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Gegevens weergeven als bubbelgrafiekgroottes**
Er is een nieuwe **get_BubbleSizeRepresentation()**‑methode toegevoegd aan de **IChartSeries**‑ en **ChartSeries**‑klassen. **BubbleSizeRepresentation** bepaalt hoe de bubbelformaatwaarden worden weergegeven in de bubbelgrafiek. Mogelijke waarden zijn: **BubbleSizeRepresentationType.Area** en **BubbleSizeRepresentationType.Width**. Dienovereenkomstig is de **BubbleSizeRepresentationType**‑enum toegevoegd om de mogelijke manieren te specificeren om gegevens weer te geven als bubbelformaten. Hieronder staat voorbeeldcode.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Wordt een “bubbelgrafiek met 3‑D‑effect” ondersteund, en hoe verschilt deze van een gewone?**

Ja. Er bestaat een apart grafiektype, “Bubble with 3‑D”. Het voegt 3‑D‑styling toe aan de bubbels maar voegt geen extra as toe; de gegevens blijven X‑Y‑S (grootte). Het type is beschikbaar in de [chart type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/)‑enumeratie.

**Is er een limiet op het aantal reeksen en punten in een bubbelgrafiek?**

Er is geen harde limiet op API‑niveau; beperkingen worden bepaald door prestaties en de doel‑PowerPoint‑versie. Het wordt aanbevolen om het aantal punten redelijk te houden voor leesbaarheid en render‑snelheid.

**Hoe beïnvloedt export de weergave van een bubbelgrafiek (PDF, afbeeldingen)?**

Export naar ondersteunde formaten behoudt de weergave van de grafiek; de rendering wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑/vectorformaten gelden de algemene regels voor grafiekrendering (resolutie, anti‑aliasing), dus kies een voldoende DPI voor afdrukken.