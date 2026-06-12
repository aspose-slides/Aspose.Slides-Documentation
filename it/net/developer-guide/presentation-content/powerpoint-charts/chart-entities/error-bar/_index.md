---
title: Personalizza le barre di errore nei grafici di presentazione in .NET
linktitle: Barra di errore
type: docs
url: /it/net/error-bar/
keywords:
- barra di errore
- valore personalizzato
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiungere e personalizzare le barre di errore nei grafici con Aspose.Slides per .NET—ottimizza le visualizzazioni dei dati nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con le barre di errore nei grafici di presentazione utilizzando Aspose.Slides. Mostra come aggiungere le barre di errore a una serie di grafico, configurare le impostazioni delle barre di errore X e Y e applicare diversi tipi di valore come valori fissi, percentuali e personalizzati.

Dimostra inoltre come assegnare valori personalizzati delle barre di errore per punti dati individuali in una serie utilizzando la relativa raccolta di punti dati. Inoltre, l'articolo include brevi note su come le barre di errore si comportano durante l'esportazione, sulla loro compatibilità con i marcatori e le etichette dei dati, e su dove trovare le classi e le enum di riferimento dell'API correlate.

## **Aggiungere barre di errore**
Aspose.Slides per .NET fornisce un'API semplice per gestire i valori delle barre di errore. Il codice di esempio si applica quando si utilizza un tipo di valore personalizzato. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella raccolta **DataPoints** della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Impostazione dei valori e del formato delle barre.
1. Scrivi la presentazione modificata in un file PPTX.

```c#
// Creazione di una presentazione vuota
using (Presentation presentation = new Presentation())
{
    // Creazione di un grafico a bolle
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Aggiunta delle barre di errore e impostazione del formato
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Salvataggio della presentazione
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Aggiungere valori personalizzati delle barre di errore**
Aspose.Slides per .NET fornisce un'API semplice per gestire i valori personalizzati delle barre di errore. Il codice di esempio si applica quando la proprietà **IErrorBarsFormat.ValueType** è uguale a **Custom**. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella raccolta **DataPoints** della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Accedi ai singoli punti dati della serie del grafico e imposta i valori della barra di errore per ciascun punto dati della serie.
1. Impostazione dei valori e del formato delle barre.
1. Scrivi la presentazione modificata in un file PPTX.

```c#
// Creazione di una presentazione vuota
using (Presentation presentation = new Presentation())
{
    // Creazione di un grafico a bolle
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Aggiunta di barre di errore personalizzate e impostazione del formato
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Accesso al punto dati della serie del grafico e impostazione dei valori delle barre di errore per il punto individuale
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Impostazione delle barre di errore per i punti della serie del grafico
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Salvataggio della presentazione
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Cosa succede alle barre di errore quando si esporta una presentazione in PDF o immagini?**

Vengono renderizzate come parte del grafico e conservate durante la conversione insieme al resto della formattazione del grafico, a condizione che la versione o il renderer siano compatibili.

**Le barre di errore possono essere combinate con i marcatori e le etichette dei dati?**

Sì. Le barre di errore sono un elemento separato e sono compatibili con i marcatori e le etichette dei dati; se gli elementi si sovrappongono, potrebbe essere necessario regolare la formattazione.

**Dove posso trovare l'elenco delle proprietà e delle enum per lavorare con le barre di errore nell'API?**

Nella documentazione dell'API: la classe [ErrorBarsFormat](https://reference.aspose.com/slides/it/net/aspose.slides.charts/errorbarsformat/) e le enum correlate [ErrorBarType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/errorbarvaluetype/).