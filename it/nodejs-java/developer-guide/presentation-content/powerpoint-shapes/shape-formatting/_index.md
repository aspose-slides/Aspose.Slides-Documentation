---
title: Formattare le forme di PowerPoint in JavaScript
linktitle: Formattazione della forma
type: docs
weight: 20
url: /it/nodejs-java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile di unione
- riempimento sfumato
- riempimento pattern
- riempimento immagine
- riempimento texture
- riempimento colore solido
- trasparenza forma
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Formattare le forme di PowerPoint in JavaScript usando Aspose.Slides—imposta riempimenti, linee e stili di effetti per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint è possibile aggiungere forme alle diapositive. Poiché le forme sono costituite da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti gli interni.

![formato-forma-powerpoint](format-shape-powerpoint.png)

Aspose.Slides per Node.js tramite Java fornisce classi e metodi che consentono di formattare le forme usando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti descrivono la procedura:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare lo [stile della linea](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linestyle/) della forma.
1. Impostare lo spessore della linea.
1. Impostare lo [stile tratteggiato](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linedashstyle/) della linea.
1. Impostare il colore della linea per la forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice seguente dimostra come formattare un rettangolo `AutoShape`:

```js
// Instanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rettangolo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Imposta il colore di riempimento per la forma rettangolo.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Applica la formattazione alle linee del rettangolo.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Imposta il colore per la linea del rettangolo.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Salva il file PPTX su disco.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti schizzo alle linee della forma**

Un effetto schizzo rende la linea di una forma simile a un disegno a mano libera. Utilizzare [Shape.getLineFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) per accedere alle impostazioni della linea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/lineformat/) per accedere alle impostazioni dello schizzo e [SketchFormat.setSketchType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sketchformat/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linesketchtype/).

Il codice JavaScript seguente mostra come applicare l'effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linesketchtype/):

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Accedi al formato linea della forma e al suo formato schizzo.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Applica un effetto schizzo.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Leggi l'effetto schizzo assegnato direttamente alla forma.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Rimuovi l'effetto schizzo.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Il valore restituito da [SketchFormat.getSketchType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sketchformat/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, utilizzare [LineFormat.getEffective](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/lineformat/), chiamare `getSketchFormat` sull'oggetto restituito e poi chiamare il suo metodo `getSketchType`. Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione delle eredità:

```js
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

## **Formattare gli stili di unione**

Ecco le tre opzioni di tipo di unione:

* Round
* Miter
* Bevel

Per impostazione predefinita, quando PowerPoint unisce due linee con un angolo (ad esempio nell'angolo di una forma), utilizza l'impostazione **Round**. Tuttavia, se si disegna una forma con angoli acuti, è possibile preferire l'opzione **Miter**.

![Lo stile di unione nella presentazione](join-style-powerpoint.png)

Il codice JavaScript seguente dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di unione Miter, Bevel e Round:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi tre forme automatiche di tipo Rettangolo.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Imposta il colore di riempimento per ciascuna forma rettangolo.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Imposta lo spessore della linea.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Imposta il colore per la linea di ciascun rettangolo.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Imposta lo stile di unione.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Aggiungi testo a ciascun rettangolo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salva il file PPTX su disco.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riempimento sfumato**

In PowerPoint, il Riempimento sfumato è un’opzione di formattazione che consente di applicare una sfumatura continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento sfumato a una forma usando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungere i due colori preferiti con le posizioni definite usando i metodi `add` della collezione di fermate sfumate esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/gradientformat/).
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un effetto di riempimento sfumato a un'ellisse:

```js
// Instanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Ellisse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Applica la formattazione a gradiente all'ellisse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Imposta la direzione del gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Aggiungi due fermate di gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Salva il file PPTX su disco.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L’ellisse con riempimento sfumato](gradient-fill.png)

## **Riempimento pattern**

In PowerPoint, il Riempimento pattern è un’opzione di formattazione che consente di applicare un disegno a due colori—come punti, strisce, tratteggi incrociati o quadretti—a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del pattern.

Aspose.Slides fornisce oltre 45 stili di pattern predefiniti che è possibile applicare alle forme per migliorare l’aspetto visivo delle presentazioni. Anche dopo aver selezionato un pattern predefinito, è possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento pattern a una forma usando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegliere uno stile di pattern tra le opzioni predefinite.
1. Impostare il [Background Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/patternformat/#getBackColor--) del pattern.
1. Impostare il [Foreground Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/patternformat/#getForeColor--) del pattern.
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un riempimento pattern a un rettangolo:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Imposta lo stile del pattern.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Imposta i colori di sfondo e di primo piano del pattern.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salva il file PPTX su disco.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rettangolo con riempimento pattern](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un’opzione di formattazione che consente di inserire un’immagine all’interno di una forma, utilizzandola effettivamente come sfondo della forma.

Ecco come usare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Picture`.
1. Impostare la modalità di riempimento immagine su `Tile` (o un’altra modalità preferita).
1. Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) dall’immagine che si desidera utilizzare.
1. Passare l’immagine al metodo `ISlidesPicture.setImage`.
1. Salvare la presentazione modificata come file PPTX.

Supponiamo di avere il file “lotus.png” con l’immagine seguente:

![L’immagine del loto](lotus.png)

Il codice JavaScript seguente dimostra come riempire una forma con l’immagine:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Imposta il tipo di riempimento su Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Imposta la modalità di riempimento immagine.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Carica un'immagine e aggiungila alle risorse della presentazione.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Imposta l'immagine.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salva il file PPTX su disco.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Tile Picture As Texture**

Se si desidera impostare un’immagine a tasselli come texture e personalizzare il comportamento di tassellatura, è possibile utilizzare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Specifica l’allineamento delle tessere all’interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Controlla se la tessera è ribaltata orizzontalmente, verticalmente o su entrambi gli assi.
- [setTileOffsetX](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Imposta lo spostamento orizzontale della tessera (in punti) dall’origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Imposta lo spostamento verticale della tessera (in punti) dall’origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definisce la scala orizzontale della tessera in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definisce la scala verticale della tessera in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine a tessere e configurare le opzioni di tassellatura:

```js
// Instanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica rettangolare.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Imposta il tipo di riempimento della forma su Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Carica l'immagine e aggiungila alle risorse della presentazione.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Assegna l'immagine alla forma.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configura la modalità di riempimento immagine e le proprietà di tassellatura.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Salva il file PPTX su disco.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le opzioni di tassellatura](tile-options.png)

## **Riempimento colore solido**

In PowerPoint, il Riempimento colore solido è un’opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza sfumature, trame o pattern.

Per applicare un riempimento colore solido a una forma usando Aspose.Slides, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Solid`.
1. Assegnare alla forma il colore di riempimento desiderato.
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un riempimento colore solido a un rettangolo in una diapositiva PowerPoint:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Imposta il colore di riempimento.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salva il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento di colore solido, sfumato, immagine o trama a una forma, è possibile impostare anche un livello di trasparenza per controllare l’opacità del riempimento. Un valore di trasparenza più elevato rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa del colore usato per il riempimento. Ecco come fare:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) su `Solid`.
1. Utilizzare `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica rettangolare solida.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Aggiungi una forma automatica rettangolare trasparente sopra la forma solida.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Salva il file PPTX su disco.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può risultare utile quando si posizionano elementi visivi con requisiti specifici di allineamento o design.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà di rotazione della forma sull’angolo desiderato.
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come ruotare una forma di 5 gradi:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ruota la forma di 5 gradi.
    shape.setRotation(5);

    // Salva il file PPTX su disco.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides permette di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, seguire questi passaggi:

1. Istanziate la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenete un riferimento a una diapositiva per indice.
1. Aggiungete un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Configurate il [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salvate la presentazione.

Il codice JavaScript seguente mostra come applicare effetti di smusso 3D a una forma:

```js
// Crea un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma alla diapositiva.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Imposta le proprietà ThreeDFormat della forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Salva la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L’effetto di smusso 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Utilizzare [setCameraType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come applicare effetti di rotazione 3D a una forma:

```js
// Crea un'istanza della classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Salva la presentazione come file PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L’effetto di rotazione 3D](3D-rotation-effect.png)

## **Reimpostare la formattazione**

Il codice Java seguente mostra come reimpostare la formattazione di una diapositiva e ripristinare posizione, dimensione e formattazione di tutte le forme con segnaposto sul [LayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/) alle impostazioni predefinite:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Ripristina ogni forma sulla diapositiva che ha un segnaposto sul layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i contenuti multimediali incorporati occupano la maggior parte dello spazio, mentre i parametri delle forme come colori, effetti e sfumature vengono memorizzati come metadata e aggiungono praticamente nessuna dimensione extra.

**Come posso individuare le forme su una diapositiva che condividono una formattazione identica per raggrupparle?**

Confrontare le principali proprietà di formattazione di ciascuna forma—impostazioni di riempimento, linea ed effetto. Se tutti i valori corrispondono, trattare gli stili come identici e raggruppare logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Salvare forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando si crea una nuova presentazione, aprire il modello, clonare le forme stilizzate necessarie e ri‑applicare la loro formattazione dove richiesto.