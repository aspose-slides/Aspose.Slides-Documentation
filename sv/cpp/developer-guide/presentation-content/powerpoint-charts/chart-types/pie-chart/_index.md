---
title: Anpassa pajdiagram i presentationer med C++
linktitle: Pajdiagram
type: docs
url: /sv/cpp/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar pajdiagram i C++ med Aspose.Slides, exportera till PowerPoint, och förbättra din databerättelse på några sekunder."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära plot-alternativ för Pie of Pie- och Bar of Pie-diagram, och hur man aktiverar automatisk färgläggning av segment för ett standardpajdiagram.

Exemplen fokuserar på praktiska anpassningssteg för diagram, såsom att lägga till ett diagram på en bild, justera serie- och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden, samt spara den uppdaterade presentationen.

## **Sekundära plot‑alternativ för Pie of Pie‑ och Bar of Pie‑diagram**

Aspose.Slides för C++ stöder nu sekundära plot‑alternativ för Pie of Pie‑ eller Bar of Pie‑diagram. I detta avsnitt visar vi med ett exempel hur man specificerar dessa alternativ med Aspose.Slides. För att specificera egenskaperna, följ stegen nedan:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klassobjekt.
1. Lägg till diagram på bilden.
1. Specificera diagrammets sekundära plot‑alternativ.
1. Skriv presentationen till disk.

I exemplet nedan har vi ställt in olika egenskaper för Pie of Pie‑diagrammet.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Ställ in automatiska färger för pajdiagramsegment**

Aspose.Slides för C++ tillhandahåller ett enkelt API för att ställa in automatiska färger för pajdiagramsegment. Exempelkoden tillämpar inställningarna som beskrivs ovan.

1. Skapa en instans av Presentation‑klassen.
1. Öppna den första bilden.
1. Lägg till diagram med standarddata.
1. Ange diagramtitel.
1. Ställ in den första serien på Visa värden.
1. Ställ in indexet för diagrammets datablad.
1. Hämta diagrammets dataark.
1. Ta bort standardgenererade serier och kategorier.
1. Lägg till nya kategorier.
1. Lägg till ny serie.

Skriv den ändrade presentationen till en PPTX‑fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Stöds 'Pie of Pie' och 'Bar of Pie' variationerna?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/) ett sekundärt diagram för pajdiagram, inklusive 'Pie of Pie' och 'Bar of Pie'-typerna.

**Kan jag exportera bara diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [exportera själva diagrammet som en bild](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getimage/) (t.ex. PNG) utan hela presentationen.