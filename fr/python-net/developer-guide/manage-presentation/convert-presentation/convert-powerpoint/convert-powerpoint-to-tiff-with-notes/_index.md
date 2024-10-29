---
title: Convertir PowerPoint en TIFF avec Notes
type: docs
weight: 100
url: /fr/python-net/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint en TIFF avec notes"
description: "Convertir PowerPoint en TIFF avec notes dans Aspose.Slides."
---

{{% alert title="Astuce" color="primary" %}}

Vous voudrez peut-être jeter un œil à Aspose [convertisseur GRATUIT de PowerPoint en Poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

TIFF est l'un des nombreux formats d'image largement utilisés que Aspose.Slides pour Python via .NET prend en charge pour convertir des présentations PowerPoint PPT et PPTX avec des notes en images. Vous pouvez également générer des miniatures de diapositives dans la vue de Diapositive de Notes. La méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exposée par la classe Presentation peut être utilisée pour convertir l'intégralité de la présentation en vue de Diapositive de Notes en TIFF. Enregistrer une présentation Microsoft PowerPoint en TIFF avec des notes avec Aspose.Slides pour Python via .NET est un processus en deux lignes. Vous ouvrez simplement la présentation et l'enregistrez en tant que TIFF avec des notes. Vous pouvez également générer une miniature de diapositive en vue de Diapositive de Notes pour des diapositives individuelles. Les extraits de code ci-dessous mettent à jour la présentation d'exemple en images TIFF dans la vue de Diapositive de Notes, comme indiqué ci-dessous :

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
presentation = slides.Presentation("pres.pptx")

# Enregistrer la présentation en TIFF avec des notes
presentation.save("Notes_In_Tiff_out.tiff", slides.export.SaveFormat.TIFF)
```