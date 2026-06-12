---
title: Personalizza i punti dati nei grafici Treemap e Sunburst usando Java
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- grafico treemap
- grafico sunburst
- punto dati
- colore etichetta
- colore ramo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come gestire i punti dati nei grafici treemap e sunburst con Aspose.Slides per Java, compatibile con i formati PowerPoint."
---
## **Introduzione**

Tra gli altri tipi di grafici PowerPoint, esistono due tipi “gerarchici” – **Treemap** e **Sunburst** (conosciuti anche come Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph o Multi Level Pie Chart). Questi grafici mostrano dati gerarchici organizzati come un albero – dalle foglie fino alla parte superiore del ramo. Le foglie sono definite dai punti dati della serie, e ogni livello di raggruppamento annidato successivo è definito dalla categoria corrispondente. Aspose.Slides per Java consente di formattare i punti dati dei grafici Sunburst e Treemap in Java.

Ecco un grafico Sunburst, in cui i dati nella colonna Series1 definiscono i nodi foglia, mentre le altre colonne definiscono i punti dati gerarchici:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Iniziamo aggiungendo un nuovo grafico Sunburst alla presentazione:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Vedi anche" %}} 
- [**Crea o Aggiorna Grafici di Presentazioni PowerPoint in Java**](/slides/it/java/create-chart/)
{{% /alert %}}

Se è necessario formattare i punti dati del grafico, dovremmo utilizzare quanto segue:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataPointLevelsManager), [**IChartDataPointLevel**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataPointLevel) classi e il metodo [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) forniscono l'accesso alla formattazione dei punti dati dei grafici Treemap e Sunburst. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataPointLevelsManager) è usato per accedere a categorie a più livelli – rappresenta il contenitore di [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartCategoryLevelsManager) con le proprietà aggiunte specifiche per i punti dati. La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataPointLevel) ha due metodi: [**getFormat**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataPointLevel#getFormat--) e [**getDataLabel**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataPointLevel#getLabel--) che forniscono l'accesso alle impostazioni corrispondenti.

## **Mostra il Valore di un Punto Dati**
Mostra il valore del punto dati "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Imposta l'Etichetta e il Colore di un Punto Dati**
Imposta l'etichetta del punto dati "Branch 1" per mostrare il nome della serie ("Series1") invece del nome della categoria. Quindi imposta il colore del testo su giallo:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Imposta il Colore del Ramo di un Punto Dati**
Cambia il colore del ramo "Steam 4":

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Posso modificare l'ordine (ordinamento) dei segmenti in Sunburst/Treemap?**

No. PowerPoint ordina i segmenti automaticamente (tipicamente per valori decrescenti, in senso orario). Aspose.Slides replica questo comportamento: non è possibile modificare direttamente l'ordine; è necessario farlo pre‑elaborando i dati.

**In che modo il tema della presentazione influisce sui colori dei segmenti e delle etichette?**

I colori del grafico ereditano il [tema/palette](/slides/it/java/presentation-theme/) della presentazione, a meno che non impostiate esplicitamente riempimenti/caratteri. Per risultati coerenti, fissate riempimenti solidi e la formattazione del testo nei livelli richiesti.

**L'esportazione in PDF/PNG manterrà i colori personalizzati dei rami e le impostazioni delle etichette?**

Sì. Durante l'esportazione della presentazione, le impostazioni del grafico (riempimenti, etichette) vengono conservate nei formati di output perché Aspose.Slides rende il grafico con la formattazione applicata.

**Posso calcolare le coordinate effettive di un'etichetta/elemento per posizionare un overlay personalizzato sopra il grafico?**

Sì. Dopo che il layout del grafico è stato convalidato, le coordinate *x* e *y* effettive sono disponibili per gli elementi (ad esempio, un [DataLabel](https://reference.aspose.com/slides/it/java/com.aspose.slides/datalabel/)), il che aiuta a posizionare con precisione gli overlay.