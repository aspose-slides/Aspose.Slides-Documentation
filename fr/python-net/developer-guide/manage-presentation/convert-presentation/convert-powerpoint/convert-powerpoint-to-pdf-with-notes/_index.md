---
title: Convertir des présentations en PDF avec notes en Python
linktitle: Présentation en PDF avec notes
type: docs
weight: 50
url: /fr/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir PPT
- convertir PPTX
- convertir ODP
- PowerPoint en PDF
- OpenDocument en PDF
- présentation en PDF
- PPT en PDF
- PPTX en PDF
- ODP en PDF
- notes du présentateur
- PDF avec notes
- Python
- Aspose.Slides
description: "Convertir les formats PPT, PPTX et ODP en PDF avec notes à l'aide d'Aspose.Slides pour Python. Conserver les mises en page et les notes du présentateur pour des présentations professionnelles."
---
## **Vue d'ensemble**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l'aide d'Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à réaliser cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en conservant les notes du présentateur.
- Personnaliser le PDF de sortie afin que les notes du présentateur soient incluses et formatées selon vos exigences.

Pour définir les dimensions et l'orientation de la page des notes avant l'exportation, consultez [Taille de la page des notes](/slides/fr/python-net/notes-size/).

## **Convertir PowerPoint en PDF avec notes**

La méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il suffit de charger la présentation, de configurer les options de mise en page à l'aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d’enregistrer le fichier au format PDF. Le fragment de code suivant montre comment convertir une présentation d'exemple en PDF en vue des diapositives de notes.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Configurez les options PDF pour le rendu des notes du présentateur.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Enregistrez la présentation en PDF avec les notes du présentateur.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Vous pouvez consulter le [Convertisseur PowerPoint en PDF en ligne d'Aspose](https://products.aspose.app/slides/fr/conversion).
{{% /alert %}}