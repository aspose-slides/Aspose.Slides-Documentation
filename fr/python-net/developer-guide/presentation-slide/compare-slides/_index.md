---
title: Comparer les diapositives de présentation en Python
linktitle: Comparer les diapositives
type: docs
weight: 50
url: /fr/python-net/compare-slides/
keywords:
- comparer les diapositives
- comparaison de diapositives
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Comparez programmétiquement les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Identifiez rapidement les différences de diapositives dans le code."
---

## **Comparer deux diapositives**
La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) et à la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). Elle renvoie true pour les diapositives/dispositions et les diapositives maîtresses qui sont identiques par leur structure et contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. La comparaison ne prend pas en compte les valeurs d'identifiants uniques, par ex. SlideId, ni le contenu dynamique, par ex. la valeur de la date actuelle dans le texte de remplacement de date.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Le fait qu'une diapositive soit masquée affecte-t-il la comparaison des diapositives elles‑mêmes ?**

Le statut masqué ([Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/)) est une propriété au niveau de la présentation/la lecture, pas un contenu visuel. L'égalité de deux diapositives spécifiques est déterminée par leur structure et leur contenu statique ; le simple fait qu'une diapositive soit masquée ne rend pas les diapositives différentes.

**Les hyperliens et leurs paramètres sont-ils pris en compte ?**

Oui. Les liens font partie du contenu statique d'une diapositive. Si l'URL ou l'action du lien hypertexte diffère, cela est généralement considéré comme une différence de contenu statique.

**Si un graphique se réfère à un fichier Excel externe, le contenu de ce fichier sera-t-il pris en compte ?**

Non. La comparaison s'effectue sur la base des diapositives elles‑mêmes. Les sources de données externes ne sont généralement pas lues lors de la comparaison ; seul le contenu présent dans la structure et l'état statique de la diapositive est pris en compte.