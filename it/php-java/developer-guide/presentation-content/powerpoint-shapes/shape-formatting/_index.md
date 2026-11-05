---
title: Formattare le forme PowerPoint in PHP
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/php-java/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea forma schizzo
- formattare stile di giunzione
- riempimento gradiente
- riempimento a trama
- riempimento immagine
- riempimento texture
- riempimento a colore solido
- trasparenza forma
- rendering forma in bianco e nero
- rendering forma in scala di grigi
- ruotare forma
- effetto smussatura 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in PHP usando Aspose.Slides - imposta riempimento, linea e stili degli effetti per file PPT e PPTX con precisione e pieno controllo."
---
## **Introduzione**

Formatta le forme in PowerPoint regolando i contorni, i riempimenti e gli effetti. Aspose.Slides per PHP via Java consente di controllare queste impostazioni tramite codice, inclusi trasparenza, rotazione e formattazione 3D.

![Opzioni di formattazione della forma in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides per PHP via Java fornisce classi e metodi che permettono di formattare le forme usando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Usa [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) per controllare il contorno di una forma. Questo esempio crea un rettangolo non riempito con un contorno blu a tratteggio. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) seleziona una linea composta spessa-sottile, mentre [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) ne imposta lo spessore a 7 punti e [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) sceglie il modello di tratteggio.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le linee formattate nella presentazione](formatted-lines.png)

### **Impostare modelli di tratteggio personalizzati**

Usa [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) quando gli stili di linea predefiniti non forniscono le lunghezze di tratto e di interruzione necessarie, ad esempio per contorni aziendali o diagrammi tecnici. L'assegnazione di un modello cambia automaticamente lo stile di tratto della linea in [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Le voci dell'array alternano lunghezze di tratto e di interruzione, iniziando con un tratto. Ogni valore è un multiplo dello spessore della linea: `[4, 2]` a uno spessore di 3 punti produce un tratto di 12 punti seguito da un'interruzione di 6 punti. Usa coppie di valori finiti e non negativi per definire segmenti di tratto‑interruzione completi. L'esempio utilizza valori positivi per mantenere visibili tutti i tratti e le interruzioni.

Questo esempio crea cinque linee blu della stessa lunghezza con estremità piatte. Le prime tre confrontano i modelli a uno spessore di 3 punti. La quarta ripete il primo modello a doppio spessore, raddoppiando sia la lunghezza del tratto sia quella dell'interruzione. La quinta passa da un modello personalizzato a una linea continua.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Restituire l'ultima linea a uno stile solido.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per tornare a uno stile di tratto predefinito, passa [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) a [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Lo stile selezionato controlla l'aspetto della linea.

Il risultato in PowerPoint, dall'alto verso il basso: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Tre modelli di tratto personalizzati, una linea più larga usando il primo modello e una linea continua in PowerPoint](custom-dash-patterns.png)

### **Impostare le estremità delle linee**

Usa [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) per impostare le estremità di una linea aperta. La classe [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) fornisce tre stili di estremità espliciti:

- `Flat`: il tratto si ferma al punto finale.
- `Round`: un'estremità semicircolare si estende oltre il punto finale di metà spessore della linea.
- `Square`: un'estremità quadrata si estende oltre il punto finale di metà spessore della linea.

La classe include anche `NotDefined`, che significa che non è stato assegnato esplicitamente alcun stile di estremità.

Le estremità sono diverse dalle punte delle frecce, che aggiungono simboli alle estremità della linea, e dalle giunzioni, che controllano gli angoli tra i segmenti di linea. Questo esempio disabilita le punte delle frecce tramite [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) e [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) così che vengano confrontate solo le forme delle estremità.

L'esempio seguente crea tre linee orizzontali altrimenti identiche, larghe 20 punti. Dall'alto verso il basso, usano estremità flat, round e square. I loro punti finali hanno le stesse coordinate orizzontali; le estremità round e square si estendono per 10 punti oltre ciascun punto finale.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato in PowerPoint, dall'alto verso il basso: **Flat**, **Round** e **Square**.

![Estremità flat, round e square su linee spesse identiche in PowerPoint](line-caps.png)

## **Applicare effetti di schizzi alle linee delle forme**

Un effetto di schizzi fa apparire una linea di forma come disegnata a mano. Usa [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) per accedere alle impostazioni della linea, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) per accedere alle impostazioni dello schizzo e [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) per selezionare un valore dalla classe [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Il codice PHP seguente mostra come applicare un effetto [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Il valore restituito da [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), accedi al metodo `getSketchFormat` dell'oggetto restituito e leggi il suo valore `getSketchType`. Il valore effective riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà. Questo esempio richiede una presentazione esistente con almeno una forma nella prima diapositiva e stampa entrambi i valori:

```php
use aspose\slides\Presentation;

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

Lo stile di giunzione controlla come due segmenti di contorno si incontrano a un angolo. Usa **Round** per angoli arrotondati, **Miter** per angoli appuntiti o **Bevel** per angoli appiattiti.

![Lo stile di giunzione nella presentazione](join-style-powerpoint.png)

Questo esempio crea tre rettangoli neri con contorni blu larghi 15 punti. Imposta [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ai valori miter, bevel e round della classe [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), rispettivamente, per confrontare come vengono disegnati gli angoli.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Limitare le giunzioni a incastro nei punti acuti**

Usa [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) con [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) impostato su [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) per limitare quanto può estendersi un angolo acuto.

Il limite è un rapporto tra la distanza tra gli angoli interno ed esterno della giunzione e lo spessore della linea. Per esempio, un valore di `8` consente una lunghezza dell'incastro fino a otto volte lo spessore della linea; non è una misura in punti. Se l'angolo superasse il limite, PowerPoint utilizza una giunzione smussata in quel punto. Un limite più grande consente punte più acute. L'impostazione influisce solo sulle giunzioni a incastro e non ha effetto visibile quando l'angolo rimane entro entrambi i limiti.

Questo esempio crea due triangoli identici, non riempiti, con contorni larghi 20 punti. Il triangolo sinistro usa un limite di `2`, quello destro di `8`. Ogni triangolo è largo 80 punti e alto 160 punti, dando al suo angolo superiore un rapporto lunghezza-incastro / spessore di circa `4.12`. Di conseguenza, PowerPoint smussa l'apice sinistro e mantiene l'apice destro.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato in PowerPoint: **Limite incastro 2** a sinistra e **Limite incastro 8** a destra.

![Un apice smussato con limite incastro 2 e un apice appuntito con limite incastro 8 in PowerPoint](miter-limits.png)

## **Riempimento a gradiente**

Un riempimento a gradiente fonde i colori su una forma. Questo esempio riempie un'ellisse con un gradiente lineare a 45 gradi dal rosso al viola usando [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). Il metodo [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) posiziona le fermate di colore a 0 e 1, all'inizio e alla fine del gradiente. Cancellare le fermate esistenti assicura che vengano usati solo questi due colori.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'ellisse con riempimento a gradiente](gradient-fill.png)

Se un gradiente appare diverso in un'immagine esportata rispetto a PowerPoint, consulta [Choose a Gradient Rendering Style](/slides/it/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puoi selezionare uno stile di rendering senza modificare il gradiente memorizzato nella presentazione.

### **Impostare l'angolo del gradiente lineare**

Usa [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) per controllare l'orientamento di un riempimento [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). L'angolo è misurato in gradi e aumenta in senso orario: `0` va da sinistra a destra, `90` dall'alto al basso, `180` da destra a sinistra e `270` dal basso all'alto. Sono supportati angoli frazionari. Angoli finiti fuori dall'intervallo `[0, 360)` sono normalizzati a una rivoluzione; ad esempio, `-45` diventa `315` e `360` diventa `0`.

Questo esempio crea sei rettangoli con fermate di rosso, verde e blu identiche alle posizioni `0`, `0.5` e `1`. La scala è disabilitata così l'angolo può essere confrontato indipendentemente dalle proporzioni dei rettangoli. Gli angoli, da sinistra a destra, sono `0`, `45` e `90` nella prima riga, e `135`, `180` e `270` nella seconda riga.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato in PowerPoint:

![Gradienti lineari a 0, 45 e 90 gradi nella riga superiore, e a 135, 180 e 270 gradi nella riga inferiore](linear-gradient-angles.png)

### **Scalare un gradiente lineare con la forma**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) accetta un valore [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Impostalo esplicitamente su `False` per mantenere l'angolo geometrico del gradiente mentre le proporzioni della forma cambiano, o su `True` per scalare il gradiente con larghezza e altezza della forma. Con la scala abilitata, l'angolo visibile può differire dall'angolo assegnato su una forma non quadrata.

L'esempio seguente usa un angolo di `45` gradi e le stesse fermate di colore dell'esempio di confronto degli angoli. La colonna sinistra usa `False`; la colonna destra usa `True`. Ogni colonna contiene un rettangolo largo sopra un rettangolo alto. Entrambi partono dalle stesse dimensioni larghe; modificare larghezza e altezza del secondo rettangolo dimostra come il riempimento risponde al ridimensionamento senza cambiare le impostazioni del gradiente.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato in PowerPoint, con la scala disabilitata a sinistra e abilitata a destra:

![Rettangoli larghi e alti con un gradiente a 45 gradi, confrontando LinearGradientScaled False a sinistra con True a destra](linear-gradient-scaling.png)

Con la scala disabilitata, le bande di colore diagonali mantengono la stessa orientazione in entrambi i rettangoli. Con la scala abilitata, le bande si allungano con le proporzioni della forma. Questo aiuta a riprodurre il gradiente di un modello quando si adatta una forma a una dimensione diversa. Su una forma quadrata, abilitare la scala non cambia l'aspetto di questo gradiente a `45` gradi.

Sia l'angolo sia le impostazioni di scala si applicano ai gradienti lineari. Non controllano i riempimenti [GradientShape::Radial o GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Combinare l'angolo con la direzione del gradiente**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) seleziona uno stile di gradiente dalla classe [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); non è un sostituto per un angolo numerico. Per un gradiente lineare, gli stili di angolo possono modificare l'area su cui i colori sono distribuiti senza cambiare l'angolo assegnato tramite [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Mantieni la direzione invariata quando confronti angoli o scale.

L'esempio seguente applica le stesse impostazioni in ordine opposto. I due rettangoli hanno lo stesso aspetto: assegnare la direzione prima o dopo l'angolo non cambia il risultato.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Riempimento a trama**

Un riempimento a trama applica un disegno bicolore, come punti, righe o scacchi. Questo esempio usa [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) per selezionare un modello a rete. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) fornisce lo sfondo grigio chiaro, e [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) fornisce il colore giallo della trama.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Il rettangolo con riempimento a trama](pattern-fill.png)

## **Riempimento immagine**

Un riempimento immagine utilizza un'immagine all'interno di una forma. Questo esempio richiede un'immagine locale e usa [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) per caricarla nella collezione di immagini della presentazione. Impostare [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) sulla modalità tiled ripete l'immagine all'interno del rettangolo. L'immagine di origine mostrata qui sotto:

![L'immagine del loto](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma con riempimento immagine](picture-fill.png)

### **Tessellare l'immagine come trama**

Se desideri impostare un'immagine tassellata come trama e personalizzare il comportamento della tessellazione, puoi usare i seguenti metodi della classe [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): imposta la modalità di riempimento immagine—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): specifica l'allineamento delle tessere all'interno della forma.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): controlla se la tessera è capovolta orizzontalmente, verticalmente o in entrambe le direzioni.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): imposta lo spostamento orizzontale della tessera (in punti) dall'origine della forma.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): imposta lo spostamento verticale della tessera (in punti) dall'origine della forma.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): definisce la scala orizzontale della tessera in percentuale.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): definisce la scala verticale della tessera in percentuale.

Questo esempio richiede un'immagine locale e configura [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) per ripeterla al 50 % della sua dimensione originale. Gli offset di −32 punti spostano le tessere orizzontalmente e verticalmente; l'allineamento in basso a destra e il capovolgimento in entrambe le direzioni determinano come viene disposto il pattern ripetuto.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![Le opzioni di tessellazione](tile-options.png)

## **Riempimento a colore solido**

Un riempimento solido assegna alla forma un unico colore uniforme. Questo esempio imposta [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) sul tipo di riempimento solido e assegna il giallo tramite [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), quindi salva il rettangolo nella presentazione.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma con riempimento a colore solido](solid-color-fill.png)

### **Copiare i colori preservando i riferimenti al tema**

Usa [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) per copiare una definizione di colore, inclusi tipo di colore, riferimento al tema e trasformazioni. Questo è utile quando si trasferisce un colore di riempimento tra forme che devono continuare a seguire il tema della presentazione. Il metodo copia solo il colore: non copia il tipo di riempimento, il contorno o altra formattazione della forma. Imposta esplicitamente il tipo di riempimento di destinazione con [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Questo esempio crea tre rettangoli, da sinistra a destra: la sorgente, una copia consapevole del tema e una copia RGB fissa. La sorgente usa [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) per fare riferimento al primo colore di accento e aggiunge una tinta tramite [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). La copia RGB usa il colore di riempimento effective della sorgente, così tutti e tre inizialmente appaiono identici. Chiamare [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) imposta un valore RGB fisso e cancella eventuali trasformazioni di colore esistenti.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // I riferimenti al tema seguono il nuovo colore di accento; il valore RGB fisso non lo fa.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prima della modifica del tema, tutti e tre i riempimenti corrispondono:

![Sorgente, destinazione copyFrom e destinazione RGB fissa con riempimenti blu identici](color-copy-before.png)

Dopo la modifica del tema, la sorgente e la copia consapevole del tema seguono il nuovo colore di accento e mantengono la loro tinta. La copia RGB fissa rimane blu:

![Sorgente e destinazione copyFrom con riempimenti arancioni, mentre la destinazione RGB fissa rimane blu](color-copy-after.png)

La definizione copiata è indipendente dalla sorgente. Modificare successivamente il riferimento al tema della sorgente, assegnare un altro colore o aggiungere/rimuovere le sue trasformazioni non influisce sulla destinazione. Una modifica del tema influisce comunque su entrambe le forme perché ciascuna fa riferimento indipendentemente allo stesso colore del tema.

Il salvataggio e la riapertura del PPTX preservano il tipo di colore restituito da [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), il riferimento al tema e la collezione di trasformazioni restituita da [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); non appiattiscono la definizione in RGB.

Quando si copia tra contesti tematici diversi, ad esempio presentazioni con palette di accento diverse, il riferimento copiato viene risolto rispetto al tema di destinazione. Lo stesso riferimento e le stesse trasformazioni possono quindi produrre un colore visibile diverso. Vedi [Presentation Theme](/slides/it/php-java/presentation-theme/) per ulteriori informazioni sulla configurazione dei colori del tema.

## **Usare lo sfondo della diapositiva come riempimento della forma**

Usa [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) quando una forma deve corrispondere allo sfondo della diapositiva, ad esempio in un modello di presentazione. Imposta il tipo di riempimento con [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) su [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) prima per rimuovere qualsiasi riempimento esplicito. Con questa combinazione, la forma utilizza lo sfondo della diapositiva invece del riempimento di stile. Attivare il flag da solo non rimuove un riempimento esplicito esistente.

Ciò differisce da [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): il riempimento di sfondo copre gli oggetti dietro la forma con l'area corrispondente dello sfondo della diapositiva, mentre NoFill lascia visibili quegli oggetti. Un gradiente rimane allineato alla diapositiva anziché ricominciare all'interno di ogni forma.

L'esempio seguente crea uno sfondo master ereditato dalla diapositiva e posiziona una banda magenta dietro tre rettangoli. Il rettangolo sinistro usa lo sfondo, il rettangolo centrale non ha riempimento e il rettangolo destro passa dal riempimento di sfondo a un riempimento arancione esplicito.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Eredita il gradiente dal master.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Aggiungi questo oggetto per primo così appare dietro i rettangoli.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Disabilita il riempimento di sfondo prima di applicare un riempimento esplicito.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato, da sinistra a destra: **riempimento di sfondo**, **nessun riempimento** e **riempimento esplicito**. La banda magenta è nascosta dai rettangoli sinistro e destro ma rimane visibile attraverso il rettangolo centrale.

![Riempimento di sfondo, nessun riempimento e riempimento arancione esplicito su una banda magenta](background-fill.png)

Lo stesso comportamento si applica a uno sfondo definito direttamente sulla diapositiva o ereditato da un layout. La forma utilizza lo sfondo risolto della diapositiva; l'esempio lascia sia lo sfondo della diapositiva sia quello del layout non definiti così che il master lo fornisca.

## **Impostare la trasparenza**

Per un riempimento solido, il componente alfa del colore controlla l'opacità: 0 è completamente trasparente e 255 è completamente opaco. Questo esempio usa un valore alfa di 128 per un rettangolo giallo, rendendolo circa 50 % trasparente in modo che il rettangolo sottostante rimanga visibile. Il colore è assegnato tramite [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La forma trasparente](shape-transparency.png)

## **Ruotare le forme**

Usa [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) per ruotare una forma nel piano della diapositiva. L'angolo è misurato in gradi; questo esempio ruota un rettangolo di 5 gradi in senso orario e salva la presentazione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![La rotazione della forma](shape-rotation.png)

## **Aggiungere effetti di smussatura 3D**

Usa [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) per dare a una forma profondità e bordi smussati. Questo esempio crea un'ellisse verde con contorno arancione, imposta [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) a 4 punti e applica una smussatura superiore circolare con larghezza e altezza di 6 punti tramite [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Una telecamera ortografica frontale e un'illuminazione a tre punti rendono visibile lo smussamento.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'effetto di smussatura 3D](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

La vista 3D di una forma è controllata dalle impostazioni della telecamera. Questo esempio usa [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) con angoli di latitudine, longitudine e rivoluzione di 40, 35 e 20 gradi rispettivamente. Seleziona una telecamera isometrica tramite [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) e un'illuminazione bilanciata tramite [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), quindi salva il rettangolo formattato.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![L'effetto di rotazione 3D](3D-rotation-effect.png)

## **Controllare la resa in bianco e nero per le forme**

Il metodo [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) specifica come una singola forma viene resa quando una presentazione è visualizzata o elaborata in modalità bianco e nero. Non attiva di per sé la visualizzazione in bianco e nero e non modifica il riempimento, il contorno o altra formattazione della forma in modalità colore normale.

Usa un valore della classe [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) per selezionare il comportamento desiderato. Per esempio, `Automatic` lascia che l'applicazione di rendering scelga la conversione, `Gray` e `LightGray` usano la colorazione grigia, `BlackWhite` utilizza solo nero e bianco, `Black` e `White` forzano un singolo colore, `Color` preserva la colorazione normale, e `Hidden` omette la forma in modalità bianco e nero. `NotDefined` indica che non è stato assegnato alcun livello a livello di forma.

Questo esempio crea un rettangolo arancione e imposta [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) su grigio. La forma salvata mantiene il riempimento arancione per la visualizzazione a colore normale e richiede la colorazione grigia alle applicazioni che rispettano le impostazioni di visualizzazione in bianco e nero:

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
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In modalità colore normale, il rettangolo mantiene il riempimento arancione. In un flusso di lavoro di visualizzazione in bianco e nero, usa la colorazione grigia perché il suo modo è impostato su `Gray`. Questo consente di preservare una diapositiva a colori completi definendo un aspetto distinto per la stampa, l'anteprima o altri flussi di lavoro che rispettano le impostazioni di visualizzazione in bianco e nero della presentazione.

## **Ripristinare la formattazione**

Usa [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) per ripristinare posizione, dimensione e formattazione dei segnaposto della diapositiva dai loro corrispondenti segnaposto del layout. Questo esempio richiede una presentazione esistente con segnaposto collegati al layout e ripristina ogni diapositiva prima di salvare. Le forme senza segnaposto corrispondente nel layout non vengono ripristinate.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Colori, stili di linea e impostazioni degli effetti aggiungono generalmente pochi dati rispetto alle immagini e ai media incorporati. I riempimenti immagine possono aumentare la dimensione del file perché le loro immagini sono memorizzate nella presentazione.

**Come posso individuare le forme su una diapositiva che condividono la stessa formattazione per raggrupparle?**

Confronta le proprietà chiave di formattazione di ciascuna forma—riempimento, linea e impostazioni degli effetti. Se tutti i valori corrispondenti coincidono, considera i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forma personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva le forme di esempio con gli stili desiderati in una presentazione modello o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme con lo stile necessario e riapplica la loro formattazione dove richiesto.