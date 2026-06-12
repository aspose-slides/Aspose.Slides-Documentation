---
title: Personalizza le barre di errore nei grafici di presentazione con Python
linktitle: Barra di errore
type: docs
url: /it/python-net/error-bar/
keywords:
- barra di errore
- valore personalizzato
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come aggiungere e personalizzare le barre di errore nei grafici con Aspose.Slides per Python via .NET—ottimizza la visualizzazione dei dati in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come lavorare con le barre di errore nei grafici di presentazione utilizzando Aspose.Slides. Mostra come aggiungere barre di errore a una serie di grafico, configurare le impostazioni delle barre di errore X e Y e applicare diversi tipi di valore come fisso, percentuale e valori personalizzati.

Dimostra anche come assegnare valori di barra di errore personalizzati per punti dati individuali in una serie utilizzando la relativa raccolta di punti dati. Inoltre, l'articolo include brevi note su come le barre di errore si comportano durante l'esportazione, la loro compatibilità con marcatori ed etichette dati e dove trovare le classi e gli enum di riferimento API correlati.

## **Aggiungi barra di errore**
Aspose.Slides for Python via .NET fornisce una semplice API per gestire i valori delle barre di errore. Il codice di esempio si applica quando si utilizza un tipo di valore personalizzato. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella raccolta **DataPoints** della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Impostazione dei valori e del formato delle barre.
1. Scrivi la presentazione modificata in un file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creazione di una presentazione vuota
with slides.Presentation() as presentation:
    # Creazione di un grafico a bolle
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Aggiunta di barre di errore e impostazione del loro formato
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Salvataggio della presentazione
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Aggiungi valore di barra di errore personalizzato**
Aspose.Slides for Python via .NET fornisce una semplice API per gestire i valori delle barre di errore personalizzate. Il codice di esempio si applica quando la proprietà **IErrorBarsFormat.ValueType** è uguale a **Custom**. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella raccolta **DataPoints** della serie:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Aggiungi un grafico a bolle nella diapositiva desiderata.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore X.
1. Accedi alla prima serie del grafico e imposta il formato della barra di errore Y.
1. Accedi ai punti dati individuali della serie del grafico e imposta i valori della barra di errore per ciascun punto della serie.
1. Impostazione dei valori e del formato delle barre.
1. Scrivi la presentazione modificata in un file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creazione di una presentazione vuota
with slides.Presentation() as presentation:
    # Creazione di un grafico a bolle
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Aggiunta di barre di errore personalizzate e impostazione del loro formato
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Accesso al punto dati della serie del grafico e impostazione dei valori delle barre di errore per il punto individuale
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Impostazione delle barre di errore per i punti della serie del grafico
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Salvataggio della presentazione
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Cosa succede alle barre di errore quando si esporta una presentazione in PDF o immagini?**

Vengono renderizzate come parte del grafico e preservate durante la conversione insieme al resto della formattazione del grafico, assumendo una versione o un motore compatibile.

**Le barre di errore possono essere combinate con marcatori e etichette dati?**

Sì. Le barre di errore sono un elemento separato e sono compatibili con marcatori ed etichette dati; se gli elementi si sovrappongono, potrebbe essere necessario regolare la formattazione.

**Dove posso trovare l'elenco delle proprietà e degli enum per lavorare con le barre di errore nell'API?**

Nella documentazione dell'API: la classe [ErrorBarsFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/errorbarsformat/) e gli enum correlati [ErrorBarType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/errorbarvaluetype/).