---
title: "Gérer les classeurs de graphiques dans les présentations sur Android"
linktitle: "Classeur de graphique"
type: docs
weight: 70
url: /fr/androidjava/chart-workbook/
keywords:
- "classeur de graphique"
- "données de graphique"
- "cellule de classeur"
- "étiquette de donnée"
- "feuille de calcul"
- "source de données"
- "classeur externe"
- "données externes"
- "PowerPoint"
- "présentation"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Découvrez Aspose.Slides pour Android via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument afin d’optimiser les données de votre présentation."
---

## **Lire et ecrire les donnees de graphique a partir d'un classeur**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) et [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) qui permettent de lire et d'ecrire des classeurs de donnees de graphique (contenant des donnees de graphique modifiees avec Aspose.Cells). **Note** que les donnees du graphique doivent etre organisees de la meme maniere ou avoir une structure similaire a la source.

Ce code Java illustre une operation d'exemple :
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


## **Definir une cellule de classeur comme libelle de donnees de graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d'une diapositive à l'aide de son indice.
1. Ajoutez un graphique à bulles avec certaines données.
1. Accédez aux séries du graphique.
1. Définissez la cellule du classeur comme libellé de données.
1. Enregistrez la présentation.

Ce code Java montre comment définir une cellule de classeur comme libellé de données de graphique :
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


## **Gerer les feuilles de calcul**

Ce code Java montre une operation onde la méthode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) est utilisee pour acceder à une collection de feuilles de calcul :
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


## **Specifier le type de source de donnees**

Ce code Java montre comment specifier un type pour une source de donnees :
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

Aspose.Slides prend en charge les classeurs externes comme source de donnees pour les graphiques.

### **Creer un classeur externe**

En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez soit creer un classeur externe a partir de zero, soit rendre un classeur interne externe.

Ce code Java montre le processus de creation d'un classeur externe :
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


### **Definir un classeur externe**

En utilisant la methode **`setExternalWorkbook`**, vous pouvez attribuer un classeur externe a un graphique comme source de donnees. Cette methode peut egalement etre utilisee pour mettre a jour le chemin vers le classeur externe (si ce dernier a ete deplace).

Bien que vous ne puissiez pas modifier les donnees des classeurs stockes dans des emplacements ou des ressources distants, vous pouvez toujours utiliser ces classeurs comme source de donnees externe. Si le chemin relatif d'un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code Java montre comment definir un classeur externe :
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


Le parametre `ChartData` (dans la methode `setExternalWorkbook`) est utilise pour specifier si un classeur Excel sera charge ou non. 

* Lorsque la valeur de `ChartData` est définie sur `false`, seul le chemin du classeur est mis à jour — les données du graphique ne seront pas chargées ou mises à jour depuis le classeur cible. Vous pouvez utiliser ce réglage lorsqu'il n'existe pas ou n'est pas disponible. 
* Lorsque la valeur de `ChartData` est définie sur `true`, les données du graphique sont mises à jour depuis le classeur cible.
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


### **Obtenir le chemin du classeur source de donnees externe d'un graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d'une diapositive à l'aide de son indice.
1. Créez un objet pour la forme du graphique.
1. Créez un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Specifiez la condition pertinente en fonction du fait que le type de source soit le même que le type de source de données du classeur externe.

Ce code Java montre l'opération :
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


### **Modifier les donnees du graphique**

Vous pouvez modifier les donnees des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levee.

Ce code Java est une implementation du processus décrit :
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

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu'un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont-ils pris en charge, et comment sont-ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela est pratique pour la portabilité du projet ; cependant, soyez conscient que la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis-je utiliser des classeurs situés sur des ressources/partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification des classeurs distants directement depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase-t-il le fichier XLSX externe lors de l'enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) et l'utilise pour la lecture des données. Le fichier externe lui‑même n’est pas modifié lorsque la présentation est enregistrée.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à enlever la protection à l'avance ou à préparer une copie déchiffrée (par exemple en utilisant [Aspose.Cells](/cells/androidjava/)) et à créer un lien vers cette copie.

**Plusieurs graphiques peuvent-ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier se reflétera dans chaque graphique la prochaine fois que les données seront chargées.