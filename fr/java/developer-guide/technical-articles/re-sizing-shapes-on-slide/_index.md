---
title: Redimensionner des formes sur la diapositive
type: docs
weight: 110
url: /java/re-sizing-shapes-on-slide/
---

## **Redimensionner des formes sur la diapositive**
L'une des questions les plus fréquentes posées par les clients d'Aspose.Slides pour Java est comment redimensionner des formes afin que lorsque la taille de la diapositive est modifiée, les données ne soient pas coupées. Ce conseil technique court montre comment y parvenir.

Pour éviter la désorientation des formes, chaque forme sur la diapositive doit être mise à jour en fonction de la nouvelle taille de la diapositive.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

S'il y a un tableau dans la diapositive, le code ci-dessus ne fonctionnerait pas parfaitement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.

{{% /alert %}} 

Vous devez utiliser le code suivant de votre côté si vous avez besoin de redimensionner les diapositives avec des tableaux. Définir la largeur ou la hauteur du tableau est un cas particulier dans les formes où vous devez modifier la hauteur des lignes individuelles et la largeur des colonnes pour modifier la hauteur et la largeur du tableau.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}