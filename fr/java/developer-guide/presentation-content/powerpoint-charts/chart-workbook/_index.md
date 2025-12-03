---
title: Gérer les classeurs de graphiques dans les présentations avec Java
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/java/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- étiquette de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument afin d’optimiser les données de votre présentation."
---

## **Définir les données du graphique à partir du classeur**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) et [WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) qui vous permettent de lire et d'écrire des classeurs de données de graphiques (contenant des données de graphiques modifiées avec Aspose.Cells). **Remarque** les données du graphique doivent être organisées de la même manière ou disposer d'une structure similaire à la source.

Ce code Java démontre une opération d'exemple :
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


## **Définir la cellule du classeur comme étiquette de données du graphique**
1. Créer une instance de la classe [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. Obtenir la référence d'une diapositive via son index.
1. Ajouter un graphique à bulles avec certaines données.
1. Accéder aux séries du graphique.
1. Définir la cellule du classeur comme étiquette de données.
1. Enregistrer la présentation.

Ce code Java vous montre comment définir une cellule du classeur comme étiquette de données du graphique :
```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

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


## **Gérer les feuilles de calcul**
Ce code Java démontre une opération où la méthode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) est utilisée pour accéder à une collection de feuilles de calcul :
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


## **Spécifier le type de source de données**
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


## **Classeur externe**
{{% alert color="primary" %}} 
Dans [Aspose.Slides 19.4](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/), nous avons implémenté la prise en charge des classeurs externes comme source de données pour les graphiques.
{{% /alert %}} 

### **Créer un classeur externe**
En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez soit créer un classeur externe à partir de zéro, soit rendre un classeur interne externe.

Ce code Java démontre le processus de création d'un classeur externe :
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


### **Définir le classeur externe**
En utilisant la méthode **`setExternalWorkbook`**, vous pouvez assigner un classeur externe à un graphique comme source de données. Cette méthode peut aussi être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés dans des emplacements ou ressources distants, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif pour un classeur externe est fourni, il est automatiquement converti en un chemin complet.

Ce code Java vous montre comment définir un classeur externe :
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


Le paramètre `ChartData` (dans la méthode `setExternalWorkbook`) est utilisé pour spécifier si un classeur Excel doit être chargé ou non. 

* Lorsque la valeur de `ChartData` est définie sur `false`, seul le chemin du classeur est mis à jour — les données du graphique ne seront pas chargées ou mises à jour depuis le classeur cible. Vous pouvez utiliser ce paramètre lorsqu'il n'existe pas ou n'est pas disponible. 
* Lorsque la valeur de `ChartData` est définie sur `true`, les données du graphique sont mises à jour à partir du classeur cible.
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


### **Obtenir le chemin du classeur source de données externe du graphique**
1. Créer une instance de la classe [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. Obtenir la référence d'une diapositive via son index.
1. Créer un objet pour la forme du graphique.
1. Créer un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifier la condition pertinente en fonction du type de source étant identique au type de source de données du classeur externe.

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


### **Modifier les données du graphique**
Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levée.

Ce code Java est une implémentation du processus décrit :
```java
// Crée une instance de la classe Presentation
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


## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu'un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela est pratique pour la portabilité du projet ; toutefois, sachez que la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis‑je utiliser des classeurs situés sur des ressources/partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n'est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l'enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) et l'utilise pour lire les données. Le fichier externe lui‑même n'est pas modifié lors de l'enregistrement de la présentation.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n'accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie décryptée (par exemple, en utilisant [Aspose.Cells](/cells/java/)) et à la lier.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S'ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique la prochaine fois que les données seront chargées.