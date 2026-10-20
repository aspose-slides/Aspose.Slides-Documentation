---
title: Créer des graphiques Excel et les incorporer dans des présentations en tant qu'objets OLE
type: docs
weight: 30
url: /fr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graphique Excel
- intégrer le graphique
- objet OLE
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer un graphique Excel avec Aspose.Cells for PHP via Java et incorporer le classeur dans une présentation PowerPoint avec Aspose.Slides for PHP via Java, incluant un aperçu du graphique."
---
## **Vue d'ensemble**

Cet article montre comment créer un graphique à colonnes Excel avec Aspose.Cells for PHP via Java et incorporer son classeur dans une présentation PowerPoint avec Aspose.Slides for PHP via Java. Le classeur incorporé contient à la fois les données sources et le graphique. Un aperçu PNG distinct affiche le graphique sur la diapositive avant que l’objet OLE ne soit activé.

Le résultat est un objet Excel incorporé, pas un graphique PowerPoint natif. La modification du classeur via OLE nécessite une application de bureau qui prend en charge l’activation OLE et une installation Excel compatible.

## **Prérequis**

Configurez Aspose.Cells for PHP via Java et Aspose.Slides for PHP via Java avec la même instance PHP/Java Bridge. Chargez les deux wrappers PHP et rendez les bibliothèques Java des deux produits accessibles au pont. Microsoft Office n’est pas requis pour générer la présentation avec ces bibliothèques.

Aucun fichier d’entrée n’est nécessaire : l’exemple crée les données et le graphique en mémoire, puis écrit `OutputChart.pptx` dans le répertoire de travail actuel. Appliquez les licences pour les deux produits lorsque vous exécutez hors mode d’évaluation.

## **Comment fonctionne l'intégration**

1. Créez un classeur avec une feuille de données et une feuille de graphique.  
1. Activez la feuille de graphique afin que le classeur s’ouvre sur le graphique.  
1. Définissez la plage d’affichage OLE du classeur et rendez le graphique au format PNG.  
1. Enregistrez le classeur au format XLSX en mémoire et intégrez ces octets dans une diapositive.  
1. Assignez le PNG comme aperçu de l’objet OLE et enregistrez la présentation au format PPTX.

La plage d’affichage du classeur et le cadre sur la diapositive ont des rôles différents. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) prend les indices de ligne et de colonne de début/fin basés sur zéro. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) prend quant à lui la ligne supérieure, la colonne gauche, la ligne inférieure et la colonne droite. L’exemple utilise l’indice de ligne 55 et l’indice de colonne 25 comme limites en bas à droite ; ces valeurs sont des choix de mise en page, pas le nombre de lignes ou de colonnes de données.

Le cadre de la diapositive utilise des points. L’exemple l’ajuste à l’intérieur de la diapositive et le centre tout en conservant le ratio d’aspect du PNG, plutôt que d’étirer l’aperçu pour remplir la diapositive.

## **Créer et intégrer le graphique**

L’exemple complet suivant remplit `DataSheet` avec quatre lignes et cinq colonnes de valeurs. Chaque ligne devient une série du graphique. `ChartSheet` est sélectionnée comme feuille active avant l’enregistrement du classeur.

Le classeur est explicitement enregistré au format XLSX, correspondant à l’extension `xlsx` transmise à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Les résultats numériques Java sont convertis avec `java_values` avant que PHP n’effectue des opérations arithmétiques, tandis que les données binaires restent dans les tableaux d’octets Java. Le PNG est chargé directement à partir de ses octets sans conversion intermédiaire en bitmap. L’affectation via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) remplace le substitut OLE par défaut.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Conservez le PNG et le XLSX sous forme de tableaux d'octets Java lors du passage à Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Ajustez et centrez l'aperçu tout en conservant son ratio d'aspect.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Résultat attendu**

`OutputChart.pptx` contient une diapositive avec un classeur Excel incorporé et un aperçu du graphique. Le classeur contient les données d’origine et un graphique à colonnes avec quatre séries. L’aperçu est centré sur la diapositive et conserve ses proportions.

![Diagramme en colonnes Excel affiché comme aperçu d'un classeur intégré](excel-chart-ole-preview.png)

Dans un environnement PowerPoint de bureau compatible avec Excel disponible, double‑cliquez sur l’objet pour activer et modifier le classeur incorporé. L’activation et la modification dépendent de la prise en charge OLE de l’application hôte et de ses paramètres de sécurité.

## **FAQ**

**Pourquoi un aperçu image est‑il nécessaire ?**

Le classeur incorporé et son aperçu sur la diapositive sont du contenu séparé. Fournissez une image du graphique afin que la diapositive affiche le graphique au lieu de l’espace réservé « EMBEDDED OLE OBJECT ». Voir [Problème d’aperçu d’objet lors de l’ajout d’OleObjectFrame](/slides/fr/php-java/object-preview-issue-when-adding-oleobjectframe/).

**L’aperçu se met‑il à jour automatiquement lorsque je modifie le classeur dans le code ?**

Considérez l’aperçu comme une capture instantanée. Lors de la mise à jour des données du classeur par programme, régénérez l’image du graphique et remplacez l’aperçu ainsi que les données du classeur incorporé.

**Puis‑je utiliser XLS au lieu de XLSX ?**

Oui. Enregistrez le classeur au format XLS et utilisez `xls` comme extension de données incorporées. L’extension doit correspondre au format réel du classeur ; changer uniquement l’extension ne convertit pas les données.

**Pourquoi l’objet peut‑il changer de taille après activation ?**

L’application hôte peut mettre à jour la présentation de l’objet OLE lorsqu’elle active le classeur. La plage d’affichage OLE du classeur et les dimensions du cadre de la diapositive influencent toutes deux le résultat. Voir [Solution fonctionnelle pour le redimensionnement de graphique dans PPTX](/slides/fr/java/working-solution-for-chart-resizing-in-pptx/).

## **Sections connexes**

- [Solution fonctionnelle pour le redimensionnement de graphique dans PPTX](/slides/fr/java/working-solution-for-chart-resizing-in-pptx/)
- [Problème d’aperçu d’objet lors de l’ajout d’OleObjectFrame](/slides/fr/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Gérer les objets OLE](/slides/fr/php-java/manage-ole/)