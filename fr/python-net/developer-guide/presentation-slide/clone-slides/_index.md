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
description: "Clonez ou dupliquez rapidement des diapositives PowerPoint avec Aspose.Slides pour Python via .NET. Suivez nos exemples de code clairs et nos astuces pour automatiser la création de PPT en quelques secondes, augmenter la productivité et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus de creation d'une copie exacte ou d'une replica de quelque chose. Aspose.Slides permet egalement de copier (cloner) n'importe quelle diapositive puis d'insérer la diapositive clonee dans la presentation actuelle ou dans toute autre presentation ouverte. Le clonage de diapositives cree une nouvelle diapositive que les developpeurs peuvent modifier sans affecter la diapositive originale. Il existe plusieurs facons de cloner une diapositive :

- Cloner a la fin d'une presentation.
- Cloner a une autre position dans une presentation.
- Cloner a la fin d'une autre presentation.
- Cloner a une autre position dans une autre presentation.
- Cloner a une position specifique dans une autre presentation.

Dans Aspose.Slides pour Python via .NET, la [collection de diapositives](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) exposee par l'objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) fournit les methodes `add_clone` et `insert_clone` pour effectuer ces types de clonage de diapositives.

## **Installation**

```bash
pip install aspose.slides
```

## **Cloner a la fin dans la meme presentation**

Si vous souhaitez cloner une diapositive au sein de la meme presentation et l'ajouter a la fin des diapositives existantes, utilisez la methode `add_clone`. Suivez ces etapes :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Recuperer la collection de diapositives a partir de l'objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Appeler la methode `add_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/), en passant la diapositive a cloner.
1. Enregistrer la presentation modifiee.

Dans l'exemple ci-dessous, la premiere diapositive (index 0) est clonee et ajoutee a la fin de la presentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter le fichier de présentation.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Enregistrer la présentation modifiée sur le disque.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner a une position specifique dans la meme presentation**

Si vous souhaitez cloner une diapositive au sein de la meme presentation et la placer a une position differente, utilisez la methode `insert_clone` :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Recuperer la collection de diapositives a partir de l'objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Appeler la methode `insert_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/), en passant la diapositive a cloner et l'index cible pour sa nouvelle position.
1. Enregistrer la presentation modifiee.

Dans l'exemple ci-dessous, la diapositive d'index 1 (position 2) est clonee a l'index 2 (position 3) dans la meme presentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter le fichier de présentation.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Cloner la diapositive souhaitée à la position spécifiée (index) dans la même présentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Enregistrer la présentation modifiée sur le disque.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner a la fin d'une autre presentation**

Si vous devez cloner une diapositive d'une presentation et l'ajouter a la fin d'une autre presentation :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la presentation source (celle qui contient la diapositive a cloner).
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la presentation de destination (ou la diapositive sera ajoutee).
1. Recuperer la collection de diapositives de la presentation de destination.
1. Appeler `add_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) de destination, en passant la diapositive de la presentation source.
1. Enregistrer la presentation de destination modifiee.

Dans l'exemple ci-dessous, la diapositive d'index 0 de la presentation source est clonee a la fin de la presentation de destination.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive sera clonée).
    with slides.Presentation() as target_presentation:
        # Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Enregistrer la présentation de destination sur le disque.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner a une position specifique dans une autre presentation**

Si vous devez cloner une diapositive d'une presentation et l'insérer dans une autre presentation a une position specifique :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la presentation source (celle contenant la diapositive a cloner).
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la presentation de destination (ou la diapositive sera ajoutee).
1. Recuperer la collection de diapositives de la presentation de destination.
1. Appeler la methode `insert_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) de destination, en passant la diapositive de la presentation source et l'index cible souhaite.
1. Enregistrer la presentation de destination modifiee.

Dans l'exemple ci-dessous, la diapositive d'index 0 de la presentation source est clonee a l'index 2 (position 3) dans la presentation de destination.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Insérer un clone de la première diapositive de la source à l'index 2 dans la présentation de destination.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Enregistrer la présentation de destination sur le disque.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner une diapositive avec sa diapositive maitre dans une autre presentation**

Si vous devez cloner une diapositive **avec son maitre** d'une presentation et l'utiliser dans une autre, clonez d'abord la diapositive maitre requise de la presentation source vers la presentation de destination. Utilisez ensuite ce maitre de destination lors du clonage de la diapositive. La methode `add_clone(Slide, MasterSlide)` attend une **diapositive maitre de la presentation de destination**, et non de la source.

Pour cloner une diapositive avec son maitre, suivez ces etapes :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la presentation source (celle contenant la diapositive a cloner).
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la presentation de destination.
1. Acceder a la diapositive source a cloner et a sa diapositive maitre.
1. Recuperer la [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/) de la collection maitre de la presentation de destination.
1. Appeler `add_clone` sur la [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/), en passant le maitre source pour le cloner dans la destination.
1. Recuperer la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) de la collection de diapositives de la presentation de destination.
1. Appeler `add_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/), en passant la diapositive source et le maitre destination clone.
1. Enregistrer la presentation de destination modifiee.

Dans l'exemple ci-dessous, la diapositive d'index 0 de la presentation source est clonee a la fin de la presentation de destination en utilisant le maitre clone depuis la source.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instancier la classe Presentation pour la présentation de destination où la diapositive sera clonée.
    with slides.Presentation() as target_presentation:
        # Obtenir la première diapositive de la présentation source.
        source_slide = source_presentation.slides[0]
        # Obtenir la diapositive maître utilisée par la première diapositive.
        source_master = source_slide.layout_slide.master_slide
        # Cloner la diapositive maître dans la collection maîtres de la présentation de destination.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Cloner la diapositive de la présentation source à la fin de la présentation de destination en utilisant le maître cloné.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Enregistrer la présentation de destination sur le disque.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner a la fin dans une section specifiee**

Grace a Aspose.Slides pour Python via .NET, vous pouvez cloner une diapositive d'une section d'une presentation et l'insérer dans une autre section de la meme presentation. Pour ce faire, utilisez la methode `add_clone(Slide, Section)` de la classe [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/).

L'exemple Python suivant montre comment cloner une diapositive et inserer le clone dans une section specifiee :

```py
import aspose.slides as slides

# Créer une nouvelle présentation vierge.
with slides.Presentation() as presentation:
    # Ajouter une diapositive vide basée sur la disposition de la première diapositive.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Ajouter une forme ellipse à la nouvelle diapositive ; cette diapositive sera clonée plus tard.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Ajouter une autre diapositive vide basée sur la disposition de la première diapositive.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Créer une section nommée "Section2" qui commence à slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Cloner la diapositive créée précédemment dans la section "Section2".
    presentation.slides.add_clone(slide, section)
    # Enregistrer la présentation en tant que fichier PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Assurer une correspondance de la taille des diapositives**

Lors du clonage de diapositives dans une autre presentation, assurez-vous que la presentation de destination a la meme taille de diapositive que la source. Si les tailles de diapositives diffèrent, Aspose.Slides ne redimensionne pas automatiquement les formes clones; leurs coordonnees et dimensions d'origine sont conservees, ce qui peut entraîner un mauvais alignement du contenu ou son depassement des limites de la diapositive.

Vous pouvez definir la taille des diapositives de la presentation de destination pour qu'elle corresponde a celle de la source avant de cloner le maitre et la diapositive :

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Faites-le avant de cloner le maitre et la diapositive.

## **FAQ**

**Les notes du presentateur et les commentaires des relecteurs sont-ils clones ?**

Oui. La page de notes et les commentaires de revision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez-les](/slides/fr/python-net/presentation-notes/) apres l'insertion.

**Comment les graphiques et leurs sources de donnees sont-ils gérés ?**

L'objet du graphique, son formatage et les donnees integrees sont copies. Si le graphique etait lie a une source externe (par ex., un classeur OLE integre), ce lien est conserve sous forme d'[objet OLE](/slides/fr/python-net/manage-ole/). Apres le deplacement entre fichiers, verifiez la disponibilite des donnees et le comportement de rafraichissement.

**Puis-je controler la position d'insertion et les sections du clone ?**

Oui. Vous pouvez inserer le clone a un index de diapositive specifique et le placer dans une [section](/slides/fr/python-net/slide-section/) choisissez. Si la section cible n'existe pas, creez-la d'abord puis deplacez la diapositive dans celle-ci.