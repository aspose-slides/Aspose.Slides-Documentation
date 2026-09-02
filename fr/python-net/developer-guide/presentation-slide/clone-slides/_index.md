---
title: Cloner des diapositives PowerPoint en Python
linktitle: Cloner les diapositives
type: docs
weight: 40
url: /fr/python-net/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- sauvegarder diapositive
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Clonez rapidement ou dupliquez des diapositives PowerPoint avec Aspose.Slides pour Python via .NET. Suivez nos exemples de code clairs et nos conseils pour automatiser la création de PPT en quelques secondes, augmenter la productivité et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus de création d'une copie exacte ou d'une réplique de quelque chose. Aspose.Slides permet également de copier (cloner) n'importe quelle diapositive, puis d'insérer la diapositive clonée dans la présentation en cours ou dans toute autre présentation ouverte. Le clonage de diapositives crée une nouvelle diapositive que les développeurs peuvent modifier sans affecter la diapositive originale. Il existe plusieurs façons de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à une autre position dans une présentation.
- Cloner à la fin d'une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides pour Python via .NET, la [collection de diapositives](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) fournit les méthodes `add_clone` et `insert_clone` pour effectuer ces types de clonage de diapositives.

## **Installation**

```bash
pip install aspose.slides
```

## **Cloner à la fin dans la même présentation**

Si vous souhaitez cloner une diapositive dans la même présentation et l'ajouter à la fin des diapositives existantes, utilisez la méthode `add_clone`. Suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Récupérez la collection de diapositives à partir de l'objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
3. Appelez la méthode `add_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/), en passant la diapositive à cloner.
4. Enregistrez la présentation modifiée.

Dans l’exemple ci‑dessous, la première diapositive (index 0) est clonée et ajoutée à la fin de la présentation.

```py
import aspose.slides as slides

# Instanciez la classe Presentation pour représenter le fichier de présentation.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Clonez la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation.
    presentation.slides.add_clone(presentation.slides[0])
    # Enregistrez la présentation modifiée sur le disque.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner à une position spécifique dans la même présentation**

Si vous souhaitez cloner une diapositive dans la même présentation et la placer à une position différente, utilisez la méthode `insert_clone` :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Récupérez la collection de diapositives à partir de l'objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
3. Appelez la méthode `insert_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/), en passant la diapositive à cloner et l'index cible pour sa nouvelle position.
4. Enregistrez la présentation modifiée.

Dans l’exemple ci‑dessous, la diapositive à l’index 1 (position 2) est clonée à l’index 2 (position 3) dans la même présentation.

```py
import aspose.slides as slides

# Instanciez la classe Presentation pour représenter le fichier de présentation.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Clonez la diapositive souhaitée à la position spécifiée (index) dans la même présentation.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Enregistrez la présentation modifiée sur le disque.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner à la fin d’une autre présentation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la présentation source (celle qui contient la diapositive à cloner).
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la présentation de destination (où la diapositive sera ajoutée).
3. Récupérez la collection de diapositives de la présentation de destination.
4. Appelez `add_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) de destination, en passant la diapositive de la présentation source.
5. Enregistrez la présentation de destination modifiée.

Dans l’exemple ci‑dessous, la diapositive à l’index 0 dans la présentation source est clonée à la fin de la présentation de destination.

```py
import aspose.slides as slides

# Instanciez la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanciez la classe Presentation pour le PPTX de destination (où la diapositive sera clonée).
    with slides.Presentation() as target_presentation:
        # Clonez la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Enregistrez la présentation de destination sur le disque.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner à une position spécifique dans une autre présentation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la présentation source (celle qui contient la diapositive à cloner).
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la présentation de destination (où la diapositive sera ajoutée).
3. Récupérez la collection de diapositives de la présentation de destination.
4. Appelez la méthode `insert_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) de destination, en passant la diapositive de la présentation source et l'index cible souhaité.
5. Enregistrez la présentation de destination modifiée.

Dans l’exemple ci‑dessous, la diapositive à l’index 0 dans la présentation source est clonée à l’index 2 (position 3) dans la présentation de destination.

```py
import aspose.slides as slides

# Instanciez la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Instanciez la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Insérez un clone de la première diapositive de la source à l'index 2 dans la présentation de destination.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Enregistrez la présentation de destination sur le disque.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner une diapositive avec sa diapositive maîtresse dans une autre présentation**

Si vous devez cloner une diapositive **avec son maître** d'une présentation et l'utiliser dans une autre, clonez d'abord la diapositive maître requise de la présentation source vers la présentation de destination. Utilisez ensuite ce maître de destination lors du clonage de la diapositive. La méthode `add_clone(Slide, MasterSlide)` attend un **maître de la présentation de destination**, pas de la source.

Pour cloner une diapositive avec son maître, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la présentation source (celle qui contient la diapositive à cloner).
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour la présentation de destination.
3. Accédez à la diapositive source à cloner et à son maître.
4. Récupérez la [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/) de la collection de maîtres de la présentation de destination.
5. Appelez `add_clone` sur la [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/), en passant le maître source pour le cloner dans la destination.
6. Récupérez la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) de la collection de diapositives de la présentation de destination.
7. Appelez `add_clone` sur la [SlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/), en passant la diapositive source et le maître de destination cloné.
8. Enregistrez la présentation de destination modifiée.

Dans l’exemple ci‑dessous, la diapositive à l’index 0 dans la présentation source est clonée à la fin de la présentation de destination en utilisant le maître cloné depuis la source.

```py
import aspose.slides as slides

# Instanciez la classe Presentation pour représenter le fichier de présentation source.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Instanciez la classe Presentation pour la présentation de destination où la diapositive sera clonée.
    with slides.Presentation() as target_presentation:
        # Obtenez la première diapositive de la présentation source.
        source_slide = source_presentation.slides[0]
        # Obtenez la diapositive maître utilisée par la première diapositive.
        source_master = source_slide.layout_slide.master_slide
        # Clonez la diapositive maître dans la collection de maîtres de la présentation de destination.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Clonez la diapositive de la présentation source à la fin de la présentation de destination en utilisant le maître cloné.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Enregistrez la présentation de destination sur le disque.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Cloner à la fin dans une section spécifiée**

Avec Aspose.Slides pour Python via .NET, vous pouvez cloner une diapositive d'une section d'une présentation et l'insérer dans une autre section de la même présentation. Pour ce faire, utilisez la méthode `add_clone(Slide, Section)` de la classe [SlideCollection].

L’exemple Python suivant montre comment cloner une diapositive et insérer le clone dans une section spécifiée :

```py
import aspose.slides as slides

    # Créez une nouvelle présentation vierge.
    with slides.Presentation() as presentation:
        # Ajoutez une diapositive vide en fonction de la mise en page de la première diapositive.
        slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
        # Ajoutez une forme d'ellipse à la nouvelle diapositive; cette diapositive sera clonée plus tard.
        slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
        # Ajoutez une autre diapositive vide en fonction de la mise en page de la première diapositive.
        slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
        # Créez une section nommée "Section2" qui commence à slide2.
        section = presentation.sections.add_section("Section2", slide2)
        # Clonez la diapositive créée précédemment dans la section "Section2".
        presentation.slides.add_clone(slide, section)
        # Enregistrez la présentation au format PPTX.
        presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Les notes du présentateur et les commentaires des réviseurs sont-ils clonés ?

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/python-net/presentation-notes/) après l’insertion.

### Comment les graphiques et leurs sources de données sont‑ils gérés ?

L'objet graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé en tant qu'[objet OLE](/slides/fr/python-net/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

### Puis‑je contrôler la position d’insertion et les sections du clone ?

Oui. Vous pouvez insérer le clone à un index de diapositive spécifique et le placer dans une [section](/slides/fr/python-net/slide-section/) choisie. Si la section cible n'existe pas, créez‑la d'abord puis déplacez la diapositive dedans.