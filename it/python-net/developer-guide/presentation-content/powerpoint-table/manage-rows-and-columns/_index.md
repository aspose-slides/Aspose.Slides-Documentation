---
title: Gestire righe e colonne nelle tabelle PowerPoint usando Python
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/python-net/manage-rows-and-columns/
keywords:
- riga di tabella
- colonna di tabella
- prima riga
- intestazione della tabella
- clona riga
- clona colonna
- copia riga
- copia colonna
- rimuovi riga
- rimuovi colonna
- formattazione testo riga
- formattazione testo colonna
- stile tabella
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci righe e colonne delle tabelle in PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Panoramica**

Questo articolo mostra come gestire righe e colonne di tabelle nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python. Imparerai come aggiungere, inserire, clonare ed eliminare righe o colonne, contrassegnare la prima riga come intestazione, regolare dimensioni e layout e applicare formattazione del testo e dello stile a livello di riga o colonna. Ogni attività è dimostrata con frammenti di codice compatti e autonomi basati sull'API [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) , così potrai individuare rapidamente una tabella in una diapositiva e rimodellarne la struttura per adattarla al tuo design.

## **Imposta la prima riga come intestazione**

Contrassegna la prima riga della tabella come intestazione per distinguere chiaramente i titoli delle colonne dai dati. In Aspose.Slides per Python, basta abilitare l'opzione *First Row* della tabella per applicare la formattazione dell'intestazione definita dallo stile di tabella selezionato.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione.
1. Accedi alla diapositiva tramite il suo indice.
1. Scorri tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) per trovare la tabella pertinente.
1. Imposta la prima riga della tabella come intestazione.

```python
import aspose.slides as slides

# Istanziare la classe Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Iterare attraverso le forme e ottenere un riferimento alla tabella.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Impostare la prima riga della tabella come intestazione.
    table.first_row = True
    
    # Salvare la presentazione su disco.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Clona una riga o colonna di tabella**

Clona qualsiasi riga o colonna di una tabella e inserisci la copia nella posizione desiderata nella tabella. Il duplicato conserva il contenuto delle celle, la formattazione e le dimensioni, così potrai ampliare i layout rapidamente e in modo coerente.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione.
1. Accedi alla diapositiva tramite il suo indice.
1. Definisci un array di larghezze delle colonne.
1. Definisci un array di altezze delle righe.
1. Aggiungi una [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) alla diapositiva usando `add_table(x, y, column_widths, row_heights)`.
1. Clona una riga della tabella.
1. Clona una colonna della tabella.
1. Salva la presentazione modificata.

```python
 import aspose.slides as slides

# Istanziare la classe Presentation.
with slides.Presentation() as presentation:
    # Accedere alla prima diapositiva.
    slide = presentation.slides[0]

    # Definire larghezze delle colonne e altezze delle righe.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Aggiungere una tabella alla diapositiva.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Aggiungere testo alla riga 1, colonna 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Aggiungere testo alla riga 2, colonna 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Clonare la riga 1 alla fine della tabella.
    table.rows.add_clone(table.rows[0], False)

    # Aggiungere testo alla riga 1, colonna 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Aggiungere testo alla riga 2, colonna 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Clonare la riga 2 come quarta riga della tabella.
    table.rows.insert_clone(3,table.rows[1], False)

    # Clonare la prima colonna alla fine.
    table.columns.add_clone(table.columns[0], False)

    # Clonare la seconda colonna all'indice 3 (la quarta posizione).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Salvare la presentazione su disco.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovi una riga o colonna da una tabella**

Semplifica una tabella rimuovendo qualsiasi riga o colonna per indice usando Aspose.Slides per Python—il layout si riadatta automaticamente mantenendo la formattazione delle celle rimanenti. È utile per semplificare griglie di dati o eliminare segnaposti senza ricostruire la tabella.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione.
1. Accedi alla diapositiva tramite il suo indice.
1. Definisci un array di larghezze delle colonne.
1. Definisci un array di altezze delle righe.
1. Aggiungi un ITable alla diapositiva usando `add_table(x, y, column_widths, row_heights)`.
1. Rimuovi la riga della tabella.
1. Rimuovi la colonna della tabella.
1. Salva la presentazione modificata.

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

## **Imposta la formattazione del testo a livello di riga della tabella**

Applica una formattazione testuale coerente all'intera riga di una tabella in un unico passaggio. Con Aspose.Slides per Python, puoi impostare la famiglia del carattere, la dimensione, lo spessore, il colore e l'allineamento per tutte le celle della riga contemporaneamente per mantenere intestazioni o bande di dati uniformi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione.
1. Accedi alla diapositiva tramite il suo indice.
1. Accedi all'oggetto [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) pertinente sulla diapositiva.
1. Imposta l'altezza del carattere per le celle della prima riga.
1. Imposta l'allineamento e il margine destro per le celle della prima riga.
1. Imposta il tipo di orientamento verticale del testo per le celle della seconda riga.
1. Salva la presentazione modificata.

```python
import aspose.slides as slides

# Creare un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Impostare l'altezza del carattere per le celle della prima riga.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Impostare l'allineamento del testo e il margine destro per le celle della prima riga.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Impostare il tipo verticale del testo per le celle della seconda riga.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Salvare la presentazione su disco.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

Applica una formattazione testuale coerente all'intera colonna di una tabella in un unico passaggio. Con Aspose.Slides per Python, puoi impostare la famiglia del carattere, la dimensione, lo spessore, il colore e l'allineamento per tutte le celle di una colonna per creare bande verticali uniformi per intestazioni o dati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione.
1. Accedi alla diapositiva tramite il suo indice.
1. Accedi all'oggetto [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) pertinente sulla diapositiva.
1. Imponi l'altezza del carattere per le celle della prima colonna.
1. Imposta l'allineamento e il margine destro per le celle della prima colonna.
1. Imposta il tipo di orientamento verticale del testo per le celle della seconda colonna.
1. Salva la presentazione modificata.

```python
import aspose.slides as slides

# Creare un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Impostare l'altezza del carattere per le celle della prima colonna.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Impostare l'allineamento del testo e il margine destro per le celle della prima colonna.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Impostare il tipo verticale del testo per le celle della seconda colonna.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Salvare la presentazione su disco.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottieni le proprietà di stile della tabella**

Aspose.Slides ti consente di recuperare le proprietà di stile di una tabella così da poterle riutilizzare per un'altra tabella o altrove. Il seguente codice Python mostra come ottenere le proprietà di stile da uno stile di tabella predefinito:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso applicare temi/stili PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno ordinamento o filtri integrati. Ordina i dati in memoria prima, quindi ripopolare le righe della tabella in quell'ordine.

**Posso avere colonne a bande (striate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, quindi sovrascrivi celle specifiche con una formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.