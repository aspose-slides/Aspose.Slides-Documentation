---
title: Personalizza i Punti Dati nei Diagrammi Treemap e Sunburst Utilizzando JavaScript
linktitle: Punti Dati nei Diagrammi Treemap e Sunburst
type: docs
url: /it/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- diagramma treemap
- diagramma sunburst
- punto dati
- colore etichetta
- colore ramo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come gestire i punti dati nei diagrammi treemap e sunburst con JavaScript e Aspose.Slides per Node.js tramite Java, compatibile con i formati PowerPoint."
---
## **Introduzione**

Tra gli altri tipi di diagrammi PowerPoint, esistono due tipologie “gerarchiche” – il diagramma **Treemap** e il diagramma **Sunburst** (noto anche come Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph o Multi Level Pie Chart). Questi diagrammi visualizzano dati gerarchici organizzati come un albero – dalle foglie fino alla cima del ramo. Le foglie sono definite dai punti dati della serie, e ogni livello di raggruppamento annidato successivo è definito dalla corrispondente categoria. Aspose.Slides per Node.js tramite Java consente di formattare i punti dati dei diagrammi Sunburst e Treemap in JavaScript.

Ecco un diagramma Sunburst, dove i dati nella colonna Series1 definiscono i nodi foglia, mentre le altre colonne definiscono i punti dati gerarchici:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Iniziamo aggiungendo un nuovo diagramma Sunburst alla presentazione:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Vedi anche" %}} 
- [**Crea o Aggiorna Diagrammi PowerPoint in JavaScript**](/slides/it/nodejs-java/create-chart/)
{{% /alert %}}

Se è necessario formattare i punti dati del diagramma, dovremmo utilizzare il seguente:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPointLevelsManager), [ChartDataPointLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPointLevel) classi e il metodo [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) forniscono l'accesso per formattare i punti dati dei diagrammi Treemap e Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPointLevelsManager) è usato per accedere alle categorie a più livelli – rappresenta il contenitore degli oggetti [**ChartDataPointLevel**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPointLevel). 
In sostanza è un wrapper per [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartCategoryLevelsManager) con proprietà aggiunte specifiche per i punti dati. 
La classe [**ChartDataPointLevel**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPointLevel) ha due metodi: [**getFormat**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) e [**getDataLabel**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) che forniscono l'accesso alle impostazioni corrispondenti.

## **Mostra Valore del Punto Dati**
Mostra il valore del punto dati "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Imposta Etichetta e Colore del Punto Dati**
Imposta l'etichetta del punto dati "Branch 1" per mostrare il nome della serie ("Series1") invece del nome della categoria. Poi imposta il colore del testo a giallo:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Imposta Colore del Ramo del Punto Dati**
Cambia il colore del ramo "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Posso cambiare l'ordine (ordinamento) dei segmenti in Sunburst/Treemap?**

No. PowerPoint ordina i segmenti automaticamente (tipicamente per valori decrescenti, in senso orario). Aspose.Slides replica questo comportamento: non è possibile cambiare direttamente l'ordine; lo si ottiene pre-elaborando i dati.

**Come influisce il tema della presentazione sui colori dei segmenti e delle etichette?**

I colori del diagramma ereditano il [tema/palette](/slides/it/nodejs-java/presentation-theme/) della presentazione, a meno che non si impostino esplicitamente riempimenti/font. Per risultati coerenti, bloccare riempimenti solidi e formattazione del testo ai livelli necessari.

**L'esportazione in PDF/PNG manterrà i colori personalizzati dei rami e le impostazioni delle etichette?**

Sì. Durante l'esportazione della presentazione, le impostazioni del diagramma (riempimenti, etichette) vengono preservate nei formati di output perché Aspose.Slides rende il diagramma con la formattazione applicata.

**Posso calcolare le coordinate effettive di un'etichetta/elemento per posizionare sovrapposizioni personalizzate sopra il diagramma?**

Sì. Dopo che il layout del diagramma è stato convalidato, sono disponibili le coordinate X reale e Y reale per gli elementi (ad esempio un [DataLabel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datalabel/)), il che aiuta a posizionare con precisione le sovrapposizioni.