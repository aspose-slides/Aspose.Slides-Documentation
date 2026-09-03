---
title: Gestire le caselle di testo nelle presentazioni con Python
linktitle: Gestire casella di testo
type: docs
weight: 20
url: /it/python-net/manage-textbox/
keywords:
- casella di testo
- riquadro di testo
- aggiungere testo
- aggiornare testo
- creare casella di testo
- verificare casella di testo
- aggiungere colonna di testo
- aggiungere collegamento ipertestuale
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Creare, identificare, formattare e aggiornare le caselle di testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET."
---
## **Introduzione**

In Aspose.Slides per Python via .NET, il testo delle diapositive è memorizzato in riquadri di testo che appartengono a forme. La [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) class rappresenta la forma più comune contenente testo e rende disponibile il suo testo attraverso la proprietà [AutoShape.text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Note" %}}

Ogni auto shape eredita da [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/), ma non ogni forma è un'auto shape o supporta un riquadro di testo. Quando si elabora una presentazione esistente, usare `isinstance(shape, slides.AutoShape)` per verificare il tipo di forma prima di accedere al suo testo.

{{% /alert %}}

## **Crea una casella di testo su una diapositiva**

Per creare una casella di testo, aggiungere un'auto shape a una diapositiva, aggiungere testo al suo riquadro di testo e salvare la presentazione. Il seguente esempio crea una casella di testo rettangolare:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Le coordinate e le dimensioni passate a [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_auto_shape/) sono misurate in punti. [AutoShape.add_text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/add_text_frame/) inizializza il riquadro di testo con il testo fornito.

## **Verifica una forma di casella di testo**

Usa la proprietà [AutoShape.is_text_box](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/is_text_box/) per determinare se un'auto shape è considerata una casella di testo. Questo è utile quando una presentazione contiene sia auto shape con testo sia auto shape puramente grafiche.

![Una casella di testo e una forma](istextbox.png)

Il seguente esempio ispeziona ogni auto shape in una presentazione:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Una auto shape appena aggiunta non è considerata una casella di testo finché non contiene testo non vuoto. È possibile fornire quel testo tramite [AutoShape.add_text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/add_text_frame/) o [TextFrame.text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/text/). L'aggiunta o l'assegnazione di una stringa vuota lascia [is_text_box](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/is_text_box/) impostato su `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Le prime due chiamate stampano `True`; le ultime due stampano `False`.

## **Trova la forma proprietaria di un riquadro di testo**

Il codice generico di elaborazione del testo può ricevere un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) senza sapere quale oggetto della presentazione lo contiene. Usa la proprietà di sola lettura [TextFrame.parent_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_shape/) per tornare alla sua [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) proprietaria.

Per un riquadro di testo posseduto da un'auto shape o da un'altra forma contenente testo, [parent_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_shape/) contiene il proprietario e [TextFrame.parent_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_cell/) è `None`. Controlla il valore restituito prima di accedervi. Per identificare sia i proprietari delle forme sia le celle della tabella, incluse le forme associate a nodi SmartArt, vedi [Search and Replace Text](/slides/it/python-net/search-and-replace-text/).

## **Aggiungi colonne a una casella di testo**

La proprietà [TextFrameFormat.column_count](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/column_count/) divide il riquadro di testo in colonne, mentre [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/column_spacing/) imposta lo spazio tra le colonne in punti. Entrambe le impostazioni appartengono a [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) e possono essere modificate tramite il riquadro di testo di una casella di testo esistente. Il testo fluisce tra le colonne all'interno della stessa forma; non continua in un'altra forma.

Il seguente esempio crea una casella di testo a tre colonne con 10 punti tra le colonne, salva la presentazione e legge le impostazioni memorizzate dal file di output:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Estrai testo da colonne individuali**

Usa [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/split_text_by_columns/) per recuperare il testo assegnato a ciascuna colonna visiva in un riquadro di testo esistente. Il metodo restituisce una stringa per ogni colonna, in ordine di lettura basato sulle colonne. Un riquadro di testo a colonna singola produce una lista con un elemento, e una colonna vuota è rappresentata da una stringa vuota. Le stringhe contengono solo testo semplice; la formattazione a livello di porzione non viene preservata.

Questo è utile quando è necessario:

- Estrarre il testo mantenendo l'ordine di lettura basato sulle colonne.
- Indicizzare o confrontare il contenuto di diapositive a più colonne.
- Esportare ogni colonna in un file separato, campo di database o altra destinazione.
- Esaminare come il testo viene ridistribuito dopo aver modificato [TextFrameFormat.column_count](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/column_spacing/), il carattere o le dimensioni del riquadro di testo.

Il metodo riporta il testo distribuito all'interno dell'attuale [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/); non fluisce automaticamente il testo tra forme o caselle di testo separate. La distribuzione delle colonne può dipendere dai caratteri disponibili e da altre impostazioni di layout del testo, quindi assicurati che i caratteri richiesti siano disponibili quando è importante ottenere risultati coerenti.

Il seguente esempio carica una presentazione, trova la prima auto shape a più colonne con un riquadro di testo, legge il conteggio delle colonne configurato e scrive il testo di ogni colonna in un file separato. Le forme che non forniscono un riquadro di testo sono ignorate.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Aggiorna il testo**

Per aggiornare il testo in tutta la presentazione, itera tra le diapositive e le forme, seleziona le auto shape e quindi modifica le loro porzioni di testo. Lavorare a livello di porzione consente di modificare sia il testo sia la formattazione dei caratteri.

Il seguente esempio sostituisce ogni occorrenza di `years` con `months` nel testo delle auto shape e rende grassetto ogni porzione interessata:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Questo attraversamento aggiorna il testo solo nelle auto shape. Il testo memorizzato in tabelle, grafici, SmartArt o forme raggruppate richiede l'attraversamento delle collezioni proprie di quegli oggetti.

## **Aggiungi una casella di testo con un collegamento ipertestuale**

È possibile assegnare un collegamento ipertestuale a una specifica porzione di testo, così solo quel testo funge da collegamento cliccabile. Usa [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) per associare la porzione a un URL esterno.

Il seguente esempio crea testo collegato e lo salva in una presentazione:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo su una diapositiva master o layout?**

Un [placeholder](/slides/it/python-net/manage-placeholder/) può ereditare posizione e formattazione da una [master slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslide/) o da una [layout slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/). Una casella di testo normale è una forma indipendente sulla diapositiva in cui è stata creata e non acquisisce il comportamento di placeholder quando il layout cambia.

**Come posso sostituire il testo senza modificare il testo nei grafici, tabelle o SmartArt?**

Limita l'attraversamento alle istanze di [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) come mostrato nell'esempio Aggiorna il testo. Grafici, tabelle e SmartArt memorizzano il testo nei propri modelli di oggetti, quindi non vengono modificati da quel ciclo.