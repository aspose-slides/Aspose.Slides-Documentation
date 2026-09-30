---
title: Personalizza le legende dei grafici nelle presentazioni usando JavaScript
linktitle: Leggenda del grafico
type: docs
url: /it/nodejs-java/chart-legend/
keywords:
- leggenda del grafico
- posizione leggenda
- dimensione carattere
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per Node.js via Java per ottimizzare le presentazioni PowerPoint con formattazione della leggenda su misura."
---
## **Panoramica**

Aspose.Slides for Node.js via Java offre opzioni per personalizzare le leggende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda, formattare una voce della legenda individuale e nascondere o ripristinare le voci selezionate.

Le FAQ coprono comportamenti correlati, includendo la riserva di spazio per la legenda, la visualizzazione di etichette multilinea e l'ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della leggenda**

Utilizza i metodi [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) e [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) della legenda per specificare la sua posizione e dimensione come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti alla prima diapositiva. Dividendo gli offset e le dimensioni desiderate della legenda per la larghezza e l'altezza del grafico si convertono in valori relativi: la legenda è spostata di 50 punti dall'angolo superiore sinistro del grafico e dimensionata a 100 per 100 punti.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Esprimi la posizione e le dimensioni della leggenda rispetto al grafico.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la dimensione del carattere di una legenda**

Utilizza il metodo [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) della legenda per accedere alla formattazione del testo e usa [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) per impostare la dimensione del carattere in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della legenda a 20 punti. Disabilita inoltre i limiti automatici per l'asse verticale e imposta il suo intervallo da -5 a 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la dimensione del carattere di una voce della leggenda individuale**

Utilizza la collezione restituita dal metodo [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) della legenda per accedere alla formattazione di una voce specifica. Gli indici delle voci partono da zero, quindi l'indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate i cui dati predefiniti includono almeno due serie. Formatta la seconda voce della legenda con testo grassetto, corsivo e blu da 20 punti.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nascondi voci della leggenda individuali**

Per escludere una serie ausiliaria dalla leggenda mantenendo i suoi dati visibili, chiama [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) con `true` tramite [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Questo nasconde solo la voce della legenda selezionata; non rimuove la serie o i suoi punti dati. Chiamare [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) con `false`, invece, nasconde l'intera leggenda.

L'esempio seguente crea un grafico a colonne raggruppate con più serie usando dati predefiniti. Nasconde la voce della legenda della seconda serie (indice `1`) e salva la presentazione. Poi ripristina la voce chiamando [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) con `false` e salva una seconda copia. Le colonne rimangono visibili in entrambi i file.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Ripristina la stessa voce senza modificare i dati del grafico.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto sotto mostra lo stesso grafico con tutte le voci visibili e con la seconda voce nascosta. Le colonne della seconda serie rimangono inalterate.

![Confronto di un grafico con tutte le voci della legenda visibili e con la Serie 2 nascosta nella legenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

Nei grafici a colonne, barre e linee, le voci della legenda identificano le serie. Nei grafici a torta, identificano i singoli punti dati (fette), quindi usa [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) sulla fetta selezionata. L'API documenta questo metodo per i tipi di grafico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Non presumere che si applichi ai grafici a ciambella, che non sono inclusi in tale elenco.

## **FAQ**

**Posso fare in modo che il grafico riservi spazio per la legenda invece di sovrapporla?**

Sì. Chiama [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) con `false` per riservare spazio per la legenda invece di consentire che si sovrapponga all'area del grafico.

**Posso creare etichette della legenda multilinea?**

Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. È anche possibile utilizzare caratteri di nuova riga nei nomi delle serie per richiedere interruzioni di riga.

**Come posso fare in modo che la legenda segua lo schema colore del tema della presentazione?**

Lascia vuoti i colori, i riempimenti e i caratteri della legenda in modo che possa ereditare la formattazione del tema. La formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.