---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.2.0 esetében
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és törő változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes [added](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) osztályt, metódust, tulajdonságot és így tovább, valamint az új korlátozásokat és egyéb [changes](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) amelyeket az Aspose.Slides for Java 15.2.0 API bevezet.
{{% /alert %}} {{% alert color="info" %}} 
Ismertek a problémák néhány képgolyó és WordArt objektummal, amelyeket az Aspose.Slides for Java 15.2.0 javítani fog.
{{% /alert %}} 
## **Nyilvános API-változások**
### **Az addDataPointForDoughnutSeries metódusok hozzá lettek adva**
A IChartDataPointCollection.addDataPointForDoughnutSeries() metódus két túlterhelése hozzá lett adva a Donut típusú sorozatok adatpontjainak hozzáadásához.
### **A com.aspose.slides.SmartArtShape osztály örököl a com.aspose.slides.GeometryShape osztályból**
A com.aspose.slides.SmartArtShape osztály örököl a com.aspose.slides.GeometryShape osztályból. Ez a változás javítja az Aspose.Slides objektummodellt és új funkciókat ad a SmartArtShape osztályhoz.
### **Az IGradientStopCollection.add(...) és IGradientStopCollection.insert(...) metódusok módosultak**
Az IGradientStop add(float position, int presetColor) aláírása helyettesítve lett az IGradientStop addPresetColor(float position, int presetColor) aláírással.
Az IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) metódus aláírása helyettesítve lett az IGradientStop addSchemeColor(float position, int schemeColor) aláírással.
Az IGradientStopCollection void insert(int index, float position, int presetColor) metódus aláírása helyettesítve lett a void insertPresetColor(int index, float position, int presetColor) aláírással.
Az IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) metódus aláírása helyettesítve lett a void insertSchemeColor(int index, float position, int schemeColor) aláírással.
### **A java.awt.Color getAutomaticSeriesColor() metódus hozzá lett adva a com.aspose.slides.IChartSeries-hez**
A getAutomaticSeriesColor() metódus egy automatikus színt ad vissza a sorozathoz, a sorozat indexe és a diagram stílusa alapján. Ez a szín alapértelmezésként használatos, ha a FillType értéke NotDefined.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Metódus a diagram adatpont és a diagram kategória index szerinti eltávolításához hozzá lett adva**
Az IChartDataPointCollection.removeAt(int index) metódus hozzá lett adva a diagram adatpont index szerinti eltávolításához.
Az IChartCategoryCollection.removeAt(int index) metódus hozzá lett adva a diagram kategória index szerinti eltávolításához.
### **A PptXPptY érték hozzá lett adva a com.aspose.slides.PropertyType felsoroláshoz**
A PptXPptY érték a com.aspose.slides.PropertyType felsoroláshoz lett hozzáadva egy sorosítási probléma javítása keretében.