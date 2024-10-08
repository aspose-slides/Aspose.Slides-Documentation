---
title: 导入演示文稿 - C++ PowerPoint API
linktitle: 导入演示文稿
type: docs
weight: 60
url: /cpp/import-presentation/
keywords: "导入 PowerPoint, PDF 到演示文稿, PDF 到 PPTX, PDF 到 PPT, C++, Aspose.Slides for C++"
description: "从 PDF 导入 PowerPoint 演示文稿。将 PDF 转换为 PowerPoint"
---

使用 [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)，您可以从其他格式的文件导入演示文稿。 Aspose.Slides 提供了 [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) 类，允许您从 PDF、HTML 文档等导入演示文稿。

## **从 PDF 导入 PowerPoint**

在这种情况下，您可以将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 实例化演示文稿类的对象。
2. 调用 [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) 方法并传递 PDF 文件。
3. 使用 [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法将文件保存为 PowerPoint 格式。

以下 C++ 代码演示了 PDF 到 PowerPoint 的操作：

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="提示" color="primary" %}} 

您可以查看 **Aspose 免费** [PDF 到 PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) 网页应用，因为它是此处描述的过程的实时实现。

{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在这种情况下，您可以将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。
2. 调用 [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) 方法并传递 HTML 文件。 
3. 使用 [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法将文件保存为 PowerPoint 格式。

以下 C++ 代码演示了 HTML 到 PowerPoint 的操作：

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

您还可以使用 Aspose.Slides 将 HTML 转换为其他流行的文件格式：

* [HTML 到图像](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML 到 JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML 到 XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML 到 TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}