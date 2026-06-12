---
title: Crea effetti 3D nelle presentazioni su Android
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint su Android con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides for Android via Java può creare, modificare, preservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="primary" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa il metodo [IShape.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) per applicare la formattazione 3D a una forma. Il metodo restituisce [IThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa il metodo [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Questo applica la formattazione 3D al riquadro di testo anziché al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Punto di vista, tipo di telecamera preimpostata, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a una preimpostazione di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Preset di luce, direzione e rotazione della luce. | Cambiare il modo in cui le luci e le ombre appaiono sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) e [setMaterial](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, più morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) e [setExtrusionHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Quanto la forma si estende verso il retro dalla faccia anteriore. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getDepth--) e [setDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regolare finemente la profondità per forme o testo, soprattutto insieme a impostazioni di smusso e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bordi rialzati o arrotondati sulle facce frontale e posteriore. | Aggiungere un bordo smussato o modellato anziché una faccia piatta e affilata. |
| [getContourColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), e [setContourWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contorno attorno all'oggetto 3D. | Evidenziare il bordo dell'oggetto nell'output renderizzato. |

## **Creare una Forma 3D**

Una forma di solito richiede quattro tipologie di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della telecamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influenza il modo in cui la luce viene resa.
- Impostazioni di estrusione o profondità, perché una forma piatta necessita di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia anteriore, applica la formattazione 3D, salva la presentazione come PPTX e rende la diapositiva in un'immagine PNG.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

In PowerPoint, la rotazione 3D è configurata dal riquadro 3-D Rotation. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Riquadro 3-D Rotation di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, imposta il tipo di telecamera e la rotazione tramite [IThreeDFormat.getCamera](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Usa la telecamera quando devi modificare il modo in cui lo spettatore vede l'oggetto. Non cambia la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungere Estrusione e Profondità**

L'estrusione fa apparire una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo di profondità imposta tale spessore visibile, e il controllo di colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà di colore di estrusione e altezza di estrusione](img_02_02.png)

Imposta [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) per lo spessore e [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) per il colore laterale:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Usa [IThreeDFormat.setDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) quando devi lavorare direttamente con il valore di profondità di PowerPoint o combinare profondità con smusso, materiale ed effetti di testo. In molti scenari di forme, `setExtrusionHeight` è l'impostazione più chiara perché esprime direttamente l'estrusione visibile.

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

Per utilizzare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

L'immagine viene renderizzata sulla faccia anteriore, mentre l'estrusione è resa come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento fotografico sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applicare la Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti in stile WordArt dove le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni di telecamera.

L'esempio seguente crea testo con riempimento a motivo, applica una trasformazione WordArt e configura le impostazioni 3D su [ITextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

Il testo viene renderizzato come lettere 3D curve ed estruse:

![Testo 3D renderizzato con trasformazione WordArt arcuata, riempimento motivo arancione e estrusione scura](img_02_05.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides preserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando si esegue il rendering o l'esportazione verso formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando renderizzi le diapositive in [PNG](/slides/it/androidjava/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/androidjava/convert-powerpoint-to-html/), o generi fotogrammi per la [conversione video](/slides/it/androidjava/convert-powerpoint-to-video/).

Tieni presente questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, rig di luce, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi esaminare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effective della forma](/slides/it/androidjava/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D di PowerPoint modificabile. In questi formati, il risultato visivo è renderizzato anziché preservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non genera scene 3D interattive in immagini, PDF o pagine HTML che lo spettatore possa ruotare. In PPTX, la formattazione 3D resta modificabile in PowerPoint dove il formato la supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una normale forma o al testo di PowerPoint, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Come minimo, impostare una rotazione della telecamera e oppure estrusione o profondità. In pratica, impostare anche un rig di luce e un materiale affinché le facce renderizzate mostrino chiaramente evidenziature e ombre.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [IShape.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) per il corpo della forma e [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) per il testo.

**Gli effetti 3D appariranno quando esporti in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini di diapositive, output PDF, output HTML e fotogrammi utilizzati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori 3D finali dopo l'applicazione di eredità e impostazioni del tema?**

Sì. Usa le API di formattazione effective descritte nelle [Proprietà Effective della Forma](/slides/it/androidjava/shape-effective-properties/) per leggere la telecamera finale, il rig di luce, lo smusso e i relativi valori 3D.