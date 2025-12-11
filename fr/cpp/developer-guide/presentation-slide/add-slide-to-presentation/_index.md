---
title: Ajouter des diapositives aux présentations en C++
linktitle: Ajouter une diapositive
type: docs
weight: 10
url: /fr/cpp/add-slide-to-presentation/
keywords:
- ajouter une diapositive
- créer une diapositive
- diapositive vide
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++ — insertion de diapositives fluide et efficace en quelques secondes."
---

## **Ajouter une diapositive à une présentation**
Avant de parler de l’ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive Master / Layout et d’autres diapositives Normal. Cela signifie qu’un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for C++. Chaque diapositive possède un Id unique et toutes les diapositives Normal sont organisées dans un ordre spécifié par l’indice basé sur zéro. Aspose.Slides for C++ permet aux développeurs d’ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) en définissant une référence à la propriété Slides (collection d’objets Slide de contenu) exposée par l’objet Presentation.
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes AddEmptySlide exposées par l’objet ISlideCollection.
- Effectuez des opérations avec la diapositive vide nouvellement ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l’objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, et pas seulement à la fin ?**

Oui. La bibliothèque prend en charge les collections de diapositives et les opérations [insert](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertclone/) , vous pouvez ainsi ajouter une diapositive à l’indice requis plutôt que seulement à la fin.

**Les thèmes/styles sont-ils conservés lors de l’ajout d’une diapositive basée sur un layout ?**

Oui. Un layout hérite du formatage de son maître, et la nouvelle diapositive hérite du layout sélectionné et de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d’ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l’indice zéro. Cela est important à prendre en compte lors du calcul des indices d’insertion.

**Comment choisir le « bon » layout pour une nouvelle diapositive si le maître propose de nombreuses options ?**

Choisissez généralement le [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) qui correspond à la structure requise ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cpp/aspose.slides/slidelayouttype/)). Si un tel layout manque, vous pouvez [add it to the master](/slides/fr/cpp/slide-layout/) puis l’utiliser.