---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 14.10.0
linktitle: Aspose.Slides voor Java 14.10.0
type: docs
weight: 90
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de publieke API en brekende wijzigingen in Aspose.Slides voor Java om soepel uw PowerPoint PPT, PPTX en ODP presentatiesoplossingen te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een lijst van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) klassen, methoden, eigenschappen enz., eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) die zijn geïntroduceerd met de Aspose.Slides for Java 14.10.0 API.

{{% /alert %}} 
## **Wijzigingen in de publieke API**
### **com.aspose.slides.FieldType.getFooter()‑methode is toegevoegd**
De getFooter()‑methode retourneert het type voettekstveld. Hij is toegevoegd om de mogelijkheid te implementeren velden van dit type te maken en om geldige presentatie‑serialisatie mogelijk te maken.
### **Element com.aspose.slides.ShapeElementFillSource.Own is verwijderd**
Element ShapeElementFillSource.Own is verwijderd omdat het duplicated was. Gebruik ShapeElementFillSource.Shape in plaats van ShapeElementFillSource.Own.
### **Methoden voor grafiekdatapunten en -categorieën verwijderen zijn toegevoegd**
**De volgende methoden, die het mogelijk maken een grafiekdatapunt uit een grafiekdatapuntcollectie te verwijderen, zijn toegevoegd:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**De volgende methode, die het mogelijk maakt een grafiekkategorie uit de bijbehorende collectie te verwijderen, is toegevoegd:**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // verwijderen met ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // verwijderen met ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // verwijderen met ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Verouderde Aspose.Slides.ParagraphFormat‑methoden zijn verwijderd**
De methoden getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() en bijbehorende set‑methoden zijn verwijderd. Ze werden al lang geleden gemarkeerd als verouderd.
### **Onbruikbare en verouderde constructors zijn verwijderd**
De volgende constructors zijn verwijderd:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)