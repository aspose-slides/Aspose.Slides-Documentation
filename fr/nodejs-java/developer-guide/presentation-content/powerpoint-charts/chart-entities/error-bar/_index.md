---
title: Barre d'erreur
type: docs
url: /fr/nodejs-java/error-bar/
---

## **Ajouter une barre d'erreur**

Aspose.Slides for Node.js via Java fournit une API simple pour gérer les valeurs des barres d'erreur. Le code d'exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Définissez les valeurs des barres et leur format.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Création d'un graphique à bulles
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Ajout de barres d'erreur et définition de leur format
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Enregistrement de la présentation
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajouter une valeur de barre d'erreur personnalisée**

Aspose.Slides for Node.js via Java fournit une API simple pour gérer les valeurs de barres d'erreur personnalisées. Le code d'exemple s'applique lorsque la propriété [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série de graphique et définissez les valeurs de la barre d'erreur pour chaque point de données de la série.
1. Définissez les valeurs des barres et leur format.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Créer un graphique à bulles
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Ajout de barres d'erreur personnalisées et définition de leur format
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Accéder au point de données de la série du graphique et définir les valeurs des barres d'erreur pour
    // point individuel
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Définir les barres d'erreur pour les points de la série du graphique
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Enregistrement de la présentation
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Que se passe-t-il avec les barres d'erreur lors de l'exportation d'une présentation en PDF ou en images ?**

Elles sont rendues comme partie du graphique et conservées pendant la conversion avec le reste du formatage du graphique, en supposant une version ou un moteur compatible.

**Les barres d'erreur peuvent-elles être combinées avec des marqueurs et des étiquettes de données ?**

Oui. Les barres d'erreur sont un élément distinct et sont compatibles avec les marqueurs et les étiquettes de données ; si les éléments se chevauchent, vous devrez peut‑être ajuster le formatage.

**Où puis-je trouver la liste des propriétés et des énumérations pour travailler avec les barres d'erreur dans l'API ?**

Dans la référence de l'API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarsformat/) et les énumérations associées [ErrorBarType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarvaluetype/).