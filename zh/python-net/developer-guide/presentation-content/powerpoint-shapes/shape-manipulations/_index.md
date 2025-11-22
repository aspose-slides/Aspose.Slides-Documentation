---
title: 使用 Python 管理演示文稿中的形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/python-net/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取 Interop 形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "学习在 Aspose.Slides for Python via .NET 中创建、编辑和优化形状，并交付高性能的 PowerPoint 和 OpenDocument 演示文稿。"
---

## **概述**

本指南介绍了通过 .NET 在 Aspose.Slides for Python 中进行形状操作。了解查找形状（包括通过替代文本）、复制、删除或隐藏、重新排序、对齐和翻转、读取 ID 和基于布局的格式化，以及使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 和 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) API 将单个形状导出为 SVG 的实用模式。

## **在幻灯片上查找形状**

PowerPoint 仅通过内部 ID 标识形状。先在 PowerPoint 中为目标形状分配唯一的 Alt Text，然后使用 Aspose.Slides for Python 打开演示文稿，遍历幻灯片上的形状，选择 Alt Text 匹配的形状。`find_shape` 方法实现了此思路并返回匹配的形状。
```py
import aspose.slides as slides

# 在幻灯片上通过替代文本查找形状。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 实例化代表演示文稿文件的 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 查找 Alt Text 为 "Shape1" 的形状。
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```


## **克隆形状**

要在 Aspose.Slides 中将形状从源幻灯片克隆到新幻灯片，请按以下步骤操作：

1. 从源文件创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
1. 按索引获取源幻灯片及其 shapes 集合。
1. 从母版幻灯片检索一个空白布局。
1. 使用该布局添加空白幻灯片并获取其 shapes。
1. 将形状克隆到目标幻灯片。
1. 将演示文稿另存为 PPTX。

下面的代码示例演示了如何将形状从一个幻灯片克隆到另一个幻灯片。
```py
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **删除形状**

Aspose.Slides 允许您删除幻灯片上的任何形状。例如，要通过其替代文本删除第一张幻灯片上的形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例并加载文件。
1. 从 slides 集合中访问第一张幻灯片。
1. 通过 Alternative Text 值查找形状。
1. 将该形状从幻灯片的 shapes 集合中移除。
1. 将演示文稿保存为 PPTX 格式。
```py
import aspose.slides as slides

# 在幻灯片上通过替代文本查找形状。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 查找 Alt Text 为 "User Defined" 的形状。
    shape = find_shape(slide, "User Defined")
    # 删除该形状。
    slide.shapes.remove(shape)
    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **隐藏形状**

Aspose.Slides 允许您隐藏幻灯片上的任何形状。例如，要通过其替代文本隐藏第一张幻灯片上的形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例并加载文件。
1. 从 slides 集合中访问第一张幻灯片。
1. 通过 Alternative Text 值查找形状。
1. 将该形状设置为隐藏。
1. 将演示文稿保存为 PPTX 格式。
```py
# 在幻灯片上通过替代文本查找形状。
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 查找 Alt Text 为 "User Defined" 的形状。
    shape = find_shape(slide, "User Defined")
    # 隐藏该形状。
    shape.hidden = True
    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **更改形状的顺序**

Aspose.Slides 允许开发者重新排列形状（更改 z‑order）。重新排序决定哪个形状位于前面或后面。例如，要在第一张幻灯片上重新排列两个形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加第一个形状（例如矩形）。
1. 添加第二个形状（例如三角形）。
1. 通过将第二个形状移动到集合的第一位置来重新排序。
1. 将演示文稿保存到磁盘。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 向幻灯片添加两个形状。
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # 将第二个形状移动到第一个位置。
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **获取 Interop 形状 ID**

Aspose.Slides 让您获取形状在幻灯片范围内的唯一标识符，与 `unique_id`（跨整个演示文稿唯一）不同。`office_interop_shape_id` 属性位于 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类上。其值对应于 `Microsoft.Office.Interop.PowerPoint.Shape` 对象的 `Id`。下面展示了相应的示例代码。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 获取形状在幻灯片中的唯一标识符。
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```


## **为形状设置替代文本**

Aspose.Slides 允许开发者为任意形状设置替代文本。您可以使用替代文本在演示文稿中标识和定位形状。该属性可以通过 Aspose.Slides 和 Microsoft PowerPoint 读取或写入。通过为形状打上此标签，后续可以在幻灯片上删除、隐藏或重新排序它们。

设置形状的替代文本，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加一个形状。
1. 设置替代文本。
1. 将演示文稿保存到磁盘。
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # 添加一个形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # 设置形状的替代文本。
    shape.alternative_text = "User Defined"
    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **访问形状的布局格式**

Aspose.Slides 提供了简洁的 API 用于访问形状的布局格式。本节演示如何获取布局格式。
```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```


## **将形状渲染为 SVG**

Aspose.Slides 支持将形状渲染为 SVG。`write_as_svg` 方法（及其重载）位于 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类上，可将形状内容保存为 SVG 图像。下面的代码片段展示了如何将形状导出为 SVG 文件。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # 获取第一张幻灯片上的第一个形状。
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```


## **对齐形状**

使用 [SlidesUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) 类中的 `align_shape` 方法，您可以：

* 相对于幻灯片边距对齐形状（参见 示例 1）。
* 相互之间对齐形状（参见 示例 2）。

[ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) 枚举定义了可用的对齐选项。

**示例 1**

下面的 Python 代码展示了如何将索引为 1、2、4 的形状对齐到幻灯片的顶部边缘：
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```


**示例 2**

下面的 Python 示例展示了如何将集合中的所有形状相对于该集合中最底部的形状进行对齐：
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```


## **翻转属性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) 类通过 `flip_h` 和 `flip_v` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)，可取 `TRUE`（翻转）、`FALSE`（不翻转）或 `NOT_DEFINED`（使用默认行为）。这些值可通过形状的 [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) 访问。

要修改翻转设置，可构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) 实例，传入形状当前的位置、大小以及期望的 `flip_h`、`flip_v` 值和旋转角度。将该实例分配给形状的 [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) 并保存演示文稿，即可应用镜像转换并写入输出文件。

假设我们有一个 sample.pptx 文件，第一张幻灯片包含单个默认翻转设置的形状，如下所示。

![要翻转的形状](shape_to_be_flipped.png)

下面的代码示例获取该形状当前的翻转属性并同时进行水平和垂直翻转。
```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # 检索形状的水平翻转属性。
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # 检索形状的垂直翻转属性。
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # 水平和垂直翻转。
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![翻转后的形状](flipped_shape.png)

## **常见问题**

**我可以像桌面编辑器一样在幻灯片上对形状进行合并（并集/交集/相减）吗？**

目前没有内置的布尔运算 API。您可以自行构造所需的轮廓来近似实现，例如计算结果几何（通过 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)），然后使用该轮廓创建新形状，并可选择删除原始形状。

**如何控制堆叠顺序（z‑order），使形状始终保持在最上层？**

在幻灯片的 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 集合中更改插入/移动顺序即可。为获得可预期的结果，建议在完成其他所有幻灯片修改后最后确定 z‑order。

**我能“锁定”形状，以防止用户在 PowerPoint 中编辑它吗？**

可以。设置 [shape-level protection flags](/slides/zh/python-net/applying-protection-to-presentation/)（例如锁定选择、移动、调整大小、文本编辑）。如有需要，可在母版或布局上镜像这些限制。请注意，这是一种 UI 级别的保护，而非安全特性；若需更强的保护，可结合文件级限制，例如 [只读建议或密码](/slides/zh/python-net/password-protected-presentation/)。