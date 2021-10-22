---
title: Convert PowerPoint to PDF with Notes
type: docs
weight: 50
url: /cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "convert powerpoint to pdf with notes"
description: "Convert PowerPoint to PDF with notes. Convert PPT and PPTX to PDF with notes in Aspose.Slides."
---

The [Save](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by Presentation class can be used to convert PowerPoint PPT or PPTX presentation to PDF with notes. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for C++ is a two-line process. You simply open the presentation and save it out to PDF notes. The code snippets below update the sample presentation to PDF in Notes Slide view:

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a presentation file 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Setting Slide Type and Size 
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```
