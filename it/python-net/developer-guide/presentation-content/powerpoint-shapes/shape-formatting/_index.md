---
title: Formattare forme PowerPoint in Python
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/python-net/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma a schizzo
- formattare stile di giunzione
- riempimento gradiente
- riempimento motivo
- riempimento immagine
- riempimento texture
- riempimento colore solido
- trasparenza forma
- rendering forma in bianco-nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in Python usando Aspose.Slides - imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando le impostazioni che controllano il riempimento degli interni.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python offre classi e proprietà che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti descrivono la procedura:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare lo [stile della linea](https://reference.aspose.com/slides/it/python-net/aspose.slides/linestyle/) della forma.
5. Impostare lo spessore della linea.
6. Impostare lo [stile tratteggiato](https://reference.aspose.com/slides/it/python-net/aspose.slides/linedashstyle/) della forma.
7. Impostare il colore della linea per la forma.
8. Salvare la presentazione modificata come file PPTX.

Il seguente codice Python dimostra come formattare un `AutoShape` rettangolare:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere una forma automatica di tipo Rettangolo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Rimuovere il riempimento dalla forma rettangolo in modo che siano visibili solo le linee.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Applicare la formattazione alle linee del rettangolo.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Impostare il colore della linea del rettangolo.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Salvare il file PPTX su disco.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The formatted lines in the presentation](formatted-lines.png)

## **Applicare effetti di schizzi alle linee delle forme**

Un effetto di schizzo rende la linea di una forma simile a un disegno a mano libera. Utilizzare [Shape.line_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/line_format/) per accedere alle impostazioni della linea, [LineFormat.sketch_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/lineformat/sketch_format/) per accedere alle impostazioni di schizzo e [SketchFormat.sketch_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/sketchformat/sketch_type/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/python-net/aspose.slides/linesketchtype/).

Il seguente codice Python mostra come applicare l'effetto [LineSketchType.CURVED](https://reference.aspose.com/slides/it/python-net/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.NONE](https://reference.aspose.com/slides/it/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Accedere al formato linea della forma e al suo formato schizzo.
    sketch_format = shape.line_format.sketch_format

    # Applicare un effetto schizzo.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Leggere l'effetto schizzo assegnato direttamente alla forma.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Rimuovere l'effetto schizzo.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Il valore restituito da `SketchFormat.sketch_type` rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, utilizzare [LineFormat.get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/lineformat/get_effective/), accedere alla proprietà `sketch_format` dell'oggetto restituito e leggere la sua proprietà `sketch_type`. Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione dell'ereditarietà:

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

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Round
* Miter
* Bevel

Per impostazione predefinita, quando PowerPoint unisce due linee ad angolo (ad esempio nell'angolo di una forma), utilizza l'impostazione **Round**. Tuttavia, se si disegna una forma con angoli pronunciati, potrebbe essere preferibile l'opzione **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Il seguente codice Python dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di giunzione Miter, Bevel e Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

	# Ottenere la prima diapositiva.
	slide = presentation.slides[0]

	# Aggiungere tre forme automatiche di tipo Rettangolo.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Impostare il colore di riempimento per ciascuna forma rettangolare.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Impostare lo spessore della linea.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Impostare il colore per la linea di ciascun rettangolo.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Impostare lo stile di giunzione.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Aggiungere testo a ciascun rettangolo.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Salvare il file PPTX su disco.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Riempimento gradiente**

In PowerPoint, il Riempimento gradiente è un'opzione di formattazione che consente di applicare una fusione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `GRADIENT`.
5. Aggiungere i due colori preferiti con posizioni definite usando i metodi `add` della collezione `gradient_stops` esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/gradientformat/).
6. Salvare la presentazione modificata come file PPTX.

Il seguente codice Python dimostra come applicare un effetto di riempimento gradiente a un'ellisse:

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere una forma automatica di tipo Ellisse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Applicare formattazione gradiente all'ellisse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Impostare la direzione del gradiente.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Aggiungere due punti di gradiente.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Salvare il file PPTX su disco.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The ellipse with gradient fill](gradient-fill.png)

## **Riempimento a trama**

In PowerPoint, il Riempimento a trama è un'opzione di formattazione che consente di applicare un motivo a due colori—come punti, righe, tratteggi incrociati o quadri—a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di trama predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato una trama predefinita, è possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a trama a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `PATTERN`.
5. Scegliere uno stile di trama dalle opzioni predefinite.
6. Impostare il [back_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/patternformat/back_color/) del motivo.
7. Impostare il [fore_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/patternformat/fore_color/) del motivo.
8. Salvare la presentazione modificata come file PPTX.

Il seguente codice Python dimostra come applicare un riempimento a trama a un rettangolo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere una forma automatica di tipo Rettangolo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Impostare il tipo di riempimento su Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Impostare lo stile del motivo.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Impostare i colori di sfondo e primo piano del motivo.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Salvare il file PPTX su disco.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The rectangle with pattern fill](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma—utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `PICTURE`.
5. Impostare la modalità di riempimento immagine su `TILE` (o su un'altra modalità preferita).
6. Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) dall'immagine da utilizzare.
7. Assegnare questa immagine alla proprietà `picture.image` del `picture_fill_format` della forma.
8. Salvare la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![The lotus picture](lotus.png)

Il seguente codice Python dimostra come riempire una forma con l'immagine:

```python
import aspose.slides as slides

# Instanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere una forma automatica di tipo Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Impostare il tipo di riempimento su Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Impostare la modalità di riempimento immagine.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Caricare un'immagine e aggiungerla alle risorse della presentazione.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Impostare l'immagine.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Salvare il file PPTX su disco.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Se si desidera impostare un'immagine piastrellata come texture e personalizzare il comportamento della piastrellatura, è possibile utilizzare le seguenti proprietà della classe [PictureFillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Imposta la modalità di riempimento immagine—`TILE` o `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_alignment/): Specifica l'allineamento delle piastrelle all'interno della forma.
- [tile_flip](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_flip/): Controlla se la piastrella è capovolta orizzontalmente, verticalmente o in entrambi i modi.
- [tile_offset_x](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_offset_x/): Imposta lo spostamento orizzontale della piastrella (in punti) dall'origine della forma.
- [tile_offset_y](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_offset_y/): Imposta lo spostamento verticale della piastrella (in punti) dall'origine della forma.
- [tile_scale_x](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definisce la scala orizzontale della piastrella in percentuale.
- [tile_scale_y](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definisce la scala verticale della piastrella in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine piastrellato e configurare le opzioni di piastrellatura:

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    first_slide = presentation.slides[0]

    # Aggiungere una forma automatica di tipo rettangolo.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Impostare il tipo di riempimento della forma su Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Caricare l'immagine e aggiungerla alle risorse della presentazione.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Assegnare l'immagine alla forma.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configurare la modalità di riempimento immagine e le proprietà di piastrellatura.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Salvare il file PPTX su disco.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The tile options](tile-options.png)

## **Riempimento colore solido**

In PowerPoint, il Riempimento colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o motivi.

Per applicare un riempimento colore solido a una forma usando Aspose.Slides, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare il [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) della forma su `SOLID`.
5. Assegnare il colore di riempimento desiderato alla forma.
6. Salvare la presentazione modificata come file PPTX.

Il seguente codice Python dimostra come applicare un riempimento colore solido a un rettangolo in una diapositiva PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere una forma automatica di tipo Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Impostare il tipo di riempimento su Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Impostare il colore di riempimento.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Salvare il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The shape with solid color fill](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un colore solido, un gradiente, un'immagine o un riempimento texture a delle forme, è possibile impostare anche un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo al sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa del colore usato per il riempimento. Ecco come fare:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare il tipo di riempimento su `SOLID`.
5. Utilizzare `Color.from_argb` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
6. Salvare la presentazione.

Il seguente codice Python dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    slide = presentation.slides[0]
    
    # Aggiungere una forma automatica rettangolare solida.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Aggiungere una forma automatica rettangolare trasparente sopra la forma solida.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The transparent shape](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando è necessario posizionare elementi visivi con un allineamento o un design specifici.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare la proprietà `rotation` della forma sull'angolo desiderato.
5. Salvare la presentazione.

Il seguente codice Python dimostra come ruotare una forma di 5 gradi:

```python
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:

    # Ottenere la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungere una forma automatica di tipo Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ruotare la forma di 5 gradi.
    shape.rotation = 5

    # Salvare il file PPTX su disco.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The shape rotation](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides permette di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, seguire questi passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Configurare il [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
5. Salvare la presentazione.

Il seguente codice Python mostra come applicare effetti di smusso 3D a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Creare un'istanza della classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Aggiungere una forma alla diapositiva.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Impostare le proprietà ThreeDFormat della forma.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Salvare la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The 3D bevel effect](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides permette di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) alla diapositiva.
4. Impostare il [camera_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/camera/camera_type/) e il [light_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/lightrig/light_type/) della forma per definire la rotazione 3D.
5. Salvare la presentazione.

Il seguente codice Python dimostra come applicare effetti di rotazione 3D a una forma:

```python
import aspose.slides as slides

# Creare un'istanza della classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Salvare la presentazione come file PPTX.
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The 3D rotation effect](3D-rotation-effect.png)

## **Controllare la resa in bianco‑nero per le forme**

La proprietà [Shape.black_white_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/black_white_mode/) specifica come una singola forma viene resa quando una presentazione è visualizzata o elaborata in modalità bianco‑nero. Non abilita la visualizzazione in bianco‑nero da sola e non modifica il riempimento, la linea o altre formattazioni della forma in modalità colore normale.

Utilizzare un valore dell'enumerazione [BlackWhiteMode](https://reference.aspose.com/slides/it/python-net/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `AUTOMATIC` consente all'applicazione di rendering di scegliere la conversione, `GRAY` e `LIGHT_GRAY` usano la colorazione grigia, `BLACK_WHITE` utilizza solo nero e bianco, `BLACK` e `WHITE` forzano un colore unico, `COLOR` preserva la colorazione normale, `HIDDEN` omette la forma in modalità bianco‑nero, e `NOT_DEFINED` indica che non è stato assegnato alcun modo a livello di forma.

Il seguente codice Python crea una forma colorata e la fa apparire grigia nella modalità di visualizzazione bianco‑nero:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Mantenere il riempimento arancione in modalità colore, ma visualizzare la forma con colorazione grigia in modalità bianco-nero.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

In modalità colore normale, il rettangolo mantiene il suo riempimento arancione. In un flusso di lavoro di visualizzazione bianco‑nero, utilizza la colorazione grigia perché il suo modo è impostato su `GRAY`. Questo consente di mantenere una diapositiva a colori completa definendo al contempo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione bianco‑nero della presentazione.

## **Ripristinare la formattazione**

Il seguente codice Python mostra come ripristinare la formattazione di una diapositiva e riportare posizione, dimensione e formattazione di tutte le forme con segnaposto nella [LayoutSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/layoutslide/) alle impostazioni predefinite:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reimposta ogni forma sulla diapositiva che ha un segnaposto nel layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file di presentazione?**

Solo marginalmente. Immagini e media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso individuare le forme su una diapositiva che condividono una formattazione identica per raggrupparle?**

Confrontare le proprietà chiave di formattazione di ciascuna forma—riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondono, trattare i loro stili come identici e raggruppare logicamente le forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conservare le forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando si crea una nuova presentazione, aprire il modello, clonare le forme stilizzate necessarie e riapplicare la loro formattazione dove richiesto.