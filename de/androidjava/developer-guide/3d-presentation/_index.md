---
title: 3D-Präsentation
type: docs
weight: 232
url: /de/androidjava/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D-Präsentation
- 3D-Rotation
- 3D-Tiefe
- 3D-Extrusion
- 3D-Verlauf
- 3D-Text
- PowerPoint-Präsentation
- Android
- Aspose.Slides für Android über Java
description: "3D PowerPoint-Präsentation in Android"
---

## Übersicht
Seit Aspose.Slides Java 20.9 ist es möglich, 3D in Präsentationen zu erstellen. PowerPoint 3D ist eine Möglichkeit, Präsentationen Leben einzuhauchen. Zeigen Sie die realen Objekte der Welt 
mit 3D-Präsentationen, demonstrieren Sie 3D-Modelle Ihres zukünftigen Geschäftsprojekts, 3D-Modelle des Gebäudes oder seines Innenraums, 3D-Modelle der Spielfigur, 
oder einfach eine 3D-Darstellung Ihrer Daten.

PowerPoint 3D-Modelle können aus 2D-Formen erstellt werden, indem folgende Effekte auf sie angewendet werden: 3D-Rotation, 3D-Tiefe und -Extrusion, 3D-Verlauf, 3D-Text usw. 
Die Liste der auf die Formen angewandten 3D-Funktionen finden Sie in der **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**-Klasse.
Die Instanz der Klasse kann erhalten werden durch:
 
- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)**-Methode zur Erstellung eines PowerPoint 3D-Modells.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)**-Methode zur Erstellung eines 3D-Texts
(WordArt).

Alle in **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** implementierten Effekte können sowohl für Formen als auch für Text verwendet werden.
Werfen wir einen kurzen Blick auf die Hauptmethoden der **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**-Klasse. Im nächsten Beispiel
erstellen wir eine 2D-Rechteckform mit einem Text darauf. Indem wir die Kameraperspektive auf die Form erhalten, ändern wir ihre Rotation und lassen sie wie ein 3D-Modell aussehen. Durch das Setzen eines flachen Lichts 
und seiner Richtung zum oberen Teil des 3D-Modells erhält das Modell mehr Volumen. Veränderte Materialien, Extrusionshöhe und Farbe lassen das 3D-Modell lebendiger aussehen.  
``` java 
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

## 3D-Rotation
Die Rotation des 3D-Modells in PowerPoint kann über das Menü erfolgen:

![todo:image_alt_text](img_02_01.png)

Um ein 3D-Modell mit der Aspose.Slides API zu drehen, verwenden Sie die **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**
Methode, um die Rotation der Kamera relativ zur 3D-Form einzustellen:

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... andere 3D-Szenenparameter einstellen

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## 3D-Tiefe und Extrusion
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)**
und **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)**-Methoden
werden verwendet, um eine Extrusion auf der Form zu erstellen:

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... andere 3D-Szenenparameter einstellen

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

In PowerPoint wird die Tiefe der Form über:

![todo:image_alt_text](img_02_02.png)

## 3D-Verlauf
Ein 3D-Verlauf kann dem PowerPoint 3D-Formen mehr Volumen verleihen:

``` java
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
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... 3D einstellen: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* Eigenschaften

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

Hier ist das Ergebnis:

![todo:image_alt_text](img_02_04.png)

## 3D-Text (WordArt)
Um einen 3D-Text (WordArt) zu erstellen, machen Sie Folgendes:
``` java
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
// „Arch Up“-WordArt-Transformations-Effekt einstellen
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

## Nicht Unterstützt - Bald Verfügbar
Die folgenden PowerPoint 3D-Funktionen werden noch nicht unterstützt: 
- Fase
- Material
- Kontur
- Beleuchtung