---
title: 使用 Python 管理演示文稿中的 SmartArt 图形
linktitle: SmartArt 图形
type: docs
weight: 20
url: /zh/python-net/manage-smartart-shape/
keywords:
- SmartArt 对象
- SmartArt 图形
- SmartArt 样式
- SmartArt 颜色
- 创建 SmartArt
- 添加 SmartArt
- 编辑 SmartArt
- 更改 SmartArt
- 访问 SmartArt
- SmartArt 布局类型
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中自动化 PowerPoint SmartArt 的创建、编辑和样式设置，并提供简洁的代码示例和以性能为重点的指南。"
---

## **创建 SmartArt 形状**
Aspose.Slides for Python via .NET 现在支持从零开始在幻灯片中添加自定义 SmartArt 形状。Aspose.Slides for Python via .NET 提供了最简单的 API，以最简单的方式创建 SmartArt 形状。要在幻灯片中创建 SmartArt 形状，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过使用其索引来获取幻灯片的引用。
- 通过设置其 LayoutType 添加 SmartArt 形状。
- 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# 实例化演示文稿
with slides.Presentation() as pres:
    # 访问演示文稿幻灯片
    slide = pres.slides[0]

    # 添加 Smart Art 形状
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # 保存演示文稿
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **访问幻灯片中的 SmartArt 形状**
以下代码将用于访问添加到演示文稿幻灯片中的 SmartArt 形状。在示例代码中，我们将遍历幻灯片中的每个形状，并检查它是否是 SmartArt 形状。如果形状是 SmartArt 类型，则将其强制转换为 SmartArt 实例。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # 遍历第一张幻灯片中的每个形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 强制转换形状为 SmartArtEx
            print("形状名称:" + shape.name)
```



## **访问具有特定布局类型的 SmartArt 形状**
以下示例代码将帮助访问具有特定 LayoutType 的 SmartArt 形状。请注意，您不能更改 SmartArt 的 LayoutType，因为它是只读的，并且只在添加 SmartArt 形状时设置。

- 创建 `Presentation` 类的实例，并加载包含 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将选定的形状强制转换为 SmartArt。
- 检查具有特定 LayoutType 的 SmartArt 形状，并执行之后需要执行的操作。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # 遍历第一张幻灯片中的每个形状
    for shape in presentation.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 检查 SmartArt 布局
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("在这里做一些事情....")
```



## **更改 SmartArt 形状样式**
以下示例代码将帮助访问具有特定 LayoutType 的 SmartArt 形状。

- 创建 `Presentation` 类的实例，并加载包含 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将选定的形状强制转换为 SmartArt。
- 找到具有特定样式的 SmartArt 形状。
- 为 SmartArt 形状设置新的样式。
- 保存演示文稿。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # 遍历第一张幻灯片中的每个形状
    for shape in presentation.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 检查 SmartArt 样式
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # 更改 SmartArt 样式
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # 保存演示文稿
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
```



## **更改 SmartArt 形状颜色样式**
在此示例中，我们将学习如何更改任何 SmartArt 形状的颜色样式。在以下示例代码中将访问具有特定颜色样式的 SmartArt 形状并更改其样式。

- 创建 `Presentation` 类的实例，并加载包含 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将选定的形状强制转换为 SmartArt。
- 找到具有特定颜色样式的 SmartArt 形状。
- 为 SmartArt 形状设置新的颜色样式。
- 保存演示文稿。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # 遍历第一张幻灯片中的每个形状
    for shape in presentation.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 检查 SmartArt 颜色类型
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # 更改 SmartArt 颜色类型
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # 保存演示文稿
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```