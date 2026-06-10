---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.8.0-ban
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és töréspontjait, hogy zökkenőmentesen migreálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) vagy [eltávolított](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for Java 15.8.0 API‑val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **A getDoughnutHoleSize(), setDoughnutHoleSize(byte) metódusok hozzáadva lettek az IChartSeries és ChartSeries típusokhoz**
Meghatározza a lyuk méretét egy gyűrűdiagramon.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```