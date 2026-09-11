---
title: Gestire le tabelle di presentazione in Python
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
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per Python tramite Java. Scopri esempi di codice semplici per ottimizzare i flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per visualizzare informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono semplici e facili da comprendere.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/), la classe [Cell](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/) e altri tipi per consentire la creazione, l'aggiornamento e la gestione delle tabelle in tutti i tipi di presentazioni.

## **Creare una tabella da zero**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva mediante il suo indice.
3. Definire un elenco di larghezze delle colonne.
4. Definire un elenco di altezze delle righe.
5. Aggiungere un oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addTable).
6. Iterare su ogni [Cell](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unire le prime due celle della prima riga della tabella.
8. Accedere al [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) di una [Cell](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/).
9. Aggiungere del testo al [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).
10. Salvare la presentazione modificata.

Questo codice Python mostra come creare una tabella in una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Istanzia una classe Presentation che rappresenta un file PPTX
presentation = Presentation()
try:

    # Accede alla prima diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Definisce colonne con larghezze e righe con altezze
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Aggiunge una forma tabella alla diapositiva
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Imposta il formato del bordo per ogni cella
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

    # Unisce le celle 1 e 2 della riga 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Aggiunge del testo alla cella unita
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Salva la presentazione su disco
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numerazione in una tabella standard**

In una tabella standard, la numerazione delle celle è semplice e basata su zero. La prima cella di una tabella ha indice 0,0 (colonna 0, riga 0).

Ad esempio, le celle di una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice Python mostra come creare una tabella con numerazione di celle standard:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Istanzia una classe Presentation che rappresenta un file PPTX
presentation = Presentation()
try:

    # Accede alla prima diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Definisce colonne con larghezze e righe con altezze
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Aggiunge una forma tabella alla diapositiva
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Imposta il formato del bordo per ogni cella
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # Salva la presentazione su disco
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedere a una tabella esistente**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).

2. Ottenere un riferimento alla diapositiva che contiene la tabella tramite il suo indice.

3. Inizializzare una variabile per un oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) e impostarla a `None`.

4. Iterare su tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) finché non si trova la tabella.

   Se sospetti che la diapositiva in uso contenga una sola tabella, puoi semplicemente controllare tutte le forme contenute. Quando una forma viene identificata come tabella, puoi usarla come oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/). Ma se la diapositiva contiene più tabelle, è preferibile cercare la tabella desiderata tramite il suo [getAlternativeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getAlternativeText).

5. Utilizzare l'oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) per lavorare con la tabella. Nell'esempio seguente, aggiorniamo il testo nella prima colonna della seconda riga.

6. Salvare la presentazione modificata.

Questo codice Python mostra come accedere e lavorare con una tabella esistente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Istanzia la classe Presentation che rappresenta un file PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Accede alla prima diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Inizializza il riferimento alla tabella.
    table = None

    # Scorre le forme e imposta un riferimento alla tabella trovata
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Imposta il testo per la prima colonna della seconda riga
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Salva la presentazione modificata su disco
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trovare la cella che possiede un TextFrame**

Quando del codice generico di elaborazione testo riceve un [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) da una tabella, usa il metodo [TextFrame.getParentCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParentCell) per recuperare la [Cell](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/) proprietaria. Per un TextFrame di cella di tabella, [TextFrame.getParentCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParentCell) restituisce il proprietario e [TextFrame.getParentShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParentShape) restituisce `None`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/#getFirstColumnIndex) e [Cell.getFirstRowIndex](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParentCell) fornisce anche una navigazione di sola lettura: restituisce il proprietario ma non ne cambia la proprietà. Controlla sempre se la cella restituita è `None` prima di usarla.

Per un esempio completo che identifica i proprietari di celle di tabella e di forme, incluse le forme associate a nodi SmartArt, vedi [Search and Replace Text](/slides/it/python-java/search-and-replace-text/).

## **Allineare il testo in una tabella**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) alla diapositiva.
4. Accedere a un oggetto [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) dalla tabella.
5. Accedere al [Paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/) dell'oggetto [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).
6. Allineare il testo verticalmente.
7. Salvare la presentazione modificata.

Questo codice Python mostra come allineare il testo in una tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Crea un'istanza della classe Presentation
presentation = Presentation()
try:

    # Ottiene la prima diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Definisce le colonne con larghezze e le righe con altezze
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Aggiunge la forma tabella alla diapositiva
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Accede al TextFrame
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Accede al primo paragrafo nel TextFrame.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Accede alla prima porzione nel paragrafo.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Allinea il testo verticalmente
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Salva la presentazione su disco
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare la formattazione del testo a livello di tabella**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Accedere a un oggetto [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) dalla diapositiva.
4. Impostare l'altezza del carattere del testo con [setFontHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Impostare l'allineamento e il margine destro con [setAlignment](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setAlignment) e [setMarginRight](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Impostare il tipo di testo verticale con [setTextVerticalType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Salvare la presentazione modificata.

Questo codice Python mostra come applicare le opzioni di formattazione preferite al testo in una tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Crea un'istanza della classe Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Supponiamo che la prima forma nella prima diapositiva sia una tabella
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Imposta l'altezza del carattere delle celle della tabella
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Imposta l'allineamento del testo delle celle della tabella e il margine destro in un'unica chiamata
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Imposta il tipo di testo verticale delle celle della tabella
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Ottenere le proprietà di stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poterle utilizzare per un'altra tabella o altrove. Questo codice Python mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # cambia il tema predefinito del preset di stile

    # Ottiene il preset di stile della tabella
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Applica il preset di stile recuperato a un'altra tabella
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bloccare il rapporto di aspetto di una tabella**

Il rapporto di aspetto di una forma geometrica è il rapporto delle sue dimensioni in diverse direzioni. Aspose.Slides fornisce il metodo [setAspectRatioLocked](https://reference.aspose.com/slides/it/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) per consentire di bloccare l'impostazione del rapporto di aspetto per tabelle e altre forme.

Questo codice Python mostra come bloccare il rapporto di aspetto per una tabella:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # inverti
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone il metodo [setRightToLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/#setRightToLeft), e i paragrafi hanno [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setRightToLeft). L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizza i [blocco forme](/slides/it/python-java/applying-protection-to-presentation/) per disabilitare spostamento, ridimensionamento, selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportata l'inserimento di un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).