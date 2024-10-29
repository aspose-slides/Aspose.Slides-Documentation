---
title: Redimensionnement des formes sur une diapositive
type: docs
weight: 110
url: /fr/php-java/redimensionnement-des-formes-sur-une-diapositive/
---

## **Redimensionnement des formes sur une diapositive**
Une des questions les plus fréquentes posées par les clients d'Aspose.Slides pour PHP via Java est comment redimensionner les formes afin que lorsque la taille de la diapositive change, les données ne soient pas coupées. Ce bref conseil technique montre comment y parvenir.

Pour éviter la désorientation des formes, chaque forme sur la diapositive doit être mise à jour en fonction de la nouvelle taille de la diapositive.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

S'il y a une table dans la diapositive, le code ci-dessus ne fonctionnera pas parfaitement. Dans ce cas, chaque cellule de la table doit être redimensionnée.

{{% /alert %}} 

Vous devez utiliser le code suivant de votre côté si vous devez redimensionner les diapositives avec des tables. Définir la largeur ou la hauteur de la table est un cas particulier dans les formes où vous devez modifier la hauteur des lignes individuelles et la largeur des colonnes pour modifier la hauteur et la largeur de la table.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}