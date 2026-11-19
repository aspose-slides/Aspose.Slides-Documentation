---
title: 3D‑Effekte in Präsentationen mit Java erstellen
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in Java mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides for Java kann PowerPoint‑ähnliche 3D‑Formatierungen für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen sowie 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modell‑Dateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in das exportierte 2D‑Ergebnis.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Methode [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) , um einer Form 3D‑Formatierung zuzuweisen. Die Methode gibt ein [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Damit wird die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper angewendet.

Die wichtigsten API‑Mitglieder sind:

| API‑Element | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie eine PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvoreinstellung, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) und [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) und [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderfläche nach hinten reicht. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen Sie die Seitenfarbe mit der Vordergrundfüllung ab. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) und [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere in Kombination mit Abschrägung‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) und [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Erhöhte oder abgerundete Kanten an Vorder‑ und Rückseiten. | Fügen Sie eine abgeflachte oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) und [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) und [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Vorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht dargestellt wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seiner Vorderseite Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild in der doppelten Standardgröße und speichert die Präsentation als PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Eine Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung im Fenster *3‑D‑Drehung* konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑3‑D‑Drehungsfenster mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie, sondern den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kameraorientierung von einer Vorlageform kopieren**

Um die Orientierung einer Vorlageform zu übernehmen, lesen Sie ihre Kameravoreinstellung mit [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) und ihre Drehwinkel mit [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Das Beispiel öffnet `template.pptx` und kopiert die Kameraausrichtung vom ersten Shape der ersten Folie auf das zweite Shape. Beide Shapes besitzen bereits 3D‑Beleuchtung, und das zweite Shape hat keine explizite Kameradrehung.

Die Winkel sind in Grad angegeben. Index 0 ist Breitengrad, Index 1 Längengrad, Index 2 Revolutionswinkel. Übergeben Sie sie in dieser Reihenfolge an [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-). Gibt die Quelle `null` zurück, hat sie keine explizite Drehung, sodass die Winkel des zweiten Shapes unverändert bleiben. Eine explizite Drehung von `(0, 0, 0)` liefert drei Nullen und sollte kopiert werden.

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

Wenn Sie `camera-copy.pptx` in PowerPoint erneut öffnen, hat der rechte Pfeil dieselbe Kameravoreinstellung und -drehung wie das linke Rechteck. Beide Shapes nutzen dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein rechter Pfeil mit übereinstimmender Kameraorientierung, von oben und rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderfläche verlängert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, abgebildet auf die Eigenschaften Extrusionsfarbe und Extrusionshöhe](img_02_02.png)

Verwenden Sie [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-), um die Dicke festzulegen, und [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) , um die Seitenfarbe zu erhalten. Dieses Beispiel gibt einem Rechteck eine Extrusion von 100 Punkten mit violetten Seiten und rotiert die Kamera, um die Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

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

Die Methode [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) steuert die Höhe des Extrusionseffekts, wie im Beispiel gezeigt.

## **Verlauf‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können die Vorderseite mit einer Vollfarbe, einem Verlauf, einem Muster oder einer Bildfüllung versehen und dennoch dieselbe Kamera, Beleuchtung, Material und Extrusionseinstellungen nutzen.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Verlauf auf die Vorderseite an und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion. Die Verlaufsstopps bei 0 % bzw. 100 % markieren Anfang und Ende des Verlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild in doppelter Standardgröße gerendert:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

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

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Verlauffüllung und oranger Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel setzt voraus, dass im Arbeitsverzeichnis eine Datei namens „image.jpg“ existiert. Es streckt das Bild, um das Rechteck auszufüllen, wendet eine Extrusion von 150 Punkten an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne zu speichern oder zu rendern:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
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

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und oranger Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt sich auf den Formkörper aus. Die 3D‑Formatierung von Text wirkt sich auf den Textrahmen aus. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kamera benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weiß‑geprüften Rastermuster, wendet einen nach oben gerichteten Bogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, die Lichtdrehung in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild bei doppelter Foliengröße und speichert die Präsentation als PPTX:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangem Mustern und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form beizubehalten, rufen Sie [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) über [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) auf. Wenn der Wert `true` ist, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt deren 3D‑Orientierung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: deren Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) konfiguriert. Sie unterscheidet sich zudem von einer gewöhnlichen Drehung. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) dreht die Form in der Folienebene, während [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Ausblenden des Textes aus der 3D‑Szene setzt keine dieser Drehungen zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Shapes besitzen dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG bei doppelter Standardgröße.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
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

![Nebeneinanderstehende 3D‑Rechtecke: Text folgt der 3D‑Orientierung links und bleibt flach rechts](keep_text_flat.png)

## **Export‑ und Renderverhalten**

Aspose.Slides behält 3D‑Formatierungen beim Speichern in PowerPoint‑Formaten wie PPTX bei. Beim Rendern oder Exportieren in fest‑layout‑Formate wird die 3D‑Szene rasterisiert bzw. in das Ergebnis als 2D‑Darstellung eingebettet. Das gilt, wenn Sie Folien zu [PNG](/slides/de/java/convert-powerpoint-to-png/), zu [PDF](/slides/de/java/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/java/convert-powerpoint-to-html/) rendern oder Frames für die [Video‑Konvertierung](/slides/de/java/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Light‑Rig, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie die vererbten oder themenbasierten Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/java/shape-effective-properties/).
- Einige Ausgabformate können keine editierbaren PowerPoint‑3D‑Formatierungen speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**  
Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**  
Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder auf Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**  
Mindestens muss eine Kameradrehung sowie entweder Extrusion oder Tiefe gesetzt werden. In der Praxis sollten zudem ein Light‑Rig und Material eingestellt werden, damit die gerenderten Flächen klare Highlights und Schatten besitzen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**  
Ja. Verwenden Sie [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) für den Formkörper und [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) für Text.

**Werden 3D‑Effekte beim Exportieren in Bilder, PDF, HTML oder Video‑Frames angezeigt?**  
Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgabe, HTML‑Ausgabe oder Frames für die Video‑Konvertierung erzeugt werden. Das exportierte Ergebnis enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Themen‑Einstellungen auslesen?**  
Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in den [effektiven Formeigenschaften](/slides/de/java/shape-effective-properties/) beschrieben sind, um die finalen Kamera‑, Light‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.