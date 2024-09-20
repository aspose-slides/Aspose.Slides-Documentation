---
title: Конвертировать PowerPoint в PDF с комментариями
type: docs
weight: 50
url: /cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "конвертировать powerpoint в pdf с комментариями"
description: "Конвертируйте PowerPoint в PDF с комментариями. Конвертируйте PPT и PPTX в PDF с комментариями в Aspose.Slides."
---

Метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставленный классом Presentation, можно использовать для конвертации презентации PowerPoint PPT или PPTX в PDF с комментариями. Сохранение презентации Microsoft PowerPoint в PDF с комментариями с помощью Aspose.Slides для C++ занимает два шага. Вам просто нужно открыть презентацию и сохранить ее в формате PDF с комментариями. Приведенные ниже фрагменты кода обновляют образец презентации в формате PDF в режиме слайдов с комментариями:

``` cpp
// Путь к директории документов.
String dataDir = GetDataPath();

// Создание объекта Presentation, представляющего файл презентации 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Установка типа и размера слайда 
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```



{{% alert color="primary" %}} 

Вы можете ознакомиться с конвертером Aspose [PowerPoint в PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) или [PPT в PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 