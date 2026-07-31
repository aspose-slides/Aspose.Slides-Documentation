---
title: Foutbalken aanpassen in presentatiediagrammen met C++
linktitle: Foutbalk
type: docs
url: /nl/cpp/error-bar/
keywords:
- foutbalk
- aangepaste waarde
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides for C++ - optimaliseer datavisualisaties in PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je foutbalken in presentatiediagrammen gebruikt met Aspose.Slides. Het laat zien hoe je foutbalken aan een diagramreeks toevoegt, hoe je X‑ en Y‑foutbalkinstellingen configureert en hoe je verschillende waardetypen toepast, zoals vast, percentage en aangepast.

Het toont ook hoe je aangepaste foutbalkwaarden toewijst aan individuele gegevenspunten in een reeks via de bijbehorende gegevenspuntcollectie. Daarnaast bevat het artikel korte aantekeningen over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markeringen en gegevenslabels, en waar je de gerelateerde API‑referentieklassen en enumeraties kunt vinden.

## **Foutbalken toevoegen**
Aspose.Slides for C++ biedt een eenvoudige API voor het beheren van foutbalkwaarden. De voorbeeldcode is van toepassing bij het gebruik van een aangepaste waardetype. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de **DataPoints**‑collectie van de reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Voeg een bubbeldiagram toe op de gewenste dia.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑X‑formaat in.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑Y‑formaat in.
1. Bepaal de waarden en opmaak van de balken.
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Aangepaste foutbalken toevoegen**
Aspose.Slides for C++ biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De voorbeeldcode is van toepassing wanneer de **IErrorBarsFormat.ValueType**‑eigenschap gelijk is aan **Custom**. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de **DataPoints**‑collectie van de reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Voeg een bubbeldiagram toe op de gewenste dia.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑X‑formaat in.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑Y‑formaat in.
1. Toegang tot de individuele gegevenspunten van de diagramreeks en stel de foutbalkwaarden in voor een individueel gegevenspunt.
1. Bepaal de waarden en opmaak van de balken.
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Wat gebeurt er met foutbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van het diagram en behouden tijdens de conversie samen met de rest van de diagramopmaak, ervan uitgaande dat een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken gecombineerd worden met markeringen en gegevenslabels?**

Ja. Foutbalken zijn een afzonderlijk element en zijn compatibel met markeringen en gegevenslabels; overlappen de elementen, dan moet je mogelijk de opmaak aanpassen.

**Waar vind ik de lijst met eigenschappen en enumeraties voor het werken met foutbalken in de API?**

In de API‑referentie: de klasse [ErrorBarsFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/errorbarsformat/) en de gerelateerde enumeraties [ErrorBarType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/errorbarvaluetype/).