---
title: Convertir PowerPoint a PDF con Notas
type: docs
weight: 50
url: /es/python-net/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir PowerPoint, Presentación, PowerPoint a PDF, notas, Python, Aspose.Slides"
description: "Convertir PowerPoint a PDF con notas usando Python"
---

El método [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase Presentation se puede usar para convertir una presentación de PowerPoint PPT o PPTX a PDF con notas. Guardar una presentación de Microsoft PowerPoint en PDF con notas utilizando Aspose.Slides para Python a través de .NET es un proceso de dos líneas. Simplemente abres la presentación y la guardas como PDF con notas. Los fragmentos de código a continuación actualizan la presentación de muestra a PDF en vista de Diapositivas de Notas:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Configuración del Tipo y Tamaño de Diapositiva 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

Es posible que desees consultar el conversor de Aspose [PowerPoint a PDF](https://products.aspose.app/slides/conversion) o [PPT a PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}}