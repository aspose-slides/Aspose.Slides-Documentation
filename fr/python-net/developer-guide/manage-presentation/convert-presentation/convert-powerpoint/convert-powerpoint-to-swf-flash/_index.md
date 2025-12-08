---
title: Convertir les présentations PowerPoint en Flash SWF avec Python
linktitle: PowerPoint vers Flash SWF
type: docs
weight: 80
url: /fr/python-net/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- PowerPoint vers SWF
- présentation vers SWF
- diapositive vers SWF
- PPT vers SWF
- PPTX vers SWF
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en Flash SWF avec Python et Aspose.Slides. Exemples de code pas à pas, sortie rapide et de qualité, sans automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

La méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) peut être utilisée pour convertir la présentation entière en document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.
```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sauvegarder la présentation et les pages de notes
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```


## **FAQ**

**Puis-je inclure des diapositives cachées dans le SWF ?**

Oui. Activez l’option [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) dans [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). Par défaut, les diapositives cachées ne sont pas exportées.

**Comment puis‑je contrôler la compression et la taille finale du SWF ?**

Utilisez le drapeau [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (activé par défaut) et ajustez [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) pour équilibrer la taille du fichier et la fidélité de l’image.

**À quoi sert 'viewer_included' et quand devrais‑je le désactiver ?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) ajoute une interface de lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez‑la si vous prévoyez d’utiliser votre propre lecteur ou si vous avez besoin d’un cadre SWF dépouillé sans interface.

**Que se passe‑t‑il si une police source est absente sur la machine d’exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) dans [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) afin d’éviter un repli imprévu.