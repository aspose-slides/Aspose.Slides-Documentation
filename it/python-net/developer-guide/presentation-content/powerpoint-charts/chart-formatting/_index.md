---
title: Formattare i grafici nelle presentazioni usando Python
linktitle: Formattazione del grafico
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
- proprietà del carattere
- bordo arrotondato
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara la formattazione dei grafici in Aspose.Slides per Python via .NET e migliora la tua presentazione PowerPoint con assi personalizzati, caratteri, formati numerici e bordi arrotondati del grafico."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come gli assi, le linee della griglia, i titoli, le legende, l'area del tracciato e i riempimenti delle pareti, per migliorare l'aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

Per riempimenti e contorni separati su intervalli in aumento e in diminuzione, vedere l'[esempio di grafico azionario](/slides/it/python-net/create-chart/#create-stock-charts).

## **Formattare gli elementi del grafico**

Utilizzare [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) per formattare i titoli dei grafici, gli assi, le linee della griglia, le legende e l'area del tracciato. Questo esempio crea un grafico a linee con marcatori e dati predefiniti, quindi applica stili di testo e di linea separati ai suoi assi dei valori e delle categorie. Le dimensioni del carattere e le larghezze della linea sono specificate in punti; le etichette delle categorie sono ruotate di 45 gradi.

L'asse dei valori utilizza [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) indipendentemente dalle celle di origine. La sua scala va da -2 a 15, con intervalli principali di 2 e intervalli secondari di 0,5. L'esempio combina anche la formattazione percentuale con [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) impostato su migliaia, quindi adatta queste impostazioni al significato e alla grandezza dei tuoi dati. La legenda rimane fuori dall'area del tracciato perché [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) è disabilitato. I riempimenti del retro-parete e del pavimento sono configurati tramite [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) e [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), ma queste superfici sono visibili solo nei grafici 3D.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare le proprietà del carattere per un grafico**

Impostare la dimensione predefinita del carattere per il testo del grafico tramite [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). L'esempio crea un grafico a colonne raggruppate con un carattere da 20 punti e abilita le etichette dei valori per la prima serie tramite [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Gli elementi di testo con impostazioni di carattere esplicite possono sovrascrivere il valore predefinito del grafico.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Riutilizzare la formattazione del riquadro di testo per la legenda di un grafico**

Per abbinare una legenda a un'intestazione di diapositiva, impostare il carattere tramite [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) sul primo paragrafo dell'intestazione. Chiamare [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) sul [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) della legenda. Copia le impostazioni del riquadro di testo, la formattazione del primo paragrafo e le proprietà di carattere predefinite di quel paragrafo. La formattazione applicata direttamente a porzioni individuali o a paragrafi successivi rimane locale alla fonte.

L'esempio utilizza un'intestazione in grassetto, colore navy, Calibri da 26 punti come modello. Dopo aver stilizzato la legenda, utilizza [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) per applicare la stessa formattazione a una didascalia separata.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

Nella presentazione salvata, la legenda e la didascalia corrispondono all'intestazione per dimensione, peso e colore. La legenda visualizza ancora i nomi delle serie, e la didascalia mantiene il proprio testo. Se una porzione nella didascalia ha già una dimensione del carattere esplicita, tale dimensione ha la precedenza sul valore predefinito del paragrafo copiato.

| Prima della copia | Dopo la copia |
| --- | --- |
| ![Grafico delle vendite trimestrali con etichette della legenda nere regolari e una didascalia nera](legend-formatting-before.png) | ![Lo stesso grafico con etichette della legenda più grandi, in grassetto, colore navy, e una didascalia corrispondente](legend-formatting.png) |

## **Impostare il formato numerico**

Utilizzare [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) per applicare un formato numerico predefinito alle celle della cartella di lavoro del grafico. Questo esempio crea un grafico a colonne raggruppate con dati predefiniti basati su celle e applica l'indice di formato 10 (`0.00%`) a ciascuna cella del valore di serie. Questo cambia il modo in cui i valori sono visualizzati nella cartella di lavoro senza alterare i numeri sottostanti; ad esempio, 0,25 viene visualizzato come 25,00%. I formati degli assi e delle etichette dei dati possono essere configurati separatamente.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0,00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

La tabella seguente elenca gli indici dei formati numerici predefiniti con i corrispondenti formati Excel rappresentativi per la località English (United States). Le stringhe di formato esatte e la loro visualizzazione possono variare in base all'applicazione e alla località, in particolare per valute e date. Alcuni formati Excel differiscono anche dai valori predefiniti nello standard OOXML, come descritto nelle [note di implementazione del formato numerico di Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indice | Formato |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Impostare i bordi arrotondati dell'area del grafico**

Abilitare [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) per arrotondare gli angoli dell'area del grafico. L'esempio crea un grafico a colonne raggruppate e utilizza [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) per dare al suo contorno un colore grigio solido e uno stile a linea singola prima di salvare la presentazione.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Modificare le annotazioni di un grafico esistente**

Un grafico può contenere forme personalizzate, come un'annotazione di testo che spiega lo stato di un report. Accedere a queste forme tramite [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). La sua collezione [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) contiene le forme possedute dal grafico.

Una casella di testo ordinaria posizionata sopra un grafico appartiene alla diapositiva, anche se sembra parte del grafico. Iterare attraverso [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) trova il grafico e le forme ordinarie della diapositiva, ma non elenca le singole forme all'interno del grafico. I titoli dei grafici e le etichette dei dati sono elementi del grafico separati, non annotazioni personalizzate in questa collezione.

Scaricare [chart-annotations.pptx](chart-annotations.pptx) e posizionarlo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene un grafico con un'annotazione non raggruppata che recita "Preliminary results", una linea di proprietà del grafico e una casella di testo di diapositiva ordinaria che recita "Slide overlay". L'esempio trova il primo grafico su quella diapositiva e cambia l'annotazione in "Final results" quando il report è pronto per la pubblicazione. Controlla una collezione vuota e modifica solo un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con un [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) che non è `None` e contiene il testo previsto.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

La linea e la casella di testo della diapositiva rimangono inalterate. Le immagini seguenti mostrano l'input e il risultato salvato e riaperto:

| Prima della modifica | Dopo la modifica |
| --- | --- |
| ![Annotazione del grafico con lettura "Preliminary results"](chart-annotations-before.png) | ![Annotazione del grafico con lettura "Final results"](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
L'esempio esamina solo le forme di primo livello possedute dal grafico. Se un'annotazione è all'interno di un [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), ispezionare anche la collezione [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) di quel gruppo. Ripetere ricorsivamente per i gruppi nidificati, applicando gli stessi controlli testuali alle forme figlie. Un gruppo è un contenitore; non considerarlo come una casella di testo.
{{% /alert %}}

## **FAQ**

**Posso impostare riempimenti semitrasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Ridurre la dimensione del carattere, disabilitare componenti non essenziali delle etichette (ad esempio, le categorie), regolare la posizione dell'etichetta, mostrare le etichette solo per i punti selezionati se necessario, o passare al formato "valore + legenda".

**Posso applicare riempimenti a gradiente o a motivo alle serie?**

Sì. Le serie supportano riempimenti solidi, a gradiente e a motivo. In pratica, utilizzare i gradienti con parsimonia ed evitare combinazioni che riducono il contrasto con la griglia e il testo.