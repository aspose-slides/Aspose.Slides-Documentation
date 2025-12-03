---
title: Personnaliser les barres d'erreur dans les graphiques de présentation avec Java
linktitle: Barre d'erreur
type: docs
url: /fr/java/error-bar/
keywords:
- barre d'erreur
- valeur personnalisée
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment ajouter et personnaliser les barres d'erreur dans les graphiques avec Aspose.Slides for Java — optimisez les visualisations de données dans les présentations PowerPoint."
---

## **Ajouter une barre d'erreur**
Aspose.Slides for Java fournit une API simple pour gérer les valeurs des barres d'erreur. Le code d'exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) des séries :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Définir les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Création d'un graphique à bulles
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Ajout des barres d'erreur et définition de leur format
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Enregistrement de la présentation
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter une valeur de barre d'erreur personnalisée**
Aspose.Slides for Java fournit une API simple pour gérer les valeurs personnalisées des barres d'erreur. Le code d'exemple s'applique lorsque la propriété [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) des séries :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série de graphiques et définissez les valeurs de la barre d'erreur pour chaque point de données de la série.
1. Définir les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Création d'un graphique à bulles
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Ajout des barres d'erreur personnalisées et définition de leur format
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Accès au point de données de la série de graphique et définition des valeurs des barres d'erreur pour
    // point individuel
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Définition des barres d'erreur pour les points de la série de graphique
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Enregistrement de la présentation
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Que se passe-t-il pour les barres d'erreur lors de l'exportation d'une présentation vers PDF ou images ?**

Elles sont rendues comme faisant partie du graphique et conservées lors de la conversion avec le reste du formatage du graphique, en supposant une version ou un rendu compatible.

**Les barres d'erreur peuvent-elles être combinées avec des marqueurs et des étiquettes de données ?**

Oui. Les barres d'erreur sont un élément distinct et sont compatibles avec les marqueurs et les étiquettes de données ; si les éléments se chevauchent, vous devrez peut-être ajuster le formatage.

**Où puis-je trouver la liste des propriétés et des classes pour travailler avec les barres d'erreur dans l'API ?**

Dans la référence de l'API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) et les classes associées [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).