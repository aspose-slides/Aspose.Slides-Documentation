---
title: "Optimieren Sie die Bildverarbeitung mit der Modernen API"
linktitle: "Moderne API"
type: docs
weight: 280
url: /de/python-net/modern-api/
keywords:
  - "moderne API"
  - "Zeichnung"
  - "Folie Miniaturbild"
  - "Folie zu Bild"
  - "Form Miniaturbild"
  - "Form zu Bild"
  - "Präsentation Miniaturbild"
  - "Präsentation zu Bildern"
  - "Bild hinzufügen"
  - "Bild einfügen"
  - "Python"
  - "Aspose.Slides"
description: "Modernisieren Sie die Folienbildverarbeitung, indem Sie die veralteten Bild‑APIs durch die Python Moderne API ersetzen, um eine nahtlose PowerPoint‑ und OpenDocument‑Automatisierung zu ermöglichen."
---

## **Einleitung**

Die öffentliche API von Aspose.Slides für Python hängt derzeit von den folgenden `aspose.pydrawing`‑Typen ab:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Ab Version 24.4 ist diese öffentliche API **veraltet** wegen [Änderungen](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) in der Aspose.Slides für Python‑Public‑API.

Um `aspose.pydrawing` aus der öffentlichen API zu entfernen, haben wir die **Moderne API** eingeführt. Methoden, die `aspose.pydrawing.Image` und `aspose.pydrawing.Bitmap` verwenden, sind veraltet und werden durch ihre Gegenstücke der Modernen API ersetzt. Methoden, die `aspose.pydrawing.Graphics` verwenden, sind veraltet und die Unterstützung dafür wird aus der öffentlichen API entfernt.

Das Entfernen der veralteten API, die von `aspose.pydrawing` abhängt, ist für die Veröffentlichung **24.8** geplant.

## **Moderne API**

Die folgenden Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — stellt ein Raster‑ oder Vektorbild dar.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — stellt ein Bilddateiformat dar.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — bietet Methoden zum Erstellen und Arbeiten mit `IImage`.

Ein typisches Anwendungsszenario für die neue API sieht so aus:
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

Für einen einfacheren Umstieg spiegelt das neue `IImage`‑Interface die getrennten APIs der Klassen `Image` und `Bitmap` wider. In den meisten Fällen müssen Sie lediglich Aufrufe von Methoden, die `aspose.pydrawing` verwenden, durch deren Gegenstücke der Modernen API ersetzen.

### **Ein Folien‑Thumbnail abrufen**

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


### **Ein Shape‑Thumbnail abrufen**

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


### **Ein Präsentations‑Thumbnail abrufen**

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


## **Methoden und Eigenschaften, die entfernt werden, und deren Moderne Ersatzmethoden**

### **Presentation‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
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

### **Slide‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
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

### **Shape‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage‑Klasse**

|Methoden-/Eigenschaftssignatur|Ersatz-Methoden-/Eigenschaftssignatur|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output‑Klasse**

|Methodensignatur|Ersatz-Methodensignatur|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Unterstützung für aspose.pydrawing.Graphics wird eingestellt**

Methoden, die `aspose.pydrawing.Graphics` verwenden, sind veraltet; die Unterstützung dafür wird aus der öffentlichen API entfernt.

Die API‑Elemente, die von `aspose.pydrawing.Graphics` abhängen und entfernt werden, umfassen:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Warum wurde aspose.pydrawing.Graphics entfernt?**

Die Unterstützung für Graphics wird aus der öffentlichen API entfernt, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, Abhängigkeiten von plattformspezifischen Bibliotheken zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) zu wechseln. Alle Rendering‑Methoden zu Graphics werden entfernt.

**Welchen praktischen Nutzen bietet IImage im Vergleich zu Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektorbildern, vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), reduziert die Abhängigkeit von pydrawing und macht den Code portabler über verschiedene Umgebungen hinweg.

**Beeinflusst die Moderne API die Performance bei der Erstellung von Thumbnails?**

Der Wechsel von `get_thumbnail` zu `get_image` verschlechtert die Szenarien nicht: Die neuen Methoden bieten die gleichen Möglichkeiten zur Bildgenerierung mit Optionen und Größen, während weiterhin Rendering‑Optionen unterstützt werden. Der konkrete Gewinn oder Verlust hängt vom Einzelfall ab, funktional sind die Ersatzmethoden jedoch äquivalent.