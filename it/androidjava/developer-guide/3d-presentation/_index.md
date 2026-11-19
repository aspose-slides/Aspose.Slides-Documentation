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
description: "Applica e renderizza effetti 3D per forme e testo di PowerPoint su Android con Aspose.Slides. Configura fotocamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per Android tramite Java può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Note" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa il metodo [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) per applicare la formattazione 3D a una forma. Il metodo restituisce [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa il metodo [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Questo applica la formattazione 3D al riquadro di testo anziché al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Punto di vista, tipo di fotocamera predefinito, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a un preset di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Preset di illuminazione, direzione e rotazione della luce. | Modifica il modo in cui i riflessi e le ombre appaiono sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) e [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiale della superficie, come piatto, opaco, plastica o metallo. | Rendi la stessa geometria più piatta, più morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) e [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Colore dei lati estrusi. | Rendi visibile la profondità o coordina il colore laterale con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) e [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regola finemente la profondità per forme o testo, specialmente insieme alle impostazioni di smussatura e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bordi rialzati o arrotondati sulle facce anteriore e posteriore. | Aggiungi un bordo smussato o modellato invece di una faccia piatta e affilata. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) e [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) e [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contorno intorno all'oggetto 3D. | Evidenzia il limite dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma solitamente necessita di quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della fotocamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impos​tazioni della luce, perché l'illuminazione rende visibili le facce e i lati.
- Impostazioni del materiale, perché la superficie influisce su come la luce viene renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

Il seguente esempio crea un rettangolo, aggiunge testo alla sua faccia anteriore e applica la formattazione 3D. I valori di rotazione della fotocamera sono in gradi, e l'altezza dell'estrusione è 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG a doppi le dimensioni predefinite e salva la presentazione come PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Ruota una Forma con la Fotocamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della fotocamera.

![Pannello Rotazione 3-D di PowerPoint con i valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla fotocamera tramite [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi, rispettivamente. Configura la forma in memoria senza salvare un file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Usa la fotocamera quando è necessario modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Modifica il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

### **Copia l'Orientamento della Fotocamera da una Forma Modello**

Per corrispondere all'orientamento di una forma modello, leggi il preset della sua fotocamera con [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) e le sue angolazioni di rotazione con [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). L'esempio apre `template.pptx` e copia l'orientamento della fotocamera dalla prima forma della prima diapositiva alla seconda forma. Entrambe le forme hanno già illuminazione 3D, e la seconda forma non ha rotazione esplicita della fotocamera.

Le angolazioni sono in gradi. L'indice `0` è latitudine, l'indice `1` è longitudine, e l'indice `2` è rivoluzione. Passali a [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) in quest'ordine. Se la sorgente restituisce `null`, non ha rotazione esplicita, quindi lascia le angolazioni della seconda forma non impostate. Una rotazione esplicita di `(0, 0, 0)` restituisce tre zeri e dovrebbe essere copiata.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quando riapri `camera-copy.pptx` in PowerPoint, la freccia a destra ha lo stesso preset di fotocamera e rotazione del rettangolo a sinistra. Entrambe le forme usano la stessa illuminazione e profondità di estrusione.

![Un rettangolo 3D blu e una freccia destra con orientamento della fotocamera corrispondente, visualizzati dall'alto e da destra](camera-orientation.png)

## **Aggiungi Estrusione e Profondità**

L'estrusione fa sembrare una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo della profondità imposta questa spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore dell'estrusione e altezza dell'estrusione](img_02_02.png)

Usa [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) per impostare lo spessore e [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) per accedere al colore laterale. Questo esempio dà al rettangolo un'estrusione di 100 punti con lati viola e ruota la fotocamera per rivelarne lo spessore. Configura la forma in memoria senza salvare un file:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Il metodo [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) imposta la profondità di una forma 3D. Il metodo [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare la stessa fotocamera, luce, materiale e impostazioni di estrusione.

Questo esempio applica un gradiente blu‑arancione alla faccia anteriore e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 indicano l'inizio e la fine del gradiente. I valori di rotazione della fotocamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a doppi le dimensioni predefinite:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int extrusionColor = Color.rgb(255, 140, 0);
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

L'output renderizzato mantiene il gradiente sulla faccia anteriore e renderizza separatamente l'estrusione:

![Rettangolo 3D renderizzato con riempimento a gradiente blu‑arancione e estrusione arancione](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della fotocamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Rettangolo 3D renderizzato con riempimento fotografico sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D della forma influenza il corpo della forma. La formattazione 3D del testo influenza il riquadro di testo. Questo è utile per effetti simili a WordArt dove le lettere stesse hanno bisogno di estrusione, materiale, illuminazione e impostazioni della fotocamera.

Il seguente esempio crea testo con un motivo griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). L'altezza e la profondità dell'estrusione sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti così da rendere visibile solo il testo. L'esempio renderizza un'immagine PNG a doppia dimensione della diapositiva predefinita e salva la presentazione come PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Mantieni il Testo Piatti su una Forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D della forma, chiama [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) tramite [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Quando il valore è `true`, il testo rimane fuori dalla scena 3D. Quando è `false`, il testo partecipa alla scena e segue l'orientamento 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua fotocamera, illuminazione, materiale e estrusione rimangono configurati tramite [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). È anche diversa dalla rotazione ordinaria. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) ruota la forma nel piano della diapositiva, mentre [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) controlla la rotazione personalizzata del testo all'interno della sua area. Mantenere il testo fuori dalla scena 3D non resetta nessuno di questi angoli.

Il seguente esempio autonomo crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `false` a sinistra e `true` a destra. Gli angoli della fotocamera sono in gradi, e l'altezza dell'estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a doppi le dimensioni predefinite.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

A sinistra, il testo segue l'orientamento 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli mantengono la stessa estrusione visibile e l'orientamento 3D.

![Rettangoli 3D affiancati: il testo segue l'orientamento 3D a sinistra e rimane piatto a destra](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando renderizzi le diapositive in [PNG](/slides/it/androidjava/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/androidjava/convert-powerpoint-to-html/), o generi fotogrammi per la [conversione video](/slides/it/androidjava/convert-powerpoint-to-video/).

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di fotocamera, illuminazione, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effettive della forma](/slides/it/androidjava/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D editabile di PowerPoint. In quei formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D editabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint normale, come rotazione, estrusione, smussatura, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Come minimo, imposta una rotazione della fotocamera e una estrusione o profondità. In pratica, imposta anche un'illuminazione e un materiale affinché le facce renderizzate abbiano riflessi e ombre evidenti.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) per il corpo della forma e [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) per il testo.

**Gli effetti 3D compariranno esportando in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D durante la produzione di immagini delle diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori 3D finali dopo l'applicazione dell'ereditarietà e delle impostazioni del tema?**

Sì. Usa le API di formattazione effettiva descritte nelle [proprietà effettive della forma](/slides/it/androidjava/shape-effective-properties/) per leggere i valori finali di fotocamera, illuminazione, smussatura e relativi valori 3D.