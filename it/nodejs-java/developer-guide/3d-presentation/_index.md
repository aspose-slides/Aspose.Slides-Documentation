---
title: Crea effetti 3D nelle presentazioni usando Node.js
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in Node.js con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java può creare, modificare, conservare e renderizzare formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Note" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nel risultato 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa il metodo [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) per applicare la formattazione 3D a una forma. Il metodo restituisce [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa il metodo [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Punto di vista, tipo di telecamera predefinito, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a un preset di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Preset di luce, direzione e rotazione della luce. | Modifica come appaiono i riflessi e le ombre sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) e [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Materiale della superficie, come piatto, opaco, plastica o metallo. | Rendi la stessa geometria più piatta, più morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) e [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Colore dei lati estrusi. | Rendi visibile la profondità o coordina il colore dei lati con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) e [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regola finemente la profondità per forme o testo, soprattutto in combinazione con le impostazioni di smussatura e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Bordi rialzati o arrotondati sulle facce frontale e posteriore. | Aggiungi un bordo ammorbidito o modellato invece di una faccia piatta e netta. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) e [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Contorno intorno all'oggetto 3D. | Evidenzia il limite dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma solitamente necessita di quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della telecamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influisce su come la luce viene renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia anteriore e applica la formattazione 3D. I valori di rotazione della telecamera sono in gradi, e l'altezza dell'estrusione è 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG a doppia dimensione rispetto a quelle predefinite e salva la presentazione come PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco 3D spesso:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Ruota una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

In Aspose.Slides, accedi alla telecamera tramite [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi, rispettivamente. Configura la forma in memoria senza salvare un file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Usa la telecamera quando devi cambiare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma nella diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

### **Copia l'Orientamento della Telecamera da una Forma di Modello**

Per corrispondere all'orientamento di una forma modello, leggi il preset della telecamera con [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) e i suoi angoli di rotazione con [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). L'esempio apre `template.pptx` e copia l'orientamento della telecamera dalla prima forma della prima diapositiva alla seconda forma. Entrambe le forme hanno già illuminazione 3D, e la seconda forma non ha una rotazione esplicita della telecamera.

Gli angoli sono in gradi. L'indice `0` è latitudine, l'indice `1` è longitudine e l'indice `2` è rivoluzione. Passali a [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) in quest'ordine. Se la sorgente restituisce `null`, non ha una rotazione esplicita, quindi lascia gli angoli della seconda forma non impostati. Una rotazione esplicita di `(0, 0, 0)` restituisce tre zero e dovrebbe essere copiata.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quando riapri `camera-copy.pptx` in PowerPoint, la freccia a destra ha lo stesso preset di telecamera e la stessa rotazione del rettangolo a sinistra. Entrambe le forme usano la stessa illuminazione e profondità di estrusione.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Aggiungi Estrusione e Profondità**

L'estrusione fa apparire una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo di profondità imposta questa spessore visibile, e il controllo di colore imposta il colore delle facce laterali.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Usa [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) per impostare lo spessore e [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) per accedere al colore laterale. Questo esempio dà al rettangolo un'estrusione di 100 punti con lati viola e ruota la telecamera per rivelarne lo spessore. Configura la forma in memoria senza salvare un file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Il metodo [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) imposta la profondità di una forma 3D. Il metodo [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare la stessa telecamera, luce, materiale e impostazioni di estrusione.

Questo esempio applica un gradiente dal blu all'arancione alla faccia anteriore e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 indicano l'inizio e la fine del gradiente. I valori di rotazione della telecamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a doppia dimensione rispetto a quelle predefinite:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

L'output renderizzato mantiene il gradiente sulla faccia anteriore e renderizza l'estrusione separatamente:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della telecamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

L'immagine è renderizzata sulla faccia anteriore, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D di una forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti in stile WordArt dove le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni della telecamera.

L'esempio seguente crea testo con un motivo griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). L'altezza dell'estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti in modo che sia visibile solo il testo. L'esempio renderizza un'immagine PNG a doppia dimensione rispetto a quella predefinita della diapositiva e salva la presentazione come PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il testo è renderizzato come lettere 3D curve ed estruse:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Mantieni il Testo Piatto su una Forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D di una forma, chiama [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) tramite [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Quando il valore è `true`, il testo rimane fuori dalla scena 3D. Quando è `false`, il testo partecipa alla scena e segue la sua orientazione 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua telecamera, illuminazione, materiale ed estrusione rimangono configurati tramite [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). È anche diversa dalla rotazione ordinaria. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) ruota la forma nel piano della diapositiva, mentre [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) controlla la rotazione personalizzata del testo all'interno del suo riquadro. Mantenere il testo fuori dalla scena 3D non resetta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `false` a sinistra e `true` a destra. Gli angoli della telecamera sono in gradi e l'altezza dell'estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a doppia dimensione rispetto a quella predefinita.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

A sinistra, il testo segue l'orientamento 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli conservano la stessa estrusione visibile e orientamento 3D.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D è rasterizzata o disegnata nell'output come risultato 2D. Questo accade quando renderizzi le diapositive in [PNG](/slides/it/nodejs-java/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/), o generi fotogrammi per la [conversione video](/slides/it/nodejs-java/convert-powerpoint-to-video/).

Tieni presenti questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, riglio di luce, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effettive della forma](/slides/it/nodejs-java/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D di PowerPoint modificabile. In tali formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**  
Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportati scenari 3D interattivi che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**  
Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint normale, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**  
Al minimo, imposta una rotazione della telecamera e oppure un'estrusione o una profondità. In pratica, imposta anche un riglio di luce e un materiale affinché le facce renderizzate abbiano evidenti riflessi e ombre.

**Posso applicare effetti 3D sia alle forme che al testo?**  
Sì. Usa [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) per il corpo della forma e [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**  
Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori finali 3D dopo l'applicazione di ereditarietà e impostazioni del tema?**  
Sì. Usa le API di formattazione effettiva descritte nelle [proprietà effettive della forma](/slides/it/nodejs-java/shape-effective-properties/) per leggere la telecamera finale, il riglio di luce, lo smusso e i valori 3D correlati.