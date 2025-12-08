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
description: "使用 Aspose.Slides 通过 .NET 在 Python 中自动化 PowerPoint SmartArt 的创建、编辑和样式设置，提供简洁的代码示例和注重性能的指南。"
---

## **创建 SmartArt 形状**

Aspose.Slides for Python via .NET 允许您从头向幻灯片添加自定义 SmartArt 形状。该 API 简单易用。要向幻灯片添加 SmartArt 形状，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取目标幻灯片。
1. 添加 SmartArt 形状，指定其布局类型。
1. 将修改后的演示文稿另存为 PPTX 文件。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# 实例化 Presentation 类。
with slides.Presentation() as presentation:
    # 访问演示文稿幻灯片。
    slide = presentation.slides[0]
    # 添加 SmartArt 形状。
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **访问 幻灯片上的 SmartArt 形状**

下面的代码演示如何访问幻灯片上的 SmartArt 形状。示例遍历幻灯片上的每个形状，并检查其是否为 [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) 对象。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# 加载演示文稿文件。
with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍历第一张幻灯片上的每个形状。
    for shape in presentation.slides[0].shapes:
        # 检查形状是否为 SmartArt 形状。
        if isinstance(shape, smartart.SmartArt):
            # 打印形状名称。
            print("Shape name:", shape.name)
```


## **使用指定布局类型访问 SmartArt 形状**

下面的示例展示如何访问具有指定布局类型的 SmartArt 形状。请注意，SmartArt 的布局类型不可更改——它是只读的，并在创建形状时设定。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片上的所有形状。
1. 检查该形状是否为 [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) 对象。
1. 如果 SmartArt 形状的布局类型与所需匹配，则执行相应操作。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍历第一张幻灯片上的每个形状。
    for shape in presentation.slides[0].shapes:
        # 检查形状是否为 SmartArt 形状。
        if isinstance(shape, smartart.SmartArt):
            # 检查 SmartArt 布局类型。
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```


## **更改 SmartArt 形状样式**

下面的示例展示如何定位 SmartArt 形状并更改其样式：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 并加载包含 SmartArt 形状的文件。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片上的每个形状。
1. 查找具有指定样式的 SmartArt 形状。
1. 将新样式分配给 SmartArt 形状。
1. 保存演示文稿。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍历第一张幻灯片上的每个形状。
    for shape in presentation.slides[0].shapes:
        # 检查形状是否为 SmartArt 形状。
        if isinstance(shape, smartart.SmartArt):
            # 检查 SmartArt 样式。
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # 更改 SmartArt 样式。
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # 保存演示文稿。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **更改 SmartArt 形状的颜色样式**

本示例展示如何更改 SmartArt 形状的颜色样式。示例代码定位具有指定颜色样式的 SmartArt 形状并对其进行更新。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含 SmartArt 形状的演示文稿。
1. 通过索引获取第一张幻灯片的引用。
1. 遍历第一张幻灯片上的每个形状。
1. 检查该形状是否为 [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) 对象。
1. 定位具有指定颜色样式的 SmartArt 形状。
1. 为该 SmartArt 形状设置新的颜色样式。
1. 保存演示文稿。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍历第一张幻灯片上的每个形状。
    for shape in presentation.slides[0].shapes:
        # 检查形状是否为 SmartArt 形状。
        if isinstance(shape, smartart.SmartArt):
            # 检查颜色类型。
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # 更改颜色类型。
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # 保存演示文稿。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**我可以将 SmartArt 作为单个对象进行动画处理吗？**

是的。SmartArt 是一种形状，您可以通过动画 API（入口、退出、强调、动作路径等）应用[标准动画](/slides/zh/python-net/powerpoint-animation/)，与其他形状的操作相同。

**如果我不知道内部 ID，如何在幻灯片上找到特定的 SmartArt？**

设置并使用备用文本（AltText），并通过该值搜索形状——这是定位目标形状的推荐方法。

**我可以将 SmartArt 与其他形状分组吗？**

是的。您可以将 SmartArt 与其他形状（图片、表格等）分组，然后[操作该组](/slides/zh/python-net/group/)。

**如何获取特定 SmartArt 的图像（例如用于预览或报告）？**

导出形状的缩略图/图像；库可以将[单个形状渲染](/slides/zh/python-net/create-shape-thumbnails/)为光栅文件（PNG/JPG/TIFF）。

**将整个演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

是的。渲染引擎针对[PDF 导出](/slides/zh/python-net/convert-powerpoint-to-pdf/)实现高保真度，并提供多种质量和兼容性选项。