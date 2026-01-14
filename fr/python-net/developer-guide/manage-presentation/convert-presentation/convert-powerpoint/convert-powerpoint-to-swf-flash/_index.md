---
title: Convertir les présentations PowerPoint en Flash SWF avec Python
linktitle: PowerPoint en Flash SWF
type: docs
weight: 80
url: /fr/python-net/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- PowerPoint en SWF
- présentation en SWF
- diapositive en SWF
- PPT en SWF
- PPTX en SWF
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en Flash SWF avec Python et Aspose.Slides. Exemples de code étape par étape, sortie rapide et de qualité, aucune automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

The [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method exposed by [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class can be used to convert the whole presentation into SWF document. You can also include comments in generated SWF by using [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) class and [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) class. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.
```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Enregistrement de la présentation et des pages de notes
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```


## **FAQ**

**Puis-je inclure les diapositives masquées dans le SWF?**

Oui. Activez l'option [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) dans [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis-je contrôler la compression et la taille finale du SWF?**

Utilisez le drapeau [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (activé par défaut) et ajustez [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) pour équilibrer la taille du fichier et la fidélité des images.

**A quoi sert 'viewer_included' et quand faut-il le désactiver?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) ajoute une interface de lecteur embarquée (contrôles de navigation, panneaux, recherche). Désactivez-le si vous prévoyez d'utiliser votre propre lecteur ou si vous avez besoin d'un cadre SWF minimal sans UI.

**Que se passe-t-il si une police source est absente sur la machine d'exportation?**

Aspose.Slides substituera la police que vous spécifiez via [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) dans [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) afin d'éviter un recours inattendu.