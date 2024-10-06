---
title: Formatage de Graphiques
type: docs
weight: 60
url: /cpp/chart-formatting/
---



## **Formatage des Éléments de Graphique**
Aspose.Slides pour C++ permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives depuis le début. Cet article explique comment formater différents éléments de graphique, y compris l'axe des catégories et l'axe des valeurs.

Aspose.Slides pour C++ fournit une API simple pour gérer différents éléments de graphique et les formater à l'aide de valeurs personnalisées :

1. Créer une instance de la classe **Presentation**.
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple, nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l'axe des valeurs du graphique et définir les propriétés suivantes :
   1. Définir **le format de ligne** pour les lignes de grille majeures de l'axe des valeurs
   1. Définir **le format de ligne** pour les lignes de grille mineures de l'axe des valeurs
   1. Définir **le format de nombre** pour l'axe des valeurs
   1. Définir **les unités Min, Max, Majeur et Mineur** pour l'axe des valeurs
   1. Définir **les propriétés de texte** pour les données de l'axe des valeurs
   1. Définir **le titre** pour l'axe des valeurs
   1. Définir **le format de ligne** pour l'axe des valeurs
1. Accéder à l'axe des catégories du graphique et définir les propriétés suivantes :
   1. Définir **le format de ligne** pour les lignes de grille majeures de l'axe des catégories
   1. Définir **le format de ligne** pour les lignes de grille mineures de l'axe des catégories
   1. Définir **les propriétés de texte** pour les données de l'axe des catégories
   1. Définir **le titre** pour l'axe des catégories
   1. Définir **le positionnement des étiquettes** pour l'axe des catégories
   1. Définir **l'angle de rotation** pour les étiquettes de l'axe des catégories
1. Accéder à la légende du graphique et définir **les propriétés de texte** pour celles-ci
1. Afficher les légendes du graphique sans chevauchement
1. Accéder à l'**axe des valeurs secondaires** du graphique et définir les propriétés suivantes :
   1. Activer l'**axe des valeurs secondaires**
   1. Définir **le format de ligne** pour l'axe des valeurs secondaires
   1. Définir **le format de nombre** pour l'axe des valeurs secondaires
   1. Définir **les unités Min, Max, Majeur et Mineur** pour l'axe des valeurs secondaires
1. Maintenant, tracer la première série de graphique sur l'axe des valeurs secondaires
1. Définir le mur arrière du graphique pour remplir la couleur
1. Définir la couleur de remplissage de la zone de traçage du graphique
1. Écrire la présentation modifiée dans un fichier PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Définir les Propriétés de Police pour le Graphique**
Aspose.Slides pour C++ prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci-dessous pour définir les propriétés de police pour le graphique.

- Instancier un objet de la classe Presentation.
- Ajouter un graphique à la diapositive.
- Définir la taille de la police.
- Enregistrer la présentation modifiée.

Un exemple d'échantillon ci-dessous est donné.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Définir les Propriétés de Police pour le Tableau de Données du Graphique**
Aspose.Slides pour C++ prend en charge le changement de couleur des catégories dans une série de couleurs. 

1. Instancier un objet de la classe Presentation.
1. Ajouter un graphique à la diapositive.
1. Définir le tableau du graphique.
1. Définir la taille de la police.
1. Enregistrer la présentation modifiée.

Un exemple d'échantillon ci-dessous est donné. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Définir les Bordures Arrondies de la Zone de Graphique**
Aspose.Slides pour C++ prend en charge la définition de la zone de graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides. 

1. Instancier un objet de la classe Presentation.
1. Ajouter un graphique à la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique.
1. Définir la propriété coins arrondis à True.
1. Enregistrer la présentation modifiée. 

Un exemple d'échantillon ci-dessous est donné. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Définir les Nombres de Données de Graphique**
Aspose.Slides pour C++ fournit une API simple pour gérer le format des données de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format de nombre prédéfini à partir des valeurs prédéfinies possibles.
1. Parcourir la cellule de données du graphique dans chaque série de graphique et définir le format de nombre des données du graphique.
1. Enregistrer la présentation.
1. Définir le format de nombre personnalisé.
1. Parcourir la cellule de données du graphique à l'intérieur de chaque série de graphique et définir un format de nombre de données de graphique différent.
1. Enregistrer la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Les valeurs possibles de format de nombre prédéfini, ainsi que leur index prédéfini qui peuvent être utilisées, sont données ci-dessous :**|
| :- | :- |

|**0**|Général|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rouge$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rouge$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/j/aa|
|**15**|j-mmm-aa|
|**16**|j-mmm|
|**17**|mmm-aa|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/j/aa h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rouge-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rouge-#,##0.00|
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