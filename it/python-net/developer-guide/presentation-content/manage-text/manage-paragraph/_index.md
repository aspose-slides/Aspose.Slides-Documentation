---
title: Gestire i paragrafi di testo PowerPoint in Python
linktitle: Gestire paragrafo
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
- proprietà paragrafo
- importare HTML
- testo a HTML
- paragrafo a HTML
- paragrafo a immagine
- testo a immagine
- esportare paragrafo
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Padroneggia la formattazione dei paragrafi con Aspose.Slides per Python via .NET — ottimizza allineamento, spaziatura e stile nelle presentazioni PowerPoint e OpenDocument in Python per coinvolgere gli spettatori."
---
## **Introduzione**

Aspose.Slides fornisce le classi necessarie per lavorare con il testo di PowerPoint in Python.

* Aspose.Slides fornisce la classe [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) per creare oggetti di riquadri di testo. Un oggetto `TextFrame` può contenere uno o più paragrafi (ogni paragrafo è separato da un ritorno a capo).
* Aspose.Slides fornisce la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) per creare oggetti paragrafo. Un oggetto `Paragraph` può contenere una o più parti di testo.
* Aspose.Slides fornisce la classe [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) per creare oggetti di porzione di testo e specificarne le proprietà di formattazione.

Un oggetto `Paragraph` può gestire testo con diverse proprietà di formattazione tramite le sue sottostanti oggetti `Portion`.

## **Aggiungere più paragrafi contenenti più porzioni**

Questi passaggi mostrano come aggiungere un riquadro di testo che contiene tre paragrafi, ognuno con tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva di destinazione tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare alla diapositiva.
1. Recupera il [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) associato all'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).
1. Crea due oggetti [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e aggiungili alla collezione di paragrafi del [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) (insieme al paragrafo predefinito, otterrai tre paragrafi).
1. Per ogni paragrafo, crea tre oggetti [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) e aggiungili alla collezione di porzioni di quel paragrafo.
1. Imposta il testo per ogni porzione.
1. Applica la formattazione desiderata a ciascuna porzione di testo utilizzando le proprietà esposte da [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/).
1. Salva la presentazione modificata.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanzia la classe Presentation per creare un nuovo file PPTX.
with slides.Presentation() as presentation:

    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi un'AutoShape rettangolare.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Accedi al TextFrame dell'AutoShape.
    text_frame = shape.text_frame

    # Crea paragrafi e porzioni; la formattazione viene applicata di seguito.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Salva il PPTX su disco.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire i punti elenco dei paragrafi**

Le liste puntate ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi con punti elenco sono spesso più facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Accedi alla diapositiva di destinazione tramite il suo indice.
1. Aggiungi un'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) della forma.
1. Rimuovi il paragrafo predefinito dal [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Crea il primo paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/).
1. Imposta il tipo di punto elenco del paragrafo a `SYMBOL` e specifica il carattere del punto.
1. Imposta il testo del paragrafo.
1. Imposta l'indentazione del punto per il paragrafo.
1. Imposta il colore del punto.
1. Imposta la dimensione (altezza) del punto.
1. Aggiungi il paragrafo alla collezione di paragrafi del [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Aggiungi un secondo paragrafo e ripeti i passaggi da 7 a 12.
1. Salva la presentazione.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea un'istanza di presentazione.
with slides.Presentation() as presentation:

    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi e accedi a un'AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accedi al riquadro di testo dell'AutoShape creata.
    text_frame = shape.text_frame

    # Rimuovi il paragrafo predefinito.
    text_frame.paragraphs.remove_at(0)

    # Crea un paragrafo.
    paragraph = slides.Paragraph()

    # Imposta lo stile e il simbolo del punto elenco del paragrafo.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Imposta il testo del paragrafo.
    paragraph.text = "Welcome to Aspose.Slides"

    # Imposta l'indentazione del punto.
    paragraph.paragraph_format.indent = 25

    # Imposta il colore del punto.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Imposta l'altezza del punto.
    paragraph.paragraph_format.bullet.height = 100

    # Aggiungi il paragrafo al riquadro di testo.
    text_frame.paragraphs.add(paragraph)

    # Crea il secondo paragrafo.
    paragraph2 = slides.Paragraph()

    # Imposta il tipo e lo stile del punto elenco del paragrafo.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Imposta il testo del paragrafo.
    paragraph2.text = "This is numbered bullet"

    # Imposta l'indentazione del punto.
    paragraph2.paragraph_format.indent = 25

    # Imposta il colore del punto.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Imposta l'altezza del punto.
    paragraph2.paragraph_format.bullet.height = 100

    # Aggiungi il paragrafo al riquadro di testo.
    text_frame.paragraphs.add(paragraph2)

    # Salva la presentazione come file PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire punti elenco con immagini**

Le liste puntate ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I punti elenco con immagini sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Accedi alla diapositiva di destinazione tramite il suo indice.
1. Aggiungi un'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) della forma.
1. Rimuovi il paragrafo predefinito dal [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Crea il primo paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/).
1. Carica un'immagine in un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/).
1. Imposta il tipo di punto elenco a [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) e assegna l'immagine.
1. Imposta il testo del paragrafo.
1. Imposta l'indentazione del paragrafo per il punto.
1. Imposta il colore del punto.
1. Imposta l'altezza del punto.
1. Aggiungi il nuovo paragrafo alla collezione di paragrafi del [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Aggiungi un secondo paragrafo e ripeti i passaggi da 8 a 12.
1. Salva la presentazione.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]

    # Carica l'immagine del punto elenco.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Aggiungi e accedi a un'AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accedi al TextFrame dell'AutoShape creata.
    text_frame = auto_shape.text_frame

    # Rimuovi il paragrafo predefinito.
    text_frame.paragraphs.remove_at(0)

    # Crea un nuovo paragrafo.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Imposta il tipo di punto elenco del paragrafo su Immagine e assegna l'immagine.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Imposta l'altezza del punto.
    paragraph.paragraph_format.bullet.height = 100

    # Aggiungi il paragrafo al riquadro di testo.
    text_frame.paragraphs.add(paragraph)

    # Salva la presentazione come file PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Salva la presentazione come file PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Gestire punti elenco a più livelli**

Le liste puntate ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I punti elenco a più livelli sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Accedi alla diapositiva di destinazione tramite il suo indice.
1. Aggiungi un'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Accedi al [TextFrame] dell'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).
1. Rimuovi il paragrafo predefinito dal [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Crea il primo paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta la sua profondità a 0.
1. Crea il secondo paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta la sua profondità a 1.
1. Crea il terzo paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta la sua profondità a 2.
1. Crea il quarto paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta la sua profondità a 3.
1. Aggiungi i nuovi paragrafi alla collezione di paragrafi del [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Salva la presentazione.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea un'istanza di presentazione.
with slides.Presentation() as presentation:

    # Accedi alla prima diapositiva.
    slide = presentation.slides[0]
    
    # Aggiungi un'AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accedi al TextFrame dell'AutoShape creata.
    text_frame = auto_shape.text_frame
    
    # Cancella il paragrafo predefinito.
    text_frame.paragraphs.clear()

    # Aggiungi il primo paragrafo.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Imposta il livello del punto elenco.
    paragraph1.paragraph_format.depth = 0

    # Aggiungi il secondo paragrafo.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Imposta il livello del punto elenco.
    paragraph2.paragraph_format.depth = 1

    # Aggiungi il terzo paragrafo.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Imposta il livello del punto elenco.
    paragraph3.paragraph_format.depth = 2

    # Aggiungi il quarto paragrafo.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Imposta il livello del punto elenco.
    paragraph4.paragraph_format.depth = 3

    # Aggiungi i paragrafi alla collezione.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Salva la presentazione come file PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire paragrafi con elenchi numerati personalizzati**

La classe [BulletFormat] fornisce la proprietà `numbered_bullet_start_with` (e altre) per controllare la numerazione e la formattazione personalizzate dei paragrafi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Accedi alla diapositiva che conterrà i paragrafi.
1. Aggiungi un'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) della forma.
1. Rimuovi il paragrafo predefinito dal [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Crea il primo [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta `numbered_bullet_start_with` a 2.
1. Crea il secondo [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta `numbered_bullet_start_with` a 3.
1. Crea il terzo [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) e imposta `numbered_bullet_start_with` a 7.
1. Aggiungi i paragrafi alla collezione del [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
1. Salva la presentazione.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Aggiungi e accedi a un'AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accedi al TextFrame dell'AutoShape creata.
    text_frame = shape.text_frame

    # Rimuovi il paragrafo predefinito esistente.
    text_frame.paragraphs.remove_at(0)

    # Crea il primo elemento numerato (inizia a 2, livello di profondità 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Crea il secondo elemento numerato (inizia a 3, livello di profondità 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Crea il terzo elemento numerato (inizia a 7, livello di profondità 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare l'indentazione della prima riga per un paragrafo**

Usa la proprietà [ParagraphFormat.indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) per controllare l'indentazione della prima riga di un paragrafo. Questa proprietà sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga verso destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [ParagraphFormat.margin_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/margin_left/) quando devi spostare l'intero paragrafo. Usa [ParagraphFormat.indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) quando devi spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori `indent` differenti per dimostrare come l'indentazione della prima riga influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori [indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) differenti per ciascuno.
6. Aggiungi i paragrafi al riquadro di testo.
7. Salva la presentazione modificata.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

![Indentazione della prima riga dei paragrafi](first_line_indent.png)

## **Impostare l'indentazione sospesa per un paragrafo**

Un'indentazione sospesa è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, crei questo effetto con la proprietà [ParagraphFormat.indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/). Imposta `indent` a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/margin_left/) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat.indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un'indentazione sospesa, imposta un valore positivo per `margin_left` e un valore negativo per `indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [margin_left](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/margin_left/) per ciascun paragrafo.
6. Imposta un valore negativo di [indent](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/indent/) per creare l'effetto di indentazione sospesa.
7. Aggiungi i paragrafi al riquadro di testo.
8. Salva la presentazione modificata.

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

![Indentazione sospesa dei paragrafi](hanging_indent.png)

## **Gestire il formato della porzione di fine paragrafo**

Quando devi controllare lo stile della "fine" di un paragrafo (la formattazione applicata dopo l'ultima porzione di testo), usa la proprietà `end_paragraph_portion_format`. L'esempio seguente applica un carattere Times New Roman più grande alla fine del secondo paragrafo.

1. Crea o apri un file [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni la diapositiva di destinazione tramite l'indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Usa il [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) della forma e crea due paragrafi.
5. Crea un [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/) impostato a Times New Roman 48 pt e applicalo come formato di fine porzione del paragrafo.
6. Assegna questa impostazione alla proprietà `end_paragraph_portion_format` del paragrafo (si applica alla fine del secondo paragrafo).
7. Scrivi la presentazione modificata in un file PPTX.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Importare testo HTML nei paragrafi**

Aspose.Slides fornisce un supporto avanzato per importare testo HTML nei paragrafi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione tramite il suo indice.
3. Aggiungi un'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) dell'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).
5. Rimuovi il paragrafo predefinito dal [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
6. Leggi il file HTML di origine.
7. Crea il primo paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/).
8. Aggiungi il contenuto HTML alla collezione di paragrafi del [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).
9. Salva la presentazione modificata.

```python
import aspose.slides as slides

# Crea un'istanza di Presentation vuota.
with slides.Presentation() as presentation:

    # Accedi alla prima diapositiva della presentazione.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Aggiungi un'AutoShape per contenere il contenuto HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Cancella tutti i paragrafi nel riquadro di testo aggiunto.
    shape.text_frame.paragraphs.clear()

    # Carica il file HTML.
    with open("file.html", "rt") as html_stream:
        # Aggiungi il testo dal file HTML al riquadro di testo.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Salva la presentazione.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Esportare il testo del paragrafo in HTML**

Aspose.Slides fornisce un supporto avanzato per esportare il testo in HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione di destinazione.
2. Accedi alla diapositiva desiderata tramite il suo indice.
3. Seleziona la forma che contiene il testo da esportare.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) della forma.
5. Apri uno stream di file per scrivere l'output HTML.
6. Specifica l'indice di partenza ed esporta i paragrafi richiesti.

```python
import aspose.slides as slides

# Carica il file della presentazione.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Accedi alla prima diapositiva della presentazione.
    slide = presentation.slides[0]

    # Indice della forma di destinazione.
    index = 0

    # Accedi alla forma tramite indice.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Scrivi i dati dei paragrafi in HTML fornendo l'indice del paragrafo iniziale e il numero totale di paragrafi da esportare.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Salvare un paragrafo come immagine**

Nella presente sezione, esploreremo due esempi che dimostrano come salvare un paragrafo di testo, rappresentato dalla classe [Paragraph], come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo utilizzando i metodi `get_image` della classe [Shape], il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. Questi approcci consentono di estrarre parti specifiche del testo da presentazioni PowerPoint e salvarle come immagini separate, utili per ulteriori utilizzi in vari scenari.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio, otteniamo il secondo paragrafo come immagine. Per fare ciò, estraiamo l'immagine della forma dalla prima diapositiva della presentazione e poi calcoliamo i limiti del secondo paragrafo nel riquadro di testo della forma. Il paragrafo viene quindi ridisegnato su una nuova immagine bitmap, che viene salvata in formato PNG. Questo metodo è particolarmente utile quando è necessario salvare un paragrafo specifico come immagine separata preservando le dimensioni e la formattazione esatte del testo.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Salva la forma in memoria come bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Crea un bitmap della forma dalla memoria.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calcola i limiti del secondo paragrafo.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

![L'immagine del paragrafo](paragraph_to_image_output.png)

**Esempio 2**

In questo esempio, estendiamo l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala di `2`. Ciò consente un output a risoluzione più alta durante l'esportazione del paragrafo. I limiti del paragrafo vengono quindi calcolati tenendo conto della scala. La scalatura può essere particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per l'uso in materiali stampati di alta qualità.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Salva la forma in memoria come bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Crea un bitmap della forma dalla memoria.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calcola i limiti del secondo paragrafo.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**Posso disabilitare completamente l'andare a capo all'interno di un TextFrame?**

Sì. Usa l'impostazione di avvolgimento del TextFrame ([wrap_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/wrap_text/)) per disattivare l'andare a capo in modo che le linee non si interrompano ai bordi del riquadro.

**Come posso ottenere i limiti esatti sulla diapositiva di un paragrafo specifico?**

Puoi recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola porzione) per conoscere la sua posizione e dimensione precise sulla diapositiva.

**Dove è controllato l'allineamento del paragrafo (sinistra/destra/centrato/giustificato)?**

[Alignment](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/alignment/) è un'impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/); si applica all'intero paragrafo indipendentemente dalla formattazione di singole porzioni.

**Posso impostare una lingua di correzione ortografica solo per una parte di un paragrafo (ad esempio, una parola)?**

Sì. La lingua è impostata a livello di porzione ([PortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/language_id/)), quindi più lingue possono coesistere all'interno di un singolo paragrafo.