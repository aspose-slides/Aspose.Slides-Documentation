---
title: "Képfeldolgozás javítása a Modern API-val"
linktitle: "Modern API"
type: docs
weight: 280
url: /hu/python-net/modern-api/
keywords:
- "modern API"
- "rajzolás"
- "dia bélyegkép"
- "dia képpé alakítás"
- "alakzat bélyegkép"
- "alakzat képpé alakítás"
- "prezentáció bélyegkép"
- "prezentáció képekké alakítás"
- "kép hozzáadása"
- "kép beillesztése"
- "Python"
- "Aspose.Slides"
description: "Modernizálja a diák képfeldolgozását az elavult képkönyvtári API-k lecserélésével a Python Modern API-ra, a zökkenőmentes PowerPoint és OpenDocument automatizálás érdekében."
---
## **Bevezetés**

Az Aspose.Slides for Python nyilvános API-ja jelenleg a következő `aspose.pydrawing` típusoktól függ:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

A 24.4-es verziótól ez a nyilvános API **elavult**, a [változások](https://releases.aspose.com/slides/hu/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) miatt az Aspose.Slides for Python nyilvános API-jában.

Az `aspose.pydrawing` eltávolításához a nyilvános API-ból bevezettük a **Modern API**-t. Az `aspose.pydrawing.Image` és `aspose.pydrawing.Bitmap` használatával járó metódusok elavultak, és helyettük a Modern API megfelelőit kell használni. Az `aspose.pydrawing.Graphics` használatával járó metódusok elavultak, és közvetlen Modern API helyettesítőjük nincs.

A jelenlegi verziókban tekintse a `aspose.pydrawing`-tól függő nyilvános API-t örököltnek/elavultnak. Új kódhoz és a meglévő képfeldolgozó munkafolyamatok migrálásához használja a Modern API-t.

## **Modern API**

A következő osztályok és felsorolások kerültek hozzáadásra a nyilvános API-hoz:

- [aspose.slides.IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) – raszteres vagy vektor kép.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imageformat/) – képfájl formátum.
- [aspose.slides.Images](https://reference.aspose.com/slides/hu/python-net/aspose.slides/images/) – metódusokat biztosít a [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) létrehozásához és kezeléséhez.

Használja a `get_image` metódust egyetlen dia vagy alakzat rendereléséhez. A `get_images` metódust több prezentációs dia rendereléséhez. Használja az [Images](https://reference.aspose.com/slides/hu/python-net/aspose.slides/images/) metódusait képek betöltéséhez, az `add_image`-t [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) segítségével a prezentációhoz való hozzáadáshoz, és a `replace_image`-t [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) segítségével egy meglévő prezentációs kép frissítéséhez.

Egy tipikus felhasználási példa az új API-hoz a következő:

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

## **Régi kód lecserélése Modern API-val**

A könnyebb átállás érdekében az új [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) osztály tükrözi az `aspose.pydrawing.Image` és `aspose.pydrawing.Bitmap` osztályok különálló API-jait. A legtöbb esetben csak a `aspose.pydrawing`-ot használó metódushívásokat kell lecserélni a Modern API megfelelőire.

### **Dia bélyegkép lekérése**

**Elavult API:**

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

### **Alakzat bélyegkép lekérése**

**Elavult API:**

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

### **Prezentáció bélyegkép lekérése**

**Elavult API:**

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

### **Kép hozzáadása egy prezentációhoz**

**Elavult API:**

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

## **Eltávolítandó metódusok és tulajdonságok, valamint azok Modern helyettesítései**

### **Presentation osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Slide osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Shape osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage osztály**

|Metódus/Tulajdonság aláírás|Helyettesítő metódus/tulajdonság aláírás|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output osztály**

|Metódus aláírás|Helyettesítő metódus aláírás|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **API támogatás az aspose.pydrawing.Graphics számára**

Az `aspose.pydrawing.Graphics`-et használó metódusok elavultak, és közvetlen Modern API helyettesítőjük nincs.

Használja a Modern API képrenderelő metódusait a `aspose.pydrawing.Graphics`-re történő renderelés helyett:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **GYIK**

**Miért lett eltávolítva az `aspose.pydrawing.Graphics`?**

Az `aspose.pydrawing.Graphics` támogatása elavult a nyilvános API-ban, hogy egységesítsék a renderelést és a képek kezelését, megszüntessék a platformfüggő függőségeket, és a [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) használatával keresztplatformos megközelítésre váltsanak. Használja a `get_image` vagy `get_images` metódusokat a `aspose.pydrawing.Graphics` helyett.

**Mi a gyakorlati előnye az [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/)nek a `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`-hez képest?**

Az [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) egységesíti a raszteres és vektor képek kezelését, egyszerűsíti a különböző formátumokba való mentést a [ImageFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imageformat/) segítségével, csökkenti a pydrawing függőséget, és a kód hordozhatóbbá válik a különböző környezetekben.

**Hatással lesz a Modern API a bélyegképek generálásának teljesítményére?**

A `get_thumbnail`-ról `get_image`-re váltás nem rontja a teljesítményt: az új metódusok ugyanazokat a lehetőségeket biztosítják a képek előállításához opciókkal és méretekkel, miközben megtartják a renderelési beállítások támogatását. A konkrét nyereség vagy csökkenés a forgatókönyvtől függ, de funkcionálisan a helyettesítések egyenértékűek.