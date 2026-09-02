---
title: Formattare le forme PowerPoint su Android
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/androidjava/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile di unione
- riempimento gradiente
- riempimento a trama
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- reimpostare formattazione
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint su Android usando Aspose.Slides—imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti gli interni.

![formato-forma-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java fornisce interfacce e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti illustrano la procedura:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare lo [stile della linea](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linestyle/) della forma.
1. Impostare lo spessore della linea.
1. Impostare lo [stile tratteggiato](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linedashstyle/) della linea.
1. Impostare il colore della linea per la forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice seguente dimostra come formattare un rettangolo `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rettangolo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Rimuovere il riempimento dalla forma rettangolare in modo che siano visibili solo le linee.
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

Un effetto schizzo fa apparire una linea della forma disegnata a mano. Utilizzare [IShape.getLineFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) per accedere alle impostazioni della linea, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformat/) per accedere alle impostazioni dello schizzo e [ISketchFormat.setSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isketchformat/) per selezionare un valore dall’enumerazione [LineSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linesketchtype/).

Il codice Java seguente mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l’effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

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

Il valore restituito da [ISketchFormat.getSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isketchformat/) rappresenta l’impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, utilizzare [ILineFormat.getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformat/), accedere a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformateffectivedata/), e leggere [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isketchformateffectivedata/). Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione dell’eredità:

```java
import com.aspose.slides.*;

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

Per impostazione predefinita, quando PowerPoint unisce due linee con un angolo (ad esempio a un angolo di una forma), utilizza l’impostazione **Round**. Tuttavia, se si disegna una forma con angoli acuti, è possibile preferire l’opzione **Miter**.

![Lo stile di unione nella presentazione](join-style-powerpoint.png)

Il codice Java seguente dimostra come tre rettangoli (come mostrato nell’immagine sopra) siano stati creati utilizzando le impostazioni di unione Miter, Bevel e Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere tre forme automatiche di tipo Rettangolo.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Impostare il colore di riempimento per ciascuna forma rettangolare.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Impostare lo spessore della linea.
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

## **Riempimento a gradiente**

In PowerPoint, il Riempimento a gradiente è un’opzione di formattazione che consente di applicare una graduale fusione di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell’altro.

Ecco come applicare un riempimento a gradiente a una forma utilizzando Aspose.Slides:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungere i due colori preferiti con posizioni definite utilizzando i metodi `add` della collezione di fermate del gradiente esposta dall’interfaccia [IGradientFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/igradientformat/).
1. Salvare la presentazione modificata come file PPTX.

Il codice Java seguente dimostra come applicare un effetto di riempimento a gradiente a un’ellisse:

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicare la formattazione a gradiente all'ellisse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Impostare la direzione del gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Aggiungere due fermate del gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Salvare il file PPTX su disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L’ellisse con riempimento a gradiente](gradient-fill.png)

## **Riempimento a trama**

In PowerPoint, il Riempimento a trama è un’opzione di formattazione che consente di applicare a una forma un disegno a due colori—ad esempio punti, righe, tratteggi incrociati o scacchi. È possibile scegliere colori personalizzati per il primo piano e lo sfondo della trama.

Aspose.Slides offre oltre 45 stili di trama predefiniti che è possibile applicare alle forme per migliorare l’aspetto visivo delle presentazioni. Anche dopo aver selezionato una trama predefinita, è possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a trama a una forma utilizzando Aspose.Slides:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Pattern`.
1. Scegliere uno stile di trama dalle opzioni predefinite.
1. Impostare il [Background Color](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/patternformat/#getBackColor--) della trama.
1. Impostare il [Foreground Color](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/patternformat/#getForeColor--) della trama.
1. Salvare la presentazione modificata come file PPTX.

Il codice Java seguente dimostra come applicare un riempimento a trama a un rettangolo:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
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

Il risultato:

![Il rettangolo con riempimento a trama](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un’opzione di formattazione che consente di inserire un’immagine all’interno di una forma—utilizzando effettivamente l’immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Picture`.
1. Impostare la modalità di riempimento immagine su `Tile` (o un’altra modalità preferita).
1. Creare un oggetto [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) dall’immagine da utilizzare.
1. Passare l’immagine al metodo `ISlidesPicture.setImage`.
1. Salvare la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l’immagine seguente:

![L’immagine del loto](lotus.png)

Il codice Java seguente dimostra come riempire una forma con l’immagine:

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
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

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Tile Picture As Texture**

Se si desidera impostare un’immagine a mosaico come texture e personalizzare il comportamento del mosaico, è possibile utilizzare i seguenti metodi dell’interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): imposta la modalità di riempimento immagine—`Tile` oppure `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): specifica l’allineamento delle tessere all’interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): controlla se la tessera è capovolta orizzontalmente, verticalmente o in entrambi i modi.
- [setTileOffsetX](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): imposta lo spostamento orizzontale della tessera (in punti) dall’origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): imposta lo spostamento verticale della tessera (in punti) dall’origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): definisce la scala orizzontale della tessera in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): definisce la scala verticale della tessera in percentuale.

Il frammento di codice seguente mostra come aggiungere una forma rettangolare con riempimento immagine a mosaico e configurare le opzioni di tessera:

```java
import com.aspose.slides.*;

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

Il risultato:

![Le opzioni di tessera](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a colore solido è un’opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradazioni, trame o motivi.

Per applicare un riempimento a colore solido a una forma utilizzando Aspose.Slides, seguire questi passaggi:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) della forma su `Solid`.
1. Assegnare il colore di riempimento desiderato alla forma.
1. Salvare la presentazione modificata come file PPTX.

Il codice Java seguente dimostra come applicare un riempimento a colore solido a un rettangolo in una diapositiva PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
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

Il risultato:

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento a colore solido, a gradiente, immagine o texture a delle forme, è possibile impostare anche un livello di trasparenza per controllare l’opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa nel colore usato per il riempimento. Ecco come fare:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare il [FillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) su `Solid`.
1. Utilizzare `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salvare la presentazione.

Il codice Java seguente dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
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

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, seguire questi passaggi:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Impostare la proprietà di rotazione della forma sull’angolo desiderato.
1. Salvare la presentazione.

Il codice Java seguente dimostra come ruotare una forma di 5 gradi:

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ruotare la forma di 5 gradi.
    shape.setRotation(5);

    // Salvare il file PPTX su disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides consente di applicare effetti di smusso 3D alle forme configurando le proprietà del loro [ThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, seguire questi passaggi:

1. Istanziare la classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Configurare il [ThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salvare la presentazione.

Il codice Java seguente mostra come applicare effetti di smusso 3D a una forma:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![L’effetto di smusso 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le proprietà del loro [ThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Creare un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento a una diapositiva per indice.
1. Aggiungere un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) alla diapositiva.
1. Utilizzare [setCameraType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icamera/#setCameraType-int-) e [setLightType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) per definire la rotazione 3D.
1. Salvare la presentazione.

Il codice Java seguente dimostra come applicare effetti di rotazione 3D a una forma:

```java
import com.aspose.slides.*;

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

![L’effetto di rotazione 3D](3D-rotation-effect.png)

## **Controllare la resa in bianco e nero per le forme**

Il metodo [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) specifica come una singola forma viene renderizzata quando una presentazione viene visualizzata o elaborata in modalità bianco e nero. Non abilita di per sé la visualizzazione in bianco e nero e non modifica il riempimento, la linea o altra formattazione della forma in modalità colore normale.

Utilizzare un valore della classe [BlackWhiteMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` consente all’applicazione di rendering di scegliere la conversione, `Gray` e `LightGray` usano una colorazione grigia, `BlackWhite` usa solo nero e bianco, `Black` e `White` forzano un singolo colore, `Color` preserva la colorazione normale, e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` indica che nessuna modalità a livello di forma è assegnata.

Il codice Java seguente crea una forma colorata e la fa apparire grigia nella modalità di visualizzazione bianco e nero:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Mantenere il riempimento arancione in modalità colore, ma rendere la forma con colorazione grigia in modalità bianco e nero.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione bianco e nero, utilizza la colorazione grigia perché la sua modalità è impostata su `Gray`. Questo consente di mantenere una diapositiva a colori completa definendo al contempo un aspetto distinto per la stampa, l’anteprima o altri flussi che rispettano le impostazioni di visualizzazione bianco e nero della presentazione.

## **Reimpostare la formattazione**

Il codice Java seguente mostra come reimpostare la formattazione di una diapositiva e ripristinare la posizione, le dimensioni e la formattazione di tutte le forme con segnaposto sul [LayoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/layoutslide/) alle impostazioni predefinite:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reimposta ogni forma della diapositiva che ha un segnaposto nel layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso individuare le forme su una diapositiva che condividono una formattazione identica in modo da raggrupparle?**

Confrontare le proprietà chiave di formattazione di ciascuna forma—riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondono, considerare i loro stili come identici e raggruppare logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conservare forme di esempio con gli stili desiderati in un modello di presentazione o in un file modello .POTX. Quando si crea una nuova presentazione, aprire il modello, clonare le forme formattate necessarie e riapplicare la loro formattazione dove richiesto.