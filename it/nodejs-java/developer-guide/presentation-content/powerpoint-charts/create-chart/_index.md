---
title: Crea o aggiorna grafici di presentazioni PowerPoint in JavaScript
linktitle: Crea o aggiorna grafici
type: docs
weight: 10
url: /it/nodejs-java/create-chart/
keywords:
- aggiungi grafico
- crea grafico
- modifica grafico
- cambia grafico
- aggiorna grafico
- grafico a dispersione
- grafico a torta
- grafico a linee
- grafico ad albero
- grafico finanziario
- grafico a scatola e baffi
- grafico a imbuto
- grafico a raggiera
- istogramma
- grafico radar
- grafico multicategoria
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e personalizza i grafici nelle presentazioni PowerPoint con Aspose.Slides per Node.js. Aggiungi, formatta e modifica i grafici con esempi pratici di codice in JavaScript."
---
## **Panoramica**

Questo articolo fornisce una guida completa su come creare e personalizzare i grafici utilizzando Aspose.Slides. Imparerai a inserire programmaticamente un grafico in una diapositiva, a popolarlo con i dati e ad applicare varie opzioni di formattazione per soddisfare i requisiti di design specifici. In tutto l'articolo, esempi di codice dettagliati illustrano ogni passaggio, dall'inizializzazione della presentazione e dell'oggetto grafico alla configurazione di serie, assi e legende. Seguendo questa guida otterrai una solida comprensione di come integrare la generazione dinamica di grafici nelle tue applicazioni, semplificando il processo di creazione di presentazioni basate sui dati.

## **Crea un grafico**

I grafici aiutano le persone a visualizzare rapidamente i dati e a ottenere approfondimenti che potrebbero non essere immediatamente evidenti da una tabella o da un foglio di calcolo.

**Perché creare grafici?**

Utilizzando i grafici è possibile:

* aggregare, condensare o riassumere grandi quantità di dati su una singola diapositiva di una presentazione
* evidenziare schemi e tendenze nei dati
* dedurre la direzione e la dinamica dei dati nel tempo o rispetto a una specifica unità di misura
* individuare valori anomali, aberrazioni, deviazioni, errori, dati senza senso, ecc.
* comunicare o presentare dati complessi

In PowerPoint è possibile creare grafici tramite la funzione *Insert*, che fornisce modelli per progettare molti tipi di grafico. Utilizzando Aspose.Slides, è possibile creare sia grafici standard (basati su tipi di grafico popolari) sia grafici personalizzati.

{{% alert color="info" title="Note" %}}
Per creare i grafici, utilizza la classe [ChartType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/). I campi di questa classe corrispondono a diversi tipi di grafico.
{{% /alert %}}

### **Crea grafici a colonne raggruppate**

Questa sezione spiega come creare grafici a colonne raggruppate utilizzando Aspose.Slides. Imparerai a inizializzare una presentazione, aggiungere un grafico e personalizzare i suoi elementi, come titolo, dati, serie, categorie e stile. Segui i passaggi qui sotto per vedere come viene generato un grafico a colonne raggruppate standard:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con alcuni dati e specifica il tipo `ChartType.ClusteredColumn` .
4. Aggiungi un titolo al grafico.
5. Accedi al foglio dati del grafico.
6. Cancella tutte le serie e le categorie predefinite.
7. Aggiungi nuove serie e categorie.
8. Aggiungi nuovi dati al grafico per le serie.
9. Applica un colore di riempimento alle serie del grafico.
10. Aggiungi etichette alle serie del grafico.
11. Salva la presentazione modificata come file PPTX.

Questo codice C# dimostra come creare un grafico a colonne raggruppate:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanza di una classe presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiunge un grafico con i dati predefiniti
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Imposta il titolo del grafico
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Imposta la prima serie per mostrare i valori
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Imposta l'indice per il foglio dati del grafico
    var defaultWorksheetIndex = 0;
    // Ottiene il foglio dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Elimina le serie e le categorie generate di default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Aggiunge nuove serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Aggiunge nuove categorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Prende la prima serie del grafico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Ora popola i dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Imposta il colore di riempimento per la serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Prende la seconda serie del grafico
    series = chart.getChartData().getSeries().get_Item(1);
    // Popola i dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Imposta il colore di riempimento per la serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Crea etichette personalizzate per ciascuna categoria per la nuova serie
    // Imposta la prima etichetta per mostrare il nome della categoria
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Mostra il valore per la terza etichetta
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Salva la presentazione con il grafico
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici a dispersione**

I grafici a dispersione (noti anche come diagrammi a dispersione o grafici x‑y) sono spesso usati per verificare la presenza di schemi o per dimostrare correlazioni tra due variabili.

Usa un grafico a dispersione quando:

* disponi di dati numerici accoppiati
* hai due variabili che si correlano bene tra loro
* vuoi determinare se due variabili sono correlate
* hai una variabile indipendente con più valori per una variabile dipendente

1. Segui i passaggi in [Crea grafici a colonne raggruppate](#create-clustered-column-charts).
2. Per il terzo passaggio, aggiungi un grafico con alcuni dati e specifica il tipo di grafico come uno dei seguenti:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Rappresenta un grafico a dispersione._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Rappresenta un grafico a dispersione collegato da curve, con marcatori dati._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Rappresenta un grafico a dispersione collegato da curve, senza marcatori dati._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Rappresenta un grafico a dispersione collegato da linee, con marcatori dati._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Rappresenta un grafico a dispersione collegato da linee, senza marcatori dati._

Questo codice JavaScript mostra come creare un grafico a dispersione con marcatori diversi per ogni serie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanzia una classe presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Crea il grafico predefinito
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Ottiene l'indice del foglio dati del grafico predefinito
    var defaultWorksheetIndex = 0;
    // Ottiene il foglio dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Elimina le serie demo
    chart.getChartData().getSeries().clear();
    // Aggiunge nuove serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Prende la prima serie del grafico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Aggiunge un nuovo punto (1:3) alla serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Aggiunge un nuovo punto (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Cambia il tipo della serie
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Cambia il marcatore della serie del grafico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
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
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici a torta**

I grafici a torta sono ideali per mostrare la relazione parte‑intero nei dati, soprattutto quando i dati contengono etichette categoriali con valori numerici. Tuttavia, se i tuoi dati contengono molte parti o etichette, potresti considerare l'uso di un grafico a barre.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.Pie](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#Pie) .
4. Accedi al workbook dei dati del grafico [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Cancella le serie e le categorie predefinite.
6. Aggiungi nuove serie e categorie.
7. Aggiungi nuovi dati al grafico per le serie.
8. Aggiungi nuovi punti al grafico e applica colori personalizzati ai settori del grafico a torta.
9. Imposta le etichette per le serie.
10. Abilita le linee guida per le etichette delle serie.
11. Imposta l'angolo di rotazione per le sezioni del grafico a torta.
12. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico a torta:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanzia una classe presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var slides = pres.getSlides().get_Item(0);
    // Aggiunge un grafico con dati predefiniti
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Imposta il titolo del grafico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Imposta la prima serie per mostrare i valori
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Imposta l'indice per il foglio dati del grafico
    var defaultWorksheetIndex = 0;
    // Ottiene il foglio dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Elimina le serie e le categorie generate di default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Aggiunge nuove categorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Aggiunge nuove serie
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Popola i dati della serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Non funziona nella nuova versione
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Imposta il bordo del settore
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Imposta il bordo del settore
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Imposta il bordo del settore
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Crea etichette personalizzate per ciascuna categoria per la nuova serie
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Mostra le linee guida per il grafico
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Imposta l'angolo di rotazione per i settori del grafico a torta
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Salva la presentazione con un grafico
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici a linee**

I grafici a linee (noti anche come grafici lineari) sono ideali quando si desidera mostrare variazioni di valore nel tempo. Con un grafico a linee è possibile confrontare grandi quantità di dati contemporaneamente, monitorare cambiamenti e tendenze nel tempo, evidenziare anomalie nelle serie di dati e molto altro.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.Line](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#Line) .
1. Accedi al workbook dei dati del grafico ([ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/)) .
1. Cancella le serie e le categorie predefinite.
1. Aggiungi nuove serie e categorie.
1. Aggiungi nuovi dati al grafico per le serie.
1. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico a linee:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Per impostazione predefinita, i punti di un grafico a linee sono collegati da linee continue rette. Se desideri che i punti siano collegati da segmenti tratteggiati, puoi specificare il tipo di tratto desiderato come segue:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici ad albero**

I grafici ad albero sono ideali per dati di vendita quando si vuole mostrare la dimensione relativa delle categorie e attirare rapidamente l'attenzione sugli elementi che contribuiscono di più all'interno di ciascuna categoria.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.Treemap](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#Treemap) .
4. Accedi al workbook dei dati del grafico [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Cancella le serie e le categorie predefinite.
6. Aggiungi nuove serie e categorie.
7. Aggiungi nuovi dati al grafico per le serie.
8. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico ad albero:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ramo 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ramo 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici finanziari**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Accedi al workbook dei dati del grafico [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Cancella le serie e le categorie predefinite.
6. Aggiungi nuove serie e categorie.
7. Aggiungi nuovi dati al grafico per le serie.
8. Specifica il formato delle linee high‑low.
9. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico finanziario:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici a scatola e baffi**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Accedi al workbook dei dati del grafico [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Cancella le serie e le categorie predefinite.
6. Aggiungi nuove serie e categorie.
7. Aggiungi nuovi dati al grafico per le serie.
8. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico a scatola e baffi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
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
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici a imbuto**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.Funnel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#Funnel) .
4. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico a imbuto:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici a raggiera**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.Sunburst](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#Sunburst) .
4. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico a raggiera:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ramo 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ramo 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea istogrammi**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.Histogram](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#Histogram) .
4. Accedi al workbook dei dati del grafico [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Cancella le serie e le categorie predefinite.
6. Aggiungi nuove serie e categorie.
7. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un istogramma:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Crea grafici radar**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con alcuni dati e specifica il tipo di grafico preferito ([ChartType.Radar](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#Radar) in questo caso).
4. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico radar:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici multicategoria**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e specifica il tipo [ChartType.ClusteredColumn](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/#ClusteredColumn) .
4. Accedi al workbook dei dati del grafico [ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Cancella le serie e le categorie predefinite.
6. Aggiungi nuove serie e categorie.
7. Aggiungi nuovi dati al grafico per le serie.
8. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come creare un grafico multicategoria:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Salva la presentazione con il grafico
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici geografici**

I grafici geografici visualizzano dati geospaziali e aiutano a confrontare valori tra regioni.

Questo codice JavaScript mostra come creare un grafico geografico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crea grafici combinati**

Un grafico combinato (o combo) combina due o più tipi di grafico in un unico diagramma. Questo grafico consente di evidenziare, confrontare o esaminare differenze tra due o più set di dati, aiutandoti a identificare le relazioni tra di essi.

![The combination chart](combination_chart.png)

Il codice JavaScript seguente mostra come creare il grafico combinato mostrato sopra in una presentazione PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Imposta il titolo del grafico.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Imposta la legenda del grafico.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Elimina le serie e le categorie generate di default.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Aggiungi nuove categorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Aggiungi la prima serie.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Imposta l'asse orizzontale.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Imposta l'asse verticale.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Imposta il colore delle linee di griglia principali verticali.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Imposta l'asse orizzontale secondario.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Imposta l'asse verticale secondario.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Aggiorna grafici**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) che rappresenta la presentazione contenente il grafico da aggiornare.
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Scorri tutte le forme per trovare il grafico desiderato.
4. Accedi al foglio dati del grafico.
5. Modifica le serie di dati del grafico cambiando i valori delle serie.
6. Aggiungi una nuova serie e popola i suoi dati.
7. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come aggiornare un grafico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Accedi al primo slideMarker
    var sld = pres.getSlides().get_Item(0);
    // Ottieni il grafico con dati predefiniti
    var chart = sld.getShapes().get_Item(0);
    // Impostazione dell'indice del foglio dati del grafico
    var defaultWorksheetIndex = 0;
    // Recupero del foglio dati del grafico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Modifica del nome della categoria del grafico
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Prendi la prima serie del grafico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Aggiornamento dei dati della serie
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modifica del nome della serie
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Prendi la seconda serie del grafico
    series = chart.getChartData().getSeries().get_Item(1);
    // Aggiornamento dei dati della serie
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modifica del nome della serie
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Aggiunta di una nuova serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Prendi la terza serie del grafico
    series = chart.getChartData().getSeries().get_Item(2);
    // Popolamento dei dati della serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Salva la presentazione con il grafico
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta intervallo dati per un grafico**

Per impostare l'intervallo dati per un grafico, esegui quanto segue:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) che rappresenta la presentazione contenente il grafico.
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Scorri tutte le forme per trovare il grafico desiderato.
4. Accedi ai dati del grafico e imposta l'intervallo.
5. Salva la presentazione modificata come file PPTX.

Questo codice JavaScript mostra come impostare l'intervallo dati per un grafico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usa marcatori predefiniti nei grafici**

Quando utilizzi marcatori predefiniti nei grafici, ogni serie del grafico ottiene automaticamente un simbolo di marcatore diverso.

Questo codice JavaScript mostra come impostare automaticamente un marcatore di serie di grafico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Ora si popolano i dati della serie
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quali tipi di grafico sono supportati da Aspose.Slides?**

Aspose.Slides supporta un'ampia gamma di [tipi di grafico](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/charttype/), tra cui barre, linee, torta, area, dispersione, istogramma, radar e molti altri. Questa flessibilità ti consente di scegliere il tipo di grafico più adatto alle tue esigenze di visualizzazione dei dati.

**Come aggiungo un nuovo grafico a una diapositiva?**

Per aggiungere un grafico, prima crei un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) , recuperi la diapositiva desiderata tramite il suo indice e poi chiami il metodo per aggiungere un grafico, specificando il tipo di grafico e i dati iniziali. Questo processo integra il grafico direttamente nella tua presentazione.

**Come posso aggiornare i dati visualizzati in un grafico?**

Puoi aggiornare i dati di un grafico accedendo al suo workbook dei dati ([ChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/)), cancellando le serie e le categorie predefinite e aggiungendo i tuoi dati personalizzati. Questo ti permette di aggiornare programmaticamente il grafico per riflettere i dati più recenti.

**È possibile personalizzare l'aspetto del grafico?**

Sì, Aspose.Slides offre ampie opzioni di personalizzazione. Puoi modificare colori, caratteri, etichette, legende e altri [elementi di formattazione](/slides/it/nodejs-java/chart-entities/) per adattare l'aspetto del grafico ai requisiti di design specifici.