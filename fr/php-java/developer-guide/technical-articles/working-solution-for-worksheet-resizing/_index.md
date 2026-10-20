---
title: Solution fonctionnelle pour le redimensionnement des feuilles de calcul
type: docs
weight: 20
url: /fr/php-java/working-solution-for-worksheet-resizing/
aliases:
  - /fr/php-java/solution-fonctionnelle-pour-le-redimensionnement-de-feuille-de-calcul/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Corrige le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux méthodes pour garder les cadres d'objets cohérents—redimensionner le cadre ou la feuille—dans les formats PPT et PPTX."
---
{{% alert color="info" title="Note" %}}

Les feuilles de calcul Excel incorporées en tant qu'objets OLE dans une présentation PowerPoint à l'aide des composants Aspose peuvent changer de taille de manière inattendue après leur première activation. Ce comportement crée une différence visuelle notable entre l'objet OLE avant et après l'activation. Cet article explique le problème et décrit deux solutions pour y remédier.

{{% /alert %}}

## **Contexte**

Dans l'article [Gestion OLE](/slides/fr/php-java/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint à l'aide d'Aspose.Slides for PHP via Java. Pour résoudre le [probleme d'aperçu d'objet](/slides/fr/php-java/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté une image de la zone de feuille de calcul sélectionnée au cadre de l'objet OLE. Dans la présentation générée, lorsque vous double-cliquez sur le cadre de l'objet OLE affichant l'image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs peuvent apporter toutes les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre de l'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre de l'objet OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille originale lors de la première activation. En revanche, le cadre de l'objet OLE a ses propres dimensions. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir le maintien des proportions correctes dans le cadre du processus d'intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et celle du cadre de l'objet OLE ainsi que de sa position.

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l'effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint pour qu'il corresponde à la hauteur et à la largeur totales des lignes et colonnes sélectionnées.
- Conserver la taille du cadre OLE constante et redimensionner les lignes et colonnes sélectionnées pour qu'elles s'adaptent à l'intérieur.

### **Redimensionner la taille du cadre OLE**

Cette approche définit la taille du cadre OLE afin qu'elle corresponde à la hauteur et à la largeur totales des lignes et colonnes sélectionnées dans la feuille de calcul Excel incorporée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices basés sur zéro. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) définit la plage affichée. L'aperçu est rendu à 96 DPI, et ses dimensions en pixels sont converties en points en utilisant 72 points par pouce. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) intègre le classeur modifié dans un cadre avec ces dimensions. L'aperçu est assigné via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) pour remplacer l'espace reserve "EMBEDDED OLE OBJECT" dans la présentation enregistrée.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Intégrez le classeur modifié et conservez les données binaires dans des tableaux d'octets Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

L'assistant d'aperçu définit [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) sur la plage sélectionnée et supprime les marges, en-têtes et pieds de page. Avec [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) active, [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) rend la plage sous forme d'image PNG. L'assistant renvoie un nouveau flux d'entree contenant l'image PNG, positionne au debut pour etre utilise dans la presentation.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Redimensionner la taille de la plage de cellules**

Cette approche redimensionne les hauteurs des lignes sélectionnées et les largeurs des colonnes sélectionnées pour correspondre à une taille de cadre OLE personnalisee.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices basés sur zéro. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) définit la plage affichée, et l'assistant ci-dessous redimensionne cette plage pour l'adapter à un cadre de 400 points de largeur et 100 points de hauteur. Après avoir enregistré le classeur modifié dans un flux, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) l'intègre à la taille spécifiée. Un aperçu rendu à 96 DPI est assigné via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de sorte que la présentation enregistrée affiche les cellules sélectionnées au lieu de l'espace reserve par défaut.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Intégrez le classeur modifié et conservez les données binaires dans des tableaux d'octets Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

L'assistant de mise a l'echelle calcule des rapports de largeur et de hauteur separates pour la plage selectionnee, en preservant les largeurs relatives de ses colonnes et les hauteurs relatives de ses lignes. Il convertit les dimensions calculees de points en pouces avant de les appliquer avec [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) et [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). La plage selectionnee doit avoir une largeur et une hauteur differentes de zero.

```php
use aspose\cells\CellsUnitType;

// La largeur et la hauteur sont les dimensions attendues de la plage de cellules en points.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

L'assistant d'aperçu rend la plage redimensionnee en utilisant [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Il limite [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) a cette plage, supprime les marges, en-tetes et pieds de page, et renvoie un flux PNG positionne au debut.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Conclusion**

{{% alert color="info" title="Note" %}}

Il existe deux approches pour corriger le problème de redimensionnement de la feuille de calcul. Choisissez l'approche qui correspond le mieux à vos exigences et à votre cas d'utilisation. Les deux approches fonctionnent de la même maniere, que les presentations soient creees a partir d'un modele ou a partir de zero. De plus, il n'y a aucune limite a la taille du cadre de l'objet OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel incorporee change-t-elle de taille lors de sa premiere activation dans PowerPoint?**

Cela se produit parce qu'Excel tente de conserver la taille originale de sa fenetre lorsqu'elle est activee, tandis que le cadre de l'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel negocient la taille afin de conserver le rapport d'aspect, ce qui peut entraîner le redimensionnement.

**Est-il possible d'eviter completement ce probleme de redimensionnement?**

Oui. En redimensionnant le cadre OLE pour qu'il corresponde à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour qu'elle corresponde à la taille souhaitee du cadre OLE, vous pouvez eviter le redimensionnement indesirable.

**Quelle methode de mise a l'echelle dois-je utiliser, le redimensionnement du cadre OLE ou le redimensionnement de la plage de cellules?**

Select **OLE frame scaling** si vous souhaitez conserver les tailles originales des lignes et colonnes Excel. Select **cell range scaling** si vous desirez une taille fixe pour le cadre OLE dans votre presentation.

**Ces solutions fonctionneront-elles si ma presentation est basee sur un modele?**

Oui. Les deux solutions fonctionnent pour les presentations creees a partir de modeles et a partir de zero.

**Existe-t-il une limite a la taille du cadre OLE lors de l'utilisation de ces methodes?**

Non. Vous pouvez donner au cadre de l'objet OLE n'importe quelle taille tant que vous definissez correctement l'echelle.

**Existe-t-il un moyen d'eviter le texte d'espace reserve "EMBEDDED OLE OBJECT" dans PowerPoint?**

Oui. En capturant une image de la plage de cellules Excel cible et en la definissant comme image d'espace reserve du cadre OLE, vous pouvez afficher une image d'aperçu personnalisee a la place de l'espace reserve par defaut.

## **Articles associés**

[Creer un graphique Excel et l'integrer dans une presentation en tant qu'objet OLE](/slides/fr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre a jour les objets OLE automatiquement a l'aide d'un add-in MS PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)