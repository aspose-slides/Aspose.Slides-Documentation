---
title: Formattare forme PowerPoint in PHP
linktitle: Formattazione forma
type: docs
weight: 20
url: /it/php-java/shape-formatting/
keywords:
- formattazione forma
- formattazione linea
- effetto schizzo
- linea forma schizzo
- formattazione stile unione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in PHP usando Aspose.Slides—imposta riempimenti, linee e stili di effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, puoi aggiungere forme alle diapositive. Poiché le forme sono composte da linee, puoi formattarle modificando o applicando effetti ai loro contorni. Inoltre, puoi formattare le forme specificando impostazioni che controllano come vengono riempiti i loro interni.

![formattazione-forme-powerpoint](format-shape-powerpoint.png)

Aspose.Slides per PHP via Java fornisce classi e metodi che consentono di formattare le forme usando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, puoi specificare uno stile di linea personalizzato per una forma. I seguenti passaggi descrivono la procedura:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta lo [stile di linea](https://reference.aspose.com/slides/it/php-java/aspose.slides/linestyle/) della forma.
1. Imposta la larghezza della linea.
1. Imposta lo [stile di tratteggio](https://reference.aspose.com/slides/it/php-java/aspose.slides/linedashstyle/) della linea.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il seguente codice PHP dimostra come formattare un `AutoShape` rettangolo:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi una autoforma di tipo Rectangle.
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

## **Applicare effetti schizzo alle linee della forma**

Un effetto schizzo rende la linea di una forma simile a disegnata a mano. Usa [Shape.getLineFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) per accedere alle impostazioni della linea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/lineformat/) per accedere alle impostazioni dello schizzo e [SketchFormat.setSketchType](https://reference.aspose.com/slides/it/php-java/aspose.slides/sketchformat/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/php-java/aspose.slides/linesketchtype/).

Il seguente codice PHP mostra come applicare un effetto [LineSketchType.Curved](https://reference.aspose.com/slides/it/php-java/aspose.slides/linesketchtype/) , leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType.None](https://reference.aspose.com/slides/it/php-java/aspose.slides/linesketchtype/):

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

Il valore restituito da [SketchFormat.getSketchType](https://reference.aspose.com/slides/it/php-java/aspose.slides/sketchformat/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, master slide o layout slide, usa [LineFormat.getEffective](https://reference.aspose.com/slides/it/php-java/aspose.slides/lineformat/), accedi al metodo `getSketchFormat` dell'oggetto restituito e leggi il valore `getSketchType`. Il valore effettivo riflette la formattazione realmente applicata dopo la risoluzione dell'ereditarietà:

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

## **Formattare gli stili di unione**

Ecco le tre opzioni di tipo di unione:

* Arrotondato
* Smusso
* Smussatura

Per impostazione predefinita, quando PowerPoint unisce due linee a un angolo (come nell'angolo di una forma), utilizza l'impostazione **Arrotondato**. Tuttavia, se stai disegnando una forma con angoli acuti, potresti preferire l'opzione **Smusso**.

![Lo stile di unione nella presentazione](join-style-powerpoint.png)

Il seguente codice PHP dimostra come tre rettangoli (come mostrato nell'immagine sopra) siano stati creati usando le impostazioni di tipo di unione Miter, Bevel e Round:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi tre autoforme di tipo Rectangle.
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

    // Imposta la larghezza della linea.
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

    // Imposta lo stile di unione.
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

## **Riempimento a gradiente**

In PowerPoint, il Riempimento a Gradiente è un'opzione di formattazione che consente di applicare una sfumatura continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento a gradiente a una forma usando Aspose.Slides:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungi i due colori preferiti con posizioni definite usando i metodi `add` della collezione di fermate del gradiente esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/gradientformat/).
1. Salva la presentazione modificata come file PPTX.

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'autoforma di tipo Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Applica la formattazione a gradiente all'ellisse.
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

![L'ellisse con riempimento a gradiente](gradient-fill.png)

## **Riempimento a motivo**

In PowerPoint, il Riempimento a Motivo è un'opzione di formattazione che consente di applicare un disegno a due colori — come punti, righe, tratteggi o quadretti — a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma usando Aspose.Slides:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegli uno stile di motivo dalle opzioni predefinite.
1. Imposta il [Background Color](https://reference.aspose.com/slides/it/php-java/aspose.slides/patternformat/#getBackColor) del motivo.
1. Imposta il [Foreground Color](https://reference.aspose.com/slides/it/php-java/aspose.slides/patternformat/#getForeColor) del motivo.
1. Salva la presentazione modificata come file PPTX.

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'autoforma di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Imposta il tipo di riempimento su Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Imposta lo stile del motivo.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Imposta i colori di sfondo e di primo piano del motivo.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Salva il file PPTX su disco.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Il rettangolo con riempimento a motivo](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento Immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma, utilizzandola come sfondo della forma stessa.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Picture`.
1. Imposta la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) dall'immagine che desideri utilizzare.
1. Passa l'immagine al metodo `SlidesPicture.setImage`.
1. Salva la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine del loto](lotus.png)

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'autoforma di tipo Rectangle.
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

![La forma con riempimento immagine](picture-fill.png)

### **Tessellare immagine come texture**

Se vuoi impostare un'immagine a piastrelle come texture e personalizzare il comportamento della piastrellatura, puoi utilizzare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileAlignment): Specifica l'allineamento delle tessere all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileFlip): Controlla se la tessera è capovolta orizzontalmente, verticalmente o entrambe.
- [setTileOffsetX](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Imposta lo spostamento orizzontale della tessera (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Imposta lo spostamento verticale della tessera (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definisce la scala orizzontale della tessera come percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definisce la scala verticale della tessera come percentuale.

Il seguente esempio di codice mostra come aggiungere una forma rettangolare con riempimento immagine a piastrelle e configurare le opzioni di piastrellatura:

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'autoforma rettangolare.
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

    // Configura la modalità di riempimento immagine e le proprietà di piastrellatura.
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

![Le opzioni di tessera](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a Colore Solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o motivi.

Per applicare un riempimento a colore solido a una forma usando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Solid`.
1. Assegna alla forma il colore di riempimento preferito.
1. Salva la presentazione modificata come file PPTX.

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'autoforma di tipo Rectangle.
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

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando applichi un riempimento a colore solido, gradiente, immagine o texture a delle forme, puoi anche impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides ti permette di impostare il livello di trasparenza regolando il valore alpha nel colore usato per il riempimento. Ecco come fare:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) su `Solid`.
1. Usa `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'autoforma rettangolare solida.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Aggiungi un'autoforma rettangolare trasparente sopra la forma solida.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Salva il file PPTX su disco.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con esigenze specifiche di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Imposta la proprietà di rotazione della forma sull'angolo desiderato.
1. Salva la presentazione.

```php
// Istanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungi un'autoforma di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ruota la forma di 5 gradi.
    $shape->setRotation(5);

    // Salva il file PPTX su disco.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides consente di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, segui questi passaggi:

1. Istanzia la classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salva la presentazione.

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

![L'effetto di smusso 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/).

Per applicare la rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
1. Usa [setCameraType](https://reference.aspose.com/slides/it/php-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/it/php-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
1. Salva la presentazione.

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

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Ripristinare la formattazione**

Il seguente codice Java mostra come ripristinare la formattazione di una diapositiva e riportare posizione, dimensione e formattazione di tutte le forme con segnaposto sul [LayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/) alle impostazioni predefinite:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Reimposta ogni forma sulla diapositiva che ha un segnaposto nel layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono archiviati come metadata e aggiungono praticamente nessuna dimensione aggiuntiva.

**Come posso rilevare forme su una diapositiva che condividono la stessa formattazione così da poterle raggruppare?**

Confronta le proprietà chiave di formattazione di ciascuna forma — impostazioni di riempimento, linea ed effetto. Se tutti i valori corrispondono, considera i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva le forme di esempio con gli stili desiderati in un modello di diapositiva o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate di cui hai bisogno e riapplica la loro formattazione dove necessario.