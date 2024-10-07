---
title: 3D-Präsentation
type: docs
weight: 232
url: /python-net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D-Präsentation
- 3D-Rotation
- 3D-Tiefe
- 3D-Extrusion
- 3D-Gradient
- 3D-Text
- PowerPoint-Präsentation
- Python
- Aspose.Slides für Python über .NET
description: "3D PowerPoint-Präsentation in Python"
---


## Überblick
Wie erstellen Sie normalerweise eine 3D PowerPoint-Präsentation?
Microsoft PowerPoint ermöglicht die Erstellung von 3D-Präsentationen, indem wir 3D-Modelle hinzufügen, 3D-Effekte auf Formen anwenden, 
3D-Text erstellen, 3D-Grafiken in die Präsentation hochladen und PowerPoint 3D-Animationen erstellen. 

Die Erstellung von 3D-Effekten hat einen großen Einfluss auf die Verbesserung Ihrer Präsentation zu einer 3D-Präsentation und kann die einfachste Implementierung einer 3D-Präsentation sein. 
Seit der Version 20.9 von Aspose.Slides wurde eine neue **plattformübergreifende 3D-Engine** hinzugefügt. Die neue 3D-Engine ermöglicht 
das Exportieren und Rasterisieren von Formen und Text mit 3D-Effekten. In den vorherigen Versionen 
wurden Slides-Formen mit angewendeten 3D-Effekten flach gerendert. Aber jetzt ist es möglich, 
Formen mit **vollwertigem 3D** zu rendern.
Darüber hinaus ist es jetzt möglich, Formen mit 3D-Effekten über die öffentliche API von Slides zu erstellen.

Im Aspose.Slides API, um 
eine Form zu einer PowerPoint 3D-Form zu machen, verwenden Sie die Eigenschaft [IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), 
die die Funktionen der Schnittstelle [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat) erbt:
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
und [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): Bevel auf die Form einstellen, Bevel-Typ definieren (z. B. Winkel, Kreis, SoftRound), Höhe und Breite des Bevels definieren.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): wird verwendet, um Kamerabewegungen um das Objekt zu imitieren. Mit anderen Worten, durch das Setzen von Kamerarotation, Zoom und anderen Eigenschaften - können Sie mit Ihren 
Formen wie mit dem 3D-Modell in PowerPoint spielen.
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
und [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): Kontureigenschaften einstellen, um die Form wie eine 3D PowerPoint-Form aussehen zu lassen.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/), 
[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
und [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): werden verwendet, um die Form dreidimensional zu machen, was bedeutet, eine 2D-Form in eine 3D-Form zu konvertieren, 
indem man ihre Tiefe oder Extrusion einstellt.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): kann einen Lichteffekt auf einer 3D-Form erzeugen. Die Logik dieser Eigenschaft ist der Kamera ähnlich, Sie können die Rotation des Lichts 
relativ zur 3D-Form einstellen und den Lichttyp auswählen.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): Durch das Einstellen des Typs des 3D-Formmaterials kann ein lebendigerer Effekt erzielt werden. Die Eigenschaft bietet eine Reihe vordefinierter Materialien, wie: 
Metall, Kunststoff, Pulver, Matt, usw.  

Alle 3D-Funktionen können sowohl auf Formen als auch auf Text angewendet werden. Lassen Sie uns sehen, wie man auf die oben genannten Eigenschaften zugreift und dann Schritt für Schritt detailliert darauf eingeht:
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

Das gerenderte Thumbnail sieht so aus:

![todo:image_alt_text](img_01_01.png)

## 3D-Rotation
Es ist möglich, PowerPoint 3D-Formen im 3D-Raum zu drehen, was mehr Interaktivität ermöglicht. Um eine 3D-Form in PowerPoint zu rotieren, verwenden Sie normalerweise das folgende Menü:

![todo:image_alt_text](img_02_01.png)

Im Aspose.Slides API kann die Rotation von 3D-Formen mithilfe der Eigenschaft [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) gesteuert werden:

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... andere 3D-Szenenparameter einstellen

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## 3D-Tiefe und Extrusion
Um der Form die dritte Dimension zu verleihen und sie zu einer 3D-Form zu machen, verwenden Sie die Eigenschaften [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
und [extrusion_color.color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... andere 3D-Szenenparameter einstellen

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

Normalerweise verwenden Sie das Tiefe-Menü in PowerPoint, um die Tiefe für die PowerPoint 3D-Form einzustellen:

![todo:image_alt_text](img_02_02.png)


## 3D-Gradient
Ein Farbverlauf kann verwendet werden, um die Farbe der PowerPoint 3D-Form zu füllen. Lassen Sie uns eine Form mit einem Farbverlauf-Füllfarbe erstellen und einen 3D-Effekt darauf anwenden:

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

Und hier ist das Ergebnis:

![todo:image_alt_text](img_02_03.png)

Außer einer Farbverlauf-Füllfarbe ist es möglich, Formen mit einem Bild zu füllen:
```py
with open("image.png", "rb") as image_file: 
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... 3D einrichten: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* Eigenschaften

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


So sieht es aus:

![todo:image_alt_text](img_02_04.png)

## 3D-Text (WordArt)
Aspose.Slides ermöglicht es auch, 3D auf Text anzuwenden. Um einen 3D-Text zu erstellen, kann der WordArt-Transformations-Effekt verwendet werden:

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
    # "Arch Up" WordArt-Transformations-Effekt einrichten
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

Hier ist das Ergebnis:

![todo:image_alt_text](img_02_05.png)


## Nicht Unterstützt - Bald Verfügbar
Die folgenden PowerPoint 3D-Funktionen werden noch nicht unterstützt: 
- Bevel
- Material
- Kontur
- Beleuchtung

Wir arbeiten weiterhin daran, unsere 3D-Engine zu verbessern, und diese Funktionen sind Gegenstand weiterer Implementierungen.