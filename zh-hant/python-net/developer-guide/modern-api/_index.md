---
title: 使用現代 API 強化影像處理
linktitle: 現代 API
type: docs
weight: 280
url: /zh-hant/python-net/modern-api/
keywords:
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉圖像
- 形狀縮圖
- 形狀轉圖像
- 簡報縮圖
- 簡報轉圖像
- 新增影像
- 新增圖片
- Python
- Aspose.Slides
description: "透過使用 Python 現代 API 取代已棄用的影像 API，現代化投影片影像處理，實現無縫的 PowerPoint 與 OpenDocument 自動化。"
---
## **簡介**

Aspose.Slides for Python 的公開 API 目前依賴以下 `aspose.pydrawing` 類型：
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

從 24.4 版開始，該公開 API 因為 [變更](https://releases.aspose.com/slides/zh-hant/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) 而 **已棄用**。

為了將 `aspose.pydrawing` 從公開 API 中移除，我們引入了 **Modern API**。使用 `aspose.pydrawing.Image` 和 `aspose.pydrawing.Bitmap` 的方法已棄用，應改為使用其 Modern API 等價方法。使用 `aspose.pydrawing.Graphics` 的方法已棄用，且沒有直接的 Modern API 替代。

在當前版本中，將依賴 `aspose.pydrawing` 的公開 API 視為遺留/已棄用。對於新程式碼以及遷移現有影像處理工作流程時，請使用 Modern API。

## **Modern API**

已在公開 API 中加入以下類別與列舉：

- [aspose.slides.IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) - 代表光柵或向量圖像。
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imageformat/) - 代表圖像檔案格式。
- [aspose.slides.Images](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/images/) - 提供建立和使用 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 的方法。

使用 `get_image` 來呈現單一投影片或形狀。使用 `get_images` 來呈現多個投影片。使用 [Images](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/images/) 方法載入圖像，使用 `add_image` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 將圖像加入投影片，並使用 `replace_image` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 更新現有投影片圖像。

新 API 的典型使用情境如下：

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

## **以現代 API 取代舊程式碼**

為了更容易過渡，新 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 類別鏡像了 `aspose.pydrawing.Image` 與 `aspose.pydrawing.Bitmap` 兩個獨立 API。在大多數情況下，只需將使用 `aspose.pydrawing` 的方法呼叫替換為其 Modern API 等價方法。

### **取得投影片縮圖**

**已棄用的 API：**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API：**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **取得圖形縮圖**

**已棄用的 API：**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API：**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **取得簡報縮圖**

**已棄用的 API：**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API：**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **將圖片加入簡報**

**已棄用的 API：**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API：**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **方法與屬性將被移除及其 Modern 替代方案**

### **Presentation 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Slide 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Shape 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage 類別**

| 方法/屬性簽名 | 替代方法/屬性簽名 |
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output 類別**

| 方法簽名 | 替代方法簽名 |
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **支援 aspose.pydrawing.Graphics 的 API**

使用 `aspose.pydrawing.Graphics` 的方法已棄用，且沒有直接的 Modern API 替代。

請改用 Modern API 的影像渲染方法，而非渲染至 `aspose.pydrawing.Graphics` 的 API：
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **常見問題**

**為何棄用 `aspose.pydrawing.Graphics`？**

`aspose.pydrawing.Graphics` 在公開 API 中已棄用，以統一渲染與圖像的工作、消除對平台特定相依性的綁定，並透過 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 採用跨平台方式。請改用 `get_image` 或 `get_images` 取代渲染至 `aspose.pydrawing.Graphics`。

**相較於 `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`，[IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 的實際好處是什麼？**

[IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 統一了光柵與向量圖像的操作，透過 [ImageFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imageformat/) 簡化了多種格式的儲存，減少了對 pydrawing 的依賴，讓程式碼在不同環境間更具可移植性。

**Modern API 會影響產生縮圖的效能嗎？**

將 `get_thumbnail` 改為 `get_image` 並不會使效能變差：新方法提供相同的選項與尺寸產生圖像的能力，且仍支援渲染選項。具體的效能提升或下降取決於使用情境，但功能上兩者是等價的。