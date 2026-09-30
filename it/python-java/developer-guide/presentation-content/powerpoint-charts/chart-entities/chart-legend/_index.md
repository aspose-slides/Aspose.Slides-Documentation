---
title: Personalizza le legende dei grafici nelle presentazioni usando Python
linktitle: Legenda del grafico
type: docs
url: /it/python-java/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per Python via Java per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides for Python via Java offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l’intera legenda, formattare una voce di legenda individuale e nascondere o ripristinare voci selezionate.

La FAQ copre comportamenti correlati, inclusa la riserva di spazio per la legenda, la visualizzazione di etichette multilinea e l’ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della leggenda**

Utilizzare i metodi della legenda [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) e [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) per specificare la sua posizione e dimensione come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti alla prima diapositiva. Dividendo gli offset e le dimensioni desiderate della legenda per la larghezza e l’altezza del grafico, si ottengono valori relativi: la legenda è spostata di 50 punti dall’angolo in alto a sinistra del grafico e dimensionata a 100 × 100 punti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Espressione della posizione e delle dimensioni della legenda rispetto al grafico.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare la dimensione del carattere di una leggenda**

Utilizzare la legenda [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) per accedere alla formattazione del testo e [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) per impostare la dimensione del carattere in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della legenda a 20 punti. Disattiva inoltre i limiti automatici per l’asse verticale e imposta il suo intervallo da -5 a 10.

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

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare la dimensione del carattere di una voce di leggenda individuale**

Utilizzare la collezione restituita dal metodo [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) della legenda per accedere alla formattazione di una voce specifica. Gli indici delle voci partono da zero, quindi l’indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate il cui set di dati predefinito include almeno due serie. Formatta la seconda voce della leggenda con testo in grassetto, corsivo e colore blu a 20 punti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nascondere le voci di leggenda individuali**

Per escludere una serie ausiliaria dalla leggenda mantenendo i suoi dati visibili, chiamare [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) con `True` tramite [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Questo nasconde solo la voce di leggenda selezionata; non rimuove la serie né i suoi punti dati. Invece, chiamare [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) con `False` nasconde l’intera leggenda.

L’esempio seguente crea un grafico a colonne raggruppate con più serie usando dati predefiniti. Nasconde la voce di leggenda della seconda serie (indice `1`) e salva la presentazione. Successivamente ripristina la voce chiamando [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) con `False` e salva una seconda copia. Le colonne rimangono visibili in entrambi i file.

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
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Ripristina la stessa voce senza modificare i dati del grafico.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il confronto sotto mostra lo stesso grafico con tutte le voci visibili e con la seconda voce nascosta. Le colonne della seconda serie rimangono inalterate.

![Confronto di un grafico con tutte le voci della leggenda visibili e con la Serie 2 nascosta dalla legenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

In grafici a colonne, barre e linee, le voci della leggenda identificano le serie. Nei grafici a torta, identificano i singoli punti dati (fette), quindi utilizzare [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) sulla fetta selezionata. L’API documenta questo metodo per i tipi di grafico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Non presumere che sia valido per i grafici a ciambella, che non sono inclusi in tale elenco.

## **FAQ**

**Posso far sì che il grafico riservi spazio per la leggenda invece di sovrapporla?**

Sì. Chiamare [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) con `False` per riservare spazio alla leggenda invece di permettere la sovrapposizione all’area del grafico.

**Posso creare etichette della leggenda multilinea?**

Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. È inoltre possibile utilizzare caratteri di nuova riga nei nomi delle serie per richiedere interruzioni di riga.

**Come faccio a far sì che la leggenda segua lo schema di colori del tema della presentazione?**

Lasciare i colori, i riempimenti e i caratteri della leggenda non impostati, così da consentire l’ereditarietà della formattazione del tema. Una formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.