---
title: Erstellen von 3D-Effekten in Präsentationen mit Python
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/python-net/3d-presentation/
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
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint-Formen und -Text in Python mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D-Text."
---
## **Übersicht**

Aspose.Slides für Python via .NET kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel befasst sich mit 3D‑Formatierungseffekten für PowerPoint‑Formen und -Text. Er behandelt nicht das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in das exportierte 2D‑Ergebnis.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die Eigenschaft [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) , um einer Form eine 3D‑Formatierung zuzuweisen. Die Eigenschaft stellt [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) bereit, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Eigenschaft [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Damit wird die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper angewendet.

Die wichtigsten Eigenschaften sind:

| Eigenschaft | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Lichtvorgabe, Richtung und Lichtdrehung. | Ändern Sie, wie Glanzlichter und Schatten auf der 3D‑Oberfläche erscheinen. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Wie weit die Form von ihrer Vorderseite nach hinten reicht. | Verwandeln Sie eine flache Form in ein sichtbar dickeres 3D‑Objekt. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder passen Sie die Seitenfarbe an die Vorderseitenfüllung an. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, besonders in Kombination mit Abschrägung‑ und Materialeinstellungen. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) und [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Erhöhte oder abgerundete Kanten an Vorder‑ und Rückseiten. | Fügen Sie eine abgeflachte oder geformte Kante statt einer scharfen flachen Seite hinzu. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) und [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **3D‑Form erstellen**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, da die standardmäßige Vorderansicht die Extrusion verbergen kann.  
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.  
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie das Licht dargestellt wird.  
- Extrusions‑ oder Tiefeneinstellungen, da eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seiner Vorderseite Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehungswerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild in der doppelten Standardgröße und speichert die Präsentation als PPTX.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Form mit der Kamera drehen**

In PowerPoint wird die 3D‑Drehung im Dialogfeld „3‑D‑Drehung“ konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Dialogfeld 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt die X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kamerabewegung einer Vorlagenform kopieren**

Um die Ausrichtung einer Vorlagenform zu übernehmen, kopieren Sie deren [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/)‑Voreinstellung und lesen Sie die Drehung mit [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Das Beispiel öffnet `template.pptx` und kopiert die Kameraausrichtung von der ersten Form auf der ersten Folie zur zweiten Form. Beide Formen besitzen bereits 3D‑Beleuchtung, und die zweite Form hat keine explizite Kameradrehung.

Die Winkel sind in Grad angegeben. Die Indizes `0`, `1` und `2` enthalten jeweils Breitengrad, Längengrad und Umdrehung. Übergeben Sie sie in dieser Reihenfolge an [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/). Wenn die Quelle keine explizite Drehung hat, gibt `get_rotation` `None` zurück, sodass die Zielwinkel unverändert bleiben. Wenn die Quelle alle drei Winkel explizit auf Null setzt, kopieren Sie diese Nullen.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie `camera-copy.pptx` in PowerPoint erneut öffnen, haben beide Formen dieselbe Kamera‑Voreinstellung und Drehung. Der Pfeil rechts verwendet die von dem linken Rechteck kopierte Ausrichtung. Beide Formen nutzen dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein rechter Pfeil mit passender Kameraausrichtung, von oben und rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dicker erscheinen, indem sie hinter die Vorderseite ausgedehnt wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, die den Extrusions‑Farb‑ und Extrusions‑Höhen‑Eigenschaften zugeordnet sind](img_02_02.png)

Setzen Sie [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) für die Dicke und [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) für die Seitenfarbe. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke sichtbar zu machen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Die [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)‑Eigenschaft legt die Tiefe einer 3D‑Form fest. Die [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/)‑Eigenschaft steuert die Höhe des Extrusionseffekts, wie im Beispiel gezeigt.

## **Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und dennoch dieselbe Kamera-, Licht‑, Material‑ und Extrusionskonfiguration nutzen.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Farbverlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Farbverlaufsstops bei 0 % und 100 % markieren den Beginn bzw. das Ende des Verlaufs. Die Kameradrehungswerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild in der doppelten Standardgröße gerendert:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Verlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild der Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel setzt eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis voraus. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne zu speichern oder zu rendern:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Shape‑3D‑Formatierung wirkt sich auf den Formkörper aus. Text‑3D‑Formatierung wirkt sich auf den Textrahmen aus. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einem orange‑weißen Rastermuster, wendet einen Aufwärtsbogen an und konfiguriert 3D‑Einstellungen über [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Die Extrusions‑höhe und Tiefe werden in Punkten angegeben, und die Lichtdrehung in Grad. Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild in der doppelten Standardgröße und speichert die Präsentation als PPTX:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Transform, orangefarbiger Musterausfüllung und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Aussehen einer Form zu bewahren, setzen Sie [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) über [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Ist der Wert `True`, bleibt der Text außerhalb der 3D‑Szene. Ist er `False`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt die 3D‑Formatierung der Form nicht: Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) konfiguriert. Sie unterscheidet sich zudem von einer herkömmlichen Drehung. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) dreht die Form in der Folienebene, während [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keine dieser Winkeln zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und klont es neben das Original. Beide Formen besitzen dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `False` links und `True` rechts. Die Kamerawinkel sind in Grad angegeben, die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG in der doppelten Standardgröße.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

![Nebeneinander dargestellte 3D‑Rechtecke: keep_text_flat ist links False und rechts True](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert bzw. in das Ergebnis als 2D‑Darstellung eingebettet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/python-net/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/python-net/convert-powerpoint-to-html/) exportieren oder Frames für [video conversion](/slides/de/python-net/convert-powerpoint-to-video/) erzeugen.

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.  
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Lichtsystem, Material, Extrusion, Füllung und Folien‑Skalierung ab.  
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/python-net/shape-effective-properties/).  
- Manche Ausgabeformate können editierbare PowerPoint‑3D‑Formatierungen nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert statt als editierbare 3D‑Einstellungen erhalten.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens eine Kameradrehung und entweder Extrusion oder Tiefe müssen gesetzt werden. In der Praxis sollten außerdem ein Lichtsystem und ein Material definiert werden, damit die gerenderten Flächen klare Highlights und Schatten besitzen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) für den Formkörper und [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) für Text.

**Werden 3D‑Effekte beim Export zu Bildern, PDF, HTML oder Video‑Frames sichtbar?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgabe, HTML‑Ausgabe oder Frames für die Videokonvertierung erzeugt werden. Das exportierte Ergebnis enthält das gerenderte Erscheinungsbild, jedoch kein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Theme‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [Shape Effective Properties](/slides/de/python-net/shape-effective-properties/) beschrieben sind, um die finalen Kamera‑, Lichtsystem‑, Abschrägungs‑ und zugehörigen 3D‑Werte zu lesen.