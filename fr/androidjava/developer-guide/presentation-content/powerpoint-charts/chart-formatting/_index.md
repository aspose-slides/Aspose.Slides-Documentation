---
title: Formatage de Graphiques
type: docs
weight: 60
url: /fr/androidjava/chart-formatting/
---

## **Formatage des Entités de Graphique**
Aspose.Slides pour Android via Java permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment formater différentes entités de graphique, y compris l'axe des catégories et l'axe des valeurs.

Aspose.Slides pour Android via Java fournit une API simple pour gérer différentes entités de graphique et les formater en utilisant des valeurs personnalisées :

1. Créez une instance de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi qu'un type désiré (dans cet exemple, nous utiliserons ChartType.LineWithMarkers).
1. Accédez à l'Axe des Valeurs du graphique et définissez les propriétés suivantes :
   1. Définir le **Format de ligne** pour les lignes de grille majeures de l'axe des valeurs
   1. Définir le **Format de ligne** pour les lignes de grille mineures de l'axe des valeurs
   1. Définir le **Format de nombre** pour l'axe des valeurs
   1. Définir les **Unités Min, Max, Majeures et Mineures** pour l'axe des valeurs
   1. Définir les **Propriétés de texte** pour les données de l'axe des valeurs
   1. Définir le **Titre** pour l'axe des valeurs
   1. Définir le **Format de ligne** pour l'axe des valeurs
1. Accédez à l'Axe des Catégories du graphique et définissez les propriétés suivantes :
   1. Définir le **Format de ligne** pour les lignes de grille majeures de l'axe des catégories
   1. Définir le **Format de ligne** pour les lignes de grille mineures de l'axe des catégories
   1. Définir les **Propriétés de texte** pour les données de l'axe des catégories
   1. Définir le **Titre** pour l'axe des catégories
   1. Définir le **Positionnement des étiquettes** pour l'axe des catégories
   1. Définir l'**Angle de rotation** pour les étiquettes de l'axe des catégories
1. Accédez à la Légende du graphique et définissez les **Propriétés de texte** pour celles-ci
1. Affichez les légendes du graphique sans chevaucher le graphique
1. Accédez à l'**Axe des Valeurs Secondaires** du graphique et définissez les propriétés suivantes :
   1. Activez l'**Axe des Valeurs Secondaires**
   1. Définir le **Format de ligne** pour l'axe des valeurs secondaires
   1. Définir le **Format de nombre** pour l'axe des valeurs secondaires
   1. Définir les **Unités Min, Max, Majeures et Mineures** pour l'axe des valeurs secondaires
1. Tracez maintenant la première série de graphique sur l'Axe des Valeurs Secondaires
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de tracé du graphique
1. Écrire la présentation modifiée dans un fichier PPTX

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Accès à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter le graphique exemple
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Définir le titre du graphique
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Graphique Exemple");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Définir le format des lignes de grille majeures pour l'axe de valeur
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Définir le format des lignes de grille mineures pour l'axe de valeur
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Définir le format de nombre de l'axe des valeurs
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Définir les valeurs maximum et minimum du graphique
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
    valtitle.setText("Axe Principal");
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
    catTitle.setText("Catégorie Exemple");
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

    // Définir l'affichage des légendes du graphique sans chevauchement
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Définir l'axe des valeurs secondaires
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Définir le format de nombre de l'axe des valeurs secondaires
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Définir les valeurs maximum et minimum du graphique
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

    // Sauvegarder la Présentation
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir les Propriétés de Police pour le Graphique**
Aspose.Slides pour Android via Java fournit un support pour définir les propriétés de police liées au graphique. Veuillez suivre les étapes ci-dessous pour définir les propriétés de police pour le graphique.

- Instanciez un objet de classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Ajoutez un graphique sur la diapositive.
- Définissez la hauteur de la police.
- Sauvegardez la présentation modifiée.

Un exemple d'échantillon est donné ci-dessous.

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

## **Définir le Format des Nombres**
Aspose.Slides pour Android via Java fournit une API simple pour gérer le format des données graphiques :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi qu'un type désiré (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format de nombre prédéfini à partir des valeurs prédéfinies possibles.
1. Parcourez chaque cellule de données dans chaque série de graphiques et définissez le format de nombre des données graphiques.
1. Sauvegardez la présentation.
1. Définir le format de nombre personnalisé.
1. Parcourez chaque cellule de données à l'intérieur de chaque série de graphiques et définissez un format de nombre de graphique différent.
1. Sauvegardez la présentation.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter un graphique en colonne groupé par défaut
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accéder à la collection de séries de graphique
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Parcourez chaque série de graphique
    for (IChartSeries ser : series) 
    {
        // Parcourez chaque cellule de données dans la série
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Définir le format de nombre
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Sauvegarder la présentation
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Les valeurs possibles de format de nombre prédéfini ainsi que leur index prédéfini qui peuvent être utilisés sont données ci-dessous :

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
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les Bordures Arrondies de la Zone de Graphique**
Aspose.Slides pour Android via Java fournit un support pour définir la zone de graphique. Les méthodes [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) et [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) ont été ajoutées à l'interface [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) et à la classe [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart).

1. Instanciez un objet de classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Définissez le type de remplissage et la couleur de remplissage du graphique
1. Définissez la propriété des coins arrondis sur Vrai.
1. Sauvegardez la présentation modifiée.

Un exemple d'échantillon est donné ci-dessous.

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