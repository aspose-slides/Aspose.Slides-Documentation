---
title: Crea effetti 3D nelle presentazioni usando PHP
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/php-java/3d-presentation/
keywords:
- PowerPoint 3D
- Presentazione 3D
- Rotazione 3D
- Profondità 3D
- Estrusione 3D
- Gradiente 3D
- Testo 3D
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Applica e renderizza gli effetti 3D per forme e testo PowerPoint in PHP con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per PHP tramite Java può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="primary" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Utilizza la classe [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) e il suo metodo [Shape::getThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getThreeDFormat--) per applicare la formattazione 3D a una forma. Il metodo restituisce [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa la classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/) e il suo metodo [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

Le impostazioni più importanti sono:

| Metodo o impostazione | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getCamera--) | Punto di vista, tipo di telecamera preimpostato, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a una rotazione 3D preimpostata di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getLightRig--) | Preimpostazione luce, direzione e rotazione della luce. | Modifica come appaiono le luci e le ombre sulla superficie 3D. |
| [setMaterial](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Rende la stessa geometria più piatta, più morbida, lucida o metallica. |
| [setExtrusionHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Colore dei lati estrusi. | Rende visibile la profondità o coordina il colore laterale con il riempimento frontale. |
| [setDepth](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#setDepth-double-) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regola finemente la profondità per forme o testo, soprattutto insieme a impostazioni di smusso e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getBevelBottom--) | Bordi rialzati o arrotondati sulle facce frontali e posteriori. | Aggiunge un bordo smussato o modellato invece di una faccia piatta e netta. |
| [getContourColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getContourColor--) e [setContourWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Contorno intorno all'oggetto 3D. | Evidenzia i bordi dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma solitamente richiede quattro tipologie di impostazioni prima di apparire realisticamente 3D:

- Impostazioni della telecamera, poiché la vista frontale predefinita può nascondere l'estrusione.  
- Impostazioni della luce, poiché l'illuminazione rende le facce e i lati leggibili.  
- Impostazioni del materiale, poiché la superficie influisce sul modo in cui viene resa la luce.  
- Impostazioni di estrusione o profondità, poiché una forma piatta necessita di spessore.  

Il seguente esempio crea un rettangolo, aggiunge testo alla sua faccia anteriore, applica la formattazione 3D, salva la presentazione come PPTX e renderizza la diapositiva in un'immagine PNG.

```php
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

## **Ruota una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Pannello Rotazione 3-D di PowerPoint con i valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, imposta il tipo di telecamera e la rotazione tramite [ThreeDFormat::getCamera](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Usa la telecamera quando devi modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungi Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo della profondità imposta questo spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore dell'estrusione e altezza dell'estrusione](img_02_02.png)

Imposta [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) per lo spessore e [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getExtrusionColor--) per il colore laterale:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Usa [ThreeDFormat::setDepth](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#setDepth-double-) quando devi lavorare direttamente con il valore di profondità di PowerPoint o combinare la profondità con smusso, materiale ed effetti di testo. In molti scenari di forma, `setExtrusionHeight` è l'impostazione più chiara perché esprime direttamente l'estrusione visibile.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare le stesse impostazioni di telecamera, luce, materiale ed estrusione.

Questo esempio applica un riempimento gradiente alla forma e un colore di estrusione più scuro ai lati:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

![Rettangolo 3D renderizzato con riempimento gradiente dal blu all'arancione e estrusione arancione](img_02_03.png)

Per usare invece un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

![Rettangolo 3D renderizzato con riempimento foto sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt in cui le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni di telecamera.

Il seguente esempio crea testo con un riempimento a motivo, applica una trasformazione WordArt e configura le impostazioni 3D su [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando si renderizzano le diapositive in [PNG](/slides/it/php-java/convert-powerpoint-to-png/), si esporta in [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), si esporta in [HTML](/slides/it/php-java/convert-powerpoint-to-html/), o si generano fotogrammi per la [conversione video](/slides/it/php-java/convert-powerpoint-to-video/).

Tieni presente questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.  
- L'aspetto finale dipende dalla combinazione di telecamera, set di luci, materiale, estrusione, riempimento e ridimensionamento della diapositiva.  
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effettive della forma](/slides/it/php-java/shape-effective-properties/).  
- Alcuni formati di output non possono memorizzare la formattazione 3D editabile di PowerPoint. In tali formati, il risultato visivo è renderizzato invece di essere conservato come impostazioni 3D editabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportati scene 3D interattive che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato la supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint regolare, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della telecamera e oppure estrusione o profondità. In pratica, imposta anche un set di luci e materiale affinché le facce renderizzate abbiano evidenti luci e ombre.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape::getThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getThreeDFormat--) per il corpo della forma e [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#getThreeDFormat--) per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini di diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D editabile.

**Posso leggere i valori finali 3D dopo l'applicazione di ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione effettiva descritte in [Shape Effective Properties](/slides/it/php-java/shape-effective-properties/) per leggere la telecamera finale, il set di luci, lo smusso e i relativi valori 3D.