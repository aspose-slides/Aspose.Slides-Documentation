---
title: Gérer les notes de présentation en Python
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/python-net/presentation-notes/
keywords:
- notes
- diapositive de notes
- ajouter des notes
- supprimer des notes
- style de notes
- notes maîtres
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Personnalisez les notes de présentation avec Aspose.Slides pour Python via .NET. Travaillez de manière fluide avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Dans ce sujet, nous présenterons cette nouvelle fonctionnalité de suppression des notes ainsi que l’ajout de styles de notes à partir de n’importe quelle présentation. Aspose.Slides for Python via .NET offre la possibilité de supprimer les notes d’une diapositive ainsi que d’ajouter un style aux notes existantes. Les développeurs peuvent supprimer les notes de plusieurs façons :

- Supprimer les notes d’une diapositive spécifique d’une présentation.
- Supprimer les notes de toutes les diapositives d’une présentation.
## **Supprimer les notes d’une diapositive**
Les notes d’une diapositive précise peuvent être supprimées comme le montre l’exemple ci‑dessous :

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Suppression des notes de la première diapositive
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # enregistrer la présentation sur le disque
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer les notes de toutes les diapositives**
Les notes de toutes les diapositives d’une présentation peuvent être supprimées comme le montre l’exemple ci‑dessous :

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Suppression des notes de toutes les diapositives
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # enregistrer la présentation sur le disque
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter le style de notes**
La propriété NotesStyle a été ajoutée à l’interface [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) respectivement. Cette propriété spécifie le style du texte des notes. L’implémentation est démontrée dans l’exemple ci‑dessous.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obtenir le style de texte du MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # Définir le symbole de puce pour les paragraphes de premier niveau
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # enregistrer le fichier PPTX sur le disque
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quelle entité API permet d’accéder aux notes d’une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) et une [property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) qui renvoie l’objet des notes, ou `None` s’il n’y a pas de notes.

**Existe-t-il des différences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible une large gamme de formats Microsoft PowerPoint (97 et versions ultérieures) ainsi que ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.