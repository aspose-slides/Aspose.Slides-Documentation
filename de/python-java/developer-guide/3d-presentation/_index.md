---
title: 3D‑Effekte in Präsentationen mit Python erstellen
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D Präsentation
- 3D‑Drehung
- 3D‑Tiefe
- 3D‑Extrusion
- 3D‑Farbverlauf
- 3D‑Text
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in Python über Java mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides for Python via Java kann Formen und Text 3D‑Formatierungen im PowerPoint‑Stil erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er befasst sich nicht mit dem Einfügen oder Bearbeiten eigenständiger 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Methode [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat), um einer Form eine 3D‑Formatierung zuzuweisen. Die Methode gibt ein [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Diese wendet die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten API‑Mitglieder sind:

| API‑Element | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Lichtvoreinstellung, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) und [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallischer wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) und [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt ist. | Verwandeln Sie eine flache Form in ein sichtbar dickeres 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vorderfüllung. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) und [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, besonders zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) und [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Erhöhte oder abgerundete Kanten auf Vorder- und Rückseite. | Fügen Sie eine abgeflachte oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) und [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) und [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Eine 3D‑Form erstellen**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, da die Standard‑Vorderansicht die Extrusion verbergen kann.  
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten lesbar macht.  
- Materialeinstellungen, da die Oberfläche beeinflusst, wie Licht gerendert wird.  
- Extrusions‑ oder Tiefe‑Einstellungen, da einer flachen Form Dicke fehlt.

Das folgende Beispiel erzeugt ein Rechteck, fügt seiner Vorderseite Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit doppelter Standardgröße und speichert die Präsentation als PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Eine Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung über das Feld 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Feld 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kameraposition von einer Vorlagenform kopieren**

Um die Ausrichtung einer Vorlagenform zu übernehmen, lesen Sie deren Kameravoreinstellung mit [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) und deren Rotationswinkel mit [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Das Beispiel öffnet `template.pptx` und kopiert die Kameraposition von der ersten Form auf der ersten Folie zur zweiten Form. Beide Formen besitzen bereits 3D‑Beleuchtung, und die zweite Form hat keine explizite Kameradrehung.

Die Winkel sind in Grad angegeben. Index `0` ist Breite, Index `1` ist Länge und Index `2` ist Umdrehung. Übergeben Sie sie in dieser Reihenfolge an [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation). Gibt die Quelle `None` zurück, hat sie keine explizite Drehung, sodass die Winkel der zweiten Form unverändert bleiben. Eine explizite Drehung von `(0, 0, 0)` liefert drei Nullen und sollte kopiert werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wenn Sie `camera-copy.pptx` in PowerPoint erneut öffnen, hat der Pfeil rechts dieselbe Kameravoreinstellung und Drehung wie das Rechteck links. Beide Formen verwenden dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein rechter Pfeil mit übereinstimmender Kameraposition, von oben und rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderseite erweitert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, abgebildet auf Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften](img_02_02.png)

Verwenden Sie [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight), um die Dicke festzulegen, und [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor), um die Seitenfarbe abzurufen. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke sichtbar zu machen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Die Methode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verwenden von Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können der Vorderseite eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung zuweisen und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusionseinstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Farbverlauf auf die Vorderseite an und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion. Die Farbverlaufs‑Stops bei 0 und 100 markieren den Start bzw. das Ende des Farbverlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild mit doppelter Standardgröße gerendert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Farbverlauf und orangener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie dem Dokument das Bild hinzu und weisen es der Formfüllung zu. Dieses Beispiel setzt eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis voraus. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und legt die Kameradrehung in Grad fest. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung von Formen wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erzeugt Text mit einem orange‑weiß‑Gittermuster, wendet einen Aufwärtsbogen an und konfiguriert 3D‑Einstellungen über [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtdrehung in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit doppelter Standardgröße der Folie und speichert die Präsentation als PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Effekt, orangefarbener Musternfüllung und dunkler Extrusion](img_02_05.png)

## **Text auf einer 3D‑Form flach halten**

Um den Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, rufen Sie [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) über [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat) auf. Ist der Wert `True`, bleibt der Text außerhalb der 3D‑Szene. Ist er `False`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: deren Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) konfiguriert. Es unterscheidet sich außerdem von einer normalen Drehung. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) dreht die Form in der Folienebene, während [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keines dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen besitzen dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `False` links und `True` rechts. Die Kamerawinkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG mit doppelter Standardgröße.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten die gleiche sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander stehende 3D‑Rechtecke: Text folgt links der 3D‑Ausrichtung und bleibt rechts flach](keep_text_flat.png)

## **Export‑ und Renderverhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in fest‑layoutige Formate wird die 3D‑Szene rasterisiert oder in die Ausgabe als 2D‑Ergebnis gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/python-java/convert-powerpoint-to-png/), zu [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/python-java/convert-powerpoint-to-html/) rendern oder Rahmen für die [Video‑Konvertierung](/slides/de/python-java/convert-powerpoint-to-video/) erzeugen.

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.  
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Lichtanlage, Material, Extrusion, Füllung und Folien­skalierung ab.  
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen möchten, lesen Sie die [effektiven Formeigenschaften](/slides/de/python-java/shape-effective-properties/).  
- Einige Ausgabeformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**  
Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format sie unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**  
Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine normale PowerPoint‑Form oder -Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**  
Mindestens muss eine Kameradrehung und entweder Extrusion oder Tiefe festgelegt werden. In der Praxis sollten außerdem eine Lichtanlage und ein Material gesetzt werden, damit die gerenderten Flächen klare Highlights und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**  
Ja. Verwenden Sie [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) für den Formkörper und [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) für den Text.

**Werden 3D‑Effekte beim Exportieren zu Bildern, PDF, HTML oder Videoframes angezeigt?**  
Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgaben, HTML‑Ausgaben und Frames für die Videokonvertierung erzeugt werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Theme‑Einstellungen auslesen?**  
Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [Form‑Effektive Eigenschaften](/slides/de/python-java/shape-effective-properties/) beschrieben sind, um die endgültigen Werte für Kamera, Lichtanlage, Abschrägung und verwandte 3D‑Parameter auszulesen.