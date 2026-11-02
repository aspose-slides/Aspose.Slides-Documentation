---
title: Gestisci elenchi puntati e numerati nelle presentazioni in Python
linktitle: Gestisci elenchi
type: docs
weight: 70
url: /it/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- punto elenco
- elenco puntato
- elenco numerato
- punto simbolo
- punto immagine
- punto personalizzato
- elenco multilivello
- crea punto
- aggiungi punto
- aggiungi elenco
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagini, multilivello e numerati in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Aspose.Slides for Python via .NET ti consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni di punti elenco sono controllate tramite il suo formato paragrafo.

Usa la proprietà [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) per accedere alle impostazioni di elenco a livello di paragrafo. Il punto di ingresso principale è [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), che restituisce un oggetto [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/). Con questo oggetto, puoi impostare il tipo di punto elenco, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero di partenza.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un punto elenco immagine
- creare un elenco multilevel impostando la profondità del paragrafo
- creare un elenco numerato
- ispezionare e modificare la formattazione dell'elenco in una presentazione esistente
- leggere i marcatori e i numeri dell'elenco effettivi accanto al testo del paragrafo

## **Crea un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) e imposta [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) su [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Puoi quindi impostare [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/), e [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) per controllare l'aspetto del punto elenco.

Il seguente codice Python dimostra come creare un elenco puntato in una diapositiva:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
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

![I punti elenco simbolici](symbol_bullets.png)

## **Crea un elenco numerato**

Utilizza gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) su [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) o impostare [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) quando l'elenco deve iniziare da un valore diverso da 1.

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

![I punti elenco numerati](numbered_bullets.png)

## **Crea un punto elenco immagine**

Aspose.Slides ti consente di sostituire un simbolo di punto elenco regolare con un'immagine. I punti elenco immagine funzionano meglio con immagini semplici che rimangono leggibili a piccole dimensioni, come icone o piccoli file PNG trasparenti.

{{% alert color="info" title="Note" %}}
Idealmente, se prevedi di sostituire il simbolo di punto elenco regolare con un'immagine, è consigliabile scegliere una grafica semplice con sfondo trasparente. Tali immagini funzionano bene come simboli di punto elenco personalizzati.

Tieni presente che l'immagine verrà ridotta a una dimensione molto piccola. Per questo motivo, consigliamo vivamente di scegliere un'immagine che rimanga chiara ed efficace visualmente quando usata come punto elenco in un elenco.
{{% /alert %}}

Per creare un punto elenco immagine, aggiungi un'immagine a [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) e assegna l'oggetto immagine restituito a [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). Imposta [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) su [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per i punti elenco](picture_for_bullets.png)

Il seguente codice Python mostra come creare punti elenco immagine in una diapositiva:

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

![I punti elenco immagine](picture_bullets.png)

## **Crea un elenco multilevel**

Usa [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello superiore, il livello 1 è annidato sotto di esso, e così via. La profondità controlla solo l'indentazione; imposta [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) su ogni paragrafo quando i livelli devono anche contenere punti elenco.

Il seguente codice Python mostra come creare un elenco multilevel:

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

![L'elenco multilevel](multilevel_list.png)

## **Modifica un elenco esistente**

Per modificare la formattazione di un elenco in una presentazione esistente, accedi al paragrafo di destinazione e aggiorna le sue impostazioni [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/). Le stesse proprietà usate per creare gli elenchi possono essere utilizzate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice Python cambia il primo paragrafo in un riquadro di testo per utilizzare uno stile di elenco numerato:

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

## **Leggi i valori effettivi dei punti elenco**

Durante l'estrazione del contenuto di una presentazione, mantieni i marcatori dell'elenco accanto al testo del paragrafo. Chiama [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) e accedi a [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) per ottenere il formato effettivo del punto elenco. Controlla il suo [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) prima di leggere [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/).

Per gli elenchi numerati, distingui questi tre valori:

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) determina il formato, come numeri arabi seguiti da un punto o lettere minuscole seguite da un punto.
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) specifica il numero di partenza per un gruppo di paragrafi numerati.
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) restituisce il marcatore formattato per un particolare paragrafo. Per esempio, il secondo elemento in un elenco che inizia da 5 restituisce `6.`.

Conserva [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) con ogni paragrafo per mantenere il suo livello di annidamento. Il marcatore effettivo non codifica l'intera gerarchia: un elemento annidato può restituire `c.` anziché un'etichetta combinata come `6.c.`.

Il seguente esempio autonomo crea elenchi, li salva in una presentazione e ricarica la presentazione per riportare il testo, la profondità, il tipo di punto elenco e il valore effettivo di ciascun paragrafo. Il piccolo marcatore immagine blu è creato da SVG in linea.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # Crea un marcatore immagine senza un file immagine esterno.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

Gli elenchi di origine sono mostrati di seguito.

![Elenchi che iniziano da 5, elementi annidati con lettere e numeri romani, un marcatore simbolico, un paragrafo senza punto elenco e un marcatore immagine blu](actual_bullet_values.png)

Il report corrisponde ai marcatori visualizzati in PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

Per [BulletType.NONE and BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/), [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) restituisce `None`, non una stringa vuota. Gestisci questi tipi separatamente: il primo non ha marcatore, mentre il secondo richiede l'estrazione dell'immagine del punto elenco separatamente. Un punto elenco immagine non può essere riprodotto solo estraendo un marcatore di testo.

## **Domande frequenti**

**È possibile esportare elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides preserva la formattazione degli elenchi quando il formato di destinazione supporta il layout del testo e le funzionalità dei punti elenco corrispondenti.

**Posso modificare gli elenchi in presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo di destinazione, ispeziona o aggiorna le sue impostazioni [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, così puoi creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.