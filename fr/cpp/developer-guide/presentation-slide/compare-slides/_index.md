---
title: Comparer les Diapositives
type: docs
weight: 50
url: /fr/cpp/compare-slides/
---

## **Comparer Deux Diapositives**
La méthode Equals a été ajoutée à l'interface IBaseSlide et à la classe BaseSlide. Elle retourne vrai pour les diapositives / diapositives de mise en page / diapositives maîtres qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. La comparaison ne prend pas en compte les valeurs d'identificateur uniques, par exemple SlideId et le contenu dynamique, par exemple la valeur de la date actuelle dans le Placeholder de Date.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}