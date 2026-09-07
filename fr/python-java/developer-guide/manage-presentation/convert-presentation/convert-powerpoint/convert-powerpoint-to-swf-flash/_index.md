---
title: Convertir des présentations PowerPoint en SWF Flash avec Python via Java
linktitle: PowerPoint vers SWF
type: docs
weight: 80
url: /fr/python-java/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers SWF
- présentation vers SWF
- diapositive vers SWF
- PPT vers SWF
- PPTX vers SWF
- PowerPoint vers Flash
- présentation vers Flash
- diapositive vers Flash
- PPT vers Flash
- PPTX vers Flash
- enregistrer PPT en SWF
- enregistrer PPTX en SWF
- exporter PPT en SWF
- exporter PPTX en SWF
- Python
- Java
- Aspose.Slides
description: "Convertissez des présentations PowerPoint en SWF Flash avec Python via Java grâce à Aspose.Slides. Configurez le visualiseur, les notes, les diapositives masquées, la compression et les polices."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet de convertir des présentations PowerPoint en SWF sans Microsoft PowerPoint. Utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour exporter la présentation et [SwfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/) pour configurer les paramètres du visualiseur, la qualité des images et la mise en page des notes ou des commentaires.

## **Convertir des présentations en Flash**

Chargez le fichier source avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), configurez [SwfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/) et enregistrez-le en utilisant [SaveFormat.Swf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Swf).

L'exemple suivant exporte `presentation.pptx` vers `presentation.swf`. Il désactive le visualiseur intégré avec [setViewerIncluded](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/#setViewerIncluded) et inclut les notes du présentateur sous les diapositives à l'aide de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Avant d'exécuter l'exemple, [installez Aspose.Slides for Python via Java](/slides/fr/python-java/installation/) et placez `presentation.pptx` dans le répertoire de travail. La JVM est démarrée une fois par processus Python.

L'exemple applique [NotesPositions.BottomFull](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/#BottomFull) via [setNotesPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) et transmet la mise en page à [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Pour inclure également les commentaires, configurez [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) avant l'export.

## **FAQ**

**Puis-je inclure les diapositives masquées dans le SWF ?**

Oui. Appelez [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) avec `True`. Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis-je contrôler la compression et la taille finale du SWF ?**

Utilisez [SwfOptions.setCompressed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/#setCompressed) pour activer ou désactiver la compression et [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/#setJpegQuality) pour ajuster la qualité des images JPEG. Une qualité JPEG plus basse peut réduire la taille du fichier au détriment de la fidélité de l'image.

**À quoi sert le visualiseur intégré et quand devrais-je le désactiver ?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/#setViewerIncluded) contrôle si le SWF généré inclut le visualiseur. Passez `False` lorsque vous avez besoin des diapositives exportées sans le visualiseur intégré, comme dans l'exemple ci‑dessus.

**Que se passe-t-il si une police source est absente sur la machine d'exportation ?**

Vous pouvez spécifier une police régulière par défaut avec [setDefaultRegularFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), héritée par [SwfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/swfoptions/). Choisissez une police disponible pour le processus d'exportation ; la substitution de police peut modifier l'apparence du texte et la mise en page.