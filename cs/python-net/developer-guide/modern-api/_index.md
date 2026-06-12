---
title: Vylepšení zpracování obrazu pomocí Moderního API
linktitle: Moderní API
type: docs
weight: 280
url: /cs/python-net/modern-api/
keywords:
- moderní API
- kreslení
- miniatura snímku
- snímek na obrázek
- miniatura tvaru
- tvar na obrázek
- miniatura prezentace
- prezentace na obrázky
- přidat obrázek
- přidat obrázek
- Python
- Aspose.Slides
description: "Modernizujte zpracování snímků nahrazením zastaralých API pro obrázky Moderním Python API pro bezproblémovou automatizaci PowerPoint a OpenDocument."
---
## **Úvod**

Veřejné API Aspose.Slides pro Python v současné době závisí na následujících typech `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Od verze 24.4 je toto veřejné API **zastaralé** kvůli [změnám](https://releases.aspose.com/slides/cs/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) v veřejném API Aspose.Slides pro Python.

Abychom odstranili `aspose.pydrawing` z veřejného API, zavedli jsme **Moderní API**. Metody, které používají `aspose.pydrawing.Image` a `aspose.pydrawing.Bitmap`, jsou zastaralé a měly by být nahrazeny jejich ekvivalenty v Moderním API. Metody, které používají `aspose.pydrawing.Graphics`, jsou zastaralé a nemají přímou náhradu v Moderním API.

V aktuálních verzích považujte veřejné API, které závisí na `aspose.pydrawing`, za starší/zastaralé. Pro nový kód i při migraci existujících pracovních toků zpracování obrázků používejte Moderní API.

## **Moderní API**

Do veřejného API byly přidány následující třídy a výčty:

- [aspose.slides.IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) – představuje rastrový nebo vektorový obrázek.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imageformat/) – představuje formát souboru obrázku.
- [aspose.slides.Images](https://reference.aspose.com/slides/cs/python-net/aspose.slides/images/) – poskytuje metody pro vytváření a práci s [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/).

Použijte `get_image` pro vykreslení jediného snímku nebo tvaru. Použijte `get_images` pro vykreslení několika snímků prezentace. Použijte metody z [Images](https://reference.aspose.com/slides/cs/python-net/aspose.slides/images/) pro načtení obrázků, `add_image` s [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) pro jejich přidání do prezentace a `replace_image` s [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) pro aktualizaci existujícího obrázku v prezentaci.

Typický scénář použití nového API vypadá takto:

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

## **Nahraďte starý kód Moderním API**

Pro snazší přechod nová třída [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) odráží samostatná API tříd `aspose.pydrawing.Image` a `aspose.pydrawing.Bitmap`. Ve většině případů stačí nahradit volání metod, které používají `aspose.pydrawing`, jejich ekvivalenty v Moderním API.

### **Získat miniaturu snímku**

**Zastaralé API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Moderní API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Získat miniaturu tvaru**

**Zastaralé API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Moderní API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Získat miniaturu prezentace**

**Zastaralé API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Moderní API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Přidat obrázek do prezentace**

**Zastaralé API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Moderní API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Metody a vlastnosti, které mají být odstraněny, a jejich moderní náhrady**

### **Presentation Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Žádná moderní náhrada API|
|save(fname, format, options, response, show_inline)|Žádná moderní náhrada API|
|print()|Žádná moderní náhrada API|
|print(printer_settings)|Žádná moderní náhrada API|
|print(printer_name)|Žádná moderní náhrada API|
|print(printer_settings, pres_name)|Žádná moderní náhrada API|

### **Slide Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Žádná moderní náhrada API|
|render_to_graphics(options, graphics, scale_x, scale_y)|Žádná moderní náhrada API|
|render_to_graphics(options, graphics, rendering_size)|Žádná moderní náhrada API|

### **Shape Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage Class**

|Podpis metody/vlastnosti|Podpis náhradní metody/vlastnosti|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output Class**

|Podpis metody|Podpis náhradní metody|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Podpora API pro aspose.pydrawing.Graphics**

Metody, které používají `aspose.pydrawing.Graphics`, jsou zastaralé a nemají přímou moderní náhradu API.

Použijte metody pro vykreslování obrázků Moderního API místo API, které vykresluje do `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **Často kladené otázky**

**Proč byl `aspose.pydrawing.Graphics` odstraněn?**

Podpora pro `aspose.pydrawing.Graphics` je ve veřejném API zastaralá, aby se sjednotilo vykreslování a práce s obrázky, odstranily se vazby na platformově specifické závislosti a přešlo se na multiplatformní přístup s [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/). Používejte `get_image` nebo `get_images` místo vykreslování do `aspose.pydrawing.Graphics`.

**Jaký je praktický přínos [IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) ve srovnání s `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iimage/) spojuje práci s rastrovými i vektorovými obrázky, zjednodušuje ukládání do různých formátů pomocí [ImageFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imageformat/), snižuje závislost na pydrawing a činí kód přenosnějším mezi různými prostředími.

**Ovlivní Moderní API výkon generování miniatur?**

Přechod z `get_thumbnail` na `get_image` nezhoršuje scénáře: nové metody poskytují stejné možnosti pro vytváření obrázků s volbami a velikostmi a stále podporují možnosti vykreslování. Konkrétní zisk nebo ztráta závisí na konkrétní situaci, ale funkčně jsou náhrady ekvivalentní.