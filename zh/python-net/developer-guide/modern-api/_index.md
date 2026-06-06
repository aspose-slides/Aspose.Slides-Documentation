---
title: 使用 Modern API 增强图像处理
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
description: "通过使用 Python Modern API 替换已弃用的图像 API，实现幻灯片图像处理的现代化，从而实现 PowerPoint 和 OpenDocument 的无缝自动化。"
---
## **介绍**

Aspose.Slides for Python 公共 API 目前依赖以下 `aspose.pydrawing` 类型：
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

从 24.4 版本开始，因 Aspose.Slides for Python 公共 API 的[更改](https://releases.aspose.com/slides/zh/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api)而 **已弃用**。

为消除公共 API 中的 `aspose.pydrawing`，我们引入了 **Modern API**。使用 `aspose.pydrawing.Image` 和 `aspose.pydrawing.Bitmap` 的方法已弃用，应该改用其 Modern API 等价实现。使用 `aspose.pydrawing.Graphics` 的方法已弃用，且没有直接的 Modern API 替代。

在当前版本中，请将依赖 `aspose.pydrawing` 的公共 API 视为旧版/已弃用。新代码以及迁移现有图像处理工作流时，请使用 Modern API。

## **Modern API**

已在公共 API 中添加以下类和枚举：

- [aspose.slides.IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) - 表示光栅或矢量图像。
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imageformat/) - 表示图像文件格式。
- [aspose.slides.Images](https://reference.aspose.com/slides/zh/python-net/aspose.slides/images/) - 提供创建和使用 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 的方法。

使用 `get_image` 渲染单个幻灯片或形状。使用 `get_images` 渲染多个演示文稿幻灯片。使用 [Images](https://reference.aspose.com/slides/zh/python-net/aspose.slides/images/) 方法加载图像，使用 `add_image` 与 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 将其添加到演示文稿，使用 `replace_image` 与 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 更新已存在的演示文稿图像。

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

## **使用 Modern API 替换旧代码**

为了更容易迁移，新 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 类镜像了 `aspose.pydrawing.Image` 和 `aspose.pydrawing.Bitmap` 类的独立 API。大多数情况下，只需将使用 `aspose.pydrawing` 的方法调用替换为其 Modern API 等价实现。

### **获取幻灯片缩略图**

**已弃用的 API：**

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

### **获取形状缩略图**

**已弃用的 API：**

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

**Modern API：**

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

**Modern API：**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **将被移除的方法和属性及其 Modern 替代方案**

### **Presentation 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|无 Modern API 替代|
|save(fname, format, options, response, show_inline)|无 Modern API 替代|
|print()|无 Modern API 替代|
|print(printer_settings)|无 Modern API 替代|
|print(printer_name)|无 Modern API 替代|
|print(printer_settings, pres_name)|无 Modern API 替代|

### **Slide 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|无 Modern API 替代|
|render_to_graphics(options, graphics, scale_x, scale_y)|无 Modern API 替代|
|render_to_graphics(options, graphics, rendering_size)|无 Modern API 替代|

### **Shape 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage 类**

| 方法/属性签名 | 替代方法/属性签名 |
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output 类**

| 方法签名 | 替代方法签名 |
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **aspose.pydrawing.Graphics 的 API 支持**

使用 `aspose.pydrawing.Graphics` 的方法已弃用，且没有直接的 Modern API 替代。

请使用 Modern API 的图像渲染方法替代渲染到 `aspose.pydrawing.Graphics` 的 API：
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **常见问题解答**

**为什么移除了 `aspose.pydrawing.Graphics`？**

`aspose.pydrawing.Graphics` 在公共 API 中已弃用，目的是统一渲染和图像的工作方式，消除对平台特定依赖的绑定，并通过 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 转向跨平台方案。请改用 `get_image` 或 `get_images`，而不是渲染到 `aspose.pydrawing.Graphics`。

**[IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 相比 `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap` 的实际好处是什么？**

[IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 统一了对光栅和矢量图像的处理，简化了通过 [ImageFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imageformat/) 保存为多种格式的操作，减少了对 pydrawing 的依赖，使代码在不同环境间更具可移植性。

**Modern API 会影响生成缩略图的性能吗？**

从 `get_thumbnail` 切换到 `get_image` 不会导致性能下降：新方法在提供相同的选项和尺寸生成图像能力的同时，仍然支持渲染选项。具体的提升或下降取决于使用场景，但功能上两者是等价的。