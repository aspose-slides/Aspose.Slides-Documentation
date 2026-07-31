---
title: Personnaliser les graphiques 3D dans les présentations avec C++
linktitle: Graphique 3D
type: docs
url: /fr/cpp/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques 3D dans Aspose.Slides pour C++, avec prise en charge des fichiers PPT et PPTX — améliorez vos présentations dès aujourd'hui."
---
## **Aperçu**

Cet article explique comment personnaliser un graphique 3D dans Aspose.Slides en configurant les paramètres `Rotation3D` tels que `RotationX`, `RotationY`, `DepthPercents` et `RightAngleAxes`. Il décrit la création d'une présentation, l'ajout d'un graphique 3D avec des données par défaut, l'application des paramètres de vue 3D requis et l'enregistrement de la présentation modifiée au format PPTX.

## **Définir les propriétés RotationX, RotationY et DepthPercents d'un graphique 3D**

Aspose.Slides for C++ fournit une API simple pour définir ces propriétés. L'article suivant vous montrera comment définir différentes propriétés comme la rotation X,Y, **DepthPercents** etc. Le code d'exemple applique le réglage des propriétés mentionnées ci-dessus.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques en colonnes, y compris Column 3D, Clustered Column 3D, Stacked Column 3D et 100% Stacked Column 3D, ainsi que les types 3D associés exposés via l'énumération [ChartType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/charttype/). Pour une liste exacte et à jour, consultez les membres [ChartType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique vers une image via l'[API du graphique](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/getimage/) ou [rendre la diapositive entière](/slides/fr/cpp/convert-powerpoint-to-png/) dans des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d'un aperçu pixel-perfect ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

La performance dépend du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série dans la mesure du possible, et effectuez le rendu vers une sortie de taille appropriée (résolution et dimensions) afin de correspondre aux besoins d'affichage ou d'impression cibles.