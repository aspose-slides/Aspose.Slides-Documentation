---
title: Personnaliser les graphiques circulaires dans les présentations sur Android
linktitle: Graphique circulaire
type: docs
url: /fr/androidjava/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de tranche
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer et personnaliser des graphiques circulaires sur Android avec Aspose.Slides for Android via Java. Configurer les tracés secondaires, afficher les étiquettes de données et appliquer des couleurs automatiques aux tranches dans PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie, et comment activer la coloration automatique des tranches pour un graphique circulaire standard.

Les exemples portent sur des tâches de personnalisation de graphiques telles que l'ajout d'un graphique à une diapositive, l'ajustement des séries et des paramètres d'étiquettes, le remplacement des données de graphique par défaut par des catégories et des valeurs personnalisées, et l'enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides for Android via Java prend en charge les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie. Ces options contrôlent la taille du tracé secondaire et la façon dont les points de données sont répartis entre les deux tracés.

L’exemple suivant crée un graphique Pie of Pie dans une nouvelle présentation et affiche les valeurs des points de données comme étiquettes. La méthode [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) définit la taille du tracé secondaire à 149% du tracé principal. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) sélectionne le fractionnement basé sur le pourcentage, et [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) définit le seuil à 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Afficher les valeurs et configurer le tracé secondaire.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sélectionner des catégories pour le tracé secondaire**

Utilisez le fractionnement personnalisé lorsque vous souhaitez regrouper des catégories spécifiques dans le tracé secondaire, quel que soit leur pourcentage. Par exemple, un rapport de ventes pourrait afficher Online et Events ensemble afin que les lecteurs puissent comparer ces deux canaux, même s’ils représentent 35% et 10% du total des ventes.

Appelez [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) avec [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) et sélectionnez les points à l’aide de [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). La méthode [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) de la collection accepte un indice basé sur zéro dans la série ; utilisez [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) pour ajouter un objet de point de données. Dans cet exemple, l’indice 1 sélectionne Online, et le point à l’indice 3 sélectionne Events. Partners est également ajouté temporairement, puis exclu à l’aide de [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Remplacer les données par défaut par les ventes par canal.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Sélectionner Online par son indice zéro et Events par son objet de point de données.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Exclure Partners de la sélection sans supprimer ses données sources.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) et Events (10) apparaissent comme des tranches séparées dans le tracé secondaire. Dans le tracé principal, ils sont représentés par une tranche combinée d’une valeur de 45, aux côtés de Retail (40) et Partners (15). Supprimer Partners de la sélection personnalisée le maintient dans le tracé principal ; cela ne supprime pas la catégorie ou sa valeur des données sources du graphique.

L’image suivante montre la présentation enregistrée dans PowerPoint :

![Graphique Pie of Pie avec Online et Events dans le tracé secondaire et leur valeur combinée de 45 dans le tracé principal](pie_of_pie_custom.png)

## **Définir des couleurs automatiques pour les tranches du graphique circulaire**

Aspose.Slides for Android via Java peut attribuer automatiquement des couleurs différentes aux tranches d’un graphique circulaire. L’exemple suivant crée un graphique circulaire avec un titre centré et remplace les données par défaut par trois catégories trimestrielles et leurs valeurs. La méthode [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) affiche les valeurs 20, 50 et 30 comme étiquettes, tandis que [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) active une couleur distincte pour chaque tranche.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Ajouter un titre de graphique centré.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Remplacer les données par défaut en utilisant la première feuille de calcul.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Afficher les valeurs et attribuer des couleurs différentes aux tranches.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Les variantes Pie of Pie et Bar of Pie sont‑elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types Pie of Pie et Bar of Pie.

**Puis‑je exporter uniquement le graphique sous forme d’image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même en tant qu’image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (par exemple PNG) sans exporter toute la présentation.