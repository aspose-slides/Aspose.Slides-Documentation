---
title: Comparer les diapositives de présentation en Java
linktitle: Comparer les diapositives
type: docs
weight: 50
url: /fr/java/compare-slides/
keywords:
- comparer les diapositives
- comparaison de diapositives
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Comparez les présentations PowerPoint et OpenDocument programmatiquement avec Aspose.Slides pour Java. Identifiez rapidement les différences de diapositives dans le code."
---

## **Comparer deux diapositives**
La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) et à la classe [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide). Elle renvoie true pour les diapositives/modèle et les diapositives maître qui sont identiques par leur structure et leur contenu statique.  

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc., sont identiques. La comparaison ne prend pas en compte les valeurs d'identifiants uniques, par exemple SlideId, ni le contenu dynamique, par exemple la valeur de date actuelle dans le texte de substitution Date.  
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

**Le fait qu'une diapositive soit masquée affecte-t-il la comparaison des diapositives elles‑mêmes ?**

[Hidden status](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getHidden--) est une propriété au niveau de la présentation/lecture, pas de contenu visuel. L'egalite de deux diapositives spécifiques est determinee par leur structure et leur contenu statique ; le simple fait qu'une diapositive soit masquee ne les rend pas differentes.

**Les hyperliens et leurs paramètres sont-ils pris en compte ?**

Oui. Les liens font partie du contenu statique d'une diapositive. Si l'URL ou l'action du lien hypertexte diffère, cela est généralement considéré comme une différence dans le contenu statique.

**Si un graphique fait référence à un fichier Excel externe, le contenu de ce fichier sera-t-il pris en compte ?**

Non. La comparaison se fait en se basant sur les diapositives elles‑mêmes. Les sources de données externes ne sont généralement pas lues lors de la comparaison ; seules les informations presentes dans la structure et l'etat statique de la diapositive sont prises en compte.