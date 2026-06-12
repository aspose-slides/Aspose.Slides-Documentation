---
title: Crea effetti 3D nelle presentazioni usando Node.js
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/nodejs-java/3d-presentation/
keywords:
- PowerPoint 3D
- presentazione 3D
- rotazione 3D
- profondità 3D
- estrusione 3D
- gradiente 3D
- testo 3D
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in Node.js con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per Node.js via Java può creare, modificare, conservare e renderizzare formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre effetti 3D come rotazione, estrusione, smussature, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="primary" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` per applicare la formattazione 3D a una forma. L'oggetto [ThreeDFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/) restituito controlla la scena 3D per quella forma.

Per il testo, usa [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getCamera) | Punto di vista, tipo di telecamera predefinito, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a un preset di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getLightRig) | Preset di luce, direzione e rotazione della luce. | Modifica l'aspetto di luci e ombre sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getMaterial) e [setMaterial](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#setMaterial) | Materiale della superficie, come piatto, opaco, plastica o metallo. | Rendi la stessa geometria più piatta, soffice, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) e [setExtrusionHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Quanto la forma si estende verso dietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Colore dei lati estrusi. | Rendi la profondità visibile o coordina il colore laterale con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getDepth) e [setDepth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#setDepth) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regola finemente la profondità per forme o testo, soprattutto insieme a smussature e impostazioni di materiale. |
| [getBevelTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Bordi rialzati o arrotondati sulle facce anteriore e posteriore. | Aggiungi un bordo smussato o modellato invece di una faccia piatta e netta. |
| [getContourColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#getContourWidth) e [setContourWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Contorno intorno all'oggetto 3D. | Evidenzia il bordo dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma di solito richiede quattro tipi di impostazioni prima di apparire convincente in 3D:

- Impostazioni della telecamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influisce su come la luce viene renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta necessita di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia anteriore, applica la formattazione 3D, salva la presentazione come PPTX e renderizza la diapositiva in un'immagine PNG.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia anteriore](img_01_01.png)

## **Ruota una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal riquadro Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Riquadro Rotazione 3-D di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, imposta il tipo di telecamera e la rotazione tramite il formato 3D restituito da `shape.getThreeDFormat()`:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Usa la telecamera quando devi modificare il punto di vista dell'osservatore sull'oggetto. Non cambia la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungi Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo di profondità imposta questo spessore visibile, e il controllo di colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint collegati alle proprietà colore estrusione e altezza estrusione](img_02_02.png)

Imposta l'altezza di estrusione per lo spessore e il colore di estrusione per il colore laterale:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Usa l'impostazione di profondità quando devi lavorare direttamente con il valore di profondità di PowerPoint o combinare profondità con smussature, materiale ed effetti di testo. In molti scenari di forme, l'altezza di estrusione è l'impostazione più chiara perché esprime direttamente l'estrusione visibile.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare le stesse impostazioni di telecamera, luce, materiale ed estrusione.

Questo esempio applica un riempimento a gradiente alla forma e un colore di estrusione più scuro ai lati:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

L'output renderizzato mantiene il gradiente sulla faccia anteriore e rende l'estrusione separatamente:

![Rettangolo 3D renderizzato con riempimento gradiente dal blu all'arancione e estrusione arancione](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

L'immagine viene renderizzata sulla faccia anteriore, mentre l'estrusione viene renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con un riempimento foto sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D di una forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti in stile WordArt dove le singole lettere hanno bisogno di estrusione, materiale, illuminazione e impostazioni della telecamera.

L'esempio seguente crea testo con riempimento a motivo, applica una trasformazione WordArt e configura le impostazioni 3D su [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/):

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento motivo arancione e estrusione scura](img_02_05.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva in formati PowerPoint come PPTX. Quando renderizza o esporta in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Ciò vale quando renderizzi le diapositive in [PNG](/slides/it/nodejs-java/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/), o generi fotogrammi per [conversione video](/slides/it/nodejs-java/convert-powerpoint-to-video/).

Tieni presenti questi punti:

- Le immagini ed i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, rig luce, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effective della forma](/slides/it/nodejs-java/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D modificabile di PowerPoint. In quei formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scenari 3D interattivi che lo spettatore può ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato la supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una normale forma o testo di PowerPoint, come rotazione, estrusione, smussatura, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Come minimo, imposta una rotazione della telecamera e oppure estrusione o profondità. Nella pratica, imposta anche un rig luce e un materiale affinché le facce renderizzate mostrino chiaramente evidenziature e ombre.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` per il corpo della forma e [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini diapositiva, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori 3D finali dopo l'applicazione di ereditarietà e impostazioni di tema?**

Sì. Usa le API di formattazione effective descritte in [Shape Effective Properties](/slides/it/nodejs-java/shape-effective-properties/) per leggere telecamera, rig luce, smussatura e valori 3D correlati finali.