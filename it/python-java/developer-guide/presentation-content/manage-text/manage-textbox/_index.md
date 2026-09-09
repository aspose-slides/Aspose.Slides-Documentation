---
title: Gestire le caselle di testo nelle presentazioni usando Python via Java
linktitle: Gestire casella di testo
type: docs
weight: 20
url: /it/python-java/manage-textbox/
keywords:
- casella di testo
- frame di testo
- aggiungere testo
- aggiornare testo
- creare casella di testo
- verificare casella di testo
- aggiungere colonna di testo
- aggiungere collegamento ipertestuale
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea, identifica, formatta e aggiorna le caselle di testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via Java."
---
## **Introduzione**

In Aspose.Slides per Python via Java, il testo delle diapositive è memorizzato nei frame di testo che appartengono alle forme. La classe [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) rappresenta la forma più comune contenente testo ed espone il suo testo tramite il metodo [AutoShape.getTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Ogni auto shape eredita da [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/), ma non tutte le forme sono auto shape o supportano un frame di testo. Quando si elabora una presentazione esistente, verificare che una forma sia un'istanza di [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) prima di accedere al suo testo.
{{% /alert %}}

## **Crea una casella di testo su una diapositiva**

Per creare una casella di testo, aggiungere un'auto shape a una diapositiva, aggiungere testo al suo frame di testo e salvare la presentazione. Il seguente esempio crea una casella di testo rettangolare:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le coordinate e le dimensioni passate a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) sono misurate in punti. [AutoShape.addTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#addTextFrame) inizializza il frame di testo con il testo fornito.

## **Verifica la presenza di una forma casella di testo**

Utilizzare il metodo [AutoShape.isTextBox](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#isTextBox) per determinare se un'auto shape è trattata come una casella di testo. Questo è utile quando una presentazione contiene sia auto shape con testo che auto shape puramente grafiche.

![Una casella di testo e una forma](istextbox.png)

Il seguente esempio esamina ogni auto shape in una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Una auto shape appena aggiunta non è considerata una casella di testo finché non contiene testo non vuoto. È possibile fornire quel testo tramite [AutoShape.addTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#addTextFrame) o [TextFrame.setText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#setText). Aggiungere o assegnare una stringa vuota fa sì che [AutoShape.isTextBox](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#isTextBox) restituisca `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Le prime due chiamate stampano `True`; le ultime due stampano `False`.

## **Trova la forma che possiede un frame di testo**

Il codice generico di elaborazione del testo può ricevere un [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) senza sapere quale oggetto della presentazione lo contiene. Utilizzare il metodo di sola lettura [TextFrame.getParentShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParentShape) per tornare alla sua forma proprietaria.

Per un frame di testo posseduto da un'auto shape o da un'altra forma che contiene testo, [TextFrame.getParentShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParentShape) restituisce il proprietario e [TextFrame.getParentCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getParentCell) restituisce `None`. Verificare il valore restituito prima di accedervi. Per identificare sia i proprietari della forma sia della cella di tabella, incluse le forme associate ai nodi SmartArt, vedere [Search and Replace Text](/slides/it/python-java/search-and-replace-text/).

## **Aggiungi colonne a una casella di testo**

Il metodo [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setColumnCount) divide il frame di testo in colonne, mentre [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setColumnSpacing) imposta lo spazio tra le colonne in punti. Entrambe le impostazioni appartengono a [TextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/) e possono essere modificate tramite il frame di testo di una casella di testo esistente. Il testo si ridistribuisce tra le colonne all'interno della stessa forma; non continua in un'altra forma.

Il seguente esempio crea una casella di testo a tre colonne con 10 punti tra le colonne, salva la presentazione e legge le impostazioni memorizzate dal file di output:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Estrai testo da colonne individuali**

Utilizzare [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#splitTextByColumns) per recuperare il testo assegnato a ciascuna colonna visiva in un frame di testo esistente. Il metodo restituisce una stringa per ogni colonna, nell'ordine di lettura basato sulle colonne. Un frame di testo a colonna singola produce un array con un elemento, e una colonna vuota è rappresentata da una stringa vuota. Le stringhe contengono solo testo semplice; la formattazione a livello di porzione non viene conservata.

Questo è utile quando è necessario:

- Estrarre il testo mantenendo il suo ordine di lettura basato sulle colonne.
- Indicizzare o confrontare il contenuto di diapositive multicolonna.
- Esportare ogni colonna in un file separato, campo di database o altra destinazione.
- Ispezionare come il testo viene ridistribuito dopo aver modificato il numero di colonne con [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setColumnCount), la spaziatura con [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setColumnSpacing), il carattere o la dimensione del frame di testo.

Il metodo riporta il testo distribuito all'interno del [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) corrente; non fa fluire automaticamente il testo tra forme o caselle di testo separate. La distribuzione delle colonne può dipendere dai caratteri disponibili e da altre impostazioni di layout del testo, quindi assicurarsi che i caratteri richiesti siano disponibili quando è importante ottenere risultati coerenti.

Il seguente esempio carica una presentazione, trova la prima auto shape multicolonna con un frame di testo, legge il numero di colonne configurato e scrive il testo di ogni colonna in un file separato. Le forme che non forniscono un frame di testo vengono ignorate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Aggiorna testo**

Per aggiornare il testo in tutta la presentazione, iterare le diapositive e le forme, selezionare le auto shape e quindi modificare le loro porzioni di testo. Lavorare a livello di porzione consente di modificare sia il testo sia la formattazione dei caratteri.

Il seguente esempio sostituisce ogni occorrenza di `years` con `months` nel testo delle auto shape e rende grassetto ogni porzione interessata:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Questo attraversamento aggiorna il testo solo nelle auto shape. Il testo memorizzato in tabelle, grafici, SmartArt o forme raggruppate richiede l'attraversamento delle proprie collezioni di quegli oggetti.

## **Aggiungi una casella di testo con un collegamento ipertestuale**

Un collegamento ipertestuale può essere assegnato a una specifica porzione di testo, così solo quel testo funge da collegamento cliccabile. Utilizzare [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) per associare la porzione a un URL esterno.

Il seguente esempio crea testo collegato e lo salva in una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo su una diapositiva master o di layout?**

Un [placeholder](/slides/it/python-java/manage-placeholder/) può ereditare la sua posizione e formattazione da una [master slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/) o da una [layout slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/). Una casella di testo regolare è una forma indipendente sulla diapositiva in cui è stata creata e non acquisisce il comportamento di segnaposto quando il layout cambia.

**Come posso sostituire il testo senza modificare quello nei grafici, tabelle o SmartArt?**

Limitare l'attraversamento alle forme che sono istanze di [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/), come mostrato nell'esempio Aggiorna testo. Grafici, tabelle e SmartArt memorizzano il testo nei propri modelli di oggetti, quindi non vengono modificati da quel ciclo.