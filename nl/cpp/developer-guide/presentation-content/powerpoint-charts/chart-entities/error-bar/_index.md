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
description: "Leer hoe u foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides voor C++ — optimaliseer datavisualisaties in PowerPoint‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met foutbalken in presentatiediagrammen kunt werken met Aspose.Slides. Het laat zien hoe u foutbalken toevoegt aan een diagramreeks, X‑ en Y‑foutbalkinstellingen configureert en verschillende waardetypen toepast, zoals vaste, percentage‑ en aangepaste waarden.

Het toont ook hoe u aangepaste foutbalkwaarden toewijst aan individuele gegevenspunten in een reeks door de bijbehorende gegevenspuntcollectie te gebruiken. Bovendien bevat het artikel korte opmerkingen over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markers en gegevenslabels, en waar u de gerelateerde API‑referentieklassen en enum‑types kunt vinden.

## **Foutbalken toevoegen**
Aspose.Slides voor C++ biedt een eenvoudige API voor het beheren van foutbalkwaarden. De voorbeeldcode is van toepassing bij het gebruik van een aangepast waardetype. Om een waarde op te geven, gebruikt u de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de **DataPoints**‑collectie van een reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Voeg een bubbeldiagram toe op de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑foutbalkformaat in.
1. Open de eerste diagramreeks en stel het Y‑foutbalkformaat in.
1. Stel de balkwaarden en het formaat in.
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **Aangepaste foutbalken toevoegen**
Aspose.Slides voor C++ biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De voorbeeldcode is van toepassing wanneer de eigenschap **IErrorBarsFormat.ValueType** gelijk is aan **Custom**. Om een waarde op te geven, gebruikt u de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de **DataPoints**‑collectie van een reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Voeg een bubbeldiagram toe op de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑foutbalkformaat in.
1. Open de eerste diagramreeks en stel het Y‑foutbalkformaat in.
1. Open de individuele gegevenspunten van de diagramreeks en stel de foutbalkwaarden in voor een individueel gegevenspunt.
1. Stel de balkwaarden en het formaat in.
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Wat gebeurt er met foutbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van het diagram en behouden tijdens de conversie, samen met de rest van de diagramopmaak, op voorwaarde dat er een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken gecombineerd worden met markers en gegevenslabels?**

Ja. Foutbalken zijn een apart element en zijn compatibel met markers en gegevenslabels; overlappen de elementen, dan moet u mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en enums vinden voor het werken met foutbalken in de API?**

In de API‑referentie: de [ErrorBarsFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/errorbarsformat/)‑klasse en de verwante enums [ErrorBarType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/errorbarvaluetype/).