---
title: Gestire righe e colonne nelle tabelle PowerPoint usando Python
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/python-java/manage-rows-and-columns/
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
description: "Gestisci righe e colonne delle tabelle in PowerPoint con Aspose.Slides per Python via Java e velocizza la modifica delle presentazioni e gli aggiornamenti dei dati."
---
## **Introduzione**

Per consentirti di gestire le righe e le colonne di una tabella in una presentazione PowerPoint, Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) e molti altri tipi.

## **Imposta la Prima Riga Come Intestazione**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione.  
2. Ottieni un riferimento a una diapositiva tramite il suo indice.  
3. Crea un riferimento a una [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) e impostalo su `None`.  
4. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) per trovare la tabella pertinente.  
5. Imposta la prima riga della tabella come intestazione.

Questo codice Python mostra come impostare la prima riga di una tabella come intestazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clona una Riga o Colonna di una Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione.  
2. Ottieni un riferimento a una diapositiva tramite il suo indice.  
3. Definisci un elenco di larghezze delle colonne.  
4. Definisci un elenco di altezze delle righe.  
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addTable).  
6. Clona la riga della tabella.  
7. Clona la colonna della tabella.  
8. Salva la presentazione modificata.

Questo codice Python mostra come clonare una riga o colonna di una tabella PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rimuovi una Riga o Colonna da una Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).  
2. Ottieni un riferimento a una diapositiva tramite il suo indice.  
3. Definisci un elenco di larghezze delle colonne.  
4. Definisci un elenco di altezze delle righe.  
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addTable).  
6. Rimuovi la riga della tabella.  
7. Rimuovi la colonna della tabella.  
8. Salva la presentazione modificata.

Questo codice Python mostra come rimuovere una riga o colonna da una tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la Formattazione del Testo a Livello di Riga della Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione.  
2. Ottieni un riferimento a una diapositiva tramite il suo indice.  
3. Accedi all'oggetto [Table] pertinente dalla diapositiva.  
4. Imposta l'altezza del carattere delle celle della prima riga usando [setFontHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Imposta l'allineamento del testo e il margine destro delle celle della prima riga usando [setAlignment](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Imposta il tipo di testo verticale delle celle della seconda riga usando [setTextVerticalType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Salva la presentazione modificata.

Questo codice Python dimostra l'operazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Imposta la Formattazione del Testo a Livello di Colonna della Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione.  
2. Ottieni un riferimento a una diapositiva tramite il suo indice.  
3. Accedi all'oggetto [Table] pertinente dalla diapositiva.  
4. Imposta l'altezza del carattere delle celle della prima colonna usando [setFontHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Imposta l'allineamento del testo e il margine destro delle celle della prima colonna usando [setAlignment](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Imposta il tipo di testo verticale delle celle della seconda colonna usando [setTextVerticalType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Salva la presentazione modificata.

Questo codice Python dimostra l'operazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Ottieni le Proprietà di Stile della Tabella**

Aspose.Slides ti consente di recuperare le proprietà di stile per una tabella in modo da poter utilizzare questi dettagli per un'altra tabella o altrove. Questo codice Python mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere i riempimenti, i bordi e i colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno ordinamento o filtri integrati. Ordina i dati in memoria prima, poi ripopolare le righe della tabella in quell'ordine.

**Posso avere colonne a bande (a strisce) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, quindi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha priorità sullo stile della tabella.