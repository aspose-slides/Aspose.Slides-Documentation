---
title: Convertir PowerPoint en PDF avec des notes
type: docs
weight: 50
url: /python-net/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir PowerPoint, Présentation, PowerPoint en PDF, notes, Python, Aspose.Slides"
description: "Convertir PowerPoint en PDF avec des notes en utilisant Python"
---

La méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exposée par la classe Presentation peut être utilisée pour convertir une présentation PowerPoint PPT ou PPTX en PDF avec des notes. Sauvegarder une présentation Microsoft PowerPoint en PDF avec des notes en utilisant Aspose.Slides pour Python via .NET est un processus en deux lignes. Vous ouvrez simplement la présentation et la sauvegardez en PDF avec des notes. Les extraits de code ci-dessous mettent à jour la présentation d'exemple en PDF en vue des notes de diapositive :

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Définir le type et la taille de la diapositive 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter Aspose [PowerPoint en PDF](https://products.aspose.app/slides/conversion) ou [PPT en PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) convertisseur. 

{{% /alert %}}