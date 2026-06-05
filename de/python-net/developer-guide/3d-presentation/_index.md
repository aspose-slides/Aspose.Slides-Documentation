---
title: 3D-Effekte in Präsentationen mit Python erstellen
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
## **Überblick**

Aspose.Slides für Python via .NET kann PowerPoint‑ähnliche 3D‑Formatierungen für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="primary" %}}
Dieser Artikel handelt von 3D‑Formatierungseffekten für PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in das exportierte 2D‑Ergebnis.
{{% /alert %}}

## **3D-Formatierungskonzepte**

Verwenden Sie die Eigenschaft [Shape.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/three_d_format/), um einer Form eine 3D‑Formatierung zuzuweisen. Die Eigenschaft gibt [ThreeDFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Eigenschaft [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/three_d_format/). Diese wendet die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper an.

Die wichtigsten Eigenschaften sind:

| Eigenschaft | Was es steuert | Wann zu verwenden |
|---|---|---|
| [camera](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/camera/) | Sichtpunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehungsvoreinstellung an. |
| [light_rig](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/light_rig/) | Lichtvoreinstellung, Richtung und Lichtdrehung. | Ändern Sie, wie Highlights und Schatten auf der 3D‑Oberfläche erscheinen. |
| [material](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/material/) | Oberflächenmaterial, wie flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [extrusion_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_height/) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt ist. | Verwandeln Sie eine flache Form in ein deutlich dickes 3D‑Objekt. |
| [extrusion_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_color/) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder koordinieren Sie die Seitenfarbe mit der Vordergrundfüllung. |
| [depth](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/depth/) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, besonders in Kombination mit Abschrägung‑ und Materialeinstellungen. |
| [bevel_top](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/bevel_top/) und [bevel_bottom](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/bevel_bottom/) | Erhöhte oder abgerundete Kanten an den Vorder‑ und Rückseiten. | Fügen Sie einen weichen oder geformten Rand statt einer scharfen flachen Fläche hinzu. |
| [contour_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/contour_color/) und [contour_width](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/contour_width/) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

Eine Form benötigt normalerweise vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, da die standardmäßige Vorderansicht die Extrusion verdecken kann.
- Lichteinstellungen, weil die Beleuchtung die Flächen und Seiten sichtbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie das Licht gerendert wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt seiner Vorderseite Text hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie zu einem PNG‑Bild.

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

In PowerPoint wird die 3D‑Drehung über das Fenster 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Fenster 3‑D‑Drehung mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides setzen Sie den Kameratyp und die Drehung über [ThreeDFormat.camera](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie verändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert die 3D‑Ansicht, die von PowerPoint und von Aspose.Slides beim Rendern verwendet wird.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick wirken, indem sie hinter der Vorderfläche verlängert wird. In PowerPoint legt die Tiefen‑Steuerung diese sichtbare Dicke fest, und die Farb‑Steuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefen‑Steuerungen, die den Extrusions‑Farb‑ und Extrusions‑Höhen‑Eigenschaften zugeordnet sind](img_02_02.png)

Setzen Sie [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_height/) für die Dicke und [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_color/) für die Seitenfarbe:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Verwenden Sie [ThreeDFormat.depth](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/depth/), wenn Sie direkt mit dem PowerPoint‑Tiefenwert arbeiten oder Tiefe mit Abschrägung, Material und Texteffekten kombinieren müssen. In vielen Form‑Szenarien ist [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/threedformat/extrusion_height/) die eindeutigere Einstellung, da sie die sichtbare Extrusion direkt ausdrückt.

## **Verwenden von Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderfläche anwenden und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusions‑Einstellungen verwenden.

Dieses Beispiel wendet eine Farbverlauf‑Füllung auf die Form und eine dunklere Extrusionsfarbe auf die Seiten an:

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

Das gerenderte Ergebnis behält den Farbverlauf auf der Vorderfläche bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit blau‑zu‑orangefarbenem Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche gerendert wird:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Dies ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einer Musterfüllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [TextFrameFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/):

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

![Gerenderter 3D‑Text mit einer geschwungenen WordArt‑Transformation, orangefarbener Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Renderverhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert oder als 2D‑Ergebnis in die Ausgabe gezeichnet. Das gilt, wenn Sie Folien zu [PNG](/slides/de/python-net/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/python-net/convert-powerpoint-to-html/) exportieren oder Frames für die [Video‑Konvertierung](/slides/de/python-net/convert-powerpoint-to-video/) erzeugen.

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter gedreht werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.
- Wenn Sie geerbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/python-net/shape-effective-properties/).
- Einige Ausgabeformate können die bearbeitbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als bearbeitbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenerien, die ein Betrachter drehen kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint bearbeitbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder -Text angewendet wird, wie Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung sowie entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie außerdem ein Licht‑Rig und ein Material setzen, damit die gerenderten Flächen klare Lichtreflexe und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [Shape.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/three_d_format/) für den Formkörper und [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframeformat/three_d_format/) für Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgabe, HTML‑Ausgabe und Frames für die Video‑Konvertierung erzeugt werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein bearbeitbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Theme‑Einstellungen auslesen?**

Ja. Verwenden Sie die effektiven Formatierungs‑APIs, die in [Shape Effective Properties](/slides/de/python-net/shape-effective-properties/) beschrieben sind, um die endgültigen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte auszulesen.