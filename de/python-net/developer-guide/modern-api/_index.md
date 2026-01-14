---
title: Verbessern Sie die Bildverarbeitung mit der Modernen API
linktitle: Moderne API
type: docs
weight: 280
url: /de/python-net/modern-api/
keywords:
- moderne API
- Zeichnen
- Folien-Miniaturansicht
- Folie zu Bild
- Form-Miniaturansicht
- Form zu Bild
- Präsentations-Miniaturansicht
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- Python
- Aspose.Slides
description: "Modernisieren Sie die Folien-Bildverarbeitung, indem Sie veraltete Bild-APIs durch die Python Moderne API ersetzen, um eine nahtlose PowerPoint- und OpenDocument-Automatisierung zu ermöglichen."
---

## **Einleitung**

Die öffentliche API von Aspose.Slides für Python hängt derzeit von den folgenden `aspose.pydrawing`-Typen ab:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Ab Version 24.4 ist diese öffentliche API **veraltet** aufgrund von [Änderungen](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) in der Aspose.Slides für Python öffentlichen API.

Um `aspose.pydrawing` aus der öffentlichen API zu entfernen, haben wir die **Modern API** eingeführt. Methoden, die `aspose.pydrawing.Image` und `aspose.pydrawing.Bitmap` verwenden, sind veraltet und werden durch ihre Modern API‑Entsprechungen ersetzt. Methoden, die `aspose.pydrawing.Graphics` verwenden, sind veraltet und die Unterstützung dafür wird aus der öffentlichen API entfernt.

Die Entfernung der veralteten API, die von `aspose.pydrawing` abhängt, ist für die Veröffentlichung **24.8** geplant.

## **Moderne API**

Die folgenden Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — repräsentiert ein Raster- oder Vektorbild.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — repräsentiert ein Bilddateiformat.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — stellt Methoden zum Erstellen und Arbeiten mit `IImage` bereit.

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

Für einen einfacheren Übergang spiegelt die neue Klasse `IImage` die separaten APIs der Klassen `Image` und `Bitmap` wider. In den meisten Fällen müssen Sie nur Aufrufe von Methoden, die `aspose.pydrawing` verwenden, durch ihre Moderne API‑Entsprechungen ersetzen.

### **Miniaturansicht einer Folie erhalten**

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


### **Miniaturansicht einer Form erhalten**

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


### **Miniaturansicht einer Präsentation erhalten**

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

### **Presentation Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Will be deleted completely|
|save(fname, format, options, response, show_inline)|Will be deleted completely|
|print()|Will be deleted completely|
|print(printer_settings)|Will be deleted completely|
|print(printer_name)|Will be deleted completely|
|print(printer_settings, pres_name)|Will be deleted completely|

### **Slide Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Will be deleted completely|
|render_to_graphics(options, graphics, scale_x, scale_y)|Will be deleted completely|
|render_to_graphics(options, graphics, rendering_size)|Will be deleted completely|

### **Shape Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage Class**

|Methoden-/Eigenschaftssignatur|Ersatzmethoden-/Eigenschaftssignatur|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output Class**

|Methodensignatur|Ersatzmethodensignatur|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Unterstützung für aspose.pydrawing.Graphics wird eingestellt**

Methoden, die `aspose.pydrawing.Graphics` verwenden, sind veraltet; die Unterstützung hierfür wird aus der öffentlichen API entfernt.

Die API-Mitglieder, die von `aspose.pydrawing.Graphics` abhängen und entfernt werden, umfassen:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Warum wurde aspose.pydrawing.Graphics entfernt?**

Die Unterstützung für Graphics wird aus der öffentlichen API entfernt, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, Abhängigkeiten von plattformspezifischen Komponenten zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) zu wechseln. Alle Rendering‑Methoden für Graphics werden entfernt.

**Was ist der praktische Nutzen von IImage im Vergleich zu Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektorbildern, vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), reduziert die Abhängigkeit von pydrawing und macht den Code in verschiedenen Umgebungen portabler.

**Wird die Moderne API die Performance bei der Erstellung von Miniaturansichten beeinflussen?**

Der Wechsel von `get_thumbnail` zu `get_image` verschlechtert die Szenarien nicht: Die neuen Methoden bieten die gleichen Möglichkeiten, Bilder mit Optionen und Größen zu erzeugen, und behalten die Unterstützung für Rendering‑Optionen bei. Der konkrete Nutzen oder Nachteil hängt vom jeweiligen Szenario ab, funktional sind die Ersatzmethoden jedoch gleichwertig.