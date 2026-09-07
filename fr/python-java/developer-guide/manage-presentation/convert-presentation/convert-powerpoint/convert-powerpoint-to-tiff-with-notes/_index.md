---
title: Convertir des présentations PowerPoint en TIFF avec notes en Python
linktitle: PowerPoint en TIFF avec notes
type: docs
weight: 100
url: /fr/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- enregistrer PPT en tant que TIFF
- enregistrer PPTX en tant que TIFF
- exporter PPT en TIFF
- exporter PPTX en TIFF
- PowerPoint avec notes
- présentation avec notes
- diapositive avec notes
- PPT avec notes
- PPTX avec notes
- TIFF avec notes
- Python
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint en TIFF avec notes en utilisant Aspose.Slides pour Python via Java. Apprenez comment exporter efficacement les diapositives avec les notes du présentateur."
---
## **Introduction**

Aspose.Slides for Python via Java fournit une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d'images haute qualité, l'impression et l'archivage de documents. Utilisez la méthode [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) pour exporter les diapositives et leurs notes du présentateur vers un seul fichier TIFF multipage.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument au format TIFF avec notes à l'aide d'Aspose.Slides for Python via Java implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/): charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de mise en page de sortie : utilisez la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
1. Enregistrer la présentation au format TIFF : transmettez les options configurées à la méthode [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save).

Supposons que nous disposions d'un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![La diapositive de la présentation avec notes du présentateur](slide_with_notes.png)

Le fragment de code ci-dessous montre comment convertir la présentation en image TIFF en vue diapositive avec notes à l'aide de la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Afficher les notes du présentateur complètes sous chaque diapositive.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Configurer la résolution TIFF et la mise en page des notes.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Enregistrer la présentation au format TIFF avec les notes du présentateur.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Le résultat :

![L'image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Découvrez le [Convertisseur gratuit PowerPoint vers Poster d'Aspose](https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Puis-je contrôler la position de la zone de notes dans le TIFF résultant ?**

Oui. Configurez [setNotesPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) avec [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/#BottomTruncated) pour placer les notes sur une page, éventuellement les tronquer, ou [NotesPositions.BottomFull](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/#BottomFull) pour afficher toutes les notes en utilisant des pages supplémentaires si nécessaire. Pour exporter les diapositives sans notes, omettez la configuration de la mise en page des notes comme indiqué dans [Convertir PowerPoint en TIFF](/slides/fr/python-java/convert-powerpoint-to-tiff/).

**Comment réduire la taille d’un fichier TIFF avec notes sans perdre la qualité de l’image ?**

Utilisez la compression sans perte [LZW compression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffcompressiontypes/#LZW) via [setCompressionType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/#setCompressionType). Réduire la résolution ou la profondeur de couleur peut encore diminuer la taille du fichier, mais peut affecter la qualité de l’image et la lisibilité des notes. Consultez les [paramètres d’exportation TIFF](/slides/fr/python-java/convert-powerpoint-to-tiff/) pour plus d’options.

**La police des notes influence-t-elle le résultat si les polices d’origine sont absentes du système ?**

Oui. Les polices manquantes déclenchent la [substitution de police](/slides/fr/python-java/font-selection-sequence/), ce qui peut modifier les métriques et l’apparence du texte. [Fournissez les polices requises](/slides/fr/python-java/custom-font/) pour conserver les typographies prévues.