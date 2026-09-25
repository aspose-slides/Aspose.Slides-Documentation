---
title: 3D‑Effekte in Präsentationen mit Node.js erstellen
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑Präsentation
- 3D‑Drehung
- 3D‑Tiefe
- 3D‑Extrusion
- 3D‑Farbverlauf
- 3D‑Text
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in Node.js mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für Node.js über Java kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er behandelt nicht das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in das exportierte 2D‑Ergebnis.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Methode [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getThreeDFormat), um einer Form eine 3D‑Formatierung zuzuweisen. Die Methode gibt ein [ThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Damit wird die 3D‑Formatierung auf den Textrahmen und nicht auf den Formkörper angewendet.

Die wichtigsten API‑Mitglieder sind:

| API‑Mitglied | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getCamera) | Blickpunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie ein PowerPoint‑3D‑Drehungs‑Preset an. |
| [getLightRig](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getLightRig) | Licht‑Preset, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getMaterial) und [setMaterial](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#setMaterial) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch erscheinen. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) und [setExtrusionHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickeres 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vordergrundfüllung. |
| [getDepth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getDepth) und [setDepth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#setDepth) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feineinstellung der Tiefe für Formen oder Text, besonders zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getBevelTop) und [getBevelBottom](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Erhöhte oder abgerundete Kanten auf Vorder- und Rückseite. | Fügen Sie eine abgeflachte oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getContourWidth) und [setContourWidth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, da die Standard‑Frontalansicht die Extrusion verbergen kann.
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten erkennbar macht.
- Materialeinstellungen, da die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefeneinstellungen, da eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seinem Vordergrund Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit dem Doppelten der Standard‑Abmessungen und speichert die Präsentation als PPTX.

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

## **Drehen einer Form mit der Kamera**

In PowerPoint wird die 3D‑Drehung im Bereich 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑3‑D‑Drehungsbereich mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat.getCamera](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getCamera) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Frontalansicht und setzt die X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderseite verlängert wird. In PowerPoint legt die Tiefen‑Steuerung diese sichtbare Dicke fest, und die Farb‑Steuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefen‑Steuerelemente, zugeordnet zu Extrusion‑Farbe‑ und Extrusion‑Höhen‑Eigenschaften](img_02_02.png)

Verwenden Sie [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight), um die Dicke festzulegen, und [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#getExtrusionColor), um die Seitenfarbe zu erhalten. Dieses Beispiel verleiht einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Die Methode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#setDepth) setzt die Tiefe einer 3D‑Form. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) steuert die Höhe des Extrusions‑Effekts, wie in diesem Beispiel gezeigt.

## **Verwenden von Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine einfarbige Füllung, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Farbverlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Farbverlauf‑Stopps bei 0 und 100 markieren den Start bzw. das Ende des Farbverlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild mit dem Doppelten der Standard‑Abmessungen gerendert:

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

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und ordnen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

![Gerendertes 3D‑Rechteck mit einer Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung von Formen wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weißen Rastermuster, wendet einen Aufwärtsbogen an und konfiguriert 3D‑Einstellungen über [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtdrehung ist in Grad. Die Formfüllung und Kontur sind ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit dem Doppelten der Standard‑Folienabmessungen und speichert die Präsentation als PPTX:

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

![Gerenderter 3D‑Text mit einem bogenförmigen WordArt‑Transform, orangefarbener Mustelfüllung und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, rufen Sie [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) über [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) auf. Wenn der Wert `true` ist, bleibt der Text außerhalb der 3D‑Szene. Wenn er `false` ist, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: deren Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getThreeDFormat) konfiguriert. Sie unterscheidet sich auch von gewöhnlicher Drehung. [Shape.setRotation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#setRotation) dreht die Form in der Folienebene, während [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG mit dem Doppelten der Standard‑Abmessungen.

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

![Nebeneinander dargestellte 3D‑Rechtecke: Text folgt der 3D‑Ausrichtung links und bleibt rechts flach](keep_text_flat.png)

## **Export‑ und Render‑Verhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert oder als 2D‑Ergebnis in die Ausgabe gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/nodejs-java/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/) exportieren oder Frames für die [Video‑Konvertierung](/slides/de/nodejs-java/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Lichtsystem, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/nodejs-java/shape-effective-properties/).
- Einige Ausgabedateien können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, statt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung und entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie auch ein Lichtsystem und ein Material setzen, damit die gerenderten Flächen klare Highlights und Schatten haben.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getThreeDFormat) für den Formkörper und [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) für Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte bei der Erstellung von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung. Die exportierte Ausgabe enthält das gerenderte Aussehen, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [Shape Effective Properties](/slides/de/nodejs-java/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Lichtsystem‑, Abschrägungs‑ und zugehörigen 3D‑Werte zu lesen.