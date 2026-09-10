---
title: Personalizza le barre di errore nei grafici di presentazione usando Python
linktitle: Barra di errore
type: docs
url: /it/python-java/error-bar/
keywords:
- barra di errore
- valore personalizzato
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come aggiungere e personalizzare le barre di errore nei grafici con Aspose.Slides for Python via Java—ottimizza le visualizzazioni dei dati nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con le barre di errore nei grafici di presentazione utilizzando Aspose.Slides. Mostra come aggiungere le barre di errore a una serie di grafico, configurare le impostazioni delle barre di errore X e Y e applicare diversi tipi di valore come fisso, percentuale e personalizzato.

Dimostra inoltre come assegnare valori personalizzati di barra di errore per punti dati individuali in una serie utilizzando la relativa collezione di punti dati. Inoltre, l'articolo include brevi note su come le barre di errore si comportano durante l'esportazione, la loro compatibilità con i marcatori e le etichette dati, e dove trovare le classi e le enumerazioni correlate nella documentazione di riferimento dell'API.

## **Aggiungere barre di errore**

Aspose.Slides for Python via Java fornisce un'API semplice per gestire i valori delle barre di errore. Il codice di esempio seguente utilizza tipi di valore fisso e percentuale.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Aggiungere un grafico a bolle alla diapositiva desiderata.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore X.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore Y.
1. Impostare i valori e la formattazione delle barre di errore.
1. Scrivere la presentazione modificata in un file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    # Crea un grafico a bolle.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Aggiungi le barre di errore e imposta la loro formattazione.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Salva la presentazione.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere valori personalizzati per le barre di errore**

Aspose.Slides for Python via Java fornisce un'API semplice per gestire i valori personalizzati delle barre di errore. Il codice di esempio seguente si applica quando [getValueType](https://reference.aspose.com/slides/it/python-java/aspose.slides/errorbarsformat/#getValueType) restituisce [ErrorBarValueType.Custom](https://reference.aspose.com/slides/it/python-java/aspose.slides/errorbarvaluetype/#Custom). Per specificare un valore, utilizzare [getErrorBarsCustomValues](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) per un punto dati specifico nella collezione restituita dal metodo della serie [getDataPoints](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getDataPoints).

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Aggiungere un grafico a bolle alla diapositiva desiderata.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore X.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore Y.
1. Accedere ai singoli punti dati nella serie del grafico e impostare i loro valori di barra di errore.
1. Impostare i valori e la formattazione delle barre di errore.
1. Scrivere la presentazione modificata in un file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    # Crea un grafico a bolle.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Aggiungi barre di errore personalizzate e imposta la loro formattazione.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Accedi ai punti dati della serie del grafico e configura le loro fonti di valori per le barre di errore.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Imposta i valori delle barre di errore per i punti dati della serie del grafico.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Salva la presentazione.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Cosa succede alle barre di errore quando si esporta una presentazione in PDF o immagini?**

Vengono renderizzate come parte del grafico e vengono conservate durante la conversione insieme al resto della formattazione del grafico, supposando una versione o un motore compatibile.

**Le barre di errore possono essere combinate con marcatori e etichette dati?**

Sì. Le barre di errore sono un elemento separato e sono compatibili con marcatori e etichette dati; se gli elementi si sovrappongono, potrebbe essere necessario regolare la formattazione.

**Dove posso trovare l'elenco delle proprietà e delle classi per lavorare con le barre di errore nell'API?**

Nella documentazione di riferimento dell'API: la classe [ErrorBarsFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/errorbarsformat/) e le classi correlate [ErrorBarType](https://reference.aspose.com/slides/it/python-java/aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/it/python-java/aspose.slides/errorbarvaluetype/).