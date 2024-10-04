---
title: Convertir PowerPoint a PDF con Notas
type: docs
weight: 50
url: /cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir powerpoint a pdf con notas"
description: "Convertir PowerPoint a PDF con notas. Convertir PPT y PPTX a PDF con notas en Aspose.Slides."
---

El [método Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) expuesto por la clase Presentation se puede utilizar para convertir presentaciones PowerPoint PPT o PPTX a PDF con notas. Guardar una presentación de Microsoft PowerPoint como PDF con notas usando Aspose.Slides para C++ es un proceso de dos líneas. Simplemente abres la presentación y la guardas como PDF con notas. Los fragmentos de código a continuación actualizan la presentación de muestra a PDF en vista de diapositivas con notas:

``` cpp
// La ruta al directorio de documentos.
String dataDir = GetDataPath();

// Instanciar un objeto Presentation que representa un archivo de presentación 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Configurar el tipo y tamaño de la diapositiva 
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```



{{% alert color="primary" %}} 

Puede que desee consultar el convertidor de Aspose [PowerPoint a PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) o [PPT a PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 