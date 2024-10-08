---
title: 将PowerPoint转换为带备注的PDF
type: docs
weight: 50
url: /cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "将powerpoint转换为带备注的pdf"
description: "将PowerPoint转换为带备注的PDF。在Aspose.Slides中将PPT和PPTX转换为带备注的PDF。"
---

Presentation类暴露的[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)方法可以用于将PowerPoint PPT或PPTX演示文稿转换为带备注的PDF。使用Aspose.Slides for C++将Microsoft PowerPoint演示文稿保存为PDF备注的过程只需两行代码。您只需打开演示文稿并将其保存为PDF备注。下面的代码片段将示例演示文稿更新为备注幻灯片视图的PDF：

``` cpp
// 文档目录的路径。
String dataDir = GetDataPath();

// 实例化一个表示演示文稿文件的Presentation对象
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// 设置幻灯片类型和大小
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```



{{% alert color="primary" %}} 

您可能想查看Aspose [PowerPoint到PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf)或[PPT到PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf)转换器。

{{% /alert %}} 