---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /fr/cpp/add-slide-to-presentation/
---

## **Ajouter une diapositive à la présentation**
Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits sur les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive Maître / Mise en page et d'autres diapositives Normales. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides pour C++. Chaque diapositive a un identifiant unique et toutes les diapositives normales sont organisées dans un ordre spécifié par l'index basé sur zéro. Aspose.Slides pour C++ permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) classe.
- Instanciez [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) classe en définissant une référence à la propriété Slides (collection d'objets de diapositive de contenu) exposée par l'objet Presentation.
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes AddEmptySlide exposées par l'objet ISlideCollection.
- Effectuez quelques actions avec la nouvelle diapositive vide ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}