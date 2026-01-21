---
title: Formater les graphiques de présentation en C++
linktitle: Formatage de graphiques
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
- bordure arrondie
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez le formatage des graphiques dans Aspose.Slides pour C++ et améliorez votre présentation PowerPoint avec un style professionnel et attractif."
---

## **Formater les entités de graphique**
Aspose.Slides pour C++ permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment formater différentes entités de graphique, y compris la catégorie du graphique et l’axe des valeurs.

Aspose.Slides pour C++ fournit une API simple pour gérer différentes entités de graphique et les formater à l’aide de valeurs personnalisées :

1. Créez une instance de la classe **Presentation**.
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple nous utiliserons ChartType.LineWithMarkers).
4. Accédez à l’Axe des valeurs du graphique et définissez les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de grille majeures de Value Axis
   2. Définir le **Line format** pour les lignes de grille mineures de Value Axis
   3. Définir le **Number Format** pour Value Axis
   4. Définir le **Min, Max, Major and Minor units** pour Value Axis
   5. Définir le **Text Properties** pour les données de Value Axis
   6. Définir le **Title** pour Value Axis
   7. Définir le **Line Format** pour Value Axis
5. Accédez à l’Axe des catégories du graphique et définissez les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de grille majeures de Category Axis
   2. Définir le **Line format** pour les lignes de grille mineures de Category Axis
   3. Définir le **Text Properties** pour les données de Category Axis
   4. Définir le **Title** pour Category Axis
   5. Définir le **Label Positioning** pour Category Axis
   6. Définir le **Rotation Angle** pour les libellés de Category Axis
6. Accédez à la légende du graphique et définissez les **Text Properties** pour celle‑ci.
7. Configurez l’affichage des légendes du graphique sans chevaucher le graphique.
8. Accédez à l’**Secondary Value Axis** du graphique et définissez les propriétés suivantes :
   1. Activer l’**Secondary Value Axis**
   2. Définir le **Line Format** pour Secondary Value Axis
   3. Définir le **Number Format** pour Secondary Value Axis
   4. Définir le **Min, Max, Major and Minor units** pour Secondary Value Axis
9. Tracez maintenant la première série de graphique sur Secondary Value Axis.
10. Définissez la couleur de remplissage du mur arrière du graphique.
11. Définissez la couleur de remplissage de la zone de tracé du graphique.
12. Enregistrez la présentation modifiée dans un fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Définir les propriétés de police d’un graphique**
Aspose.Slides pour C++ prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instanciez un objet de la classe Presentation.
- Ajoutez un graphique sur la diapositive.
- Définissez la hauteur de la police.
- Enregistrez la présentation modifiée.

L’exemple suivant est fourni.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Définir les propriétés de police d’une table de données de graphique**
Aspose.Slides pour C++ prend en charge la modification de la couleur des catégories dans la couleur d’une série.

1. Instanciez un objet de la classe Presentation.
1. Ajoutez un graphique sur la diapositive.
1. Définissez la table du graphique.
1. Définissez la hauteur de la police.
1. Enregistrez la présentation modifiée.

L’exemple suivant est fourni.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Définir les coins arrondis de la zone du graphique**
Aspose.Slides pour C++ prend en charge la définition de la zone du graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides.

1. Instanciez un objet de la classe Presentation.
1. Ajoutez un graphique sur la diapositive.
1. Définissez le type de remplissage et la couleur de remplissage du graphique.
1. Activez la propriété de coins arrondis (True).
1. Enregistrez la présentation modifiée.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Définir le format numérique**
Aspose.Slides pour C++ fournit une API simple pour gérer le format des données de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son indice.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple, nous utilisons **ChartType.ClusteredColumn**).
4. Définissez le format numérique prédéfini parmi les valeurs prédéfinies possibles.
5. Parcourez chaque cellule de données du graphique dans toutes les séries et définissez le format numérique des données du graphique.
6. Enregistrez la présentation.
7. Définissez le format numérique personnalisé.
8. Parcourez chaque cellule de données du graphique dans toutes les séries et définissez un format numérique différent pour les données du graphique.
9. Enregistrez la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Les valeurs possibles de format numérique prédéfini ainsi que leur indice et qui peuvent être utilisées sont présentées ci‑dessous :**|
| :- | :- |
|**0**|Général|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **FAQ**

**Puis‑je définir des remplissages semi‑transparents pour les colonnes/zones tout en gardant la bordure opaque ?**  
Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les étiquettes de données lorsqu’elles se chevauchent ?**  
Réduisez la taille de la police, désactivez les composants d’étiquettes non essentiels (par exemple, les catégories), ajustez le décalage/position de l’étiquette, affichez les étiquettes uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages en dégradé ou en motif aux séries ?**  
Oui. Les remplissages plein et en dégradé/motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.