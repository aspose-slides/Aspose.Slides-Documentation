---
title: 保存演示文稿 - C++ PowerPoint 库
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/cpp/save-presentation/
description: C++ PowerPoint API 或库允许您将演示文稿保存到文件或流中。您可以从头开始创建演示文稿或修改现有演示文稿。
---

{{% alert title="信息" color="info" %}}

要了解如何打开或加载演示文稿，请参阅 [*打开演示文稿*](https://docs.aspose.com/slides/cpp/open-presentation/) 文章。

{{% /alert %}}

本文解释了如何保存演示文稿。

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有的，在完成后，您都希望保存演示文稿。使用 Aspose.Slides for C++，可以将演示文稿保存为 **文件** 或 **流**。本文解释了以不同方式保存演示文稿的方法：

## **将演示文稿保存到文件**
通过调用 **Presentation** 类的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法将演示文稿保存到文件。只需将文件名和保存格式传递给 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法。以下示例演示了如何使用 Aspose.Slides for C++ 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **将演示文稿保存到流**
通过将输出流传递给 [Presentation]() 类的 Save 方法，可以将演示文稿保存到流中。可以将演示文稿保存到多种类型的流。下面的示例中，我们创建了一个新的演示文稿文件，在形状中添加文本，并将演示文稿保存到流中。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}

## **使用预定义视图类型保存演示文稿**
Aspose.Slides for C++ 提供了在 PowerPoint 中打开生成的演示文稿时设置视图类型的功能，通过 [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties) 类。 [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) 属性用于通过 [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype) 枚举器设置视图类型。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **将演示文稿保存为严格的 Office Open XML 格式**
Aspose.Slides 允许您以严格的 Office Open XML 格式保存演示文稿。为此，它提供了 **PptxOptions** 类，您可以在保存演示文稿文件时设置 Conformance 属性。如果将其值设置为 **Conformance.Iso29500_2008_Strict**，则输出的演示文稿文件将以严格的 Office Open XML 格式保存。

以下示例代码创建一个演示文稿并将其保存为严格的 Office Open XML 格式。在调用演示文稿的 Save 方法时，**PptxOptions** 对象会传入，其中 Conformance 属性设置为 **Conformance.Iso29500_2008_Strict**。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}

## **以百分比保存进度更新**
 新的 **IProgressCallback** 接口已添加到 **ISaveOptions** 接口和 **SaveOptions** 抽象类中。 **IProgressCallback** 接口表示用于保存进度更新的回调对象，以百分比表示。

以下代码片段显示如何使用 IProgressCallback 接口：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="信息" color="info" %}}

使用自己的 API，Aspose 开发了一个 [免费的 PowerPoint 分割应用](https://products.aspose.app/slides/splitter)，允许用户将演示文稿拆分为多个文件。实际上，该应用将给定演示文稿中的选定幻灯片保存为新的 PowerPoint (PPTX 或 PPT) 文件。

{{% /alert %}}