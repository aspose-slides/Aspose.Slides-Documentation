---
title: Aanpassen van doughnut-diagrammen in presentaties met C++
linktitle: Doughnut-diagram
type: docs
weight: 30
url: /nl/cpp/doughnut-chart/
keywords:
- doughnut-diagram
- centrale opening
- grootte van het gat
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe u doughnut-diagrammen kunt maken en aanpassen in Aspose.Slides voor C++, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe je met een doughnut‑diagram in Aspose.Slides werkt door het diagram aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de methode `set_DoughnutHoleSize` en toont de basisstappen die nodig zijn om dit diagramtype in code aan te passen.

## **Specificeer de centrale opening in een doughnut‑diagram**
Om de grootte van het gat in een doughnut‑diagram op te geven, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
- Voeg een doughnut‑diagram toe aan de dia.
- Geef de grootte van het gat in een doughnut‑diagram op.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grootte van het gat in een doughnut‑diagram ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Kan ik een meerlagige doughnut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één doughnut‑diagram — elke serie wordt een afzonderlijke ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

**Wordt een “exploded” doughnut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/) en een explosie‑eigenschap op datapunt; je kunt individuele segmenten afzonderlijk weergeven.

**Hoe kan ik een afbeelding van een doughnut‑diagram (PNG/SVG) voor een rapport verkrijgen?**

Een diagram is een shape; je kunt het renderen naar een [raster‑afbeelding](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) of het diagram exporteren naar een [SVG‑afbeelding](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/).