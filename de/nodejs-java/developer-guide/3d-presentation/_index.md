---
title: 3D Effekte in Präsentationen mit Node.js erstellen
linktitle: 3D Präsentation
type: docs
weight: 232
url: /de/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D Präsentation
- 3D Drehung
- 3D Tiefe
- 3D Extrusion
- 3D Verlauf
- 3D Text
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint-Formen und -Text in Node.js mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D-Text."
---
## **Übersicht**

Aspose.Slides für Node.js über Java kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er handelt nicht vom Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Methode [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat), um einer Form eine 3D‑Formatierung zuzuweisen. Die Methode gibt ein [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Dadurch wird die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper angewendet.

Die wichtigsten API‑Member sind:

| API‑Member | Was es steuert | Wann zu verwenden |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie einen PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Lichtvoreinstellung, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) und [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallischer wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) und [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderfüllung. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) und [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Zusätzliche 3D‑Tiefe, die von der PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, besonders zusammen mit Abschrägung‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) und [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Erhöhte oder abgerundete Kanten an Vorder- und Rückseiten. | Fügen Sie eine abgeflachte oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) und [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Eine 3D‑Form erstellen**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontalansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefeneinstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seinem Vordergrund Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehungswerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit dem Doppelten ihrer Standardgröße und speichert die Präsentation als PPTX.

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

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Eine Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung über das Bedienfeld 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Bedienfeld 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Frontansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Betrachtungspunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kameraausrichtung von einer Vorlage‑Form kopieren**

Um die Ausrichtung einer Vorlagen‑Form zu übernehmen, lesen Sie deren Kameravoreinstellung mit [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) und die Drehwinkel mit [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). Das Beispiel öffnet `template.pptx` und kopiert die Kameraausrichtung von der ersten Form auf der ersten Folie zur zweiten Form. Beide Formen besitzen bereits 3D‑Beleuchtung, und die zweite Form hat keine explizite Kameradrehung.

Die Winkel sind in Grad angegeben. Index `0` ist die Breite, Index `1` die Länge und Index `2` die Drehung. Übergeben Sie sie in dieser Reihenfolge an [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation). Gibt die Quelle `null` zurück, hat sie keine explizite Drehung, sodass die Winkel der zweiten Form unbelegt bleiben. Eine explizite Drehung von `(0, 0, 0)` gibt drei Nullen zurück und sollte kopiert werden.

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

Wenn Sie `camera-copy.pptx` in PowerPoint erneut öffnen, hat der Pfeil rechts dieselbe Kameravoreinstellung und Drehung wie das Rechteck links. Beide Formen verwenden dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein nach rechts zeigender Pfeil mit passender Kameraausrichtung, von oben und rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderseite ausgedehnt wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbansteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, zugeordnet zu Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften](img_02_02.png)

Verwenden Sie [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight), um die Dicke festzulegen, und [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor), um die Seitenfarbe zu erhalten. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um seine Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Die Methode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verlauf‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können die Vorderfläche mit einer Vollfarbe, einem Verlauf, einem Muster oder einer Bildfüllung versehen und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusionseinstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Verlauf auf die Vorderfläche und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Verlaufspunkte bei 0 und 100 markieren den Start bzw. das Ende des Verlaufs. Die Kameradrehungswerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild mit dem Doppelten ihrer Standardgröße gerendert:

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

![Gerendertes 3D‑Rechteck mit blau‑zu‑orangefarbenem Verlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung von Formen betrifft den Formkörper. Die 3D‑Formatierung von Text betrifft den Textrahmen. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weiß‑gitterförmigen Muster, wendet einen nach oben geschwungenen Bogen an und konfiguriert 3D‑Einstellungen über [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtdrehung ist in Grad. Die Formfüllung und der Umriss werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit dem Doppelten der Standardfoliengröße und speichert die Präsentation als PPTX:

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

![Gerenderter 3D‑Text mit einem nach oben geschwungenen WordArt‑Transform, orangefarbiger Mustersfüllung und dunkler Extrusion](img_02_05.png)

## **Text auf einer 3D‑Form flach halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form beizubehalten, rufen Sie [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) über [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) auf. Ist der Wert `true`, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) konfiguriert. Sie unterscheidet sich außerdem von einer üblichen Drehung. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) dreht die Form in der Folienebene, während [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und klont es neben das Original. Beide Formen besitzen dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu einem PNG mit dem Doppelten ihrer Standardgröße.

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

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander angezeigte 3D‑Rechtecke: Text folgt der 3D‑Ausrichtung links und bleibt rechts flach](keep_text_flat.png)

## **Export‑ und Renderverhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in Festlayout‑Formate wird die 3D‑Szene gerastert oder als 2D‑Ergebnis in die Ausgabe eingefügt. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/nodejs-java/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/) exportieren oder Frames für die [Video‑Konvertierung](/slides/de/nodejs-java/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export vom Betrachter nicht gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Beleuchtung, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/nodejs-java/shape-effective-properties/).
- Einige Ausgabeformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, statt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es erzeugt keine interaktiven 3D‑Szenen in exportierten Bildern, PDFs oder HTML‑Seiten, die ein Betrachter drehen könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder einen Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens muss eine Kameradrehung sowie entweder Extrusion oder Tiefe festgelegt werden. In der Praxis sollten außerdem ein Lichtsystem und Material eingestellt werden, damit die gerenderten Flächen klare Hervorhebungen und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) für den Formkörper und [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) für Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Videoframes angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte beim Erzeugen von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames, die für die Videokonvertierung verwendet werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Anwendung von Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [effektiven Formeigenschaften](/slides/de/nodejs-java/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Licht‑, Abschrägungs‑ und verwandten 3D‑Werte auszulesen.