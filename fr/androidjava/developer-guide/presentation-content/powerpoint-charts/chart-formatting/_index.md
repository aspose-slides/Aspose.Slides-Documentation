---
title: Format des graphiques de présentation sur Android
linktitle: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/androidjava/chart-formatting/
keywords:
- format de graphique
- mise en forme de graphique
- entité de graphique
- propriétés de graphique
- paramètres de graphique
- options de graphique
- propriétés de police
- bord arrondi
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez la mise en forme des graphiques dans Aspose.Slides pour Android via Java et améliorez votre présentation PowerPoint avec un style professionnel et accrocheur."
---

## **Formater les entités de graphique**
Aspose.Slides for Android via Java permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives depuis le début. Cet article explique comment formater différentes entités de graphique, y compris les axes de catégorie et de valeur.

Aspose.Slides for Android via Java fournit une API simple pour gérer différentes entités de graphique et les formater en utilisant des valeurs personnalisées :

1. Créer une instance de la classe [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenir la référence d’une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple, nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l’axe des valeurs du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille majeures de l’axe des valeurs
   1. Définir le **format de ligne** pour les lignes de grille mineures de l’axe des valeurs
   1. Définir le **format de nombre** pour l’axe des valeurs
   1. Définir les **unités Min, Max, majeures et mineures** pour l’axe des valeurs
   1. Définir les **propriétés de texte** pour les données de l’axe des valeurs
   1. Définir le **titre** de l’axe des valeurs
   1. Définir le **format de ligne** de l’axe des valeurs
1. Accéder à l’axe des catégories du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille majeures de l’axe des catégories
   1. Définir le **format de ligne** pour les lignes de grille mineures de l’axe des catégories
   1. Définir les **propriétés de texte** pour les données de l’axe des catégories
   1. Définir le **titre** de l’axe des catégories
   1. Définir le **positionnement des libellés** pour l’axe des catégories
   1. Définir l’**angle de rotation** des libellés de l’axe des catégories
1. Accéder à la légende du graphique et définir les **propriétés de texte** pour celle‑ci
1. Afficher les légendes du graphique sans chevaucher le graphique
1. Accéder à l’**axe des valeurs secondaire** du graphique et définir les propriétés suivantes :
   1. Activer l’**axe des valeurs secondaire**
   1. Définir le **format de ligne** pour l’axe des valeurs secondaire
   1. Définir le **format de nombre** pour l’axe des valeurs secondaire
   1. Définir les **unités Min, Max, majeures et mineures** pour l’axe des valeurs secondaire
1. Tracer maintenant la première série de graphique sur l’axe des valeurs secondaire
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de tracé du graphique
1. Enregistrer la présentation modifiée dans un fichier PPTX
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter le graphique d'exemple
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Définir le titre du graphique
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir le format des lignes de grille majeures pour l'axe des valeurs
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Définir le format des lignes de grille mineures pour l'axe des valeurs
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Définir le format numérique de l'axe des valeurs
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Définir les valeurs maximale et minimale du graphique
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Définir les propriétés de texte de l'axe des valeurs
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Définir le titre de l'axe des valeurs
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir le format des lignes de grille majeures pour l'axe des catégories
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Définir le format des lignes de grille mineures pour l'axe des catégories
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Définir les propriétés de texte de l'axe des catégories
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Définir le titre de la catégorie
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir la position des étiquettes de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Définir l'angle de rotation des étiquettes de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Définir les propriétés de texte des légendes
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Afficher les légendes du graphique sans chevaucher le graphique

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Définir l'axe des valeurs secondaire
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Définir le format numérique de l'axe des valeurs secondaire
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Définir les valeurs maximale et minimale du graphique
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Définir la couleur du mur arrière du graphique
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Définir la couleur de la zone de tracé
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Enregistrer la présentation
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir les propriétés de police pour un graphique**
Aspose.Slides for Android via Java prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instancier l’objet de classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
- Ajouter un graphique sur la diapositive.
- Définir la hauteur de la police.
- Enregistrer la présentation modifiée.

L’exemple de code ci‑dessous est fourni.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir le format numérique**
Aspose.Slides for Android via Java fournit une API simple pour gérer le format des données du graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. Obtenir la référence d’une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format numérique prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourir les cellules de données du graphique dans chaque série et définir le format numérique des données du graphique.
1. Enregistrer la présentation.
1. Définir le format numérique personnalisé.
1. Parcourir les cellules de données du graphique dans chaque série et définir un format numérique différent pour les données du graphique.
1. Enregistrer la présentation.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter un diagramme à colonnes groupées par défaut
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accéder à la collection des séries du diagramme
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Parcourir chaque série du diagramme
    for (IChartSeries ser : series) 
    {
        // Parcourir chaque cellule de données de la série
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Définir le format numérique
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    // Enregistrer la présentation
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Les valeurs de format numérique prédéfini possibles ainsi que leur index sont indiquées ci‑dessous :

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

## **Définir les bords arrondis de la zone du graphique**
Aspose.Slides for Android via Java prend en charge la définition de la zone du graphique. Les méthodes [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) et [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) ont été ajoutées à l’interface [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) et à la classe [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart).

1. Instancier l’objet de classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Ajouter un graphique sur la diapositive.
3. Définir le type de remplissage et la couleur de remplissage du graphique
4. Définir la propriété d’angle arrondi à true.
5. Enregistrer la présentation modifiée.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis‑je définir des remplissages semi‑transparents pour les colonnes/aires tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans les visualisations denses.

**Comment gérer les libellés de données lorsqu’ils se chevauchent ?**

Réduisez la taille de la police, désactivez les composants de libellé non essentiels (par exemple les catégories), définissez le décalage/position du libellé, n’affichez les libellés que pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages en dégradé ou à motifs aux séries ?**

Oui. Les remplissages unis ainsi que les remplissages en dégradé/motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.