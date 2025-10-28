---
title: 管理Python中的演示文稿背景
linktitle: 幻灯片背景
type: docs
weight: 20
url: /zh/python-net/presentation-background/
keywords:
- 演示文稿背景
- 幻灯片背景
- 实色
- 渐变色
- 图像背景
- 背景透明度
- 背景属性
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 为 PowerPoint 和 OpenDocument 文件设置动态背景，并提供代码技巧以提升您的演示文稿。"
---

## **概述**

实色、渐变和图像通常用于幻灯片背景。您可以为 **普通幻灯片**（单张幻灯片）或 **母版幻灯片**（一次应用于多张幻灯片）设置背景。

![PowerPoint background](powerpoint-background.png)

## **为普通幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿中指定的幻灯片设置实色背景——即使演示文稿使用母版幻灯片。此更改仅适用于所选幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 设置为 `OWN_BACKGROUND`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `SOLID`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 上的 `solid_fill_color` 属性指定实色背景颜色。
5. 保存修改后的演示文稿。

以下 Python 示例演示如何将普通幻灯片的背景设置为蓝色实色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set the background color of the slide to blue.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **为母版幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿的母版幻灯片设置实色背景。母版幻灯片是控制所有幻灯片格式的模板，因此当您为母版的背景选择实色时，它会应用到每张幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将母版幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/)（通过 `masters`）设置为 `OWN_BACKGROUND`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `SOLID`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 上的 `solid_fill_color` 属性指定实色背景颜色。
5. 保存修改后的演示文稿。

以下 Python 示例演示如何将母版幻灯片的背景设置为森林绿实色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Set the background color for the Master slide to Forest Green.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **为幻灯片设置渐变背景**

渐变是一种通过颜色逐渐变化实现的图形效果。用作幻灯片背景时，渐变可以使演示文稿更具艺术感和专业感。Aspose.Slides 允许您为幻灯片设置渐变颜色背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 设置为 `OWN_BACKGROUND`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `GRADIENT`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 上的 `gradient_format` 属性配置您偏好的渐变设置。
5. 保存修改后的演示文稿。

以下 Python 示例演示如何将渐变颜色设置为幻灯片的背景：

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Apply a gradient effect to the background.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the presentation to disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **将图像设置为幻灯片背景**

除了实色和渐变填充，Aspose.Slides 还允许您使用图像作为幻灯片背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 设置为 `OWN_BACKGROUND`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 设置为 `PICTURE`。
4. 加载您想用作幻灯片背景的图像。
5. 将图像添加到演示文稿的图像集合中。
6. 使用 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 上的 `picture_fill_format` 属性将图像指定为背景。
7. 保存修改后的演示文稿。

以下 Python 示例演示如何将图像设置为幻灯片的背景：

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set background image properties.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Add the image to the presentation's image collection.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

以下代码示例演示如何将背景填充类型设置为平铺图片并修改平铺属性：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Set the image used for the background fill.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Set the picture fill mode to Tile and adjust the tile properties.
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

阅读更多： [**平铺图片作为纹理**](/slides/zh/python-net/shape-formatting/#tile-picture-as-texture)。

{{% /alert %}}

### **更改背景图像透明度**

您可能希望调整幻灯片背景图像的透明度，以使幻灯片内容更突出。以下 Python 代码演示如何更改幻灯片背景图像的透明度：

```python
transparency_value = 30  # For example.

# Get the collection of picture transform operations.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Find an existing fixed-percentage transparency effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Set the new transparency value.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **获取幻灯片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) 类，用于检索幻灯片的有效背景值。该类公开有效的 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 和 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) 类的 `background` 属性，您可以获取幻灯片的有效背景。

以下 Python 示例演示如何获取幻灯片的有效背景值：

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Retrieve the effective background, taking into account master, layout, and theme.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**我可以重置自定义背景并恢复主题/布局背景吗？**

可以。删除幻灯片的自定义填充后，背景将再次从相应的 [layout](/slides/zh/python-net/slide-layout/)/[master](/slides/zh/python-net/slide-master/) 幻灯片（即 [theme background](/slides/zh/python-net/presentation-theme/)）继承。

**如果稍后更改演示文稿的主题，背景会怎样？**

如果幻灯片已有自己的填充，它将保持不变。如果背景是从 [layout](/slides/zh/python-net/slide-layout/)/[master](/slides/zh/python-net/slide-master/) 继承的，则会更新以匹配新的主题。