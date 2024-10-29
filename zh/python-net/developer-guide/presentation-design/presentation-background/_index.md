---
title: 演示文稿背景
type: docs
weight: 20
url: /zh/python-net/presentation-background/
keywords: "PowerPoint 背景, 设置背景, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中设置 PowerPoint 演示文稿的背景"
---

纯色、渐变色和图片常用作幻灯片的背景图像。您可以为 **普通幻灯片**（单个幻灯片）或 **母版幻灯片**（多个幻灯片）设置背景。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **为普通幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置纯色背景（即使该演示文稿包含母版幻灯片）。背景的更改仅影响所选幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) 属性，通过 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 指定背景的纯色。
5. 保存修改后的演示文稿。

以下 Python 代码演示了如何为普通幻灯片设置纯色（蓝色）背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as pres:
    # 为第一个 ISlide 设置背景颜色为蓝色
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # 将演示文稿写入磁盘
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **为母版幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的母版幻灯片设置纯色背景。母版幻灯片充当模板，包含并控制所有幻灯片的格式设置。因此，当您选择母版幻灯片的背景为纯色时，新背景将用于所有幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将母版幻灯片（`Masters`）的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) 属性，通过 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 指定背景的纯色。
5. 保存修改后的演示文稿。

以下 Python 代码演示了如何为演示文稿中的母版幻灯片设置纯色（森林绿）背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as pres:
    # 将母版 ISlide 的背景颜色设置为森林绿
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # 将演示文稿写入磁盘
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **为幻灯片设置渐变色背景**

渐变是一种基于颜色逐渐变化的图形效果。渐变色作为幻灯片背景使用时，使演示文稿看起来更具艺术性和专业性。Aspose.Slides 允许您为演示文稿中的幻灯片设置渐变色背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 枚举设置为 `Gradient`。
4. 使用 [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) 属性，通过 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 指定您首选的渐变设置。
5. 保存修改后的演示文稿。

以下 Python 代码演示了如何为幻灯片设置渐变色作为背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # 将渐变效果应用于背景
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # 将演示文稿写入磁盘
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **为幻灯片设置图片作为背景**

除了纯色和渐变色，Aspose.Slides 还允许您将图片设置为演示文稿中幻灯片的背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 枚举设置为 `Picture`。
4. 加载您想用作幻灯片背景的图片。
5. 将图片添加到演示文稿的图片集合中。
6. 使用 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) 属性，通过 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 将图片设置为背景。
7. 保存修改后的演示文稿。

以下 Python 代码演示了如何为幻灯片设置图片作为背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # 设置背景图片的条件
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 加载图片
    img = draw.Bitmap(path + "Tulips.jpg")

    # 将图片添加到演示文稿的图片集合中
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # 将演示文稿写入磁盘
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **更改背景图片的透明度**

您可能希望调整幻灯片背景图片的透明度，以使幻灯片内容更加突出。以下 Python 代码演示了如何更改幻灯片背景图片的透明度：

```python
transparencyValue = 30 # 例如

# 获取图片转换操作的集合
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# 查找具有固定百分比的透明度效果。
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# 设置新的透明度值。
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **获取幻灯片背景的值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) 接口，允许您获取幻灯片背景的有效值。该接口包含有效的 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) 和有效的 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) 的信息。

使用 [Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties) 属性从 [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) 类，您可以获取幻灯片背景的有效值。

以下 Python 代码演示了如何获取幻灯片的有效背景值：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("填充颜色: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("填充类型: " + str(effBackground.fill_format.fill_type))
```