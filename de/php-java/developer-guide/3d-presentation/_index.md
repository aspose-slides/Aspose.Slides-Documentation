---
title: 3D‑Effekte in Präsentationen mit PHP erstellen
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/php-java/3d-presentation/
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
- PHP
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in PHP mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für PHP via Java kann 3D-Formatierungen im PowerPoint-Stil für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D-Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D-Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten eigenständiger 3D‑Modell‑Dateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Methode [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat), um einer Form eine 3D‑Formatierung zuzuweisen. Die Methode gibt ein [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat), die die 3D‑Formatierung auf den Textrahmen anwendet, nicht auf den Formkörper.

Die wichtigsten API‑Elemente sind:

| API‑Element | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Standpunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es einer PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Lichtvoreinstellung, Richtung und Lichtrotation. | Ändern Sie, wie Glanzlichter und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) und [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) und [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein deutlich dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen Sie die Seitenfarbe mit der Vorderseitenfüllung ab. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) und [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, besonders in Kombination mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) und [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Erhobene oder abgerundete Kanten an Vorder‑ und Rückseiten. | Fügen Sie eine sanfte oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) und [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) und [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Umrandung um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **3D‑Form erstellen**

Eine Form benötigt in der Regel vier Arten von Einstellungen, damit sie überzeugend 3D wirkt:

- Kameraeinstellungen, da die standardmäßige Vorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht dargestellt wird.
- Extrusions‑ oder Tiefe‑Einstellungen, da eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seiner Vorderseite Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit doppelter Standardgröße und speichert die Präsentation als PPTX.

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

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung über das Fenster 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Fenster 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt die X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie. Sie ändert den 3D‑Standpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kameraposition von einer Vorlagenform kopieren**

Um die Ausrichtung einer Vorlagenform zu übernehmen, lesen Sie deren Kameravoreinstellung mit [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) und deren Drehwinkel mit [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Das Beispiel öffnet `template.pptx` und kopiert die Kameraposition von der ersten Form auf der ersten Folie zur zweiten Form. Beide Formen besitzen bereits 3D‑Beleuchtung, und die zweite Form hat keine explizite Kameradrehung.

Die Winkel sind in Grad angegeben. Index `0` ist die Breite, Index `1` die Länge und Index `2` die Drehung. Übergeben Sie sie in dieser Reihenfolge an [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation). Gibt die Quelle `null` zurück, hat sie keine explizite Drehung, sodass die Winkel der zweiten Form unverändert bleiben. Eine explizite Drehung von `(0, 0, 0)` liefert drei Nullen und sollte kopiert werden.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wenn Sie `camera-copy.pptx` in PowerPoint erneut öffnen, hat der Pfeil rechts dieselbe Kameravoreinstellung und Drehung wie das Rechteck links. Beide Formen verwenden dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein rechter Pfeil mit übereinstimmender Kameraposition, von oben und rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter der Vorderseite erweitert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, die den Extrusionsfarb‑ und Extrusionhöhen‑Eigenschaften zugeordnet sind](img_02_02.png)

Verwenden Sie [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight), um die Dicke festzulegen, und [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor), um die Seitenfarbe abzurufen. Dieses Beispiel verleiht einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke sichtbar zu machen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Die Methode [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verwenden von Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können die Vorderseite mit einer Vollfarbe, einem Farbverlauf, einer Muster‑ oder Bildfüllung versehen und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Farbverlauf auf die Vorderseite an und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion. Die Farbverlauf‑Stops bei 0 und 100 markieren den Anfang bzw. das Ende des Farbverlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild mit doppelter Standardgröße gerendert:

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

![Gerendertes 3D‑Rechteck mit blau‑zu‑orange‑Farbverlauf‑Füllung und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel benötigt eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es dehnt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und legt die Kameradrehung in Grad fest. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche gerendert wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung von Formen wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weißes Gittermuster, wendet einen nach oben gebogenen Bogen an und konfiguriert 3D‑Einstellungen über [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtrotation in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit doppelter Standardfoliengröße und speichert die Präsentation als PPTX:

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

Der Text wird als gekrümmte, extrudierte 3D‑Beschriftung gerendert:

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbenem Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Um den Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, rufen Sie [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) über [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) auf. Ist der Wert `true`, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) konfiguriert. Sie unterscheidet sich zudem von der normalen Drehung. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) dreht die Form in der Folienebene, während [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und klont es neben das Original. Beide Formen besitzen dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG mit doppelter Standardgröße.

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

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander angezeigte 3D‑Rechtecke: Text folgt der 3D‑Ausrichtung links und bleibt rechts flach](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene gerastert bzw. als 2D‑Ergebnis in die Ausgabe gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/php-java/convert-powerpoint-to-png/), zu [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/php-java/convert-powerpoint-to-html/) exportieren oder Frames für [video conversion](/slides/de/php-java/convert-powerpoint-to-video/) erzeugen.

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/php-java/shape-effective-properties/).
- Einige Ausgabeformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine normale PowerPoint‑Form oder einen Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung und entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie außerdem ein Licht‑Rig und Material setzen, damit die gerenderten Flächen klare Glanzlichter und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) für den Formkörper und [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) für Text.

**Werden 3D‑Effekte beim Exportieren zu Bildern, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte beim Erzeugen von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [effektiven Formeigenschaften](/slides/de/php-java/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.