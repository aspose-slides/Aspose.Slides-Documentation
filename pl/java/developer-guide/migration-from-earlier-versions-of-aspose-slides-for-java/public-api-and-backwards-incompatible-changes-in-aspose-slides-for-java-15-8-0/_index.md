---
title: Publiczne API i zmiany niezgodne wstecz w Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides dla Java 15.8.0
type: docs
weight: 160
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migracja
- kod dziedziczny
- nowoczesny kod
- podejście dziedziczne
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące kompatybilność w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodano](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) lub [usunięto](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) klasy, metody, właściwości i podobne, a także inne zmiany wprowadzone w API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Metody getDoughnutHoleSize(), setDoughnutHoleSize(byte) zostały dodane do IChartSeries i ChartSeries**
Określa rozmiar otworu w wykresie pierścieniowym.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```