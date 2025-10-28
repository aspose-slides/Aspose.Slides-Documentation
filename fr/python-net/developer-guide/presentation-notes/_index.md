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
description: "Personnalisez les notes de présentation avec Aspose.Slides pour Python via .NET. Travaillez facilement avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Dans cet article, nous présenterons cette nouvelle fonctionnalité de suppression des notes ainsi que l’ajout de diapositives de style de notes à partir de n’importe quelle présentation. Aspose.Slides pour Python via .NET offre la possibilité de supprimer les notes de n’importe quelle diapositive ainsi que d’ajouter un style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

- Supprimer les notes d’une diapositive spécifique d’une présentation.
- Supprimer les notes de toutes les diapositives d’une présentation.

## **Supprimer les notes d’une diapositive**
Notes de certaines diapositives spécifiques peuvent être supprimées comme le montre l’exemple ci‑dessous :

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of first slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # save presentation to disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer les notes de toutes les diapositives**
Notes de toutes les diapositives d’une présentation peuvent être supprimées comme le montre l’exemple ci‑dessus :

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of all slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # save presentation to disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter un style de notes**
La propriété NotesStyle a été ajoutée à l’interface [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) respectivement. Cette propriété spécifie le style du texte des notes. L’implémentation est illustrée dans l’exemple ci‑dessous.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Get MasterNotesSlide text style
        notesStyle = notesMaster.notes_style

        #Set symbol bullet for the first level paragraphs
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # save the PPTX file to the Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quelle entité API donne accès aux notes d’une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : chaque diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) et une [property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) qui renvoie l’objet notes, ou `None` s’il n’y a pas de notes.

**Existe‑t‑il des différences de prise en charge des notes selon les versions de PowerPoint compatibles avec la bibliothèque ?**

La bibliothèque cible une large gamme de formats Microsoft PowerPoint (97 et versions ultérieures) ainsi que ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.