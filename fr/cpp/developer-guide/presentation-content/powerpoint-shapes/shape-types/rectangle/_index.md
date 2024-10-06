---
title: Rectangle
type: docs
weight: 80
url: /cpp/rectangle/
---


## **Créer un Rectangle Simple**
Comme les sujets précédents, celui-ci concerne également l'ajout d'une forme et cette fois la forme que nous allons discuter est le Rectangle. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour C++. Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Créer un Rectangle Formaté**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Définissez le Type de Remplissage du Rectangle sur Solide.
1. Définissez la Couleur du Rectangle en utilisant la propriété SolidFillColor.Color telle qu'exposée par l'objet FillFormat associé à l'objet IShape.
1. Définissez la Couleur des lignes du Rectangle.
1. Définissez la Largeur des lignes du Rectangle.
1. Écrivez la présentation modifiée en tant que fichier PPTX.
   Les étapes ci-dessus sont mises en œuvre dans l'exemple donné ci-dessous.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}