---
title: 保存演示文稿
type: docs
weight: 80
url: /python-net/save-presentation/
keywords: "保存 PowerPoint, PPT, PPTX, 保存演示文稿, 文件, 流, Python"
description: "在 Python 中将 PowerPoint 演示文稿保存为文件或流"
---

## **保存演示文稿**
打开演示文稿描述了如何使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类来打开演示文稿。本文介绍了如何创建和保存演示文稿。
[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头开始创建演示文稿还是修改现有演示文稿，完成后都需要保存演示文稿。使用 Aspose.Slides for Python via .NET，可以将其保存为 **文件** 或 **流**。本文解释了如何以不同方式保存演示文稿：

### **保存演示文稿到文件**
通过调用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法将演示文稿保存到文件。只需将文件名和保存格式传递给 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法。以下示例展示了如何使用 Aspose.Slides for Python via .NET 以 Python 保存演示文稿。

```py
import aspose.slides as slides

# 实例化一个表示 PPT 文件的 Presentation 对象
with slides.Presentation() as presentation:
    
    #...在这里做一些工作...

    # 将您的演示文稿保存到文件
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **保存演示文稿到流**
通过将输出流传递给 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的 Save 方法，可以将演示文稿保存到流。可以将演示文稿保存到多种类型的流。在以下示例中，我们创建了一个新的演示文稿文件，在形状中添加文本，并将演示文稿保存到流。

```py
import aspose.slides as slides

# 实例化一个表示 PPT 文件的 Presentation 对象
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # 将您的演示文稿保存到流
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **使用预定义视图类型保存演示文稿**
Aspose.Slides for Python via .NET 提供了在 PowerPoint 中打开生成的演示文稿时设置视图类型的功能，通过 [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) 类。可以使用 [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) 枚举器的 [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) 属性来设置视图类型。

```py
import aspose.slides as slides

# 实例化一个表示 PPT 文件的 Presentation 对象
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **以严格的 Office Open XML 格式保存演示文稿**
Aspose.Slides 允许您以严格的 Office Open XML 格式保存演示文稿。为此，它提供了 [**PptxOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) 类，可以在保存演示文稿文件时设置 Conformance 属性。如果将其值设置为 Conformance.Iso29500_2008_Strict，则输出的演示文稿文件将以严格的 Office Open XML 格式保存。

以下示例代码创建了一个演示文稿并将其保存为严格的 Office Open XML 格式。在为演示文稿调用 Save 方法时，将 **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** 对象传递到其中，并将 [**Conformance**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) 属性设置为 [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/)。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation() as presentation:
    # 获取第一张幻灯片
    slide = presentation.slides[0]

    # 添加一条类型为线的自形状
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # 保存演示文稿为严格的 Office Open XML 格式
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **以百分比保存进度更新**
新增了 [**IProgressCallback**](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/) 接口到 [**ISaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/) 接口和 [**SaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) 抽象类中。**IProgressCallback** 接口代表一个用于保存进度更新的回调对象，以百分比形式显示。

下面的代码示例展示了如何使用 IProgressCallback 接口：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

{{% alert title="信息" color="info" %}}

使用其自己的 API，Aspose 开发了一款 [免费的 PowerPoint 拆分器应用](https://products.aspose.app/slides/splitter)，允许用户将他们的演示文稿拆分为多个文件。本质上，该应用会将从给定演示文稿中选择的幻灯片保存为新的 PowerPoint (PPTX 或 PPT) 文件。 

{{% /alert %}}