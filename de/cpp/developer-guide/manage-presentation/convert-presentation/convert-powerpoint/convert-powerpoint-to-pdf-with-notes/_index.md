---
title: PowerPoint in PDF mit Notizen konvertieren
type: docs
weight: 50
url: /de/cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "powerpoint in pdf mit notizen konvertieren"
description: "Konvertieren Sie PowerPoint in PDF mit Notizen. Konvertieren Sie PPT und PPTX in PDF mit Notizen in Aspose.Slides."
---

Die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode der Presentation-Klasse kann verwendet werden, um eine PowerPoint PPT- oder PPTX-Präsentation in PDF mit Notizen zu konvertieren. Das Speichern einer Microsoft PowerPoint-Präsentation in PDF-Notizen mit Aspose.Slides für C++ ist ein zweizeiliger Prozess. Sie öffnen einfach die Präsentation und speichern sie als PDF-Notizen. Die folgenden Codeausschnitte aktualisieren die Beispielpräsentation zu PDF in der Notizenfolie:

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Festlegen des Folientyps und der Größe 
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```



{{% alert color="primary" %}} 

Sie möchten möglicherweise den Aspose [PowerPoint in PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) oder [PPT in PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) Konverter ausprobieren. 

{{% /alert %}} 