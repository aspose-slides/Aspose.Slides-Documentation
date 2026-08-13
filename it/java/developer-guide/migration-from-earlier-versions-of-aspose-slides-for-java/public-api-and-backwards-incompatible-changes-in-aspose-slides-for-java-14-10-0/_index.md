---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 14.10.0
linktitle: Aspose.Slides per Java 14.10.0
type: docs
weight: 90
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti delle API pubbliche e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) , eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introdotte con l'Aspose.Slides for Java 14.10.0 API.

{{% /alert %}} 
## **Modifiche API pubblica**
### **Il metodo com.aspose.slides.FieldType.getFooter() è stato aggiunto**
Il metodo getFooter() restituisce il tipo di campo piè di pagina. È stato aggiunto per implementare la possibilità di creare campi di questo tipo e per una serializzazione valida della presentazione.
### **L'elemento com.aspose.slides.ShapeElementFillSource.Own è stato eliminato**
L'elemento ShapeElementFillSource.Own è stato eliminato perché duplicato. Usa ShapeElementFillSource.Shape al posto di ShapeElementFillSource.Own.
### **Sono stati aggiunti metodi per la rimozione di punti dati e categorie dei grafici**
**I seguenti metodi, che consentono di rimuovere un punto dati del grafico da una raccolta di punti dati del grafico, sono stati aggiunti:**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**Il seguente metodo, che consente di rimuovere una categoria del grafico dalla raccolta contenente, è stato aggiunto:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // rimuovi con ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // rimuovi con ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // rimuovi con ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()
}

pres.save("presentation.pptx", SaveFormat.Pptx);
```
### **I metodi obsoleti Aspose.Slides.ParagraphFormat sono stati rimossi**
I metodi getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() e i metodi set corrispondenti sono stati rimossi. Erano stati contrassegnati come obsoleti da tempo.
### **Costruttori inutili e obsoleti sono stati rimossi**
I seguenti costruttori sono stati rimossi:

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