---
title: Gérer les étiquettes de données de graphique dans les présentations sur Android
linktitle: Étiquette de données
type: docs
url: /fr/androidjava/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance d'étiquette
- position d'étiquette
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Android via Java pour des diapositives plus attrayantes."
---

Les étiquettes de données d'un graphique affichent les détails concernant les séries de données du graphique ou les points de données individuels. Elles permettent aux lecteurs d'identifier rapidement les séries de données et facilitent également la compréhension des graphiques.

## **Définir la précision des données dans les étiquettes de graphique**

Ce code Java vous montre comment définir la précision des données dans une étiquette de graphique :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Afficher les pourcentages en tant qu'étiquettes**

Aspose.Slides for Android via Java vous permet de définir des étiquettes de pourcentage sur les graphiques affichés. Ce code Java montre l'opération :
```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Récupère la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Enregistre la présentation contenant le graphique
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir le signe pourcentage avec les étiquettes de données du graphique**

Ce code Java vous montre comment définir le signe pourcentage pour une étiquette de données de graphique :
```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtient une référence à la diapositive via son indice
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Crée le graphique PercentsStackedColumn sur une diapositive
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Définit NumberFormatLinkedToSource sur false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de calcul des données du graphique
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Ajoute une nouvelle série
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Définit la couleur de remplissage de la série
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Définit les propriétés de LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Ajoute une nouvelle série
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Définit le type de remplissage et la couleur
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // Enregistre la présentation sur le disque
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la distance de l'étiquette par rapport à un axe**

Ce code Java vous montre comment définir la distance de l'étiquette par rapport à un axe de catégorie lorsque vous travaillez avec un graphique tracé à partir d'axes :
```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtient la référence d'une diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Crée un graphique sur la diapositive
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Définit la distance de l'étiquette par rapport à un axe
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // Enregistre la présentation sur le disque
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajuster la position de l'étiquette**

Lorsque vous créez un graphique qui ne dépend d'aucun axe, comme un graphique circulaire, les étiquettes de données du graphique peuvent se retrouver trop proches de son bord. Dans ce cas, vous devez ajuster la position de l'étiquette de données afin que les traits de rattachement s'affichent clairement.

Ce code Java vous montre comment ajuster la position de l'étiquette sur un graphique circulaire :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Comment puis-je empêcher les étiquettes de données de se chevaucher sur des graphiques denses ?**  
Combinez le placement automatique des étiquettes, les traits de rattachement et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n'affichez les étiquettes que pour les points extrêmes ou clés.

**Comment puis-je désactiver les étiquettes uniquement pour les valeurs zero, négatives ou vides ?**  
Filtrez les points de données avant d'activer les étiquettes et désactivez l'affichage pour les valeurs egales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment puis-je garantir un style d'étiquette cohérent lors de l'exportation en PDF/images ?**  
Définissez explicitement les polices (famille, taille) et vérifiez que la police est disponible du côté du rendu afin d'éviter le recours à une police de secours.