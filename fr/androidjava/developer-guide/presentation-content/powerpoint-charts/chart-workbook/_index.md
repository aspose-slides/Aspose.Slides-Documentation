---
title: Carnet de Chart
type: docs
weight: 70
url: /fr/androidjava/chart-workbook/
keywords: "Carnet de Chart, données de chart, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Carnet de chart dans la présentation PowerPoint en Java"
---

## **Définir les Données du Chart à partir du Carnet**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) et [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) qui vous permettent de lire et d'écrire des carnets de données de chart (contenant des données de chart éditées avec Aspose.Cells). **Remarque** que les données de chart doivent être organisées de la même manière ou doivent avoir une structure similaire à la source.

Ce code Java démontre une opération exemple :

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la Cellule du Carnet comme Étiquette de Données du Chart**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un chart à bulles avec quelques données.
1. Accédez à la série de chart.
1. Définissez la cellule du carnet comme étiquette de données.
1. Enregistrez la présentation.

Ce code Java montre comment définir une cellule du carnet comme étiquette de données de chart :

```java
String lbl0 = "Valeur de la cellule d'étiquette 0";
String lbl1 = "Valeur de la cellule d'étiquette 1";
String lbl2 = "Valeur de la cellule d'étiquette 2";

// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer les Feuilles de Calcul**

Ce code Java démontre une opération où la méthode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) est utilisée pour accéder à une collection de feuilles de calcul :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spécifier le Type de Source de Données**

Ce code Java vous montre comment spécifier un type pour une source de données :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Carnet Externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides 19.4](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-19-4-release-notes/), nous avons mis en œuvre le support des carnets externes comme source de données pour les charts.
{{% /alert %}} 

### **Créer un Carnet Externe**

En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez soit créer un carnet externe à partir de zéro, soit rendre un carnet interne externe.

Ce code Java démontre le processus de création de carnet externe :

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Définir un Carnet Externe**

En utilisant la méthode **`setExternalWorkbook`**, vous pouvez assigner un carnet externe à un chart comme sa source de données. Cette méthode peut également être utilisée pour mettre à jour un chemin vers le carnet externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas éditer les données dans les carnets stockés dans des emplacements ou des ressources distants, vous pouvez toujours utiliser de tels carnets comme source de données externe. Si le chemin relatif d'un carnet externe est fourni, il est automatiquement converti en un chemin complet.

Ce code Java vous montre comment définir un carnet externe :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Le paramètre `ChartData` (sous la méthode `setExternalWorkbook`) est utilisé pour spécifier si un carnet Excel sera chargé ou non. 

* Lorsque la valeur `ChartData` est définie sur `false`, seul le chemin du carnet est mis à jour—les données du chart ne seront pas chargées ou mises à jour à partir du carnet cible. Vous pouvez vouloir utiliser ce réglage dans une situation où le carnet cible est inexistant ou indisponible. 
* Lorsque la valeur `ChartData` est définie sur `true`, les données du chart sont mises à jour à partir du carnet cible.

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtenir le Chemin du Carnet de Source de Données Externe du Chart**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Créez un objet pour la forme du chart.
1. Créez un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du chart.
1. Spécifiez la condition pertinente en fonction du type de source étant le même que le type de source de données du carnet externe.

Ce code Java démontre l'opération :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Enregistre la présentation
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Modifier les Données du Chart**

Vous pouvez modifier les données dans les carnets externes de la même manière que vous faites des changements aux contenus des carnets internes. Lorsqu'un carnet externe ne peut pas être chargé, une exception est levée.

Ce code Java est une mise en œuvre du processus décrit :

```java
// Crée une instance de tthe Presentation class
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```