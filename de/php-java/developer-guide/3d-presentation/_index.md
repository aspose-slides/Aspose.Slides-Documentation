---
title: 3D-Effekte in Präsentationen mit PHP erstellen
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
- 3D-Farbverlauf
- 3D-Text
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint‑Formen und -Text in PHP mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für PHP über Java kann 3D-Formatierungen im PowerPoint-Stil für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D-Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf- oder Bildfüllungen und 3D-Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D-Formatierungseffekte für PowerPoint-Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D-Modell-Dateien. Wenn Sie eine Folie als Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D-Effekte in die exportierte 2D-Ausgabe.
{{% /alert %}}

## **3D-Formatierungskonzepte**

Verwenden Sie die [Shape::getThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getThreeDFormat--)‑Methode, um einer Form eine 3D‑Formatierung zuzuweisen. Die Methode gibt ein [ThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#getThreeDFormat--)‑Methode. Diese wendet die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten API-Mitglieder sind:

| API-Mitglied | Was es steuert | Wann zu verwenden |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getCamera--) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D-Raum oder passen Sie es an eine PowerPoint-3D-Drehungs-Voreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getLightRig--) | Licht-Voreinstellung, Richtung und Lichtrotation. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D-Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Oberflächenmaterial, z.B. flach, matt, Plastik oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch aussehen. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D-Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderseitenfüllung. |
| [getDepth](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#setDepth-double-) | Zusätzliche 3D-Tiefe, die von PowerPoint-3D-Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere zusammen mit Abschrägungs- und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getBevelBottom--) | Erhobene oder abgerundete Kanten auf Vorder- und Rückseite. | Fügen Sie eine abgeflachte oder geformte Kante hinzu statt einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Kontur um das 3D-Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Eine 3D-Form erstellen**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard-Vorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions- oder Tiefeneinstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seiner Vorderfläche Text hinzu und wendet 3D-Formatierung an. Die Kamera-Rotationswerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG-Bild mit doppelter Standardgröße und speichert die Präsentation als PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D-Block:

![Gerendertes blaues 3D-Rechteck mit weißem 3D-Text auf der Vorderseite](img_01_01.png)

## **Eine Form mit der Kamera drehen**

In PowerPoint wird die 3D-Drehung über das Bedienfeld "3-D-Drehung" konfiguriert. Die X-, Y- und Z-Drehungswerte entsprechen der Drehung, die Sie über die Kamera-API festlegen.

![PowerPoint-Bedienfeld 3-D-Drehung mit hervorgehobenen X-, Y- und Z-Drehungswerten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat::getCamera](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getCamera--) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt seine X-, Y- und Z-Drehungen auf jeweils 20, 30 und 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Verwenden Sie die Kamera, wenn Sie ändern möchten, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D-Formgeometrie auf der Folie. Sie ändert den 3D-Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderseite verlängert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint-Tiefensteuerungen, die den Extrusions-Farb- und Extrusions-Höhen-Eigenschaften zugeordnet sind](img_02_02.png)

Verwenden Sie [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) , um die Dicke festzulegen, und [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#getExtrusionColor--) , um die Seitenfarbe zu erhalten. Dieses Beispiel verleiht einem Rechteck eine 100-Punkt-Extrusion mit violetten Seiten und dreht die Kamera, um seine Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Die Methode [ThreeDFormat::setDepth](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#setDepth-double-) legt die Tiefe einer 3D-Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verwenden von Farbverlauf- oder Bildfüllungen mit 3D-Effekten**

3D-Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und dennoch dieselben Kamera-, Licht-, Material- und Extrusions-Einstellungen verwenden.

Dieses Beispiel wendet einen Blau-zu-Orange-Farbverlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150-Punkt-Extrusion an. Die Farbverlaufsstopps bei 0 und 100 kennzeichnen den Start bzw. das Ende des Farbverlaufs. Die Kamera-Rotationswerte sind in Grad angegeben. Die Folie wird zu einem PNG-Bild mit doppelter Standardgröße gerendert:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Die gerenderte Ausgabe behält den Farbverlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D-Rechteck mit einem Blau-zu-Orange-Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150-Punkt-Extrusion an und setzt die Kamera-Drehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Das Bild wird auf der Vorderfläche gerendert, während die Extrusion als 3D-Seitenfläche gerendert wird:

![Gerendertes 3D-Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D-Formatierung auf Text anwenden**

Die 3D-Formatierung einer Form wirkt auf den Formkörper. Die 3D-Formatierung von Text wirkt auf den Textrahmen. Das ist nützlich für WordArt-ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einem orange-weiß-Gittermuster, wendet einen nach oben gerichteten Bogen an und konfiguriert 3D-Einstellungen über [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtrotation ist in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG-Bild mit doppelter Standardfoliengröße und speichert die Präsentation als PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der Text wird als gebogener, extrudierter 3D-Schriftzug gerendert:

![Gerenderter 3D-Text mit einem bogenförmigen WordArt-Transform, orangem Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Text auf einer 3D-Form flach halten**

Um den Text lesbar zu halten und gleichzeitig das 3D-Aussehen einer Form zu bewahren, rufen Sie [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) über [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getTextFrameFormat--) auf. Wenn der Wert `true` ist, bleibt der Text außerhalb der 3D-Szene. Wenn er `false` ist, nimmt der Text an der Szene teil und folgt ihrer 3D-Ausrichtung.

Diese Einstellung entfernt nicht die 3D-Formatierung der Form: ihre Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape::getThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getThreeDFormat--) konfiguriert. Sie unterscheidet sich außerdem von einer normalen Drehung. [Shape::setRotation](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#setRotation-float-) dreht die Form in der Folienebene, während [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D-Szene setzt keine dieser Drehungen zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und klont es neben das Original. Beide Formen haben dieselbe 3D-Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamera-Winkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu einem PNG mit doppelter Standardgröße.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Links folgt der Text der 3D-Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D-Ausrichtung bei.

![Nebeneinander stehende 3D-Rechtecke: Text folgt der 3D-Ausrichtung links und bleibt rechts flach](keep_text_flat.png)

## **Export- und Rendering-Verhalten**

Aspose.Slides bewahrt die 3D-Formatierung beim Speichern in PowerPoint-Formaten wie PPTX. Beim Rendern oder Exportieren in feste Layout-Formate wird die 3D-Szene gerastert oder in die Ausgabe als 2D-Ergebnis gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/php-java/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/php-java/convert-powerpoint-to-html/) exportieren oder Frames für [Video-Konvertierung](/slides/de/php-java/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Licht-Rig, Material, Extrusion, Füllung und Folien-Skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektive Formeigenschaften](/slides/de/php-java/shape-effective-properties/).
- Einige Ausgabeformate können die editierbare PowerPoint-3D-Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert statt als editierbare 3D-Einstellungen erhalten.

## **FAQ**

**Kann Aspose.Slides interaktive 3D-Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint-3D-Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML-Seiten nicht zu interaktiven 3D-Szenen, die ein Betrachter drehen kann. In PPTX bleibt die 3D-Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D-Modell und einem 3D-Effekt?**

Ein 3D-Modell ist ein separates 3D-Objekt, das in eine Präsentation eingefügt wird. Ein 3D-Effekt ist eine Formatierung, die auf eine reguläre PowerPoint-Form oder -Text angewendet wird, z.B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D-Effekte.

**Welche Einstellungen sind für eine sichtbare 3D-Form erforderlich?**

Mindestens muss eine Kameradrehung und entweder Extrusion oder Tiefe festgelegt werden. In der Praxis sollten zudem ein Licht-Rig und Material gesetzt werden, damit die gerenderten Flächen klare Hervorhebungen und Schatten besitzen.

**Kann ich 3D-Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape::getThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getThreeDFormat--) für den Formkörper und [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#getThreeDFormat--) für Text.

**Werden 3D-Effekte beim Exportieren zu Bildern, PDF, HTML oder Videoframes angezeigt?**

Ja. Aspose.Slides rendert 3D-Effekte, wenn Folienbilder, PDF-Ausgaben, HTML-Ausgaben und Frames für die Videokonvertierung erzeugt werden. Das exportierte Ergebnis enthält das gerenderte Aussehen, nicht ein editierbares 3D-Objekt.

**Kann ich die endgültigen 3D-Werte nach Vererbung und Theme-Einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Formatierungs-APIs, die in [Shape Effective Properties](/slides/de/php-java/shape-effective-properties/) beschrieben werden, um die endgültigen Kamera-, Licht-Rig-, Abschrägungs- und zugehörigen 3D-Werte auszulesen.