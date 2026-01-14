---
title: 使用现代 API 增强图像处理
linktitle: 现代 API
type: docs
weight: 280
url: /zh/python-net/modern-api/
keywords:
- 现代 API
- 绘图
- 幻灯片缩略图
- 幻灯片转图像
- 形状缩略图
- 形状转图像
- 演示文稿缩略图
- 演示文稿转图像
- 添加图像
- 添加图片
- Python
- Aspose.Slides
description: "通过使用 Python 现代 API 替换已弃用的成像 API，实现幻灯片图像处理的现代化，以实现无缝的 PowerPoint 和 OpenDocument 自动化。"
---

## **介绍**

Aspose.Slides for Python 公共 API 当前依赖以下 `aspose.pydrawing` 类型：
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

从 24.4 版起，此公共 API 因在 Aspose.Slides for Python 公共 API 中的[更改](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api)而 **已弃用**。

为了从公共 API 中移除 `aspose.pydrawing`，我们引入了 **现代 API**。使用 `aspose.pydrawing.Image` 和 `aspose.pydrawing.Bitmap` 的方法已弃用，且将被其现代 API 等价方法取代。使用 `aspose.pydrawing.Graphics` 的方法已弃用，这些方法的支持将从公共 API 中删除。

依赖 `aspose.pydrawing` 的已弃用 API 的删除计划在 **24.8** 版发布。

## **现代 API**

以下类和枚举已添加到公共 API：

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) — 表示栅格或矢量图像。
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) — 表示图像文件格式。
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images/) — 提供创建和使用 `IImage` 的方法。

新 API 的典型使用场景如下：
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


## **用现代 API 替换旧代码**

为了更容易的迁移，新的 `IImage` 类镜像了 `Image` 和 `Bitmap` 类的独立 API。大多数情况下，您只需将使用 `aspose.pydrawing` 的方法调用替换为其现代 API 等价方法。

### **获取幻灯片缩略图**

**已弃用的 API：**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```


**现代 API：**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```


### **获取形状缩略图**

**已弃用的 API：**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```


**现代 API：**
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```


### **获取演示文稿缩略图**

**已弃用的 API：**
```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```


**现代 API：**
```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


### **向演示文稿添加图片**

**已弃用的 API：**
```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```


**现代 API：**
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```


## **将被删除的方法和属性及其现代替代方案**

### **Presentation 类**

|方法签名|替代方法签名|
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

### **Slide 类**

|方法签名|替代方法签名|
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

### **Shape 类**

|方法签名|替代方法签名|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection 类**

|方法签名|替代方法签名|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage 类**

|方法/属性签名|替代方法/属性签名|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory 类**

|方法签名|替代方法签名|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat 类**

|方法签名|替代方法签名|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData 类**

|方法签名|替代方法签名|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output 类**

|方法签名|替代方法签名|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **aspose.pydrawing.Graphics 的 API 支持将被停止**

使用 `aspose.pydrawing.Graphics` 的方法已弃用；对它们的支持将从公共 API 中移除。

依赖 `aspose.pydrawing.Graphics` 且将被删除的 API 成员包括：
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **常见问题**

**为什么弃用 aspose.pydrawing.Graphics？**

从公共 API 中移除 Graphics 支持是为了统一渲染和图像的工作、消除对平台特定依赖的关联，并转向使用跨平台的[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) 方法。所有渲染到 Graphics 的方法都将被删除。

**IImage 相对于 Image/Bitmap 的实际好处是什么？**

[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) 统一了栅格和矢量图像的处理，通过[ImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) 简化了保存为各种格式的过程，降低了对 pydrawing 的依赖，并使代码在不同环境之间更加可移植。

**现代 API 会影响生成缩略图的性能吗？**

从 `get_thumbnail` 切换到 `get_image` 并不会导致性能下降：新方法在提供相同的选项和尺寸生成图像的能力的同时，仍然支持渲染选项。具体的提升或下降取决于使用场景，但在功能上替代是等价的。