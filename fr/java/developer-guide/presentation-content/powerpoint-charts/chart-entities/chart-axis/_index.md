---
title: Personnaliser les axes de graphique dans les présentations avec Java
linktitle: Axe de graphique
type: docs
url: /fr/java/chart-axis/
keywords:
- axe de graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides for Java pour personnaliser les axes de graphique dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Aperçu**

Cet article explique comment personnaliser les axes de graphiques avec Aspose.Slides for Java. Il couvre les valeurs d’axe calculées, l’échange des lignes et colonnes du graphique, la visibilité des axes, les intervalles d’étiquettes de catégorie et de marques de graduation, les catégories de date et leur formatage, la rotation du titre, le positionnement des axes, les unités d’affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l’axe vertical des graphiques**

Créez une [Présentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) et ajoutez un graphique en aires avec des données par défaut. Appelez [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) avant de lire les valeurs d’axe calculées afin que la disposition du graphique soit à jour.

Lisez [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) et [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) pour les limites de l’axe, ainsi que [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) et [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) pour les intervalles de marques. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) et [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) fournissent des échelles d’unités de temps, pertinentes pour les axes de date. L’exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Échanger les données entre les axes**

Utilisez [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) pour inverser les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n’échange pas les axes horizontal et vertical. L’exemple utilise [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) pour lier les données par défaut à `Sheet1!A1:D5`, incluant la ligne d’en-tête et la colonne de catégorie, avant d’échanger les lignes et les colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Inverser l’ordre de tracé d’un axe**

Utilisez [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) pour inverser un axe de catégorie ou de valeur. Par exemple, un graphique à barres horizontal peut afficher les étapes d’un projet de haut en bas dans le même ordre que la feuille : Planification, Développement, Test. Inverser un axe change la direction de tracé ; cela ne trie pas et ne réarrange pas les données du classeur. En comparaison, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) échange les rôles des séries et des catégories.

L’exemple suivant crée un graphique à barres horizontal avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Diapositive 2 : afficher la première catégorie en haut.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Conserver l'axe de valeur horizontal en bas.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Diapositive 3 : inverser uniquement l'échelle numérique horizontale.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Inverser un axe peut également déplacer l’axe perpendiculaire du côté opposé du tracé. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) contrôle où l’autre axe croise l’axe configuré. Dans la diapositive 2, l’appeler avec `CrossesType.Maximum` sur l’axe de catégorie inversé maintient l’axe de valeur horizontal en bas. Pour un point de croisement spécifique, utilisez [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Vérifiez les paramètres de croisement lors du changement de direction, surtout si le graphique possède déjà un point de croisement personnalisé. Appelez `setPlotOrderReversed` avec `false` pour restaurer la direction de tracé normale ; les paramètres de croisement sont séparés.

| Ordre normal (diapositive 1) | Catégories inversées (diapositive 2) | Valeurs inversées (diapositive 3) |
| --- | --- | --- |
| ![Graphique à barres horizontal avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Graphique à barres horizontal avec catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Graphique à barres horizontal avec axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories s’étendent du bas vers le haut ; les valeurs augmentent de gauche à droite. | Planification, Développement et Test s’étendent de haut en bas. Les valeurs et l’ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L’axe de catégorie croise à zéro à droite. |

## **Masquer l’axe vertical pour les graphiques en courbes**

Appelez [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) avec `false` sur l’axe vertical pour le masquer. L’exemple crée un graphique en courbes avec des données par défaut et l’enregistre avec l’axe vertical masqué.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Masquer l’axe horizontal pour les graphiques en courbes**

Appelez [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) avec `false` sur l’axe horizontal pour le masquer. L’exemple crée un graphique en courbes avec des données par défaut et l’enregistre avec l’axe horizontal masqué.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier un axe de catégorie**

Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) pour choisir un axe de catégorie date ou texte. Cet exemple nécessite `ExistingChart.pptx`, contenant un graphique comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l’axe horizontal en axe de date. En appelant [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) avec `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) avec `1` et [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) avec `TimeUnitType.Months`, les graduations majeures sont placées à des intervalles d’un mois.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler les intervalles d’étiquettes d’axe de catégorie**

Lorsqu’un graphique possède de nombreuses catégories, réduisez le nombre d’étiquettes d’axe visibles sans supprimer les catégories ni les points de données. Appelez [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) avec `false`, puis transmettez l’intervalle de catégorie souhaité à [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Pour les catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l’exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, … Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, … Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, … Catégorie 22 |

Un intervalle de `3` affiche chaque troisième étiquette, en cachant deux étiquettes entre les affichées. Cela ne supprime pas les colonnes correspondantes. L’espacement automatique choisit un intervalle selon l’espace disponible ; il n’affiche pas nécessairement chaque étiquette.

Les marques de graduation disposent de contrôles séparés. Appelez [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) avec `false` et utilisez [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) pour définir leur intervalle. Par exemple, `1` conserve une marque à chaque intervalle de catégorie tandis que les étiquettes n’apparaissent qu’à chaque troisième catégorie. Utilisez [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) avec un style visible afin de voir le résultat. Repasser l’un ou l’autre des réglages automatiques à `true` permet au graphique de choisir à nouveau cet intervalle.

L’exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des étiquettes avec marques de graduation indépendantes, et restauration de l’espacement automatique. Les deux copies conservent les données d’origine du graphique. Aucun fichier de présentation d’entrée n’est requis. Le texte des étiquettes horizontales rend la différence de densité facile à voir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Diapositive 2 : afficher chaque troisième étiquette, mais conserver une marque de graduation pour chaque catégorie.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Diapositive 3 : laisser le graphique choisir à nouveau les deux intervalles.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Espacement automatique (diapositive 1) :** dans ce rendu, chaque seconde étiquette de catégorie est affichée et se répartit sur deux lignes. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** chaque troisième étiquette est affichée sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Toutes les 24 colonnes, y compris celles sans étiquette, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l’apparence automatique montrée ci‑dessus.

![Intervalle manuel des étiquettes de catégorie à trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir le bon axe et intervalle**

Utilisez cet intervalle de comptage de catégories pour un axe de catégorie texte, comme l’axe de catégorie d’un graphique en colonnes, en courbes, en aires ou en barres. Dans un graphique en colonnes, il s’agit de l’axe horizontal. Dans un graphique à barres horizontal, l’axe de catégorie est vertical, donc appliquez ces réglages à l’axe retourné par [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). L’espacement des marques de graduation s’applique également à un axe de série dans les graphiques qui en possèdent un.

N’utilisez pas l’espacement des étiquettes de catégorie pour définir l’échelle numérique d’un axe de valeur. Sur un axe de valeur, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des marques à 0, 10, 20, etc. lorsqu’on commence à zéro. Un intervalle d’étiquette de catégorie de `3` compte simplement les positions de catégorie, indépendamment de leurs valeurs. Les graphiques en nuage de points et à bulles utilisent des axes de valeur plutôt qu’un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures et des échelles basées sur le temps comme décrit dans [Modifier un axe de catégorie](#modifier-un-axe-de-catégorie).

## **Définir le format de date pour les valeurs d’axe de catégorie**

L’exemple remplace les données de graphique par défaut par quatre valeurs annuelles. Les dates sont stockées comme nombres de série OLE Automation dans la première feuille de calcul (indice `0`), calculées comme le nombre de jours depuis le 30 décembre 1899. Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) avec `CategoryAxisType.Date`, appelez [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) avec `false`, et transmettez `yyyy` à [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) pour que les étiquettes de catégorie affichent les années à quatre chiffres indépendamment du format de cellule.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir un angle de rotation pour le titre d’un axe de graphique**

Appelez [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) avec `true` sur l’axe vertical, fournissez le texte du titre, et utilisez [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) pour le faire pivoter. L’angle est exprimé en degrés ; cet exemple enregistre un graphique en colonnes avec le titre de l’axe de valeur pivoté à 90 degrés.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la position de l’axe sur un axe de catégorie ou de valeur**

Utilisez [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) pour contrôler si l’axe de valeur croise l’axe de catégorie entre les catégories ou sur les marques de catégorie. Ce réglage s’applique aux axes de catégorie. L’exemple le définit à `true` sur l’axe de catégorie horizontal d’un graphique en colonnes et enregistre le résultat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l’unité d’affichage sur un axe de valeur du graphique**

Utilisez [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) pour mettre à l’échelle les étiquettes d’un axe de valeur sans modifier les données sous‑jacent. Avec [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) réglé sur `Millions`, une valeur de 60 000 000 s’affiche sous la forme 60. L’exemple crée un graphique en colonnes et applique l’unité d’affichage « Millions » à son axe vertical.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Configurer un axe de valeur logarithmique**

Un axe de valeur logarithmique est utile lorsque des valeurs positives couvrent plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les valeurs les plus petites apparaissent très rapprochées près de zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Appelez [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) avec `true` sur l’axe de valeur et utilisez [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne change pas les données ni n’ajoute une ligne de tendance logarithmique. Une ligne de tendance représente une relation ajustée aux données et constitue une fonctionnalité séparée.

### **Choisir l’axe de valeur et la base**

Pour un graphique en lignes ou en colonnes, l’axe de valeur est retourné par [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Pour un graphique à barres horizontal, il est retourné par [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Les graphiques en nuage de points et à bulles possèdent deux axes de valeur, choisissez donc l’axe horizontal pour les valeurs X, l’axe vertical pour les valeurs Y, ou les deux. N’appliquez pas le redimensionnement logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000` inclusivement ; les bases fractionnaires comme `2.5` sont également prises en charge. Avec une base de `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont espacées uniformément.

### **Comparer les échelles linéaire et logarithmique**

L’exemple autonome suivant crée un graphique en lignes avec les cinq comptes de requêtes sur la première diapositive, puis clone cette diapositive et active un axe de valeur logarithmique base 10 sur la seconde. Les deux diapositives conservent les mêmes données.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Conserver la première diapositive linéaire et ne modifier que l'echelle de l'axe de valeur de la copie.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Échelle linéaire (diapositive 1) :** des distances verticales égales représentent des différences égales de comptage de requêtes. La plus grande valeur domine le graphique, rendant les plus petites difficiles à distinguer.

![Graphique en lignes PowerPoint montrant cinq comptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, les points forment donc une ligne droite ascendante sur l’échelle base 10. Les étiquettes d’axe affichent toujours les comptes de requêtes d’origine.

![Les mêmes cinq comptes de requêtes PowerPoint sur un axe de valeur logarithmique base 10](value-axis-logarithmic.png)

### **Gestion des valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l’activer. Si les valeurs zéro ou négatives sont significatives, conservez une échelle linéaire ou affichez‑les séparément. Si leur exclusion est justifiée, expliquez‑lui. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela modifie le sens des données. Toute valeur minimale ou maximale configurée manuellement pour un axe logarithmique doit également être positive.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l’autre (croisement d’axe) ?**

Utilisez [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) pour sélectionner le comportement de croisement. Pour spécifier une valeur numérique de croisement, utilisez [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Ces réglages vous permettent de déplacer le croisement d’axe vers une ligne de base adaptée.

**Comment positionner les étiquettes de graduation par rapport à l’axe ?**

Appelez [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) : `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) ou [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); ils sont distincts du positionnement des étiquettes.