---
title: Comparer les Diapositives
type: docs
weight: 50
url: /fr/python-net/compare-slides/
keywords: "Comparer les diapositives PowerPoint, Comparer deux diapositives, Présentation, Python, Aspose.Slides"
description: "Comparer les diapositives de présentation PowerPoint en Python"
---

## **Comparer Deux Diapositives**
La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) et à la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). Elle retourne vrai pour les diapositives/layout et les diapositives/master qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. sont identiques. La comparaison ne prend pas en compte les valeurs d'identificateur uniques, par exemple, SlideId et le contenu dynamique, par exemple, la valeur de la date actuelle dans l'espace réservé à la date.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("La MasterSlide#{0} de la Présentation1 est égale à la MasterSlide#{1} de la Présentation2".format(i,j))
```