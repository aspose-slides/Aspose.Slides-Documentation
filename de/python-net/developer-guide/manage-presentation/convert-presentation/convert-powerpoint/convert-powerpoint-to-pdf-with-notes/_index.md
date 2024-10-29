---
title: PowerPoint mit Notizen in PDF umwandeln
type: docs
weight: 50
url: /de/python-net/convert-powerpoint-to-pdf-with-notes/
keywords: "PowerPoint umwandeln, Präsentation, PowerPoint in PDF, Notizen, Python, Aspose.Slides"
description: "PowerPoint mit Notizen in PDF umwandeln mit Python"
---

Die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode, die von der Presentation-Klasse bereitgestellt wird, kann verwendet werden, um eine PowerPoint PPT oder PPTX Präsentation mit Notizen in PDF umzuwandeln. Das Speichern einer Microsoft PowerPoint-Präsentation als PDF-Notizen mit Aspose.Slides für Python über .NET ist ein zweizeiliger Prozess. Sie öffnen einfach die Präsentation und speichern sie als PDF-Notizen. Die folgenden Code-Snippets aktualisieren die Beispielpräsentation auf PDF im Notizen-Folienansicht:

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Festlegen von Folientyp und Größe 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

Sie möchten vielleicht den Aspose [PowerPoint in PDF](https://products.aspose.app/slides/conversion) oder [PPT in PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) Konverter ausprobieren. 

{{% /alert %}}