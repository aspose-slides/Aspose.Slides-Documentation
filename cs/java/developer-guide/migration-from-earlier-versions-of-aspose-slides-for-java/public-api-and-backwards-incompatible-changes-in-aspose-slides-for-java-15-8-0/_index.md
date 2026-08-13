---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro Java 15.8.0
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
description: "Přehled aktualizací veřejného API a zásadních změn v Aspose.Slides pro Java, které umožní plynulou migraci vašich řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) nebo [odebráno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v rozhraní API Aspose.Slides pro Java 15.8.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Metody getDoughnutHoleSize() a setDoughnutHoleSize(byte) byly přidány do IChartSeries a ChartSeries**
Určuje velikost otvoru v prstencovém grafu.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```