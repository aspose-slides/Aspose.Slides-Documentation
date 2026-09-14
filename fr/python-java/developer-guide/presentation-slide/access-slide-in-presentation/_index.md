---
title: Accéder aux diapositives de présentation en Python
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/python-java/access-slide-in-presentation/
keywords:
- accéder à la diapositive
- indice de diapositive
- ID de diapositive
- position de la diapositive
- modifier la position
- propriétés de la diapositive
- numéro de diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment accéder aux diapositives et les gérer dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java. Augmentez votre productivité grâce à des exemples de code."
---
## **Vue d'ensemble**

Cet article explique comment accéder aux diapositives et les gérer dans une présentation à l'aide d'Aspose.Slides. Il montre comment récupérer les diapositives par leur indice basé sur zéro à partir de la collection de diapositives et comment accéder à une diapositive par son ID unique en utilisant la méthode [getSlideById](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlideById).

Vous apprendrez également comment modifier la position d'une diapositive en utilisant la méthode [setSlideNumber](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#setSlideNumber) et comment définir le numéro de diapositive de départ pour une présentation avec la méthode [setFirstSlideNumber](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#setFirstSlideNumber). Les exemples montrent le chargement d'une présentation, l'obtention de références de diapositives, la mise à jour de l'ordre ou de la numérotation des diapositives, et l'enregistrement de la présentation modifiée.

## **Accéder à une diapositive par indice**

Toutes les diapositives d'une présentation sont disposées numériquement en fonction de la position de la diapositive en commençant à partir de 0. La première diapositive est accessible via l'indice 0 ; la deuxième diapositive est accessible via l'indice 1 ; etc.

La classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) , représentant un fichier de présentation, expose toutes les diapositives sous forme d'une collection [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) (collection d'objets [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/)). Ce code Python vous montre comment accéder à une diapositive via son indice :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Instancier un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("demo.pptx")
try:
    # Accéder à une diapositive en utilisant son indice.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Accéder à une diapositive par ID**

Chaque diapositive d'une présentation possède un ID unique qui lui est associé. Vous pouvez utiliser la méthode [getSlideById](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlideById) (exposée par la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/)) pour cibler cet ID. Ce code Python vous montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [getSlideById](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlideById) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Instancier un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("demo.pptx")
try:
    # Obtenir un ID de diapositive.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # Accéder à la diapositive via son ID.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Modifier la position de la diapositive**

Aspose.Slides vous permet de modifier la position d'une diapositive. Par exemple, vous pouvez spécifier que la première diapositive devienne la deuxième.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir la référence de la diapositive (dont vous voulez changer la position) via son indice.
1. Définir une nouvelle position pour la diapositive via la méthode [setSlideNumber](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#setSlideNumber).
1. Enregistrer la présentation modifiée.

Ce code Python démontre une opération où la diapositive en position 1 est déplacée en position 2 :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("Presentation.pptx")
try:
    # Obtenir la diapositive dont la position sera modifiée.
    slide = presentation.getSlides().get_Item(0)

    # Définir la nouvelle position de la diapositive.
    slide.setSlideNumber(2)

    # Enregistrer la présentation modifiée.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous modifiez la position d'une diapositive, les autres diapositives sont automatiquement ajustées.

## **Définir le numéro de la diapositive**

En utilisant la méthode [setFirstSlideNumber](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#setFirstSlideNumber) (exposée par la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d'une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenir le numéro de la diapositive.
1. Définir le numéro de la diapositive.
1. Enregistrer la présentation modifiée.

Ce code Python démontre une opération où le numéro de la première diapositive est fixé à 10 :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier un objet Presentation qui représente un fichier de présentation.
presentation = Presentation("HelloWorld.pptx")
try:
    # Obtenir le numéro de la première diapositive.
    first_slide_number = presentation.getFirstSlideNumber()

    # Définir le numéro de la diapositive.
    presentation.setFirstSlideNumber(10)

    # Enregistrer la présentation modifiée.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si vous préférez sauter la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première) de cette manière :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # Définir le numéro de la première diapositive de la présentation.
    # Afficher les numéros de diapositive pour toutes les diapositives.
    # Masquer le numéro de diapositive pour la première diapositive.
    # Enregistrer la présentation modifiée.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Le numéro de diapositive vu par l'utilisateur correspond-il à l'indice basé sur zéro de la collection ?**

Le nombre affiché sur une diapositive peut commencer à partir d'une valeur arbitraire (par ex., 10) et n'a pas besoin de correspondre à l'indice ; la relation est contrôlée par le paramètre [premier numéro de diapositive](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#setFirstSlideNumber) de la présentation.

**Les diapositives masquées affectent-elles l'indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l'indexation ; « masquée » fait référence à l'affichage, pas à sa position dans la collection.

**L'indice d'une diapositive change-t-il lorsque d'autres diapositives sont ajoutées ou supprimées ?**

Oui. Les indices reflètent toujours l'ordre actuel des diapositives et sont recalculés lors des opérations d'insertion, de suppression et de déplacement.