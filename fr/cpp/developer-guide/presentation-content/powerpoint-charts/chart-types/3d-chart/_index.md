---
title: Personnaliser les graphiques 3D dans les présentations avec С++
linktitle: Graphique 3D
type: docs
url: /fr/cpp/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- С++
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques 3-D dans Aspose.Slides pour С++, avec prise en charge des fichiers PPT et PPTX — améliorez vos présentations dès aujourd’hui."
---

## **Définir les propriétés RotationX, RotationY et DepthPercents d'un graphique 3D**
Aspose.Slides for C++ propose une API simple pour définir ces propriétés. L'article suivant vous aidera à définir différentes propriétés comme la rotation X, Y, **DepthPercents**, etc. Le code d'exemple applique la définition des propriétés mentionnées ci‑above.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Écrivez la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via l’énumération [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique en image via l’[API du graphique](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ou [renderiser la diapositive entière](/slides/fr/cpp/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu pixel‑perfect ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

La performance dépend du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque possible, et renderisez vers une sortie de taille appropriée (résolution et dimensions) correspondant aux besoins d’affichage ou d’impression ciblés.