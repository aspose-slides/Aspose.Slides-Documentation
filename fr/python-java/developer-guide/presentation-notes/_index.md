---
title: Gérer les notes de présentation en Python via Java
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/python-java/presentation-notes/
keywords:
- notes
- diapositive de notes
- ajouter des notes
- supprimer des notes
- style des notes
- notes maîtres
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Personnalisez les notes de présentation avec Aspose.Slides pour Python via Java. Travaillez en toute transparence avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---
## **Vue d'ensemble**

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Ce sujet présente cette fonctionnalité, y compris comment supprimer les notes et comment appliquer un style aux diapositives de notes dans une présentation. Aspose.Slides vous permet de supprimer les notes de n’importe quelle diapositive et d’appliquer un style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

- Supprimer les notes d’une diapositive spécifique dans une présentation.
- Supprimer les notes de toutes les diapositives d’une présentation.

Pour lire ou modifier les dimensions de la page de notes, changer l’orientation et vérifier le comportement d’exportation, voir [Taille de la page de notes](/slides/fr/python-java/notes-size/).

## **Supprimer les notes d’une diapositive**

Les notes d’une diapositive spécifique peuvent être supprimées comme le montre l’exemple ci-dessous :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancie un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("presWithNotes.pptx")
try:
    # Supprime les notes de la première diapositive.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Enregistre la présentation sur le disque.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Supprimer les notes d’une présentation**

Les notes de toutes les diapositives d’une présentation peuvent être supprimées comme le montre l’exemple ci-dessous :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancie un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("presWithNotes.pptx")
try:
    # Supprime les notes de toutes les diapositives.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Enregistre la présentation sur le disque.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter un style de notes**

La méthode [getNotesStyle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslide/#getNotesStyle) de la classe [MasterNotesSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslide/) fournit un accès au style du texte des notes. L’implémentation est illustrée dans l’exemple ci-dessous.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Instancie un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Obtient le style de texte de la diapositive de notes maîtres.
        notes_style = notes_master.getNotesStyle()

        # Définit des puces symboliques pour les paragraphes de premier niveau.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quelle entité API fournit l’accès aux notes d’une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive dispose d’un [NotesSlideManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notesslidemanager/) et d’une méthode [getNotesSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notesslidemanager/#getNotesSlide) qui renvoie l’objet notes, ou `None` s’il n’y a aucune note.

**Existe-t-il des différences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible un large éventail de formats Microsoft PowerPoint (97 et suivants) ainsi que le format ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.