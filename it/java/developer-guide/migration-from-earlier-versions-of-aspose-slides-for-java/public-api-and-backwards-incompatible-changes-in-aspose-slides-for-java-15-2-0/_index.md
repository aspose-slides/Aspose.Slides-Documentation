---
title: API pubblica e modifiche incompatibili retroattive in Aspose.Slides per Java 15.2.0
linktitle: Aspose.Slides per Java 15.2.0
type: docs
weight: 110
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) classi, metodi, proprietà e così via, eventuali nuove restrizioni e le altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introdotte con l'API Aspose.Slides per Java 15.2.0.

{{% /alert %}} {{% alert color="info" %}} 

Sono noti dei problemi con alcuni proiettili immagine e oggetti WordArt che saranno risolti in Aspose.Slides per Java 15.2.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Sono stati aggiunti i metodi addDataPointForDoughnutSeries**
Sono state aggiunte le due versioni sovraccarico del metodo IChartDataPointCollection.addDataPointForDoughnutSeries() per aggiungere punti dati nelle serie di tipo Doughnut.
### **La classe com.aspose.slides.SmartArtShape è stata ereditata dalla classe com.aspose.slides.GeometryShape**
La classe com.aspose.slides.SmartArtShape è stata ereditata dalla classe com.aspose.slides.GeometryShape. Questa modifica migliora il modello oggetto di Aspose.Slides e aggiunge nuove funzionalità alla classe SmartArtShape.
### **I metodi IGradientStopCollection.add(...) e IGradientStopCollection.insert(...) sono stati modificati**
La firma di IGradientStop add(float position, int presetColor) è stata sostituita dalla firma IGradientStop addPresetColor(float position, int presetColor).

La firma del metodo IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) è stata sostituita dalla firma IGradientStop addSchemeColor(float position, int schemeColor).

La firma del metodo IGradientStopCollection void insert(int index, float position, int presetColor) è stata sostituita dalla firma void insertPresetColor(int index, float position, int presetColor).

La firma del metodo IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) è stata sostituita dalla firma void insertSchemeColor(int index, float position, int schemeColor).
### **È stato aggiunto il metodo java.awt.Color getAutomaticSeriesColor() alla classe com.aspose.slides.IChartSeries**
Il metodo getAutomaticSeriesColor() restituisce un colore automatico per la serie basato sull'indice della serie e sullo stile del grafico. Questo colore è utilizzato per impostazione predefinita se FillType è uguale a NotDefined.
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **È stato aggiunto il metodo per rimuovere il punto dati del grafico e la categoria del grafico per indice**
È stato aggiunto il metodo IChartDataPointCollection.removeAt(int index) per rimuovere il punto dati del grafico per il suo indice.
È stato aggiunto il metodo IChartCategoryCollection.removeAt(int index) per rimuovere la categoria del grafico per il suo indice.
### **Il valore PptXPptY è stato aggiunto all'enumerazione com.aspose.slides.PropertyType**
Il valore PptXPptY è stato aggiunto all'enumerazione com.aspose.slides.PropertyType nell'ambito della correzione di un problema di serializzazione.