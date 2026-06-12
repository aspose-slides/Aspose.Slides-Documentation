---
title: Formattare forme PowerPoint in JavaScript
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/nodejs-java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- formattare stile di giunzione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- ruotare forma
- effetto smussatura 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatta forme PowerPoint in JavaScript usando Aspose.Slides—imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano il modo in cui gli interni sono riempiti.

![formattazione-forma-powerpoint](format-shape-powerpoint.png)

Aspose.Slides per Node.js tramite Java fornisce classi e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I seguenti passaggi descrivono la procedura:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare lo [stile della linea](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linestyle/) della forma.
1. Impostare la larghezza della linea.
1. Impostare lo [stile del tratto](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/linedashstyle/) della linea.
1. Impostare il colore della linea per la forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice seguente dimostra come formattare un rettangolo `AutoShape`:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Impostare il colore di riempimento per la forma rettangolo.
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

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Rotondo
* Smussato
* Angolo

Per impostazione predefinita, quando PowerPoint collega due linee con un angolo (come in un angolo di forma), utilizza l'impostazione **Rotondo**. Tuttavia, se si disegna una forma con angoli acuti, potrebbe essere preferibile l'opzione **Angolo**.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Il codice JavaScript seguente dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di giunzione Angolo, Smussato e Rotondo:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere tre forme automatiche di tipo Rettangolo.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Impostare il colore di riempimento per ciascuna forma rettangolare.
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

    // Impostare il colore per la linea di ciascun rettangolo.
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

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungere i due colori preferiti con posizioni definite usando i metodi `add` della raccolta di fermate gradiente esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/gradientformat/).
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un effetto di riempimento gradiente a un'ellisse:

```js
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

    // Aggiungere due fermate del gradiente.
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

In PowerPoint, il Riempimento a motivo è un'opzione di formattazione che consente di applicare un disegno a due colori—come punti, strisce, tratteggi incrociati o quadretti—a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma usando Aspose.Slides:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegliere uno stile di motivo tra le opzioni predefinite.
1. Impostare il [Colore di sfondo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/patternformat/#getBackColor--) del motivo.
1. Impostare il [Colore di primo piano](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/patternformat/#getForeColor--) del motivo.
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un riempimento a motivo a un rettangolo:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Impostare il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Impostare lo stile del motivo.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Impostare i colori di sfondo e di primo piano del motivo.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salvare il file PPTX su disco.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rettangolo con riempimento a motivo](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma—utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Picture`.
1. Impostare la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) dall'immagine da utilizzare.
1. Passare l'immagine al metodo `ISlidesPicture.setImage`.
1. Salvare la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine di loto](lotus.png)

Il codice JavaScript seguente dimostra come riempire una forma con l'immagine:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
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

- [setPictureFillMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): specifica l'allineamento dei tasselli all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): controlla se il tassello è capovolto orizzontalmente, verticalmente o in entrambi i modi.
- [setTileOffsetX](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): imposta lo spostamento orizzontale del tassello (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): imposta lo spostamento verticale del tassello (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): definisce la scala orizzontale del tassello in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): definisce la scala verticale del tassello in percentuale.

Il campione di codice seguente mostra come aggiungere una forma rettangolare con riempimento immagine a tasselli e configurare le opzioni del tassello:

```js
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

    // Configurare la modalità di riempimento immagine e le proprietà di tassellamento.
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

![Le opzioni di tassellamento](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o motivi.

Per applicare un riempimento a colore solido a una forma usando Aspose.Slides, seguire questi passaggi:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) della forma su `Solid`.
1. Assegnare alla forma il colore di riempimento desiderato.
1. Salvare la presentazione modificata come file PPTX.

Il codice JavaScript seguente dimostra come applicare un riempimento a colore solido a un rettangolo in una diapositiva PowerPoint:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
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

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento a colore solido, gradiente, immagine o texture a forme, è possibile impostare anche un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa nel colore utilizzato per il riempimento. Ecco come fare:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) su `Solid`.
1. Utilizzare `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```js
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

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può risultare utile quando si posizionano elementi visivi con requisiti specifici di allineamento o design.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Impostare la proprietà di rotazione della forma sull'angolo desiderato.
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come ruotare una forma di 5 gradi:

```js
// Istanziare la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Ottenere la prima diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
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

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smussatura 3D**

Aspose.Slides consente di applicare effetti di smussatura 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

Per aggiungere effetti di smussatura 3D a una forma, seguire questi passaggi:

1. Istanziare la classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Configurare il [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/) della forma per definire le impostazioni di smussatura.
1. Salvare la presentazione.

Il codice JavaScript seguente mostra come applicare effetti di smussatura 3D a una forma:

```js
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

![L'effetto di smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Creare un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per il suo indice.
1. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
1. Utilizzare i metodi [setCameraType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
1. Salvare la presentazione.

Il codice JavaScript seguente dimostra come applicare effetti di rotazione 3D a una forma:

```js
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

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Ripristinare la formattazione**

Il codice Java seguente mostra come ripristinare la formattazione di una diapositiva e riportare posizione, dimensione e formattazione di tutte le forme con segnaposto nella [LayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/) alle impostazioni predefinite:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Reimposta ciascuna forma sulla diapositiva che ha un segnaposto nel layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo in minima parte. Le immagini e i contenuti multimediali incorporati occupano la maggior parte dello spazio, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso individuare forme su una diapositiva che condividono la stessa formattazione per raggrupparle?**

Confrontare le proprietà chiave di formattazione di ciascuna forma—impostazioni di riempimento, linea ed effetti. Se tutti i valori corrispondenti coincidono, trattare i loro stili come identici e raggruppare logicamente tali forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conservare forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando si crea una nuova presentazione, aprire il modello, clonare le forme stilizzate necessarie e riapplicare la loro formattazione dove richiesto.