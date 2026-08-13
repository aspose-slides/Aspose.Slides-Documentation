---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 14.10.0
linktitle: Aspose.Slides voor Java 14.10.0
type: docs
weight: 90
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de publieke API en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) klassen, methoden, eigenschappen enzovoort, van eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 14.10.0 API.

{{% /alert %}} 
## **Wijzigingen in de publieke API**
### **com.aspose.slides.FieldType.getFooter() methode is toegevoegd**
De methode getFooter() retourneert het voettekst‑veldtype. Deze is toegevoegd om de mogelijkheid te bieden velden van dit type te creëren en voor een geldige serialisatie van presentaties.
### **Element com.aspose.slides.ShapeElementFillSource.Own is verwijderd**
Element ShapeElementFillSource.Own is verwijderd als duplicaat. Gebruik ShapeElementFillSource.Shape in plaats van ShapeElementFillSource.Own.
### **Methoden voor het verwijderen van diagramdatapunten en categorieën zijn toegevoegd**
**De volgende methoden, die het verwijderen van een diagramdatapunt uit een diagramdatapuntcollectie mogelijk maken, zijn toegevoegd:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**De volgende methode, die het verwijderen van een diagramcategorie uit de bijbehorende collectie mogelijk maakt, is toegevoegd:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // verwijder met ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // verwijder met ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // verwijder met ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Obsolete Aspose.Slides.ParagraphFormat‑methoden zijn verwijderd**
De methoden getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() en de bijbehorende set‑methoden zijn verwijderd. Ze waren al lang gemarkeerd als verouderd.
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