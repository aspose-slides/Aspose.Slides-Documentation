---
title: Convertir les présentations PowerPoint en Flash SWF avec Python
linktitle: PowerPoint en Flash SWF
type: docs
weight: 80
url: /fr/python-net/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir une présentation
- convertir une diapositive
- PowerPoint en SWF
- présentation en SWF
- diapositive en SWF
- PPT en SWF
- PPTX en SWF
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en Flash SWF avec Python et Aspose.Slides. Exemples de code pas à pas, sortie rapide et de haute qualité, sans automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

The [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class can be used to convert the entire presentation into an SWF document. You can also include comments in the generated SWF by using the [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) class and the [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) interface. The following example shows how to convert a presentation into an SWF document using the options provided by the SWFOptions class.

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

**Puis-je inclure des diapositives cachées dans le SWF ?**

Oui. Activez l’option [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) dans [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). Par défaut, les diapositives cachées ne sont pas exportées.

**Comment puis‑je contrôler la compression et la taille finale du SWF ?**

Utilisez le drapeau [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (activé par défaut) et ajustez [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) pour équilibrer la taille du fichier et la fidélité de l’image.

**À quoi sert 'viewer_included' et quand doit‑il être désactivé ?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) ajoute une interface utilisateur de lecteur intégré (contrôles de navigation, panneaux, recherche). Désactivez‑le si vous prévoyez d’utiliser votre propre lecteur ou si vous avez besoin d’un cadre SWF vierge sans UI.

**Que se passe‑t‑il si une police source est manquante sur la machine d’exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) dans [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) afin d’éviter un remplacement inattendu.