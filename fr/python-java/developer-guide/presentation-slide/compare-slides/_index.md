---
title: Comparer les diapositives de présentation en Python
linktitle: Comparer les diapositives
type: docs
weight: 50
url: /fr/python-java/compare-slides/
keywords:
- comparer les diapositives
- comparaison de diapositives
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Comparez les présentations PowerPoint et OpenDocument programmatiquement avec Aspose.Slides pour Python via Java. Identifiez rapidement les différences de diapositives dans le code."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de comparer des diapositives, des diapositives de mise en page et des diapositives maîtres à l'aide de la méthode [equals](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#equals) fournie par la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/). Cette méthode retourne `True` lorsque les diapositives comparées sont identiques dans leur structure et leur contenu statique.

## **Comparer deux diapositives**

La méthode [equals](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#equals) dans la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/) retourne `True` pour les diapositives, les diapositives de mise en page et les diapositives maîtres qui sont identiques dans leur structure et leur contenu statique.

Deux diapositives sont égales si toutes leurs formes, styles, texte, animations et autres paramètres sont identiques. La comparaison ne prend pas en compte les valeurs d'identifiants uniques, comme les ID de diapositives, ou le contenu dynamique, comme la date actuelle dans un espace réservé de date.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Le fait qu'une diapositive soit masquée affecte-t-il la comparaison des diapositives elles‑mêmes ?**

Le [statut masqué](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getHidden) est une propriété au niveau de la présentation/la lecture, et non un contenu visuel. L'égalité de deux diapositives spécifiques est déterminée par leur structure et leur contenu statique ; le simple fait qu'une diapositive soit masquée ne rend pas les diapositives différentes.

**Les hyperliens et leurs paramètres sont-ils pris en compte ?**

Oui. Les liens font partie du contenu statique d’une diapositive. Si l’URL ou l’action du lien hypertexte diffère, cela est généralement considéré comme une différence dans le contenu statique.

**Si un graphique fait référence à un fichier Excel externe, le contenu de ce fichier sera-t-il pris en compte ?**

Non. La comparaison s’effectue à partir des diapositives elles‑elles. Les sources de données externes ne sont généralement pas lues au moment de la comparaison ; seul ce qui est présent dans la structure et l’état statique de la diapositive est pris en compte.