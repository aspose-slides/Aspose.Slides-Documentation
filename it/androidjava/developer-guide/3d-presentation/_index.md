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
description: "Applica e rendi gli effetti 3D per forme e testo PowerPoint su Android con Aspose.Slides. Configura fotocamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides for Android via Java può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre gli effetti 3D come rotazione, estrusione, smussature, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Nota" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non riguarda l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di formattazione 3D**

Usa il metodo [IShape.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) per applicare la formattazione 3D a una forma. Il metodo restituisce [IThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa il metodo [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Questo applica la formattazione 3D al riquadro del testo invece che al corpo della forma.

I membri API più importanti sono:

| Membro API | Che cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Punto di vista, tipo di fotocamera predefinito, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a un preset di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Predefinito di illuminazione, direzione e rotazione della luce. | Cambia come appaiono luci e ombre sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) e [setMaterial](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Materiale della superficie, come piatto, opaco, plastica o metallo. | Rendi la stessa geometria più piatta, morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) e [setExtrusionHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Colore dei lati estrusi. | Rendi visibile la profondità o coordina il colore laterale con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getDepth--) e [setDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Rifinisci la profondità per forme o testo, soprattutto insieme a impostazioni di smussatura e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) e [getBevelBottom](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Bordi rialzati o arrotondati sulle facce anteriore e posteriore. | Aggiungi un bordo smussato o modellato invece di una faccia piatta e tagliente. |
| [getContourColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) e [getContourWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) e [setContourWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Contorno intorno all'oggetto 3D. | Evidenzia il confine dell'oggetto nell'output renderizzato. |

## **Creare una forma 3D**

Una forma di solito necessita di quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della fotocamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni di illuminazione, perché la luce rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influisce sul modo in cui la luce viene resa.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia anteriore e applica la formattazione 3D. I valori di rotazione della fotocamera sono in gradi e l'altezza di estrusione è 100 punti. L'esempio rende la diapositiva in un'immagine PNG a doppia dimensione rispetto a quelle predefinite e salva la presentazione come PPTX.

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

## **Ruotare una forma con la fotocamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della fotocamera.

![Pannello Rotazione 3-D di PowerPoint con valori X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla fotocamera tramite [IThreeDFormat.getCamera](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi rispettivamente. Configura la forma in memoria senza salvare un file:

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

Usa la fotocamera quando devi cambiare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma nella diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungere estrusione e profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo di profondità imposta questo spessore visibile e il controllo di colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore estrusione e altezza estrusione](img_02_02.png)

Usa [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) per impostare lo spessore e [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) per accedere al colore laterale. Questo esempio dà a un rettangolo un'estrusione di 100 punti con lati viola e ruota la fotocamera per rivelarne lo spessore. Configura la forma in memoria senza salvare un file:

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

Il metodo [IThreeDFormat.setDepth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) imposta la profondità di una forma 3D. Il metodo [setExtrusionHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usare riempimenti a gradiente o immagine con effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, gradiente, motivo o riempimento immagine alla faccia anteriore e continuare a usare le stesse impostazioni di fotocamera, luce, materiale ed estrusione.

Questo esempio applica un gradiente dal blu all'arancione alla faccia anteriore e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 marcano l'inizio e la fine del gradiente. I valori di rotazione della fotocamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a doppia dimensione rispetto a quelle predefinite:

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

L'output renderizzato mantiene il gradiente sulla faccia anteriore e rende separatamente l'estrusione:

![Rettangolo 3D renderizzato con gradiente blu‑arancione e estrusione arancione](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della fotocamera in gradi. Configura la forma in memoria senza salvare né renderizzare un file:

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

L'immagine è renderizzata sulla faccia anteriore, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento fotografico sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applicare la formattazione 3D al testo**

La formattazione 3D delle forme influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro del testo. Questo è utile per effetti simili a WordArt in cui le lettere stesse hanno bisogno di estrusione, materiale, illuminazione e impostazioni della fotocamera.

L'esempio seguente crea testo con un motivo a griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). L'altezza di estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti così che solo il testo sia visibile. L'esempio rende un'immagine PNG a doppia dimensione della diapositiva predefinita e salva la presentazione come PPTX:

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

Il testo è renderizzato come lettere 3D curve ed estruse:

![Testo 3D renderizzato con trasformazione WordArt arcuata, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Mantenere il testo piatto su una forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D di una forma, chiama [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) tramite [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Quando il valore è `true`, il testo rimane fuori dalla scena 3D. Quando è `false`, il testo partecipa alla scena e segue la sua orientazione 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua fotocamera, illuminazione, materiale ed estrusione rimangono configurati tramite [IShape.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). È anche diversa dalla rotazione ordinaria. [IShape.setRotation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#setRotation-float-) ruota la forma nel piano della diapositiva, mentre [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) controlla la rotazione personalizzata del testo all'interno del suo riquadro. Mantenere il testo fuori dalla scena 3D non reimposta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `false` a sinistra e `true` a destra. Gli angoli della fotocamera sono in gradi e l'altezza di estrusione è 40 punti. L'esempio salva la presentazione come PPTX e rende la diapositiva di confronto in PNG a doppia dimensione rispetto a quelle predefinite.

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

A sinistra, il testo segue l'orientazione 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli mantengono la stessa estrusione visibile e orientazione 3D.

![Rettangoli 3D affiancati: il testo segue l'orientazione 3D a sinistra e resta piatto a destra](keep_text_flat.png)

## **Comportamento di esportazione e rendering**

Aspose.Slides conserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando renderizza o esporta in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando renderizzi diapositive in [PNG](/slides/it/androidjava/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), in [HTML](/slides/it/androidjava/convert-powerpoint-to-html/), o generi fotogrammi per [conversione video](/slides/it/androidjava/convert-powerpoint-to-video/).

Tieni presente questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di fotocamera, luce, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effective della forma](/slides/it/androidjava/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D modificabile di PowerPoint. In questi formati, il risultato visivo è renderizzato anziché preservato come impostazioni 3D editabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane editabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint normale, come rotazione, estrusione, smussatura, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Come minimo, imposta una rotazione della fotocamera e oppure estrusione o profondità. In pratica, imposta anche una luce e un materiale affinché le facce renderizzate abbiano evidenziazioni e ombre chiare.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [IShape.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) per il corpo della forma e [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) per il testo.

**Gli effetti 3D appariranno esportando in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D editabile.

**Posso leggere i valori finali 3D dopo l'applicazione di ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione effective descritte nelle [Proprietà effective della forma](/slides/it/androidjava/shape-effective-properties/) per leggere fotocamera, luce, smussatura e valori 3D correlati finali.