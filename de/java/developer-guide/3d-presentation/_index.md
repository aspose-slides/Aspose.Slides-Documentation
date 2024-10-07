---
title: 3D Präsentation
type: docs
weight: 232
url: /java/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D Präsentation
- 3D Rotation
- 3D Tiefe
- 3D Extrusion
- 3D Verlauf
- 3D Text
- PowerPoint Präsentation
- Java
- Aspose.Slides für Java
description: "3D PowerPoint Präsentation in Java"
---

## Übersicht
Seit Aspose.Slides Java 20.9 ist es möglich, 3D in Präsentationen zu erstellen. PowerPoint 3D ist eine Möglichkeit, Präsentationen Leben einzuhauchen. Zeigen Sie die Objekte der realen Welt mit 3D-Präsentationen, demonstrieren Sie ein 3D-Modell Ihres zukünftigen Geschäftsprojekts, ein 3D-Modell des Gebäudes oder seines Innenraums, ein 3D-Modell des Spielcharakters oder einfach eine 3D-Darstellung Ihrer Daten.

PowerPoint 3D-Modelle können aus 2D-Formen erstellt werden, indem folgende Effekte auf sie angewendet werden: 3D-Rotation, 3D-Tiefe und -Extrusion, 3D-Verlauf, 3D-Text usw. Die Liste der auf die Formen angewendeten 3D-Funktionen finden Sie in der **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**-Klasse. Die Instanz der Klasse kann durch folgende Methoden erhalten werden:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getThreeDFormat--)** Methode zum Erstellen eines PowerPoint 3D Modells.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** Methode zum Erstellen eines 3D-Texts (WordArt).

Alle Effekte, die in **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)** implementiert sind, können sowohl für Formen als auch für Texte verwendet werden. Lassen Sie uns einen kurzen Blick auf die Hauptmethoden der **[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**-Klasse werfen. Im nächsten Beispiel erstellen wir eine rechteckige 2D-Form mit einem Text darauf. Indem wir die Kameraperspektive auf die Form erhalten, ändern wir ihre Rotation und lassen sie wie ein 3D-Modell aussehen. Das Einstellen eines flachen Lichts und dessen Richtung nach oben auf das 3D-Modell verleiht dem Modell mehr Volumen. Geänderte Materialien, Extrusionshöhe und Farbe lassen das 3D-Modell lebendiger erscheinen.
```java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("sandbox_3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Hier ist das resultierende 3D-Modell:

![todo:image_alt_text](img_01_01.png)

## 3D Rotation
Die Rotation des 3D-Modells in PowerPoint kann über das Menü durchgeführt werden:

![todo:image_alt_text](img_02_01.png)

Um das 3D-Modell mit der Aspose.Slides-API zu rotieren, verwenden Sie die **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getCamera--)**-Methode, und setzen Sie die Rotation der Kamera relativ zur 3D-Form:

```java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... andere 3D-Szenenparameter setzen

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## 3D Tiefe und Extrusion
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** 
und **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionColor--)**-Methoden werden verwendet, um die Extrusion auf die Form zu erstellen:

```java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... andere 3D-Szenenparameter setzen

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

In PowerPoint wird die Tiefe der Form über folgendes eingestellt:

![todo:image_alt_text](img_02_02.png)

## 3D Verlauf
Ein 3D-Verlauf kann PowerPoint 3D-Formen mehr Volumen verleihen:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getFillFormat().setFillType(FillType.Gradient);
shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.dispose();
```

So sieht es aus:

![todo:image_alt_text](img_02_03.png)

Sie können auch einen Bildverlauf erstellen:
```java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... 3D-Eigenschaften: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* setzen

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

Hier ist das Ergebnis:

![todo:image_alt_text](img_02_04.png)

## 3D Text (WordArt)
Um einen 3D-Text (WordArt) zu erstellen, führen Sie Folgendes durch:
```java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getFillFormat().setFillType(FillType.NoFill);
shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
shape.getTextFrame().setText("3D Text");

Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
// setzen Sie den "Bogen nach oben" WordArt-Transformationseffekt
textFrameFormat.setTransform(TextShapeType.ArchUp);

textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
textFrameFormat.getThreeDFormat().setDepth(3);
textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("text3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("text3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Hier ist das Ergebnis:

![todo:image_alt_text](img_02_05.png)

## Nicht unterstützt - Kommt bald
Die folgenden PowerPoint 3D-Funktionen werden noch nicht unterstützt:
- Fase
- Material
- Kontur
- Beleuchtung