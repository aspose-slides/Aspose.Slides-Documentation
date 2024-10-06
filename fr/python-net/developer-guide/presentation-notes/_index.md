---
title: Notes de présentation
type: docs
weight: 110
url: /python-net/presentation-notes/
keywords: "Notes, notes PowerPoint, ajouter des notes, supprimer des notes, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter et supprimer des notes dans des présentations PowerPoint en Python"
---



Aspose.Slides prend en charge la suppression des diapositives de notes d'une présentation. Dans ce sujet, nous allons introduire cette nouvelle fonctionnalité de suppression de notes ainsi que l'ajout de diapositives de style de notes à partir de n'importe quelle présentation. Aspose.Slides pour Python via .NET fournit la fonctionnalité de suppression des notes de n'importe quelle diapositive ainsi que d'ajouter un style aux notes existantes. Les développeurs peuvent supprimer des notes de la manière suivante :

- Supprimer les notes d'une diapositive spécifique d'une présentation.
- Supprimer les notes de toutes les diapositives d'une présentation.
## **Supprimer des notes d'une diapositive**
Les notes d'une diapositive spécifique peuvent être supprimées comme montré dans l'exemple ci-dessous :

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


## **Supprimer des notes de toutes les diapositives**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme montré dans l'exemple ci-dessous :

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


## **Ajouter NotesStyle**
La propriété NotesStyle a été ajoutée à l'interface [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) respectivement. Cette propriété spécifie le style d'un texte de notes.  L'implémentation est démontrée dans l'exemple ci-dessous.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obtenir le style de texte du MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # Définir un symbole de puce pour les paragraphes de premier niveau
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # enregistrer le fichier PPTX sur le disque
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```