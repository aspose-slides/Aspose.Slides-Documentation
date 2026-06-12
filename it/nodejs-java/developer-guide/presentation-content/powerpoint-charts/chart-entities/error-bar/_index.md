---
title: Personalizza le barre di errore nei grafici delle presentazioni usando JavaScript
linktitle: Barra di errore
type: docs
url: /it/nodejs-java/error-bar/
keywords:
- barra di errore
- valore personalizzato
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aggiungere e personalizzare le barre di errore nei grafici con JavaScript e Aspose.Slides per Node.js tramite Java—ottimizza le visualizzazioni dei dati nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con le barre di errore nei grafici delle presentazioni utilizzando Aspose.Slides. Mostra come aggiungere barre di errore a una serie di grafico, configurare le impostazioni delle barre di errore X e Y e applicare diversi tipi di valore come valori fissi, percentuali e personalizzati.

Dimostra inoltre come assegnare valori di barra di errore personalizzati per punti dati individuali in una serie utilizzando la collezione dei punti dati corrispondente. Inoltre, l’articolo include brevi note su come le barre di errore si comportano durante l’esportazione, la loro compatibilità con marker e etichette dati, e dove trovare le classi e gli enum di riferimento dell’API correlati.

## **Aggiungi barra di errore**

Aspose.Slides per Node.js tramite Java fornisce una semplice API per gestire i valori delle barre di errore. Il codice di esempio si applica quando si utilizza un tipo di valore personalizzato. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella collezione [**DataPoints**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeriesCollection) della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Imposta i valori delle barre e il formato.
1. Scrivi la presentazione modificata in un file PPTX.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Creazione di un grafico a bolle
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Aggiunta di barre di errore e impostazione del loro formato
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Salvataggio della presentazione
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungi valore barra di errore personalizzato**

Aspose.Slides per Node.js tramite Java fornisce una semplice API per gestire i valori di barra di errore personalizzati. Il codice di esempio si applica quando la proprietà [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) è pari a **Custom**. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella collezione [**DataPoints**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartSeriesCollection) della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Accedi ai singoli punti dati della serie del grafico e imposta i valori della barra di errore per ciascun punto dati della serie.
1. Imposta i valori delle barre e il formato.
1. Scrivi la presentazione modificata in un file PPTX.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Creazione di un grafico a bolle
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Aggiunta di barre di errore personalizzate e impostazione del loro formato
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Accesso al punto dati della serie del grafico e impostazione dei valori delle barre di errore per
    // punto individuale
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Impostazione delle barre di errore per i punti della serie del grafico
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Salvataggio della presentazione
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Cosa succede alle barre di errore quando si esporta una presentazione in PDF o immagini?**

Vengono renderizzate come parte del grafico e preservate durante la conversione insieme al resto della formattazione del grafico, assumendo una versione o un renderer compatibile.

**Le barre di errore possono essere combinate con marker e etichette dati?**

Sì. Le barre di errore sono un elemento separato e sono compatibili con marker e etichette dati; se gli elementi si sovrappongono, potrebbe essere necessario regolare la formattazione.

**Dove posso trovare l'elenco delle proprietà e degli enum per lavorare con le barre di errore nell'API?**

Nella documentazione di riferimento dell'API: la classe [ErrorBarsFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/errorbarsformat/) e gli enum correlati [ErrorBarType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/errorbarvaluetype/).