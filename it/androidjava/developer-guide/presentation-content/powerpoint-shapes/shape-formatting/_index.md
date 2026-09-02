---
title: Formatta forme PowerPoint su Android
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/androidjava/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea di forma a schizzo
- formattare stile di giunzione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint su Android utilizzando Aspose.Slides—imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono costituite da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando le impostazioni che controllano il riempimento dei loro interni.

![Formato della forma in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides per Android via Java fornisce interfacce e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti illustrano la procedura:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare lo [stile della linea](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linestyle/) della forma.
1. Impostare la larghezza della linea.
1. Impostare lo [stile tratteggiato](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linedashstyle/) della linea.
1. Impostare il colore della linea per la forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice seguente dimostra come formattare un `AutoShape` rettangolare:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Imposta il colore di riempimento per la forma rettangolare.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Applica la formattazione alle linee del rettangolo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Imposta il colore per la linea del rettangolo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Salva il file PPTX su disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti di schizzo alle linee della forma**

Un effetto di schizzo rende la linea di una forma simile a un disegno a mano libera. Utilizzare [IShape.getLineFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) per accedere alle impostazioni della linea, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformat/) per accedere alle impostazioni di schizzo e [ISketchFormat.setSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isketchformat/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linesketchtype/).

Il codice Java seguente mostra come applicare l'effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Accedi al formato linea della forma e al suo formato schizzo.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Applica un effetto di schizzo.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Leggi l'effetto di schizzo assegnato direttamente alla forma.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Rimuovi l'effetto di schizzo.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Il valore restituito da [ISketchFormat.getSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isketchformat/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva di layout, utilizzare [ILineFormat.getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformat/), accedere a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformateffectivedata/) e leggere [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isketchformateffectivedata/). Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione dell'ereditarietà:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Arrotondato
* Miter
* Smussato

Per impostazione predefinita, quando PowerPoint unisce due linee con un angolo (ad esempio all'angolo di una forma), utilizza l'impostazione **Arrotondato**. Tuttavia, se si sta disegnando una forma con angoli acuti, si può preferire l'opzione **Miter**.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Il codice Java seguente dimostra come tre rettangoli (come mostrato nell'immagine sopra) sono stati creati utilizzando le impostazioni di tipo di giunzione Miter, Smussato e Arrotondato:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi tre forme automatiche di tipo Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Imposta il colore di riempimento per ogni forma rettangolare.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Imposta la larghezza della linea.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Imposta il colore per la linea di ogni rettangolo.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Imposta lo stile di giunzione.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Aggiungi testo a ogni rettangolo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salva il file PPTX su disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riempimento gradiente**

In PowerPoint, il Riempimento gradiente è un'opzione di formattazione che consente di applicare una fusione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungere i due colori preferiti con posizioni definite utilizzando i metodi `add` della raccolta di fermate gradiente esposta dall'interfaccia [IGradientFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/igradientformat/).
1. Salvare la presentazione modificata come file PPTX.

Il codice Java seguente dimostra come applicare un effetto di riempimento gradiente a un'ellisse:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applica la formattazione gradiente all'ellisse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Imposta la direzione del gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Aggiungi due fermate gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Salva il file PPTX su disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'ellisse con riempimento gradiente](gradient-fill.png)

## **Riempimento a motivo**

In PowerPoint, il Riempimento a motivo è un'opzione di formattazione che consente di applicare un disegno a due colori—come punti, strisce, reticoli o quadretti—a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma utilizzando Aspose.Slides:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Pattern`.
1. Scegliere uno stile di motivo tra le opzioni predefinite.
1. Impostare il [Colore di sfondo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/patternformat/#getBackColor--) del motivo.
1. Impostare il [Colore di primo piano](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/patternformat/#getForeColor--) del motivo.
1. Salvare la presentazione modificata come file PPTX.

Il codice Java seguente dimostra come applicare un riempimento a motivo a un rettangolo:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Imposta lo stile del motivo.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Imposta i colori di sfondo e di primo piano del motivo.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Salva il file PPTX su disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rettangolo con riempimento a motivo](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma, utilizzandola effettivamente come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Picture`.
1. Impostare la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Creare un oggetto [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) dall'immagine da utilizzare.
1. Passare l'immagine al metodo `ISlidesPicture.setImage`.
1. Salvare la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine del loto](lotus.png)

Il codice Java seguente dimostra come riempire una forma con l'immagine:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Imposta il tipo di riempimento su Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Imposta la modalità di riempimento immagine.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Carica un'immagine e aggiungila alle risorse della presentazione.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Imposta l'immagine.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salva il file PPTX su disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Immagine a tasselli come texture**

Se si desidera impostare un'immagine a tasselli come texture e personalizzare il comportamento del tassellamento, è possibile utilizzare i seguenti metodi dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): specifica l'allineamento delle tessere all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): controlla se la tessera è capovolta orizzontalmente, verticalmente o entrambe.
- [setTileOffsetX](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): imposta lo spostamento orizzontale della tessera (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): imposta lo spostamento verticale della tessera (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): definisce la scala orizzontale della tessera in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): definisce la scala verticale della tessera in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine a tasselli e configurare le opzioni di tessellazione:

```java
    // Istanziare la classe Presentation che rappresenta un file di presentazione.
    Presentation presentation = new Presentation();
    try {
        // Ottieni la prima diapositiva.
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        // Aggiungi una forma automatica rettangolare.
        IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

        // Imposta il tipo di riempimento della forma su Picture.
        shape.getFillFormat().setFillType(FillType.Picture);

        // Carica l'immagine e aggiungila alle risorse della presentazione.
        IImage sourceImage = Images.fromFile("lotus.png");
        IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
        sourceImage.dispose();

        // Assegna l'immagine alla forma.
        IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
        pictureFillFormat.getPicture().setImage(presentationImage);

        // Configura la modalità di riempimento immagine e le proprietà di tassellatura.
        pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
        pictureFillFormat.setTileOffsetX(-32);
        pictureFillFormat.setTileOffsetY(-32);
        pictureFillFormat.setTileScaleX(50);
        pictureFillFormat.setTileScaleY(50);
        pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
        pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

        // Salva il file PPTX su disco.
        presentation.save("tile.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

Il risultato:

![Le opzioni di tassellatura](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo sfondo semplice viene applicato senza gradienti, texture o motivi.

Per applicare un riempimento a colore solido a una forma utilizzando Aspose.Slides, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Solid`.
1. Assegnare il colore di riempimento preferito alla forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice Java seguente dimostra come applicare un riempimento a colore solido a un rettangolo in una diapositiva PowerPoint:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Imposta il colore di riempimento.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Salva il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento solido, gradiente, immagine o texture a delle forme, è possibile impostare anche un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più elevato rende la forma più trasparente, consentendo al fondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa del colore usato per il riempimento. Ecco come procedere:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) su `Solid`.
1. Utilizzare `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salvare la presentazione.

Il codice Java seguente dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica rettangolare solida.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Aggiungi una forma automatica rettangolare trasparente sopra la forma solida.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Salva il file PPTX su disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può risultare utile quando si posizionano elementi visivi con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare la proprietà di rotazione della forma sull'angolo desiderato.
1. Salvare la presentazione.

Il codice Java seguente dimostra come ruotare una forma di 5 gradi:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ruota la forma di 5 gradi.
    shape.setRotation(5);

    // Salva il file PPTX su disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides permette di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, seguire questi passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Configurare il [ThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salvare la presentazione.

Il codice Java seguente mostra come applicare effetti di smusso 3D a una forma:

```java
// Creare un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma alla diapositiva.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Impostare le proprietà ThreeDFormat della forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Salvare la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'effetto di smusso 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva mediante il suo indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Utilizzare [setCameraType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icamera/#setCameraType-int-) e [setLightType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) per definire la rotazione 3D.
1. Salvare la presentazione.

Il codice Java seguente dimostra come applicare effetti di rotazione 3D a una forma:

```java
// Creare un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Salvare la presentazione come file PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Reimpostare la formattazione**

Il codice Java seguente mostra come reimpostare la formattazione di una diapositiva e ripristinare posizione, dimensione e formattazione di tutte le forme con segnaposto sulla [LayoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslide/) ai valori predefiniti:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reimposta ogni forma sulla diapositiva che ha un segnaposto nel layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo minimamente. Immagini e contenuti multimediali incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme, come colori, effetti e gradienti, vengono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso rilevare le forme su una diapositiva che condividono la stessa formattazione per poterle raggruppare?**

Confrontare le proprietà chiave di formattazione di ciascuna forma—riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondenti coincidono, considerare gli stili come identici e raggruppare logicamente tali forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarli in altre presentazioni?**

Sì. Conservare le forme di esempio con gli stili desiderati in un modello di diapositiva o in un file modello .POTX. Quando si crea una nuova presentazione, aprire il modello, clonare le forme stilizzate necessarie e riapplicare la loro formattazione dove richiesto.