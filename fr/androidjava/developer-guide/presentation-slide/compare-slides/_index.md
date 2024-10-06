---
title: Comparer des Diapositives
type: docs
weight: 50
url: /androidjava/compare-slides/
---

## **Comparer Deux Diapositives**
La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) et à la classe [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide). Elle renvoie true pour les diapositives/layout et les diapositives/master qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiant unique, par exemple SlideId, et le contenu dynamique, par exemple la valeur de la date actuelle dans l'espace réservé de date.

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
                    System.out.println(String.format("CertainesPrésentation1 MasterSlide#%d est égale à CertainesPrésentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```