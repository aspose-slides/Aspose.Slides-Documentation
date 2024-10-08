---
title: Moderne API
type: docs
weight: 280
url: /de/python-net/modern-api/
keywords: "Moderne API, Zeichnen"
description: "Moderne API"
---

## Einführung

Derzeit hat die Aspose.Slides für Python über .NET-Bibliothek Abhängigkeiten in ihrer öffentlichen API von den folgenden Klassen aus `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Seit Version 24.4 wird diese öffentliche API aufgrund von [Änderungen](https://releases.aspose.com/slides/net/release-notes/2024/aspose-slides-for-net-24-4-release-notes/#introducing-a-new-modern-api) in der Aspose.Slides für .NET öffentlichen API als veraltet erklärt.

Um die Abhängigkeiten von `aspose.pydrawing` in der öffentlichen API zu beseitigen, haben wir die sogenannte "Moderne API" hinzugefügt. Methoden mit `aspose.pydrawing.Image` und `aspose.pydrawing.Bitmap` werden als veraltet erklärt und durch die entsprechenden Methoden aus der Modernen API ersetzt. Methoden mit `aspose.pydrawing.Graphics` werden als veraltet erklärt und ihre Unterstützung wird aus der öffentlichen API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten von `aspose.pydrawing` wird in der Veröffentlichung 24.8 erfolgen.

## Moderne API

Folgende Klassen und Enums wurden zur öffentlichen API hinzugefügt:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage) - repräsentiert das Raster- oder Vektorbild.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat) - repräsentiert das Dateiformat des Bildes.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images) - Methoden zur Instanziierung und Arbeit mit dem `IImage`-Interface.

Ein typisches Szenario zur Verwendung der neuen API könnte wie folgt aussehen:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
    with pres.slides[0].get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## Ersetzen alter Codes durch die Moderne API

Zur Erleichterung des Übergangs wiederholt die Schnittstelle des neuen `IImage` die separaten Signaturen der Klassen `Image` und `Bitmap`. Im Allgemeinen müssen Sie einfach den Aufruf der alten Methode mit `aspose.pydrawing` durch die neue ersetzen.

### Thumbnail eines Slides erhalten

Code, der eine veraltete API verwendet:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_thumbnail().save("slide1.png")
```

Moderne API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].get_image() as image:
        image.save("slide1.png")
```

### Thumbnail einer Form erhalten

Code, der eine veraltete API verwendet:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_thumbnail().save("shape.png")
```

Moderne API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].shapes[0].get_image() as image:
        image.save("shape.png")
```

### Thumbnail einer Präsentation erhalten

Code, der eine veraltete API verwendet:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", drawing.imaging.ImageFormat.png)
```

Moderne API:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", slides.ImageFormat.PNG)
```

### Ein Bild in eine Präsentation einfügen

Code, der eine veraltete API verwendet:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = drawing.Image.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

Moderne API:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

## Methoden/Eigenschaften, die entfernt werden sollen und ihre Ersetzung in der Modernen API

### Präsentationsklasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Wird vollständig gelöscht|
|save(fname, format, options, response, show_inline)|Wird vollständig gelöscht|
|print()|Wird vollständig gelöscht|
|print(printer_settings)|Wird vollständig gelöscht|
|print(printer_name)|Wird vollständig gelöscht|
|print(printer_settings, pres_name)|Wird vollständig gelöscht|

### Folienklasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Wird vollständig gelöscht|
|render_to_graphics(options, graphics, scale_x, scale_y)|Wird vollständig gelöscht|
|render_to_graphics(options, graphics, rendering_size)|Wird vollständig gelöscht|

### Formenklasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### ImageCollection-Klasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### PPImage-Klasse
|Methoden-/Eigenschaftensignatur|Ersatzmethoden-/Eigenschaftensignatur|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### ImageWrapperFactory-Klasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### PatternFormat-Klasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### IPatternFormatEffectiveData-Klasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### Ausgabe-Klasse
|Methoden-Signatur|Ersatzmethoden-Signatur|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## Die Unterstützung der API für `aspose.pydrawing.Graphics` wird eingestellt

Methoden mit `aspose.pydrawing.Graphics` werden als veraltet erklärt und ihre Unterstützung wird aus der öffentlichen API entfernt.

Der Teil der API, der dies verwendet, wird entfernt:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`