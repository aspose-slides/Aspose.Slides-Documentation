---
title: Ulepsz przetwarzanie obrazów przy użyciu nowoczesnego API
linktitle: Nowoczesne API
type: docs
weight: 280
url: /pl/python-net/modern-api/
keywords:
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd do obrazu
- miniatura kształtu
- kształt do obrazu
- miniatura prezentacji
- prezentacja do obrazów
- dodaj obraz
- dodaj zdjęcie
- Python
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe interfejsy API przetwarzania obrazów nowoczesnym API Pythona dla płynnej automatyzacji PowerPoint i OpenDocument."
---
## **Wstęp**

Publiczne API Aspose.Slides for Python obecnie zależy od następujących typów `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Od wersji 24.4 to publiczne API jest **przestarzałe** z powodu [zmian](https://releases.aspose.com/slides/pl/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) w publicznym API Aspose.Slides for Python.

Aby wyeliminować `aspose.pydrawing` z publicznego API, wprowadziliśmy **Nowoczesne API**. Metody używające `aspose.pydrawing.Image` i `aspose.pydrawing.Bitmap` są przestarzałe i powinny zostać zastąpione ich odpowiednikami w Nowoczesnym API. Metody używające `aspose.pydrawing.Graphics` są przestarzałe i nie mają bezpośredniego zamiennika w Nowoczesnym API.

W bieżących wersjach traktuj publiczne API zależne od `aspose.pydrawing` jako dziedzictwo/przestarzałe. Używaj Nowoczesnego API w nowym kodzie oraz przy migracji istniejących przepływów przetwarzania obrazów.

## **Nowoczesne API**

Do publicznego API dodano następujące klasy i wyliczenia:

- [aspose.slides.IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) - reprezentuje obraz rastrowy lub wektorowy.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imageformat/) - reprezentuje format pliku obrazu.
- [aspose.slides.Images](https://reference.aspose.com/slides/pl/python-net/aspose.slides/images/) - udostępnia metody do tworzenia i pracy z [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/).

Użyj `get_image`, aby wyrenderować pojedynczy slajd lub kształt. Użyj `get_images`, aby wyrenderować kilka slajdów prezentacji. Użyj metod [Images](https://reference.aspose.com/slides/pl/python-net/aspose.slides/images/) do ładowania obrazów, `add_image` z [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) aby dodać je do prezentacji oraz `replace_image` z [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) aby zaktualizować istniejący obraz w prezentacji.

Typowy scenariusz użycia nowego API wygląda następująco:

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

## **Zastąp stary kod nowoczesnym API**

Aby ułatwić przejście, nowa klasa [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) odzwierciedla odrębne API klas `aspose.pydrawing.Image` i `aspose.pydrawing.Bitmap`. W większości przypadków wystarczy zamienić wywołania metod używających `aspose.pydrawing` na ich odpowiedniki w Nowoczesnym API.

### **Pobierz miniaturę slajdu**

**Przestarzałe API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Nowoczesne API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Pobierz miniaturę kształtu**

**Przestarzałe API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Nowoczesne API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Pobierz miniaturę prezentacji**

**Przestarzałe API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Nowoczesne API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Dodaj obraz do prezentacji**

**Przestarzałe API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Nowoczesne API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Metody i właściwości do usunięcia oraz ich nowoczesne zamienniki**

### **Klasa Presentation**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Klasa Slide**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Klasa Shape**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Klasa ImageCollection**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Klasa PPImage**

|Sygnatura metody/właściwości|Zastępcza sygnatura metody/właściwości|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/image/)|

### **Klasa ImageWrapperFactory**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Klasa PatternFormat**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Klasa IPatternFormatEffectiveData**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Klasa Output**

|Sygnatura metody|Zastępcza sygnatura metody|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Obsługa API dla aspose.pydrawing.Graphics**

Metody używające `aspose.pydrawing.Graphics` są przestarzałe i nie mają bezpośredniego zamiennika w Nowoczesnym API.

Użyj metod renderujących obrazy w Nowoczesnym API zamiast API renderującego do `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Dlaczego `aspose.pydrawing.Graphics` został usunięty?**

Obsługa `aspose.pydrawing.Graphics` jest przestarzała w publicznym API, aby ujednolicić pracę z renderowaniem i obrazami, wyeliminować zależności od specyficznych platform oraz przejść na podejście wieloplatformowe z [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/). Użyj `get_image` lub `get_images` zamiast renderowania do `aspose.pydrawing.Graphics`.

**Jaka jest praktyczna korzyść z [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) w porównaniu do `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) ujednolica pracę zarówno z obrazami rastrowymi, jak i wektorowymi, upraszcza zapisywanie w różnych formatach za pomocą [ImageFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imageformat/), zmniejsza zależność od pydrawing i sprawia, że kod jest bardziej przenośny między środowiskami.

**Czy nowoczesne API wpłynie na wydajność generowania miniatur?**

Przejście z `get_thumbnail` na `get_image` nie pogarsza scenariuszy: nowe metody zapewniają te same możliwości tworzenia obrazów z opcjami i rozmiarami, zachowując wsparcie dla opcji renderowania. Konkretne zyski lub straty zależą od scenariusza, ale funkcjonalnie zamienniki są równoważne.