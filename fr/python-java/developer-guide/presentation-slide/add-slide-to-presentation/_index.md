---
title: Ajouter des diapositives aux présentations en Python
linktitle: Ajouter une diapositive
type: docs
weight: 10
url: /fr/python-java/add-slide-to-presentation/
keywords:
- ajouter une diapositive
- créer une diapositive
- diapositive vide
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides for Python via Java—une insertion de diapositives fluide et efficace en quelques secondes."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d’ajouter des diapositives à des présentations PowerPoint de façon programmatique. Une présentation contient des diapositives maître/disposition et des diapositives normales, et les diapositives normales sont organisées par un indice zéro‑based. Chaque diapositive possède un identifiant unique, et les fichiers de présentation sans diapositives ne sont pas pris en charge.

Cet article explique comment créer un objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), accéder à sa collection de diapositives, ajouter une diapositive vide, travailler avec la diapositive nouvellement ajoutée et enregistrer la présentation mise à jour. Il couvre également des points associés tels que l’insertion de diapositives à une position spécifique, l’utilisation de dispositions et la compréhension de la diapositive vierge qui existe dans une présentation nouvellement créée.

## **Ajouter une diapositive à une présentation**

Avant d’aborder la façon d’ajouter des diapositives aux fichiers de présentation, passons en revue quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient des diapositives **maître/disposition** et des diapositives **normales**. Un fichier de présentation contient au moins une diapositive. Les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for Python via Java. Chaque diapositive possède un identifiant unique, et toutes les diapositives normales sont ordonnées selon un indice zéro‑based.

Aspose.Slides for Python via Java permet aux développeurs d’ajouter des diapositives vides à leurs présentations. Pour ajouter une diapositive vide à une présentation, suivez les étapes suivantes :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenez une référence à l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) en utilisant la méthode [getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Ajoutez une diapositive vide à la fin de la collection de diapositives de la présentation en appelant la méthode [addEmptySlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addEmptySlide) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/).
- Effectuez les opérations souhaitées avec la diapositive vide nouvellement ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l’objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instancier la classe Presentation qui représente le fichier de présentation.
presentation = Presentation()
try:
    # Obtenir la collection de diapositives.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Ajouter une diapositive vide à la collection de diapositives.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Effectuer des opérations sur la diapositive nouvellement ajoutée.

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je insérer une nouvelle diapositive à une position spécifique, et pas seulement à la fin ?**

Oui. La bibliothèque prend en charge les collections de diapositives ainsi que les opérations [insert](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertClone), ce qui permet d’ajouter une diapositive à l’indice requis plutôt qu’uniquement à la fin.

**Les thèmes/styles sont‑ils préservés lors de l’ajout d’une diapositive basée sur une disposition ?**

Oui. Une disposition hérite du formatage de son maître, et la nouvelle diapositive hérite de la disposition sélectionnée et de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d’ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l’indice zéro. Cela est important à prendre en compte lors du calcul des indices d’insertion.

**Comment choisir la « bonne » disposition pour une nouvelle diapositive si le maître propose de nombreuses options ?**

En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/) qui correspond à la structure requise ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidelayouttype/)). Si une telle disposition est manquante, vous pouvez [add it to the master](/slides/fr/python-java/slide-layout/) puis l’utiliser.