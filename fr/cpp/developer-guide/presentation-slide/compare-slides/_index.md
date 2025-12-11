---
title: Comparer les diapositives de présentation en C++
linktitle: Comparer les diapositives
type: docs
weight: 50
url: /fr/cpp/compare-slides/
keywords:
- comparer les diapositives
- comparaison de diapositives
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Comparez les présentations PowerPoint et OpenDocument programmatiquement avec Aspose.Slides pour C++. Identifiez rapidement les différences de diapositives dans le code."
---

## **Comparer deux diapositives**
La méthode Equals a été ajoutée à l'interface IBaseSlide et à la classe BaseSlide. Elle renvoie true pour les diapositives / diapositives de mise en page / diapositives maîtres qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. La comparaison ne tient pas compte des valeurs d'identifiant uniques, par ex. SlideId, ni du contenu dynamique, par ex. la valeur de date actuelle dans le texte de remplacement de date.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**Le fait qu'une diapositive soit masquée affecte-t-il la comparaison des diapositives elles‑mêmes ?**

Le statut masqué([Hidden status](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/)) est une propriété au niveau de la présentation/lecture, pas du contenu visuel. L'égalité de deux diapositives spécifiques est déterminée par leur structure et leur contenu statique ; le simple fait qu'une diapositive soit masquée ne les rend pas différentes.

**Les hyperliens et leurs paramètres sont-ils pris en compte ?**

Oui. Les liens font partie du contenu statique d’une diapositive. Si l’URL ou l’action du lien hypertexte diffère, cela est généralement considéré comme une différence de contenu statique.

**Si un graphique fait référence à un fichier Excel externe, le contenu de ce fichier est‑il pris en compte ?**

Non. La comparaison s’effectue sur les diapositives elles‑mêmes. Les sources de données externes ne sont généralement pas lues lors de la comparaison ; seuls ce qui est présent dans la structure et l’état statique de la diapositive sont pris en compte.