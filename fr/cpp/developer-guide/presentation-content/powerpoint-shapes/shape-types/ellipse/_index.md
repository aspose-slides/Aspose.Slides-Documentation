---
title: Ellipse
type: docs
weight: 30
url: /cpp/ellipse/
---


## **Créer une Ellipse**
Dans ce sujet, nous allons présenter aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides pour C++. Aspose.Slides pour C++ fournit un ensemble d'APIs plus simples pour dessiner différents types de formes avec seulement quelques lignes de code. Pour ajouter une simple ellipse à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la [classe Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)
1. Obtenez la référence d'une diapositive en utilisant son index
1. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes
1. Écrivez la présentation modifiée en tant que fichier PPTX

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse à la première diapositive.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}


## **Créer une Ellipse Formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la [classe Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Définissez le type de remplissage de l'ellipse sur Solide.
1. Définissez la couleur de l'ellipse en utilisant la propriété SolidFillColor.Color telle qu'exposée par l'objet FillFormat associé à l'objet IShape.
1. Définissez la couleur des lignes de l'ellipse.
1. Définissez la largeur des lignes de l'ellipse.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}