---
title: Formattare forme PowerPoint in Java
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile di unione
- riempimento gradiente
- riempimento pattern
- riempimento immagine
- riempimento texture
- riempimento colore solido
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in Java usando Aspose.Slides—imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti i loro interni.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides per Java fornisce interfacce e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I seguenti passaggi descrivono la procedura:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta lo [stile di linea](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) della forma.
1. Imposta la larghezza della linea.
1. Imposta lo [stile di tratteggio](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) della linea.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice mostra come formattare un rettangolo `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Applicare effetti schizzo alle linee della forma**

Un effetto schizzo rende la linea di una forma simile a disegnata a mano. Usa [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) per accedere alle impostazioni della linea, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) per accedere alle impostazioni dello schizzo e [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Il seguente codice Java mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) , leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Accedi al formato della linea della forma e al suo formato schizzo.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Applica un effetto schizzo.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Leggi l'effetto schizzo assegnato direttamente alla forma.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Rimuovi l'effetto schizzo.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Il valore restituito da [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), accedi a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/), e leggi [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). Il valore effettivo riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà:

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

* Arrotondato
* Miter
* Smussato

Per impostazione predefinita, quando PowerPoint unisce due linee ad un angolo (ad esempio all'angolo di una forma), utilizza l'impostazione **Arrotondato**. Tuttavia, se si disegna una forma con angoli acuti, potrebbe essere preferita l'opzione **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Il seguente codice Java dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di unione Miter, Bevel e Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi tre forme automatiche di tipo Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Imposta il colore di riempimento per ciascuna forma rettangolare.
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

    // Imposta il colore per la linea di ciascun rettangolo.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Imposta lo stile di unione.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Aggiungi testo a ciascun rettangolo.
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

In PowerPoint, il Riempimento gradiente è un'opzione di formattazione che consente di applicare una sfumatura continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungi i due colori preferiti con posizioni definite usando i metodi `add` della raccolta di gradient stop esposta dall'interfaccia [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Salva la presentazione modificata come file PPTX.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

    // Aggiungi due gradient stop.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Salva il file PPTX su disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The ellipse with gradient fill](gradient-fill.png)

Se un gradiente appare diverso in un'immagine esportata rispetto a PowerPoint, consulta [Scegliere uno stile di rendering del gradiente](/slides/it/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). È possibile selezionare uno stile di rendering senza modificare il riempimento gradiente memorizzato nella presentazione.

## **Riempimento pattern**

In PowerPoint, il Riempimento pattern è un'opzione di formattazione che consente di applicare un design a due colori — come punti, strisce, tratteggi incrociati o quadretti — a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del pattern.

Aspose.Slides fornisce oltre 45 stili di pattern predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un pattern predefinito, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento pattern a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) della forma su `Pattern`.
1. Scegli uno stile di pattern dalle opzioni predefinite.
1. Imposta il [Colore di sfondo](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) del pattern.
1. Imposta il [Colore di primo piano](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) del pattern.
1. Salva la presentazione modificata come file PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma automatica di tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Imposta lo stile del pattern.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Imposta i colori di sfondo e di primo piano del pattern.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Salva il file PPTX su disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The rectangle with pattern fill](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma, utilizzando efficacemente l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) della forma su `Picture`.
1. Imposta la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) dall'immagine da utilizzare.
1. Passa l'immagine al metodo `ISlidesPicture.setImage`.
1. Salva la presentazione modificata come file PPTX.

![The lotus picture](lotus.png)

Il seguente codice Java mostra come riempire una forma con l'immagine:

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

![The shape with picture fill](picture-fill.png)

### **Piastrella immagine come texture**

Se desideri impostare un'immagine a piastrelle come texture e personalizzare il comportamento della piastrella, puoi utilizzare i seguenti metodi dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Imposta la modalità di riempimento immagine — `Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Specifica l'allineamento delle piastrelle all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controlla se la piastrella è capovolta orizzontalmente, verticalmente o entrambe.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Imposta lo spostamento orizzontale della piastrella (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Imposta lo spostamento verticale della piastrella (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definisce la scala orizzontale della piastrella in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definisce la scala verticale della piastrella in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine a piastrelle e configurare le opzioni della piastrella:

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

    // Configura la modalità di riempimento immagine e le proprietà di piastrellatura.
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

![The tile options](tile-options.png)

## **Riempimento colore solido**

In PowerPoint, il Riempimento colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza sfumature, texture o pattern.

Per applicare un riempimento colore solido a una forma utilizzando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) della forma su `Solid`.
1. Assegna il colore di riempimento desiderato alla forma.
1. Salva la presentazione modificata come file PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

![The shape with solid color fill](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento di colore solido, gradiente, immagine o texture a forme, è possibile impostare anche un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa del colore usato per il riempimento. Ecco come procedere:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) su `Solid`.
1. Usa `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

![The transparent shape](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando è necessario posizionare elementi visivi con requisiti specifici di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Imposta la proprietà di rotazione della forma sull'angolo desiderato.
1. Salva la presentazione.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

![The shape rotation](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides consente di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salva la presentazione.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crea un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una forma alla diapositiva.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Imposta le proprietà ThreeDFormat della forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Salva la presentazione come file PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The 3D bevel effect](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) alla diapositiva.
1. Usa [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) e [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) per definire la rotazione 3D.
1. Salva la presentazione.

```java
import com.aspose.slides.*;

// Crea un'istanza della classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Salva la presentazione come file PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The 3D rotation effect](3D-rotation-effect.png)

## **Controllare il rendering in bianco e nero per le forme**

Il metodo [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) specifica come una singola forma viene renderizzata quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non abilita la visualizzazione in bianco e nero di per sé e non modifica il riempimento, la linea o altre formattazioni della forma in modalità colore normale.

Utilizza un valore della classe [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` consente all'applicazione di rendering di scegliere la conversione, `Gray` e `LightGray` usano la colorazione grigia, `BlackWhite` utilizza solo nero e bianco, `Black` e `White` forzano un colore unico, `Color` conserva la colorazione normale, e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` indica che non è stato assegnato alcun modo a livello di forma.

Il seguente codice Java crea una forma colorata e la fa apparire grigia nella modalità di visualizzazione bianco e nero:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Mantieni il riempimento arancione in modalità colore, ma rendi la forma con colorazione grigia in modalità bianco e nero.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro in bianco e nero, utilizza la colorazione grigia perché il suo modo è impostato su `Gray`. Questo consente di preservare una diapositiva a colori completa definendo al contempo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione in bianco e nero della presentazione.

## **Ripristinare la formattazione**

Il seguente codice Java mostra come ripristinare la formattazione di una diapositiva e ripristinare posizione, dimensione e formattazione di tutte le forme con segnaposto sulla [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) ai valori predefiniti:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Ripristina ogni forma nella diapositiva che ha un segnaposto nel layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo in minima parte. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso individuare le forme su una diapositiva che condividono la stessa formattazione così da poterle raggruppare?**

Confronta le proprietà di formattazione chiave di ogni forma — impostazioni di riempimento, linea ed effetto. Se tutti i valori corrispondenti coincidono, considera i loro stili identici e raggruppa logicamente quelle forme, semplificando la gestione degli stili in seguito.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva le forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate necessarie e riapplica la loro formattazione dove richiesto.