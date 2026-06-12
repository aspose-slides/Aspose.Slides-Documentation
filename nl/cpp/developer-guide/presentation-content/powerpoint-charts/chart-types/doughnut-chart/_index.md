---
title: "Pas donutgrafieken aan in presentaties met С++"
linktitle: "Donutgrafiek"
type: docs
weight: 30
url: /nl/cpp/doughnut-chart/
keywords:
- "donutgrafiek"
- "centrale opening"
- "grootte van het gat"
- "PowerPoint"
- "presentatie"
- "С++"
- "Aspose.Slides"
description: "Ontdek hoe u donutgrafieken kunt maken en aanpassen in Aspose.Slides voor С++, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe u werkt met een donutgrafiek in Aspose.Slides door de grafiek aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de `set_DoughnutHoleSize`‑methode en toont de basisstappen die nodig zijn om dit type grafiek in code aan te passen.

## **Specificeer de centrale opening in een donutgrafiek**
Om de grootte van het gat in een donutgrafiek te specificeren, volgt u de onderstaande stappen:

- Instantieer de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
- Voeg een donutgrafiek toe aan de dia.
- Specificeer de grootte van het gat in de donutgrafiek.
- Sla de presentatie op naar schijf.

In het onderstaande voorbeeld hebben we de grootte van het gat in een donutgrafiek ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Veelgestelde vragen**

**Kan ik een meerlaagse donut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één donutgrafiek — elke serie wordt een afzonderlijke ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

**Wordt een “exploded” donut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/) en een explosie‑eigenschap op datapunten; u kunt individuele segmenten scheiden.

**Hoe kan ik een afbeelding van een donutgrafiek (PNG/SVG) voor een rapport krijgen?**

Een grafiek is een vorm; u kunt deze renderen naar een [raster image](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) of de grafiek exporteren naar een [SVG image](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/).