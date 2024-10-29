---
title: 打印演示文稿
type: docs
weight: 50
url: /zh/python-net/print-presentation/
keywords: "打印 PowerPoint, PPT, PPTX, 打印演示文稿, Python, 打印机, 打印选项"
description: "在 Python 中打印 PowerPoint 演示文稿"
---
Aspose.Slides for Python 提供了 4 个重载的 `print` 方法，允许您打印演示文稿。重载方法接受不同的参数，因此您始终可以找到适合您打印需求的方法。

## **打印到默认打印机**

此简单打印操作用于通过系统的默认打印机打印 PowerPoint 演示文稿中的所有幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，并传入要打印的演示文稿。
2. 调用 `print` 方法（不带参数）。

以下 Python 代码演示如何打印 PowerPoint 演示文稿：

```python
import aspose.slides as slides

# 加载演示文稿
presentation = slides.Presentation("Print.ppt")

# 调用 print 方法将整个演示文稿打印到默认打印机
presentation.print()
```

## **打印到特定打印机**

此操作用于通过特定打印机打印 PowerPoint 演示文稿中的所有幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，并传入要打印的演示文稿。
2. 调用 `print` 方法并将打印机名称作为字符串传入。

以下 Python 代码演示如何使用特定打印机打印 PowerPoint 演示文稿：

```python
import aspose.slides as slides

try:
    # 加载演示文稿
    with slides.Presentation("pres.pptx") as pres:
        # 调用 print 方法将整个演示文稿打印到所需打印机
        pres.print("请在此处设置您的打印机名称")
except:
    print("请将打印机名称作为字符串参数传递给演示文稿的 Print 方法")
```

## **动态设置打印选项**

使用 `PrinterSettings` 类的属性，您可以应用定义打印操作的参数。您可以指定要打印多少份副本，幻灯片是以横向还是纵向打印，您首选的边距等。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，并传入要打印的演示文稿。
2. 实例化 `PrinterSettings` 类。
3. 指定您首选的打印操作参数：
   * 副本数量
   * 页面方向
   * 边距数值等
4. 调用 `print` 方法。

以下 Python 代码演示如何使用某些打印选项打印 PowerPoint 演示文稿：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    printerSettings = drawing.printing.PrinterSettings()
    printerSettings.copies = 2
    printerSettings.default_page_settings.landscape = True
    printerSettings.default_page_settings.margins.left = 10
    pres.print(printerSettings)
```