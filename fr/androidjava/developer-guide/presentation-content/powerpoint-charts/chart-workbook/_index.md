---
title: Gérer les classeurs de graphiques dans les présentations sur Android
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/androidjava/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule du classeur
- étiquette de données
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
description: "Découvrez Aspose.Slides pour Android via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour simplifier les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire des données de graphique via des flux de classeur, utiliser les cellules du classeur comme étiquettes de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs de graphique.

Il couvre également le travail avec des classeurs externes comme sources de données de graphique. Les exemples montrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules de classeur qui représentent des données manquantes, voir [Contrôler l'affichage des cellules vides](/slides/fr/androidjava/chart-series/) pour la différence entre une cellule vide et zéro, ainsi qu’une comparaison de diagramme en lignes des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) pour contrôler si un graphique trace les données des lignes et colonnes de feuille masquées. Réglez‑le sur `true` pour tracer uniquement les cellules visibles, ou sur `false` pour inclure à la fois les cellules visibles et masquées. Ce paramètre contrôle le tracé du graphique ; il ne masque pas et ne rend pas visibles les lignes ou colonnes de la feuille.

La [présentation d'exemple](hidden-source-data.pptx) contient un graphique en colonnes comme première forme de sa première diapositive. La feuille de calcul intégrée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de feuille | A : Mois | B : Vente au détail | C : Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | janvier | 10 | 30 |
| 3 (ligne masquée) | février | 40 | 60 |
| 4 | mars | 20 | 50 |

Accédez aux cellules sources via [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) et lisez [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) pour examiner leur statut masqué. Cette méthode indique le statut masqué sans le modifier. Dans cet exemple, B2 est visible, B3 appartient à la ligne masquée et C2 appartient à la colonne masquée ; l’exemple affiche `false`, `true` et `true`, respectivement.

Pour cet exemple, actualisez les données du graphique après avoir modifié le paramètre de tracé : conservez le classeur intégré avec [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) et rechargez‑le avec [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Lors de l’inclusion de toutes les cellules, utilisez également [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) pour restaurer la plage complète, y compris la catégorie février masquée. Le simple changement du drapeau n’est pas suffisant pour actualiser les données de graphique en cache et les étiquettes de catégorie de cet exemple.

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

            // Actualiser les données du graphique à partir du classeur intégré.
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

L’exemple enregistre deux versions de la présentation : l’une avec uniquement les valeurs visibles de Vente au détail (10 et 20), et l’autre avec les six valeurs. Les images ci‑dessous illustrent les deux modes de tracé. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Cellules visibles uniquement (`true`) | Toutes les cellules (`false`) |
| --- | --- |
| ![Cellules visibles uniquement : valeurs de Vente au détail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs de Vente au détail et Vente en gros pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur est différente d’une cellule vide. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut ni n’exclut les données sources masquées. Voir [Contrôler l'affichage des cellules vides](/slides/fr/androidjava/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Récupérer la plage de données d'un graphique**

Avant de mettre à jour les données du classeur dans une présentation existante, inspectez les plages sources afin d’identifier quelles cellules de feuille chaque graphique utilise. La méthode [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) renvoie la plage de données actuelle sous forme de formule qualifiée par la feuille, par exemple `Sheet1!$A$1:$D$5`. Ici, `Sheet1` est le nom de la feuille, `!` la sépare de la plage de cellules, et `$A$1:$D$5` désigne les cellules A1 à D5, incluses. Les signes dollar indiquent des références absolues de ligne et de colonne.

La méthode lit la plage actuelle sans modifier le graphique ni son classeur. Si le graphique n’utilise pas de classeur comme source de données, elle lève `InvalidOperationException`. Pour plus d’informations, consultez la [Référence de l'API ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Cet exemple ouvre une présentation et vérifie les formes directement sur chaque diapositive pour y trouver des graphiques. Il affiche le nom de chaque graphique et sa plage source. Si un graphique n’utilise pas de classeur, il affiche un message et passe au graphique suivant.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lire et écrire des données de graphique depuis un classeur**

Aspose.Slides for Android via Java fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) et [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) qui permettent de lire et d’écrire les classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** le classeur de données doit être organisé de la même manière ou disposer d’une structure similaire à la source.

Cet exemple utilise une présentation contenant un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un tableau d’octets, supprime les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l’exemple n’enregistre pas la présentation.

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

### **Valider la mise en page du graphique après modification du classeur**

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’échec de [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) avec une erreur d’indice hors limites. Supprimez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple utilise un graphique qui est la première forme de la première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la mise en page en mémoire.

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

La suppression des collections élimine les références de données obsolètes avant que le classeur ne soit réécrit. Reconstruisez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir des formats numériques personnalisés pour les cellules du classeur**

Utilisez [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) pour contrôler la façon dont les valeurs numériques apparaissent dans le classeur intégré d’un graphique. Par exemple, un rapport peut nécessiter un taux de conversion affiché en pourcentage avec quatre décimales et un coefficient affiché avec cinq décimales. Conservez les deux valeurs sous forme numérique afin qu’elles restent disponibles pour les calculs et le tracé du graphique.

Un format numérique change l’affichage, pas la valeur stockée. Le format `0.0000%` affiche `0.125` sous forme `12.5000%` ; il ne remplace pas le nombre stocké par `12.5`. De même, `0.00000` affiche `0.1234567` sous forme `0.12346` sans arrondir la valeur stockée. Si le format personnalisé est une chaîne vide (`""`), le format renvoyé par [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) est utilisé à la place.

L’exemple suivant crée un graphique en colonnes et accède à ses cellules via [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Sur la feuille 0, B2 contient le taux de conversion et C2 le coefficient. Les deux cellules fournissent les valeurs du graphique. L’exemple active également les étiquettes de valeur liées aux formats sources.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les formats de cellule du classeur sont distincts des formats définis directement sur les axes du graphique ou les étiquettes de données. Dans cet exemple, chaque étiquette affiche la valeur de sa cellule source parce que [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) est à `true`, et suit le format numérique source parce que [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) est à `true`. Après avoir enregistré et rouvert la présentation, les étiquettes affichent `12.5000%` et `0.12346`, comme illustré ci‑dessous. L’axe vertical utilise son propre format numérique, assigné avec [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) à `0.00`, avec [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) à `false`.

Pour formater une étiquette de données indépendamment, désactivez son drapeau de liaison à la source (`false`) et assignez un format avec [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Cela ne change pas le format de la cellule du classeur. Par exemple, un format d’étiquette indépendant `0.00` affiche la première valeur sous forme `0.13`, tandis que B2 continue d’afficher `12.5000%`. Voir [Étiquettes de données du graphique](/slides/fr/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) pour le formatage direct des étiquettes.

L’image ci‑dessous a été rendue à partir de la présentation enregistrée après l’avoir rouverte :

![Graphique en colonnes avec des étiquettes liées à la source affichant 12.5000% et 0.12346 et un axe numérique formaté indépendamment.](custom-cell-formats.png)

## **Définir une cellule de classeur comme étiquette de données de graphique**

Vous pouvez utiliser le texte des cellules de classeur comme étiquettes de données de graphique.

Cet exemple ajoute un graphique à bulles avec des données par défaut à la première diapositive d’une présentation existante. Il utilise les cellules A10 :A12 sur la feuille 0 pour les trois premières étiquettes de la première série, active les étiquettes à partir des cellules et enregistre la présentation mise à jour.

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

La méthode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) fournit l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et affiche chaque nom de feuille dans la console.

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

Les valeurs de points de série peuvent également être stockées directement comme littéraux numériques. Voir [Set Series Values Using Numeric Literals](/slides/fr/androidjava/chart-series/#set-series-values-using-numeric-literals) pour un exemple complet qui les enregistre et les lit. Le type de source des valeurs de points est distinct de la configuration interne ou externe du classeur du graphique ; l’utilisation de littéraux numériques ne supprime pas, à elle seule, le classeur intégré.

Cet exemple crée un graphique en colonnes 3D avec des données par défaut et définit deux noms de série en utilisant différentes sources de données. Le premier nom utilise un littéral de chaîne ; le second utilise la cellule C1 sur la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) sélectionne la source pour chaque nom. L’exemple enregistre la présentation avec les noms de série mis à jour.

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

## **Détecter les formats de classeur intégré non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être intégré à certains graphiques. Vous pouvez utiliser la méthode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) sur [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) avec l’énumération [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple inspecte les formes de la première diapositive d’une présentation existante, ignore les formes qui ne sont pas des graphiques et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

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

        // Lire ou modifier les données du classeur de graphique prises en charge ici.
    }
} finally {
    presentation.dispose();
}
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) et [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) pour exporter le classeur de graphique intégré vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut et exporte son classeur. Il termine l’écriture du fichier avant d’affecter le classeur externe comme source de données du graphique, puis enregistre la présentation liée.

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

En utilisant la méthode [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également servir à mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données dans des classeurs stockés sur des emplacements distants ou des ressources, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif est fourni, il est automatiquement converti en chemin complet.

Cet exemple utilise un classeur externe dont la feuille nommée `Sheet1` contient un nom de série en B1, les noms de catégories en A2 :A4 et des valeurs numériques en B2 :B4. L’exemple crée un graphique circulaire, lie le classeur et utilise [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) pour mapper A1 :B4 à une série et trois catégories. Il enregistre la présentation avec le graphique lié.

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

Le paramètre `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) contrôle si le classeur est chargé.

* Lorsque `updateChartData` est `false`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour depuis le classeur cible, de sorte que le classeur peut être indisponible.
* Lorsque `updateChartData` est `true`, les données du graphique sont mises à jour depuis le classeur cible.

L’exemple suivant affecte une URL factice avec `updateChartData` réglé sur `false`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

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

Pour identifier le classeur lié à un graphique, vérifiez si le graphique utilise une source de données externe et récupérez son chemin de classeur.

Cet exemple inspecte la première forme de la première diapositive d’une présentation contenant un classeur externe lié. Si c’est un graphique lié à un classeur externe, l’exemple affiche [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) dans la console. Il enregistre ensuite une copie de la présentation.

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

Vous pouvez modifier les données dans les classeurs externes de la même façon que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple utilise un graphique qui est la première forme de la première diapositive et qui est lié à un classeur externe accessible. Il affecte la valeur basée sur la cellule du premier point de données de la première série à 100 et enregistre la présentation mise à jour. Modifier les valeurs des cellules peut mettre à jour le fichier XLSX externe lié, utilisez donc une copie si vous devez préserver le classeur original.

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

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez un [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), appelez [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), et réglez [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) sur `true` avant d’ouvrir la présentation.

L’exemple Java suivant récupère les données du classeur pour un graphique qui est la première forme de la première diapositive et qui référence un classeur externe indisponible. Il accède aux données récupérées via [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) et [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données de graphique mises en cache est une solution de secours acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que déplacer le classeur peut nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Modifier les données du graphique basées sur les cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à enlever la protection au préalable ou à préparer une copie déchiffrée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/java/)) et à lier cette copie.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.