---
title: Classeur de graphiques
type: docs
weight: 70
url: /php-java/chart-workbook/
keywords: "Classeur de graphiques, données de graphiques, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Classeur de graphiques dans une présentation PowerPoint"
---

## **Définir les données du graphique à partir du classeur**
Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) et [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-) qui vous permettent de lire et d'écrire des classeurs de données de graphiques (contenant des données de graphiques modifiées avec Aspose.Cells). **Remarque** : les données de graphique doivent être organisées de la même manière ou doivent avoir une structure similaire à celle de la source.

Ce code PHP démontre une opération d'exemple :

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir une cellule de classeur comme étiquette de données du graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique à bulles avec des données.
1. Accédez aux séries de graphiques.
1. Définissez la cellule de classeur comme une étiquette de données.
1. Enregistrez la présentation.

Ce code PHP vous montre comment définir une cellule de classeur comme une étiquette de données du graphique :

```php
  $lbl0 = "Valeur de la cellule Label 0";
  $lbl1 = "Valeur de la cellule Label 1";
  $lbl2 = "Valeur de la cellule Label 2";
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gérer les feuilles de calcul**

Ce code PHP démontre une opération où la méthode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) est utilisée pour accéder à une collection de feuilles de calcul :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Spécifier le type de source de données**

Ce code PHP vous montre comment spécifier un type pour une source de données :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Classeur externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/), nous avons implémenté la prise en charge des classeurs externes comme source de données pour les graphiques.
{{% /alert %}} 

### **Créer un classeur externe**

En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez soit créer un classeur externe à partir de zéro, soit rendre un classeur interne externe.

Ce code PHP démontre le processus de création de classeur externe :

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Définir un classeur externe**

En utilisant la méthode **`setExternalWorkbook`**, vous pouvez attribuer un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin vers le classeur externe (si celui-ci a été déplacé).

Bien que vous ne puissiez pas modifier les données dans les classeurs stockés dans des emplacements ou ressources distants, vous pouvez toujours utiliser ces classeurs comme source de données externe. Si le chemin relatif pour un classeur externe est fourni, il sera automatiquement converti en chemin complet.

Ce code PHP vous montre comment définir un classeur externe :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Le paramètre `ChartData` (sous la méthode `setExternalWorkbook`) est utilisé pour spécifier si un classeur Excel sera chargé ou non. 

* Lorsque la valeur de `ChartData` est définie sur `false`, seul le chemin du classeur est mis à jour : les données du graphique ne seront ni chargées ni mises à jour à partir du classeur cible. Vous pourriez vouloir utiliser ce paramètre lorsqu'une situation où le classeur cible est inexistant ou indisponible se présente. 
* Lorsque la valeur de `ChartData` est définie sur `true`, les données du graphique sont mises à jour à partir du classeur cible.

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Obtenir le chemin de la source de données externe du graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Créez un objet pour la forme du graphique.
1. Créez un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifiez la condition pertinente en fonction du type de source étant le même que le type source de données du classeur externe.

Ce code PHP démontre l'opération :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Enregistre la présentation
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Modifier les données du graphique**

Vous pouvez modifier les données dans des classeurs externes de la même façon que vous apportez des modifications aux contenus des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est lancée.

Ce code PHP est une implémentation du processus décrit :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```