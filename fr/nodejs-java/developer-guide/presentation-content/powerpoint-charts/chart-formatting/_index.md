---
title: Formater les graphiques de présentation en JavaScript
linktitle: Formatage des graphiques
type: docs
weight: 60
url: /fr/nodejs-java/chart-formatting/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez le formatage des graphiques dans Aspose.Slides pour Node.js en JavaScript et améliorez votre présentation PowerPoint avec un style professionnel et attrayant."
---

## **Formater les entités du graphique**

Aspose.Slides for Node.js via Java permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives depuis le début. Cet article explique comment formater différentes entités du graphique, y compris l'axe des catégories et l'axe des valeurs.

Aspose.Slides for Node.js via Java fournit une API simple pour gérer différentes entités du graphique et les formater à l'aide de valeurs personnalisées :

1. Créer une instance de la classe [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenir la référence d'une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple, nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l'axe des valeurs du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes majeures de la grille de l'axe des valeurs
   1. Définir le **format de ligne** pour les lignes mineures de la grille de l'axe des valeurs
   1. Définir le **format de nombre** pour l'axe des valeurs
   1. Définir les **unités Min, Max, majeures et mineures** pour l'axe des valeurs
   1. Définir les **propriétés de texte** pour les données de l'axe des valeurs
   1. Définir le **titre** pour l'axe des valeurs
   1. Définir le **format de ligne** pour l'axe des valeurs
1. Accéder à l'axe des catégories du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes majeures de la grille de l'axe des catégories
   1. Définir le **format de ligne** pour les lignes mineures de la grille de l'axe des catégories
   1. Définir les **propriétés de texte** pour les données de l'axe des catégories
   1. Définir le **titre** pour l'axe des catégories
   1. Définir le **positionnement des libellés** pour l'axe des catégories
   1. Définir l'**angle de rotation** pour les libellés de l'axe des catégories
1. Accéder à la légende du graphique et définir les **propriétés de texte** pour celle-ci
1. Afficher les légendes du graphique sans chevaucher le graphique
1. Accéder à l'**axe secondaire des valeurs** du graphique et définir les propriétés suivantes :
   1. Activer l'**axe secondaire des valeurs**
   1. Définir le **format de ligne** pour l'axe secondaire des valeurs
   1. Définir le **format de nombre** pour l'axe secondaire des valeurs
   1. Définir les **unités Min, Max, majeures et mineures** pour l'axe secondaire des valeurs
1. Tracer maintenant la première série du graphique sur l'axe secondaire des valeurs
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de tracé du graphique
1. Écrire la présentation modifiée dans un fichier PPTX
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter le graphique d'exemple
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Définir le titre du graphique
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Définir le format des lignes de grille majeures pour l'axe des valeurs
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Définir le format des lignes de grille mineures pour l'axe des valeurs
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Définir le format numérique de l'axe des valeurs
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Définir les valeurs maximales et minimales du graphique
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Définir les propriétés de texte de l'axe des valeurs
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Définir le titre de l'axe des valeurs
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Définir le format des lignes de grille majeures pour l'axe des catégories
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Définir le format des lignes de grille mineures pour l'axe des catégories
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Définir les propriétés de texte de l'axe des catégories
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Définir le titre de la catégorie
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Définir la position des étiquettes de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Définir l'angle de rotation des étiquettes de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Définir les propriétés de texte des légendes
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Afficher les légendes du graphique sans chevaucher le graphique
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Définir l'axe secondaire des valeurs
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Définir le format numérique de l'axe secondaire des valeurs
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Définir les valeurs maximales et minimales du graphique (axe secondaire)
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Définir la couleur du mur arrière du graphique
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Définir la couleur de la zone de tracé
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Enregistrer la présentation
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir les propriétés de police pour le graphique**

Aspose.Slides for Node.js via Java prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
- Ajouter un graphique sur la diapositive.
- Définir la hauteur de la police.
- Enregistrer la présentation modifiée.

L'exemple d'échantillon ci‑dessous est fourni.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir le format des valeurs numériques**

Aspose.Slides for Node.js via Java fournit une API simple pour gérer le format des données du graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenir la référence d'une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format de nombre prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourir la cellule de données du graphique dans chaque série et définir le format de nombre des données du graphique.
1. Enregistrer la présentation.
1. Définir le format de nombre personnalisé.
1. Parcourir la cellule de données du graphique dans chaque série et appliquer un format de nombre différent aux données du graphique.
1. Enregistrer la présentation.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Ajouter un graphique en colonnes groupées par défaut
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Accéder à la collection des séries du graphique
    var series = chart.getChartData().getSeries();
    // Parcourir chaque série du graphique
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Parcourir chaque cellule de données dans la série
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Définir le format numérique
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Enregistrer la présentation
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Les valeurs de format de nombre prédéfinies possibles ainsi que leur index sont indiquées ci‑dessous :

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
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les coins arrondis de la zone du graphique**

Aspose.Slides for Node.js via Java prend en charge la définition de la zone du graphique. Les méthodes [**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) et [**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) ont été ajoutées à la classe [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart) et [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart).

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique
1. Définir la propriété de coin arrondi sur True.
1. Enregistrer la présentation modifiée.

L'exemple d'échantillon ci‑dessous est fourni. 
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je définir des remplissages semi‑transparents pour les colonnes/zones tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les étiquettes de données lorsqu'elles se chevauchent ?**

Réduire la taille de la police, désactiver les composants d'étiquette non essentiels (par exemple, les catégories), régler le décalage/la position de l'étiquette, n'afficher les étiquettes que pour les points sélectionnés si nécessaire, ou passer au format "valeur + légende".

**Puis-je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les remplissages plein et en dégradé/motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.