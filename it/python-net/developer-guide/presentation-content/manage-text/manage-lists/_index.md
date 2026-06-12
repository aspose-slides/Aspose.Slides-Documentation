---
title: Gestire elenchi puntati e numerati nelle presentazioni in Python
linktitle: Gestisci elenchi
type: docs
weight: 70
url: /it/python-net/manage-lists/
keywords:
- puntatore
- elenco puntato
- elenco numerato
- puntatore simbolo
- puntatore immagine
- puntatore personalizzato
- elenco a più livelli
- crea puntatore
- aggiungi puntatore
- aggiungi elenco
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagini, a più livelli e numerati in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Aspose.Slides per Python tramite .NET consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni di punteggio sono controllate tramite il suo formato di paragrafo.

Utilizza la proprietà [Paragraph.paragraph_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/paragraph_format/) per accedere alle impostazioni di elenco a livello di paragrafo. Il punto di ingresso principale è [ParagraphFormat.bullet](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/bullet/), che restituisce un oggetto [BulletFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/). Con questo oggetto è possibile impostare il tipo di puntatore, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero iniziale.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un puntatore immagine
- creare un elenco multlivello impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) e imposta [BulletFormat.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/type/) su [BulletType.SYMBOL](https://reference.aspose.com/slides/it/python-net/aspose.slides/bullettype/). Puoi quindi impostare [BulletFormat.char](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/color/), e [BulletFormat.height](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/height/) per controllare l'aspetto del puntatore.

Il seguente codice Python dimostra come creare un elenco puntato in una diapositiva:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![I simboli puntati](symbol_bullets.png)

## **Creare un elenco numerato**

Utilizza gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [BulletFormat.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/type/) su [BulletType.NUMBERED](https://reference.aspose.com/slides/it/python-net/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/numbered_bullet_style/) oppure impostare [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) quando l'elenco deve iniziare da un valore diverso da 1.

Il seguente codice Python mostra come creare un elenco numerato in una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![I puntatori numerati](numbered_bullets.png)

## **Creare un puntatore immagine**

Aspose.Slides consente di sostituire un simbolo di puntatore normale con un'immagine. I puntatori immagine funzionano al meglio con immagini semplici che rimangono leggibili a dimensioni ridotte, come icone o piccoli file PNG trasparenti.

{{% alert color="primary" %}}
Idealmente, se prevedi di sostituire il simbolo di puntatore normale con un'immagine, è consigliabile scegliere una grafica semplice con sfondo trasparente. Tale immagine funziona bene come simbolo di puntatore personalizzato.
{{% /alert %}}

Per creare un puntatore immagine, aggiungi un'immagine a [Presentation.images](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/images/) e assegna l'oggetto immagine restituito a [BulletFormat.picture](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/picture/). Imposta [BulletFormat.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/type/) su [BulletType.PICTURE](https://reference.aspose.com/slides/it/python-net/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per i puntatori](picture_for_bullets.png)

Il seguente codice Python mostra come creare puntatori immagine in una diapositiva:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![I puntatori immagine](picture_bullets.png)

## **Creare un elenco multlivello**

Utilizza [ParagraphFormat.depth](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/depth/) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello più alto, il livello 1 è annidato al di sotto, e così via.

Il seguente codice Python mostra come creare un elenco puntato multlivello:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![L'elenco multlivello](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione di un elenco in una presentazione esistente, accedi al paragrafo di destinazione e aggiorna le sue impostazioni [ParagraphFormat.bullet](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/bullet/). Le stesse proprietà utilizzate per creare gli elenchi possono essere usate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice Python modifica il primo paragrafo in un text frame per utilizzare uno stile di elenco numerato:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**È possibile esportare elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides conserva la formattazione degli elenchi quando il formato di destinazione supporta il layout di testo corrispondente e le funzionalità dei puntatori.

**Posso modificare gli elenchi in presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo di destinazione, ispeziona o aggiorna le sue impostazioni [ParagraphFormat.bullet](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/bullet/), e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, quindi è possibile creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.