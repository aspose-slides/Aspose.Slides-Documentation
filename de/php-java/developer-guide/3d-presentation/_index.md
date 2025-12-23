---
title: Erstellen von 3D-Präsentationen in PHP
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-Präsentation
- 3D-Drehung
- 3D-Tiefe
- 3D-Extrusion
- 3D-Gradient
- 3D-Text
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie mühelos interaktive 3D-Präsentationen in PHP mit Aspose.Slides. Exportieren Sie schnell in PowerPoint- und OpenDocument-Formate für vielseitige Nutzung."
---

## **Übersicht**
Seit Aspose.Slides Java 20.9 ist es möglich, 3D in Präsentationen zu erstellen. PowerPoint 3D ist eine Möglichkeit, Präsentationen Leben einzuhauchen. Zeigen Sie reale Objekte mit einer 3D‑Präsentation, demonstrieren Sie ein 3D‑Modell Ihres zukünftigen Geschäftsprojekts, ein 3D‑Modell des Gebäudes oder seines Innenraums, ein 3D‑Modell des Spielcharakters oder einfach eine 3D‑Darstellung Ihrer Daten. 

PowerPoint‑3D‑Modelle können aus 2D‑Formen erstellt werden, indem solche Effekte auf sie angewendet werden: 3D‑Drehung, 3D‑Tiefe und Extrusion, 3D‑Gradient, 3D‑Text usw. Die Liste der auf die Formen angewendeten 3D‑Funktionen findet sich in der Klasse **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. Eine Instanz der Klasse kann erhalten werden durch:
 
- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** Methode zum Erstellen eines PowerPoint‑3D‑Modells.
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** Methode zum Erstellen eines 3D‑Texts (WordArt).

Alle in **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** implementierten Effekte können sowohl für Formen als auch für Text verwendet werden. Lassen Sie uns einen kurzen Blick auf die wichtigsten Methoden der Klasse **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** werfen. Im nächsten Beispiel erstellen wir eine rechteckige 2D‑Form mit einem Text darauf. Durch das Abrufen der Kameraperspektive der Form ändern wir ihre Drehung und lassen sie wie ein 3D‑Modell aussehen. Das Einstellen eines flachen Lichts und seiner Richtung nach oben am 3D‑Modell verleiht dem Modell mehr Volumen. Geänderte Materialien, Extrusionshöhe und Farbe lassen das 3D‑Modell lebendiger wirken.  
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


Hier ist das resultierende 3D‑Modell:

![todo:image_alt_text](img_01_01.png)

## **3D‑Drehung**
Die Drehung eines 3D‑Modells in PowerPoint kann über das Menü durchgeführt werden:

![todo:image_alt_text](img_02_01.png)

Um ein 3D‑Modell mit der Aspose.Slides‑API zu drehen, verwenden Sie die Methode **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**, setzen Sie die Drehung der Kamera relativ zur 3D‑Form:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... weitere 3D‑Szenenparameter setzen

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


## **3D‑Tiefe und Extrusion**
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** und **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** Methoden werden verwendet, um eine Extrusion auf einer Form zu erstellen:
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... weitere 3D‑Szenenparameter setzen

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


In PowerPoint wird die Tiefe der Form über folgendes eingestellt:

![todo:image_alt_text](img_02_02.png)

## **3D‑Gradient**
Ein 3D‑Gradient kann einer PowerPoint‑3D‑Form mehr Volumen verleihen:
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
  
Sie können auch einen Bild‑Gradient erstellen:
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... 3D einrichten: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* Eigenschaften

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


Hier ist das Ergebnis:

![todo:image_alt_text](img_02_04.png)

## **3D‑Text (WordArt)**
Um einen 3D‑Text (WordArt) zu erstellen, gehen Sie wie folgt vor:
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
# Einrichten "Arch Up" WordArt Transformations-Effekt
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

## **FAQ**

**Werden 3D‑Effekte beim Exportieren einer Präsentation in Bilder/PDF/HTML erhalten bleiben?**

Ja. Die Slides‑3D‑Engine rendert 3D‑Effekte beim Export in unterstützte Formate ([images](/slides/de/php-java/convert-powerpoint-to-png/),[PDF](/slides/de/php-java/convert-powerpoint-to-pdf/),[HTML](/slides/de/php-java/convert-powerpoint-to-html/), usw.).

**Kann ich die „effektiven“ (finalen) 3D‑Parameterwerte abrufen, die Themen, Vererbung usw. berücksichtigen?**

Ja. Slides bietet APIs zum [Lesen effektiver Werte](/slides/de/php-java/shape-effective-properties/) (einschließlich für 3D – Beleuchtung, Abschrägungen usw.), sodass Sie die final angewendeten Einstellungen sehen können.

**Funktionieren 3D‑Effekte beim Konvertieren einer Präsentation in ein Video?**

Ja. Beim [Erzeugen von Frames für das Video](/slides/de/php-java/convert-powerpoint-to-video/) werden 3D‑Effekte genauso gerendert wie bei [exportierten Bildern](/slides/de/php-java/convert-powerpoint-to-png/).