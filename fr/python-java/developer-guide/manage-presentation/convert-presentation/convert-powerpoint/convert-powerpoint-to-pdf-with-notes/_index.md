---
title: Convertir les présentations PowerPoint en PDF avec notes en Python
linktitle: PowerPoint en PDF avec notes
type: docs
weight: 50
url: /fr/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir PPT
- convertir PPTX
- PowerPoint en PDF
- présentation en PDF
- PPT en PDF
- PPTX en PDF
- enregistrer la présentation au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- notes du présentateur
- PDF avec notes
- Python
- Java
- Aspose.Slides
description: "Convertir les présentations PPT et PPTX en PDF avec les notes du présentateur à l'aide d'Aspose.Slides pour Python via Java. Configurer le placement des notes et conserver les notes longues."
---
## **Vue d'ensemble**

Cet article explique comment convertir des présentations PowerPoint en PDF avec les notes du présentateur à l'aide d'Aspose.Slides pour Python via Java. Vous pouvez inclure des notes sous chaque diapositive et permettre aux notes longues de se poursuivre sur des pages supplémentaires. Pour d'autres paramètres d'exportation PDF, voir [Convertir PowerPoint en PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/).

## **Convertir PowerPoint en PDF avec des notes**

Utilisez la méthode [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) pour exporter une présentation PPT ou PPTX vers PDF. Pour inclure les notes du présentateur, créez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/) et configurez sa méthode [setNotesPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Assignez cette mise en page à [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) en utilisant [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

L'exemple suivant charge `sample.pptx` et l'exporte vers `output.pdf` avec les notes du présentateur sous les diapositives :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configurer les options PDF pour le rendu des notes du présentateur.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Enregistrer la présentation au format PDF avec les notes du présentateur.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Vous pouvez également essayer le [Convertisseur PowerPoint en PDF en ligne](https://products.aspose.app/slides/fr/conversion).
{{% /alert %}}

## **FAQ**

**Comment éviter que les notes longues du présentateur ne soient tronquées ?**

Utilisez [NotesPositions.BottomFull](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/#BottomFull), comme dans l'exemple ci‑dessus. Ce paramètre affiche les notes complètes, en utilisant des pages supplémentaires si besoin.

**Puis‑je garder chaque diapositive et ses notes sur une seule page ?**

Utilisez [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/#BottomTruncated). Ce paramètre limite les notes à une page, ainsi les notes qui ne tiennent pas peuvent être tronquées.

**Comment exporter les diapositives sans les notes du présentateur ?**

Omettez la configuration de mise en page des notes et utilisez l'exportation PDF standard décrite dans [Convertir PowerPoint en PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/).