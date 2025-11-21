---
title: 3D-Präsentation
type: docs
weight: 232
url: /de/nodejs-java/3d-presentation/
---

## **Übersicht**

Seit Aspose.Slides für Java 20.9 ist es möglich, 3D in Präsentationen zu erzeugen. PowerPoint‑3D ist ein Weg, Präsentationen Leben zu verleihen. Zeigen Sie reale Objekte mit einer 3D‑Präsentation, demonstrieren Sie das 3D‑Modell Ihres zukünftigen Geschäftsprojekts, das 3D‑Modell eines Gebäudes oder dessen Innenraum, das 3D‑Modell eines Spielcharakters oder einfach eine 3D‑Darstellung Ihrer Daten.

PowerPoint‑3D‑Modelle können aus 2D‑Formen erstellt werden, indem solche Effekte darauf angewendet werden: 3D‑Drehung, 3D‑Tiefe und Extrusion, 3D‑Verlauf, 3D‑Text usw. Die Liste der auf Formen anwendbaren 3D‑Funktionen findet sich in der Klasse **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. Eine Instanz dieser Klasse erhalten Sie über:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getThreeDFormat--)** Methode zum Erzeugen eines PowerPoint‑3D‑Modells.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** Methode zum Erzeugen von 3D‑Text (WordArt).

Alle in **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)** implementierten Effekte können sowohl für Formen als auch für Text verwendet werden. Werfen wir einen kurzen Blick auf die wichtigsten Methoden der Klasse **[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat)**. Im nächsten Beispiel erstellen wir eine 2D‑Rechteckform mit Text darauf. Indem wir die Kameraperspektive auf die Form setzen, ändern wir ihre Drehung und lassen sie wie ein 3D‑Modell aussehen. Durch Festlegen eines flachen Lichts und dessen Richtung zur Oberseite des 3D‑Modells verleihen wir dem Modell mehr Volumen. Geänderte Materialien, Extrusionshöhe und Farbe lassen das 3D‑Modell lebendiger wirken.  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("sandbox_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Hier ist das resultierende 3D‑Modell:

![todo:image_alt_text](img_01_01.png)

## **3D‑Drehung**

Die Drehung eines 3D‑Modells in PowerPoint kann über das Menü erfolgen:

![todo:image_alt_text](img_02_01.png)

Um ein 3D‑Modell mit der Aspose.Slides‑API zu drehen, verwenden Sie die Methode **[ThreeDFormat.getCamera()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getCamera--)**, setzen die Drehung der Kamera relativ zur 3D‑Form:  
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... weitere 3D-Szenenparameter setzen
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


## **3D‑Tiefe und Extrusion**

Die Methoden **[ThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** und **[ThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** werden verwendet, um eine Extrusion auf einer Form zu erzeugen:  
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 128, 0, 128));
// ... weitere 3D‑Szenenparameter setzen
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


In PowerPoint wird die Tiefe einer Form über folgendes Menü eingestellt:

![todo:image_alt_text](img_02_02.png)

## **3D‑Verlauf**

Ein 3D‑Verlauf kann einer PowerPoint‑3D‑Form mehr Volumen verleihen:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


So sieht das aus:

![todo:image_alt_text](img_02_03.png)
  
Sie können auch einen Bildverlauf erstellen:  
```javascript
shape.getFillFormat().setFillType(java.newByte(java.newByteaspose.slides.FillType.Picture));
var picture;
var image = aspose.slides.Images.fromFile("image.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) {
        image.dispose();
    }
}
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
// .. Einrichtung von 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* Eigenschaften
try {
    var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
    slideImage.save("sample_3d.png", aspose.slides.ImageFormat.Png);
} finally {
    if (slideImage != null) {
        slideImage.dispose();
    }
}
```


Hier das Ergebnis:

![todo:image_alt_text](img_02_04.png)

## **3D‑Text (WordArt)**

Um 3D‑Text (WordArt) zu erstellen, gehen Sie wie folgt vor:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");
    var portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.newInstanceSync("java.awt.Color", 255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);
    var textFrame = shape.getTextFrame();
    // Einrichten des WordArt-Transformations-Effekts "Arch Up"
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
    try {
        var slideImage = pres.getSlides().get_Item(0).getImage(2, 2);
        slideImage.save("text3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    pres.save("text3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Hier das Ergebnis:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Werden 3D‑Effekte beim Exportieren einer Präsentation in Bilder/PDF/HTML beibehalten?**

Ja. Die Slides‑3D‑Engine rendert 3D‑Effekte beim Export in unterstützte Formate ([images](/slides/de/nodejs-java/convert-powerpoint-to-png/), [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/), usw.).

**Kann ich die „effektiven“ (finalen) 3D‑Parameterwerte abrufen, die Themen, Vererbung usw. berücksichtigen?**

Ja. Slides bietet APIs zum **[read effective values](/slides/de/nodejs-java/shape-effective-properties/)** (einschließlich für 3D — Beleuchtung, Abschrägungen usw.), sodass Sie die letztlich angewendeten Einstellungen sehen können.

**Funktionieren 3D‑Effekte beim Konvertieren einer Präsentation in ein Video?**

Ja. Beim **[generating frames for the video](/slides/de/nodejs-java/convert-powerpoint-to-video/)** werden 3D‑Effekte genauso gerendert wie bei **[exported images](/slides/de/nodejs-java/convert-powerpoint-to-png/)**.