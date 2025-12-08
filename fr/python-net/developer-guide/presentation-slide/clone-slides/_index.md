---
title: Cloner des diapositives PowerPoint en Python
linktitle: Cloner des diapositives
type: docs
weight: 40
url: /fr/python-net/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- enregistrer diapositive
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Clonez ou dupliquez rapidement des diapositives PowerPoint avec Aspose.Slides for Python via .NET. Suivez nos exemples de code clairs et nos conseils pour automatiser la création de PPT en quelques secondes, augmenter la productivité et éliminer le travail manuel."
---

## **Vue d'ensemble**

Le clonage est le processus de creation d'une copie exacte ou d'une réplique de quelque chose. Aspose.Slides for Python via .NET vous permet de cloner n'importe quelle diapositive et d'insérer ce clone dans la présentation actuelle ou dans une autre présentation ouverte. Le processus de clonage crée une nouvelle diapositive que vous pouvez modifier sans affecter l'original.

- Cloner une diapositive à la fin dans la même présentation.
- Cloner une diapositive à une position spécifique dans la même présentation.
- Cloner une diapositive à la fin d'une autre présentation.
- Cloner une diapositive à une position spécifique dans une autre présentation.
- Cloner une diapositive avec sa diapositive maître dans une autre présentation.

Dans Aspose.Slides for Python via .NET, la [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) exposée par l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) fournit les méthodes `add_clone` et `insert_clone` pour effectuer ces types de clonage de diapositives.

## **Cloner à la fin dans la même présentation**

Si vous voulez cloner une diapositive dans la même présentation et l'ajouter à la fin des diapositives existantes, utilisez la méthode `add_clone`. Suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez la slide collection de l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Appelez la méthode `add_clone` sur le [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), en passant la diapositive à cloner.
1. Enregistrez la présentation modifiée.

Dans l'exemple ci-dessous, la première diapositive (indice 0) est clonée et ajoutée à la fin de la présentation.
```py
import aspose.slides as slides

# Instancie la classe Presentation pour représenter le fichier de présentation.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clone la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Enregistre la présentation modifiée sur le disque.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à une position spécifique dans la même présentation**

Si vous voulez cloner une diapositive dans la même présentation et la placer à une position différente, utilisez la méthode `insert_clone` :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez la slide collection de l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Appelez la méthode `insert_clone` sur le [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/), en passant la diapositive à cloner et l'indice cible pour sa nouvelle position.
1. Enregistrez la présentation modifiée.

Dans l'exemple ci-dessous, la diapositive à l'indice 0 (position 1) est clonée à l'indice 1 (position 2) dans la même présentation.
```py
import aspose.slides as slides

# Instancie la classe Presentation pour représenter le fichier de présentation.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clone la diapositive souhaitée à la position spécifiée (indice) dans la même présentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Enregistre la présentation modifiée sur le disque.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à la fin d'une autre présentation**

Si vous devez cloner une diapositive d'une présentation source et l'ajouter à la fin d'une présentation de destination :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour la présentation source (celle qui contient la diapositive à cloner).
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour la présentation de destination (où la diapositive sera ajoutée).
1. Récupérez la slide collection de la présentation de destination.
1. Appelez `add_clone` sur le [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de destination, en passant la diapositive de la présentation source.
1. Enregistrez la présentation de destination modifiée.

Dans l'exemple ci-dessous, la diapositive à l'indice 0 de la présentation source est clonée à la fin de la présentation de destination.
```py
import aspose.slides as slides

# Instancie la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instancie la classe Presentation pour le PPTX de destination (où la diapositive sera clonée).
    with slides.Presentation() as target_presentation:
        # Clone la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Enregistre la présentation de destination sur le disque.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à une position spécifique dans une autre présentation**

Si vous devez cloner une diapositive d'une présentation et l'insérer dans une autre présentation à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour la présentation source (celle contenant la diapositive à cloner).
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour la présentation de destination (où la diapositive sera ajoutée).
1. Récupérez la slide collection de la présentation de destination.
1. Appelez la méthode `insert_clone` sur le [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de destination, en passant la diapositive de la présentation source et l'indice cible souhaité.
1. Enregistrez la présentation de destination modifiée.

Dans l'exemple ci-dessous, la diapositive à l'indice 0 de la présentation source est clonée à l'indice 1 (position 2) dans la présentation de destination.
```py
import aspose.slides as slides

# Instancie la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instancie la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Insère un clone de la première diapositive de la source à l'indice 2 dans la présentation de destination.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Enregistre la présentation de destination sur le disque.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner une diapositive avec sa diapositive maître dans une autre présentation**

Si vous devez cloner une diapositive **avec son maître** d'une présentation et l'utiliser dans une autre, commencez par cloner la diapositive maître requise de la présentation source vers la présentation de destination. Utilisez ensuite ce maître de destination lors du clonage de la diapositive. La méthode `add_clone(Slide, MasterSlide)` attend une **diapositive maître de la présentation de destination**, et non de la source.

Pour cloner une diapositive avec son maître, suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour la présentation source (celle contenant la diapositive à cloner).
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour la présentation de destination.
1. Accédez à la diapositive source à cloner ainsi qu'à sa diapositive maître.
1. Récupérez le [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) de la collection de maîtres de la présentation de destination.
1. Appelez `add_clone` sur le [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) de destination, en passant le maître source pour le cloner dans la destination.
1. Récupérez le [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de la collection de diapositives de la présentation de destination.
1. Appelez `add_clone` sur le [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de destination, en passant la diapositive source et le maître de destination cloné.
1. Enregistrez la présentation de destination modifiée.

Dans l'exemple ci-dessous, la diapositive à l'indice 0 de la présentation source est clonée à la fin de la présentation de destination en utilisant le maître cloné depuis la source.
```py
import aspose.slides as slides

# Instancie la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instancie la classe Presentation pour la présentation de destination où la diapositive sera clonée.
    with slides.Presentation() as target_presentation:
        # Récupère la première diapositive de la présentation source.
        source_slide = source_presentation.slides[0]
        # Récupère la diapositive maître utilisée par la première diapositive.
        source_master = source_slide.layout_slide.master_slide
        # Clone la diapositive maître dans la collection de maîtres de la présentation de destination.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clone la diapositive de la présentation source à la fin de la présentation de destination en utilisant le maître cloné.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Enregistre la présentation de destination sur le disque.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à la fin dans une section spécifiée**

Avec Aspose.Slides for Python via .NET, vous pouvez cloner une diapositive d'une section d'une présentation et l'insérer dans une autre section de la même présentation. Pour ce faire, utilisez la méthode `add_clone(Slide, Section)` de l'interface [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

L'exemple Python suivant montre comment cloner une diapositive et insérer le clone dans une section spécifiée :
```py
import aspose.slides as slides

# Crée une nouvelle présentation vierge.
with slides.Presentation() as presentation:
    # Ajoute une diapositive vide basée sur la mise en page de la première diapositive.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Ajoute une forme ellipse à la nouvelle diapositive ; cette diapositive sera clonée plus tard.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Ajoute une autre diapositive vide basée sur la mise en page de la première diapositive.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Crée une section nommée "Section2" qui commence à slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Clone la diapositive créée précédemment dans la section "Section2".
    presentation.slides.add_clone(slide, section)
    # Enregistre la présentation au format PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Les notes du présentateur et les commentaires des examinateurs sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez-les](/slides/fr/python-net/presentation-notes/) après l'insertion.

**Comment les graphiques et leurs sources de données sont-ils gérés ?**

L'objet du graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par exemple, un classeur intégré OLE), ce lien est conservé sous forme d'[objet OLE](/slides/fr/python-net/manage-ole/). Après le déplacement entre les fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis-je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/python-net/slide-section/) choisie. Si la section cible n'existe pas, créez-la d'abord puis déplacez la diapositive dedans.