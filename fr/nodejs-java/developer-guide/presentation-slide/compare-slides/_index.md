---
title: Comparer les diapositives
type: docs
weight: 50
url: /fr/nodejs-java/compare-slides/
---

## **Comparer deux diapositives**
La méthode Equals a été ajoutée à la classe [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) et à la classe [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). Elle renvoie true pour les diapositives/maquettes et les diapositives maîtres qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc., sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiant uniques, par exemple SlideId, ni le contenu dynamique, par exemple la valeur de la date actuelle dans le champ Date Placeholder.
```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

**Le fait qu'une diapositive soit masquée affecte-t-il la comparaison des diapositives elles‑elles?**

[Statut masqué](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) est une propriété au niveau de la présentation/la lecture, et non du contenu visuel. L'égalité de deux diapositives spécifiques est déterminée par leur structure et leur contenu statique ; le simple fait qu'une diapositive soit masquée ne rend pas les diapositives différentes.

**Les hyperliens et leurs paramètres sont‑ils pris en compte ?**

Oui. Les liens font partie du contenu statique d’une diapositive. Si l’URL ou l’action du lien hypertexte diffèrent, cela est généralement considéré comme une différence de contenu statique.

**Si un graphique fait référence à un fichier Excel externe, le contenu de ce fichier sera‑t‑il pris en compte ?**

Non. La comparaison s’effectue sur les diapositives elles‑elles. Les sources de données externes ne sont généralement pas lues lors de la comparaison ; seul le contenu présent dans la structure et l’état statique de la diapositive est pris en compte.