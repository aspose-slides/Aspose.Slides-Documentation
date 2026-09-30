---
title: Gestire righe e colonne nelle tabelle PowerPoint usando Python
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/python-net/manage-rows-and-columns/
keywords:
- riga della tabella
- colonna della tabella
- prima riga
- intestazione della tabella
- clona riga
- clona colonna
- copia riga
- copia colonna
- rimuovi riga
- rimuovi colonna
- formattazione testo della riga
- formattazione testo della colonna
- stile della tabella
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci righe e colonne delle tabelle in PowerPoint con Aspose.Slides per Python via .NET e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Aspose.Slides per Python via .NET ti consente di gestire la struttura e la formattazione delle tabelle nelle presentazioni PowerPoint attraverso la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Puoi designare una riga di intestazione, clonare o rimuovere righe e colonne e applicare la formattazione del testo a un’intera riga o colonna.

Questo articolo spiega queste operazioni con esempi Python. Mostra anche come recuperare il preset di stile di una tabella per riutilizzarlo. Gli indici di righe e colonne della tabella sono a base zero.

## **Controllare l’altezza della riga**

Usa [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) per impostare l’altezza minima di una riga in punti. È un limite inferiore, non un’altezza fissa. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) restituisce l’altezza reale ed è di sola lettura. Accedi alla riga tramite [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

L’esempio carica [row-height-input.pptx](row-height-input.pptx), che contiene una tabella come prima forma nella prima diapositiva. La sua prima riga parte da 70 punti. Le celle usano testo Arial da 18 punti, con a capo automatico e margini superiori e inferiori di 6 punti; il testo più lungo nella seconda colonna si avvolge su più righe. L’esempio aumenta il minimo a 100 punti, poi lo riduce a 20 punti, stampa l’altezza reale dopo ogni modifica e salva entrambi i risultati.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Con la presentazione fornita, aumentare il minimo aggiunge spazio alla riga. Ridurlo elimina quello spazio extra, ma l’altezza reale rimane superiore a 20 punti perché il testo e i margini delle celle richiedono più spazio. Ridurre solo il valore minimo non può forzare la riga al di sotto dello spazio richiesto dal suo contenuto.

Diversi fattori influenzano l’altezza reale:

- **Testo e dimensione del carattere:** testo più lungo, interruzioni di riga esplicite o un carattere più grande possono richiedere più spazio verticale.
- **A capo automatico e larghezza della colonna:** con l’avvolgimento abilitato, una [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) più stretta può produrre più righe. Una colonna più larga può ridurre lo spazio richiesto verticalmente.
- **Margini della cella:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) e [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) aggiungono spazio verticale. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) e [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) riducono la larghezza disponibile per il testo e possono causare ulteriore avvolgimento.

Per questa tabella senza celle unite, la cella che richiede più spazio verticale determina il limite inferiore determinato dal contenuto per l’intera riga. Per rendere la riga più corta potrebbe essere necessario accorciare il testo, ridurre la dimensione del carattere o i margini, o allargare una colonna.

Le immagini sotto mostrano la stessa tabella alla stessa scala. In questo caso, le altezze reali erano 70, 100 e 55,2 punti: la riga finale è rimasta più alta del minimo di 20 punti. Le misurazioni precise del testo possono variare a seconda dei caratteri disponibili nell’ambiente. Scarica i risultati salvati: [increased minimum](row-height-increased.pptx) e [decreased minimum](row-height-decreased.pptx).

| Originale: minimo 70 pt, reale 70 pt | Incrementato: minimo 100 pt, reale 100 pt | Decrementato: minimo 20 pt, reale 55,2 pt |
| --- | --- | --- |
| ![Tabella originale con la prima riga di 70 punti.](row-height-before.png) | ![Tabella dopo aver aumentato il minimo della prima riga a 100 punti.](row-height-increased.png) | ![Tabella dopo aver diminuito il minimo della prima riga a 20 punti; il testo avvolto mantiene la riga più alta del minimo.](row-height-decreased.png) |

## **Impostare la prima riga come intestazione**

Usa la proprietà [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) per contrassegnare la prima riga come intestazione. Il suo aspetto dipende dallo stile della tabella applicato.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Accedi alla tabella memorizzata come prima forma sulla diapositiva.
4. Abilita la formattazione dell’intestazione per la sua prima riga.
5. Salva la presentazione modificata.

L’esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva. Abilita la formattazione dell’intestazione per la prima riga e salva `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Clonare una riga o una colonna della tabella**

Clona righe o colonne per riutilizzare il loro contenuto e la loro formattazione. Puoi aggiungere una copia alla fine della tabella o inserirla in una posizione specifica.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Clona le righe richieste.
6. Clona le colonne richieste.
7. Salva la presentazione modificata.

L’esempio richiede `Test.pptx` con almeno una diapositiva. Crea una tabella con tre colonne e cinque righe, con dimensioni specificate in punti. Aggiunge copie della prima riga e colonna, poi inserisce copie della seconda riga e colonna all’indice 3 (quarta posizione). La tabella risultante ha sette righe e cinque colonne. L’argomento `False` disabilita il clonaggio in righe o colonne unite adiacenti; questa tabella non contiene celle unite.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovere una riga o una colonna da una tabella**

Rimuovi righe o colonne non più necessarie in una tabella. La rimozione di un elemento sposta gli indici delle righe o colonne successive.

1. Crea una presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Rimuovi la seconda riga e la seconda colonna.
6. Salva la presentazione modificata.

Questo esempio crea una tabella 3×3 e rimuove la riga e la colonna all’indice 1, lasciando una tabella 2×2 in `TestTable_out.pptx`. Le dimensioni sono in punti. L’argomento `False` disabilita la rimozione di righe o colonne unite adiacenti; questa tabella non contiene celle unite.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la formattazione del testo a livello di riga della tabella**

Applica la formattazione del testo a un’intera riga per mantenere coerenti le celle. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e l’orientamento del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Imposta [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) per la prima riga.
4. Imposta [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) e [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) per la prima riga.
5. Imposta [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) per la seconda riga.
6. Salva la presentazione modificata.

L’esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due righe. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima riga, quindi imposta il testo verticale nella seconda riga.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la formattazione del testo a livello di colonna della tabella**

Applica la formattazione del testo a un’intera colonna per mantenere coerenti le celle. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e l’orientamento del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Imposta [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) per la prima colonna.
4. Imposta [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) e [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) per la prima colonna.
5. Imposta [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) per la seconda colonna.
6. Salva la presentazione modificata.

L’esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due colonne. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima colonna, quindi imposta il testo verticale nella seconda colonna.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere le proprietà di stile della tabella**

Usa la proprietà [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) per recuperare il preset applicato a una tabella e riutilizzarlo su un’altra tabella. Questo identifica il preset anziché le sovrascritture di formattazione delle singole celle.

L’esempio crea una tabella, applica [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), e legge il preset indietro. Stampa `True` quando il preset recuperato corrisponde a quello applicato e salva la tabella in `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe di una tabella come in Excel?**

No, le tabelle di Aspose.Slides non dispongono di ordinamento o filtri integrati. Ordina i dati in memoria prima, quindi ricrea le righe della tabella in quell’ordine.

**Posso avere colonne a bande (striate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.