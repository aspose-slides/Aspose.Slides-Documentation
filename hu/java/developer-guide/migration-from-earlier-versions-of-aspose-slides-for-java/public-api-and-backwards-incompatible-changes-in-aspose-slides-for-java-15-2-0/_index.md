---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
description: "Tekintse át az Aspose.Slides for Java publikus API frissítéseit és töréspontjait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) osztályt, metódust, tulajdonságot és így tovább, az összes új korlátozást, valamint a bevezetett egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) az Aspose.Slides for Java 15.2.0 API-val kapcsolatban.

{{% /alert %}} {{% alert color="primary" %}} 

Ismert problémák vannak egyes képgolyókkal és WordArt objektumokkal kapcsolatban, amelyeket az Aspose.Slides for Java 15.2.0 javítani fog.

{{% /alert %}} 
## **Publikus API változások**
### **addDataPointForDoughnutSeries metódusok hozzá lettek adva**
Az IChartDataPointCollection.addDataPointForDoughnutSeries() metódus két túlterhelése lett hozzáadva a Donut típusú sorozatok adatpontjainak hozzáadásához.
### **A com.aspose.slides.SmartArtShape osztály örököl a com.aspose.slides.GeometryShape osztálytól**
A com.aspose.slides.SmartArtShape osztály örököl a com.aspose.slides.GeometryShape osztálytól. Ez a változás javítja az Aspose.Slides objektummodellt és új funkciókat ad a SmartArtShape osztályhoz.
### **Az IGradientStopCollection.add(...) és IGradientStopCollection.insert(...) metódusok megváltoztak**
Az IGradientStop add(float position, int presetColor) aláírását az IGradientStop addPresetColor(float position, int presetColor) aláírás váltotta fel.

Az IGradientStopCollection metódus IGradientStop add(float position, SchemeColor schemeColor) aláírását az IGradientStop addSchemeColor(float position, int schemeColor) aláírás váltotta fel.

Az IGradientStopCollection metódus void insert(int index, float position, int presetColor) aláírását a void insertPresetColor(int index, float position, int presetColor) aláírás váltotta fel.

Az IGradientStopCollection metódus void insert(int index, float position, SchemeColor schemeColor) aláírását a void insertSchemeColor(int index, float position, int schemeColor) aláírás váltotta fel.
### **java.awt.Color getAutomaticSeriesColor() metódus hozzá lett adva a com.aspose.slides.IChartSeries-hez**
A getAutomaticSeriesColor() metódus egy automatikus színt ad vissza a sorozathoz a sorozat indexe és a diagram stílusa alapján. Ez a szín alapértelmezés szerint használatos, ha a FillType értéke NotDefined.
 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Metódus a diagram adatpontjának és kategóriájának index szerinti eltávolításához hozzá lett adva**
IChartDataPointCollection.removeAt(int index) metódus hozzá lett adva a diagram adatpontjának index szerinti eltávolításához.
IChartCategoryCollection.removeAt(int index) metódus hozzá lett adva a diagram kategória index szerinti eltávolításához.
### **PptXPptY érték hozzá lett adva a com.aspose.slides.PropertyType felsoroláshoz**
A PptXPptY érték a com.aspose.slides.PropertyType felsoroláshoz lett hozzáadva a sorosítási probléma javítása keretében.