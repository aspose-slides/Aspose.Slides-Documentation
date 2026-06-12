---
title: Gestire le tabelle di presentazione con Python
linktitle: Gestire tabella
type: docs
weight: 10
url: /it/python-net/manage-table/
keywords:
- aggiungi tabella
- creare tabella
- accedere tabella
- rapporto d'aspetto
- allineare testo
- formattazione testo
- stile tabella
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea e modifica tabelle in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET. Scopri semplici esempi di codice per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per presentare le informazioni. Le informazioni disposte in una griglia di celle (righe e colonne) sono chiare e facili da comprendere.

Aspose.Slides fornisce la classe [Tabella](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/), la classe [Cella](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/) e altri tipi correlati per aiutarti a creare, aggiornare e gestire le tabelle in qualsiasi presentazione.

## **Creare tabelle da zero**

Questa sezione mostra come creare una tabella da zero in Aspose.Slides aggiungendo una forma tabella a una diapositiva, definendo le sue righe e colonne e impostando dimensioni precise. Vedrai anche come riempire le celle con testo, regolare l’allineamento e i bordi e personalizzare l’aspetto della tabella.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Definisci un array di larghezze delle colonne.
4. Definisci un array di altezze delle righe.
5. Aggiungi una [Tabella](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) alla diapositiva.
6. Itera su ogni [Cella](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/) e formatta i bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle nella prima riga della tabella.
8. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) di una [Cella](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/).
9. Aggiungi testo al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
10. Salva la presentazione modificata.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    # Definisci le larghezze delle colonne e le altezze delle righe.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Aggiungi una forma tabella alla diapositiva.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Imposta il formato del bordo per ogni cella.
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
        
    # Unisci le celle da (riga 0, col 0) a (riga 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Aggiungi testo alla cella unita.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Salva la presentazione su disco.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numerazione nelle tabelle standard**

In una tabella standard, la numerazione delle celle è semplice e parte da zero. La prima cella di una tabella è indicizzata come (0, 0) (colonna 0, riga 0).

Ad esempio, in una tabella con 4 colonne e 4 righe, le celle sono numerate come segue:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Il seguente esempio Python mostra come fare riferimento alle celle utilizzando questa numerazione a base zero:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Accedere a una tabella esistente**

Questa sezione spiega come individuare e lavorare con una tabella esistente in una presentazione usando Aspose.Slides. Imparerai a trovare la tabella su una diapositiva, accedere alle sue righe, colonne e celle, e aggiornare contenuti o formattazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice.
3. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) finché non trovi la tabella.
4. Usa l'oggetto [Tabella](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) per lavorare con la tabella.
5. Salva la presentazione modificata.

{{% alert color="info" %}}
Se la diapositiva contiene diverse tabelle, è preferibile cercare la tabella di cui hai bisogno tramite la sua proprietà `alternative_text`.
{{% /alert %}}

Il seguente esempio Python mostra come accedere e lavorare con una tabella esistente:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Istanzia la classe Presentation per caricare un file PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    table = None

    # Itera attraverso le forme e riferisci la prima tabella trovata.
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

## **Allineare il testo nelle tabelle**

Questa sezione mostra come controllare l’allineamento del testo all’interno delle celle di una tabella usando Aspose.Slides. Imparerai a impostare l’allineamento orizzontale e verticale per le celle per mantenere il contenuto chiaro e coerente.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Aggiungi un oggetto [Tabella](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) alla diapositiva.
4. Accedi a un oggetto [Cella](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/) della tabella.
5. Allinea il testo verticalmente.
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

    # Aggiungi una forma tabella alla diapositiva.
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

Questa sezione mostra come applicare la formattazione del testo a livello di tabella in Aspose.Slides in modo che ogni cella erediti uno stile coerente e unificato. Imparerai a impostare le dimensioni del carattere, gli allineamenti e i margini a livello globale.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Aggiungi una [Tabella](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) alla diapositiva.
4. Imposta la dimensione del carattere (altezza del font) per il testo.
5. Imposta l'allineamento del paragrafo e i margini.
6. Imposta l'orientazione verticale del testo.
7. Salva la presentazione modificata.

Il seguente esempio Python mostra come applicare le tue opzioni di formattazione preferite al testo in una tabella:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea un'istanza della classe Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Imposta la dimensione del font per tutte le celle della tabella.
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

Aspose.Slides consente di formattare le tabelle utilizzando stili predefiniti direttamente nel codice. L’esempio dimostra come creare una tabella, applicare uno stile predefinito e salvare il risultato—un modo efficiente per garantire una formattazione coerente e professionale.

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

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un’intera tabella e il testo nelle sue celle?**

Sì. La tabella espone la proprietà [right_to_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/right_to_left/), e i paragrafi hanno [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/right_to_left/). L’uso di entrambi garantisce l’ordine RTL corretto e il rendering all’interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa i [blocchi di forma](/slides/it/python-net/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportato inserire un’immagine all’interno di una cella come sfondo?**

Sì. Puoi impostare un [picture fill](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/) per una cella; l’immagine coprirà l’area della cella secondo la modalità scelta (stretch o tile).