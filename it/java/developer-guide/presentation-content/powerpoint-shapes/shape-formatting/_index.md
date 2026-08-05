---
title: Formattare le forme PowerPoint in Java
linktitle: Formattazione delle forme
type: docs
weight: 20
url: /it/java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- stile di unione
- riempimento gradiente
- riempimento pattern
- riempimento immagine
- riempimento texture
- riempimento colore solido
- trasparenza forma
- ruotare forma
- effetto smussatura 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in Java usando Aspose.Slides—imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, puoi aggiungere forme alle diapositive. Poiché le forme sono composte da linee, puoi formattarle modificando o applicando effetti ai loro contorni. Inoltre, puoi formattare le forme specificando impostazioni che controllano come vengono riempiti i loro interni.

![formattazione-forma-powerpoint](format-shape-powerpoint.png)

Aspose.Slides per Java fornisce interfacce e metodi che ti permettono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, puoi specificare uno stile di linea personalizzato per una forma. I passaggi seguenti descrivono la procedura:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta lo [line style](https://reference.aspose.com/slides/it/java/com.aspose.slides/linestyle/) della forma.
1. Imposta la larghezza della linea.
1. Imposta lo [dash style](https://reference.aspose.com/slides/it/java/com.aspose.slides/linedashstyle/) della linea.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice dimostra come formattare un rettangolo `AutoShape`:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Impostare il colore di riempimento per la forma rettangolo.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Applicare la formattazione alle linee del rettangolo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Impostare il colore per la linea del rettangolo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Salvare il file PPTX su disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti schizzo alle linee della forma**

Un effetto schizzo fa apparire la linea di una forma disegnata a mano. Usa [IShape.getLineFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) per accedere alle impostazioni della linea, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilineformat/) per accedere alle impostazioni dello schizzo e [ISketchFormat.setSketchType](https://reference.aspose.com/slides/it/java/com.aspose.slides/isketchformat/) per selezionare un valore dalla enumerazione [LineSketchType](https://reference.aspose.com/slides/it/java/com.aspose.slides/linesketchtype/).

Il seguente codice Java mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/java/com.aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Accedere al formato linea della forma e al suo formato schizzo.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Applicare un effetto schizzo.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Leggere l'effetto schizzo assegnato direttamente alla forma.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Rimuovere l'effetto schizzo.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Il valore restituito da [ISketchFormat.getSketchType](https://reference.aspose.com/slides/it/java/com.aspose.slides/isketchformat/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, una diapositiva master o una diapositiva layout, usa [ILineFormat.getEffective](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilineformat/), accedi a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilineformateffectivedata/), e leggi [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/it/java/com.aspose.slides/isketchformateffectivedata/). Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione dell'ereditarietà:

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

## **Formattare gli stili di unione**

Ecco le tre opzioni di tipo di unione:

* Round
* Miter
* Bevel

Per impostazione predefinita, quando PowerPoint unisce due linee formando un angolo (ad esempio nell'angolo di una forma), utilizza l'impostazione **Round**. Tuttavia, se stai disegnando una forma con angoli acuti, potresti preferire l'opzione **Miter**.

![Lo stile di unione nella presentazione](join-style-powerpoint.png)

Il seguente codice Java dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di unione Miter, Bevel e Round:

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere tre forme automatiche di tipo Rettangolo.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Impostare il colore di riempimento per ciascuna forma rettangolo.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Impostare la larghezza della linea.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Impostare il colore per la linea di ciascun rettangolo.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Impostare lo stile di unione.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Aggiungere testo a ciascun rettangolo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salvare il file PPTX su disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riempimento gradiente**

In PowerPoint, il Gradient Fill è un'opzione di formattazione che consente di applicare una sfumatura continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma usando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungi i tuoi due colori preferiti con posizioni definite usando i metodi `add` della collezione di gradient stop esposta dall'interfaccia [IGradientFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/igradientformat/).
1. Salva la presentazione modificata come file PPTX.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Ellisse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicare formattazione gradiente all'ellisse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Impostare la direzione del gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Aggiungere due fermate gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Salvare il file PPTX su disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![L'ellisse con riempimento gradiente](gradient-fill.png)

## **Riempimento pattern**

In PowerPoint, il Pattern Fill è un'opzione di formattazione che consente di applicare un disegno a due colori — come punti, righe, tratteggi incrociati o scacchi — a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del pattern.

Aspose.Slides fornisce oltre 45 stili di pattern predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un pattern predefinito, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento pattern a una forma usando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) della forma su `Pattern`.
1. Scegli uno stile di pattern dalle opzioni predefinite.
1. Imposta il [Background Color](https://reference.aspose.com/slides/it/java/com.aspose.slides/patternformat/#getBackColor--) del pattern.
1. Imposta il [Foreground Color](https://reference.aspose.com/slides/it/java/com.aspose.slides/patternformat/#getForeColor--) del pattern.
1. Salva la presentazione modificata come file PPTX.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Impostare il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Impostare lo stile del pattern.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Impostare i colori di sfondo e di primo piano del pattern.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Salvare il file PPTX su disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Il rettangolo con riempimento pattern](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Picture Fill è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma — utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come usare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) della forma su `Picture`.
1. Imposta la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ippimage/) dall'immagine che desideri utilizzare.
1. Passa l'immagine al metodo `ISlidesPicture.setImage`.
1. Salva la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine del loto](lotus.png)

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Impostare il tipo di riempimento su Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Impostare la modalità di riempimento immagine.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Caricare un'immagine e aggiungerla alle risorse della presentazione.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Impostare l'immagine.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salvare il file PPTX su disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La forma con riempimento immagine](picture-fill.png)

### **Immagine a tasselli come texture**

Se desideri impostare un'immagine a tasselli come texture e personalizzare il comportamento del tassellamento, puoi utilizzare i seguenti metodi dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Imposta la modalità di riempimento immagine — `Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Specifica l'allineamento dei tasselli all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controlla se il tassello è capovolto orizzontalmente, verticalmente o in entrambi i modi.
- [setTileOffsetX](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Imposta lo spostamento orizzontale del tassello (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Imposta lo spostamento verticale del tassello (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definisce la scala orizzontale del tassello come percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definisce la scala verticale del tassello come percentuale.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica rettangolare.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Impostare il tipo di riempimento della forma su Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Caricare l'immagine e aggiungerla alle risorse della presentazione.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Assegnare l'immagine alla forma.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurare la modalità di riempimento immagine e le proprietà di tiling.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Salvare il file PPTX su disco.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Le opzioni di tassellamento](tile-options.png)

## **Riempimento colore solido**

In PowerPoint, il Solid Color Fill è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o pattern.

Per applicare un riempimento colore solido a una forma usando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) della forma su `Solid`.
1. Assegna alla forma il colore di riempimento preferito.
1. Salva la presentazione modificata come file PPTX.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Impostare il tipo di riempimento su Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Impostare il colore di riempimento.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Salvare il file PPTX su disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La forma con riempimento colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando applichi un riempimento di colore solido, gradiente, immagine o texture a delle forme, puoi anche impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides ti consente di impostare il livello di trasparenza regolando il valore alfa del colore usato per il riempimento. Ecco come fare:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) su `Solid`.
1. Usa `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

```java
// Istanziate la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica rettangolare solida.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Aggiungere una forma automatica rettangolare trasparente sopra la forma solida.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Salvare il file PPTX su disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides ti consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta la proprietà di rotazione della forma all'angolo desiderato.
1. Salva la presentazione.

```java
// Istanziate la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ruotare la forma di 5 gradi.
    shape.setRotation(5);

    // Salvare il file PPTX su disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti d'ombreggiatura 3D**

Aspose.Slides consente di applicare effetti di smussatura 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/threedformat/).

Per aggiungere effetti di smussatura 3D a una forma, segui questi passaggi:

1. Instanzia la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/threedformat/) della forma per definire le impostazioni di smussatura.
1. Salva la presentazione.

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

![L'effetto smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Usa [setCameraType](https://reference.aspose.com/slides/it/java/com.aspose.slides/icamera/#setCameraType-int-) e [setLightType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilightrig/#setLightType-int-) per definire la rotazione 3D.
1. Salva la presentazione.

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

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Reimpostare la formattazione**

Il seguente codice Java mostra come reimpostare la formattazione di una diapositiva e ripristinare la posizione, le dimensioni e la formattazione di tutte le forme con segnaposto sulla [LayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/layoutslide/) alle impostazioni predefinite:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reimposta ogni forma nella diapositiva che ha un segnaposto nel layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso rilevare le forme su una diapositiva che condividono la stessa formattazione per poterle raggruppare?**

Confronta le proprietà chiave di formattazione di ogni forma — impostazioni di riempimento, linea ed effetti. Se tutti i valori corrispondenti coincidono, considera i loro stili come identici e raggruppa logicamente tali forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Salva le forme di esempio con gli stili desiderati in un deck di diapositive modello o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate necessarie e riapplica la loro formattazione dove richiesto.