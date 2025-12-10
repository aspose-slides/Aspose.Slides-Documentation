---
title: "在 C++ 中从 PDF 或 HTML 导入演示文稿"
linktitle: "导入演示文稿"
type: docs
weight: 60
url: /zh/cpp/import-presentation/
keywords:
  - "导入演示文稿"
  - "导入幻灯片"
  - "导入 PDF"
  - "导入 HTML"
  - "PDF 转演示文稿"
  - "PDF 转 PPT"
  - "PDF 转 PPTX"
  - "PDF 转 ODP"
  - "HTML 转演示文稿"
  - "HTML 转 PPT"
  - "HTML 转 PPTX"
  - "HTML 转 ODP"
  - "PowerPoint"
  - "OpenDocument"
  - "C++"
  - "Aspose.Slides"
description: "使用 Aspose.Slides 在 C++ 中轻松将 PDF 和 HTML 文档导入 PowerPoint 和 OpenDocument 演示文稿，实现无缝、高性能的幻灯片处理。"
---

使用 [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)，您可以从其他格式的文件导入演示文稿。Aspose.Slides 提供了 [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) 类，以便您从 PDF、HTML 文档等导入演示文稿。

## **从 PDF 导入 PowerPoint**

在这种情况下，您可以将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 实例化 Presentation 类的对象。  
2. 调用 [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) 方法并传入 PDF 文件。  
3. 使用 [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法将文件保存为 PowerPoint 格式。

以下 C++ 代码演示了 PDF 转换为 PowerPoint 的操作：
```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```


{{% alert  title="Tip" color="primary" %}} 
您可能想了解 **Aspose 免费** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) 网页应用，因为它是本文所述过程的实时实现。 
{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在这种情况下，您可以将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。  
2. 调用 [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) 方法并传入 HTML 文件。  
3. 使用 [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法将文件保存为 PowerPoint 格式。

以下 C++ 代码演示了 HTML 转换为 PowerPoint 的操作：
```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
您也可以使用 Aspose.Slides 将 HTML 转换为其他常用文件格式： 

* [HTML 转图片](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **常见问题**

**在导入 PDF 时是否保留表格，并且可以改进表格检测吗？**

在导入过程中可以检测表格；[PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) 包含一个 [set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) 方法，可启用表格识别。其效果取决于 PDF 的结构。