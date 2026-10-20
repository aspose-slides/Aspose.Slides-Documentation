---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 40
url: /fr/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer graphique
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans PPTX lors de l’utilisation d’objets OLE Excel intégrés avec Aspose.Slides for PHP via Java. Définissez des dimensions fixes du graphique pour garder la taille du graphique et du cadre OLE cohérentes."
---
## **Vue d'ensemble**

Les graphiques Excel intégrés en tant qu’objets OLE dans des présentations PowerPoint à l’aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut entraîner une différence visible dans l’apparence du graphique avant et après l’activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l’éviter en faisant correspondre les dimensions fixes du graphique au cadre OLE.

Dans [Créer des graphiques Excel et les intégrer en tant qu’objets OLE dans les présentations](/slides/fr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for PHP via Java et l’intégrer dans une présentation PowerPoint à l’aide d’Aspose.Slides for PHP via Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/php-java/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté l’image du graphique au cadre de l’objet OLE du graphique. Dans la présentation générée, lorsque vous double-cliquez sur le cadre OLE affichant l’image du graphique, le graphique Excel est activé. Les utilisateurs peuvent modifier le classeur Excel intégré, puis revenir à la diapositive en cliquant en dehors du classeur activé. La taille du cadre OLE change lorsque l’utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d’origine du cadre OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Le classeur Excel intégré possède ses propres dimensions de fenêtre, que Excel tente de conserver lors de la première activation de l’objet. Le cadre OLE sur la diapositive a des dimensions définies indépendamment. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l’objet afin de maintenir ses proportions dans le cadre du processus d’intégration. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc provoquer le redimensionnement de l’objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE de la diapositive et maintenez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une nouvelle présentation ou un modèle existant.

L’exemple nécessite Aspose.Cells for PHP via Java et Aspose.Slides for PHP via Java. Configurez les deux produits avec la même instance PHP/Java Bridge, chargez les deux wrappers PHP et rendez les deux bibliothèques Java disponibles pour le bridge. Aucun fichier d’entrée n’est requis. Il crée un simple graphique en colonnes sur une feuille de graphique active et intègre le classeur au format XLS. Aucune image d’aperçu du graphique n’est affectée ; le graphique devient visible lorsque l’objet OLE est activé dans PowerPoint.

L’exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces positionné à 0,5 pouce du bord gauche et à 1 pouce du haut. Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce). Pour une présentation existante, voir [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) sur false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions de [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) via [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) et [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), en convertissant les points en pixels avec 96 pixels par pouce : un cadre mesurant 684 × 288 points correspond à un graphique de 912 × 384 pixels. Définissez [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) sur la valeur CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). L’exemple intègre le classeur avec [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

Les résultats numériques Java sont convertis avec `java_values` avant d’être utilisés comme indices PHP. Les octets du classeur restent dans un tableau d’octets Java lorsqu’ils sont transmis à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce).
        $width = 684; // 9,5 pouces.
        $height = 288; // 4 pouces.

        $chart->setSizeWithWindow(false);
        // Convertir les points en pixels du graphique en utilisant 96 pixels par pouce.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Utiliser un modèle**

La logique de dimensionnement est la même pour une présentation existante. Pour adapter l’exemple :

1. Chargez la présentation modèle au lieu de créer une présentation vide.  
2. Vérifiez que la première diapositive contient au moins trois formes, puis utilisez la forme à l’index 2 comme espace réservé.  
3. Prenez la largeur et la hauteur du cadre à partir de cette forme au lieu d’utiliser les valeurs fixes 684 et 288. Conservez les calculs de dimensionnement inchangés.  
4. Ajoutez le cadre OLE à la position de l’espace réservé au lieu des coordonnées fixes 36 et 72.  
5. Supprimez l’espace réservé avant d’enregistrer la présentation.

## **FAQ**

**Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**  
Cela se produit parce qu’Excel tente de restaurer la taille de fenêtre d’origine lors de la première activation, alors que le cadre OLE de PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille pour conserver le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Comment garder les tailles du graphique et du cadre OLE cohérentes ?**  
Définissez des dimensions de graphique fixes qui correspondent au cadre OLE et utilisez une taille d’impression personnalisée du graphique avant d’intégrer le classeur. L’exemple ci‑dessus montre les paramètres requis et les conversions d’unités.

**Le fait d’aligner la taille de la fenêtre du classeur suffit‑il ?**  
Aligner uniquement la taille de la fenêtre du classeur ne garantit pas que le cadre OLE ne change pas de taille après l’activation. Utilisez des dimensions de graphique fixes comme indiqué dans l’exemple.

**Cette solution fonctionne‑t‑elle avec les présentations basées sur un modèle et les nouvelles présentations ?**  
Oui. Pour un modèle, utilisez les dimensions et la position de l’espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d’autres programmes de tableur ?**  
L’exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne montre pas le comportement d’activation pour d’autres programmes de tableur.

## **Sections connexes**

- [Créer des graphiques Excel et les intégrer en tant qu’objets OLE dans les présentations](/slides/fr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)