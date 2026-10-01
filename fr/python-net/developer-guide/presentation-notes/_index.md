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
## **Vue d'ensemble**

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Dans cet article, nous présentons cette fonctionnalité, y compris la façon de supprimer les notes et d’appliquer un style aux diapositives de notes dans une présentation. Aspose.Slides vous permet de supprimer les notes de n’importe quelle diapositive et également d’appliquer un style aux notes existantes. Les développeurs peuvent supprimer les notes de plusieurs manières :

- Supprimer les notes d’une diapositive spécifique dans une présentation.
- Supprimer les notes de toutes les diapositives d’une présentation.

Pour lire ou modifier les dimensions de la page de notes, changer l’orientation et vérifier le comportement d’exportation, voir [Notes Page Size](/slides/fr/python-net/notes-size/).

## **Supprimer les notes d’une diapositive**
Les notes d’une diapositive spécifique peuvent être supprimées comme le montre l’exemple ci‑dessous :

```py
import aspose.slides as slides

# Instanciez un objet Presentation qui représente un fichier de présentation 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Suppression des notes de la première diapositive
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # enregistrer la présentation sur le disque
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer les notes de toutes les diapositives**
Les notes de toutes les diapositives d’une présentation peuvent être supprimées comme le montre l’exemple ci‑dessous :

```py
import aspose.slides as slides

# Instanciez un objet Presentation qui représente un fichier de présentation 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Suppression des notes de toutes les diapositives
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # enregistrer la présentation sur le disque
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Appliquer un style de notes**
La propriété [notes_style](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslide/notes_style/) a été ajoutée à la classe [MasterNotesSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masternotesslide/). Cette propriété spécifie le style du texte des notes. L’implémentation est démontrée dans l’exemple ci‑dessous.

```py
import aspose.slides as slides

# Instanciez la classe Presentation qui représente le fichier de présentation
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Obtenez le style de texte du MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Définir le symbole de puce pour les paragraphes du premier niveau
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # enregistrer le fichier PPTX sur le disque
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quel entité API fournit l’accès aux notes d’une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notesslidemanager/) et une [property](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notesslidemanager/notes_slide/) qui renvoie l’objet notes, ou `None` s’il n’y a pas de notes.

**Existe‑t‑il des différences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible une large gamme de formats Microsoft PowerPoint (97‑plus récent) et ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.