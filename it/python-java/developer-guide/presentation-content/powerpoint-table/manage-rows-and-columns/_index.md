---
title: Gestire righe e colonne nelle tabelle PowerPoint con Python
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
- formattazione testo riga
- formattazione testo colonna
- stile della tabella
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci righe e colonne delle tabelle in PowerPoint con Aspose.Slides per Python via Java e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Aspose.Slides per Python via Java ti consente di gestire la struttura e la formattazione delle tabelle nelle presentazioni PowerPoint attraverso la classe [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) . Puoi designare una riga di intestazione, clonare o rimuovere righe e colonne, e applicare la formattazione del testo a un'intera riga o colonna.

Questo articolo spiega queste operazioni con esempi Python. Mostra anche come recuperare un preset di stile della tabella in modo da poterlo riutilizzare. Gli indici di righe e colonne della tabella partono da zero.

## **Controllo altezza della riga**

Usa [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) per impostare l'altezza minima di una riga in punti. È un limite inferiore, non un'altezza fissa. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) restituisce l'altezza reale. Accedi alla riga tramite [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

L'esempio carica [row-height-input.pptx](row-height-input.pptx), che contiene una tabella come prima forma nella prima diapositiva. La sua prima riga inizia a 70 punti. Le celle usano testo Arial da 18 punti, a capo automatico e margini superiori e inferiori di 6 punti; il testo più lungo nella seconda colonna si avvolge su più righe. L'esempio aumenta il valore minimo a 100 punti, poi lo diminuisce a 20 punti, stampa l'altezza reale dopo ogni modifica e salva entrambi i risultati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Con la presentazione fornita, aumentare il minimo aggiunge spazio alla riga. Ridurlo rimuove quello spazio extra, ma l'altezza reale rimane superiore a 20 punti perché il testo e i margini delle celle richiedono più spazio. Ridurre solo il minimo non può forzare la riga al di sotto dello spazio richiesto dal suo contenuto.

Diversi fattori influenzano l'altezza reale:

- **Text and font size:** un testo più lungo, interruzioni di riga esplicite o un carattere più grande possono richiedere più spazio verticale.
- **Wrapping and column width:** con l'andare a capo abilitato, ridurre la larghezza della colonna con [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) può generare più righe. Una colonna più larga può ridurre lo spazio richiesto verticalmente.
- **Cell margins:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) e [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) aggiungono spazio verticale. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) e [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) riducono la larghezza disponibile per il testo e possono causare ulteriori a capo automatici.

Per questa tabella senza celle unite, la cella che richiede più spazio verticale determina il limite inferiore determinato dal contenuto per l'intera riga. Per rendere la riga più corta, potresti anche dover abbreviare il testo, ridurre la dimensione del carattere o i margini, o allargare una colonna.

Le immagini sottostanti mostrano la stessa tabella alla stessa scala. Nei risultati illustrati, le altezze reali erano 70, 100 e 55,2 punti: la riga finale è rimasta più alta del minimo di 20 punti. Le misurazioni esatte del testo possono variare a seconda dei caratteri disponibili nel tuo ambiente. Scarica i risultati salvati: [minimum aumentato](row-height-increased.pptx) e [minimum ridotto](row-height-decreased.pptx).

| Originale: minimo 70 pt, reale 70 pt | Aumentato: minimo 100 pt, reale 100 pt | Ridotto: minimo 20 pt, reale 55.2 pt |
| --- | --- | --- |
| ![Tabella originale con prima riga di 70 punti.](row-height-before.png) | ![Tabella dopo aver aumentato il minimo della prima riga a 100 punti.](row-height-increased.png) | ![Tabella dopo aver ridotto il minimo della prima riga a 20 punti; il testo a capo mantiene la riga più alta del minimo.](row-height-decreased.png) |

## **Imposta la prima riga come intestazione**

Usa il metodo [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) per contrassegnare la prima riga per la formattazione dell'intestazione. Il suo aspetto dipende dallo stile della tabella applicato.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Accedi alla tabella memorizzata come prima forma nella diapositiva.
4. Abilita la formattazione dell'intestazione per la sua prima riga.
5. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva. Abilita la formattazione dell'intestazione per la prima riga e salva `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clona una riga o una colonna della tabella**

Clona righe o colonne per riutilizzare il loro contenuto e la formattazione. Puoi aggiungere una copia alla fine della tabella o inserirla in una posizione specifica.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Clona le righe necessarie.
6. Clona le colonne necessarie.
7. Salva la presentazione modificata.

L'esempio richiede `Test.pptx` con almeno una diapositiva. Crea una tabella con tre colonne e cinque righe, con dimensioni specificate in punti. Aggiunge copie della prima riga e della prima colonna, poi inserisce copie della seconda riga e della seconda colonna all'indice 3 (la quarta posizione). La tabella risultante ha sette righe e cinque colonne. L'argomento `False` disabilita il clonare in righe o colonne unite adiacenti; questa tabella non ha celle unite.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
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

## **Rimuovi una riga o una colonna da una tabella**

Rimuovi righe o colonne non più necessarie in una tabella. Rimuovere un elemento sposta gli indici delle righe o colonne che lo seguono.

1. Crea una presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Rimuovi la seconda riga e la seconda colonna.
6. Salva la presentazione modificata.

Questo esempio crea una tabella 3x3 e rimuove la riga e la colonna all'indice 1, lasciando una tabella 2x2 in `TestTable_out.pptx`. Le dimensioni sono in punti. L'argomento `False` disabilita la rimozione di righe o colonne unite adiacenti; questa tabella non ha celle unite.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la formattazione del testo a livello di riga della tabella**

Applica la formattazione del testo a un'intera riga per mantenere coerenti le sue celle. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) per la prima riga.
4. Usa [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) per la prima riga.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) per la seconda riga.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due righe. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima riga, poi imposta il testo verticale nella seconda riga.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

Applica la formattazione del testo a un'intera colonna per mantenere coerenti le sue celle. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) per la prima colonna.
4. Usa [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) per la prima colonna.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) per la seconda colonna.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due colonne. Applica testo da 25 punti, allineamento a destra e un margine destro del paragrafo di 20 punti alla prima colonna, poi imposta il testo verticale nella seconda colonna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ottieni le proprietà dello stile della tabella**

Usa il metodo [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) per recuperare il preset applicato a una tabella e riutilizzarlo su un'altra tabella. Questo identifica il preset anziché le sovrascritture di formattazione delle singole celle.

L'esempio crea una tabella, applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1), e legge nuovamente il preset. Stampa il valore intero corrispondente a `DarkStyle1` e salva la tabella in `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso applicare i temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non hanno ordinamento o filtri incorporati. Ordina i dati in memoria prima, poi riempi nuovamente le righe della tabella in quell'ordine.

**Posso avere colonne a bande (striate) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi le celle specifiche con formattazione locale; la formattazione a livello di cella ha la precedenza sullo stile della tabella.