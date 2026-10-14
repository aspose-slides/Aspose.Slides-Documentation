---
title: Formattare le forme PowerPoint in Python via Java
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/python-java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile unione
- riempimento gradiente
- riempimento motivo
- riempimento immagine
- riempimento texture
- riempimento a tinta unita
- trasparenza forma
- rendering forma bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smussatura 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in Python via Java usando Aspose.Slides—imposta stili di riempimento, linea ed effetto per i file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti i loro interni.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java fornisce classi e metodi che consentono di formattare le forme usando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti descrivono la procedura:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare lo [stile della linea](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) della forma.
1. Impostare lo spessore della linea.
1. Impostare lo [stile tratteggiato](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) della linea.
1. Impostare il colore della linea per la forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice seguente dimostra come formattare un rettangolo [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Impostare il colore di riempimento per la forma rettangolare.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Applicare la formattazione alle linee del rettangolo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Impostare il colore per la linea del rettangolo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Salvare il file PPTX su disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti di schizzo alle linee della forma**

Un effetto di schizzo rende la linea di una forma simile a un disegno a mano libera. Utilizzare [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) per accedere alle impostazioni della linea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) per accedere alle impostazioni di schizzo e [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Il codice Python seguente mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None):

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

    # Accedere al formato linea della forma e al suo formato schizzo.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Applicare un effetto schizzo.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Leggere l'effetto schizzo assegnato direttamente alla forma.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Rimuovere l'effetto schizzo.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Il valore restituito da [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, utilizzare [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), accedere a `LineFormatEffectiveData.getSketchFormat` e leggere `SketchFormatEffectiveData.getSketchType`. Il valore effettivo riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà:

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

## **Formattare gli stili di unione**

Ecco le tre opzioni di tipo di unione:

* Arrotondato
* Smussato
* Bisel

Per impostazione predefinita, quando PowerPoint unisce due linee ad un angolo (ad esempio nell'angolo di una forma), utilizza l'impostazione **Arrotondato**. Tuttavia, se si disegna una forma con angoli affilati, si può preferire l'opzione **Smussato**.

![Lo stile di unione nella presentazione](join-style-powerpoint.png)

Il codice Python seguente dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati usando le impostazioni di tipo di unione Smussato, Bisel e Arrotondato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere tre forme automatiche di tipo Rettangolo.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Impostare il colore di riempimento per ogni forma rettangolare.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Impostare lo spessore della linea.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Impostare il colore per la linea di ogni rettangolo.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Impostare lo stile di unione.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Aggiungere testo a ogni rettangolo.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Salvare il file PPTX su disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Riempimento sfumato**

In PowerPoint, il Riempimento sfumato è un'opzione di formattazione che consente di applicare una fusione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento sfumato a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungere i due colori preferiti con posizioni definite usando il metodo [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) della raccolta di fermate gradienti esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/).
1. Salvare la presentazione modificata come file PPTX.

Il codice Python seguente dimostra come applicare un effetto di riempimento sfumato a un'ellisse:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica di tipo Ellisse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Applicare la formattazione gradiente all'ellisse.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Impostare la direzione del gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Aggiungere due fermate gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Salvare il file PPTX su disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'ellisse con riempimento sfumato](gradient-fill.png)

Se un gradiente appare diverso in un'immagine esportata rispetto a quanto visualizzato in PowerPoint, vedere [Scegli uno stile di rendering del gradiente](/slides/it/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). È possibile selezionare uno stile di rendering senza modificare il riempimento sfumato memorizzato nella presentazione.

## **Riempimento a trama**

In PowerPoint, il Riempimento a trama è un'opzione di formattazione che consente di applicare un disegno a due colori—come punti, righe, tratteggi incrociati o scacchi—a una forma. È possibile scegliere colori personalizzati per lo sfondo e il primo piano della trama.

Aspose.Slides fornisce oltre 45 stili di trama predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato una trama predefinita, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a trama a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegliere uno stile di trama dalle opzioni predefinite.
1. Impostare il [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) della trama.
1. Impostare il [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) della trama.
1. Salvare la presentazione modificata come file PPTX.

Il codice Python seguente dimostra come applicare un riempimento a trama a un rettangolo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Impostare il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Impostare lo stile del motivo.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Impostare i colori di sfondo e primo piano del motivo.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Salvare il file PPTX su disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il rettangolo con riempimento a trama](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma—utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come usare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) della forma su `Picture`.
1. Impostare la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Creare un oggetto [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) dall'immagine che si desidera utilizzare.
1. Passare l'immagine al metodo `SlidesPicture.setImage`.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine del loto](lotus.png)

Il codice Python seguente dimostra come riempire una forma con l'immagine:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica di tipo Rettangolo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Impostare il tipo di riempimento su Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Impostare la modalità di riempimento immagine.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Caricare un'immagine e aggiungerla alle risorse della presentazione.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Impostare l'immagine.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Salvare il file PPTX su disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Immagine a piastrelle come texture**

Se si desidera impostare un'immagine a piastrelle come texture e personalizzare il comportamento della piastrellatura, è possibile utilizzare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Specifica l'allineamento delle piastrelle all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Controlla se la piastrella è capovolta orizzontalmente, verticalmente o entrambi.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Imposta lo scostamento orizzontale della piastrella (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Imposta lo scostamento verticale della piastrella (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definisce la scala orizzontale della piastrella in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definisce la scala verticale della piastrella in percentuale.

Il codice di esempio seguente mostra come aggiungere una forma rettangolare con riempimento immagine a piastrelle e configurare le opzioni di piastrellatura:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    first_slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica di tipo Rettangolo.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Impostare il tipo di riempimento della forma su Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Caricare l'immagine e aggiungerla alle risorse della presentazione.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Assegnare l'immagine alla forma.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Configurare la modalità di riempimento immagine e le proprietà di piastrellatura.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Salvare il file PPTX su disco.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le opzioni delle piastrelle](tile-options.png)

## **Riempimento a tinta unita**

In PowerPoint, il Riempimento a tinta unita è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o trame.

Per applicare un riempimento a tinta unita a una forma usando Aspose.Slides, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) della forma su `Solid`.
1. Assegnare il colore di riempimento desiderato alla forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice Python seguente dimostra come applicare un riempimento a tinta unita a un rettangolo in una diapositiva PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica di tipo Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Impostare il tipo di riempimento su Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Impostare il colore di riempimento.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Salvare il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La forma con riempimento a tinta unita](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento di colore solido, sfumato, immagine o texture a forme, è possibile impostare anche un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alpha nel colore usato per il riempimento. Ecco come fare:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) su `Solid`.
1. Utilizzare [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salvare la presentazione.

Il codice Python seguente dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica rettangolare solida.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Aggiungere una forma automatica rettangolare trasparente sopra la forma solida.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Salvare il file PPTX su disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visuali con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà di rotazione della forma sull'angolo desiderato.
1. Salvare la presentazione.

Il codice Python seguente dimostra come ruotare una forma di 5 gradi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Istanziare la classe Presentation che rappresenta un file di presentazione.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma automatica di tipo Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ruotare la forma di 5 gradi.
    shape.setRotation(5)

    # Salvare il file PPTX su disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smussatura 3D**

Aspose.Slides consente di applicare effetti di smussatura 3D alle forme configurando le proprietà [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) della forma.

Per aggiungere effetti di smussatura 3D a una forma, seguire questi passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Configurare il [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) della forma per definire le impostazioni di smussatura.
1. Salvare la presentazione.

Il codice Python seguente mostra come applicare effetti di smussatura 3D a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Creare un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma alla diapositiva.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Impostare le proprietà ThreeDFormat della forma.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Salvare la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'effetto di smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le proprietà [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) della forma.

Per applicare la rotazione 3D a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) alla diapositiva.
1. Utilizzare i metodi [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
1. Salvare la presentazione.

Il codice Python seguente dimostra come applicare effetti di rotazione 3D a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Creare un'istanza della classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Salvare la presentazione come file PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Controllare il rendering in bianco e nero per le forme**

Il metodo [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) specifica come una singola forma viene renderizzata quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non attiva la visualizzazione in bianco e nero di per sé e non modifica il riempimento, la linea o altra formattazione della forma in modalità colore normale.

Utilizzare un valore della classe [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` consente all'applicazione di rendering di scegliere la conversione, `Gray` e `LightGray` usano la colorazione grigia, `BlackWhite` utilizza solo il nero e il bianco, `Black` e `White` forzano un colore singolo, `Color` preserva la colorazione normale e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` indica che non è stato assegnato alcun modo a livello di forma.

Il codice Python seguente crea una forma colorata e la fa apparire grigia nella modalità di visualizzazione bianco e nero:

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Mantieni il riempimento arancione in modalità colore, ma visualizza la forma con colorazione grigia in modalità bianco e nero.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione in bianco e nero, utilizza la colorazione grigia perché il suo modo è impostato su `Gray`. Questo consente di conservare una diapositiva a colori completa definendo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione bianco e nero della presentazione.

## **Reimpostare la formattazione**

Il seguente codice Python mostra come reimpostare la formattazione di una diapositiva e ripristinare posizione, dimensione e formattazione di tutte le forme con segnaposti sul [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) alle impostazioni predefinite:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Reimpostare ogni forma sulla diapositiva che ha un segnaposto sul layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione aggiuntiva.

**Come posso individuare le forme su una diapositiva che condividono una formattazione identica per raggrupparle?**

Confrontare le principali proprietà di formattazione di ogni forma—riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondono, considerare gli stili come identici e raggruppare logicamente tali forme, semplificando la successiva gestione degli stili.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarli in altre presentazioni?**

Sì. Salvare forme di esempio con gli stili desiderati in un modello di diapositiva o in un file modello .POTX. Quando si crea una nuova presentazione, aprire il modello, clonare le forme stilizzate necessarie e riapplicare la loro formattazione dove necessario.