---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 280
url: /de/python-net/modern-api/
keywords:
- Moderne API
- Zeichnung
- Folien-Miniaturbild
- Folie zu Bild
- Shape-Miniaturbild
- Shape zu Bild
- Präsentations-Miniaturbild
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- Python
- Aspose.Slides
description: "Modernisieren Sie die Folienbildverarbeitung, indem Sie veraltete Bild-APIs durch die Python Moderne API für nahtlose PowerPoint- und OpenDocument‑Automatisierung ersetzen."
---
## **Einleitung**

Die Aspose.Slides für Python öffentliche API hängt derzeit von den folgenden `aspose.pydrawing`-Typen ab:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Ab Version 24.4 ist diese öffentliche API **veraltet** aufgrund von [Änderungen](https://releases.aspose.com/slides/de/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) in der Aspose.Slides für Python öffentlichen API.

Um `aspose.pydrawing` aus der öffentlichen API zu entfernen, haben wir die **Moderne API** eingeführt. Methoden, die `aspose.pydrawing.Image` und `aspose.pydrawing.Bitmap` verwenden, sind veraltet und sollten durch ihre Moderne API‑Entsprechungen ersetzt werden. Methoden, die `aspose.pydrawing.Graphics` verwenden, sind veraltet und haben keinen direkten Ersatz in der Modernen API.

In aktuellen Versionen behandeln Sie die öffentliche API, die von `aspose.pydrawing` abhängt, als legacy/veraltet. Verwenden Sie die Moderne API für neuen Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- [aspose.slides.IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) - stellt ein Raster‑ oder Vektorbild dar.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/imageformat/) - repräsentiert ein Bilddateiformat.
- [aspose.slides.Images](https://reference.aspose.com/slides/de/python-net/aspose.slides/images/) - bietet Methoden zum Erstellen und Arbeiten mit [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/).

Verwenden Sie `get_image`, um eine einzelne Folie oder ein Shape zu rendern. Verwenden Sie `get_images`, um mehrere Präsentationsfolien zu rendern. Verwenden Sie die [Images](https://reference.aspose.com/slides/de/python-net/aspose.slides/images/)‑Methoden, um Bilder zu laden, `add_image` mit [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) zum Hinzufügen zu einer Präsentation und `replace_image` mit [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) zum Aktualisieren eines bestehenden Präsentationsbildes.

Ein typisches Anwendungsbeispiel für die neue API sieht folgendermaßen aus:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Alten Code durch die Moderne API ersetzen**

Für einen einfacheren Übergang spiegelt die neue [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/)‑Klasse die separaten APIs der Klassen `aspose.pydrawing.Image` und `aspose.pydrawing.Bitmap` wider. In den meisten Fällen müssen Sie nur Aufrufe von Methoden, die `aspose.pydrawing` verwenden, durch deren Moderne API‑Entsprechungen ersetzen.

### **Ein Folien‑Miniaturbild erhalten**

**Veraltete API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Moderne API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Ein Shape‑Miniaturbild erhalten**

**Veraltete API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Moderne API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Ein Präsentations‑Miniaturbild erhalten**

**Veraltete API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Moderne API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Ein Bild zu einer Präsentation hinzufügen**

**Veraltete API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Moderne API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Methoden und Eigenschaften, die entfernt werden, und ihre modernen Ersatzmethoden**

### **Presentation‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Slide‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Shape‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage‑Klasse**

|Methoden/Eigenschaftssignatur|Ersetzungsmethoden/Eigenschaftssignatur|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/de/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/de/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output‑Klasse**

|Methodensignatur|Ersetzungsmethodensignatur|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/de/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **API‑Unterstützung für aspose.pydrawing.Graphics**

Methoden, die `aspose.pydrawing.Graphics` verwenden, sind veraltet und haben keinen direkten Ersatz in der Modernen API.

Verwenden Sie stattdessen die Bild‑Render‑Methoden der Modernen API anstelle der API, die zu `aspose.pydrawing.Graphics` rendert:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Warum wurde `aspose.pydrawing.Graphics` entfernt?**

Die Unterstützung für `aspose.pydrawing.Graphics` ist in der öffentlichen API veraltet, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, Abhängigkeiten von plattformspezifischen Bibliotheken zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) zu wechseln. Verwenden Sie `get_image` oder `get_images` anstelle des Renderns zu `aspose.pydrawing.Graphics`.

**Was ist der praktische Nutzen von [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) im Vergleich zu `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektor‑Bildern, vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/imageformat/), reduziert die Abhängigkeit von pydrawing und macht den Code portabler über verschiedene Umgebungen hinweg.

**Wird die Moderne API die Leistung beim Erzeugen von Miniaturbildern beeinflussen?**

Der Wechsel von `get_thumbnail` zu `get_image` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Erzeugung von Bildern mit Optionen und Größen, während sie weiterhin Rendering‑Optionen unterstützen. Der konkrete Gewinn oder Verlust hängt vom Einzelfall ab, funktional sind die Ersatzmethoden jedoch gleichwertig.