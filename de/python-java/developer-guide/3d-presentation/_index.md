---
title: 3D-Effekte in Präsentationen mit Python erstellen
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-Präsentation
- 3D-Drehung
- 3D-Tiefe
- 3D-Extrusion
- 3D-Verlauf
- 3D-Text
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint-Formen und -Text in Python über Java mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D-Text."
---
## **Übersicht**

Aspose.Slides for Python via Java kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er befasst sich nicht mit dem Einfügen oder Bearbeiten eigenständiger 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in das exportierte 2D‑Ergebnis.
{{% /alert %}}

## **3D-Formatierungskonzepte**

Verwenden Sie die Methode [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getThreeDFormat), um einer Form eine 3D‑Formatierung anzuwenden. Die Methode gibt ein [ThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#getThreeDFormat). Diese wendet die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten API‑Elemente sind:

| API‑Mitglied | Was es steuert | Wann zu verwenden |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getCamera) | Sichtpunkt, vordefinierter Kameratyp, Drehung, Zoom und Perspektive. | Rotieren Sie das Objekt im 3‑D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehungs‑Voreinstellung an. |
| [getLightRig](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getLightRig) | Lichtvorgabe, Richtung und Lichtdrehung. | Ändern Sie, wie Highlights und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getMaterial) und [setMaterial](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setMaterial) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lässt dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getExtrusionHeight) und [setExtrusionHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandelt eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getExtrusionColor) | Farbe der extrudierten Seiten. | Macht die Tiefe sichtbar oder stimmt die Seitenfarbe mit der Vorderseitenfüllung ab. |
| [getDepth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getDepth) und [setDepth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setDepth) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [getBevelTop](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getBevelTop) und [getBevelBottom](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getBevelBottom) | Erhöhte oder abgerundete Kanten an Vorder- und Rückseite. | Fügt eine weiche oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [getContourColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getContourColor) und [getContourWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getContourWidth) und [setContourWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setContourWidth) | Umriss um das 3D‑Objekt. | Betont die Objektgrenzen in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die standardmäßige Vorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zu seiner Vorderseite hinzu und wendet eine 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild bei dem Doppelten seiner Standardgröße und speichert die Präsentation als PPTX.

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

In PowerPoint wird die 3D‑Drehung im Bedienfeld 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Bedienfeld 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat.getCamera](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getCamera) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie verändert die 3D‑Sicht, die von PowerPoint und von Aspose.Slides beim Rendern verwendet wird.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick erscheinen, indem sie hinter die Vorderseite verlängert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, die den Extrusions‑Farb‑ und Extrusions‑Höhen‑Eigenschaften zugeordnet sind](img_02_02.png)

Verwenden Sie [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setExtrusionHeight), um die Dicke festzulegen, und [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getExtrusionColor), um die Seitenfarbe zu erhalten. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```python
import jpime
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

Die Methode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setDepth) legt die Tiefe einer 3D‑Form fest. Die Methode [setExtrusionHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setExtrusionHeight) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verwenden von Farbverläufen oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Farbverlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Farbverlaufs‑Stops bei 0 und 100 markieren den Anfang bzw. das Ende des Verlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild bei dem Doppelten ihrer Standardgröße gerendert:

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

Das gerenderte Ergebnis behält den Farbverlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erzeugt Text mit einem orange‑weißen Gitternetzmuster, wendet einen nach oben gerichteten Bogen an und konfiguriert die 3D‑Einstellungen über [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#getThreeDFormat). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, und die Lichtdrehung ist in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild bei dem Doppelten der Standardfolienabmessungen und speichert die Präsentation als PPTX:

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

Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbiger Musternfüllung und dunkler Extrusion:

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbiger Musternfüllung und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Um den Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, rufen Sie [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setKeepTextFlat) über [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getTextFrameFormat) auf. Wenn der Wert `True` ist, bleibt der Text außerhalb der 3D‑Szene. Wenn er `False` ist, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: ihre Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getThreeDFormat) konfiguriert. Sie unterscheidet sich zudem von der normalen Drehung. [Shape.setRotation](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setRotation) dreht die Form in der Folienebene, während [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setRotationAngle) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Ausblenden des Textes aus der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und klont es neben das Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `False` links und `True` rechts. Die Kamerawinkel sind in Grad angegeben, und die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu einem PNG bei dem Doppelten ihrer Standardgröße.

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

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander stehende 3D‑Rechtecke: Text folgt auf der linken Seite der 3D‑Ausrichtung und bleibt auf der rechten Seite flach](keep_text_flat.png)

## **Export‑ und Renderverhalten**

Aspose.Slides behält die 3D‑Formatierung bei, wenn in PowerPoint‑Formate wie PPTX gespeichert wird. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene gerastert oder in das Ergebnis als 2D‑Darstellung eingefügt. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/python-java/convert-powerpoint-to-png/), zu [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/python-java/convert-powerpoint-to-html/) exportieren oder Frames für die [Video‑Konvertierung](/slides/de/python-java/convert-powerpoint-to-video/) erzeugen.

Beachten Sie die folgenden Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/python-java/shape-effective-properties/).
- Einige Ausgab Formate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder -Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung und entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie außerdem ein Licht‑Rig und ein Material einstellen, sodass die gerenderten Flächen klare Highlights und Schatten besitzen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getThreeDFormat) für den Formkörper und [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#getThreeDFormat) für Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Videoframes angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Videokonvertierung erzeugt werden. Das exportierte Ergebnis enthält das gerenderte Aussehen, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Themen‑einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [Shape Effective Properties](/slides/de/python-java/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Licht‑Rig-, Abschrägungs‑ und zugehörigen 3D‑Werte zu lesen.