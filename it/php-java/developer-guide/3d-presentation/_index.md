---
title: "Crea effetti 3D nelle presentazioni usando PHP"
linktitle: "Presentazione 3D"
type: docs
weight: 232
url: /it/php-java/3d-presentation/
keywords:
- "PowerPoint 3D"
- "presentazione 3D"
- "rotazione 3D"
- "profondità 3D"
- "estrusione 3D"
- "gradiente 3D"
- "testo 3D"
- "PowerPoint"
- "presentazione"
- "PHP"
- "Aspose.Slides"
description: "Applica e renderizza effetti 3D per forme e testo di PowerPoint in PHP con Aspose.Slides. Configura fotocamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per PHP via Java può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta gli effetti 3D come rotazione, estrusione, smussature, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Note" %}}

Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non riguarda l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in immagine, PDF o HTML, Aspose.Slides renderizza quegli effetti 3D nell'output 2D esportato.

{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa il metodo [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) per applicare la formattazione 3D a una forma. Il metodo restituisce [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa il metodo [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Punto di vista, tipo di fotocamera preimpostato, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a una rotazione 3D preimpostata di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Illuminazione preimpostata, direzione e rotazione della luce. | Modificare l'aspetto di evidenziature e ombre sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) e [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) e [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Quanto la forma si estende all'indietro dalla sua faccia frontale. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) e [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regolare finemente la profondità per forme o testo, soprattutto con impostazioni di smussatura e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Bordi rialzati o arrotondati sulle facce frontali e posteriori. | Aggiungere un bordo smussato o modellato invece di una superficie piatta e netta. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) e [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) e [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Contorno intorno all'oggetto 3D. | Evidenziare il confine dell'oggetto nell'output renderizzato. |

## **Creare una Forma 3D**

Una forma di solito richiede quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della fotocamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende leggibili le facce e i lati.
- Impostazioni del materiale, perché la superficie influenza il modo in cui la luce viene renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia frontale e applica la formattazione 3D. I valori di rotazione della fotocamera sono espressi in gradi e l'altezza di estrusione è 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG a doppia dimensione rispetto a quella predefinita e salva la presentazione come PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco 3D spesso:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia anteriore](img_01_01.png)

## **Ruotare una Forma con la Fotocamera**

In PowerPoint, la rotazione 3D è configurata dal pannello 3-D Rotation. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della fotocamera.

![Pannello 3-D Rotation di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla fotocamera tramite [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi rispettivamente. Configura la forma in memoria senza salvare un file:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Usa la fotocamera quando devi modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma nella diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

### **Copiare l'Orientamento della Fotocamera da una Forma Modello**

Per corrispondere all'orientamento di una forma modello, leggi il suo preset di fotocamera con [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) e i suoi angoli di rotazione con [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). L'esempio apre `template.pptx` e copia l'orientamento della fotocamera dalla prima forma della prima diapositiva alla seconda forma. Entrambe le forme hanno già illuminazione 3D, e la seconda forma non ha una rotazione della fotocamera esplicita.

Gli angoli sono espressi in gradi. L'indice `0` è latitudine, l'indice `1` è longitudine e l'indice `2` è rivoluzione. Passali a [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) in quest'ordine. Se la sorgente restituisce `null`, non ha una rotazione esplicita, quindi lascia gli angoli della seconda forma non impostati. Una rotazione esplicita di `(0, 0, 0)` restituisce tre zeri e deve essere copiata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Quando riapri `camera-copy.pptx` in PowerPoint, la freccia a destra ha lo stesso preset di fotocamera e la stessa rotazione del rettangolo a sinistra. Entrambe le forme usano la stessa illuminazione e la stessa profondità di estrusione.

![Rettangolo 3D blu e freccia destra con orientamento della fotocamera corrispondente, vista dall'alto e da destra](camera-orientation.png)

## **Aggiungere Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia frontale. In PowerPoint, il controllo della profondità imposta questo spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà di colore ed altezza dell'estrusione](img_02_02.png)

Usa [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) per impostare lo spessore e [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) per accedere al colore laterale. Questo esempio assegna a un rettangolo un'estrusione di 100 punti con lati viola e ruota la fotocamera per mostrare lo spessore. Configura la forma in memoria senza salvare un file:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Il metodo [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) imposta la profondità di una forma 3D. Il metodo [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usare Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore pieno, un gradiente, un motivo o un riempimento immagine alla faccia frontale e continuare a usare le stesse impostazioni di fotocamera, luce, materiale ed estrusione.

Questo esempio applica un gradiente dal blu all'arancione alla faccia frontale e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 indicano l'inizio e la fine del gradiente. I valori di rotazione della fotocamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a doppia dimensione rispetto a quella predefinita:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

L'output renderizzato mantiene il gradiente sulla faccia frontale e renderizza separatamente l'estrusione:

![Rettangolo 3D renderizzato con riempimento a gradiente dal blu all'arancione ed estrusione arancione](img_02_03.png)

Per usare invece un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della fotocamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

L'immagine è renderizzata sulla faccia frontale, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento fotografico sulla faccia frontale ed estrusione arancione](img_02_04.png)

## **Applicare la Formattazione 3D al Testo**

La formattazione 3D delle forme influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt dove le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni della fotocamera.

L'esempio seguente crea testo con un motivo a griglia arancione e bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). L'altezza di estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento della forma e il contorno sono nascosti in modo che sia visibile solo il testo. L'esempio renderizza un'immagine PNG a doppia dimensione rispetto alla diapositiva predefinita e salva la presentazione come PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il testo è renderizzato come lettering 3D curvo ed estruso:

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Mantenere il Testo Piatti su una Forma 3D**

Per mantenere il testo leggibile conservando l'aspetto 3D della forma, chiama [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) tramite [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). Quando il valore è `true`, il testo rimane fuori dalla scena 3D. Quando è `false`, il testo partecipa alla scena e segue l'orientamento 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua fotocamera, illuminazione, materiale ed estrusione rimangono configurati tramite [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). È anche diversa dalla rotazione ordinaria. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) ruota la forma nel piano della diapositiva, mentre [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) controlla la rotazione personalizzata del testo all'interno del suo riquadro. Tenere il testo fuori dalla scena 3D non reimposta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo duplica accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; la sola differenza è l'impostazione del testo: `false` a sinistra e `true` a destra. Gli angoli della fotocamera sono in gradi e l'altezza di estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a doppia dimensione rispetto a quella predefinita.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

A sinistra, il testo segue l'orientamento 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli conservano la stessa estrusione visibile e orientamento 3D.

![Rettangoli 3D affiancati: il testo segue l'orientamento 3D a sinistra e rimane piatto a destra](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando si renderizza o esporta in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando renderizzi le diapositive in [PNG](/slides/it/php-java/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), in [HTML](/slides/it/php-java/convert-powerpoint-to-html/) o generi fotogrammi per la [conversione video](/slides/it/php-java/convert-powerpoint-to-video/).

Tieni presenti questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di fotocamera, illuminazione, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effective della forma](/slides/it/php-java/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D editabile di PowerPoint. In tali formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D editabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane editabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una normale forma o al testo di PowerPoint, come rotazione, estrusione, smussatura, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della fotocamera e una estrusione o profondità. In pratica, imposta anche un rig di luce e un materiale affinché le facce renderizzate mostrino evidenziature e ombre chiare.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) per il corpo della forma e [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D editabile.

**Posso leggere i valori 3D finali dopo l'applicazione di ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione effective descritte in [Proprietà Effective della Forma](/slides/it/php-java/shape-effective-properties/) per leggere fotocamera, rig di luce, smussatura e valori 3D correlati finali.