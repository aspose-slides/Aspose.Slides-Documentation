---
title: 3D-Präsentationen in Python erstellen
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/python-net/developer-guide/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-Präsentation
- 3D-Rotation
- 3D-Tiefe
- 3D-Extrusion
- 3D-Verlauf
- 3D-Text
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen Sie mühelos interaktive 3D-Präsentationen in Python mit Aspose.Slides. Exportieren Sie schnell in PowerPoint- und OpenDocument-Formate für vielseitige Verwendung."
---

## **Übersicht**

Wie erstellen Sie normalerweise eine 3D-PowerPoint‑Präsentation? Microsoft PowerPoint ermöglicht das Hinzufügen von 3D‑Modellen, das Anwenden von 3D‑Effekten auf Formen, das Erstellen von 3D‑Text, das Einfügen von 3D‑Grafiken und das Erstellen von 3D‑Animationen.

Das Erzeugen von 3D‑Effekten hat einen großen Einfluss und ist oft der einfachste Weg, ein Standard‑Deck in eine 3D‑Präsentation zu verwandeln. Seit Aspose.Slides 20.9 wurde eine neue **plattformübergreifende 3D‑Engine** hinzugefügt. Diese Engine ermöglicht das Exportieren und Rasterisieren von Formen und Text mit 3D‑Effekten. In früheren Versionen wurden Formen mit 3D‑Effekten flach gerendert; jetzt können sie mit **vollwertigem 3D** gerendert werden. Sie können auch Formen mit 3D‑Effekten über die Aspose.Slides‑API erstellen.

In der Aspose.Slides‑API verwenden Sie die Eigenschaft [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) , um eine Form zu einer PowerPoint‑3D‑Form zu machen. Diese Eigenschaft gibt Zugriff auf die Mitglieder der Klasse [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat) :

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) und [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) : Abschrägungen festlegen, Abschrägungstyp auswählen (z. B. Winkel, Kreis, SoftRound) und Höhe sowie Breite der Abschrägung definieren.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) : Kamerabewegung um das Objekt simulieren; durch Anpassen von Kamerarotation, Zoom und anderen Eigenschaften können Sie Formen wie 3D‑Modelle in PowerPoint manipulieren.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) und [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) : Kontur‑Eigenschaften festlegen, um einer Form das Aussehen eines 3D‑PowerPoint‑Objekts zu verleihen.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) , [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) und [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) : Eine Form durch Festlegen ihrer Tiefe oder Extrusion zu einer dreidimensionalen Form machen.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) : Beleuchtungseffekte auf einer 3D‑Form erzeugen; ähnlich wie bei der Kamera können Sie die Drehung des Lichts relativ zur 3D‑Form festlegen und einen Lichttyp wählen.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) : Material auswählen, um die 3D‑Form realistischer wirken zu lassen. Vorgefertigte Materialien umfassen Metall, Kunststoff, Pulver, Matt usw.

Alle 3D‑Funktionen können sowohl auf Formen als auch auf Text angewendet werden. Die nachfolgenden Abschnitte zeigen, wie Sie auf diese Eigenschaften zugreifen und sie anschließend Schritt für Schritt untersuchen.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

Das gerenderte Vorschaubild sieht folgendermaßen aus:

![todo:image_alt_text](img_01_01.png)

## **3D‑Rotation**

Sie können PowerPoint‑3D‑Formen im dreidimensionalen Raum drehen, um Interaktivität hinzuzufügen. Um eine 3D‑Form in PowerPoint zu drehen, verwenden Sie das folgende Menü:

![todo:image_alt_text](img_02_01.png)

In der Aspose.Slides‑API steuern Sie die 3D‑Rotation einer Form über die Eigenschaft [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) .

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... andere 3D‑Szenenparameter festlegen

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **3D‑Tiefe und Extrusion**

Um Ihrer Form eine dritte Dimension hinzuzufügen und sie wirklich 3D zu machen, verwenden Sie die Eigenschaften [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) und [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) :

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... andere 3D‑Szenenparameter festlegen

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

In PowerPoint verwenden Sie typischerweise das Menü **Tiefe**, um die Tiefe einer 3D‑Form festzulegen:

![todo:image_alt_text](img_02_02.png)

## **3D‑Verlauf**

Ein Verlauf kann verwendet werden, um eine PowerPoint‑3D‑Form zu füllen. Erstellen wir eine Form mit Verlaufsfüllung und wenden darauf einen 3D‑Effekt an:

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
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

Und hier das Ergebnis:

![todo:image_alt_text](img_02_03.png)

Zusätzlich zu Verlaufsfüllungen können Sie Formen mit einem Bild füllen:

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... 3D‑Setup: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion*‑Eigenschaften

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

So sieht es aus:

![todo:image_alt_text](img_02_04.png)

## **3D‑Text (WordArt)**

Aspose.Slides ermöglicht es Ihnen, auch Text 3D‑Effekte zu verleihen. Um 3D‑Text zu erstellen, können Sie den WordArt‑Transformations‑Effekt verwenden:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # Transformations‑Effekt "Arch Up" für WordArt einrichten
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

Hier das Ergebnis:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Werden 3D‑Effekte beim Export einer Präsentation zu Bildern/PDF/HTML beibehalten?**

Ja. Die Slides‑3D‑Engine rendert 3D‑Effekte beim Export in unterstützte Formate ([Bilder](/slides/de/python-net/convert-powerpoint-to-png/), [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), usw.).

**Kann ich die „effektiven“ (finalen) 3D‑Parameterwerte abrufen, die Themen, Vererbung usw. berücksichtigen?**

Ja. Slides bietet APIs zum [Lesen effektiver Werte](/slides/de/python-net/shape-effective-properties/) (einschließlich für 3D‑Beleuchtung, Abschrägungen usw.), sodass Sie die letztendlich angewendeten Einstellungen sehen können.

**Funktionieren 3D‑Effekte beim Konvertieren einer Präsentation zu Video?**

Ja. Beim [Generieren von Frames für das Video](/slides/de/python-net/convert-powerpoint-to-video/) werden 3D‑Effekte genauso gerendert wie bei [exportierten Bildern](/slides/de/python-net/convert-powerpoint-to-png/).