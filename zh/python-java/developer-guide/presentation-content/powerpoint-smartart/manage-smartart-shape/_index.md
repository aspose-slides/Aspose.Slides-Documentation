---
title: 使用 Python 管理演示文稿中的 SmartArt 图形
linktitle: SmartArt 图形
type: docs
weight: 20
url: /zh/python-java/manage-smartart-shape/
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
description: "使用 Aspose.Slides 在 Python 中自动化 PowerPoint SmartArt 的创建、编辑和样式设置，提供简洁的代码示例和注重性能的指南。"
---
## **概述**

Aspose.Slides 允许您以编程方式在 PowerPoint 演示文稿中创建和管理 SmartArt 图形。本文介绍如何向幻灯片添加 SmartArt 形状、访问现有 SmartArt 形状、通过特定布局类型查找 SmartArt，以及通过更改 SmartArt 样式或颜色样式来更新其视觉外观。

示例展示了如何通过演示文稿幻灯片的形状集合使用 SmartArt 形状，检查形状是否为 SmartArt，然后修改或检查其属性。

## **创建 SmartArt 形状**
Aspose.Slides for Python via Java 提供了创建 SmartArt 形状的 API。要在幻灯片中创建 SmartArt 形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片。
3. 通过指定 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartlayouttype/) 来 [添加 SmartArt 形状](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addSmartArt)。
4. 将修改后的演示文稿保存为 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加 SmartArt 形状。
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # 保存演示文稿。
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已添加到幻灯片的 SmartArt 形状**|

## **访问幻灯片上的 SmartArt 形状**
以下示例访问演示文稿幻灯片上的 SmartArt 形状。它遍历幻灯片上的每个形状，并检查该形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/) 实例。

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 遍历第一张幻灯片上的每个形状。
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **使用特定布局类型访问 SmartArt 形状**
以下示例访问具有特定布局类型的 [SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/) 形状，该布局类型由 [SmartArt.getLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/#getLayout) 返回。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片。
3. 遍历第一张幻灯片上的每个形状。
4. 检查该形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/) 实例。
5. 检查 SmartArt 形状是否具有指定的布局类型并执行所需操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # 遍历第一张幻灯片上的每个形状。
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # 检查 SmartArt 布局。
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **更改 SmartArt 形状样式**
本示例展示如何更改 SmartArt 形状的快速样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片。
3. 遍历第一张幻灯片上的每个形状。
4. 检查该形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/) 实例。
5. 找到具有指定样式的 SmartArt 形状。
6. 为该 SmartArt 形状设置新的样式。
7. 保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 遍历第一张幻灯片上的每个形状。
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # 检查并更改 SmartArt 样式。
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**图：已更改样式的 SmartArt 形状**|

## **更改 SmartArt 形状颜色样式**
本示例访问具有特定颜色样式的 SmartArt 形状并更改该样式。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载包含 SmartArt 形状的演示文稿。
2. 通过索引获取第一张幻灯片。
3. 遍历第一张幻灯片上的每个形状。
4. 检查该形状是否为 [SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/) 实例。
5. 找到具有指定颜色样式的 SmartArt 形状。
6. 为该 SmartArt 形状设置新的颜色样式。
7. 保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 遍历第一张幻灯片上的每个形状。
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # 检查并更改 SmartArt 样式。
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**图：已更改颜色样式的 SmartArt 形状**|

## **FAQ**

**我可以将 SmartArt 作为单个对象进行动画处理吗？**

是的。SmartArt 是一种形状，您可以通过动画 API（进入、退出、强调、运动路径）像对待其他形状一样应用 [标准动画](/slides/zh/python-java/powerpoint-animation/)。

**如果不知道 SmartArt 的内部 ID，如何在幻灯片上找到特定的 SmartArt？**

设置并使用 [替代文本](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setAlternativeText) ，然后按该值搜索形状——这是定位目标形状的推荐方式。

**我可以将 SmartArt 与其他形状组合在一起吗？**

可以。您可以将 SmartArt 与其他形状（图片、表格等）组合，然后 [操作该组](/slides/zh/python-java/group/)。

**如何获取特定 SmartArt 的图像（例如用于预览或报告）？**

导出该形状的缩略图/图像；库可以 [渲染单个形状](/slides/zh/python-java/create-shape-thumbnails/) 为光栅文件（PNG/JPG/TIFF）。

**将整个演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

会的。渲染引擎针对 [PDF 导出](/slides/zh/python-java/convert-powerpoint-to-pdf/) 目标实现高保真度，并提供多种质量和兼容性选项。