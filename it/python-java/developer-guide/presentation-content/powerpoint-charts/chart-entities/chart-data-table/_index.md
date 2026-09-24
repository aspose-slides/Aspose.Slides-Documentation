---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni con Python
linktitle: Tabella dati
type: docs
url: /it/python-java/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Personalizza i caratteri, i bordi e le chiavi della legenda delle tabelle dei dati dei grafici nelle presentazioni PowerPoint usando Aspose.Slides per Python via Java."
---
## **Panoramica**

Aspose.Slides per Python via Java ti consente di visualizzare la tabella dei dati di un grafico e di personalizzarne la formattazione del testo, i bordi e le chiavi della legenda. Questo articolo spiega come abilitare la tabella, formattare il testo, controllare ciascun tipo di bordo e mostrare o nascondere le chiavi della legenda. Gli esempi salvano i grafici configurati in file PPTX.

## **Impostare le proprietà del carattere**

Per visualizzare la tabella dei dati di un grafico, passa `True` a [setDataTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setDataTable). Usa [getChartDataTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#getChartDataTable) per accedere alla tabella e configurarne la formattazione del testo.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Aggiungi un grafico a colonne raggruppate alla prima diapositiva.
1. Abilita la tabella dei dati del grafico.
1. Abilita il testo in grassetto con [setFontBold](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setFontBold) e passa `20` a [setFontHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setFontHeight) per un testo di 20 punti.
1. Salva la presentazione modificata.

L'esempio seguente richiede `test.pptx` nella directory di lavoro con almeno una diapositiva. Aggiunge un grafico con dati predefiniti nella posizione (50, 50), con una larghezza di 600 punti e un'altezza di 400 punti. Il file `output.pptx` salvato contiene il grafico con la tabella dei dati abilitata e le impostazioni del carattere specificate applicate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Personalizzare i bordi della tabella dei dati**

Abilita la tabella con [Chart.setDataTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setDataTable) e accedila tramite [Chart.getChartDataTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#getChartDataTable). Puoi controllare tre tipi di bordi in modo indipendente:

- [setBorderHorizontal](https://reference.aspose.com/slides/it/python-java/aspose.slides/datatable/#setBorderHorizontal) controlla i bordi orizzontali delle celle.
- [setBorderVertical](https://reference.aspose.com/slides/it/python-java/aspose.slides/datatable/#setBorderVertical) controlla i bordi verticali delle celle.
- [setBorderOutline](https://reference.aspose.com/slides/it/python-java/aspose.slides/datatable/#setBorderOutline) controlla il bordo esterno della tabella.

Passa `True` a ciascun metodo per visualizzare i suoi bordi oppure `False` per nasconderli. L'esempio seguente crea un grafico a colonne raggruppate con dati predefiniti, visualizza i bordi orizzontali e il bordo esterno e nasconde i bordi verticali. Non richiede alcun file di input. La posizione e le dimensioni del grafico sono specificate in punti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il confronto sottostante utilizza gli stessi dati del grafico e l'impostazione della chiave della legenda in tutti e quattro i casi. Partendo da tutti i bordi abilitati, ogni variante rimanente disabilita solo un'impostazione del bordo. La variante in basso a sinistra corrisponde alle impostazioni dei bordi nell'esempio.

![Tabelle dei dati del grafico con tutti i bordi abilitati, senza bordi orizzontali, senza bordi verticali e senza bordo esterno](data-table-borders.png)

## **Mostrare o nascondere le chiavi della legenda**

Le chiavi della legenda sono piccoli marcatori colorati accanto ai nomi delle serie nella tabella dei dati. Aiutano i lettori a collegare ogni riga della tabella a una serie del grafico. Passa `True` a [setShowLegendKey](https://reference.aspose.com/slides/it/python-java/aspose.slides/datatable/#setShowLegendKey) per mostrare questi marcatori o `False` per nasconderli.

La legenda separata del grafico è controllata da [Chart.setLegend](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setLegend). Queste impostazioni sono indipendenti: nascondere la legenda separata non nasconde le chiavi all'interno della tabella dei dati, e nascondere le chiavi della tabella non nasconde la legenda separata.

L'esempio seguente crea un grafico con dati predefiniti, abilita la sua tabella dei dati e mostra le chiavi della legenda all'interno di essa nascondendo la legenda separata. Tutti i bordi della tabella sono esplicitamente abilitati. Non è necessaria alcuna presentazione di input. Per nascondere solo le chiavi della tabella, passa `False` a [setShowLegendKey](https://reference.aspose.com/slides/it/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il confronto sottostante mostra la stessa tabella con le chiavi della legenda abilitate e disabilitate. Tutti i bordi rimangono abilitati e la legenda separata del grafico è nascosta in entrambi i casi.

![Tabelle dei dati del grafico con le chiavi della legenda mostrate a sinistra e nascoste a destra](data-table-legend-keys.png)

## **FAQ**

**Posso mostrare le chiavi della legenda nella tabella dei dati di un grafico?**

Sì. Passa `True` a [setShowLegendKey](https://reference.aspose.com/slides/it/python-java/aspose.slides/datatable/#setShowLegendKey) per visualizzare le chiavi della legenda o `False` per nasconderle.

**La tabella dei dati sarà preservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico e la sua tabella dei dati mostrata come parte della diapositiva durante l'esportazione in [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/it/python-java/convert-powerpoint-to-html/), o [immagini](/slides/it/python-java/convert-powerpoint-to-png/).

**Posso lavorare con le tabelle dei dati nei grafici caricati da un modello?**

Sì. Per un grafico caricato da una presentazione o modello esistente, usa [hasDataTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#hasDataTable) e [setDataTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setDataTable) per verificare o modificare se la sua tabella dei dati è visualizzata.

**Come posso trovare i grafici che hanno la tabella dei dati abilitata?**

Itera attraverso le forme su ogni diapositiva, identifica i grafici e chiama il loro metodo [hasDataTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#hasDataTable). Un valore `True` indica che la tabella dei dati è abilitata.