---
title: Formattare le forme PowerPoint in PHP
linktitle: Formattazione delle forme
type: docs
weight: 20
url: /it/php-java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- formattare stile di unione
- riempimento gradiente
- riempimento a trama
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
- PHP
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in PHP usando Aspose.Slides—imposta stili di riempimento, linea ed effetti per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come gli interni vengono riempiti.

![Formattazione forma PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java fornisce classi e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattazione delle linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti illustrano la procedura:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Imposta lo [stile linea](https://reference.aspose.com/slides/it/php-java/aspose.slides/linestyle/) della forma.
5. Imposta lo spessore della linea.
6. Imposta lo [stile tratteggio](https://reference.aspose.com/slides/it/php-java/aspose.slides/linedashstyle/) della linea.
7. Imposta il colore della linea per la forma.
8. Salva la presentazione modificata come file PPTX.

Il codice PHP seguente dimostra come formattare un `AutoShape` rettangolo:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Impostare il colore di riempimento per la forma rettangolo.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Applicare la formattazione alle linee del rettangolo.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Impostare il colore per la linea del rettangolo.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Salvare il file PPTX su disco.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

## **Formattare gli stili di unione**

Ecco le tre opzioni di tipo di unione:

* Arrotondato
* Scanalatura
* Smussato

Per impostazione predefinita, quando PowerPoint unisce due linee a un angolo (ad esempio all'angolo di una forma), utilizza l'impostazione **Arrotondato**. Tuttavia, se disegni una forma con angoli acuti, potresti preferire l'opzione **Scanalatura**.

![Lo stile di unione nella presentazione](join-style-powerpoint.png)

Il codice PHP seguente dimostra come sono stati creati tre rettangoli (come mostrato nell'immagine sopra) utilizzando le impostazioni di tipo di unione Scanalatura, Smussato e Arrotondato:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere tre forme automatiche di tipo Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Impostare il colore di riempimento per ciascuna forma rettangolo.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Impostare lo spessore della linea.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Impostare il colore per la linea di ciascun rettangolo.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Impostare lo stile di unione.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Aggiungere testo a ciascun rettangolo.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Salvare il file PPTX su disco.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Riempimento gradiente**

In PowerPoint, il Riempimento Gradiente è un'opzione di formattazione che consente di applicare una fusione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Gradient`.
5. Aggiungi i due colori preferiti con posizioni definite utilizzando i metodi `add` della collezione di fermate gradiente esposta dalla classe [GradientFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/gradientformat/).
6. Salva la presentazione modificata come file PPTX.

Il codice PHP seguente dimostra come applicare un effetto di riempimento gradiente a un'ellisse:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica di tipo Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Applicare la formattazione gradiente all'ellisse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Impostare la direzione del gradiente.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Aggiungere due fermate gradiente.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Salvare il file PPTX su disco.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'ellisse con riempimento gradiente](gradient-fill.png)

## **Riempimento a trama**

In PowerPoint, il Riempimento a Trama è un'opzione di formattazione che consente di applicare un disegno a due colori—come punti, strisce, reticolati o quadretti—a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo della trama.

Aspose.Slides fornisce oltre 45 stili di trama predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato una trama predefinita, è possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a trama a una forma utilizzando Aspose.Slides:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Pattern`.
5. Scegli uno stile di trama tra le opzioni predefinite.
6. Imposta il [Colore di sfondo](https://reference.aspose.com/slides/it/php-java/aspose.slides/patternformat/#getBackColor) della trama.
7. Imposta il [Colore di primo piano](https://reference.aspose.com/slides/it/php-java/aspose.slides/patternformat/#getForeColor) della trama.
8. Salva la presentazione modificata come file PPTX.

Il codice PHP seguente dimostra come applicare un riempimento a trama a un rettangolo:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Impostare il tipo di riempimento su Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Impostare lo stile del pattern.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Impostare i colori di sfondo e di primo piano del pattern.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Salvare il file PPTX su disco.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il rettangolo con riempimento a trama](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento Immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma—utilizzando effettivamente l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Picture`.
5. Imposta la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
6. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/ppimage/) dall'immagine che desideri utilizzare.
7. Passa l'immagine al metodo `SlidesPicture.setImage`.
8. Salva la presentazione modificata come file PPTX.

Supponiamo di avere un file "lotus.png" con l'immagine seguente:

![L'immagine di loto](lotus.png)

Il codice PHP seguente dimostra come riempire una forma con l'immagine:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Impostare il tipo di riempimento su Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Impostare la modalità di riempimento immagine.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Caricare un'immagine e aggiungerla alle risorse della presentazione.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Impostare l'immagine.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Salvare il file PPTX su disco.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Immagine a mosaico come texture**

Se desideri impostare un'immagine a mosaico come texture e personalizzare il comportamento della tassellatura, puoi utilizzare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileAlignment): Specifica l'allineamento delle tessere all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileFlip): Controlla se la tessera è capovolta orizzontalmente, verticalmente o in entrambi i sensi.
- [setTileOffsetX](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Imposta lo scostamento orizzontale della tessera (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Imposta lo scostamento verticale della tessera (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definisce la scala orizzontale della tessera in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definisce la scala verticale della tessera in percentuale.

Il campione di codice seguente mostra come aggiungere una forma rettangolare con riempimento immagine a mosaico e configurare le opzioni della tessera:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica rettangolare.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Impostare il tipo di riempimento della forma su Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Caricare l'immagine e aggiungerla alle risorse della presentazione.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Assegnare l'immagine alla forma.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Configurare la modalità di riempimento immagine e le proprietà di tessellazione.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Salvare il file PPTX su disco.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le opzioni di tassellatura](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a Colore Solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice viene applicato senza gradienti, texture o trame.

Per applicare un riempimento a colore solido a una forma usando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) della forma su `Solid`.
5. Assegna il colore di riempimento preferito alla forma.
6. Salva la presentazione modificata come file PPTX.

Il codice PHP seguente dimostra come applicare un riempimento a colore solido a un rettangolo in una diapositiva PowerPoint:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Impostare il tipo di riempimento su Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Impostare il colore di riempimento.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Salvare il file PPTX su disco.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma con riempimento a colore solido](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando applichi un riempimento a colore solido, gradiente, immagine o texture a una forma, puoi anche impostare un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza modificando il valore alfa del colore usato per il riempimento. Ecco come fare:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Imposta il [FillType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filltype/) su `Solid`.
5. Usa `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
6. Salva la presentazione.

Il codice PHP seguente dimostra come applicare un colore di riempimento trasparente a un rettangolo:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica rettangolare solida.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Aggiungere una forma automatica rettangolare trasparente sopra la forma solida.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Salvare il file PPTX su disco.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con specifici requisiti di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Imposta la proprietà di rotazione della forma sull'angolo desiderato.
5. Salva la presentazione.

Il codice PHP seguente dimostra come ruotare una forma di 5 gradi:

```php
// Istanziare la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Ottenere la prima diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma automatica di tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ruotare la forma di 5 gradi.
    $shape->setRotation(5);

    // Salvare il file PPTX su disco.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides consente di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, segui questi passaggi:

1. Instanzia la classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Configura il [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
5. Salva la presentazione.

Il codice PHP seguente mostra come applicare effetti di smusso 3D a una forma:

```php
// Creare un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Aggiungere una forma alla diapositiva.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Impostare le proprietà ThreeDFormat della forma.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Salvare la presentazione come file PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'effetto smusso 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) alla diapositiva.
4. Usa i metodi [setCameraType](https://reference.aspose.com/slides/it/php-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/it/php-java/aspose.slides/lightrig/#setLightType) per definire la rotazione 3D.
5. Salva la presentazione.

Il codice PHP seguente dimostra come applicare effetti di rotazione 3D a una forma:

```php
// Creare un'istanza della classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Salvare la presentazione come file PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Reimpostare la formattazione**

Il codice Java seguente mostra come reimpostare la formattazione di una diapositiva e riportare posizione, dimensione e formattazione di tutte le forme con segnaposti su [LayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/) alle impostazioni predefinite:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Reimpostare ogni forma sulla diapositiva che ha un segnaposto nel layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulle dimensioni finali del file di presentazione?**

Solo marginalmente. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme, come colori, effetti e gradienti, sono memorizzati come metadati e aggiungono praticamente nessuna dimensione aggiuntiva.

**Come posso individuare le forme su una diapositiva che condividono una formattazione identica in modo da raggrupparle?**

Confronta le proprietà chiave di formattazione di ciascuna forma—impostazioni di riempimento, linea ed effetti. Se tutti i valori corrispondono, considera i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione degli stili in seguito.

**Posso salvare un insieme di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva forme di esempio con gli stili desiderati in un modello di diapositiva o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate di cui hai bisogno e riapplica la loro formattazione dove necessario.