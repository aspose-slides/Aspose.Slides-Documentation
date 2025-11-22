---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /fr/net/add-slide-to-presentation/
keywords: "Ajouter une diapositive à la présentation, C#, Csharp, .NET, Aspose.Slides"
description: "Ajouter une diapositive à la présentation en C# ou .NET"
---

## **Ajouter une diapositive à la présentation**
Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive Master / Layout et d'autres diapositives normales. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for .NET. Chaque diapositive possède un Id unique et toutes les diapositives normales sont organisées dans un ordre spécifié par l'index basé sur zéro. Aspose.Slides for .NET permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Instancier la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en définissant une référence à la propriété Slides (collection d'objets Slide de contenu) exposée par l'objet Presentation.
- Ajouter une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes AddEmptySlide exposées par l'objet ISlideCollection.
- Effectuer des opérations avec la diapositive vide récemment ajoutée.
- Enfin, enregistrer le fichier de présentation à l'aide de l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, pas seulement à la fin ?**  
Oui. La bibliothèque prend en charge les collections de diapositives et les opérations [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/) vous permettant d'ajouter une diapositive à l'index requis plutôt qu'uniquement à la fin.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une disposition ?**  
Oui. Une disposition hérite du formatage de son maître, et la nouvelle diapositive hérite de la disposition sélectionnée et de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d'ajouter des diapositives ?**  
Une présentation nouvellement créée contient déjà une diapositive vierge avec l'index zéro. Cela est important à prendre en compte lors du calcul des indices d'insertion.

**Comment choisir la disposition « appropriée » pour une nouvelle diapositive si le maître propose de nombreuses options ?**  
En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) qui correspond à la structure requise ([Titre et contenu, Deux contenus, etc.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). Si une telle disposition est absente, vous pouvez [l'ajouter au maître](/slides/fr/net/slide-layout/) puis l'utiliser.