---
title: Formattare le forme PowerPoint in Python
linktitle: Formattazione Forma
type: docs
weight: 20
url: /it/python-net/shape-formatting/
keywords:
- formattazione forma
- formattazione linea
- effetto schizzo
- linea forma schizzo
- formattazione stile giunzione
- riempimento gradiente
- riempimento motivo
- riempimento immagine
- riempimento texture
- riempimento colore solido
- trasparenza forma
- ruotare forma
- effetto smussatura 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara a formattare le forme PowerPoint in Python usando Aspose.Slides—imposta riempimenti, linee e stili di effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

Nel PowerPoint, puoi aggiungere forme alle diapositive. Poiché le forme sono costituite da linee, puoi formattarle modificando o applicando effetti ai loro contorni. Inoltre, puoi formattare le forme specificando le impostazioni che controllano come vengono riempiti gli interni.

![formato forma PowerPoint](format-shape-powerpoint.png)

Aspose.Slides per Python fornisce classi e proprietà che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, puoi specificare uno stile di linea personalizzato per una forma. I passaggi seguenti descrivono la procedura:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta lo [line style](https://reference.aspose.com/slides/it/python-net/aspose.slides/linestyle/) della forma.
1. Imposta la larghezza della linea.
1. Imposta lo [dash style](https://reference.aspose.com/slides/it/python-net/aspose.slides/linedashstyle/) della forma.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice Python dimostra come formattare un rettangolo `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Imposta il colore di riempimento per la forma rettangolo.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Applica formattazione alle linee del rettangolo.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Imposta il colore per la linea del rettangolo.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Salva il file PPTX su disco.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti schizzo alle linee della forma**

Un effetto schizzo rende la linea di una forma simile a un disegno a mano libera. Usa [Shape.line_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/line_format/) per accedere alle impostazioni della linea, [LineFormat.sketch_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/lineformat/sketch_format/) per accedere alle impostazioni dello schizzo e [SketchFormat.sketch_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/sketchformat/sketch_type/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/python-net/aspose.slides/linesketchtype/).

Il seguente codice Python mostra come applicare un effetto [LineSketchType.CURVED](https://reference.aspose.com/slides/it/python-net/aspose.slides/linesketchtype/) , leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.NONE](https://reference.aspose.com/slides/it/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Accedi al formato della linea della forma e al suo formato schizzo.
    sketch_format = shape.line_format.sketch_format

    # Applica un effetto schizzo.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Leggi l'effetto schizzo assegnato direttamente alla forma.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Rimuovi l'effetto schizzo.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Il valore restituito da `SketchFormat.sketch_type` rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [LineFormat.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/lineformat/get_effective/), accedi alla proprietà `sketch_format` dell'oggetto restituito e leggi la sua proprietà `sketch_type`. Il valore efficace riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formattare gli stili di unione**

Ecco le tre opzioni di tipo di unione:

* Arrotondato
* Miter
* Smussatura

Per impostazione predefinita, quando PowerPoint unisce due linee a un angolo (ad esempio all'angolo di una forma), utilizza l'impostazione **Round**. Tuttavia, se stai disegnando una forma con angoli acuti, potresti preferire l'opzione **Miter**.

![Lo stile di unione nella presentazione](join-style-powerpoint.png)

Il seguente codice Python dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di unione Miter, Bevel e Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

	# Ottieni la prima diapositiva.
	slide = presentation.slides[0]

	# Aggiungi tre forme automatiche di tipo Rettangolo.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Imposta il colore di riempimento per ciascuna forma rettangolare.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Imposta la larghezza della linea.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Imposta il colore per la linea di ciascun rettangolo.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Imposta lo stile di unione.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Aggiungi testo a ciascun rettangolo.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Salva il file PPTX su disco.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Riempimento a gradiente**

Nel PowerPoint, il Riempimento a gradiente è un'opzione di formattazione che consente di applicare una sfumatura continua di colori a una forma. Ad esempio, puoi applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento a gradiente a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `GRADIENT`.
1. Aggiungi i tuoi due colori preferiti con posizioni definite utilizzando i metodi `add` della raccolta `gradient_stops` esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/gradientformat/).
1. Salva la presentazione modificata come file PPTX.

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo Ellisse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Applica formattazione a gradiente all'ellisse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Imposta la direzione del gradiente.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Aggiungi due fermate di gradiente.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Salva il file PPTX su disco.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

L'ellisse con riempimento a gradiente:

![L'ellisse con riempimento a gradiente](gradient-fill.png)

## **Riempimento motivo**

Nel PowerPoint, il Riempimento motivo è un'opzione di formattazione che consente di applicare un disegno a due colori — come punti, strisce, reticolati o quadretti — a una forma. Puoi scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che puoi applicare alle forme per migliorare l'appeal visivo delle tue presentazioni. Anche dopo aver selezionato un motivo predefinito, puoi comunque specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento motivo a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `PATTERN`.
1. Scegli uno stile di motivo tra le opzioni predefinite.
1. Imposta il [back_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/patternformat/back_color/) del motivo.
1. Imposta il [fore_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/patternformat/fore_color/) del motivo.
1. Salva la presentazione modificata come file PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Imposta il tipo di riempimento a Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Imposta lo stile del motivo.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Imposta i colori di sfondo e primo piano del motivo.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Salva il file PPTX su disco.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il rettangolo con riempimento motivo:

![Il rettangolo con riempimento motivo](pattern-fill.png)

## **Riempimento immagine**

Nel PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma — utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come usare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `PICTURE`.
1. Imposta la modalità di riempimento immagine su `TILE` (o un'altra modalità preferita).
1. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) dall'immagine che desideri utilizzare.
1. Assegna questa immagine alla proprietà `picture.image` del `picture_fill_format` della forma.
1. Salva la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine del loto](lotus.png)

Il seguente codice Python dimostra come riempire una forma con l'immagine:

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Imposta il tipo di riempimento a Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Imposta la modalità di riempimento immagine.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Carica un'immagine e aggiungila alle risorse della presentazione.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Imposta l'immagine.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Salva il file PPTX su disco.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

La forma con riempimento immagine:

![La forma con riempimento immagine](picture-fill.png)

### **Usa immagine a tasselli come texture**

Se desideri impostare un'immagine a tasselli come texture e personalizzare il comportamento del tassellamento, puoi utilizzare le seguenti proprietà della classe [PictureFillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Imposta la modalità di riempimento immagine — `TILE` o `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_alignment/): Specifica l'allineamento dei tasselli all'interno della forma.
- [tile_flip](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_flip/): Controlla se il tassello è capovolto orizzontalmente, verticalmente o entrambi.
- [tile_offset_x](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_offset_x/): Imposta lo spostamento orizzontale del tassello (in punti) dall'origine della forma.
- [tile_offset_y](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_offset_y/): Imposta lo spostamento verticale del tassello (in punti) dall'origine della forma.
- [tile_scale_x](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definisce la scala orizzontale del tassello in percentuale.
- [tile_scale_y](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definisce la scala verticale del tassello in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine a tasselli e configurare le opzioni di tassellamento:

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    first_slide = presentation.slides[0]

    # Aggiungi una forma automatica rettangolare.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Imposta il tipo di riempimento della forma a Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Carica l'immagine e aggiungila alle risorse della presentazione.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Assegna l'immagine alla forma.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configura la modalità di riempimento immagine e le proprietà di tassellamento.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Salva il file PPTX su disco.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Le opzioni di tassellamento:

![Le opzioni di tassellamento](tile-options.png)

## **Riempimento a colore solido**

Nel PowerPoint, il Riempimento a colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradazioni, texture o motivi.

Per applicare un riempimento a colore solido a una forma usando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `SOLID`.
1. Assegna il colore di riempimento desiderato alla forma.
1. Salva la presentazione modificata come file PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Imposta il tipo di riempimento su Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Imposta il colore di riempimento.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Salva il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

La forma con riempimento a colore solido:

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

Nel PowerPoint, quando applichi un riempimento a colore solido, a gradiente, immagine o texture a una forma, puoi anche impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides ti consente di impostare il livello di trasparenza modificando il valore alfa nel colore usato per il riempimento. Ecco come fare:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il tipo di riempimento su `SOLID`.
1. Usa `Color.from_argb` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]
    
    # Aggiungi una forma automatica rettangolare solida.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Aggiungi una forma automatica rettangolare trasparente sopra la forma solida.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

La forma trasparente:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides ti consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando posizioni elementi visivi con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta la proprietà `rotation` della forma sull'angolo desiderato.
1. Salva la presentazione.

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ruota la forma di 5 gradi.
    shape.rotation = 5

    # Salva il file PPTX su disco.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

La rotazione della forma:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smussatura 3D**

Aspose.Slides consente di applicare effetti di smussatura 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).

Per aggiungere effetti di smussatura 3D a una forma, segui questi passaggi:

1. Instanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/) della forma per definire le impostazioni di smussatura.
1. Salva la presentazione.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Aggiungi una forma alla diapositiva.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Imposta le proprietà ThreeDFormat della forma.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Salva la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

L'effetto smussatura 3D:

![L'effetto smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva mediante il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
1. Imposta le proprietà `camera_type` e `light_type` della forma per definire la rotazione 3D.
1. Salva la presentazione.

```python
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Salva la presentazione come file PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

L'effetto rotazione 3D:

![L'effetto rotazione 3D](3D-rotation-effect.png)

## **Ripristinare la formattazione**

Il seguente codice Python mostra come ripristinare la formattazione di una diapositiva e riportare posizione, dimensione e formattazione di tutte le forme con segnaposto sul [LayoutSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/) alle impostazioni predefinite:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reimposta ogni forma sulla diapositiva che ha un segnaposto nel layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo in minima parte. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione aggiuntiva.

**Come posso individuare forme su una diapositiva che condividono la stessa formattazione per poterle raggruppare?**

Confronta le proprietà chiave di formattazione di ciascuna forma — impostazioni di riempimento, linea ed effetti. Se tutti i valori corrispondenti coincidono, considera i loro stili identici e raggruppa logicamente queste forme, semplificando la gestione dello stile in seguito.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarli in altre presentazioni?**

Sì. Salva forme di esempio con gli stili desiderati in una presentazione modello o in un file .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate di cui hai bisogno e riapplica la loro formattazione dove necessario.