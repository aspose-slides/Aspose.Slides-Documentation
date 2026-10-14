---
title: "Formattare le forme PowerPoint in PHP"
linktitle: "Formattazione forma"
type: docs
weight: 20
url: /it/php-java/shape-formatting/
keywords:
- formattazione forma
- formattazione linea
- effetto schizzo
- linea schizzo della forma
- formattazione stile di giunzione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento trama
- riempimento a tinta unita
- trasparenza forma
- rendering forma bianco e nero
- rendering forma scala di grigi
- rotazione forma
- effetto smussatura 3D
- effetto rotazione 3D
- ripristino formattazione
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in PHP usando Aspose.Slides—imposta riempimenti, linee e stili di effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono costituite da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano il modo in cui vengono riempiti i loro interni.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java fornisce classi e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. La procedura è illustrata nei seguenti passaggi:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta lo [stile della linea](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) della forma.
1. Imposta lo spessore della linea.
1. Imposta lo [stile tratteggio](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) della linea.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice PHP dimostra come formattare un `AutoShape` rettangolare:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi una auto shape di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Imposta il colore di riempimento per la forma rettangolo.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Applica la formattazione alle linee del rettangolo.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Imposta il colore per la linea del rettangolo.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Salva il file PPTX su disco.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Applicare effetti schizzo alle linee delle forme**

Un effetto schizzo rende la linea di una forma simile a un disegno a mano libera. Usa [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) per accedere alle impostazioni della linea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) per accedere alle impostazioni dello schizzo e [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Il seguente codice PHP mostra come applicare l'effetto [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Accedi al formato linea della forma e al suo formato schizzo.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Applica un effetto schizzo.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Leggi l'effetto schizzo assegnato direttamente alla forma.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Rimuovi l'effetto schizzo.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Il valore restituito da [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), accedi al metodo `getSketchFormat` dell'oggetto restituito e leggi il suo valore `getSketchType`. Il valore efficace riflette la formattazione realmente applicata dopo la risoluzione dell'ereditarietà:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Round
* Miter
* Bevel

Per impostazione predefinita, quando PowerPoint unisce due linee a un angolo (ad esempio all'angolo di una forma), utilizza l'impostazione **Round**. Tuttavia, se si disegna una forma con angoli acuti, potrebbe essere preferibile l'opzione **Miter**.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Il seguente codice PHP dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati utilizzando le impostazioni di tipo di giunzione Miter, Bevel e Round:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi tre auto shape di tipo Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Imposta il colore di riempimento per ciascuna forma rettangolo.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Imposta lo spessore della linea.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Imposta il colore per la linea di ciascun rettangolo.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Imposta lo stile di giunzione.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Aggiungi testo a ciascun rettangolo.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Salva il file PPTX su disco.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Riempimento sfumato**

In PowerPoint, il Riempimento sfumato è un'opzione di formattazione che consente di applicare una transizione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento sfumato a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungi i due colori preferiti con posizioni definite usando i metodi `add` della collezione di gradient stop esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Salva la presentazione modificata come file PPTX.

Il seguente codice PHP dimostra come applicare un effetto di riempimento sfumato a un'ellisse:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'auto shape di tipo Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Applica la formattazione gradiente all'ellisse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Imposta la direzione del gradiente.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Aggiungi due fermate del gradiente.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Salva il file PPTX su disco.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'ellisse con riempimento sfumato](gradient-fill.png)

Se un gradiente appare diverso in un'immagine esportata rispetto a PowerPoint, consulta [Choose a Gradient Rendering Style](/slides/it/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puoi selezionare uno stile di rendering senza modificare il riempimento sfumato memorizzato nella presentazione.

## **Riempimento a motivo**

In PowerPoint, il Riempimento a motivo è un'opzione di formattazione che consente di applicare un disegno bicolore — ad esempio punti, strisce, tratteggi incrociati o quadretti — a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegli uno stile di motivo tra le opzioni predefinite.
1. Imposta il [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) del motivo.
1. Imposta il [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) del motivo.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice PHP dimostra come applicare un riempimento a motivo a un rettangolo:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'auto shape di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Imposta lo stile del pattern.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Imposta i colori di sfondo e di primo piano del pattern.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Salva il file PPTX su disco.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il rettangolo con riempimento a motivo](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma, usandola effettivamente come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) della forma su `Picture`.
1. Imposta la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Crea un oggetto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) a partire dall'immagine che desideri utilizzare.
1. Passa l'immagine al metodo `SlidesPicture.setImage`.
1. Salva la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine di loto](lotus.png)

Il seguente codice PHP dimostra come riempire una forma con l'immagine:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'auto shape di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Imposta il tipo di riempimento su Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Imposta la modalità di riempimento immagine.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Carica un'immagine e aggiungila alle risorse della presentazione.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Imposta l'immagine.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Salva il file PPTX su disco.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Tile Picture As Texture**

Se desideri impostare un'immagine affiancata come texture e personalizzare il comportamento del mosaico, puoi utilizzare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Imposta la modalità di riempimento immagine — `Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Specifica l'allineamento delle tessere all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Controlla se la tessera viene ribaltata orizzontalmente, verticalmente o in entrambi i modi.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Imposta lo spostamento orizzontale della tessera (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Imposta lo spostamento verticale della tessera (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definisce la scala orizzontale della tessera in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definisce la scala verticale della tessera in percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine affiancato e configurare le opzioni del mosaico:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'auto shape di tipo Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Imposta il tipo di riempimento della forma su Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Carica l'immagine e aggiungila alle risorse della presentazione.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Assegna l'immagine alla forma.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Configura la modalità di riempimento immagine e le proprietà di tiling.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Salva il file PPTX su disco.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le opzioni del mosaico](tile-options.png)

## **Riempimento a tinta unita**

In PowerPoint, il Riempimento a tinta unita è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, trame o motivi.

Per applicare un riempimento a tinta unita a una forma utilizzando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) della forma su `Solid`.
1. Assegna il colore di riempimento desiderato alla forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice PHP dimostra come applicare un riempimento a tinta unita a un rettangolo in una diapositiva PowerPoint:

```php
    // Istanzia la classe Presentation che rappresenta un file di presentazione.
    $presentation = new Presentation();
    try {
        // Ottieni la prima diapositiva.
        $slide = $presentation->getSlides()->get_Item(0);

        // Aggiungi un'auto shape di tipo Rectangle.
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

        // Imposta il tipo di riempimento su Solid.
        $shape->getFillFormat()->setFillType(FillType::Solid);

        // Imposta il colore di riempimento.
        $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

        // Salva il file PPTX su disco.
        $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

Il risultato:

![La forma con riempimento a tinta unita](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento solido, sfumato, immagine o texture alle forme, è possibile impostare anche un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa nel colore usato per il riempimento. Ecco come procedere:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) su `Solid`.
1. Usa `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

Il seguente codice PHP dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi una auto shape rettangolare solida.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Aggiungi una auto shape rettangolare trasparente sopra la forma solida.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Salva il file PPTX su disco.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con requisiti specifici di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta la proprietà di rotazione della forma sull'angolo desiderato.
1. Salva la presentazione.

Il seguente codice PHP dimostra come ruotare una forma di 5 gradi:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'auto shape di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ruota la forma di 5 gradi.
    $shape->setRotation(5);

    // Salva il file PPTX su disco.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smussatura 3D**

Aspose.Slides consente di applicare effetti di smussatura 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Per aggiungere effetti di smussatura 3D a una forma, segui questi passaggi:

1. Istanzia la classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) della forma per definire le impostazioni di smussatura.
1. Salva la presentazione.

Il seguente codice PHP mostra come applicare effetti di smussatura 3D a una forma:

```php
// Crea un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi una forma alla diapositiva.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Imposta le proprietà ThreeDFormat della forma.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Salva la presentazione come file PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'effetto di smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Usa [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
1. Salva la presentazione.

Il seguente codice PHP dimostra come applicare effetti di rotazione 3D a una forma:

```php
// Crea un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Salva la presentazione come file PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Controllare il rendering in bianco e nero per le forme**

Il metodo [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) specifica come una singola forma viene renderizzata quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non abilita la visualizzazione in bianco e nero di per sé e non modifica il riempimento, la linea o altra formattazione della forma in modalità a colori normali.

Usa un valore della classe [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Ad esempio, `Automatic` consente all'applicazione di rendering di scegliere la conversione, `Gray` e `LightGray` usano la colorazione grigia, `BlackWhite` utilizza solo nero e bianco, `Black` e `White` forzano un colore unico, `Color` preserva la colorazione normale e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` indica che nessuna modalità a livello di forma è assegnata.

Il seguente codice PHP crea una forma colorata e la fa apparire grigia nella modalità di visualizzazione bianco e nero:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Mantieni il riempimento arancione in modalità colore, ma renderizza la forma con colorazione grigia in modalità bianco e nero.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione in bianco e nero, utilizza la colorazione grigia perché la sua modalità è impostata su `Gray`. Questo consente di preservare una diapositiva a colori completi definendo al contempo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione bianco e nero della presentazione.

## **Ripristinare la formattazione**

Il seguente codice Java mostra come ripristinare la formattazione di una diapositiva e riportare posizione, dimensione e formattazione di tutte le forme con segnaposto su [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) alle impostazioni predefinite:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Reimposta ogni forma nella diapositiva che ha un segnaposto nel layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo in minima parte. Le immagini incorporate e i media occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso rilevare forme su una diapositiva che condividono la stessa formattazione in modo da raggrupparle?**

Confronta le proprietà chiave di formattazione di ogni forma — impostazioni di riempimento, linea ed effetti. Se tutti i valori corrispondenti coincidono, considera i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione degli stili in seguito.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva forme di esempio con gli stili desiderati in un modello di diapositiva o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate di cui hai bisogno e riapplica la loro formattazione dove necessario.