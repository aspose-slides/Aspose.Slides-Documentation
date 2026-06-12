---
title: API pubbliche e modifiche incompatibili con versioni precedenti in Aspose.Slides per Java 14.10.0
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introdotte con l'API Aspose.Slides for Java 14.10.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Il metodo com.aspose.slides.FieldType.getFooter() è stato aggiunto**
Il metodo getFooter() restituisce il tipo di campo footer. È stato aggiunto per consentire la creazione di campi di questo tipo e per una corretta serializzazione della presentazione.
### **L'elemento com.aspose.slides.ShapeElementFillSource.Own è stato eliminato**
L'elemento ShapeElementFillSource.Own è stato eliminato in quanto duplicato. Usa ShapeElementFillSource.Shape invece di ShapeElementFillSource.Own.
### **Sono stati aggiunti metodi per la rimozione di punti dati del grafico e di categorie**
**I seguenti metodi, che consentono di rimuovere un punto dati del grafico da una collezione di punti dati del grafico, sono stati aggiunti:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Il seguente metodo, che consente di rimuovere una categoria del grafico dalla collezione contenente, è stato aggiunto:**

IChartCategory.remove()

``` java

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
### **I metodi obsoleti di Aspose.Slides.ParagraphFormat sono stati rimossi**
I metodi getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() e i corrispondenti metodi set sono stati rimossi. Erano stati contrassegnati come obsoleti molto tempo fa.
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