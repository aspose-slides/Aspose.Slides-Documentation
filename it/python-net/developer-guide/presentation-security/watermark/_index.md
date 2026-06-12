---
title: Aggiungere filigrana alle presentazioni in Python
linktitle: Filigrana
type: docs
weight: 40
url: /it/python-net/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana di immagine
- aggiungi filigrana
- modifica filigrana
- rimuovi filigrana
- elimina filigrana
- aggiungi filigrana a PPT
- aggiungi filigrana a PPTX
- aggiungi filigrana a ODP
- rimuovi filigrana da PPT
- rimuovi filigrana da PPTX
- rimuovi filigrana da ODP
- elimina filigrana da PPT
- elimina filigrana da PPTX
- elimina filigrana da ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come gestire watermark di testo e immagine in presentazioni PowerPoint e OpenDocument con Python per indicare una bozza, informazioni riservate, copyright e altro."
---
## **Introduzione**

**Un watermark** in una presentazione è un timbro di testo o immagine usato su una diapositiva o su tutte le diapositive della presentazione. Solitamente, un watermark viene utilizzato per indicare che la presentazione è una bozza (ad es. un watermark “Bozza”), che contiene informazioni riservate (ad es. un watermark “Confidenziale”), per specificare a quale azienda appartiene (ad es. un watermark “Nome Azienda”), per identificare l’autore della presentazione, ecc. Un watermark aiuta a prevenire violazioni di copyright indicando che la presentazione non deve essere copiata. I watermark sono usati sia nei formati di presentazione PowerPoint sia in quelli OpenOffice. In Aspose.Slides, è possibile aggiungere un watermark ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/python-net/), esistono vari modi per creare watermark in documenti PowerPoint o OpenOffice e modificarne design e comportamento. L’aspetto comune è che, per aggiungere watermark di testo, si deve utilizzare la classe [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/), e per aggiungere watermark di immagine, si usa la classe [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) oppure si riempie una forma watermark con un’immagine. `PictureFrame` implementa la classe [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/), consentendo di usare tutte le impostazioni flessibili dell’oggetto shape. Poiché `TextFrame` non è una shape e le sue impostazioni sono limitate, viene racchiuso in un oggetto [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/).

Esistono due modalità per applicare un watermark: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master è usato per applicare un watermark a tutte le diapositive: il watermark viene aggiunto allo Slide Master, progettato completamente lì e applicato a tutte le diapositive senza influire sul permesso di modificare il watermark su singole diapositive.

Di solito un watermark è considerato non modificabile da altri utenti. Per impedire la modifica del watermark (o piuttosto della forma madre del watermark), Aspose.Slides fornisce la funzionalità di blocco delle forme. Una forma specifica può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma del watermark è bloccata sullo Slide Master, sarà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per il watermark così che, in futuro, se lo si desidera eliminare, lo si possa trovare tra le forme della diapositiva per nome.

È possibile progettare il watermark in qualsiasi modo; tuttavia, esistono caratteristiche comuni nei watermark, come l’allineamento centrale, la rotazione, la posizione in primo piano, ecc. Vedremo come usarle negli esempi seguenti.

## **Watermark di Testo**

### **Aggiungere un Watermark di Testo a una Diapositiva**

Per aggiungere un watermark di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, poi aggiungere un frame di testo a quella forma. Il frame di testo è rappresentato dalla classe [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/). Questo tipo non eredita da [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/), che offre un ampio set di proprietà per posizionare il watermark in modo flessibile. Perciò, l’oggetto [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) è racchiuso in un oggetto [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/). Per aggiungere il testo del watermark alla forma, utilizza il metodo [add_text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/add_text_frame/#str) come mostrato sotto.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come utilizzare la classe TextFrame](/slides/it/python-net/text-formatting/)
{{% /alert %}}

### **Aggiungere un Watermark di Testo a una Presentazione**

Se desideri aggiungere un watermark di testo all’intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungilo allo [MasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/masterslide/). Il resto della logica è identico a quello che si usa per aggiungere un watermark a una singola diapositiva: crea un oggetto [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) e poi aggiungi il watermark usando il metodo [add_text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Vedi anche" %}} 
- [Come utilizzare lo Slide Master](/slides/it/python-net/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma del Watermark**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e di bordo. Le righe di codice seguenti rendono la forma trasparente.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Impostare il Font per un Watermark di Testo**

Puoi modificare il font del watermark di testo come mostrato sotto.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Impostare il Colore del Testo del Watermark**

Per impostare il colore del testo del watermark, usa questo codice:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centrare un Watermark di Testo**

È possibile centrare il watermark su una diapositiva; per farlo, esegui quanto segue:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

L’immagine sotto mostra il risultato finale.

![The text watermark](text_watermark.png)

## **Watermark di Immagine**

### **Aggiungere un Watermark di Immagine a una Presentazione**

Per aggiungere un watermark di immagine a una diapositiva della presentazione, puoi procedere come segue:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Bloccare un Watermark dalla Modifica**

Se è necessario impedire la modifica di un watermark, utilizza la proprietà [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/auto_shape_lock/) sulla forma. Con questa proprietà è possibile proteggere la forma da selezione, ridimensionamento, riposizionamento, raggruppamento con altri elementi, bloccare il testo dalla modifica e molto altro:

```py
# Blocca la forma del watermark dalla modifica
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Portare un Watermark in Primo Piano**

In Aspose.Slides, l’ordine Z delle forme può essere impostato tramite il metodo [ShapeCollection.reorder](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Per farlo, è necessario chiamare questo metodo dall’elenco delle diapositive della presentazione e passare il riferimento della forma e il suo numero di ordine. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se devi posizionare un watermark davanti alla presentazione:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Impostare la Rotazione del Watermark**

Ecco un esempio di codice su come regolare la rotazione del watermark in modo che sia posizionato diagonalmente sulla diapositiva:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Impostare un Nome per un Watermark**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma del watermark, assegnalo alla proprietà [AutoShape.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Rimuovere un Watermark**

Per rimuovere la forma del watermark, usa il metodo [AutoShape.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/name/) per trovarla tra le forme della diapositiva. Quindi, passa la forma del watermark al metodo [ShapeCollection.remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Un Esempio Interattivo**

Puoi provare gli strumenti online **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/it/watermark) e [Remove Watermark](https://products.aspose.app/slides/it/watermark/remove-watermark).

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Che cos’è un watermark e perché dovrei usarlo?**

Un watermark è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, migliorare il riconoscimento del brand o prevenire l’uso non autorizzato delle presentazioni.

**Posso aggiungere un watermark a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere un watermark a ogni diapositiva della presentazione. È possibile iterare su tutte le diapositive e applicare le impostazioni del watermark singolarmente.

**Come posso regolare la trasparenza del watermark?**

Puoi regolare la trasparenza del watermark modificando le impostazioni di riempimento ([FillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/)) della forma. Questo garantisce che il watermark sia discreto e non distolga l’attenzione dal contenuto della diapositiva.

**Quali formati di immagine sono supportati per i watermark?**

Aspose.Slides supporta vari formati di immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il font e lo stile di un watermark di testo?**

Sì, puoi scegliere qualsiasi font, dimensione e stile per adattarli al design della tua presentazione e mantenere la coerenza del brand.

**Come faccio a cambiare la posizione o l’orientamento di un watermark?**

Puoi modificare la posizione e l’orientamento del watermark regolando le coordinate, le dimensioni e le proprietà di rotazione della [shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/).