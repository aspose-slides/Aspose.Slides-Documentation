---
title: Formattare forme PowerPoint in Python via Java
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/python-java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea schizzo
- formattare stile di giunzione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto bevel 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in Python via Java usando Aspose.Slides—imposta riempimenti, linee e stili di effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti gli interni.

![Formato forma PowerPoint](format-shape-powerpoint.png)

Aspose.Slides per Python via Java fornisce classi e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I seguenti passaggi illustrano la procedura:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta lo [line style](https://reference.aspose.com/slides/it/python-java/aspose.slides/linestyle/) della forma.
1. Imposta la larghezza della linea.
1. Imposta lo [dash style](https://reference.aspose.com/slides/it/python-java/aspose.slides/linedashstyle/) della linea.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice dimostra come formattare un rettangolo [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Imposta il colore di riempimento per la forma rettangolo.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Applica la formattazione alle linee del rettangolo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Imposta il colore per la linea del rettangolo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Salva il file PPTX su disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti Schizzo alle linee della forma**

Un effetto schizzo rende la linea di una forma simile a un disegno a mano. Usa [Shape.getLineFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getLineFormat) per accedere alle impostazioni della linea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/lineformat/#getSketchFormat) per accedere alle impostazioni dello schizzo e [SketchFormat.setSketchType](https://reference.aspose.com/slides/it/python-java/aspose.slides/sketchformat/#setSketchType) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/python-java/aspose.slides/linesketchtype/).

Il seguente codice Python mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/python-java/aspose.slides/linesketchtype/#Curved), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None_](https://reference.aspose.com/slides/it/python-java/aspose.slides/linesketchtype/#None):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Accedi al formato linea della forma e al suo formato schizzo.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Applica un effetto schizzo.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Leggi l'effetto schizzo assegnato direttamente alla forma.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Rimuovi l'effetto schizzo.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Il valore restituito da [SketchFormat.getSketchType](https://reference.aspose.com/slides/it/python-java/aspose.slides/sketchformat/#getSketchType) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, una diapositiva master o una diapositiva layout, usa [LineFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/lineformat/#getEffective), accedi a `LineFormatEffectiveData.getSketchFormat` e leggi `SketchFormatEffectiveData.getSketchType`. Il valore efficace riflette la formattazione effettivamente applicata dopo la risoluzione dell'eredità:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Arrotondato
* Miter
* Smussato

Di default, quando PowerPoint unisce due linee ad un angolo (ad esempio al bordo di una forma), utilizza l'impostazione **Round**. Tuttavia, se si disegna una forma con angoli acuti, si può preferire l'opzione **Miter**.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Il seguente codice Python dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati usando le impostazioni di tipo di giunzione Miter, Bevel e Round:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi tre forme automatiche di tipo Rettangolo.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Imposta il colore di riempimento per ciascuna forma rettangolare.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Imposta la larghezza della linea.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Imposta il colore per la linea di ciascun rettangolo.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Imposta lo stile di giunzione.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Aggiungi testo a ciascun rettangolo.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Salva il file PPTX su disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Riempimento gradiente**

In PowerPoint, il Gradient Fill è un'opzione di formattazione che consente di applicare una fusione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) della forma a `Gradient`.
1. Aggiungi i due colori preferiti con posizioni definite usando il metodo [addPresetColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/gradientstopcollection/#addPresetColor) della collezione di fermate gradiente esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/gradientformat/).
1. Salva la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica di tipo Ellisse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Applica la formattazione gradiente all'ellisse.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Imposta la direzione del gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Aggiungi due fermate gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Salva il file PPTX su disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'ellisse con riempimento gradiente](gradient-fill.png)

## **Riempimento a motivo**

In PowerPoint, il Pattern Fill è un'opzione di formattazione che permette di applicare un disegno a due colori—come punti, strisce, incroci o scacchi—a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) della forma a `Pattern`.
1. Scegli uno stile di motivo tra le opzioni predefinite.
1. Imposta il [Background Color](https://reference.aspose.com/slides/it/python-java/aspose.slides/patternformat/#getBackColor) del motivo.
1. Imposta il [Foreground Color](https://reference.aspose.com/slides/it/python-java/aspose.slides/patternformat/#getForeColor) del motivo.
1. Salva la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Imposta il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Imposta lo stile del motivo.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Imposta i colori di sfondo e primo piano del motivo.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Salva il file PPTX su disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il rettangolo con riempimento a motivo](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Picture Fill è un'opzione di formattazione che permette di inserire un'immagine all'interno di una forma—utilizzando l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) della forma a `Picture`.
1. Imposta la modalità di riempimento immagine a `Tile` (o un'altra modalità preferita).
1. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) dall'immagine che desideri utilizzare.
1. Passa l'immagine al metodo `SlidesPicture.setImage`.
1. Salva la presentazione modificata come file PPTX.

![L'immagine del loto](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Imposta il tipo di riempimento su Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Imposta la modalità di riempimento immagine.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Carica un'immagine e aggiungila alle risorse della presentazione.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Imposta l'immagine.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Salva il file PPTX su disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Immagine a mosaico come texture**

Se desideri impostare un'immagine a mosaico come texture e personalizzare il comportamento del mosaico, puoi utilizzare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#setTileAlignment): Specifica l'allineamento delle tessere all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#setTileFlip): Controlla se la tessera è capovolta orizzontalmente, verticalmente o entrambe.
- [setTileOffsetX](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Imposta lo scostamento orizzontale della tessera (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Imposta lo scostamento verticale della tessera (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definisce la scala orizzontale della tessera in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definisce la scala verticale della tessera in percentuale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    first_slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Imposta il tipo di riempimento della forma su Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Carica l'immagine e aggiungila alle risorse della presentazione.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Assegna l'immagine alla forma.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Configura la modalità di riempimento immagine e le proprietà di piastrellatura.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Salva il file PPTX su disco.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le opzioni di piastrellatura](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Solid Color Fill è un'opzione di formattazione che riempie una forma con un singolo colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o motivi.

Per applicare un riempimento a colore solido a una forma utilizzando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) della forma a `Solid`.
1. Assegna il colore di riempimento desiderato alla forma.
1. Salva la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Imposta il tipo di riempimento su Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Imposta il colore di riempimento.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Salva il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Imposta trasparenza**

In PowerPoint, quando applichi un riempimento di colore solido, gradiente, immagine o texture a forme, puoi anche impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, permettendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa nel colore usato per il riempimento. Ecco come fare:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) a `Solid`.
1. Usa [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica rettangolare solida.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Aggiungi una forma automatica rettangolare trasparente sopra la forma solida.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Salva il file PPTX su disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con requisiti specifici di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta la proprietà di rotazione della forma all'angolo desiderato.
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Istanzia la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ruota la forma di 5 gradi.
    shape.setRotation(5)

    # Salva il file PPTX su disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Rotazione della forma](shape-rotation.png)

## **Aggiungere effetti 3D bevel**

Aspose.Slides permette di applicare effetti 3D bevel alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/).

Per aggiungere effetti 3D bevel a una forma, segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/) della forma per definire le impostazioni del bevel.
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma alla diapositiva.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Imposta le proprietà ThreeDFormat della forma.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Salva la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'effetto bevel 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides permette di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Usa i metodi [setCameraType](https://reference.aspose.com/slides/it/python-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/it/python-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Salva la presentazione come file PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Controllare il rendering in bianco e nero per le forme**

Il metodo [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setBlackWhiteMode) specifica come una singola forma viene renderizzata quando una presentazione viene visualizzata o elaborata in modalità bianco e nero. Non abilita la visualizzazione in bianco e nero da solo e non modifica il riempimento, la linea o altre formattazioni della forma in modalità colore normale.

Usa un valore della classe [BlackWhiteMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` consente all'applicazione di rendering di scegliere la conversione, `Gray` e `LightGray` usano la colorazione grigia, `BlackWhite` usa solo nero e bianco, `Black` e `White` forzano un colore unico, `Color` mantiene la colorazione normale e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` indica che non è stato assegnato alcun modo a livello di forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Mantieni il riempimento arancione in modalità colore, ma renderizza la forma con colorazione grigia in modalità bianco e nero.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Reimpostare la formattazione**

Il seguente codice Python mostra come reimpostare la formattazione di una diapositiva e ripristinare la posizione, le dimensioni e la formattazione di tutte le forme con segnaposto su [LayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/) alle impostazioni predefinite:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Reimposta ogni forma nella diapositiva che ha un segnaposto nel layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione aggiuntiva.

**Come posso individuare le forme su una diapositiva che condividono la stessa formattazione per raggrupparle?**

Confronta le proprietà chiave di formattazione di ciascuna forma—riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondono, considera i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva le forme di esempio con gli stili desiderati in un modello di presentazione o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme formattate di cui hai bisogno e riapplica la loro formattazione dove necessario.