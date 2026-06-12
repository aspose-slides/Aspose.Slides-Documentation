---
title: Personalizza le barre di errore nei grafici di presentazione usando Java
linktitle: Barra di errore
type: docs
url: /it/java/error-bar/
keywords:
- barra di errore
- valore personalizzato
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come aggiungere e personalizzare le barre di errore nei grafici con Aspose.Slides per Java — ottimizza le visualizzazioni dei dati nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con le barre di errore nei grafici di presentazione utilizzando Aspose.Slides. Mostra come aggiungere le barre di errore a una serie di grafico, configurare le impostazioni delle barre di errore X e Y e applicare diversi tipi di valore come fisso, percentuale e valore personalizzato.

Dimostra inoltre come assegnare valori personalizzati alle barre di errore per punti dati individuali in una serie utilizzando la relativa collezione di punti dati. Inoltre, l'articolo include brevi note su come le barre di errore si comportano durante l'esportazione, la loro compatibilità con marker e etichette dati, e dove trovare le classi e gli enum di riferimento dell'API correlati.

## **Aggiungere barre di errore**
Aspose.Slides for Java fornisce un'API semplice per gestire i valori delle barre di errore. Il codice di esempio si applica quando si utilizza un tipo di valore personalizzato. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella collezione [**DataPoints**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartSeriesCollection) della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Impostazione dei valori e del formato delle barre.
1. Scrivi la presentazione modificata in un file PPTX.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Creazione di un grafico a bolle
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Aggiunta di barre di errore e impostazione del relativo formato
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Salvataggio della presentazione
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere valori personalizzati per le barre di errore**
Aspose.Slides for Java fornisce un'API semplice per gestire i valori personalizzati delle barre di errore. Il codice di esempio si applica quando la proprietà [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IErrorBarsFormat#getValue--) è uguale a **Custom**. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella collezione [**DataPoints**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartSeriesCollection) della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Accedi ai singoli punti dati della serie del grafico e imposta i valori della barra di errore per ciascun punto dati della serie.
1. Impostazione dei valori e del formato delle barre.
1. Scrivi la presentazione modificata in un file PPTX.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Creazione di un grafico a bolle
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Aggiunta di barre di errore personalizzate e impostazione del relativo formato
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Accesso al punto dati della serie del grafico e impostazione dei valori delle barre di errore per
    // punto individuale
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Impostazione delle barre di errore per i punti della serie del grafico
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Salvataggio della presentazione
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Cosa succede alle barre di errore quando si esporta una presentazione in PDF o immagini?**

Vengono renderizzate come parte del grafico e conservate durante la conversione insieme al resto della formattazione del grafico, a condizione che si utilizzi una versione o un renderer compatibile.

**Le barre di errore possono essere combinate con i marcatori e le etichette dati?**

Sì. Le barre di errore sono un elemento separato e sono compatibili con marcatori e etichette dati; se gli elementi si sovrappongono, potrebbe essere necessario regolare la formattazione.

**Dove posso trovare l'elenco delle proprietà e delle classi per lavorare con le barre di errore nell'API?**

Nella documentazione dell'API: la classe [ErrorBarsFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/errorbarsformat/) e le classi correlate [ErrorBarType](https://reference.aspose.com/slides/it/java/com.aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/it/java/com.aspose.slides/errorbarvaluetype/).