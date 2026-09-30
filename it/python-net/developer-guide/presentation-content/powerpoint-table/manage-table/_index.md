---
title: Gestire le tabelle delle presentazioni con Python
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/python-net/manage-table/
keywords:
- aggiungi tabella
- crea tabella
- accedi tabella
- rapporto d'aspetto
- allinea testo
- formattazione del testo
- stile della tabella
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e modifica tabelle in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python su .NET. Scopri esempi di codice semplici per semplificare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Le tabelle in PowerPoint organizzano le informazioni in righe e colonne, facilitando la lettura e il confronto dei valori.

Aspose.Slides fornisce le classi [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) e [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) e altri tipi per consentire di creare, aggiornare e gestire le tabelle nelle presentazioni.

## **Crea una tabella da zero**

Crea una tabella specificando la sua posizione, le larghezze delle colonne e le altezze delle righe. Dopo averla aggiunta a una diapositiva, puoi formattare i bordi delle celle, unire le celle e inserire testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva per indice.
3. Definisci un elenco di larghezze delle colonne in punti.
4. Definisci un elenco di altezze delle righe in punti.
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) alla diapositiva tramite il metodo [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Itera attraverso ogni [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella.
8. Accedi alla cella unita tramite la sua proprietà [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Imposta il testo nella cella unita.
10. Salva la presentazione modificata.

L'esempio seguente crea una tabella con tre colonne e cinque righe in (100, 50) punti. Applica bordi rossi con larghezza di 5 punti, unisce le prime due celle nella prima riga e salva il risultato come `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numerazione in una tabella standard**

In una tabella standard, gli indici delle celle sono basati su zero e usano l'ordine (colonna, riga). La prima cella ha indice (0, 0). In Python, accedi a una cella con `table.rows[row_index][column_index]`; l'indice di riga viene prima in questa espressione.

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate così:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo esempio crea la tabella 4 × 4 illustrata sopra, con larghezze delle colonne e altezze delle righe di 70 punti e bordi rossi di 5 punti. Le coordinate illustrano gli indici delle celle; l'esempio lascia le celle vuote e salva la tabella come `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a una tabella esistente**

Le tabelle sono memorizzate nella raccolta di forme di una diapositiva. Itera tra le forme per individuare una tabella, quindi utilizza la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) per leggere o aggiornare le sue celle.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva che contiene la tabella per indice.
3. Itera attraverso gli oggetti [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) e interrompi quando trovi una tabella. Se la diapositiva contiene più tabelle, usa [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) per identificare quella necessaria.
4. Aggiorna il testo nella cella di destinazione.
5. Salva la presentazione modificata.

L'esempio seguente apre `UpdateExistingTable.pptx` e trova la prima tabella nella prima diapositiva. Imposta la cella alla colonna 0, riga 1 su `New` e salva il risultato come `table1_out.pptx`. L'input deve contenere almeno una diapositiva e la prima tabella su quella diapositiva deve avere almeno una colonna e due righe.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Per ridimensionare una riga in una tabella esistente e capire perché la sua altezza reale può superare il minimo richiesto, consulta [Control Row Height](/slides/it/python-net/manage-rows-and-columns/#control-row-height).

## **Trova la cella che possiede un TextFrame**

Quando del codice generico di elaborazione del testo riceve un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) da una tabella, usa la proprietà [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) per recuperare la [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) proprietaria. Per un TextFrame di cella di tabella, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) è impostato e [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) è `None`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite le proprietà di sola lettura [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) e [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). Anche [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) è di sola lettura: fornisce la navigazione al proprietario ma non ne cambia la proprietà. Verifica sempre che la cella restituita non sia `None` prima di usarla.

Per un esempio completo che identifica i proprietari di celle di tabella e di forme, incluse le forme associate ai nodi di SmartArt, consulta [Search and Replace Text](/slides/it/python-net/search-and-replace-text/).

## **Allinea il testo in una tabella**

Puoi controllare l'ancoraggio verticale e la direzione del testo di singole celle di tabella. L'esempio in questa sezione centra il testo nella prima cella e lo ruota di 270 gradi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva per indice.
3. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) alla diapositiva.
4. Accedi a un oggetto [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) dalla tabella.
5. Accedi al primo [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) e imposta il suo testo e colore.
6. Imposta le proprietà [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) e [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) della cella.
7. Salva la presentazione modificata.

Questo esempio crea una tabella 4 × 4 con larghezze di colonna di 120 punti e altezze di riga di 100 punti. Formatta il testo nella cella (0, 0), aggiunge valori alle celle rimanenti nella prima riga e salva il risultato come `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la formattazione del testo a livello di tabella**

Usa [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) per applicare la formattazione del testo a tutte le celle di una tabella. Le sue overload accettano la formattazione di porzione, paragrafo e frame di testo, così puoi impostare queste proprietà senza iterare tra le singole celle.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva per indice.
3. Accedi a un oggetto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) dalla diapositiva.
4. Imposta il [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) per il testo.
5. Imposta [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) e [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Imposta [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Salva la presentazione modificata.

L'esempio seguente apre `table.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Imposta la dimensione del carattere a 25 punti, allinea a destra i paragrafi con un margine destro di 20 punti e rende il testo verticale. La presentazione formattata viene salvata come `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottieni le proprietà di stile della tabella**

Usa [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) per leggere o assegnare lo stile predefinito di una tabella. Questo esempio applica [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) a una tabella, stampa il nome del preset e assegna lo stesso preset a una seconda tabella. Entrambe le tabelle vengono salvate in `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Blocca il rapporto di aspetto di una tabella**

Il rapporto di aspetto di una tabella è il rapporto tra la sua larghezza e la sua altezza. Usa [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) per bloccare questo rapporto per una tabella.

L'esempio seguente apre `pres.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Stampa lo stato corrente del blocco, abilita il blocco del rapporto di aspetto, stampa lo stato aggiornato (`True`) e salva il risultato come `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e per il testo nelle sue celle?**

Sì. La tabella espone la proprietà [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), e i paragrafi hanno [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Usare entrambe garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa [shape locks](/slides/it/python-net/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. queste restrizioni si applicano anche alle tabelle.

**È supportata l'inserzione di un'immagine all'interno di una cella come sfondo?**

Sì. Puoi impostare un [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).