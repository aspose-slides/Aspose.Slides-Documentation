---
title: 常见问题
type: docs
weight: 340
url: /zh/python-java/faqs/
keywords:
- 常见问题
- 演示文稿格式
- 内存不足错误
- 幻灯片大小
- 提取文本
- 段落大小
- 表格边框
- 字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "查找关于 Aspose.Slides for Python via Java 的常见问题的答案，包括文件格式、内存使用、幻灯片大小、文本、表格、图像和字体。"
---
## **概述**

本常见问题解答涵盖了支持的文件格式、大型演示文稿的内存使用情况、幻灯片大小与预览、文本提取、表格边框、图片放置以及将演示文稿转换为 PDF 或图像时的字体差异。

## **常见问题**

### **支持的文件格式**

**Aspose.Slides for Python via Java 支持哪些文件格式？**

请参阅[支持的文件格式](/slides/zh/python-java/supported-file-formats/)了解支持的演示文稿、文档和图像格式以及它们的导入和导出能力。

### **异常情况**

**在加载带有图像的大型演示文稿时为何会出现内存不足错误？是否有文件大小限制？**

没有单一的文件大小阈值可以预测演示文稿是否能装入内存。内存需求取决于演示文稿的结构、解压缩后的图像、效果以及您执行的操作。图像占用的内存可能远大于其在磁盘上的压缩大小。

Aspose.Slides for Python via Java 通过 JPype 使用 Java 引擎，因此 JVM 堆必须有足够的空间进行处理。仅系统可用 RAM 并不能说明 JVM 能使用多少内存。完成使用后请使用[Presentation.dispose](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#dispose)释放演示文稿。有关环境设置，请参阅[系统要求](/slides/zh/python-java/system-requirements/)和[安装](/slides/zh/python-java/installation/)。

### **幻灯片操作**

**我可以更改演示文稿中幻灯片的大小吗？**

可以。使用[Presentation.getSlideSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getslidesize)获取演示文稿的幻灯片尺寸设置，然后使用[SlideSize.setSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesize/#setsize)设置尺寸并选择现有内容的缩放方式。

**同一演示文稿中的幻灯片可以有不同的大小吗？**

不能。Microsoft PowerPoint 文档在演示文稿级别定义幻灯片大小，所有幻灯片共享相同的尺寸。

**我可以在保存演示文稿之前预览幻灯片吗？**

可以。将幻灯片渲染为图像并在您的应用程序中显示该图像，无需先保存演示文稿。

### **文本操作**

**我可以检索演示文稿中的所有文本吗？**

可以。[SlideUtil](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/) 类提供了从演示文稿和单个幻灯片中检索文本的方法。

**为什么段落大小在 Windows 和 Linux 上不同？**

段落尺寸取决于用于呈现文本的字体度量。如果缺少某个字体，替代字体可能具有不同的字符宽度和行高，从而改变换行和段落尺寸。请在两套系统上安装相同的字体，或在创建或加载演示文稿之前使用[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadexternalfonts)加载相同的字体文件。

### **格式和图像**

**如何设置表格边框的颜色？**

使用[Cell.getCellFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/#getcellformat)获取每个单元格的边框格式，并为相关边框设置填充颜色。要更改所有边框，请处理所有单元格。若只更改表格的外框，只需更新位于表格边缘的单元格的外向边框。

**定位和尺寸图片使用的单位是什么？**

形状的坐标和尺寸以点为单位。1 英寸等于 72 点；这些值不是像素坐标。

### **字体操作**

**在将演示文稿转换为 PDF 或图像时，为什么字体会发生变化？**

执行转换的机器可能缺少所需的字体。请安装原始字体或使用[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsloader/#loadexternalfonts)添加包含这些字体的文件夹。在创建或打开演示文稿之前加载外部字体。

以下示例注册了一个字体文件夹。请将路径替换为包含您字体文件的实际文件夹。它假设已按照[安装](/slides/zh/python-java/installation/)中的环境进行设置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

该示例保持 JVM 运行，以便后续进行演示文稿操作。有关笔记本使用和 JVM 生命周期限制，请参阅[限制和 API 差异](/slides/zh/python-java/limitations-and-api-differences/)。