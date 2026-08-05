---
title: Formatage des graphiques de présentation en C++
linktitle: Formatage des graphiques
type: docs
weight: 60
url: /fr/cpp/chart-formatting/
keywords:
- format de graphique
- formatage de graphique
- entité de graphique
- propriétés du graphique
- paramètres du graphique
- options du graphique
- propriétés de police
- bord arrondi
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez le formatage des graphiques dans Aspose.Slides pour C++ et améliorez votre présentation PowerPoint avec un style professionnel et attrayant."
---
## **Aperçu**

Cet article explique comment mettre en forme des graphiques dans des présentations PowerPoint en utilisant Aspose.Slides. Il montre comment personnaliser les éléments clés d’un graphique tels que les axes, les lignes de grille, les titres, les légendes, la zone de tracé et les remplissages des murs afin d’améliorer l’apparence et la lisibilité des données du graphique.

Il démontre également comment définir les propriétés de police pour le texte du graphique, appliquer des formats numériques prédéfinis et personnalisés aux données du graphique, et activer les coins arrondis pour la zone du graphique. Ensemble, ces exemples montrent comment contrôler à la fois le style visuel et la présentation des données des graphiques dans une présentation.

## **Formater les entités du graphique**
Aspose.Slides for C++ permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment formater différentes entités de graphique, y compris l’axe de catégorie et l’axe des valeurs.

Aspose.Slides for C++ fournit une API simple pour gérer les différentes entités de graphique et les formater à l’aide de valeurs personnalisées :

1. Créez une instance de la classe **Presentation**.
1. Obtenez la référence d’une diapositive par son indice.
1. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans cet exemple nous utiliserons **ChartType.LineWithMarkers**).
1. Accédez à l’axe des valeurs du graphique et définissez les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille principales de l’axe des valeurs
   1. Définir le **format de ligne** pour les lignes de grille secondaires de l’axe des valeurs
   1. Définir le **format numérique** pour l’axe des valeurs
   1. Définir les unités **Min, Max, principales et secondaires** pour l’axe des valeurs
   1. Définir les **propriétés de texte** pour les données de l’axe des valeurs
   1. Définir le **titre** pour l’axe des valeurs
   1. Définir le **format de ligne** pour l’axe des valeurs
1. Accédez à l’axe de catégorie du graphique et définissez les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille principales de l’axe de catégorie
   1. Définir le **format de ligne** pour les lignes de grille secondaires de l’axe de catégorie
   1. Définir les **propriétés de texte** pour les données de l’axe de catégorie
   1. Définir le **titre** pour l’axe de catégorie
   1. Définir le **positionnement des étiquettes** pour l’axe de catégorie
   1. Définir l’**angle de rotation** pour les étiquettes de l’axe de catégorie
1. Accédez à la légende du graphique et définissez les **propriétés de texte** correspondantes
1. Affichez les légendes du graphique sans qu’elles ne se chevauchent avec le graphique
1. Accédez à l’**axe des valeurs secondaire** du graphique et définissez les propriétés suivantes :
   1. Activer l’**axe des valeurs secondaire**
   1. Définir le **format de ligne** pour l’axe des valeurs secondaire
   1. Définir le **format numérique** pour l’axe des valeurs secondaire
   1. Définir les unités **Min, Max, principales et secondaires** pour l’axe des valeurs secondaire
1. Tracez maintenant la première série du graphique sur l’axe des valeurs secondaire
1. Définissez la couleur de remplissage du mur arrière du graphique
1. Définissez la couleur de remplissage de la zone de tracé du graphique
1. Enregistrez la présentation modifiée dans un fichier PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Définir les propriétés de police pour un graphique**
Aspose.Slides for C++ prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instancier un objet de la classe Presentation.
- Ajouter un graphique sur la diapositive.
- Définir la hauteur de la police.
- Enregistrer la présentation modifiée.

L’exemple suivant illustre cela.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Définir les propriétés de police pour le tableau de données du graphique**
Aspose.Slides for C++ prend en charge la modification de la couleur des catégories dans une série.

1. Instancier un objet de la classe Presentation.
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

L’exemple suivant illustre cela.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Définir les bordures arrondies de la zone du graphique**
Aspose.Slides for C++ prend en charge la configuration de la zone du graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides.

1. Instancier un objet de la classe Presentation.
1. Ajouter un graphique sur la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique
1. Activer la propriété de coins arrondis True.
1. Enregistrer la présentation modifiée.

L’exemple suivant illustre cela.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Définir le format numérique**
Aspose.Slides for C++ fournit une API simple pour gérer le format des données du graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Obtenez la référence d’une diapositive par son indice.
1. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Appliquez un format numérique prédéfini parmi les valeurs possibles.
1. Parcourez chaque cellule de données du graphique dans chaque série et définissez le format numérique des données du graphique.
1. Enregistrez la présentation.
1. Appliquez un format numérique personnalisé.
1. Parcourez chaque cellule de données du graphique dans chaque série et définissez un format numérique différent.
1. Enregistrez la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Les valeurs de format numérique prédéfini possibles ainsi que leur index, qui peuvent être utilisées, sont indiquées ci‑dessous :**|
| :- | :- |
|**0**|General|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Puis‑je appliquer des remplissages semi‑transparents aux colonnes ou aux zones tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les étiquettes de données lorsqu’elles se chevauchent ?**

Réduisez la taille de la police, désactivez les composants d’étiquette non essentiels (par exemple, les catégories), définissez le décalage/position de l’étiquette, affichez les étiquettes uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les remplissages unis, en dégradé ou en motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.