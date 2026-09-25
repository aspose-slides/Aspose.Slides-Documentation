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
- 3D-Gradient
- 3D-Text
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint-Formen und -Text in Python mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D-Text."
---
## **Übersicht**

Aspose.Slides for Python via .NET kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Gradient‑ oder Bildfüllungen sowie 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel befasst sich mit 3D‑Formatierungseffekten für PowerPoint‑Formen und -Text. Er behandelt nicht das Einfügen oder Bearbeiten eigenständiger 3D‑Modelldateien. Wenn Sie eine Folie als Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D‑Formatierungskonzepte**

Verwenden Sie die [Shape.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/three_d_format/)‑Eigenschaft, um einer Form 3D‑Formatierung zuzuweisen. Die Eigenschaft stellt ein [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) bereit, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/three_d_format/)‑Eigenschaft. Damit wird die 3D‑Formatierung auf den Textrahmen und nicht auf den Formkörper angewendet.

Die wichtigsten Eigenschaften sind:

| Eigenschaft | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [camera](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/camera/) | Blickpunkt, vordefinierter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie eine PowerPoint‑3D‑Drehungsvorlage an. |
| [light_rig](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/light_rig/) | Lichtvorlage, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [material](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/material/) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [extrusion_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_height/) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [extrusion_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_color/) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen Sie die Seitenfarbe mit der Vorderseitenfüllung ab. |
| [depth](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/depth/) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, besonders zusammen mit Abschrägung‑ und Materialeinstellungen. |
| [bevel_top](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/bevel_top/) und [bevel_bottom](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/bevel_bottom/) | Erhobene oder abgerundete Kanten an Vorder‑ und Rückseiten. | Fügen Sie eine abgeflachte oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [contour_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/contour_color/) und [contour_width](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/contour_width/) | Kontur um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standard‑Frontansicht die Extrusion verbergen kann.
- Lichteinstellungen, weil Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil einer flachen Form Dicke fehlt.

Das folgende Beispiel erzeugt ein Rechteck, fügt Text auf seiner Vorderseite hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit doppelter Standardgröße und speichert die Präsentation als PPTX.

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

## **Drehen einer Form mit der Kamera**

In PowerPoint wird die 3D‑Drehung im Bereich „3‑D‑Drehung“ konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Fenster „3‑D‑Drehung“ mit hervorgehobenen X‑, Y‑ und Z‑Werten](img_02_01.png)

In Aspose.Slides greifen Sie über [ThreeDFormat.camera](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/camera/) auf die Kamera zu. Dieses Beispiel erzeugt ein Rechteck, wählt eine orthografische Frontansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie, sondern den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick wirken, indem sie hinter die Vorderseite verlängert wird. In PowerPoint steuert die Tiefen‑Kontrolle diese sichtbare Dicke, und die Farb‑Kontrolle legt die Farbe der Seitenflächen fest.

![PowerPoint‑Tiefen‑Steuerelemente, gemappt auf die Eigenschaften extrusion_color und extrusion_height](img_02_02.png)

Setzen Sie [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_height/) für die Dicke und [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_color/) für die Seitenfarbe. Dieses Beispiel gibt einem Rechteck eine Extrusion von 100 Punkten mit violetten Seiten und dreht die Kamera, um die Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Die [ThreeDFormat.depth](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/depth/)‑Eigenschaft legt die Tiefe einer 3D‑Form fest. Die [extrusion_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_height/)‑Eigenschaft steuert die Höhe des Extrusions‑Effekts, wie im Beispiel gezeigt.

## **Verwendung von Gradient‑ oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Volltonfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und gleichzeitig dieselbe Kamera-, Licht‑, Material‑ und Extrusions‑Einstellung nutzen.

Dieses Beispiel wendet einen blauen‑zu‑orangen Farbverlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Farbverlaufs‑Stops bei 0 % und 100 % markieren Beginn und Ende des Verlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild mit doppelter Standardgröße gerendert:

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

Die gerenderte Ausgabe behält den Farbverlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit blau‑zu‑orangem Farbverlauf und oranger Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen Sie es der Formfüllung zu. Dieses Beispiel setzt voraus, dass im Arbeitsverzeichnis eine Datei namens „image.jpg“ existiert. Es streckt das Bild, um das Rechteck zu füllen, wendet eine Extrusion von 150 Punkten an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche angezeigt wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und oranger Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form betrifft den Formkörper. Die 3D‑Formatierung von Text betrifft den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kamera benötigen.

Das nachfolgende Beispiel erzeugt Text mit einem orange‑weiß‑gestreiften Muster, wendet einen nach oben gerichteten Bogen an und konfiguriert 3D‑Einstellungen über [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/three_d_format/). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, die Lichtdrehung in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit doppelter Standardfoliengröße und speichert die Präsentation als PPTX:

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

Der Text wird als gekrümmte, extrudierte 3D‑Beschriftung gerendert:

![Gerenderter 3D‑Text mit bogenförmiger WordArt‑Transformation, orangefarbener Mustere‑Füllung und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D‑Form halten**

Damit Text lesbar bleibt, während die Form ihre 3D‑Darstellung behält, setzen Sie [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/keep_text_flat/) über [TextFrame.text_frame_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/text_frame_format/). Wenn der Wert `True` ist, bleibt der Text außerhalb der 3D‑Szene. Ist er `False`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [Shape.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/three_d_format/) konfiguriert. Sie unterscheidet sich auch von einer normalen Drehung. [Shape.rotation](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/rotation/) dreht die Form in der Folienebene, während [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/rotation_angle/) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keinen dieser Winkel zurück.

Das folgende eigenständige Beispiel erzeugt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `False` links und `True` rechts. Die Kamerawinkel sind in Grad, die Extrusionshöhe 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG mit doppelter Standardgröße.

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

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinanderstehende 3D‑Rechtecke: keep_text_flat ist links False und rechts True](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in fest formatierte Layouts wird die 3D‑Szene rasterisiert bzw. in das Ergebnis als 2D‑Darstellung gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/python-net/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/python-net/convert-powerpoint-to-html/) exportieren oder Frames für die [Video‑Konvertierung](/slides/de/python-net/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Form‑Eigenschaften](/slides/de/python-net/shape-effective-properties/).
- Einige Ausgabeformate können keine editierbare PowerPoint‑3D‑Formatierung speichern. In diesen Formaten wird das visuelle Ergebnis gerendert statt als editierbare 3D‑Einstellungen erhalten.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenerien, die ein Betrachter rotieren könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf einer regulären PowerPoint‑Form oder auf Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind erforderlich, damit eine 3D‑Form sichtbar ist?**

Mindestens muss eine Kameradrehung und entweder Extrusion oder Tiefe gesetzt werden. In der Praxis sollten zudem ein Licht‑Rig und ein Material festgelegt werden, damit die gerenderten Flächen klare Highlights und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/three_d_format/) für den Formkörper und [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/three_d_format/) für Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgaben, HTML‑Ausgaben und Frames für die Video‑Konvertierung erzeugt werden. Das exportierte Ergebnis enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Themen‑Einstellungen auslesen?**

Ja. Nutzen Sie die APIs für effektive Formatierung, die in [Shape Effective Properties](/slides/de/python-net/shape-effective-properties/) beschrieben sind, um die finalen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und verwandten 3D‑Werte zu lesen.