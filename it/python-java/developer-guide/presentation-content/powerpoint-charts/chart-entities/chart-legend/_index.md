---
title: Personalizza le legende dei grafici nelle presentazioni usando Python
linktitle: Legenda del grafico
type: docs
url: /it/python-java/chart-legend/
keywords:
- legenda del grafico
- posizione della leggenda
- dimensione del carattere
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per Python via Java per ottimizzare le presentazioni PowerPoint con una formattazione della leggenda su misura."
---
## **Panoramica**

Aspose.Slides offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una leggenda, impostare la dimensione del carattere per l'intera leggenda e applicare la formattazione a una voce di leggenda individuale.

Copre inoltre diversi comportamenti correlati nella sezione FAQ, inclusa l'utilizzo della modalità non sovrapposta affinché l'area del grafico lasci spazio alla leggenda, consentendo alle etichette lunghe della leggenda di andare a capo o di utilizzare interruzioni di riga, e facendo sì che la formattazione della leggenda erediti il tema della presentazione quando non vengono impostati colori, riempimenti o caratteri espliciti.

## **Posizionamento della Leggenda**

Per impostare le proprietà della leggenda, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottenere un riferimento alla diapositiva.
3. Aggiungere un grafico alla diapositiva.
4. Impostare le proprietà della leggenda.
5. Salvare la presentazione come file PPTX.

Il seguente esempio imposta la posizione e le dimensioni di una leggenda del grafico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crea una presentazione vuota.
presentation = Presentation()
try:
    # Ottieni un riferimento alla diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un grafico a colonne raggruppate alla diapositiva.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Imposta le proprietà della leggenda.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Salva la presentazione su disco.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la dimensione del carattere di una leggenda**

Aspose.Slides per Python via Java consente di impostare la dimensione del carattere di una leggenda. Seguire questi passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Creare il grafico predefinito.
3. Impostare la dimensione del carattere.
4. Impostare il valore minimo dell'asse.
5. Impostare il valore massimo dell'asse.
6. Salvare la presentazione su disco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crea una presentazione vuota.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la dimensione del carattere di una voce di leggenda individuale**

Aspose.Slides per Python via Java consente di impostare la dimensione del carattere delle singole voci di leggenda. Seguire questi passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Creare il grafico predefinito.
3. Accedere a una voce della leggenda.
4. Impostare la dimensione del carattere.
5. Salvare la presentazione su disco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Crea una presentazione vuota.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso abilitare la leggenda in modo che il grafico assegni automaticamente spazio ad essa invece di sovrapporla?**

Sì. Utilizzare [setOverlay](https://reference.aspose.com/slides/it/python-java/aspose.slides/legend/#setOverlay) con `False` per abilitare la modalità non sovrapposta; in questo caso, l'area del grafico si ridurrà per ospitare la leggenda.

**Posso creare etichette della leggenda multilinea?**

Sì. Le etichette lunghe vanno a capo automaticamente quando lo spazio è insufficiente; le interruzioni di riga forzate sono supportate tramite caratteri di nuova riga nel nome della serie.

**Come faccio a far sì che la leggenda segua lo schema di colori del tema della presentazione?**

Non impostare colori, riempimenti o caratteri espliciti per la leggenda o il suo testo. In tal caso erediteranno dal tema e si aggiorneranno correttamente quando il design cambia.