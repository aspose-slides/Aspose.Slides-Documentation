---
title: Anpassa cirkeldiagram i presentationer med С++
linktitle: Cirkeldiagram
type: docs
url: /sv/cpp/pie-chart/
keywords:
- cirkeldiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar cirkeldiagram i С++ med Aspose.Slides, exporterat till PowerPoint, och förbättrar din databerättelse på sekunder."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med cirkeldiagram i Aspose.Slides. Den visar hur du konfigurerar sekundära plotalternativ för Pie of Pie- och Bar of Pie-diagram, samt hur du aktiverar automatisk färgläggning av segment för ett standardcirkeldiagram.

Exemplen fokuserar på praktiska steg för anpassning av diagram, såsom att lägga till ett diagram på en bild, justera serie- och etikettinställningar, ersätta standarddiagramdata med egna kategorier och värden, samt spara den uppdaterade presentationen.

## **Sekundära plotalternativ för Pie of Pie- och Bar of Pie-diagram**
Aspose.Slides för C++ stöder nu sekundära plotalternativ för Pie of Pie- eller Bar of Pie-diagram. I detta ämne kommer vi med exempel att visa hur du anger dessa alternativ med Aspose.Slides. Följ stegen nedan:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klassobjekt.
2. Lägg till diagram på bilden.
3. Ange diagrammets sekundära plotalternativ.
4. Skriv presentationen till disk.

I exemplet nedan har vi ställt in olika egenskaper för Pie of Pie-diagrammet.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Ställ in automatiska färger för cirkeldiagramsegment**
Aspose.Slides för C++ erbjuder ett enkelt API för att ange automatiska färger för cirkeldiagramsegment. Exempelkoden tillämpar inställningen av de ovan nämnda egenskaperna.

1. Skapa en instans av Presentation-klassen.
2. Hämta den första bilden.
3. Lägg till diagram med standarddata.
4. Ange diagramtitel.
5. Ställ in den första serien på Visa värden.
6. Ange indexet för diagrammets datasheet.
7. Hämta diagrammets dataarbetsblad.
8. Ta bort standardgenererade serier och kategorier.
9. Lägg till nya kategorier.
10. Lägg till nya serier.

Skriv den modifierade presentationen till en PPTX-fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **Vanliga frågor**

**Stöds variationerna 'Pie of Pie' och 'Bar of Pie'?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/) ett sekundärt plot för cirkeldiagram, inklusive typerna 'Pie of Pie' och 'Bar of Pie'.

**Kan jag exportera endast diagrammet som en bild (till exempel PNG)?**

Ja, du kan [exportera själva diagrammet som en bild](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getimage/) (t.ex. PNG) utan hela presentationen.