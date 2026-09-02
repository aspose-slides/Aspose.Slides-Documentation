---
title: Formattare le forme PowerPoint in JavaScript
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/nodejs-java/shape-formatting/
keywords:
- formattazione forma
- formattazione linea
- effetto schizzo
- linea di forma a schizzo
- stile giunzione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento texture
- riempimento colore solido
- trasparenza forma
- rendering forma bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smussatura 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatta le forme PowerPoint in JavaScript usando Aspose.Slides—imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti i loro interni.

![formattazione forma powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java fornisce classi e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti descrivono la procedura:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare lo [line style](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linestyle/) della forma.
1. Impostare la larghezza della linea.
1. Impostare lo [dash style](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linedashstyle/) della linea.
1. Impostare il colore della linea per la forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice seguente dimostra come formattare un rettangolo `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Rimuovere il riempimento dalla forma rettangolo.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Applicare la formattazione alle linee del rettangolo.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Impostare il colore per la linea del rettangolo.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Salvare il file PPTX su disco.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti Schizzo alle linee della forma**

Un effetto schizzo rende una linea di forma simile a un tratto a mano. Usare [Shape.getLineFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) per accedere alle impostazioni della linea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/lineformat/) per accedere alle impostazioni dello schizzo e [SketchFormat.setSketchType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sketchformat/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linesketchtype/).

Il codice JavaScript seguente mostra come applicare l'effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Accedere al formato linea della forma e al suo formato schizzo.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Applicare un effetto schizzo.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Leggere l'effetto schizzo assegnato direttamente alla forma.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Rimuovere l'effetto schizzo.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Il valore restituito da [SketchFormat.getSketchType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sketchformat/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usare [LineFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/lineformat/), chiamare `getSketchFormat` sull'oggetto restituito e quindi chiamare il suo metodo `getSketchType`. Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione dell'eredità:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Round
* Miter
* Bevel

Per impostazione predefinita, quando PowerPoint unisce due linee ad un angolo (ad esempio all'angolo di una forma), utilizza l'impostazione **Round**. Tuttavia, se si disegna una forma con angoli affilati, si può preferire l'opzione **Miter**.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Il codice JavaScript seguente dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di giunzione Miter, Bevel e Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere tre forme automatiche di tipo Rettangolo.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Impostare il colore di riempimento per ogni forma rettangolo.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Impostare la larghezza della linea.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Impostare il colore per la linea di ogni rettangolo.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Impostare lo stile di giunzione.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Aggiungere testo a ciascun rettangolo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salvare il file PPTX su disco.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riempimento gradiente**

In PowerPoint, il Riempimento gradiente è un'opzione di formattazione che consente di applicare una fusione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungere i due colori preferiti con posizioni definite usando i metodi `add` della collezione di fermate gradiente esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/gradientformat/).
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un effetto di riempimento gradiente a un'ellisse:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Ellisse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicare la formattazione gradiente all'ellisse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Impostare la direzione del gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Aggiungere due fermate gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Salvare il file PPTX su disco.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'ellisse con riempimento gradiente](gradient-fill.png)

## **Riempimento a motivo**

In PowerPoint, il Riempimento a motivo è un'opzione di formattazione che consente di applicare un disegno a due colori — come punti, righe, tratteggi o quadretti — a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegliere uno stile di motivo tra le opzioni predefinite.
1. Impostare il [Background Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/patternformat/#getBackColor--) del motivo.
1. Impostare il [Foreground Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/patternformat/#getForeColor--) del motivo.
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un riempimento a motivo a un rettangolo:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Impostare il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Impostare lo stile del motivo.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Impostare i colori di sfondo e primo piano del motivo.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salvare il file PPTX su disco.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rettangolo con riempimento pattern](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma, usando effettivamente l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Picture`.
1. Impostare la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) dall'immagine da utilizzare.
1. Passare l'immagine al metodo `ISlidesPicture.setImage`.
1. Salvare la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine del loto](lotus.png)

Il codice JavaScript seguente dimostra come riempire una forma con l'immagine:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Impostare il tipo di riempimento su Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Impostare la modalità di riempimento immagine.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Caricare un'immagine e aggiungerla alle risorse della presentazione.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Impostare l'immagine.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salvare il file PPTX su disco.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Immagine a tasselli come texture**

Se si desidera impostare un'immagine a tasselli come texture e personalizzare il comportamento del tassellamento, è possibile utilizzare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Imposta la modalità di riempimento immagine — `Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Specifica l'allineamento dei tasselli all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Controlla se il tassello è capovolto orizzontalmente, verticalmente o in entrambi i modi.
- [setTileOffsetX](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Imposta lo spostamento orizzontale del tassello (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Imposta lo spostamento verticale del tassello (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definisce la scala orizzontale del tassello come percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definisce la scala verticale del tassello come percentuale.

Il campione di codice seguente mostra come aggiungere una forma rettangolare con riempimento immagine a tasselli e configurare le opzioni di tassellamento:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica rettangolare.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Impostare il tipo di riempimento della forma su Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Caricare l'immagine e aggiungerla alle risorse della presentazione.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Assegnare l'immagine alla forma.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurare la modalità di riempimento immagine e le proprietà di tiling.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Salvare il file PPTX su disco.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le opzioni di tiling](tile-options.png)

## **Riempimento colore solido**

In PowerPoint, il Riempimento colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o motivi.

Per applicare un riempimento colore solido a una forma usando Aspose.Slides, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Solid`.
1. Assegnare il colore di riempimento preferito alla forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un riempimento colore solido a un rettangolo in una diapositiva PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Impostare il tipo di riempimento su Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Impostare il colore di riempimento.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salvare il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento colore solido, gradiente, immagine o texture a delle forme, è anche possibile impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa nel colore usato per il riempimento. Ecco come fare:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) su `Solid`.
1. Usare `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica rettangolare solida.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Aggiungere una forma automatica rettangolare trasparente sopra la forma solida.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Salvare il file PPTX su disco.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visuali con requisiti specifici di allineamento o design.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà di rotazione della forma sull'angolo desiderato.
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come ruotare una forma di 5 gradi:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ruotare la forma di 5 gradi.
    shape.setRotation(5);

    // Salvare il file PPTX su disco.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smussatura 3D**

Aspose.Slides consente di applicare effetti di smussatura 3D alle forme configurando le proprietà del loro [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

Per aggiungere effetti di smussatura 3D a una forma, seguire questi passaggi:

1. Istituire la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Configurare il [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/) della forma per definire le impostazioni di smussatura.
1. Salvare la presentazione.

Il codice JavaScript seguente mostra come applicare effetti di smussatura 3D a una forma:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Creare un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma alla diapositiva.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Impostare le proprietà ThreeDFormat della forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Salvare la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Effetto smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le proprietà del loro [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Usare [setCameraType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come applicare effetti di rotazione 3D a una forma:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creare un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Salvare la presentazione come file PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Effetto rotazione 3D](3D-rotation-effect.png)

## **Controllare il rendering in bianco e nero per le forme**

Il metodo [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) specifica come una singola forma viene visualizzata quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non abilita la visualizzazione in bianco e nero di per sé e non modifica il riempimento, la linea o altre formattazioni della forma nella modalità a colori normale.

Usare un valore dell'enumerazione [BlackWhiteMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` consente all'applicazione di rendering di scegliere la conversione, `Gray` e `LightGray` usano il colore grigio, `BlackWhite` utilizza solo nero e bianco, `Black` e `White` forzano un colore unico, `Color` preserva la colorazione normale e `Hidden` omette la forma nella modalità bianco e nero. `NotDefined` indica che non è stato assegnato alcun modo a livello di forma.

Il codice JavaScript seguente crea una forma colorata e la fa apparire grigia nella modalità di visualizzazione bianco e nero:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Mantieni il riempimento arancione in modalità a colori, ma visualizza la forma con colorazione grigia in modalità bianco e nero.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In modalità colore normale, il rettangolo mantiene il suo riempimento arancione. In un flusso di lavoro di visualizzazione bianco e nero, utilizza il colore grigio perché il suo modo è impostato su `Gray`. Questo consente di preservare una diapositiva a colori completa definendo al contempo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione bianco e nero della presentazione.

## **Reimpostare la formattazione**

Il codice JavaScript seguente mostra come reimpostare la formattazione di una diapositiva e ripristinare la posizione, le dimensioni e la formattazione di tutte le forme con segnaposto sul [LayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/) ai loro valori predefiniti:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Ripristina ogni forma nella diapositiva che ha un segnaposto nel layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo in minima parte. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri della forma come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione aggiuntiva.

**Come posso rilevare forme su una diapositiva che condividono una formattazione identica in modo da poterle raggruppare?**

Confrontare le proprietà chiave di formattazione di ciascuna forma — impostazioni di riempimento, linea ed effetto. Se tutti i valori corrispondenti coincidono, trattare i loro stili come identici e raggruppare logicamente tali forme, semplificando la gestione successiva degli stili.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conservare forme di esempio con gli stili desiderati in un set di diapositive modello o in un file modello `.POTX`. Quando si crea una nuova presentazione, aprire il modello, clonare le forme con lo stile necessario e riapplicare la loro formattazione dove richiesto.