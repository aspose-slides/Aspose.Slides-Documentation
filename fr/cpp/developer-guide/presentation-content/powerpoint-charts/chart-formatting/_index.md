---
title: Formatage des graphiques de présentation en C++
linktitle: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/cpp/chart-formatting/
keywords:
- format de graphique
- mise en forme de graphique
- entité de graphique
- propriétés de graphique
- paramètres de graphique
- options de graphique
- propriétés de police
- bordure arrondie
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à mettre en forme les graphiques dans Aspose.Slides pour C++ et améliorez votre présentation PowerPoint avec un style professionnel et accrocheur."
---

## **Format des entités de graphique**
Aspose.Slides for C++ permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives depuis le départ. Cet article explique comment formater différentes entités de graphique, y compris les axes de catégorie et de valeur.

Aspose.Slides for C++ fournit une API simple pour gérer différentes entités de graphique et les formater à l’aide de valeurs personnalisées :

1. Créer une instance de la classe **Presentation**.
1. Obtenir la référence d’une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l’axe de valeur du graphique et définir les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de la grille principale de l’axe de valeur
   1. Définir le **Line format** pour les lignes de la grille secondaire de l’axe de valeur
   1. Définir le **Number Format** pour l’axe de valeur
   1. Définir les **Min, Max, Major and Minor units** pour l’axe de valeur
   1. Définir les **Text Properties** pour les données de l’axe de valeur
   1. Définir le **Title** pour l’axe de valeur
   1. Définir le **Line Format** pour l’axe de valeur
1. Accéder à l’axe de catégorie du graphique et définir les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de la grille principale de l’axe de catégorie
   1. Définir le **Line format** pour les lignes de la grille secondaire de l’axe de catégorie
   1. Définir les **Text Properties** pour les données de l’axe de catégorie
   1. Définir le **Title** pour l’axe de catégorie
   1. Définir le **Label Positioning** pour l’axe de catégorie
   1. Définir l’**Rotation Angle** pour les étiquettes de l’axe de catégorie
1. Accéder à la légende du graphique et définir les **Text Properties** pour celle‑ci
1. Afficher les légendes du graphique sans chevaucher le graphique
1. Accéder à l’**Secondary Value Axis** du graphique et définir les propriétés suivantes :
   1. Activer l’**Secondary Value Axis**
   1. Définir le **Line Format** pour l’**Secondary Value Axis**
   1. Définir le **Number Format** pour l’**Secondary Value Axis**
   1. Définir les **Min, Max, Major and Minor units** pour l’**Secondary Value Axis**
1. Tracer maintenant la première série de graphique sur l’**Secondary Value Axis**
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de traçage du graphique
1. Enregistrer la présentation modifiée dans un fichier PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Définir les propriétés de police pour un graphique**
Aspose.Slides for C++ prend en charge la définition des propriétés liées aux polices pour le graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instancier un objet de la classe Presentation.
- Ajouter un graphique à la diapositive.
- Définir la hauteur de la police.
- Enregistrer la présentation modifiée.

L’exemple d’échantillon ci‑dessous est fourni.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Définir les propriétés de police pour le tableau de données d’un graphique**
Aspose.Slides for C++ offre la prise en charge de la modification de la couleur des catégories dans une couleur de série.

1. Instancier un objet de la classe Presentation.
1. Ajouter un graphique à la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

L’exemple d’échantillon ci‑dessous est fourni.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Définir les bordures arrondies de la zone du graphique**
Aspose.Slides for C++ offre la prise en charge de la définition de la zone du graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides.

1. Instancier un objet de la classe Presentation.
1. Ajouter un graphique à la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique
1. Définir la propriété round corner sur True.
1. Enregistrer la présentation modifiée.

L’exemple d’échantillon ci‑dessous est fourni.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Définir le format numérique**
Aspose.Slides for C++ fournit une API simple pour gérer le format des données de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenir la référence d’une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format numérique prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourir chaque cellule de données du graphique dans chaque série et définir le format numérique des données du graphique.
1. Enregistrer la présentation.
1. Définir le format numérique personnalisé.
1. Parcourir les cellules de données du graphique dans chaque série et définir un format numérique différent pour les données du graphique.
1. Enregistrer la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Les valeurs possibles de format numérique prédéfini avec leur indice et qui peuvent être utilisées sont indiquées ci‑dessous :**|
| :- | :- |

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0/)|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Puis‑je définir des remplissages semi‑transparents pour les colonnes/zones tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment puis‑je gérer les étiquettes de données lorsqu’elles se chevauchent ?**

Réduisez la taille de la police, désactivez les composants d’étiquette non essentiels (par exemple, les catégories), définissez le décalage/la position de l’étiquette, n’affichez les étiquettes que pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les remplissages plein, en dégradé ou en motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.