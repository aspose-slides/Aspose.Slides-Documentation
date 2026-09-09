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
- 3D-Farbverlauf
- 3D-Text
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint‑Formen und -Text in Python via Java mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für Python via Java kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverläufe oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er behandelt nicht das Einfügen oder Bearbeiten von eigenständigen 3D‑Modell‑Dateien. Beim Export einer Folie zu einem Bild, PDF oder HTML rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispielcode importiert `asposeslides`, startet die JVM bei Bedarf und importiert dann die API. Das Beispiel für Bildfüllungen benötigt eine Datei `image.jpg` im Arbeitsverzeichnis.

## **3D‑Formatierungskonzepte**

Verwenden Sie [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getThreeDFormat), um einer Form 3D‑Formatierung zuzuweisen. Das zurückgegebene Formatobjekt steuert die 3D‑Szene für diese Form.

Für Text verwenden Sie [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#getThreeDFormat). Damit wird die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers angewendet.

Die wichtigsten API‑Mitglieder sind:

| API‑Mitglied | Was es steuert | Wann zu verwenden |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getCamera) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Das Objekt im 3D‑Raum drehen oder ein PowerPoint‑3D‑Drehungs‑Preset übernehmen. |
| [getLightRig](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getLightRig) | Licht‑Preset, Richtung und Lichtdrehung. | Ändern, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [getMaterial](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getMaterial) und [setMaterial](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setMaterial) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Das gleiche Geometrie‑Modell flacher, weicher, glänzender oder metallischer darstellen. |
| [getExtrusionHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getExtrusionHeight) und [setExtrusionHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Wie weit die Form von ihrer Vorderseite nach hinten ragt. | Eine flache Form in ein sichtbar dickeres 3D‑Objekt verwandeln. |
| [getExtrusionColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getExtrusionColor) | Farbe der extrudierten Seiten. | Tiefe sichtbar machen oder die Seitenfarbe mit der Vorderfüllung abstimmen. |
| [getDepth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getDepth) und [setDepth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setDepth) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Tiefe für Formen oder Text feinjustieren, besonders zusammen mit Abschrägung und Material. |
| [getBevelTop](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getBevelTop) und [getBevelBottom](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getBevelBottom) | Erhobene oder abgerundete Kanten an Vorder‑ und Rückseite. | Eine abgeflachte oder geformte Kante hinzufügen statt einer scharfen flachen Fläche. |
| [getContourColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getContourWidth) und [setContourWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#setContourWidth) | Kontur um das 3D‑Objekt. | Die Objektgrenze in der gerenderten Ausgabe betonen. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontalansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten erkennbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil einer flachen Form Dicke fehlt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zur Vorderseite hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie zu einem PNG‑Bild.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

In PowerPoint wird die 3D‑Drehung im Bereich „3‑D‑Drehung“ konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Bereich 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides setzen Sie den Kameratyp und die Drehung über das 3D‑Format, das von [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getThreeDFormat) zurückgegeben wird:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie, sondern den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dicker wirken, indem sie hinter die Vorderseite verlängert wird. In PowerPoint legt die Tiefen‑Steuerung diese sichtbare Dicke fest, und die Farb‑Steuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefen‑Steuerungen abgebildet auf Extrusions‑Farbe‑ und Extrusions‑Höhen‑Eigenschaften](img_02_02.png)

Setzen Sie die Extrusions‑Höhe für die Dicke und die Extrusions‑Farbe für die Seitenfarbe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Verwenden Sie die Tiefen‑Einstellung, wenn Sie den PowerPoint‑Tiefenwert direkt bearbeiten oder die Tiefe mit Abschrägung, Material und Texteffekten kombinieren müssen. In vielen Form‑Szenarien ist die Extrusions‑Höhe die klarere Einstellung, weil sie die sichtbare Extrusion direkt ausdrückt.

## **Verlauf‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

3D‑Formatierung ist unabhängig von der Form‑Füllung. Sie können eine einfarbige Füllung, einen Verlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen nutzen.

Dieses Beispiel wendet einen Verlauf auf die Form und eine dunklere Extrusions‑Farbe auf die Seiten an:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

Das gerenderte Ergebnis behält den Verlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit blau‑zu‑orangefarbigem Verlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Form‑Füllung zu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche gerendert wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt sich auf den Formkörper aus. Die 3D‑Formatierung von Text wirkt sich auf den Textrahmen aus. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kamera benötigen.

Das folgende Beispiel erstellt Text mit einer Musterfüllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/):

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

Der Text wird als gebogener, extrudierender 3D‑Schriftzug gerendert:

![Gerenderter 3D‑Text mit bogenförmiger WordArt‑Transformation, orangefarbener Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Renderverhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert bzw. in das Ergebnis als 2D‑Ausgabe gezeichnet. Das gilt beim Rendern von Folien zu PNG, Exportieren zu PDF, Exportieren zu HTML oder Erzeugen von Frames für die Videokonvertierung.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, nutzen Sie die API für effektive Formatierung.
- Einige Ausgabeformate können editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert statt als editierbare 3D‑Einstellung erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format sie unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbar 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung und entweder Extrusion oder Tiefe setzen. In der Praxis sollten Sie zudem ein Licht‑Rig und Material einstellen, damit die gerenderten Flächen klare Highlights und Schatten besitzen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getThreeDFormat) für den Formkörper und [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#getThreeDFormat) für Text.

**Werden 3D‑Effekte beim Exportieren zu Bildern, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte bei der Erstellung von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames, die für die Videokonvertierung verwendet werden. Das exportierte Ergebnis enthält das gerenderte Aussehen, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie [ThreeDFormat.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/threedformat/#getEffective), um die endgültigen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte zu lesen.