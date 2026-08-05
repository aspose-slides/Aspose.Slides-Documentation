---
title: "Personnaliser les barres d’erreur dans les graphiques de présentation avec C++"
linktitle: "Barre d’erreur"
type: docs
url: /fr/cpp/error-bar/
keywords:
- "barre d’erreur"
- "valeur personnalisée"
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à ajouter et personnaliser les barres d’erreur dans les graphiques avec Aspose.Slides pour C++ — optimisez les visualisations de données dans les présentations PowerPoint."
---
## **Aperçu**

Cet article explique comment travailler avec les barres d’erreur dans les graphiques de présentation en utilisant Aspose.Slides. Il montre comment ajouter des barres d’erreur à une série de graphique, configurer les paramètres des barres d’erreur X et Y, et appliquer différents types de valeurs tels que fixe, pourcentage et valeurs personnalisées.

Il montre également comment attribuer des valeurs de barres d’erreur personnalisées pour des points de données individuels dans une série en utilisant la collection de points de données correspondante. De plus, l’article comprend de brèves notes sur le comportement des barres d’erreur lors de l’exportation, leur compatibilité avec les repères et les étiquettes de données, ainsi que l’endroit où trouver les classes et énumérations de référence API liées.

## **Ajouter des barres d’erreur**
Aspose.Slides pour C++ fournit une API simple pour gérer les valeurs des barres d’erreur. Le code d’exemple s’applique lors de l’utilisation d’un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d’un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur Y.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Ajouter des barres d’erreur personnalisées**
Aspose.Slides pour C++ fournit une API simple pour gérer les valeurs de barres d’erreur personnalisées. Le code d’exemple s’applique lorsque la propriété **IErrorBarsFormat.ValueType** est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d’un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur Y.
1. Accédez aux points de données individuels de la série du graphique et définissez les valeurs de la barre d’erreur pour un point de données individuel de la série.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Que se passe-t-il avec les barres d’erreur lors de l’exportation d’une présentation au format PDF ou image ?**

Elles sont rendues comme faisant partie du graphique et préservées lors de la conversion avec le reste du formatage du graphique, à condition d’utiliser une version ou un moteur compatible.

**Les barres d’erreur peuvent‑elles être combinées avec les repères et les étiquettes de données ?**

Oui. Les barres d’erreur sont un élément séparé et sont compatibles avec les repères et les étiquettes de données ; si les éléments se chevauchent, il peut être nécessaire d’ajuster le formatage.

**Où puis‑je trouver la liste des propriétés et des énumérations pour travailler avec les barres d’erreur dans l’API ?**

Dans la référence de l’API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/errorbarsformat/) et les énumérations associées [ErrorBarType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/errorbarvaluetype/).