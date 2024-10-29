---
title: 3D Präsentation
type: docs
weight: 232
url: /de/php-java/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D Präsentation
- 3D Rotation
- 3D Tiefe
- 3D Extrusion
- 3D Farbverlauf
- 3D Text
- PowerPoint-Präsentation
- PHP
- Aspose.Slides für PHP über Java
description: "3D PowerPoint-Präsentation in PHP"
---

## Übersicht
Seit Aspose.Slides Java 20.9 ist es möglich, 3D in Präsentationen zu erstellen. PowerPoint 3D ist eine Möglichkeit, Präsentationen Leben einzuhauchen. Zeigen Sie reale Objekte
mit 3D-Präsentationen, demonstrieren Sie ein 3D-Modell Ihres zukünftigen Geschäftsprojekts, 3D-Modell des Gebäudes oder seiner Innenräume, 3D-Modell des Spielcharakters
oder einfach eine 3D-Darstellung Ihrer Daten.

PowerPoint 3D-Modelle können aus 2D-Formen erstellt werden, indem solche Effekte auf sie angewendet werden: 3D-Rotation, 3D-Tiefe und Extrusion, 3D-Farbverlauf, 3D-Text usw.
Die Liste der auf die Formen angewendeten 3D-Funktionen finden Sie in der Klasse **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**.
Die Instanz der Klasse kann durch folgende Methoden erhalten werden:

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** Methode zur Erstellung eines PowerPoint 3D-Modells.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** Methode zur Erstellung eines 3D-Texts
(WordArt).

Alle in **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** implementierten Effekte können sowohl für Formen als auch für Text verwendet werden.
Lassen Sie uns einen kurzen Blick auf die Hauptmethoden der Klasse **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** werfen. Im nächsten Beispiel
erstellen wir eine rechteckige 2D-Form mit einem Text darauf. Durch das Erhalten der Kameraperspektive auf der Form ändern wir ihre Rotation und lassen sie wie ein 3D-Modell aussehen. Durch das Setzen eines flachen Lichts
und seiner Richtung nach oben auf das 3D-Modell wird dem Modell mehr Volumen verliehen. Geänderte Materialien, Extrusionshöhe und Farbe lassen das 3D-Modell lebendiger wirken.  
``` php 
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("sandbox_3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

Hier ist das resultierende 3D-Modell:

![todo:image_alt_text](img_01_01.png)

## 3D Rotation
Die Rotation des 3D-Modells in PowerPoint kann über das Menü erfolgen:

![todo:image_alt_text](img_02_01.png)

Um ein 3D-Modell mit der Aspose.Slides-API zu drehen, verwenden Sie die Methode **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**,
setzten Sie die Rotation der Kamera relativ zur 3D-Form:

``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... set other 3D scene parameters

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```

## 3D Tiefe und Extrusion
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)**
und **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** Methoden
werden verwendet, um eine Extrusion auf der Form zu erstellen:

``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... set other 3D scene parameters

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```

In PowerPoint wird die Tiefe der Form über folgendes eingestellt:

![todo:image_alt_text](img_02_02.png)

## 3D Farbverlauf
Ein 3D-Farbverlauf kann einem PowerPoint 3D-Form mehr Volumen verleihen:

``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getFillFormat()->setFillType(FillType::Gradient);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 255, 140, 0));

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->dispose();
```

So sieht es aus:

![todo:image_alt_text](img_02_03.png)

Sie können auch einen Bildverlauf erstellen:
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... setup 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```

Hier ist das Ergebnis:

![todo:image_alt_text](img_02_04.png)

## 3D Text (WordArt)
Um einen 3D-Text (WordArt) zu erstellen, tun Sie Folgendes:
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getFillFormat()->setFillType(FillType::NoFill);
$shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
$shape->getTextFrame()->setText("3D Text");

$portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
$portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
$textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
# setup "Arch Up" WordArt transform effect
$textFrameFormat->setTransform(TextShapeType::ArchUp);

$textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
$textFrameFormat->getThreeDFormat()->setDepth(3);
$textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
$textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
$textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
$textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("text3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("text3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

Hier ist das Ergebnis:

![todo:image_alt_text](img_02_05.png)

## Nicht Unterstützt - Bald Verfügbar
Die folgenden PowerPoint 3D-Funktionen sind noch nicht unterstützt: 
- Fasen
- Material
- Kontur
- Beleuchtung