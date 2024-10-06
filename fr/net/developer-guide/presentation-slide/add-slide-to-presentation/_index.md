---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /net/add-slide-to-presentation/
keywords: "Ajouter une diapositive à la présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Ajouter une diapositive à la présentation en C# ou .NET"
---

## **Ajouter une diapositive à la présentation**
Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient des diapositives Maître / Disposition et d'autres diapositives Normales. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides pour .NET. Chaque diapositive a un identifiant unique et toutes les diapositives Normales sont organisées dans un ordre spécifié par l'index basé sur zéro. Aspose.Slides pour .NET permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en définissant une référence à la propriété Slides (collection d'objets Slide de contenu) exposée par l'objet Presentation.
- Ajouter une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes AddEmptySlide exposées par l'objet ISlideCollection.
- Faire des opérations avec la nouvelle diapositive vide ajoutée.
- Enfin, écrire le fichier de présentation à l'aide de l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}