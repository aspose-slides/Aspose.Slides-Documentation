---
title: Gérer les classeurs de graphiques dans les présentations sur Android
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/androidjava/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- libellé de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache de graphique
- récupération de classeur
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Android via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Aperçu**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données de graphique via les flux de classeur, utiliser les cellules du classeur comme libellés de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également le travail avec des classeurs externes comme sources de données de graphique. Les exemples montrent comment créer et affecter un classeur externe, récupérer le chemin d'un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules du classeur qui représentent des données manquantes, consultez [Contrôler l'affichage des cellules vides](/slides/fr/androidjava/chart-series/) pour connaître la différence entre une cellule vide et zéro, ainsi qu'une comparaison en graphique linéaire des modes d'affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) pour contrôler si un graphique trace les données provenant des lignes et colonnes de feuille de calcul masquées. Réglez-le sur `true` pour tracer uniquement les cellules visibles, ou `false` pour inclure les cellules visibles et masquées. Ce paramètre contrôle le traçage du graphique ; il ne masque ni n'affiche les lignes ou colonnes de la feuille de calcul.

Téléchargez [hidden-source-data.pptx](hidden-source-data.pptx) et placez‑le dans le répertoire de travail. Sa première diapositive contient un graphique à barres en tant que première forme. La feuille de calcul incorporée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de feuille | A : Mois | B : Vente au détail | C : Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | Janvier | 10 | 30 |
| 3 (ligne masquée) | Février | 40 | 60 |
| 4 | Mars | 20 | 50 |

Accédez aux cellules sources via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) et lisez [IChartDataCell.isHidden](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) pour inspecter leur statut masqué. Cette méthode rapporte le statut masqué sans le modifier. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée et C2 à la colonne masquée ; l'exemple affiche `false`, `true` et `true` respectivement.

Pour cet exemple, rafraîchissez les données du graphique après avoir modifié le paramètre de traçage : conservez le classeur incorporé avec [readWorkbookStream](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) et rechargez‑le avec [writeWorkbookStream](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Lors de l'inclusion de toutes les cellules, utilisez également [setRange](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) pour restaurer la plage complète, y compris la catégorie février masquée. Modifier simplement le drapeau n’est pas suffisant pour rafraîchir les données en cache du graphique et les libellés de catégorie de cet exemple.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Rafraîchir les données du graphique à partir du classeur incorporé.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Restaurer la plage source complète, y compris les catégories masquées.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

L'exemple enregistre `hidden_cells_true.pptx` avec uniquement les valeurs de vente au détail visibles (10 et 20), et `hidden_cells_false.pptx` avec les six valeurs. Les images ci‑dessous illustrent les deux modes de traçage. La ligne 3 et la colonne C restent masquées dans les deux classeurs incorporés.

| Seulement les cellules visibles (`true`) | Toutes les cellules (`false`) |
| --- | --- |
| ![Seulement les cellules visibles : valeurs de vente au détail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs de vente au détail et en gros pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur diffère d'une cellule vide. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) contrôle la façon dont les valeurs manquantes sont affichées ; elle n'inclut ni n'exclut les données sources masquées. Voir [Contrôler l'affichage des cellules vides](/slides/fr/androidjava/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Lire et écrire des données de graphique depuis un classeur**

Aspose.Slides for Android via Java fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) et [writeWorkbookStream](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) qui vous permettent de lire et d'écrire des classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** les données du graphique doivent être organisées de la même manière ou posséder une structure similaire à la source.

Cet exemple ouvre `chart.pptx`, qui doit contenir un graphique comme première forme de sa première diapositive. Il lit le classeur incorporé dans un tableau d'octets, efface les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l'exemple ne sauvegarde pas la présentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Valider la disposition du graphique après modification du classeur**

Lorsque vous remplacez un classeur incorporé par un classeur modifié, le graphique conserve ses collections de séries et de catégories d'origine. Cette discordance peut entraîner l'échec de [IChart.validateChartLayout](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/#validateChartLayout--) avec une erreur d'index hors limites. Effacez les séries et catégories existantes avant d'écrire le classeur mis à jour dans le graphique. Cet exemple nécessite `chart.pptx` avec un graphique comme première forme de sa première diapositive. Le commentaire indique où l'édition du classeur aurait lieu ; l'exemple exécutable réécrit le classeur original et valide la disposition en mémoire.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Modifier les octets du classeur ici, par exemple en utilisant Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Effacer les collections supprime les références de données obsolètes avant que le classeur ne soit réécrit. Reconstruisez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d'utiliser le graphique.

## **Définir une cellule de classeur comme libellé de données de graphique**

Vous pouvez utiliser le texte des cellules du classeur comme libellés de données de graphique. Les étapes suivantes montrent comment lier les libellés d'un graphique à bulles aux cellules de son classeur de données.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) .
2. Accédez à la première diapositive par son indice zéro.
3. Ajoutez un graphique à bulles avec des données par défaut.
4. Accédez aux séries du graphique.
5. Définissez la cellule du classeur comme libellé de données.
6. Enregistrez la présentation.

Cet exemple ouvre `chart2.pptx`, qui doit contenir au moins une diapositive, et ajoute un graphique à bulles avec des données par défaut. Il utilise les cellules A10:A12 de la feuille 0 pour les trois premiers libellés de la première série, active les libellés provenant des cellules et enregistre le résultat dans `resultchart.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gérer les feuilles de calcul**

La méthode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) fournit l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et affiche chaque nom de feuille de calcul dans la console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Spécifier le type de source de données**

Cet exemple crée un graphique à colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant des sources de données différentes. Le premier nom utilise un littéral de chaîne ; le second utilise la cellule C1 de la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/datasourcetype/) sélectionne la source pour chaque nom. Le résultat est enregistré dans `pres.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Détecter les formats de classeur incorporé non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être incorporé dans certains graphiques. Vous pouvez utiliser la méthode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) sur [IChartData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple inspecte les formes de la première diapositive de `sample.pptx`, ignore les formes qui ne sont pas des graphiques et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb incorporé.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Lire ou modifier les données de classeur de graphique prises en charge ici.
    }
} finally {
    presentation.dispose();
}
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [readWorkbookStream](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) et [setExternalWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) pour exporter un classeur de graphique incorporé vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut, écrit son classeur dans `externalWorkbook1.xlsx` et termine l’écriture du fichier avant d’affecter le fichier comme source de données du graphique. Il enregistre la présentation liée dans `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Définir un classeur externe**

En utilisant la méthode [setExternalWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également servir à mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données de classeurs stockés sur des emplacements ou ressources distants, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif pour un classeur externe est fourni, il est automatiquement converti en chemin absolu.

Cet exemple requiert `externalWorkbook.xlsx` dans le répertoire de travail. Sa feuille nommée `Sheet1` doit contenir un nom de série en B1, les noms de catégorie dans A2:A4 et des valeurs numériques dans B2:B4. L’exemple crée un graphique circulaire, lie le classeur, et utilise [setRange](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) pour mapper A1:B4 à une série et trois catégories. Il enregistre le résultat dans `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le paramètre `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) contrôle si le classeur est chargé.

* Lorsque `updateChartData` est `false`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour à partir du classeur cible, de sorte que le classeur peut être indisponible.  
* Lorsque `updateChartData` est `true`, les données du graphique sont mises à jour à partir du classeur cible.

L’exemple suivant assigne une URL fictive avec `updateChartData` réglé sur `false`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obtenir le chemin du classeur source de données externe d'un graphique**

Pour identifier le classeur lié à un graphique, vérifiez d’abord si le graphique utilise une source de données externe. Si c’est le cas, vous pouvez récupérer le chemin du classeur en suivant ces étapes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) .
2. Accédez à la première diapositive par son indice zéro.
3. Vérifiez que la première forme est un graphique.
4. Lisez le type de source de données du graphique.
5. Si la source est un classeur externe, lisez son chemin.

Cet exemple ouvre `externalWorkbook.pptx`, créé dans l’exemple précédent, et inspecte la première forme de la première diapositive. S’il s’agit d’un graphique lié à un classeur externe, l’exemple affiche [getExternalWorkbookPath](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) dans la console. Il enregistre ensuite une copie de la présentation dans `Result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même façon que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple requiert `presentation.pptx` avec un graphique comme première forme de sa première diapositive et un classeur externe accessible. Il définit la valeur de la première donnée du premier point de la première série à 100 et enregistre la présentation dans `presentation_out.pptx`. Modifier les valeurs des cellules peut mettre à jour le fichier XLSX externe lié, utilisez donc une copie si vous devez préserver le classeur d’origine.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Récupérer un classeur depuis le cache du graphique**

Si un graphique utilise un classeur externe qui manque ou est indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/), appelez [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), et définissez [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) sur `true` avant d’ouvrir la présentation.

L’exemple Java suivant ouvre `presentation.pptx`, dont la première forme de la première diapositive doit être un graphique faisant référence à un classeur externe indisponible, et accède aux données récupérées via [IChart.getChartData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/#getChartData--) et [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Lire ou modifier les données du classeur récupéré ici.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données de graphique mises en cache constitue une solution de secours acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou incorporé ?**

Oui. Un graphique possède un [data source type](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) et un [path to an external workbook](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que déplacer le classeur peut nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources/partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [link to the external file](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). La modification des données de graphique provenant de cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à enlever la protection à l’avance ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/java/)) et à lier cette copie.

**Plusieurs graphiques peuvent-ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique la prochaine fois que les données seront chargées.