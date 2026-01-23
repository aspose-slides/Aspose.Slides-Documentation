---
title: Gérer les classeurs de graphiques dans les présentations avec PHP
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/php-java/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- étiquette de donnée
- feuille de calcul
- source de données
- classeur externe
- données externes
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez Aspose.Slides pour PHP via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument afin de rationaliser les données de votre présentation."
---

## **Lire et écrire des données de graphique à partir d'un classeur**
Aspose.Slides fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#readWorkbookStream) et [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#writeWorkbookStream) qui vous permettent de lire et d'écrire des classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Note** que les données du graphique doivent être organisées de la même manière ou doivent avoir une structure similaire à la source.

Ce code PHP démontre une opération d'exemple:
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


## **Définir une cellule de classeur comme étiquette de données de graphique**
1. Créer une instance de la classe [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenir une référence à une diapositive via son indice.
1. Ajouter un graphique à bulles avec des données.
1. Accéder aux séries du graphique.
1. Définir la cellule du classeur comme étiquette de données.
1. Enregistrer la présentation.

Ce code PHP vous montre comment définir une cellule de classeur comme étiquette de données de graphique:
```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
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
Ce code PHP démontre une opération où la méthode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getWorksheets) est utilisée pour accéder à une collection de feuilles de calcul:
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
Ce code PHP vous montre comment spécifier un type pour une source de données:
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
Aspose.Slides prend en charge les classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**
En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez créer un classeur externe à partir de zéro ou rendre un classeur interne externe.

Ce code PHP démontre le processus de création d'un classeur externe:
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
En utilisant la méthode **`setExternalWorkbook`**, vous pouvez associer un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin vers le classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés dans des emplacements ou des ressources distants, vous pouvez toujours utiliser ces classeurs comme source de données externe. Si le chemin relatif d'un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code PHP vous montre comment définir un classeur externe:
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


Le paramètre `ChartData` (dans la méthode `setExternalWorkbook`) est utilisé pour indiquer si un classeur Excel doit être chargé ou non. 

* Lorsque la valeur de `ChartData` est définie sur `false`, seul le chemin du classeur est mis à jour — les données du graphique ne seront pas chargées ou mises à jour à partir du classeur cible. Vous pouvez utiliser ce paramètre lorsqu'il s'agit d'un classeur cible inexistant ou indisponible. 
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


### **Obtenir le chemin du classeur source de données externe d'un graphique**
1. Créer une instance de la classe [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenir une référence à une diapositive via son indice.
1. Créer un objet pour la forme du graphique.
1. Créer un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifier la condition pertinente en fonction du fait que le type source soit le même que le type de source de données du classeur externe.

Ce code PHP démontre l'opération:
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
Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levée.

Ce code PHP est une implémentation du processus décrit:
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


## **FAQ**
**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu'un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont-ils pris en charge, et comment sont-ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela est pratique pour la portabilité du projet ; cependant, sachez que la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis-je utiliser des classeurs situés sur des ressources/partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n'est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase-t-il le XLSX externe lors de l'enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) et l'utilise pour la lecture des données. Le fichier externe lui‑même n'est pas modifié lors de l'enregistrement de la présentation.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n'accepte pas de mot de passe lors de la création du lien. Une approche courante consiste à retirer la protection au préalable ou à préparer une copie décryptée (par exemple en utilisant [Aspose.Cells](/cells/php-java/)) et à créer le lien vers cette copie.

**Plusieurs graphiques peuvent-ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S'ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.