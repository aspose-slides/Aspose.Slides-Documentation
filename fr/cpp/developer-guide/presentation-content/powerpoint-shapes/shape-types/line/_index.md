---
title: Ligne
type: docs
weight: 50
url: /cpp/Ligne/
---

## **Créer une Ligne Simple**
Pour ajouter une simple ligne à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la [classe Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index) exposée par l'objet Shapes.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Créer une Ligne en Forme de Flèche**
Aspose.Slides pour C++ permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d'une ligne pour qu'elle ressemble à une flèche. Veuillez suivre les étapes ci-dessous pour ce faire :

- Créez une instance de la [classe Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes.
- Définissez le style de ligne sur l'un des styles offerts par Aspose.Slides pour C++.
- Définissez la largeur de la ligne.
- Définissez le [style de trait](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) de la ligne sur l'un des styles offerts par Aspose.Slides pour C++.
- Définissez le [style de tête de flèche](http://www.aspose.com/api/net/slides/aspose.slides/lineformat) et la longueur du point de départ de la ligne.
- Définissez le style de tête de flèche et la longueur du point final de la ligne.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}