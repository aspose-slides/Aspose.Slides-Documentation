---
title: Gestire le caselle di testo nelle presentazioni con Python
linktitle: Gestisci casella di testo
type: docs
weight: 20
url: /it/python-net/manage-textbox/
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
- Aspose.Slides
description: "Aspose.Slides per Python via .NET semplifica la creazione, modifica e clonazione delle caselle di testo in file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive sono tipicamente presenti in caselle di testo o forme. Pertanto, per aggiungere un testo a una diapositiva, è necessario aggiungere una casella di testo e quindi inserire del testo all'interno della casella. Aspose.Slides per Python fornisce la classe [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}
Aspose.Slides fornisce anche la classe [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/). Tuttavia, non tutte le forme possono contenere testo.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, è consigliabile verificare e confermare che sia stata convertita tramite la classe [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/). Solo allora sarà possibile lavorare con [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/), che è una proprietà di [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/). Vedere la sezione [Update Text](/slides/it/python-net/manage-textbox/#update-text) in questa pagina.
{{% /alert %}}

## **Crea caselle di testo su diapositive**

Per creare una casella di testo su una diapositiva:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla prima diapositiva.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` nella posizione desiderata sulla diapositiva.
4. Imposta il testo nel [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) della forma.
5. Salva la presentazione come file PPTX.

Il seguente esempio Python implementa questi passaggi:

```py
import aspose.slides as slides

# Istanziare la classe Presentation.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva nella presentazione.
    slide = presentation.slides[0]

    # Aggiungere un AutoShape di tipo RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Salvare la presentazione su disco.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Verifica se una forma è una casella di testo**

Aspose.Slides fornisce la proprietà [is_text_box](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/is_text_box/) sulla classe [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/), che consente di determinare se una forma è una casella di testo.

![Casella di testo e forma](istextbox.png)

Questo esempio Python mostra come verificare se una forma è stata creata come casella di testo:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Nota che se aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) utilizzando la classe [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/), la proprietà `is_text_box` della forma restituisce `False`. Tuttavia, dopo aver aggiunto del testo—oppure con il metodo `add_text_frame` o impostando la proprietà `text`—`is_text_box` restituisce `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box è falso
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box è vero

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box è falso
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box è vero

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box è falso
    shape3.add_text_frame("")
    # shape3.is_text_box è falso

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box è falso
    shape4.text_frame.text = ""
    # shape4.is_text_box è falso
```

## **Trova la forma che possiede un TextFrame**

Nel codice generico di elaborazione del testo, potresti ricevere un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) senza sapere già quale oggetto di presentazione lo contiene. Usa la proprietà [TextFrame.parent_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_shape/) per tornare alla [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) proprietaria.

Per un TextFrame che appartiene a un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) o a un'altra forma contenente testo, [TextFrame.parent_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_shape/) è impostato e [TextFrame.parent_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_cell/) è `None`. Entrambe le proprietà sono di navigazione in sola lettura, quindi leggerle non modifica la proprietà. Controlla sempre che il valore restituito non sia `None` prima di accedere alla forma.

Per un esempio completo che identifica i proprietari di forme e celle di tabella, incluse le forme associate a nodi SmartArt, vedi [Search and Replace Text](/slides/it/python-net/search-and-replace-text/).

## **Aggiungi colonne alle caselle di testo**

Aspose.Slides fornisce le proprietà [column_count](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/column_count/) e [column_spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/column_spacing/) sulla classe [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/) per aggiungere colonne alle caselle di testo. È possibile specificare il numero di colonne e impostare la spaziatura (in punti) tra le colonne.

Il seguente codice Python dimostra questa operazione:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Ottieni la prima diapositiva nella presentazione.
	slide = presentation.slides[0]

	# Aggiungi un AutoShape di tipo RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Aggiungi un TextFrame al rettangolo.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Ottieni il formato del testo del TextFrame.
	format = shape.text_frame.text_frame_format

	# Specifica il numero di colonne nel TextFrame.
	format.column_count = 3

	# Specifica la spaziatura tra le colonne.
	format.column_spacing = 10

	# Salva la presentazione.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiorna il testo**

Aspose.Slides consente di aggiornare il testo in una singola casella di testo o in tutta la presentazione.

Il seguente esempio Python mostra come aggiornare tutto il testo in una presentazione:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Salva la presentazione modificata.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi caselle di testo con collegamenti ipertestuali**

È possibile inserire un collegamento in una casella di testo. Quando la casella di testo viene cliccata, il collegamento si apre.

Per aggiungere una casella di testo che contiene un collegamento ipertestuale, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla prima diapositiva.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) con `ShapeType.RECTANGLE` nella posizione desiderata sulla diapositiva.
4. Imposta il testo nel [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) della forma.
5. Ottieni un riferimento al [HyperlinkManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/).
6. Usa la proprietà `hyperlink_manager` per impostare un collegamento ipertestuale di click esterno.
7. Salva la presentazione come file PPTX.

Questo esempio Python mostra come aggiungere una casella di testo con un collegamento ipertestuale a una diapositiva:

```py
import aspose.slides as slides

# Istanziare la classe Presentation.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva nella presentazione.
    slide = presentation.slides[0]

    # Aggiungi un AutoShape di tipo RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Aggiungi testo al frame.
    text_portion.text = "Aspose.Slides"

    # Imposta un collegamento ipertestuale per il testo della porzione.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Salva la presentazione come file PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo quando si lavora con le diapositive master?**

Un [placeholder](/slides/it/python-net/manage-placeholder/) eredita lo stile/posizione dal [master](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/). Invece, una casella di testo normale è un oggetto indipendente su una diapositiva specifica e non cambia quando si cambiano i layout.

**Come posso eseguire una sostituzione massiva del testo in tutta la presentazione senza modificare il testo all'interno di grafici, tabelle e SmartArt?**

Limita l'iterazione alle auto‑shape che possiedono TextFrame ed escludi gli oggetti incorporati ([charts](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/)) attraversando le loro collezioni separatamente o ignorando quei tipi di oggetto.