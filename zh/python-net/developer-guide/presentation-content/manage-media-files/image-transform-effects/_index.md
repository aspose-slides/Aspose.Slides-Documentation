---
title: 使用 Python 在演示文稿中管理图像变换效果
linktitle: 图像变换效果
type: docs
weight: 11
url: /zh/python-net/image-transform-effects/
keywords:
- 图像变换
- 图片效果
- 亮度
- 对比度
- 灰度
- 双调
- 色调
- HSL
- 颜色替换
- 模糊
- 透明度
- Alpha 效果
- 效果链
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 对图片框的图像变换效果进行应用、链式组合、检查、移除和验证。"
---
## **概述**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，首先获取框的[Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/)并访问其[image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/)属性。返回的[ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/)允许您追加、枚举、检查、移除和清除效果，而无需重新写入原始图像字节。

本文演示了亮度和对比度、颜色变换、模糊、透明度、有序效果链、有效值、移除以及 PPTX 循环验证的完整工作流。

## **了解效果所有权和图像复用**

图像资源和显示它的图片是不同的对象：

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 存储或引用演示文稿拥有的源图像数据。
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) 属于图片填充，引用图像资源并存储图像变换集合。
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 是幻灯片形状，拥有相应的图片填充、几何、裁剪设置以及其他框级格式。

因此，图像变换操作不会修改[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)中的字节。当同一个 `PPImage` 多次传递给[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/)时，每个新图片框都会得到自己的 `Picture` 和自己的变换集合。对一个框应用灰度不会使其他框变为灰度，即使它们复用了相同的嵌入图像资源。

相同的 `Picture.image_transform` 模型也被其他图片填充使用，如形状或幻灯片背景。下面的示例聚焦于图片框。

## **使用有效的参数范围和单位**

演示的方法使用以下语义范围和单位。即使特定库版本未立即拒绝所有超出范围的值，也请保持在这些范围内；目标演示文稿格式可能会在保存或 PowerPoint 打开文件时规范化、遗漏或拒绝无效数据。

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 表示保持不变。 |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | 无数值参数。Alpha 保持不变。 |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | 两种颜色用于暗像素和亮像素。RGB 和 alpha 通道使用 `0` 到 `255`。 |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue 为 `0`（含）到 `360`（不含）度；amount 为 `-100` 到 `100`，百分比。 |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue 为 `0`（含）到 `360`（不含）度；饱和度和亮度为 `-100` 到 `100`，百分比。 |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | 替换颜色的通道值为 `0` 到 `255`。已有的 alpha 值保持不变。 |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius 为非负数，单位为点；`grow` 为布尔值，控制模糊内容是否可超出原始边界。 |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | 非负百分比。使用 `0` 到 `100` 表示普通不透明度缩放：`0` 为完全透明，`100` 保留现有 alpha。 |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` 到 `100`，百分比 alpha 阈值。低于阈值的像素变为透明；等于或高于阈值的像素变为不透明。 |

对于固定的 alpha 调制，透明度和不透明度是互补的。例如，35% 透明度对应 alpha 调制量为 65%。

## **应用亮度和对比度**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) 返回一个[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)操作。其标量设置在创建操作时提供。[BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) 返回计算后的只读值，可用于检查或记录。

下面的示例将亮度提高 15%，对比度提高 20%，然后在不修改嵌入图像的情况下渲染预览：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 图片效果扩展，便携性不如标准 DrawingML 亮度效果。当亮度和对比度必须在 PPTX 循环后仍可编辑时，请使用[ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 并在重新打开文件后验证结果。格式限制部分对该区别作了更详细说明。

## **应用颜色变换**

颜色效果可以独立应用于复用同一图像资源的不同图片框。下面的示例创建五个框并分别应用灰度、双调、色调、HSL 调整和颜色替换。

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) 包含两个可独立编辑的颜色参数：`color1` 映射暗像素，`color2` 映射亮像素。这使其成为一个设置比单一标量更复杂的示例。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) 用固定颜色替换每个像素的颜色，同时保留 alpha。它不同于[add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)，后者将一种源颜色映射到另一种颜色，并公开源和目标颜色的格式。

### **应用亮度阈值**

亮度阈值可以使扫描页面上的淡淡标记更易于从背景中区分。[add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) 保留中间灰度。[add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) 将亮度映射为黑或白，而[add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) 对不透明度应用阈值。

亮度阈值范围为 0% 到 100%，含边界。低于阈值的像素变为黑色，达到或超过阈值的像素变为白色。提高阈值会使更多色调变黑，因为它们落在阈值以下。

下载 [grayscale-swatches.png](grayscale-swatches.png) 到工作目录。每个标签给出 0 到 255 范围内的原始灰度级。示例将原始图像放在两份副本旁边，并在演示文稿中保存每份副本的阈值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

在 PowerPoint 中打开输出演示文稿以比较这三个框。标记为 96 的色板约为 38% 亮度（96/255）。在 20% 阈值时它变白，在 60% 阈值时它变黑。

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **添加模糊、透明度和 Alpha 效果**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) 影响所有颜色通道，包括 alpha。当模糊边缘可能超出原始图片边界时，将 `grow` 设置为 `True`。

对于均匀透明度，请使用[add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)。它将每个现有 alpha 值相乘，因此部分透明的像素仍保持比例差异。[add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) 则为所有像素分配统一的 alpha 值。[add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) 根据阈值将 alpha 转换为两级。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

其他无参数的 alpha 操作包括[add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)，它将每个非零 alpha 设为完全不透明；[add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)，它将低于 100% 的 alpha 完全透明；以及[add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)，它将 alpha 改为 `100% - alpha`。

## **构建有序效果链**

每个 `add_..._effect` 方法都会将新操作追加到集合末尾。渲染器将集合视为有序管道：操作 0 的输出成为操作 1 的输入，依此类推。因此，以不同顺序排列相同操作会产生不同图像。

例如，先灰度后色调会先去除色彩信息再重新着色；先色调后灰度则会再次去除色调。类似地，alpha 替换可以覆盖之前操作计算的 alpha 值，而 alpha 调制则保留它们的相对差异。

下面的示例构建四步链，保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开的结果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

该集合不会强加兼容性矩阵限制颜色、alpha 和模糊操作必须分离链。它们可以组合，但组合不一定有用。固定颜色替换会去除之前颜色效果产生的 RGB 变化；灰度在双调之后会去除两种选定颜色；alpha ceiling、floor、replacement 或 bi-level 操作可以丢弃之前创建的 alpha 细节。请根据期望的像素处理顺序构建链，而不是把项当作无序的格式标记。


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **检查可编辑和有效值**

可编辑操作是存储在 `Picture.image_transform` 中的对象。根据效果的不同，它可能直接公开可写成员。例如，[Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) 公开可写的 `radius` 和 `grow` 属性，[AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) 公开可写的 `amount` 属性，[AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) 公开可写的 `threshold` 属性。像 [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) 这样的颜色效果公开可变的 [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) 对象。

一些操作，包括 [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/)、[Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/) 和 [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/)，不将其创建时的标量公开为可写属性。要更改这些设置，需要移除该操作并在所需位置添加替代项。

`get_effective()` 返回的有效数据是计算后的只读值。它对于解析主题相关颜色以及读取渲染器使用的归一化值很有帮助，但它不是另一个编辑界面。下面的示例枚举链并检查有效值（当相应 API 提供时）：

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

没有参数的效果，如灰度、alpha ceiling 和 alpha inverse，仍然有有效数据对象，只是没有可打印的标量设置。它们在集合中的存在和位置才是重要信息。

## **移除或清除图像变换**

使用[ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) 按索引移除单个操作。因为移除后索引会移动，建议先搜索目标再在枚举后移除。使用 `clear()` 可移除全部链。

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

移除或清除变换仅改变图片格式。它不会删除、重新压缩或以其他方式改变复用的[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)资源。

## **考虑演示文稿格式和导出目标**

图像变换起源于 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使是 PPTX，也并非所有操作都有完全相同的可移植性：

- 标准 DrawingML 操作（如亮度、灰度、双调、色调、HSL、模糊和常见 alpha 操作）在 PPTX 循环中存活的概率最高。若有保存要求，请始终重新打开生成的文件并检查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 扩展，而非标准 DrawingML 亮度操作。它可用于内存渲染，但在保存并重新打开 PPTX 后不一定保持为可编辑的 `BrightnessContrast` 操作。请优先使用[add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 以实现持久的亮度和对比度调整。
- 二进制 PPT 格式早于完整的 DrawingML 效果模型。保存为 PPT 可能会省略不支持的操作，将链缩减为受支持的子集，或近似外观。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用于渲染结果。这些输出不包含可编辑的 `ImageTransformOperationCollection`；光栅格式将结果平铺为像素，文档或矢量导出则存储自己的渲染表示。
- 效果不会使链接图像变为自包含。渲染链接图片仍依赖于加载演示文稿时链接资源可用。

不同的演示文稿读取器在边缘情况的渲染上可能有所差异，尤其是多种 alpha 或颜色量化操作组合时。对关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑循环和最终导出格式。

## **常见问题**

**图像变换效果会修改嵌入的图像数据吗？**

不会。操作属于图片填充使用的 `Picture`。底层 `PPImage` 字节保持不变。

**复用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 `PPImage` 可以避免重复的图像数据，但每个图片框通常拥有各自的 `Picture` 和图像变换集合。

**可以同时组合颜色、模糊和 alpha 效果吗？**

可以。集合接受它们在同一有序链中。请考虑每个操作对前一步输出的影响，因为替换和阈值操作可能会丢弃之前的颜色或 alpha 细节。

**为什么有效值是只读的？**

有效数据代表渲染使用的计算值，包括已解析的颜色。请在变换集合中编辑具有可写成员的操作；若无可写成员，则需移除并添加带新创建参数的替代操作。

**应使用哪种格式来保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。旧版 PPT 无法完整表示 DrawingML 效果模型，渲染导出格式仅保留外观而不保留可编辑的变换操作。