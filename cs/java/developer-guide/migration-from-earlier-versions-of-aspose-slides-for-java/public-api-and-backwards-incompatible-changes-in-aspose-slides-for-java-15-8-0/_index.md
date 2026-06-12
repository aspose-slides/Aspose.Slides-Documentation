---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.8.0
linktitle: Aspose.Slides pro Java 15.8.0
type: docs
weight: 160
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a narušující změny v Aspose.Slides pro Java, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}}

Tato stránka uvádí všechny [added](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) nebo [removed](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro Java 15.8.0.

{{% /alert %}}
## **Změny veřejného API**
#### **Metody getDoughnutHoleSize(), setDoughnutHoleSize(byte) byly přidány do IChartSeries a ChartSeries**
Určuje velikost díry v prstencovém grafu.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```