---
title: 使用 Python 管理演示文稿中的图像变换效果
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
description: "使用 Aspose.Slides for Python (via .NET) 对图片框的图像变换效果进行应用、链式组合、检查、移除和验证。"
---
## **概述**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，从框的 [Picture](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picture/) 开始，访问其 [image_transform](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picture/image_transform/) 属性。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/effects/imagetransformoperationcollection/) 允许在不重写原始图像字节的情况下追加、枚举、检查、移除和清除效果。

本文演示了亮度与对比度、颜色变换、模糊、透明度、有序效果链、有效值、移除以及 PPTX 循环验证的完整工作流。

## **了解效果所有权和图像复用**

图像资源与显示它的图片是不同的对象：

- [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 存储或引用演示文稿拥有的源图像数据。
- [Picture](https://reference.aspose.com/slides/zh/python-net/aspose.slides/picture/) 属于图片填充，引用图像资源并保存图像变换集合。
- [PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 是拥有相关图片填充、几何形状、裁剪设置以及其他框级格式的幻灯片形状。

因此，图像变换操作不会修改 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 中的字节。当同一个 `PPImage` 被多次传递给 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/) 时，每个新图片框都会获得自己的 `Picture` 和自己的变换集合。对一个框应用灰度并不会使其他框也变为灰度，即使它们复用了同一嵌入图像资源。

相同的 `Picture.image_transform` 模型也被其他图片填充使用，例如形状或幻灯片背景。以下示例重点关注图片框。

## **使用有效的参数范围和单位**

示例方法使用以下语义范围和单位。请在这些范围内提供数值，即使特定库版本未立即拒绝所有超出范围的值；目标演示文稿格式可能在保存或 PowerPoint 打开文件时对无效数据进行规范化、忽略或拒绝。

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [add_gray_scale_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | 无数值参数。Alpha 保持不变。 |
| [add_duotone_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | 两种颜色用于暗像素和亮像素。RGB 与 Alpha 通道使用 `0` 到 `255`。 |
| [add_tint_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue 为 `0`（含）到 `360`（不含）度；amount 为 `-100` 到 `100`，百分比。 |
| [add_hsl_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue 为 `0`（含）到 `360`（不含）度；饱和度和亮度为 `-100` 到 `100`，百分比。 |
| [add_color_replace_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | 替换颜色的通道值为 `0` 到 `255`。现有 Alpha 保持不变。 |
| [add_blur_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius 为非负，以点为单位；`grow` 为布尔值，决定模糊内容是否可以超出原始边界。 |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | 非负百分比。使用 `0` 到 `100` 进行普通不透明度缩放：`0` 完全透明，`100` 保持原有 Alpha。 |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` 到 `100`，百分比 Alpha 阈值。低于阈值的像素变为透明，等于或高于阈值的像素变为不透明。 |

对于固定的 Alpha 调制，透明度与不透明度是互补的。例如，35% 透明度对应的 Alpha 调制量为 65%。

## **应用亮度和对比度**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) 返回一个 [BrightnessContrast](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/brightnesscontrast/) 操作。其标量设置在创建操作时提供。[BrightnessContrast.get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) 返回计算后的只读值，可用于检查或记录。

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

[BrightnessContrast](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的图片效果扩展，兼容性不如标准 DrawingML 亮度效果。当需要在 PPTX 循环后仍保持可编辑的亮度和对比度时，请使用 [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 并在重新打开文件后验证结果。格式限制章节对此区别作了更详细说明。

## **应用颜色变换**

颜色效果可以独立地应用于复用同一图像资源的不同图片框。下例创建五个框并分别应用灰度、双调、色调、HSL 调整和颜色替换。

[Duotone](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/duotone/) 包含两个可独立编辑的颜色参数：`color1` 映射暗像素，`color2` 映射亮像素。这是一个设置比单一标量更复杂的效果示例。

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

[add_color_replace_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) 将每个像素的颜色替换为固定颜色，同时保留 Alpha。它不同于 [add_color_change_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)，后者将一种源颜色映射到另一种，并公开源与目标颜色的格式。

## **添加模糊、透明度和 Alpha 效果**

[add_blur_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) 影响所有颜色通道，包括 Alpha。当模糊边缘可能超出原始图片范围时，将 `grow` 设为 `True`。

若需统一透明度，请使用 [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)。它会乘以每个现有 Alpha 值，因此部分透明像素保持相对差异。[add_alpha_replace_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) 则将所有像素的 Alpha 设为同一值。[add_alpha_bi_level_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) 根据阈值将 Alpha 转换为两级。

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

其他无参数的 Alpha 操作包括 [add_alpha_ceiling_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)，它将所有非零 Alpha 设为完全不透明；[add_alpha_floor_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)，它将低于 100% 的 Alpha 全部设为完全透明；以及 [add_alpha_inverse_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)，它将 Alpha 改为 `100% - alpha`。

## **构建有序的效果链**

每个 `add_..._effect` 方法都会将新操作追加到集合末尾。渲染器将集合视为有序管线：操作 0 的输出成为操作 1 的输入，依此类推。因此，同样的操作若顺序不同会产生不同的图像。

例如，先灰度后色调会先去除色彩信息再为亮度结果着色；先色调后灰度则会再次去除色调。类似地，Alpha 替换可以覆盖之前操作计算的 Alpha，而 Alpha 调制则保留它们的相对差异。

下面的示例构建一个四操作链，保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开后的结果：

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

该集合并未强制兼容性矩阵来限制颜色、Alpha 与模糊操作必须分开链。它们可以组合，但组合并非总有用处。固定颜色替换会去除之前颜色效果产生的 RGB 变化；在双调后再使用灰度会去除两种选定颜色；Alpha ceiling、floor、replacement 或 bi‑level 操作会丢弃之前创建的 Alpha 细节。请根据所需的像素处理顺序构建链，而不是将其视为无序的格式标志。

## **检查可编辑和有效值**

可编辑的操作是存储在 `Picture.image_transform` 中的对象。根据效果的不同，它可能直接公开可写成员。例如，[Blur](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/blur/) 公开可写的 `radius` 和 `grow` 属性，[AlphaModulateFixed](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/alphamodulatefixed/) 公开可写的 `amount` 属性，而 [AlphaBiLevel](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/alphabilevel/) 公开可写的 `threshold` 属性。像 [Duotone](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/duotone/) 这样的颜色效果会暴露可变的 [ColorFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/colorformat/) 对象。

某些操作（包括 [BrightnessContrast](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/hsl/)、[Tint](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/tint/) 和 [AlphaReplace](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/alphareplace/)）不公开其创建时的标量作为可写属性。若要更改这些设置，需要移除该操作并在所需位置添加替代操作。

`get_effective()` 返回的有效数据是计算后的只读值。它对于解析主题相关颜色以及读取渲染器使用的归一化值非常有用，但并非另一个编辑面。下面的示例枚举链并在对应 API 提供时检查有效值：

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

诸如灰度、Alpha ceiling、Alpha inverse 等无参数效果仍然拥有有效数据对象，但没有可打印的标量设置。它们在集合中的存在与位置即为关键信息。

## **移除或清除图像变换**

使用 [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) 按索引移除单个操作。因为移除后索引会改变，请先搜索目标再在枚举后移除。使用 `clear()` 可移除整个链。

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

移除或清除变换只会改变图片格式，不会删除、重新压缩或以其他方式修改复用的 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换起源于 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使是 PPTX，也并非所有操作都有相同的可移植性：

- 标准 DrawingML 操作（如亮度、灰度、双调、色调、HSL、模糊以及常见的 Alpha 操作）最有可能在 PPTX 循环后仍然保留。若需要保留，请始终重新打开生成的文件并检查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的扩展而非标准 DrawingML 亮度操作。它可用于内存渲染，但保存并重新打开 PPTX 后不保证仍为可编辑的 `BrightnessContrast` 操作。请使用 [add_luminance_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) 进行持久的亮度和对比度调整。
- 二进制 PPT 格式诞生于完整 DrawingML 效果模型之前。保存为 PPT 可能会省略不受支持的操作、将链缩减为支持的子集，或近似外观。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用于渲染后的图像。这些输出不包含可编辑的 `ImageTransformOperationCollection`；光栅格式会将结果平铺为像素，文档或矢量导出会存储自己的渲染表示。
- 效果不会使链接图片变成自包含。渲染链接图片仍然依赖于加载演示文稿时链接资源的可用性。

不同的演示文稿阅读器在边缘情况的渲染上可能有所差异，尤其是当多个 Alpha 或颜色量化操作组合时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑的循环和最终导出格式。

## **FAQ**

**图像变换效果会修改嵌入的图像数据吗？**

不会。操作属于图片填充使用的 `Picture`。底层 `PPImage` 的字节保持不变。

**复用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 `PPImage` 可以避免重复的图像数据，但每个图片框通常拥有独立的 `Picture` 和图像变换集合。

**可以组合颜色、模糊和 Alpha 效果吗？**

可以。集合允许它们在同一有序链中出现。请考虑每个操作对前一个操作输出的影响，因为替换和阈值操作可能会丢弃之前的颜色或 Alpha 细节。

**为什么有效值是只读的？**

有效数据代表渲染使用的计算值，包括已解析的颜色。请在变换集合中编辑拥有可写成员的操作；否则移除该操作并使用新创建参数添加替代操作。

**应该使用哪种格式来保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。旧版 PPT 无法完整表示 DrawingML 效果模型，渲染导出格式只保留外观而不保留可编辑的变换操作。