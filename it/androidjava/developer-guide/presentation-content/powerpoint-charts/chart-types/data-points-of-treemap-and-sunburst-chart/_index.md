---
title: Personalizza i punti dati nei diagrammi Treemap e Sunburst su Android
linktitle: Punti dati nei diagrammi Treemap e Sunburst
type: docs
url: /it/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- diagramma treemap
- diagramma sunburst
- punto dati
- colore etichetta
- colore ramo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come gestire i punti dati nei diagrammi treemap e sunburst con Aspose.Slides per Android via Java, compatibile con i formati PowerPoint."
---
## **Introduzione**

Tra gli altri tipi di diagrammi PowerPoint, esistono due tipi “gerarchici” – **Treemap** e **Sunburst** (chart, noto anche come Sunburst Graph, Sunburst Diagram, Diagramma radiale, Grafico radiale o Grafico a torta multilevel). Questi diagrammi mostrano dati gerarchici organizzati come un albero – dalle foglie fino alla cima del ramo. Le foglie sono definite dai punti dati della serie, e ogni successivo livello di raggruppamento annidato è definito dalla categoria corrispondente. Aspose.Slides per Android via Java consente di formattare i punti dati di Sunburst Chart e Treemap in Java.

Ecco un diagramma Sunburst, in cui i dati nella colonna Series1 definiscono i nodi foglia, mentre le altre colonne definiscono punti dati gerarchici:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Iniziamo aggiungendo un nuovo diagramma Sunburst alla presentazione:

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
- [**Crea o aggiorna i diagrammi delle presentazioni PowerPoint su Android**](/slides/it/androidjava/create-chart/)
{{% /alert %}}

Se è necessario formattare i punti dati del diagramma, dovremmo usare quanto segue:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPointLevel) classes 
and [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
viene utilizzato per accedere a categorie a più livelli – rappresenta il contenitore di 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPointLevel) objects.
In pratica è un wrapper for 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartCategoryLevelsManager) with
the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPointLevel) class has
two methods: [**getFormat**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) and 
[**getDataLabel**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) which
provide access to corresponding settings.

## **Mostra il valore di un punto dati**
Mostra il valore del punto dati “Leaf 4”:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Imposta etichetta e colore di un punto dati**
Imposta l'etichetta del punto dati “Branch 1” per mostrare il nome della serie (“Series1”) invece del nome della categoria. Poi imposta il colore del testo a giallo:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Imposta colore del ramo di un punto dati**
Modifica il colore del ramo “Steam 4”:

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

**Posso cambiare l'ordine (ordinamento) dei segmenti in Sunburst/Treemap?**

No. PowerPoint ordina i segmenti automaticamente (tipicamente per valori decrescenti, in senso orario). Aspose.Slides replica questo comportamento: non è possibile cambiare l'ordine direttamente; è necessario pre‑elaborare i dati.

**In che modo il tema della presentazione influisce sui colori dei segmenti e delle etichette?**

I colori del diagramma ereditano il [tema/palette](/slides/it/androidjava/presentation-theme/) della presentazione a meno che non vengano impostati esplicitamente riempimenti/font. Per risultati coerenti, blocca i riempimenti solidi e la formattazione del testo ai livelli richiesti.

**L'esportazione in PDF/PNG preserva i colori personalizzati dei rami e le impostazioni delle etichette?**

Sì. Quando si esporta la presentazione, le impostazioni del diagramma (riempimenti, etichette) vengono preservate nei formati di output perché Aspose.Slides rende il diagramma con la formattazione applicata.

**Posso calcolare le coordinate reali di un'etichetta/elemento per posizionare una sovrapposizione personalizzata sopra il diagramma?**

Sì. Dopo che il layout del diagramma è stato validato, sono disponibili le coordinate *x* e *y* effettive per gli elementi (ad esempio, una DataLabel), il che facilita il posizionamento preciso delle sovrapposizioni.