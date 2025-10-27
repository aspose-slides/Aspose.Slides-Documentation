---
title: Manage Presentation Backgrounds in Python
linktitle: Slide Background
type: docs
weight: 20
url: /zh/python-net/presentation-background/
keywords:
- presentation background
- slide background
- solid color
- gradient color
- image background
- background transparency
- background properties
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to set dynamic backgrounds in PowerPoint and OpenDocument files using Aspose.Slides for Python via .NET, with code tips to boost your presentations."
---

## **概述**

实色、渐变和图像是常用的幻灯片背景。您可以为**普通幻灯片**（单张幻灯片）或**母版幻灯片**（一次作用于多张幻灯片）设置背景。

![PowerPoint 背景](powerpoint-background.png)

## **为普通幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置实色背景，即使演示文稿使用了母版幻灯片。此更改仅适用于所选幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 设置为 `OWN_BACKGROUND`。  
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `SOLID`。  
4. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 的 `solid_fill_color` 属性指定实色背景颜色。  
5. 保存修改后的演示文稿。

下面的 Python 示例演示如何将普通幻灯片的背景设置为蓝色实色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 将幻灯片的背景颜色设置为蓝色。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # 将演示文稿保存到磁盘。
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **为母版幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿的母版幻灯片设置实色背景。母版幻灯片充当模板，控制所有幻灯片的格式，因此为母版幻灯片的背景选择实色后，会应用于每一张幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 将母版幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/)（通过 `masters`）设置为 `OWN_BACKGROUND`。  
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `SOLID`。  
4. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 的 `solid_fill_color` 属性指定实色背景颜色。  
5. 保存修改后的演示文稿。

下面的 Python 示例演示如何将母版幻灯片的背景设置为森林绿实色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # 将母版幻灯片的背景颜色设置为森林绿。
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # 将演示文稿保存到磁盘。
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **为幻灯片设置渐变背景**

渐变是一种通过颜色逐渐变化实现的图形效果。将渐变用作幻灯片背景可以让演示文稿看起来更具艺术感和专业性。Aspose.Slides 允许您为幻灯片设置渐变颜色背景。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 设置为 `OWN_BACKGROUND`。  
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `GRADIENT`。  
4. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 的 `gradient_format` 属性配置所需的渐变设置。  
5. 保存修改后的演示文稿。

下面的 Python 示例演示如何将渐变颜色设置为幻灯片的背景：

```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 为背景应用渐变效果。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # 将演示文稿保存到磁盘。
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **将图像设为幻灯片背景**

除了实色和渐变填充外，Aspose.Slides 还允许您使用图像作为幻灯片背景。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 设置为 `OWN_BACKGROUND`。  
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `PICTURE`。  
4. 加载要用作幻灯片背景的图像。  
5. 将图像添加到演示文稿的图像集合中。  
6. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 的 `picture_fill_format` 属性将图像指定为背景。  
7. 保存修改后的演示文稿。

下面的 Python 示例演示如何将图像设为幻灯片背景：

```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 设置背景图像属性。
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 加载图像。
    with slides.Images.from_file("Tulips.jpg") as image:
        # 将图像添加到演示文稿的图像集合中。
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # 将演示文稿保存到磁盘。
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

下面的代码示例演示如何将背景填充类型设置为平铺图像并修改平铺属性：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # 设置用于背景填充的图像。
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # 将图片填充模式设为 Tile 并调整平铺属性。
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}

阅读更多： [**纹理化平铺图片**](/slides/zh/python-net/shape-formatting/#tile-picture-as-texture)。

{{% /alert %}}

### **更改背景图像透明度**

您可能希望调整幻灯片背景图像的透明度，以突出幻灯片内容。以下 Python 代码演示如何更改幻灯片背景图像的透明度：

```python
transparency_value = 30  # 示例值。

# 获取图片变换操作的集合。
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# 查找已有的固定比例透明度效果。
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# 设置新的透明度值。
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **获取幻灯片背景值**

Aspose.Slides 提供了 [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) 类用于检索幻灯片的有效背景值。该类公开了有效的 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 和 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/)。

通过 [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) 类的 `background` 属性，您可以获取幻灯片的有效背景。

下面的 Python 示例演示如何获取幻灯片的有效背景值：

```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 检索考虑母版、布局和主题后的有效背景。
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"填充颜色: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("填充类型:", str(effective_background.fill_format.fill_type))
```

## **常见问题**

**我可以重置自定义背景并恢复主题/布局背景吗？**

可以。删除幻灯片的自定义填充后，背景将再次从相应的[布局](/slides/zh/python-net/slide-layout/)/[母版](/slides/zh/python-net/slide-master/)幻灯片（即[主题背景](/slides/zh/python-net/presentation-theme/)）继承。

**如果我随后更改演示文稿的主题，背景会怎样？**

如果幻灯片拥有自己的填充，填充将保持不变。如果背景是从[布局](/slides/zh/python-net/slide-layout/)/[母版](/slides/zh/python-net/slide-master/)继承的，则会随[新主题](/slides/zh/python-net/presentation-theme/)更新。