---
title: Crea o Aggiorna Grafici di Presentazioni PowerPoint su Android
linktitle: Crea o Aggiorna Grafici
type: docs
weight: 10
url: /it/androidjava/create-chart/
keywords:
- aggiungi grafico
- crea grafico
- modifica grafico
- cambia grafico
- aggiorna grafico
- grafico a dispersione
- grafico a torta
- grafico a linee
- grafico a mappa ad albero
- grafico azionario
- grafico a scatola e baffi
- grafico a imbuto
- grafico a raggiera
- grafico istogramma
- grafico radar
- grafico multi-categoria
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea e personalizza grafici nelle presentazioni PowerPoint usando Aspose.Slides per Android. Aggiungi, formatta e modifica i grafici con esempi pratici di codice Java."
---
## **Panoramica**

Questo articolo fornisce una guida completa su come creare e personalizzare i grafici utilizzando Aspose.Slides. Imparerai a aggiungere programmaticamente un grafico a una diapositiva, a popolarlo con dati e a applicare varie opzioni di formattazione per soddisfare i requisiti di progettazione specifici. Durante tutto l’articolo, esempi di codice dettagliati illustrano ogni passaggio, dall’inizializzazione della presentazione e dell’oggetto grafico alla configurazione di serie, assi e legende. Seguendo questa guida, otterrai una solida comprensione di come integrare la generazione dinamica di grafici nelle tue applicazioni, semplificando il processo di creazione di presentazioni basate sui dati.

## **Creare un grafico**
I grafici aiutano le persone a visualizzare rapidamente i dati e a ottenere intuizioni, che potrebbero non essere immediatamente evidenti da una tabella o da un foglio di calcolo. 


**Perché creare grafici?**

Utilizzando i grafici, è possibile

* aggregare, condensare o riassumere grandi quantità di dati in una singola diapositiva di una presentazione
* evidenziare pattern e tendenze nei dati
* dedurre la direzione e la velocità dei dati nel tempo o rispetto a una specifica unità di misura 
* individuare outlier, aberrazioni, deviazioni, errori, dati incongruenti, ecc. 
* comunicare o presentare dati complessi

In PowerPoint puoi creare grafici tramite la funzione di inserimento, che fornisce modelli utilizzati per progettare molti tipi di grafico. Con Aspose.Slides, è possibile creare grafici regolari (basati sui tipi di grafico più popolari) e grafici personalizzati. 

{{% alert color="info" %}} 

Per consentirti di creare grafici, Aspose.Slides fornisce la classe [ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType). I campi di questa classe corrispondono a diversi tipi di grafico.

{{% /alert %}} 

### **Creare grafici normali**

_Passaggi: Creare grafico_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint in Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione in Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint in Java</strong></a>

_Passaggi di codice:_

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con alcuni dati e specificare il tipo di grafico desiderato. 
4. Aggiungere un titolo al grafico. 
5. Accedere al foglio di lavoro dei dati del grafico.
6. Cancellare tutte le serie e le categorie predefinite.
7. Aggiungere nuove serie e categorie.
8. Aggiungere nuovi dati al grafico per le serie.
9. Aggiungere un colore di riempimento per le serie del grafico.
10. Aggiungere etichette per le serie del grafico. 
11. Scrivere la presentazione modificata in un file PPTX.

Questo codice Java mostra come creare un grafico normale:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Aggiunge un grafico con i dati predefiniti
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Imposta il titolo del grafico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Imposta l'indice per il foglio dati del grafico
    int defaultWorksheetIndex = 0;
    
    // Ottiene il foglio di lavoro dei dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina le serie e le categorie generate di default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Aggiunge nuove serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Aggiunge nuove categorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Prende la prima serie del grafico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Ora popola i dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Imposta il colore di riempimento per la serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Prende la seconda serie del grafico
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Popola i dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Imposta il colore di riempimento per la serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Crea etichette personalizzate per ciascuna categoria della nuova serie
    // Imposta la prima etichetta per mostrare il nome della categoria
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Mostra il valore per la terza etichetta
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Salva la presentazione con il grafico
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici a dispersione**
I grafici a dispersione (noti anche come scatter plot o grafici x‑y) sono spesso usati per verificare pattern o dimostrare correlazioni tra due variabili. 

Potresti voler utilizzare un grafico a dispersione quando 

* disponi di dati numerici accoppiati
* hai 2 variabili che si combinano bene
* desideri determinare se 2 variabili sono correlate
* hai una variabile indipendente con più valori per una variabile dipendente

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Passaggi:</em> Creare grafico a dispersione in Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint a dispersione in Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint a dispersione in Java</strong></a>

1. Segui i passaggi indicati in [Creare grafici normali](#creating-normal-charts)
2. Per il terzo passaggio, aggiungi un grafico con alcuni dati e specifica il tuo tipo di grafico come uno dei seguenti
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Rappresenta un grafico a dispersione con marcatori._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Rappresenta un grafico a dispersione collegato da curve, con marcatori dei dati._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Rappresenta un grafico a dispersione collegato da curve, senza marcatori dei dati._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Rappresenta un grafico a dispersione collegato da linee, con marcatori dei dati._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Rappresenta un grafico a dispersione collegato da linee, senza marcatori dei dati._

Questo codice Java mostra come creare grafici a dispersione con diverse serie di marcatori: 

```java
import com.aspose.slides.*;

// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Crea il grafico predefinito
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Ottiene l'indice del foglio dati predefinito del grafico
    int defaultWorksheetIndex = 0;
    
    // Ottiene il foglio dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina le serie di esempio
    chart.getChartData().getSeries().clear();
    
    // Aggiunge nuove serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Prende la prima serie del grafico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Aggiunge un nuovo punto (1:3) alla serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Aggiunge un nuovo punto (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Cambia il tipo di serie
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Cambia il marcatore della serie del grafico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Prende la seconda serie del grafico
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Aggiunge un nuovo punto (5:2) lì
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Aggiunge un nuovo punto (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Aggiunge un nuovo punto (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Aggiunge un nuovo punto (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Cambia il marcatore della serie del grafico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici a torta**

I grafici a torta sono ideali per mostrare la relazione parte‑intero nei dati, soprattutto quando i dati contengono etichette categoriche con valori numerici. Tuttavia, se i tuoi dati contengono molte parti o etichette, potresti considerare l'uso di un grafico a barre.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Passaggi:</em> Creare grafico a torta in Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint a torta in Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint a torta in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato (in questo caso, [ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).Pie).
4. Accedere ai dati del grafico tramite [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Cancellare le serie e le categorie predefinite.
6. Aggiungere nuove serie e categorie.
7. Aggiungere nuovi dati al grafico per le serie.
8. Aggiungere nuovi punti per i grafici e colori personalizzati per le sezioni del grafico a torta.
9. Impostare le etichette per le serie.
10. Impostare le linee guida per le etichette delle serie.
11. Impostare l’angolo di rotazione per le diapositive del grafico a torta.
12. Scrivere la presentazione modificata in un file PPTX

Questo codice Java mostra come creare un grafico a torta:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziates una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Aggiunge un grafico con dati predefiniti
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Imposta il titolo del grafico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Imposta l'indice per il foglio dati del grafico
    int defaultWorksheetIndex = 0;
    
    // Ottiene il foglio dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina le serie e le categorie generate di default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Aggiunge nuove categorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Aggiunge nuove serie
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Popola i dati della serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Non funziona nella nuova versione
    // Aggiunta di nuovi punti e impostazione del colore del settore
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Imposta il bordo del settore
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Imposta il bordo del settore
    point1.getFormat().getLine().setFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Imposta il bordo del settore
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Crea etichette personalizzate per ciascuna delle categorie per la nuova serie
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Mostra le linee guida per il grafico
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Imposta l'angolo di rotazione per i settori del grafico a torta
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Salva la presentazione con un grafico
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici a linee**

I grafici a linee (nota anche come diagrammi a linee) sono ideali in situazioni in cui si desidera mostrare le variazioni di valore nel tempo. Utilizzando un grafico a linee, puoi confrontare molti dati contemporaneamente, tracciare cambiamenti e tendenze nel tempo, evidenziare anomalie nelle serie di dati, ecc.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato (in questo caso, `ChartType.Line`).
1. Scrivere la presentazione modificata in un file PPTX

Questo codice Java mostra come creare un grafico a linee:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Per impostazione predefinita, i punti di un grafico a linee sono collegati da linee continue rette. Se desideri che i punti siano collegati da trattini, puoi specificare il tipo di trattino preferito in questo modo:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici a mappa ad albero**

I grafici a mappa ad albero sono ideali per i dati di vendita quando si vuole mostrare la dimensione relativa delle categorie di dati e, allo stesso tempo, evidenziare rapidamente gli elementi che contribuiscono maggiormente a ciascuna categoria. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Passaggi:</em> Creare grafico a mappa ad albero in Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint a mappa ad albero in Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint a mappa ad albero in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato (in questo caso, [ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Accedere ai dati del grafico tramite [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Cancellare le serie e le categorie predefinite.
6. Aggiungere nuove serie e categorie.
7. Aggiungere nuovi dati al grafico per le serie.
8. Scrivere la presentazione modificata in un file PPTX

Questo codice Java mostra come creare un grafico a mappa ad albero:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ramo 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ramo 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici azionari**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Passaggi:</em> Creare grafico azionario in Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint azionario in Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint azionario in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato ([ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Accedere ai dati del grafico tramite [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Cancellare le serie e le categorie predefinite.
6. Aggiungere nuove serie e categorie.
7. Aggiungere nuovi dati al grafico per le serie.
8. Specificare il formato HiLowLines.
9. Scrivere la presentazione modificata in un file PPTX

Esempio di codice Java per creare un grafico azionario:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));

    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));

    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));

    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici a scatola e baffi**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Passaggi:</em> Creare grafico a scatola e baffi in Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint a scatola e baffi in Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint a scatola e baffi in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato ([ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Accedere ai dati del grafico tramite [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Cancellare le serie e le categorie predefinite.
6. Aggiungere nuove serie e categorie.
7. Aggiungere nuovi dati al grafico per le serie.
8. Scrivere la presentazione modificata in un file PPTX

Questo codice Java mostra come creare un grafico a scatola e baffi:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici a imbuto**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Passaggi:</em> Creare grafico a imbuto in Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint a imbuto in Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint a imbuto in Java</strong></a>


1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato ([ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).Funnel).
4. Scrivere la presentazione modificata in un file PPTX

Il codice Java mostra come creare un grafico a imbuto:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici a raggiera**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Passaggi:</em> Creare grafico a raggiera in Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint a raggiera in Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint a raggiera in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato (in questo caso, [ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).sunburst).
4. Scrivere la presentazione modificata in un file PPTX

Questo codice Java mostra come creare un grafico a raggiera:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ramo 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ramo 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici istogramma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Passaggi:</em> Creare grafico istogramma in Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint istogramma in Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint istogramma in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato ([ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).Histogram).
4. Accedere ai dati del grafico tramite [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Cancellare le serie e le categorie predefinite.
6. Aggiungere nuove serie e categorie.
7. Scrivere la presentazione modificata in un file PPTX

Questo codice Java mostra come creare un grafico istogramma:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Passaggi:</em> Creare grafico radar in Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint radar in Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint radar in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice. 
3. Aggiungere un grafico con alcuni dati e specificare il tipo di grafico desiderato (`ChartType.Radar` in questo caso).
4. Scrivere la presentazione modificata in un file PPTX

Questo codice Java mostra come creare un grafico radar:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici multi‑categoria**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Passaggi:</em> Creare grafico multi‑categoria in Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint multi‑categoria in Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint multi‑categoria in Java</strong></a>

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice. 
3. Aggiungere un grafico con dati predefiniti insieme al tipo desiderato ([ChartType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Accedere ai dati del grafico tramite [IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Cancellare le serie e le categorie predefinite.
6. Aggiungere nuove serie e categorie.
7. Aggiungere nuovi dati al grafico per le serie.
8. Scrivere la presentazione modificata in un file PPTX.

Questo codice Java mostra come creare un grafico multi‑categoria:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Aggiunta delle serie
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Salva la presentazione con il grafico
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici cartografici**

Un grafico cartografico è una visualizzazione di un'area contenente dati. I grafici cartografici sono ideali per confrontare dati o valori tra regioni geografiche.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Passaggi:</em> Creare grafico cartografico in Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Passaggi:</em> Creare grafico PowerPoint cartografico in Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Passaggi:</em> Creare grafico di presentazione PowerPoint cartografico in Java</strong></a>

Questo codice Java mostra come creare un grafico cartografico:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creare grafici combinati**

Un grafico combinato (o grafico combo) combina due o più tipi di grafico in un unico diagramma. Questo grafico consente di evidenziare, confrontare o esaminare le differenze tra due o più set di dati, aiutandoti a identificare le relazioni tra di essi.

![The combination chart](combination_chart.png)

Il seguente codice Java mostra come creare il grafico combinato mostrato sopra in una presentazione PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Imposta il titolo del grafico.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Imposta la legenda del grafico.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Elimina le serie e le categorie generate di default.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Aggiungi nuove categorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Aggiungi la prima serie.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Imposta l'asse orizzontale.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Imposta l'asse verticale.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Imposta il colore delle linee di griglia principali verticali.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Imposta l'asse orizzontale secondario.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Imposta l'asse verticale secondario.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Aggiornare i grafici**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Passaggi:</em> Aggiornare grafico PowerPoint in Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Passaggi:</em> Aggiornare grafico di presentazione in Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Passaggi:</em> Aggiornare grafico di presentazione PowerPoint in Java</strong></a>

1. Istanziare una classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che rappresenta la presentazione contenente il grafico da aggiornare.
2. Ottenere il riferimento a una diapositiva utilizzando il suo indice.
3. Scorrere tutte le forme per trovare il grafico desiderato.
4. Accedere al foglio di lavoro dei dati del grafico.
5. Modificare i dati della serie del grafico cambiando i valori delle serie.
6. Aggiungere una nuova serie e popolare i dati al suo interno.
7. Scrivere la presentazione modificata in un file PPTX.

Questo codice Java mostra come aggiornare un grafico:

```java
import com.aspose.slides.*;

// Apre la presentazione che contiene il grafico da aggiornare
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Ottiene il grafico dalla diapositiva
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Imposta l'indice del foglio dati del grafico
    int defaultWorksheetIndex = 0;

    // Ottiene il foglio di lavoro dei dati del grafico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Modifica il nome della categoria del grafico
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Prende la prima serie del grafico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Aggiornamento dei dati della serie
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modificando il nome della serie
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Prende la seconda serie del grafico
    series = chart.getChartData().getSeries().get_Item(1);

    // Aggiornamento dei dati della serie
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modificando il nome della serie
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Ora, aggiungendo una nuova serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Prende la terza serie del grafico
    series = chart.getChartData().getSeries().get_Item(2);

    // Popolamento dei dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Salva la presentazione con il grafico
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare l'intervallo dati per un grafico**

Per impostare l'intervallo dati per un grafico, procedi così:

1. Istanziare una classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che rappresenta la presentazione contenente il grafico.
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Scorrere tutte le forme per trovare il grafico desiderato.
4. Accedere ai dati del grafico e impostare l’intervallo.
5. Salvare la presentazione modificata in un file PPTX.

Questo codice Java mostra come impostare l'intervallo dati per un grafico:

```java
import com.aspose.slides.*;

// Apre la presentazione che contiene il grafico
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Utilizzare marcatori predefiniti nei grafici**
Quando utilizzi un marcatore predefinito nei grafici, ogni serie del grafico ottiene automaticamente simboli di marcatore diversi.

Questo codice Java mostra come impostare automaticamente un marcatore per la serie del grafico:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Prendi la seconda serie del grafico
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Ora popolando i dati della serie
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Quali tipi di grafico sono supportati da Aspose.Slides?

Aspose.Slides supporta un'ampia gamma di [tipi di grafico](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/charttype/), inclusi barre, linee, torta, area, dispersione, istogramma, radar e molti altri. Questa flessibilità ti consente di scegliere il tipo di grafico più appropriato per le tue esigenze di visualizzazione dei dati.

### Come posso aggiungere un nuovo grafico a una diapositiva?

Per aggiungere un grafico, prima crei un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) , recupera la diapositiva desiderata usando il suo indice e quindi chiami il metodo per aggiungere un grafico, specificando il tipo di grafico e i dati iniziali. Questo processo integra il grafico direttamente nella tua presentazione.

### Come posso aggiornare i dati visualizzati in un grafico?

Puoi aggiornare i dati di un grafico accedendo al suo workbook dei dati ([IChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/)), cancellando le serie e le categorie predefinite e aggiungendo i tuoi dati personalizzati. Questo ti permette di aggiornare il grafico per riflettere i dati più recenti.

### È possibile personalizzare l'aspetto del grafico?

Sì, Aspose.Slides fornisce ampie opzioni di personalizzazione. È possibile modificare colori, caratteri, etichette, legende e altri [elementi di formattazione](/slides/it/androidjava/chart-entities/) per adattare l’aspetto del grafico alle tue specifiche esigenze di design.