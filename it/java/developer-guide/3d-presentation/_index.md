---
title: Crea effetti 3D nelle presentazioni usando Java
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in Java con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides for Java può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="primary" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando si esporta una diapositiva in immagine, PDF o HTML, Aspose.Slides renderizza quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/).`getThreeDFormat()` per applicare la formattazione 3D a una forma. L'oggetto di formato restituito controlla la scena 3D per quella forma.

Per il testo, usa [ITextFrameFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Questo applica la formattazione 3D al riquadro di testo anziché al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getCamera--) | Punto di vista, tipo di telecamera predefinita, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a un preset di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getLightRig--) | Preset di luce, direzione e rotazione della luce. | Modificare come appaiono le luci e le ombre sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getMaterial--) e [setMaterial](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) e [setExtrusionHeight](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getDepth--) e [setDepth](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Rifinire la profondità per forme o testo, soprattutto insieme a impostazioni di smusso e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bordi rialzati o arrotondati sulle facce anteriore e posteriore. | Aggiungere un bordo smussato o modellato invece di una faccia piatta e netta. |
| [getContourColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#getContourWidth--), e [setContourWidth](https://reference.aspose.com/slides/it/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contorno attorno all'oggetto 3D. | Evidenziare il bordo dell'oggetto nel rendering. |

## **Creare una Forma 3D**

Una forma di solito richiede quattro tipologie di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della telecamera, perché la visuale frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influisce sul modo in cui la luce viene resa.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia anteriore, applica la formattazione 3D, salva la presentazione come PPTX e renderizza la diapositiva in un'immagine PNG.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco 3D spesso:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia anteriore](img_01_01.png)

## **Ruotare una Forma con la Telecamera**

In PowerPoint, la rotazione 3D si configura dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Pannello Rotazione 3-D di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, imposta il tipo di telecamera e la rotazione attraverso il formato 3D restituito da `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Usa la telecamera quando devi modificare il modo in cui l'osservatore vede l'oggetto. Non cambia la geometria 2D della forma nella diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungere Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo di profondità imposta questo spessore visibile, e il controllo di colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore dell'estrusione e altezza dell'estrusione](img_02_02.png)

Imposta l'altezza dell'estrusione per lo spessore e il colore dell'estrusione per il colore laterale:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Usa l'impostazione di profondità quando devi lavorare direttamente con il valore di profondità di PowerPoint o combinare profondità con smusso, materiale ed effetti di testo. In molti scenari di forma, l'altezza dell'estrusione è l'impostazione più chiara perché esprime direttamente l'estrusione visibile.

## **Utilizzare Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare le stesse impostazioni di telecamera, luce, materiale ed estrusione.

Questo esempio applica un riempimento a gradiente alla forma e un colore di estrusione più scuro ai lati:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

L'output renderizzato mantiene il gradiente sulla faccia anteriore e renderizza l'estrusione separatamente:

![Rettangolo 3D renderizzato con riempimento gradiente dal blu all'arancione e estrusione arancione](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

L'immagine viene renderizzata sulla faccia anteriore, mentre l'estrusione viene renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applicare la Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt dove le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni di telecamera.

L'esempio seguente crea testo con riempimento a motivo, applica una trasformazione WordArt e configura le impostazioni 3D su [ITextFrameFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/):

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il testo è renderizzato come lettering 3D curvo ed estruso:

![Testo 3D renderizzato con trasformazione WordArt arcuata, riempimento motivo arancione e estrusione scura](img_02_05.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides preserva la formattazione 3D quando si salva nei formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando si renderizzano diapositive in [PNG](/slides/it/java/convert-powerpoint-to-png/), si esporta in [PDF](/slides/it/java/convert-powerpoint-to-pdf/), in [HTML](/slides/it/java/convert-powerpoint-to-html/), o si generano fotogrammi per [conversione video](/slides/it/java/convert-powerpoint-to-video/).

Tieni presente questi aspetti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, rig luce, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi esaminare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effettive della forma](/slides/it/java/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D modificabile di PowerPoint. In quei formati, il risultato visivo è renderizzato anziché preservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che lo spettatore possa ruotare. Nei file PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a del testo PowerPoint normale, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Come minimo, imposta una rotazione della telecamera e either estrusione o profondità. In pratica, imposta anche un rig luce e un materiale affinché le facce renderizzate abbiano evidenti luci e ombre.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/).`getThreeDFormat()` per il corpo della forma e [ITextFrameFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori 3D finali dopo l'applicazione di ereditarietà e impostazioni tema?**

Sì. Usa le API di formattazione effettiva descritte in [Proprietà Effettive della Forma](/slides/it/java/shape-effective-properties/) per leggere telecamera, rig luce, smusso e relativi valori 3D finali.