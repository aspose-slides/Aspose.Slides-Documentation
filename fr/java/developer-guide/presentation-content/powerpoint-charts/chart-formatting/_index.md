---
title: Formatage des Graphiques
type: docs
weight: 60
url: /fr/java/chart-formatting/
---

## **Formater les Entités de Graphique**
Aspose.Slides pour Java permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment formater différentes entités de graphique, y compris l'axe des catégories et l'axe des valeurs.

Aspose.Slides pour Java fournit une API simple pour gérer différentes entités de graphique et les formater à l'aide de valeurs personnalisées :

1. Créer une instance de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir une référence de diapositive par son index.
1. Ajouter un graphique avec des données par défaut de n'importe quel type désiré (dans cet exemple, nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l'axe des valeurs du graphique et définir les propriétés suivantes :
   1. Définir **le format de ligne** pour les lignes de grille majeures de l'axe des valeurs
   1. Définir **le format de ligne** pour les lignes de grille mineures de l'axe des valeurs
   1. Définir **le format de nombre** pour l'axe des valeurs
   1. Définir **les unités Min, Max, Majeur et Mineur** pour l'axe des valeurs
   1. Définir **les propriétés de texte** pour les données de l'axe des valeurs
   1. Définir **le titre** pour l'axe des valeurs
   1. Définir **le format de ligne** pour l'axe des valeurs
1. Accéder à l'axe des catégories du graphique et définir les propriétés suivantes :
   1. Définir **le format de ligne** pour les lignes de grille majeures de l'axe des catégories
   1. Définir **le format de ligne** pour les lignes de grille mineures de l'axe des catégories
   1. Définir **les propriétés de texte** pour les données de l'axe des catégories
   1. Définir **le titre** pour l'axe des catégories
   1. Définir **le positionnement des étiquettes** pour l'axe des catégories
   1. Définir **l'angle de rotation** pour les étiquettes de l'axe des catégories
1. Accéder à la légende du graphique et définir **les propriétés de texte** pour celle-ci
1. Afficher les légendes du graphique sans chevaucher le graphique
1. Accéder à **l'axe des valeurs secondaires** du graphique et définir les propriétés suivantes :
   1. Activer **l'axe des valeurs secondaires**
   1. Définir **le format de ligne** pour l'axe des valeurs secondaires
   1. Définir **le format de nombre** pour l'axe des valeurs secondaires
   1. Définir **les unités Min, Max, Majeur et Mineur** pour l'axe des valeurs secondaires
1. Maintenant, tracer la première série de graphique sur l'axe des valeurs secondaires
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
    chartTitle.setText("Graphique d'Exemple");
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

    // Définir le format du nombre de l'axe des valeurs
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Définir les valeurs maximales et minimales du graphique
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

    // Définir le titre de l'axe des catégories
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Catégorie d'Exemple");
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

    // Afficher les légendes du graphique sans chevauchement

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

    // Définir les valeurs maximales et minimales du graphique
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

    // Enregistrer la Présentation
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir les Propriétés de Police pour le Graphique**
Aspose.Slides pour Java propose un support pour définir les propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci-dessous pour définir les propriétés de police pour le graphique.

- Instancier l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Ajouter un graphique sur la diapositive.
- Définir la hauteur de police.
- Enregistrer la présentation modifiée.

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
Aspose.Slides pour Java fournit une API simple pour gérer le formatage des données de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenir une référence de diapositive par son index.
1. Ajouter un graphique avec des données par défaut de n'importe quel type désiré (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format de nombre prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourir chaque cellule de données dans chaque série de graphiques et définir le format de nombre du graphique.
1. Enregistrer la présentation.
1. Définir le format de nombre personnalisé.
1. Parcourir les cellules de données dans chaque série de graphiques et définir un format de nombre différent pour le graphique.
1. Enregistrer la présentation.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter un graphique à colonnes groupées par défaut
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accéder à la collection de séries de graphiques
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Parcourir chaque série de graphiques
    for (IChartSeries ser : series) 
    {
        // Parcourir chaque cellule de données dans la série
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Définir le format de nombre
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Enregistrer la présentation
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

Les valeurs possibles du format de nombre prédéfini avec leur index prédéfini pouvant être utilisées sont données ci-dessous :

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
Aspose.Slides pour Java propose un support pour définir la zone de graphique. Les méthodes [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) et [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) ont été ajoutées à l'interface [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) et à la classe [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart).

1. Instancier l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique
1. Définir la propriété de coin arrondi sur True.
1. Enregistrer la présentation modifiée.

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