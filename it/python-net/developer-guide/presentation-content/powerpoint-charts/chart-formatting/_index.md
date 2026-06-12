---
title: Formattare i Grafici nelle Presentazioni con Python
linktitle: Formattazione del Grafico
type: docs
weight: 60
url: /it/python-net/chart-formatting/
keywords:
- formattare grafico
- formattazione del grafico
- entità del grafico
- proprietà del grafico
- impostazioni del grafico
- opzioni del grafico
- proprietà dei caratteri
- bordo arrotondato
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Impara la formattazione dei grafici in Aspose.Slides per Python tramite .NET e migliora la tua presentazione PowerPoint o OpenDocument con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come assi, linee della griglia, titoli, legende, area del grafico e riempimenti delle pareti, per migliorare l'aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà dei caratteri per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati nei grafici di una presentazione.

## **Formattare gli Elementi del Grafico**

Aspose.Slides per Python consente agli sviluppatori di aggiungere grafici personalizzati alle proprie diapositive da zero. Questa sezione spiega come formattare vari elementi del grafico, inclusi gli assi di categoria e di valore.

Aspose.Slides fornisce un'API semplice per gestire gli elementi del grafico e applicare formattazioni personalizzate:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva per indice.
1. Aggiungi un grafico con dati predefiniti del tipo desiderato (in questo esempio, `ChartType.LINE_WITH_MARKERS`).
1. Accedi all'asse dei valori del grafico e imposta quanto segue:
   1. Imposta il **formato della linea** per le linee della griglia principale dell'asse dei valori.
   1. Imposta il **formato della linea** per le linee della griglia secondaria dell'asse dei valori.
   1. Imposta il **formato numerico** per l'asse dei valori.
   1. Imposta le **unità min, max, principali e secondarie** per l'asse dei valori.
   1. Imposta le **proprietà del testo** per le etichette dell'asse dei valori.
   1. Imposta il **titolo** per l'asse dei valori.
   1. Imposta il **formato della linea** per l'asse dei valori.
1. Accedi all'asse delle categorie del grafico e imposta quanto segue:
   1. Imposta il **formato della linea** per le linee della griglia principale dell'asse delle categorie.
   1. Imposta il **formato della linea** per le linee della griglia secondaria dell'asse delle categorie.
   1. Imposta le **proprietà del testo** per le etichette dell'asse delle categorie.
   1. Imposta il **titolo** per l'asse delle categorie.
   1. Imposta il **posizionamento delle etichette** per l'asse delle categorie.
   1. Imposta l'**angolo di rotazione** per le etichette dell'asse delle categorie.
1. Accedi alla legenda del grafico e imposta le sue **proprietà del testo**.
1. Mostra la legenda del grafico senza sovrapporsi al grafico.
1. Accedi al **secondario asse dei valori** del grafico e imposta quanto segue:
   1. Abilita il secondario **asse dei valori**.
   1. Imposta il **formato della linea** per il secondario asse dei valori.
   1. Imposta il **formato numerico** per il secondario asse dei valori.
   1. Imposta le **unità min, max, principali e secondarie** per il secondario asse dei valori.
1. Traccia la prima serie del grafico sull'asse dei valori secondario.
1. Imposta il colore di riempimento della parete posteriore del grafico.
1. Imposta il colore di riempimento dell'area del grafico.
1. Scrivi la presentazione modificata in un file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanziare la classe Presentation.
with slides.Presentation() as presentation:

    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere un grafico di esempio.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Impostare il titolo del grafico.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Impostare il formato della linea della griglia principale per l'asse dei valori.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Impostare il formato della linea della griglia secondaria per l'asse dei valori.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Impostare il formato numerico dell'asse dei valori.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Impostare il valore massimo, minimo, unità principale e unità secondaria dell'asse dei valori.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Impostare le proprietà del testo dell'asse dei valori.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Impostare il titolo dell'asse dei valori.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Impostare il formato della linea della griglia principale per l'asse delle categorie.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Impostare il formato della linea della griglia secondaria per l'asse delle categorie.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Impostare le proprietà del testo dell'asse delle categorie.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Impostare il titolo dell'asse delle categorie.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Impostare la posizione delle etichette dell'asse delle categorie.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Impostare l'angolo di rotazione delle etichette dell'asse delle categorie.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Impostare le proprietà del testo della leggenda.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Mostrare la leggenda del grafico sovrapponendola al grafico.
    chart.legend.overlay = True
                
    # Impostare il colore della parete posteriore del grafico.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Impostare il colore dell'area del grafico.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Salvare la presentazione.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare le Proprietà dei Caratteri del Grafico**

Aspose.Slides per Python supporta l'impostazione delle proprietà correlate ai caratteri per i grafici. Segui i passaggi seguenti per configurare le proprietà dei caratteri del grafico:

1. Crea un'istanza di un oggetto [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Aggiungi un grafico alla diapositiva.
1. Imposta l'altezza del carattere.
1. Salva la presentazione modificata.

Di seguito è fornito un esempio di codice.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare il Formato Numerico**

Aspose.Slides per Python fornisce un'API semplice per gestire i formati dei dati del grafico:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva per indice.
1. Aggiungi un grafico con dati predefiniti di qualsiasi tipo desiderato.
1. Imposta un formato numerico predefinito dai valori predefiniti disponibili.
1. Scorri le celle dei dati del grafico in ogni serie e imposta il formato numerico.
1. Salva la presentazione.
1. Imposta un formato numerico personalizzato.
1. Scorri le celle dei dati del grafico in ogni serie e imposta un formato numerico diverso.
1. Salva la presentazione.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Istanziare la classe Presentation.
with slides.Presentation() as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere un grafico a colonne raggruppate predefinito.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Impostare il formato numerico predefinito.
    # Scorrere ogni serie del grafico.
    for series in chart.chart_data.series:
        # Scorrere ogni punto dati nella serie.
        for cell in series.data_points:
            # Impostare il formato numerico.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Salvare la presentazione.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

I formati numerici predefiniti disponibili e i loro indici corrispondenti sono elencati di seguito.

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

## **Impostare i Bordi Arrotondati per l'Area del Grafico**

Aspose.Slides per Python supporta la configurazione dell'area del grafico mediante la proprietà `Chart.has_rounded_corners`.

1. Crea un'istanza di un oggetto [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Aggiungi un grafico alla diapositiva.
3. Imposta il tipo di riempimento e il colore di riempimento del grafico.
4. Imposta la proprietà rounded-corners a `True`.
5. Salva la presentazione modificata.

Di seguito è fornito un esempio.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso impostare riempimenti semi‑trasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Riduci la dimensione del carattere, disabilita componenti di etichetta non essenziali (ad esempio le categorie), imposta lo scostamento/posizione dell'etichetta, mostra le etichette solo per i punti selezionati se necessario, oppure passa al formato “valore + legenda”.

**Posso applicare riempimenti a gradiente o a trama alle serie?**

Sì. Sono generalmente disponibili sia riempimenti solidi sia a gradiente/figura. In pratica, utilizza i gradienti con parsimonia e evita combinazioni che riducono il contrasto con la griglia e il testo.