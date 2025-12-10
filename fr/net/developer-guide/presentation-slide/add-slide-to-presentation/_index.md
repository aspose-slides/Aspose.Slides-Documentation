---
title: Ajouter des diapositives aux présentations en .NET
linktitle: Ajouter une diapositive
type: docs
weight: 10
url: /fr/net/add-slide-to-presentation/
keywords:
- ajouter une diapositive
- créer une diapositive
- diapositive vide
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument avec Aspose.Slides pour .NET - insertion de diapositives fluide et efficace en quelques secondes."
---

## **Ajouter une diapositive à une présentation**
Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive Maître / Mise en page et d'autres diapositives Normales. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for .NET. Chaque diapositive possède un Id unique et toutes les diapositives Normales sont organisées dans un ordre spécifié par un indice basé sur zéro. Aspose.Slides for .NET permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, suivez les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en définissant une référence à la propriété Slides (collection d'objets Slide de contenu) exposée par l'objet Presentation.
- Ajouter une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes AddEmptySlide exposées par l'objet ISlideCollection.
- Effectuer des opérations avec la nouvelle diapositive vide ajoutée.
- Enfin, enregistrer le fichier de présentation à l'aide de l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, et pas seulement à la fin ?**  
Oui. La bibliothèque prend en charge les collections de diapositives ainsi que les opérations [insérer](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[cloner](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/), vous pouvez donc ajouter une diapositive à l'index requis plutôt que uniquement à la fin.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une mise en page ?**  
Oui. Une mise en page hérite du formatage de son maître, et la nouvelle diapositive hérite de la mise en page sélectionnée et de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d'ajouter des diapositives ?**  
Une présentation nouvellement créée contient déjà une diapositive vierge avec l'indice zéro. Cela est important à considérer lors du calcul des indices d'insertion.

**Comment choisir la mise en page « correcte » pour une nouvelle diapositive si le maître propose de nombreuses options ?**  
En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) qui correspond à la structure requise ([Titre et Contenu, Deux contenus, etc.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). Si une telle mise en page manque, vous pouvez la [ajouter au maître](/slides/fr/net/slide-layout/) puis l'utiliser.