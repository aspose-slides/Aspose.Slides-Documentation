---
title: Förbättra bildbehandling med det moderna API:et
linktitle: Modernt API
type: docs
weight: 280
url: /sv/python-net/modern-api/
keywords:
- modernt API
- ritning
- bildspelsida miniatyr
- bildspelsida till bild
- form miniatyr
- form till bild
- presentation miniatyr
- presentation till bilder
- lägga till bild
- lägga till foto
- Python
- Aspose.Slides
description: "Modernisera bildspels bildbehandling genom att ersätta föråldrade bild‑API:er med det svenska Moderna API:t för sömlös PowerPoint‑ och OpenDocument‑automatisering."
---
## **Introduktion**

Det offentliga API:t för Aspose.Slides för Python är för närvarande beroende av följande `aspose.pydrawing`‑typer:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Från och med version 24.4 är detta offentliga API **föråldrat** på grund av [ändringar](https://releases.aspose.com/slides/sv/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) i det offentliga API:t för Aspose.Slides för Python.

För att eliminera `aspose.pydrawing` från det offentliga API:t introducerade vi **Modern API**. Metoder som använder `aspose.pydrawing.Image` och `aspose.pydrawing.Bitmap` är föråldrade och bör ersättas av deras motsvarande Modern API‑metoder. Metoder som använder `aspose.pydrawing.Graphics` är föråldrade och har ingen direkt Modern API‑ersättning.

I nuvarande versioner bör det offentliga API:t som är beroende av `aspose.pydrawing` betraktas som legacy/föråldrat. Använd Modern API för ny kod och när du migrerar befintliga bildbehandlingsarbetsflöden.

## **Modern API**

Följande klasser och uppräkningar har lagts till i det offentliga API:t:
- [aspose.slides.IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) – representerar en raster‑ eller vektorbild.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imageformat/) – representerar ett bildfilformat.
- [aspose.slides.Images](https://reference.aspose.com/slides/sv/python-net/aspose.slides/images/) – tillhandahåller metoder för att skapa och arbeta med [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/).

Använd `get_image` för att rendera en enda bildspelsida eller form. Använd `get_images` för att rendera flera presentation‑bilder. Använd [Images](https://reference.aspose.com/slides/sv/python-net/aspose.slides/images/)‑metoder för att läsa in bilder, `add_image` med [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) för att lägga till dem i en presentation, och `replace_image` med [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) för att uppdatera en befintlig presentationsbild.

Ett typiskt användningsscenario för det nya API:t ser ut så här:

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

## **Byt ut gammal kod mot Modern API**

För en enklare övergång speglar den nya [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/)‑klassen de separata API:erna för `aspose.pydrawing.Image` och `aspose.pydrawing.Bitmap`. I de flesta fall behöver du bara ersätta anrop till metoder som använder `aspose.pydrawing` med deras motsvarande Modern API‑metoder.

### **Hämta en bildspelsida miniatyr**

**Föråldrat API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Hämta en form miniatyr**

**Föråldrat API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Hämta en presentation miniatyr**

**Föråldrat API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Lägg till en bild i en presentation**

**Föråldrat API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Metoder och egenskaper som ska tas bort och deras moderna ersättningar**

### **Presentation‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Slide‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Shape‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage‑klass**

|Metod/Egendomssignatur|Ersättningsmetod/Egendomssignatur|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output‑klass**

|Metodsignatur|Ersättningsmetodsignatur|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **API‑stöd för aspose.pydrawing.Graphics**

Metoder som använder `aspose.pydrawing.Graphics` är föråldrade och har ingen direkt Modern API‑ersättning.

Använd Modern API:s bildrenderingsmetoder i stället för API:t som renderar till `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **Vanliga frågor**

**Varför togs `aspose.pydrawing.Graphics` bort?**

Stödet för `aspose.pydrawing.Graphics` är föråldrat i det offentliga API:t för att förena rendering och bildhantering, eliminera beroenden till plattforms‑specifika komponenter och gå över till ett plattformsoberoende tillvägagångssätt med [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/). Använd `get_image` eller `get_images` i stället för att rendera till `aspose.pydrawing.Graphics`.

**Vilken praktisk nytta ger [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) jämfört med `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) förenar arbete med både raster‑ och vektorbilder, förenklar sparande till olika format via [ImageFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imageformat/), minskar beroendet av pydrawing och gör koden mer portabel mellan miljöer.

**Kommer Modern API att påverka prestandan för att generera miniatyrer?**

Att byta från `get_thumbnail` till `get_image` försämrar inte scenarierna: de nya metoderna erbjuder samma funktionalitet för att producera bilder med alternativ och storlekar, samtidigt som stöd för renderingsalternativ behålls. Den specifika vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna ekvivalenta.