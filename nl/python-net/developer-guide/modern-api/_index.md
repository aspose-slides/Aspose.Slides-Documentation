---
title: Verbeter beeldverwerking met de Moderne API
linktitle: Moderne API
type: docs
weight: 280
url: /nl/python-net/modern-api/
keywords:
- moderne API
- tekening
- dia‑miniatuur
- dia naar afbeelding
- vorm‑miniatuur
- vorm naar afbeelding
- presentatie‑miniatuur
- presentatie naar afbeeldingen
- afbeelding toevoegen
- foto toevoegen
- Python
- Aspose.Slides
description: "Moderniseer beeldverwerking van dia's door verouderde beeld‑API's te vervangen door de Python Moderne API voor naadloze automatisering van PowerPoint en OpenDocument."
---
## **Introductie**

De openbare API van Aspose.Slides voor Python maakt momenteel gebruik van de volgende `aspose.pydrawing` typen:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Vanaf versie 24.4 is deze openbare API **verouderd** vanwege [changes](https://releases.aspose.com/slides/nl/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) in de openbare API van Aspose.Slides voor Python.

Om `aspose.pydrawing` uit de openbare API te verwijderen, hebben we de **Modern API** geïntroduceerd. Methoden die `aspose.pydrawing.Image` en `aspose.pydrawing.Bitmap` gebruiken, zijn verouderd en moeten worden vervangen door hun Modern API‑equivalenten. Methoden die `aspose.pydrawing.Graphics` gebruiken, zijn verouderd en hebben geen directe Modern API‑vervanging.

In de huidige versies moet de openbare API die afhankelijk is van `aspose.pydrawing` worden beschouwd als legacy/verouderd. Gebruik de Modern API voor nieuwe code en bij het migreren van bestaande beeldverwerkings‑workflows.

## **Moderne API**

De volgende klassen en enumeraties zijn toegevoegd aan de openbare API:

- [aspose.slides.IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) - stelt een raster- of vectorafbeelding voor.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imageformat/) - stelt een afbeeldingbestandformaat voor.
- [aspose.slides.Images](https://reference.aspose.com/slides/nl/python-net/aspose.slides/images/) - biedt methoden om te creëren en te werken met [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/).

Gebruik `get_image` om een enkele dia of vorm te renderen. Gebruik `get_images` om meerdere presentatiedia's te renderen. Gebruik de methoden van [Images](https://reference.aspose.com/slides/nl/python-net/aspose.slides/images/) om afbeeldingen te laden, `add_image` met [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `replace_image` met [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) om een bestaande afbeelding in de presentatie bij te werken.

Een typisch gebruiksscenario voor de nieuwe API ziet er als volgt uit:

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

## **Vervang oude code door de Moderne API**

Voor een eenvoudigere overgang spiegelt de nieuwe klasse [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) de afzonderlijke API's van de `aspose.pydrawing.Image`- en `aspose.pydrawing.Bitmap`-klassen. In de meeste gevallen hoef je alleen de aanroepen van methoden die `aspose.pydrawing` gebruiken te vervangen door hun Modern API‑equivalenten.

### **Een dia‑miniatuur ophalen**

**Verouderde API:**

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

### **Een vorm‑miniatuur ophalen**

**Verouderde API:**

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

### **Een presentatieminiatuur ophalen**

**Verouderde API:**

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

### **Een afbeelding toevoegen aan een presentatie**

**Verouderde API:**

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

## **Methoden en eigenschappen die verwijderd worden en hun moderne vervangingen**

### **Presentatie‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Geen Modern API‑vervanging|
|save(fname, format, options, response, show_inline)|Geen Modern API‑vervanging|
|print()|Geen Modern API‑vervanging|
|print(printer_settings)|Geen Modern API‑vervanging|
|print(printer_name)|Geen Modern API‑vervanging|
|print(printer_settings, pres_name)|Geen Modern API‑vervanging|

### **Dia‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Geen Modern API‑vervanging|
|render_to_graphics(options, graphics, scale_x, scale_y)|Geen Modern API‑vervanging|
|render_to_graphics(options, graphics, rendering_size)|Geen Modern API‑vervanging|

### **Vorm‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage‑klasse**

|Methode/eigenschap‑handtekening|Vervangende methode/eigenschap‑handtekening|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output‑klasse**

|Methode‑handtekening|Vervangende methode‑handtekening|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **API‑ondersteuning voor aspose.pydrawing.Graphics**

Methoden die `aspose.pydrawing.Graphics` gebruiken, zijn verouderd en hebben geen directe Modern API‑vervanging.

Gebruik de Modern API‑methoden voor afbeeldingsrendering in plaats van de API die rendert naar `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Waarom is `aspose.pydrawing.Graphics` verwijderd?**

Ondersteuning voor `aspose.pydrawing.Graphics` is verouderd in de openbare API om het werk met rendering en afbeeldingen te uniformiseren, afhankelijkheden van platform‑specifieke componenten te elimineren en over te schakelen op een platform‑onafhankelijke aanpak met [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/). Gebruik `get_image` of `get_images` in plaats van te renderen naar `aspose.pydrawing.Graphics`.

**Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) ten opzichte van `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) unificeert het werken met zowel raster‑ als vectorafbeeldingen, vereenvoudigt het opslaan naar verschillende formaten via [ImageFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imageformat/), vermindert de afhankelijkheid van pydrawing en maakt code draagbaarder over verschillende omgevingen.

**Zal de Moderne API de prestaties van het genereren van miniaturen beïnvloeden?**

Het overschakelen van `get_thumbnail` naar `get_image` verslechtert de scenario's niet: de nieuwe methoden bieden dezelfde mogelijkheden om afbeeldingen te produceren met opties en afmetingen, terwijl ze de ondersteuning voor render‑opties behouden. Het specifieke winst‑ of verliespercentage hangt af van het scenario, maar functioneel zijn de vervangingen gelijkwaardig.