---
title: Cloner des diapositives
type: docs
weight: 40
url: /fr/python-net/clone-slides/
keywords: "Cloner une diapositive, Copier une diapositive, Enregistrer une copie de diapositive, PowerPoint, Présentation, Python, Aspose.Slides"
description: "Cloner une diapositive PowerPoint en Python"
---

## **Cloner des diapositives dans une présentation**
Le clonage est le processus permettant de créer une copie ou une réplique exacte de quelque chose. Aspose.Slides pour Python via .NET permet également de faire une copie ou un clone de n'importe quelle diapositive et ensuite d'insérer cette diapositive clonée dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage de diapositives crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Il existe plusieurs façons de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à un autre endroit dans la présentation.
- Cloner à la fin dans une autre présentation.
- Cloner à un autre endroit dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides pour Python via .NET, (une collection d'objets [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) exposée par l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) fournit les méthodes [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) et [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) pour effectuer les types de clonage de diapositives ci-dessus.

## **Cloner à la fin dans une présentation**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) selon les étapes listées ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) en faisant référence à la collection de diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Appelez la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) et passez la diapositive à cloner en tant que paramètre à la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
3. Écrivez le fichier de présentation modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (située à la première position – zéro index – de la présentation) à la fin de la présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # Écrire la présentation modifiée sur disque
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à un autre endroit dans la présentation**
Si vous souhaitez cloner une diapositive et l'utiliser dans le même fichier de présentation mais à un autre endroit, utilisez la méthode [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Instanciez la classe en faisant référence à la collection **Slides** exposée par l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Appelez la méthode [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) et passez la diapositive à cloner ainsi que l'index pour la nouvelle position en tant que paramètre à la méthode [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (située à l'index zéro – position 1 – de la présentation) à l'index 1 – Position 2 – de la présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # Cloner la diapositive souhaitée à la fin de la collection de diapositives dans la même présentation
    slds = pres.slides

    # Cloner la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.insert_clone(2, pres.slides[1])

    # Écrire la présentation modifiée sur disque
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à la fin dans une autre présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant la présentation dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) en faisant référence à la collection **Slides** exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) et passez la diapositive de la présentation source en tant que paramètre à la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (depuis le premier index de la présentation source) à la fin de la présentation de destination.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour charger le fichier de présentation source
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    with slides.Presentation() as destPres:
        # Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives dans la présentation de destination
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # Écrire la présentation de destination sur disque
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à un autre emplacement dans une autre présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant la présentation à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) en faisant référence à la collection de diapositives exposée par l'objet Presentation de la présentation de destination.
1. Appelez la méthode [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) et passez la diapositive de la présentation source avec la position désirée en tant que paramètre à la méthode [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (depuis l'index zéro de la présentation source) à l'index 1 (position 2) de la présentation de destination.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour charger le fichier de présentation source
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # Écrire la présentation de destination sur disque
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Cloner à une position spécifique dans une autre présentation**
Si vous devez cloner une diapositive avec un maître à partir d'une présentation et l'utiliser dans une autre présentation, vous devez d'abord cloner le maître souhaité de la présentation source à la présentation de destination. Ensuite, vous devez utiliser ce maître pour cloner la diapositive avec le maître. La méthode **add_clone(ISlide, IMasterSlide)** attend un maître de la présentation de destination plutôt que de la présentation source. Pour cloner la diapositive avec un maître, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant la présentation de destination dans laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu'au maître de la diapositive.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) en faisant référence à la collection de maîtres exposée par l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la présentation de destination.
1. Appelez la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) exposée par l'objet [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) et passez le maître du PPTX source à cloner en tant que paramètre à la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) en définissant la référence à la collection de diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) de la présentation de destination.
2. Appelez la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) et passez la diapositive de la présentation source à cloner et le maître comme paramètre à la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
3. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive avec un maître (située à l'index zéro de la présentation source) à la fin de la présentation de destination en utilisant un maître de la diapositive source.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour charger le fichier de présentation source
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    with slides.Presentation() as destPres:
        # Instancier ISlide à partir de la collection de diapositives dans la présentation source ainsi qu'
        # Master slide
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # Cloner le maître souhaité de la présentation source vers la collection de maîtres dans la
        # Présentation de destination
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # Cloner le maître souhaité de la présentation source vers la collection de maîtres dans la
        # Présentation de destination
        iSlide = masters.add_clone(sourceMaster)

        # Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        # Collection de diapositives dans la présentation de destination
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)

        # Cloner le maître souhaité de la présentation source vers la collection de maîtres dans la lecture
        # Présentation de destination et enregistrer la présentation de destination sur disque
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## Cloner à la fin dans une section spécifiée

Avec Aspose.Slides pour Python via .NET, vous pouvez cloner une diapositive d'une section d'une présentation et insérer cette diapositive dans une autre section de la même présentation. Dans ce cas, vous devez utiliser la méthode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) de l'interface [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).

Ce code Python vous montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # à cloner
    
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Section2", slide2)

    pres.slides.add_clone(slide, section)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```