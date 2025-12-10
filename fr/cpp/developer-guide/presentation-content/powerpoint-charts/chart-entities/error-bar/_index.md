---
title: "Personnaliser les barres d'erreur dans les graphiques de présentation en utilisant С++"
linktitle: "Barre d'erreur"
type: docs
url: /fr/cpp/error-bar/
keywords:
- "barre d'erreur"
- "valeur personnalisée"
- PowerPoint
- présentation
- С++
- Aspose.Slides
description: "Apprenez comment ajouter et personnaliser les barres d'erreur dans les graphiques avec Aspose.Slides pour С++ - optimisez les visuels de données dans les présentations PowerPoint."
---

## **Ajouter des barres d'erreur**
Aspose.Slides for C++ fournit une API simple pour gérer les valeurs des barres d'erreur. Le code d'exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Ajouter des barres d'erreur personnalisées**
Aspose.Slides for C++ fournit une API simple pour gérer les valeurs personnalisées des barres d'erreur. Le code d'exemple s'applique lorsque la propriété **IErrorBarsFormat.ValueType** est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série du graphique et définissez les valeurs de la barre d'erreur pour un point de données individuel de la série.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Que se passe-t-il avec les barres d'erreur lors de l'exportation d'une présentation au format PDF ou images ?**

Elles sont rendues comme partie du graphique et conservées lors de la conversion avec le reste du formatage du graphique, à condition d'une version ou d'un moteur compatible.

**Les barres d'erreur peuvent-elles être combinées avec des marqueurs et des étiquettes de données ?**

Oui. Les barres d'erreur sont un élément distinct et sont compatibles avec les marqueurs et les étiquettes de données ; si les éléments se chevauchent, il peut être nécessaire d'ajuster le formatage.

**Où puis-je trouver la liste des propriétés et des énumérations pour travailler avec les barres d'erreur dans l'API ?**

Dans la référence API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarsformat/) et les énumérations associées [ErrorBarType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarvaluetype/).