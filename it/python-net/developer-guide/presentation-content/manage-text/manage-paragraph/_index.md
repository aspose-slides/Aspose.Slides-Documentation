---
title: Gestire i paragrafi di testo PowerPoint in Python
linktitle: Gestire Paragrafo
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
- punto elenco paragrafo
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
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Aspose.Slides for Python via .NET rappresenta il testo come una gerarchia di cornici di testo, paragrafi e porzioni:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua collezione di paragrafi.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) rappresenta un paragrafo in una cornice di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) rappresenta un blocco di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con diversi caratteri, colori, dimensioni e altre formattazioni usando più porzioni.

## **Creare e Formattare i Paragrafi**

Crea paragrafi nella cornice di testo di una forma e usa le porzioni per formattare blocchi di testo individuali. Questa sezione mostra come combinare più porzioni all'interno di ciascun paragrafo e applicare diversi colori, dimensioni di carattere e stili.

### **Creare Paragrafi con più Porzioni**

Il seguente esempio Python crea tre paragrafi, ciascuno contenente tre blocchi di testo nella sua collezione [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Riutilizza il paragrafo predefinito e la sua porzione vuota, poi aggiunge i paragrafi e le porzioni rimanenti. La formattazione è applicata tramite [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): la prima porzione in ogni paragrafo è rossa, in grassetto e di 15 punti; la seconda è blu, in corsivo e di 18 punti. La terza porzione mantiene la formattazione predefinita:

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

## **Creare Elenchi Puntati e Numerati**

Organizza il testo dei paragrafi in elenchi con simboli, numeri o immagini personalizzate. Gli esempi in questa sezione coprono la formattazione dei punti, gli elenchi multilevel e i numeri di partenza personalizzati.

### **Creare un Elenco Puntato o Numerato**

I punti elenco e la numerazione rendono più facile esplorare gli elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Questo esempio Python aggiunge un punto simbolo e un elemento numerato alla stessa cornice di testo. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) seleziona il tipo di punto, mentre [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) fornisce il simbolo e [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) seleziona lo stile di numerazione. Entrambi gli elementi usano punti neri con un'altezza del 100 percento e un rientro del paragrafo di 25 punti:

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

### **Usare Puntatori Immagine**

I puntatori immagine ti consentono di usare un'immagine personalizzata al posto di un simbolo o di un numero.

L'esempio richiede `bullets.png` nella directory di lavoro. Questo esempio Python aggiunge un'immagine alla collezione di immagini della presentazione come un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) e la usa come punto del paragrafo. Imposta [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) per usare un punto immagine e assegna l'immagine tramite [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) è impostato al 100 percento per dimensionare il punto in rapporto al testo del paragrafo:

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

### **Creare un Elenco Multilivello**

Imposta [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) per posizionare i paragrafi a diversi livelli di un elenco. Il livello più alto ha una profondità di `0`.

Questo esempio Python assegna valori di [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) da 0 a 3 a quattro paragrafi, creando una gerarchia all'interno di una singola cornice di testo. Ogni paragrafo usa un punto simbolo, con [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) alternato tra un punto rotondo e un trattino per distinguere i livelli adiacenti:

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

### **Avviare gli Elementi Numerati con Valori Personalizzati**

Usa [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

Questo esempio Python imposta [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) per usare la numerazione per tre paragrafi e assegna valori di [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) di 2, 3 e 7. Il valore di partenza è configurato separatamente per ogni paragrafo, consentendo ai numeri visualizzati di saltare valori:

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

## **Controllare il Layout del Paragrafo e le Proprietà di Fine**

Regola i margini e i rientri del paragrafo per controllare la posizione della prima riga e delle righe a capo. È inoltre possibile formattare il segno di fine paragrafo separatamente dalle porzioni di testo visibili.

### **Impostare un Rientro della Prima Riga**

Usa la proprietà [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) per controllare il rientro della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) quando è necessario spostare l'intero paragrafo. Usa [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) quando è necessario spostare solo la prima riga.

Il seguente esempio assegna a tre paragrafi lo stesso [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) di 20 punti e valori di [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) di 0, 20 e 40 punti. Le prime righe iniziano a offset progressivamente maggiori, mentre le righe a capo mantengono lo stesso margine sinistro:

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

![Il rientro della prima riga dei paragrafi](first_line_indent.png)

### **Impostare un Rientro Sospeso**

Un rientro sospeso è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe rimanenti. In Aspose.Slides, crei questo effetto con la proprietà [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Imposta `indent` a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sospeso, imposta un valore positivo di `margin_left` e un valore negativo di `indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

Il seguente esempio Python associa valori di [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) di 40 e 60 punti a valori di [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) di -20 e -30 punti. In ogni paragrafo, la prima riga inizia a sinistra delle righe a capo; il secondo paragrafo ha un rientro sospeso più profondo:

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

![Il rientro sospeso dei paragrafi](hanging_indent.png)

### **Impostare le Proprietà di Fine del Paragrafo**

La proprietà [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) controlla la formattazione del segno di fine paragrafo. L'esempio carica `Test.pptx`, che deve contenere almeno una diapositiva, e crea un [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) con [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) impostato a 48 punti e [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) impostato a Times New Roman. Assegna questo formato al segno di fine del secondo paragrafo, lasciando inalterate le porzioni di testo visibili:

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

## **Contare le Linee Renderizzate**

Per le regole dei paragrafi che influenzano il ritorno a capo automatico e la punteggiatura alla fine della linea, vedi [Control Line Breaking](/slides/it/python-net/text-formatting/#control-line-breaking) e [Control Hanging Punctuation](/slides/it/python-net/text-formatting/#control-hanging-punctuation).

Usa [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) per contare le linee occupate da un paragrafo dopo il layout del testo, includendo il ritorno a capo automatico. È utile quando si verifica la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento in [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) e può occupare diverse linee renderizzate. Un'interruzione di linea esplicita all'interno di un paragrafo forza una nuova linea senza creare un altro paragrafo. Il ritorno a capo automatico crea linee in base alla larghezza disponibile senza inserire interruzioni di linea esplicite nel testo. Contare i paragrafi o i caratteri di interruzione di linea quindi non fornisce il conteggio delle linee renderizzate.

Il seguente esempio crea una forma di testo, conta le sue linee, restringe la forma e poi sostituisce il testo con una stringa più corta. L'esempio abilita [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) e disabilita [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) affinché la larghezza della forma controlli il ritorno a capo senza ridurre automaticamente il testo o ridimensionare la forma. Ogni misurazione utilizza [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle linee nell'intera cornice di testo.

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

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle linee, mentre sostituire il testo con la stringa breve lo riduce. I conteggi esatti possono variare in base alla disponibilità e sostituzione dei caratteri, alla dimensione del carattere, ai margini, all'indentazione, al ritorno a capo e alle impostazioni di autofit. Usa i caratteri e le impostazioni di layout previste per l'ambiente di destinazione quando controlli un modello.

Il numero di linee da solo non determina se il testo supera il contenitore. Anche l'altezza disponibile, le altezze delle linee, la spaziatura di paragrafi e linee e il comportamento di autofit sono importanti; anche una singola linea può superare la larghezza disponibile se il ritorno a capo è disabilitato.

## **Importare ed Esportare il Contenuto dei Paragrafi**

Usa HTML per inserire testo in una presentazione o esportare paragrafi esistenti per l'uso al di fuori di essa. Questa sezione mostra anche come renderizzare paragrafi individuali come immagini, inclusi i paragrafi nelle celle delle tabelle.

### **Importare Testo HTML nei Paragrafi**

Usa [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) per convertire il markup HTML in paragrafi e porzioni in una cornice di testo.

Questo esempio Python legge HTML da `file.html` nella directory di lavoro e passa il markup a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Cancella il paragrafo predefinito della cornice di testo in modo che la cornice contenga solo il contenuto importato. La forma rettangolare lascia un margine di 10 punti su ogni lato della diapositiva:

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

### **Esportare il Testo del Paragrafo in HTML**

Usa [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) per esportare un intervallo selezionato di paragrafi come HTML. Quando riutilizzi il testo di una presentazione su un sito web, potresti voler conservare l'enfasi locale senza portare il carattere, la dimensione o gli stili della casella di testo della presentazione. Imposta [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) per controllare fino a che punto l'esportatore segue l'ereditarietà della formattazione.

Scarica [la presentazione di esempio](text-inheritance.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene una forma di testo con il testo "Inherited text; explicit red 18pt". L'input utilizza deliberatamente diversi livelli di formattazione:

- Lo stile di testo predefinito della presentazione fornisce Calibri e una dimensione di 28 pt.
- Lo stile di testo di primo livello della cornice di testo fornisce testo blu e corsivo.
- Il paragrafo imposta esplicitamente il testo in grassetto.
- La seconda porzione, "explicit red 18pt", imposta esplicitamente testo rosso e una dimensione di 18 pt.

Il seguente esempio completo esporta gli stessi paragrafi tre volte. Passa [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) al metodo di esportazione e scrive ogni risultato in un file HTML UTF-8 separato:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

L'HTML generato contiene il seguente CSS per la prima porzione, "Inherited text; ". La tabella elenca le dichiarazioni rilevanti; altre proprietà generate sono omesse per chiarezza.

| Output | CSS Rilevante per la prima porzione | Aspetto |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Testo blu, grassetto, corsivo a 28 pt in Calibri, se quel carattere è disponibile. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Testo blu, grassetto, corsivo; la pagina o il browser circostante fornisce la famiglia di caratteri e la dimensione. |
| `ParagraphOnly.html` | `font-weight:bold` | Testo in grassetto; la pagina o il browser circostante fornisce la famiglia di caratteri, la dimensione, il colore e lo stile corsivo. |

La seconda porzione mantiene `color:#ff0000`, `font-size:18pt` e `font-weight:bold` in tutti e tre i risultati. Mantiene anche il corsivo con `ALL` e `TEXT_BOX`, ma non con `PARAGRAPH_ONLY`. Limitare l'ereditarietà quindi non rimuove la formattazione assegnata esplicitamente a un paragrafo o a una porzione.

Apri i file nello stesso browser per confrontarli. Nei due modi ristretti, le proprietà CSS omesse sono risolte dagli stili della pagina di destinazione o dai valori predefiniti del browser, quindi l'aspetto risultante dipende da dove viene utilizzato l'HTML.

### **Renderizzare un Paragrafo come Immagine**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Salva il risultato in un file o in uno stream con [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Non è necessario renderizzare la forma contenente o ritagliare manualmente un bitmap.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) può restituire `None` se il paragrafo non può essere trovato nella sua collezione genitore, non ha limiti di rendering validi o non può essere renderizzato. Controlla il risultato prima di salvarlo e libera l'immagine restituita dopo l'uso.

#### **Renderizzare un Paragrafo alla Scala Predefinita**

L'esempio usa `sample.pptx`, una presentazione con una diapositiva la cui prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

Il seguente esempio seleziona il secondo paragrafo all'indice 1 e chiama [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) senza parametri di scala. Verifica che la forma contenga il paragrafo richiesto e che il rendering restituisca un'immagine prima di chiamare [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) per salvarla in formato PNG. Il gestore di contesto rilascia le risorse dell'immagine dopo l'uso.

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

#### **Renderizzare un Paragrafo in una Cella di Tabella con Scalatura**

Usa la sovraccarico di [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) che accetta i parametri `scale_x` e `scale_y` per impostare i fattori di scala orizzontale e verticale. Il seguente esempio crea una tabella, renderizza il paragrafo nella sua prima cella a una larghezza e altezza doppie rispetto al valore predefinito, e salva il risultato come immagine PNG.

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

Un fattore di scala di `1` mantiene quell'asse alla dimensione pixel predefinita. Ad esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono approssimativamente il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e le dimensioni del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output in modo indipendente.

Renderizzare un'intera forma con [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) rimane utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo del paragrafo, usa [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **FAQ**

**Posso disabilitare completamente il ritorno a capo all'interno di una cornice di testo?**

Sì. Imposta [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) per disabilitare il ritorno a capo in modo che le linee non si spezzino ai bordi della cornice di testo.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Usa [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) per recuperare il rettangolo di delimitazione del paragrafo. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni. Per allineare verticalmente le porzioni di diverse dimensioni di carattere all'interno di ogni linea, vedi [Align Fonts Within a Line](/slides/it/python-net/text-formatting/#align-fonts-within-a-line).

**Posso impostare la lingua di correzione per parte di un paragrafo?**

Sì. Imposta [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) per le singole porzioni, così un paragrafo può contenere testo in più lingue.