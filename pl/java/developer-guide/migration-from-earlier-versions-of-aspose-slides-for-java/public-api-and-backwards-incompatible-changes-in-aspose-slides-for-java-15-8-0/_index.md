---
title: Publiczne API i niekompatybilne wstecz zmiany w Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migracja
- dziedziczony kod
- nowoczesny kod
- dziedziczne podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API i zmiany łamiące w Aspose.Slides for Java, aby płynnie migrować swoje rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) lub [usunięte](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Do IChartSeries i ChartSeries dodano metody getDoughnutHoleSize(), setDoughnutHoleSize(byte)**
Określa rozmiar otworu w wykresie pierścieniowym.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```