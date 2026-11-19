---
title: 3D‑Effekte in Präsentationen auf Android erstellen
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑Präsentation
- 3D‑Drehung
- 3D‑Tiefe
- 3D‑Extrusion
- 3D‑Verlauf
- 3D‑Text
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text auf Android mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für Android via Java kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er befasst sich nicht mit dem Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **Konzepte der 3D-Formatierung**

Verwenden Sie die Methode [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) , um einem Objekt 3D‑Formatierung anzuwenden. Die Methode gibt ein [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/) zurück, das die 3D‑Szene für dieses Objekt steuert.

Für Text verwenden Sie die Methode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Dies wendet die 3D‑Formatierung auf den Textrahmen statt auf den Objektkörper an.

Die wichtigsten API‑Elemente sind:

| API‑Element | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Ansichtspunkt, vordefinierter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie ein PowerPoint‑3D‑Drehungsvorgabe an. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvorgabe, Richtung und Lichtdrehung. | Ändern Sie, wie Lichtreflexe und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch erscheinen. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderfläche nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen die Seitenfarbe mit der Vordergrundfüllung ab. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Passen Sie die Tiefe für Formen oder Text genau an, insbesondere in Kombination mit Abschrägungen und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhobene oder abgerundete Kanten an Vorder- und Rückseite. | Fügen Sie eine abgeflachte oder geformte Kante hinzu anstelle einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) und [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) und [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Umriss um das 3D‑Objekt. | Hervorhebung der Objektgrenze in der gerenderten Ausgabe. |

## **Eine 3D‑Form erstellen**

Ein Objekt benötigt in der Regel vier Arten von Einstellungen, bevor es überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefeneinstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt dem Vordergrund Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit doppelter Standardgröße und speichert die Präsentation als PPTX.

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

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderfläche](img_01_01.png)

## **Eine Form mit der Kamera rotieren**

In PowerPoint wird die 3D‑Drehung über das Feld 3‑D‑Drehung konfiguriert. Die X-, Y- und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Feld 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

Greifen Sie in Aspose.Slides über [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Frontansicht und setzt die X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert das Objekt im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie des Objekts auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kameraposition von einer Vorlageform kopieren**

Um die Ausrichtung einer Vorlageform zu übernehmen, lesen Sie deren Kamera‑Vorgabe mit [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) und deren Rotationswinkel mit [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). Das Beispiel öffnet `template.pptx` und kopiert die Kameraposition von der ersten Form auf der ersten Folie zur zweiten Form. Beide Formen haben bereits 3D‑Beleuchtung, und die zweite Form hat keine explizite Kameradrehung.

Die Winkel sind in Grad angegeben. Index `0` ist Breitengrad, Index `1` ist Längengrad und Index `2` ist Drehung. Übergaben Sie sie in dieser Reihenfolge an [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-). Gibt die Quelle `null` zurück, hat sie keine explizite Drehung, sodass die Winkel der zweiten Form unverändert bleiben. Eine explizite Drehung von `(0, 0, 0)` liefert drei Nullen und sollte kopiert werden.

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

Wenn Sie `camera-copy.pptx` in PowerPoint erneut öffnen, hat der Pfeil rechts dieselbe Kamera‑Vorgabe und -Drehung wie das Rechteck links. Beide Formen verwenden dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein rechter Pfeil mit passender Kameraposition, von oben und rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt ein Objekt dick wirken, indem es hinter die Vorderfläche verlängert wird. In PowerPoint legt die Tiefen‑Steuerung diese sichtbare Dicke fest, und die Farb‑Steuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, zugeordnet zu Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften](img_02_02.png)

Verwenden Sie [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-), um die Dicke festzulegen, und [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) , um die Seitenfarbe abzurufen. Dieses Beispiel gibt einem Rechteck eine 100‑Punkt‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke sichtbar zu machen. Es konfiguriert das Objekt im Speicher, ohne eine Datei zu speichern:

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

Die Methode [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verlaufs‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

Die 3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Verlauf, ein Muster oder eine Bildfüllung auf die Vorderfläche anwenden und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Verlauf auf die Vorderfläche und eine dunkelorange Farbe auf die 150‑Punkt‑Extrusion an. Die Verlaufspunkte bei 0 und 100 markieren den Beginn und das Ende des Verlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild mit doppelter Standardgröße gerendert:

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

Die gerenderte Ausgabe behält den Verlauf auf der Vorderfläche bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Verlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel setzt eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis voraus. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkt‑Extrusion an und legt die Kameradrehung in Grad fest. Es konfiguriert das Objekt im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderfläche und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form betrifft den Formkörper. Die 3D‑Formatierung von Text betrifft den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weißen Rastermuster, wendet einen nach oben gerichteten Bogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtdrehung ist in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit doppelter Standardgröße und speichert die Präsentation als PPTX:

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

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbenem Musterausfüllung und dunkler Extrusion](img_02_05.png)

## **Text auf einer 3D‑Form flach halten**

Um den Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, rufen Sie [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) über [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) auf. Wenn der Wert `true` ist, bleibt der Text außerhalb der 3D‑Szene. Wenn er `false` ist, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) konfiguriert. Sie unterscheidet sich außerdem von herkömmlicher Drehung. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) dreht die Form in der Folienebene, während [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu einem PNG mit doppelter Standardgröße.

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

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander stehende 3D‑Rechtecke: Text folgt links der 3D‑Ausrichtung und bleibt rechts flach](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene gerastert oder in die Ausgabe als 2D‑Ergebnis gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/androidjava/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/androidjava/convert-powerpoint-to-html/) exportieren oder Frames für [Video-Konvertierung](/slides/de/androidjava/convert-powerpoint-to-video/) erzeugen.

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/androidjava/shape-effective-properties/).
- Einige Ausgabeformate können die bearbeitbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als bearbeitbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format sie unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder -Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens muss eine Kameradrehung und entweder Extrusion oder Tiefe gesetzt werden. In der Praxis sollten zudem ein Licht‑Rig und ein Material eingestellt werden, damit die gerenderten Flächen klare Lichtreflexe und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) für den Formkörper und [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) für Text.

**Werden 3D‑Effekte beim Export zu Bildern, PDF, HTML oder Video‑Frames sichtbar?**

Ja. Aspose.Slides rendert 3D‑Effekte beim Erzeugen von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames, die für die Videokonvertierung verwendet werden. Das exportierte Ergebnis enthält das gerenderte Aussehen, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Anwendung von Theme‑Einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [Formeffektive Eigenschaften](/slides/de/androidjava/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.