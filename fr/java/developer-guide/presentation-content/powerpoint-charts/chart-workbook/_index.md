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
- libellé de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache du graphique
- récupération du classeur
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Aperçu**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire des données de graphique via des flux de classeur, utiliser les cellules du classeur comme libellés de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs de graphique.

Il couvre également l’utilisation de classeurs externes comme sources de données de graphique. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

## **Lire et écrire des données de graphique depuis un classeur**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IChartData#readWorkbookStream--) et [WriteWorkbookStream](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) qui permettent de lire et d’écrire des classeurs de données de graphique (contenant des données de graphique modifiées avec Aspose.Cells). **Note** que les données du graphique doivent être organisées de la même façon ou posséder une structure similaire à la source.

Ce code Java montre une opération d’exemple :

```java
import com.aspose.slides.*;

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

### **Valider la disposition du graphique après modification du classeur**

Lorsque vous remplacez un classeur incorporé par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’exception [IChart.validateChartLayout](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichart/#validateChartLayout--) qui lève une `ArgumentOutOfRangeException` (paramètre : index). Pour éviter l’exception, effacez les séries et catégories existantes **avant** d’écrire le classeur mis à jour dans le graphique.

```java
// Après avoir modifié le flux du classeur (par ex., avec Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Effacer les références de données existantes.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Vider les collections garantit que la structure des données du graphique correspond au nouveau classeur, permettant à `validateChartLayout` de s’exécuter sans erreur.

## **Définir une cellule de classeur comme libellé de données de graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive via son indice.
1. Ajoutez un graphique à bulles avec des données.
1. Accédez aux séries du graphique.
1. Définissez la cellule du classeur comme libellé de données.
1. Enregistrez la présentation.

Ce code Java montre comment définir une cellule de classeur comme libellé de données de graphique :

```java
import com.aspose.slides.*;

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

Ce code Java montre une opération où la méthode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) est utilisée pour accéder à une collection de feuilles de calcul :

```java
import com.aspose.slides.*;

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

Ce code Java montre comment spécifier un type pour une source de données :

```java
import com.aspose.slides.*;

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

## **Détecter les formats de classeur incorporé non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être incorporé dans certains graphiques. Vous pouvez utiliser la méthode `getEmbeddedWorkbookType` sur [IChartData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IChartData) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/WorkbookType) pour détecter les formats non pris en charge et ignorer ces graphiques.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Le classeur incorporé est au format .xlsb, qui n’est pas pris en charge.
            continue;
        }

        // Lire ou modifier les données du classeur de graphique ici.
    }
} finally {
    presentation.dispose();
}
```

## **Classeur externe**

{{% alert color="info" %}} 
Dans [Aspose.Slides 19.4](https://docs.aspose.com/slides/fr/java/aspose-slides-for-java-19-4-release-notes/), nous avons implémenté la prise en charge des classeurs externes comme source de données pour les graphiques.
{{% /alert %}} 

### **Créer un classeur externe**

En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez soit créer un classeur externe à partir de zéro, soit rendre un classeur interne externe.

Ce code Java démontre le processus de création d’un classeur externe :

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

### **Attribuer un classeur externe**

En utilisant la méthode **`setExternalWorkbook`**, vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données dans les classeurs stockés à distance ou dans des ressources, vous pouvez toujours les utiliser comme source de données externe. Si le chemin relatif d’un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code Java montre comment définir un classeur externe :

```java
import com.aspose.slides.*;

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

Le deuxième paramètre (`boolean`) de la méthode `setExternalWorkbook` sert à indiquer si le classeur Excel doit être chargé ou non.

* Lorsque sa valeur est `false`, seul le chemin du classeur est mis à jour — les données du graphique ne seront pas chargées ou mises à jour depuis le classeur cible. Ce réglage est utile lorsqu’il faut gérer un classeur cible inexistant ou indisponible. 
* Lorsque sa valeur est `true`, les données du graphique sont mises à jour depuis le classeur cible.

```java
import com.aspose.slides.*;

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

### **Obtenir le chemin du classeur source de données externe d’un graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Obtenez la référence d’une diapositive via son indice.
1. Créez un objet pour la forme du graphique.
1. Créez un objet pour le type de source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifiez la condition pertinente en fonction du type de source identique au type de source de données du classeur externe.

Ce code Java montre l’opération :

```java
import com.aspose.slides.*;

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

Vous pouvez modifier les données dans les classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Ce code Java implémente le processus décrit :

```java
import com.aspose.slides.*;

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

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez un [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/), configurez‑le avec [SpreadsheetOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/spreadsheetoptions/), puis appelez [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) avec `true` avant d’ouvrir la présentation.

L’exemple Java suivant ouvre une présentation dont le graphique référence un classeur externe indisponible et accède aux données récupérées via [IChart.getChartData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichart/#getChartData--) et [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) :

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lire ou modifier les données du classeur récupéré ici.
} finally {
    presentation.dispose();
}
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données du graphique mises en cache constitue une solution de secours acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou incorporé ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chartdata/#getDataSourceType--) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela facilite la portabilité du projet ; cependant, la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être qu’une source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) et l’utilise pour la lecture des données. Le fichier externe lui‑même n’est pas modifié lors de l’enregistrement de la présentation.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors du lien. La solution courante consiste à retirer la protection au préalable ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](/cells/java/)) et à créer le lien vers cette copie.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.