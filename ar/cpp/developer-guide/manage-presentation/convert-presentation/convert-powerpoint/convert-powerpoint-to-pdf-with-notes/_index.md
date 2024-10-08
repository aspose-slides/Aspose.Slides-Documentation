---
title: تحويل PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "تحويل PowerPoint إلى PDF مع الملاحظات"
description: "تحويل PowerPoint إلى PDF مع الملاحظات. تحويل PPT و PPTX إلى PDF مع الملاحظات في Aspose.Slides."
---

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي تفصح عنها فئة Presentation لتحويل عرض PowerPoint PPT أو PPTX إلى PDF مع الملاحظات. إن حفظ عرض PowerPoint من Microsoft إلى ملاحظات PDF باستخدام Aspose.Slides لـ C++ هو عملية تتكون من سطرين. ما عليك سوى فتح العرض وحفظه كملاحظات PDF. تُحدِّث مقتطفات الشيفرة أدناه العرض النموذجي إلى PDF في عرض شريحة الملاحظات:

``` cpp
// المسار إلى دليل الوثائق.
String dataDir = GetDataPath();

// إنشاء كائن Presentation يمثل ملف العرض 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// إعداد نوع وحجم الشريحة 
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```



{{% alert color="primary" %}} 

قد ترغب في الاطلاع على محول Aspose [PowerPoint إلى PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) أو [PPT إلى PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 