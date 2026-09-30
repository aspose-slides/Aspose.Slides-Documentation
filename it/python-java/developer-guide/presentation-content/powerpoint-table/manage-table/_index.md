---
title: Gestisci tabelle di presentazione in Python
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/python-java/manage-table/
keywords:
- aggiungi tabella
- crea tabella
- accedi tabella
- rapporto di aspetto
- allinea testo
- formattazione del testo
- stile della tabella
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per Python tramite Java. Scopri semplici esempi di codice per semplificare il tuo flusso di lavoro con le tabelle."
---
## **Introduzione**

Le tabelle in PowerPoint organizzano le informazioni in righe e colonne, facilitando la lettura e il confronto dei valori.

Aspose.Slides fornisce le classi [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) e [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) e altri tipi per consentire di creare, aggiornare e gestire le tabelle nelle presentazioni.

## **Crea una tabella da zero**

Crea una tabella specificando la sua posizione, le larghezze delle colonne e le altezze delle righe. Dopo averla aggiunta a una diapositiva, è possibile formattare i bordi delle celle, unire le celle e inserire testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Definisci un elenco di larghezze delle colonne in punti.
4. Definisci un elenco di altezze delle righe in punti.
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Itera su ciascun [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella.
8. Accedi alla cella unita tramite il suo metodo [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Imposta il testo nella cella unita.
10. Salva la presentazione modificata.

L'esempio seguente crea una tabella con tre colonne e cinque righe in (100, 50) punti. Applica bordi rossi con una larghezza di 5 punti, unisce le prime due celle della prima riga e salva il risultato come `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numerazione in una tabella standard**

In una tabella standard, gli indici delle celle sono basati su zero e usano l'ordine (colonna, riga). La prima cella è indicizzata come (0, 0).

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo esempio crea la tabella 4 × 4 illustrata sopra, con larghezze delle colonne e altezze delle righe di 70 punti e bordi delle celle rossi con una larghezza di 5 punti. Le coordinate illustrano gli indici delle celle; l'esempio lascia le celle vuote e salva la tabella come `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedi a una tabella esistente**

Le tabelle sono memorizzate nella collezione di forme di una diapositiva. Itera attraverso le forme per individuare una tabella, quindi utilizza la classe [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) per leggere o aggiornare le sue celle.

1. Carica la presentazione utilizzando la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva contenente la tabella tramite il suo indice.
3. Itera attraverso gli oggetti [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) e interrompi quando trovi una tabella. Se la diapositiva contiene diverse tabelle, usa [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) per identificare quella necessaria.
4. Aggiorna il testo nella cella target.
5. Salva la presentazione modificata.

L'esempio seguente apre `UpdateExistingTable.pptx` e trova la prima tabella nella prima diapositiva. Imposta la cella alla colonna 0, riga 1 su `New` e salva il risultato come `table1_out.pptx`. L'input deve contenere almeno una diapositiva, e la prima tabella su quella diapositiva deve avere almeno una colonna e due righe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per ridimensionare una riga in una tabella esistente e capire perché la sua altezza reale può superare il minimo richiesto, consulta [Controllo altezza riga](/slides/it/python-java/manage-rows-and-columns/#control-row-height).

## **Trova la cella che possiede un TextFrame**

Quando il codice generico di elaborazione testo riceve un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) da una tabella, usa il metodo [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) per recuperare la [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) proprietaria. Per un TextFrame di una cella di tabella, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) restituisce il proprietario e [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) restituisce `None`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) fornisce anche una navigazione di sola lettura: restituisce il proprietario ma non ne modifica la proprietà. Verifica sempre che la cella restituita non sia `None` prima di usarla.

Per un esempio completo che identifica proprietari di celle di tabella e di forme, incluse le forme associate a nodi SmartArt, vedi [Cerca e sostituisci testo](/slides/it/python-java/search-and-replace-text/).

## **Allinea il testo in una tabella**

È possibile controllare l'ancoraggio verticale e la direzione del testo delle singole celle di una tabella. L'esempio in questa sezione centra il testo nella prima cella e lo ruota di 270 gradi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) alla diapositiva.
4. Accedi a un oggetto [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) dalla tabella.
5. Accedi al primo [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) e imposta il suo testo e colore.
6. Imposta l'ancoraggio verticale della cella e la direzione del testo usando [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) e [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Salva la presentazione modificata.

Questo esempio crea una tabella 4 × 4 con larghezze delle colonne di 120 punti e altezze delle righe di 100 punti. Formattta il testo nella cella (0, 0), aggiunge valori alle restanti celle della prima riga e salva il risultato come `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la formattazione del testo a livello di tabella**

Usa [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) per applicare la formattazione del testo a tutte le celle di una tabella. Le sue sovraccariche accettano la formattazione di porzione, paragrafo e TextFrame, così è possibile impostare queste proprietà senza iterare attraverso le singole celle.

1. Carica la presentazione utilizzando la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi a un oggetto [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) dalla diapositiva.
4. Imposta la dimensione del carattere usando [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) per il testo.
5. Imposta l'allineamento del paragrafo e il margine destro usando [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Imposta la direzione del testo usando [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Salva la presentazione modificata.

L'esempio seguente apre `table.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Imposta la dimensione del carattere a 25 punti, allinea a destra i paragrafi con un margine destro di 20 punti e rende il testo verticale. La presentazione formattata viene salvata come `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ottieni le proprietà dello stile della tabella**

Usa [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) per leggere lo stile predefinito di una tabella e [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) per assegnarlo. Questo esempio applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) a una tabella, stampa il valore predefinito e assegna lo stesso stile a una seconda tabella. Entrambe le tabelle vengono salvate in `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Blocca il rapporto di aspetto di una tabella**

Il rapporto di aspetto di una tabella è il rapporto tra la sua larghezza e la sua altezza. Usa [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) per bloccare questo rapporto per una tabella.

L'esempio seguente apre `pres.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Stampa lo stato di blocco attuale, abilita il blocco del rapporto di aspetto, stampa lo stato aggiornato (`True`) e salva il risultato come `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone un metodo [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft), e i paragrafi hanno [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). L'utilizzo di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizza [shape locks](/slides/it/python-java/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**L'inserimento di un'immagine all'interno di una cella come sfondo è supportato?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (allungamento o affiancamento).