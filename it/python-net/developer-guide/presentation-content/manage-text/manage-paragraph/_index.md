---
title: Gestire i paragrafi di testo PowerPoint in Python
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire punto elenco
- rientro paragrafo
- rientro sospeso
- punto elenco del paragrafo
- elenco numerato
- elenco puntato
- proprietà del paragrafo
- importare HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esportare paragrafo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini dei paragrafi con Aspose.Slides per Python via .NET."
---
## **Panoramica**

Aspose.Slides per Python via .NET rappresenta il testo come una gerarchia di riquadri di testo, paragrafi e porzioni:

* [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) rappresenta un paragrafo in un riquadro di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) rappresenta un run di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con diversi caratteri, colori, dimensioni e altra formattazione usando più porzioni.

## **Crea e formatta i paragrafi**

### **Crea paragrafi con più porzioni**

I seguenti passaggi creano un riquadro di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame] della forma.
5. Usa il paragrafo predefinito e aggiungi altri due oggetti [Paragraph] al riquadro di testo.
6. Aggiungi sufficienti oggetti [Portion] a ciascun paragrafo affinché contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Imposta il testo di ciascuna porzione.
8. Applica la formattazione a livello di carattere tramite [Portion.portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/portion_format/).
9. Salva la presentazione modificata.

Questo esempio Python implementa i passaggi:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Crea elenchi puntati e numerati**

### **Crea un elenco puntato o numerato**

I punti elenco e la numerazione rendono più facile la scansione di elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [BulletFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva selezionata.
4. Accedi al [TextFrame] della forma.
5. Rimuovi il paragrafo predefinito dal riquadro di testo.
6. Crea un [Paragraph] per un punto simbolo.
7. Imposta [BulletFormat.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/type/) su [BulletType.SYMBOL](https://reference.aspose.com/slides/it/python-net/aspose.slides/bullettype/) e specifica il carattere del punto elenco.
8. Imposta il testo del paragrafo, l'indentazione, il colore del punto elenco e l'altezza del punto elenco.
9. Aggiungi il paragrafo al riquadro di testo.
10. Crea un secondo paragrafo e imposta [BulletFormat.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/type/) su [BulletType.NUMBERED](https://reference.aspose.com/slides/it/python-net/aspose.slides/bullettype/).
11. Configura lo stile del punto numerato e aggiungi il paragrafo al riquadro di testo.
12. Salva la presentazione.

Questo esempio Python crea un punto simbolo e un punto numerato:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Usa punti elenco immagine**

I punti elenco immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) e accedi al suo [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
4. Rimuovi il paragrafo predefinito dal riquadro di testo.
5. Carica l'immagine del punto elenco e aggiungila alla raccolta di immagini della presentazione come [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/).
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta il suo testo.
7. Imposta [BulletFormat.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/type/) su [BulletType.PICTURE](https://reference.aspose.com/slides/it/python-net/aspose.slides/bullettype/).
8. Assegna l'immagine tramite [BulletFormat.picture](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/picture/) e imposta l'altezza del punto elenco.
9. Aggiungi il paragrafo al riquadro di testo.
10. Salva la presentazione modificata.

Questo esempio Python crea un punto elenco immagine:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Crea un elenco multilevel**

Imposta [ParagraphFormat.depth](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/depth/) per collocare i paragrafi a diversi livelli di un elenco. Il livello superiore ha una profondità di `0`.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) e cancella il paragrafo predefinito dal suo riquadro di testo.
3. Crea quattro paragrafi e configura i loro simboli di punto elenco.
4. Imposta i valori di [ParagraphFormat.depth](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/depth/) su `0`, `1`, `2` e `3`.
5. Aggiungi i paragrafi al riquadro di testo e salva la presentazione.

Questo esempio Python crea un elenco puntato a quattro livelli:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Inizia gli elementi numerati dell'elenco con valori personalizzati**

Usa [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) per impostare il numero iniziale mostrato per un paragrafo numerato.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) a una diapositiva.
2. Cancella il paragrafo predefinito dal riquadro di testo della forma.
3. Crea tre paragrafi numerati.
4. Imposta [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/it/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) su `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungi i paragrafi al riquadro di testo e salva la presentazione.

Questo esempio Python assegna un numero di partenza personalizzato a ciascun paragrafo:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlla il layout del paragrafo e le proprietà di fine**

### **Imposta un rientro della prima riga**

Usa la proprietà [ParagraphFormat.indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) per controllare il rientro della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le linee rimanenti rimangono allineate al corpo del paragrafo.

Usa [ParagraphFormat.margin_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/margin_left/) quando è necessario spostare l'intero paragrafo. Usa [ParagraphFormat.indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori diversi di [ParagraphFormat.indent] per dimostrare come il rientro della prima riga influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame] della forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [ParagraphFormat.indent] per ciascuno.
6. Aggiungi i paragrafi al riquadro di testo.
7. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro di un paragrafo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![L'indentazione della prima riga dei paragrafi](first_line_indent.png)

### **Imposta un rientro sospeso**

Un rientro sospeso è un layout del paragrafo in cui la prima riga inizia a sinistra delle righe rimanenti. In Aspose.Slides, crei questo effetto con la proprietà [ParagraphFormat.indent]. Imposta `indent` a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat.margin_left] definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat.indent] definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sospeso, imposta un valore positivo di `margin_left` e un valore negativo di `indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo piuttosto che sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedi al [TextFrame] della forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [ParagraphFormat.margin_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/margin_left/) per ciascun paragrafo.
6. Imposta un valore negativo di [ParagraphFormat.indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) per creare l'effetto di rientro sospeso.
7. Aggiungi i paragrafi al riquadro di testo.
8. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro sospeso per un paragrafo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![L'indentazione sospesa dei paragrafi](hanging_indent.png)

### **Imposta le proprietà di fine esecuzione del paragrafo**

La proprietà [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) controlla la formattazione del segno di fine paragrafo. Il seguente esempio assegna una dimensione del carattere e un carattere latino al segno di fine del secondo paragrafo:

1. Carica una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) e rimuovi il suo paragrafo predefinito.
3. Crea due paragrafi e aggiungi porzioni di testo a ciascuno.
4. Crea un [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Imposta [PortionFormat.font_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/font_height/) e [PortionFormat.latin_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/latin_font/).
6. Assegna il formato a [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) e salva la presentazione.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Conta le linee renderizzate**

Usa [Paragraph.get_lines_count](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/get_lines_count/) per contare le linee occupate da un paragrafo dopo il layout del testo, includendo l'andamento automatico. Questo è utile quando si verifica la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento in [TextFrame.paragraphs](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/paragraphs/), e può occupare diverse linee renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo fornisce una nuova riga senza creare un altro paragrafo. L'andamento automatico crea linee basate sulla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Contare i paragrafi o i caratteri di interruzione di riga quindi non fornisce il conteggio delle linee renderizzate.

L'esempio seguente crea una forma di testo, conta le sue linee, restringe la forma, quindi sostituisce il testo con una stringa più corta. L'andamento è abilitato e l'autofit è disabilitato in modo che la larghezza della forma controlli l'andamento senza ridimensionare automaticamente il testo o la forma. Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle linee in tutto il riquadro di testo.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle linee, mentre sostituire il testo con la stringa breve lo riduce. I conteggi esatti possono variare in base alla disponibilità e sostituzione dei caratteri, alla dimensione del carattere, ai margini, all'indentazione, all'andamento e alle impostazioni di autofit. Usa i caratteri e le impostazioni di layout previsti per l'ambiente di destinazione quando verifichi un modello.

Il conteggio delle linee da solo non determina se il testo supera il contenitore. Anche l'altezza disponibile, le altezze delle linee, la spaziatura tra paragrafi e linee e il comportamento dell'autofit sono importanti; anche una singola linea può superare la larghezza disponibile quando l'andamento è disabilitato.

## **Importa ed esporta il contenuto dei paragrafi**

### **Importa testo HTML nei paragrafi**

Usa [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphcollection/add_from_html/) per convertire il markup HTML in paragrafi e porzioni in un riquadro di testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi a una diapositiva e aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).
3. Accedi al [TextFrame] della forma e rimuovi il paragrafo predefinito.
4. Leggi il file HTML di origine.
5. Passa la stringa HTML a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Salva la presentazione modificata.

Questo esempio Python importa HTML in un riquadro di testo:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Esporta il testo del paragrafo in HTML**

Usa [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphcollection/export_to_html/) per esportare un intervallo selezionato di paragrafi come HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi alla diapositiva e trova l'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) che contiene il testo.
3. Accedi al [TextFrame] della forma.
4. Chiama [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphcollection/export_to_html/) specificando l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivi la stringa HTML restituita in un file.

Questo esempio Python esporta tutti i paragrafi dalla prima forma di testo:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Renderizza un paragrafo come immagine**

[Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) fornisce il metodo `get_image` per renderizzare direttamente un singolo paragrafo. Il metodo restituisce un [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) che puoi salvare su file o stream con [IImage.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/save/). Non è necessario renderizzare la forma contenente o ritagliare manualmente una bitmap.

Il metodo `get_image` può restituire `None` se il paragrafo non è trovato nella sua raccolta genitore, non ha limiti di rendering validi o non può essere renderizzato. Controlla il risultato prima di salvarlo e usa l'immagine restituita come gestore di contesto per rilasciare le sue risorse.

#### **Renderizza un paragrafo alla scala predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

Il seguente esempio renderizza il secondo paragrafo in una forma di testo regolare alla scala predefinita e salva l'immagine restituita in formato PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Il risultato:

![L'immagine del paragrafo](paragraph_to_image_output.png)

#### **Renderizza un paragrafo in una cella di tabella con scala**

Passa fattori di scala orizzontali e verticali a `get_image` per controllare le dimensioni del paragrafo renderizzato. Il seguente esempio crea una tabella, renderizza il paragrafo nella sua prima cella al doppio della larghezza e altezza predefinite, e salva il risultato come immagine PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Un fattore di scala di `1` mantiene quell'asse alla dimensione di pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, con quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungheranno l'output indipendentemente.

Renderizzare un'intera forma con [Shape.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/) rimane utile quando l'output deve includere il riempimento, il bordo o altri contesti visivi della forma. Per un'immagine solo del paragrafo, usa `Paragraph.get_image`.

## **FAQ**

**Posso disabilitare completamente l'andamento automatico delle linee all'interno di un riquadro di testo?**

Sì. Imposta [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/wrap_text/) per disabilitare l'andamento automatico in modo che le linee non si interrompano ai bordi del riquadro di testo.

**Come posso ottenere i limiti esatti sulla diapositiva di un paragrafo specifico?**

Usa [Paragraph.get_rect](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/get_rect/) per recuperare il rettangolo di delimitazione del paragrafo. [Portion.get_rect](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/get_rect/) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/alignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per parte di un paragrafo?**

Sì. Imposta [PortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/language_id/) per le singole porzioni, così un paragrafo può contenere testo in più lingue.