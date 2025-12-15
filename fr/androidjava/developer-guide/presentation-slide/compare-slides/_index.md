---
title: Comparer les diapositives de présentation sur Android
linktitle: Comparer les diapositives
type: docs
weight: 50
url: /fr/androidjava/compare-slides/
keywords:
- comparer diapositives
- comparaison de diapositives
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Comparez les présentations PowerPoint et OpenDocument de manière programmatique avec Aspose.Slides pour Android. Identifiez rapidement les différences de diapositives dans le code Java."
---

## **Comparer deux diapositives**

La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) et à la classe [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide). Elle renvoie true pour les diapositives/mise en page et les diapositives ma\^tres qui sont identiques par leur structure et leur contenu statique.  

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiants uniques, par exemple SlideId, ni le contenu dynamique, par exemple la valeur de la date actuelle dans le texte de substitution Date.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **FAQ**

**Le fait qu'une diapositive soit masquée affecte-t-il la comparaison des diapositives elles-mêmes?**

Le [statut masqué](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) est une propriété au niveau de la présentation/la lecture, et non du contenu visuel. L'égalité de deux diapositives spécifiques est déterminée par leur structure et leur contenu statique; le simple fait qu'une diapositive soit masquée ne rend pas les diapositives différentes.

**Les hyperliens et leurs paramètres sont-ils pris en compte?**

Oui. Les liens font partie du contenu statique d'une diapositive. Si l'URL ou l'action du lien hypertexte diffèrent, cela est généralement considéré comme une différence de contenu statique.

**Si un graphique fait référence à un fichier Excel externe, le contenu de ce fichier sera-t-il pris en compte?**

Non. La comparaison s'effectue à partir des diapositives elles-mêmes. Les sources de données externes ne sont généralement pas lues lors de la comparaison; seul ce qui est présent dans la structure et l'état statique de la diapositive est pris en compte.