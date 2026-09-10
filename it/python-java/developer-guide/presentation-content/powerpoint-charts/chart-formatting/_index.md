---
title: Formattare i grafici delle presentazioni in Python
linktitle: Formattazione dei grafici
type: docs
weight: 60
url: /it/python-java/chart-formatting/
keywords:
- formattare grafico
- formattazione grafico
- entità del grafico
- proprietà del grafico
- impostazioni del grafico
- opzioni del grafico
- proprietà del carattere
- bordo arrotondato
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara a formattare i grafici in Aspose.Slides per Python via Java e migliora la tua presentazione PowerPoint con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come gli assi, le linee della griglia, i titoli, le legende, l'area di tracciamento e i riempimenti delle pareti, per migliorare l'aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà dei caratteri per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

## **Formattare le entità del grafico**
Aspose.Slides per Python via Java consente agli sviluppatori di aggiungere grafici personalizzati alle loro diapositive da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi gli assi delle categorie e dei valori.

Aspose.Slides per Python via Java fornisce un'API semplice per gestire diverse entità del grafico e formattarle usando valori personalizzati:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Accedere a una diapositiva tramite il suo indice.
1. Aggiungere un grafico del tipo desiderato con dati predefiniti (questo esempio utilizza [ChartType.LineWithMarkers](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/#LineWithMarkers)) .
1. Accedere all'asse dei valori del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse dei valori.
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse dei valori.
   1. Impostare **Number Format** per l'asse dei valori.
   1. Impostare **minimum, maximum, major, and minor units** per l'asse dei valori.
   1. Impostare **Text Properties** per i dati dell'asse dei valori.
   1. Impostare **Title** per l'asse dei valori.
1. Accedere all'asse delle categorie del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse delle categorie.
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse delle categorie.
   1. Impostare **Text Properties** per i dati dell'asse delle categorie.
   1. Impostare **Title** per l'asse delle categorie.
   1. Impostare **Label Positioning** per l'asse delle categorie.
   1. Impostare **Rotation Angle** per le etichette dell'asse delle categorie.
1. Accedere alla leggenda del grafico e impostare le sue **text properties**.
1. Mostrare la leggenda del grafico senza sovrapporsi al grafico.
1. Accedere all'**secondary value axis** del grafico e impostare le seguenti proprietà:
   1. Abilitare l'**value axis** secondario.
   1. Impostare **Line Format** per l'asse dei valori secondario.
   1. Impostare **Number Format** per l'asse dei valori secondario.
   1. Impostare **minimum, maximum, major, and minor units** per l'asse dei valori secondario.
1. Tracciare la prima serie del grafico sull'asse dei valori secondario.
1. Impostare il colore di riempimento della parete posteriore del grafico.
1. Impostare il colore di riempimento dell'area di tracciamento del grafico.
1. Scrivere la presentazione modificata in un file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Crea un'istanza della classe Presentation
presentation = Presentation()
try:
    # Accedi alla prima diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi il grafico di esempio
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Imposta il titolo del grafico
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Imposta il formato delle linee della griglia principale per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Imposta il formato delle linee della griglia secondaria per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Imposta il formato numerico dell'asse dei valori
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Imposta i valori massimo e minimo del grafico
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Imposta le proprietà del testo dell'asse dei valori
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Imposta il titolo dell'asse dei valori
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Imposta il formato delle linee della griglia principale per l'asse delle categorie
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Imposta il formato delle linee della griglia secondaria per l'asse delle categorie
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Imposta le proprietà del testo dell'asse delle categorie
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Imposta il titolo della categoria
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Imposta la posizione dell'etichetta dell'asse delle categorie
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Imposta l'angolo di rotazione dell'etichetta dell'asse delle categorie
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Imposta le proprietà del testo della legenda
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Mostra la legenda del grafico senza sovrapporla al grafico

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Imposta l'asse dei valori secondario
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Imposta il formato numerico dell'asse dei valori secondario
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Imposta i valori massimo e minimo del grafico
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Imposta il colore della parete posteriore del grafico
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Imposta il colore dell'area di tracciamento
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Save the presentation
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare le proprietà del carattere per un grafico**
Aspose.Slides per Python via Java supporta l'impostazione delle proprietà del carattere per i grafici. Segui questi passaggi per impostare le proprietà del carattere:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
- Aggiungere un grafico alla diapositiva.
- Impostare l'altezza del carattere.
- Salvare la presentazione modificata.

Il seguente esempio dimostra questi passaggi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crea un'istanza della classe Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare il formato numerico**
Aspose.Slides per Python via Java fornisce un'API semplice per gestire i formati dei dati dei grafici:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Accedere a una diapositiva tramite il suo indice.
1. Aggiungere un grafico del tipo desiderato con dati predefiniti (questo esempio utilizza [ChartType.ClusteredColumn](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/#ClusteredColumn)) .
1. Impostare il formato numerico predefinito tra i valori predefiniti disponibili.
1. Iterare tra le celle dati di ogni serie del grafico e impostare il loro formato numerico.
1. Salvare la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crea un'istanza della classe Presentation
presentation = Presentation()
try:
    # Accedi alla prima diapositiva della presentazione
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un grafico a colonna raggruppata predefinito
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Accedi alla collezione delle serie del grafico
    chart_series_collection = chart.getChartData().getSeries()

    # Itera attraverso ogni serie del grafico
    for chart_series in chart_series_collection:
        # Itera attraverso ogni punto dati nella serie
        for data_point in chart_series.getDataPoints():
            # Imposta il formato numerico
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Salva la presentazione
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

I formati numerici predefiniti disponibili e i loro indici sono elencati di seguito:

|**0**|Generale|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Impostare bordi arrotondati dell'area del grafico**
Aspose.Slides per Python via Java supporta gli angoli arrotondati per l'area del grafico tramite i metodi [hasRoundedCorners](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#hasRoundedCorners) e [setRoundedCorners](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#setRoundedCorners) della classe [Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/) .

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Aggiungere un grafico alla diapositiva.
1. Impostare il tipo di riempimento e lo stile della linea del bordo del grafico.
1. Abilitare gli angoli arrotondati.
1. Salvare la presentazione modificata.

Il seguente esempio dimostra questi passaggi.

```python
import jpype
import asposeslides

if not jpace.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Crea un'istanza della classe Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso impostare riempimenti semitrasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno vengono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni densamente popolate.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Ridurre la dimensione del carattere, disabilitare componenti di etichetta non essenziali (ad esempio, le categorie), impostare l'offset/posizione dell'etichetta, mostrare le etichette solo per i punti selezionati se necessario, oppure cambiare il formato in "valore + legenda".

**Posso applicare riempimenti a gradiente o a pattern alle serie?**

Sì. Sia i riempimenti solidi che a gradiente/pattern sono generalmente disponibili. In pratica, utilizzare i gradienti con parsimonia ed evitare combinazioni che riducono il contrasto con la griglia e il testo.