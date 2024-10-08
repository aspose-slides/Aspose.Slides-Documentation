---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /fr/python-net/add-slide-to-presentation/
keywords: "Ajouter diapositive à la présentation, Python, Aspose.Slides"
description: "Ajouter une diapositive à la présentation en Python"
---

## **Ajouter une diapositive à la présentation**
Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive principale / mise en page et d'autres diapositives normales. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides pour Python via .NET. Chaque diapositive a un identifiant unique et toutes les diapositives normales sont arrangées dans un ordre spécifié par l'index basé sur zéro. Aspose.Slides pour Python via .NET permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) en définissant une référence à la propriété Slides (collection d'objets de contenu Slide) exposée par l'objet Presentation.
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant la méthode AddEmptySlide exposée par l'objet ISlideCollection.
- Faites un travail avec la nouvelle diapositive vide ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le fichier de présentation
with slides.Presentation() as pres:
    # Instancier la classe SlideCollection
    slds = pres.slides

    for i in range(len(pres.layout_slides)):
        # Ajouter une diapositive vide à la collection Slides
        slds.add_empty_slide(pres.layout_slides[i])
        
    # Faire un travail sur la diapositive nouvellement ajoutée

    # Enregistrer le fichier PPTX sur le disque
    pres.save("EmptySlide.pptx", slides.export.SaveFormat.PPTX)
```