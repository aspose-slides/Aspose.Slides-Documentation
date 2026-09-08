---
title: 在 Python via Java 中将演示文稿导出为 XAML
linktitle: 演示文稿到 XAML
type: docs
weight: 30
url: /zh/python-java/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 保存 PPT 为 XAML
- 保存 PPTX 为 XAML
- 保存 ODP 为 XAML
- 导出 PPT 到 XAML
- 导出 PPTX 到 XAML
- 导出 ODP 到 XAML
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 PowerPoint 和 OpenDocument 演示文稿导出为 XAML。可使用默认选项或包含隐藏幻灯片。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Python via Java 将 PowerPoint 和 OpenDocument 演示文稿导出为 XAML。它介绍了 XAML，展示了使用默认设置进行导出的方法，并演示了如何使用 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 包含隐藏幻灯片。

示例需要 Aspose.Slides for Python via Java 和兼容的 Java 运行时。将 `pres.pptx` 放在当前工作目录中。每个示例仅在 JVM 尚未启动时才启动它。

## **关于 XAML**

XAML（可扩展应用程序标记语言）是一种基于 XML 的用于描述用户界面的语言。它被 Windows Presentation Foundation (WPF) 等框架使用。您可以使用可视化设计器或文本编辑器创建和编辑 XAML。

## **使用默认选项将演示文稿导出为 XAML**

从输入文件创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)，然后将 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 以使用默认设置导出：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **使用自定义选项将演示文稿导出为 XAML**

使用 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 配置导出。要包含隐藏幻灯片，请在保存之前调用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) 并将其设置为 `True`：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **常见问题**

**当原始字体不可用时，如何选择回退字体？**

在您的 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 对象上使用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) 来指定回退字体。确保所选字体在导出环境中可用。

**我可以在任何 XAML 框架中使用导出的标记吗？**

不同的 XAML 框架在支持的元素和功能上有所差异。请在将导出的标记集成到应用程序之前，在目标框架中进行测试。

**隐藏幻灯片会默认导出吗？**

不会。若要包含它们，请调用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) 并设为 `True`。若保持 `False` 则会排除它们。