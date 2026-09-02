---
title: Gestisci Tabelle di Presentazione con Python
linktitle: Gestisci Tabella
type: docs
weight: 10
url: /it/python-net/manage-table/
keywords:
- aggiungi tabella
- crea tabella
- accedi tabella
- rapporto d'aspetto
- allinea testo
- formattazione testo
- stile tabella
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e modifica tabelle in diapositive PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET. Scopri semplici esempi di codice per semplificare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per presentare informazioni. Le informazioni disposte in una griglia di celle (righe e colonne) sono semplici e facili da capire.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/), la classe [Cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/) e altri tipi correlati per aiutarti a creare, aggiornare e gestire tabelle in qualsiasi presentazione.

## **Creare tabelle da zero**

Questa sezione mostra come creare una tabella da zero in Aspose.Slides aggiungendo una forma di tabella a una diapositiva, definendo le sue righe e colonne e impostando dimensioni precise. Vedrai anche come riempire le celle con testo, regolare l'allineamento e i bordi e personalizzare l'aspetto della tabella.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per il suo indice.
3. Definisci un array di larghezze delle colonne.
4. Definisci un array di altezze delle righe.
5. Aggiungi una [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) alla diapositiva.
6. Itera su ogni [Cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/) e formatta i bordi superiore, inferiore, destro e sinistro.
7. Unisci le celle delle prime due righe e delle prime due colonne in un'unica cella.
8. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) di una [Cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/).
9. Aggiungi testo al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
10. Salva la presentazione modificata.

Il seguente esempio Python mostra come creare una tabella in una presentazione:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Istanziate la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    # Accedete alla prima diapositiva.
    slide = presentation.slides[0]

    # Definite le larghezze delle colonne e le altezze delle righe.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Aggiungete una forma di tabella alla diapositiva.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Impostate il formato del bordo per ciascuna cella.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Unire le celle da (riga 0, col 0) a (riga 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Aggiungete testo alla cella unita.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Salvate la presentazione su disco.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numerazione nelle tabelle standard**

In una tabella standard, la numerazione delle celle è semplice e basata su zero. La prima cella di una tabella è indicizzata come (0, 0) (colonna 0, riga 0).

Ad esempio, in una tabella con 4 colonne e 4 righe, le celle sono numerate come segue:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Il seguente esempio Python mostra come fare riferimento alle celle usando questa numerazione a zero:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una tabella con 4 colonne e 4 righe.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere a una tabella esistente**

Questa sezione spiega come individuare e lavorare con una tabella esistente in una presentazione usando Aspose.Slides. Imparerai come trovare la tabella su una diapositiva, accedere alle sue righe, colonne e celle e aggiornare contenuti o formattazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva che contiene la tabella per il suo indice.
3. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) finché non trovi la tabella.
4. Usa l'oggetto [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) per lavorare con la tabella.
5. Salva la presentazione modificata.

{{% alert color="info" title="Nota" %}}
Se la diapositiva contiene diverse tabelle, è meglio cercare la tabella necessaria tramite la sua proprietà `alternative_text`.
{{% /alert %}}

Il seguente esempio Python mostra come accedere e lavorare con una tabella esistente:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Istanziate la classe Presentation per caricare un file PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Accedete alla prima diapositiva.
    slide = presentation.slides[0]

    table = None

    # Iterate attraverso le forme e fa riferimento alla prima tabella trovata.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Imposta il testo della prima cella nella prima riga.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Salva la presentazione modificata su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Trova la cella che possiede un TextFrame**

Quando del codice generico di elaborazione del testo riceve un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) da una tabella, usa la proprietà [TextFrame.parent_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_cell/) per recuperare la [Cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/) proprietaria. Per un TextFrame di una cella di tabella, [TextFrame.parent_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_cell/) è impostata e [TextFrame.parent_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_shape/) è `None`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite le proprietà di sola lettura [Cell.first_column_index](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/first_column_index/) e [Cell.first_row_index](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/first_row_index/). Anche [TextFrame.parent_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_cell/) è di sola lettura: fornisce la navigazione al proprietario ma non ne cambia la proprietà. Verifica sempre che la cella restituita non sia `None` prima di usarla.

Per un esempio completo che identifica i proprietari di celle di tabella e di forme, incluse le forme associate a nodi SmartArt, vedi [Search and Replace Text](/slides/it/python-net/search-and-replace-text/).

## **Allineare il testo nelle tabelle**

Questa sezione mostra come controllare il posizionamento del testo all'interno delle celle di una tabella usando Aspose.Slides. Imparerai a ancorare il testo verticalmente in una cella e a modificare la direzione in cui il testo scorre.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva per il suo indice.
3. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) alla diapositiva.
4. Accedi a un oggetto [Cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/) della tabella.
5. Centra il testo verticalmente nella cella e imposta la direzione del testo.
6. Salva la presentazione modificata.

Il seguente esempio Python mostra come allineare il testo in una tabella:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Aggiungi una forma di tabella alla diapositiva.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Centra il testo e imposta l'orientamento verticale.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Salva la presentazione su disco.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la formattazione del testo a livello di tabella**

Questa sezione mostra come applicare la formattazione del testo a livello di tabella in Aspose.Slides affinché ogni cella erediti uno stile coerente e unificato. Imparerai a impostare le dimensioni dei caratteri, gli allineamenti e i margini in modo globale.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva per il suo indice.
3. Aggiungi una [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) alla diapositiva.
4. Imposta la dimensione del carattere (altezza del font) per il testo.
5. Imposta l'allineamento del paragrafo e i margini.
6. Imposta l'orientamento verticale del testo.
7. Salva la presentazione modificata.

Il seguente esempio Python mostra come applicare le opzioni di formattazione preferite al testo in una tabella:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea un'istanza della classe Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Imposta la dimensione del carattere per tutte le celle della tabella.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Imposta il testo allineato a destra e un margine destro per tutte le celle della tabella.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Imposta l'orientamento verticale del testo per tutte le celle della tabella.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicare gli stili di tabella predefiniti**

Aspose.Slides consente di formattare le tabelle usando stili predefiniti direttamente nel codice. L'esempio dimostra come creare una tabella, applicare uno stile integrato e salvare il risultato—un modo efficace per garantire una formattazione coerente e professionale.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Bloccare il rapporto d'aspetto delle tabelle**

Il rapporto d'aspetto di una forma è il rapporto tra le sue dimensioni. Aspose.Slides fornisce la proprietà `aspect_ratio_locked`, che consente di bloccare il rapporto d'aspetto per tabelle e altre forme.

Il seguente esempio Python mostra come bloccare il rapporto d'aspetto per una tabella:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone una proprietà [right_to_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/right_to_left/), e i paragrafi hanno [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/right_to_left/). Usare entrambe garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa [shape locks](/slides/it/python-net/applying-protection-to-presentation/) per disabilitare spostamento, ridimensionamento, selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**L'inserimento di un'immagine all'interno di una cella come sfondo è supportato?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).