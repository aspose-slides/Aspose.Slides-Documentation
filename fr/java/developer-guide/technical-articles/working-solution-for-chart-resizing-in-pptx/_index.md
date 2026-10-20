---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 40
url: /fr/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement du graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans PPTX lors de l'utilisation d'objets OLE Excel intégrés avec Aspose.Slides for Java. Définissez des dimensions fixes pour le graphique afin de maintenir la cohérence des tailles du graphique et du cadre OLE."
---
## **Contexte**

Les graphiques Excel intégrés en tant qu'objets OLE dans les présentations PowerPoint à l'aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut entraîner une différence notable dans l'apparence du graphique avant et après l'activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l'éviter en faisant correspondre les dimensions fixes du graphique au cadre OLE.

In [Créer des graphiques Excel et les intégrer en tant qu'objets OLE dans les présentations](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Java and embed it in a PowerPoint presentation using Aspose.Slides for Java. To address the [problème d'aperçu d'objet](/slides/fr/java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Cause du redimensionnement**

Le classeur Excel intégré possède ses propres dimensions de fenêtre, que Excel tente de conserver lorsque l'objet est activé pour la première fois. Le cadre OLE sur la diapositive a des dimensions définies de manière indépendante. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l'objet afin de maintenir ses proportions dans le cadre du processus d'intégration. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc provoquer le redimensionnement de l'objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE sur la diapositive et gardez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une nouvelle présentation ou un modèle existant.

L'exemple nécessite Aspose.Cells for Java et Aspose.Slides for Java. Il crée un simple graphique en colonnes sur une feuille de graphique active et intègre le classeur au format XLS. Aucune image d'aperçu du graphique n'est assignée ; le graphique devient visible lorsque l'objet OLE est activé dans PowerPoint.

L'exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces positionné à 0,5 pouce du bord gauche et à 1 pouce du haut. Les coordonnées et dimensions des diapositives sont exprimées en points (72 points par pouce). Pour une présentation existante, voir [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) sur false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions de [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) via [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) et [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), en convertissant les points en pixels à l'aide de 96 pixels par pouce : un cadre mesurant 684 × 288 points correspond à un graphique mesurant 912 × 384 pixels. Définissez [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) sur la valeur CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). L'exemple intègre le classeur avec [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce).
        float width = 684f; // 9,5 pouces.
        float height = 288f; // 4 pouces.

        chart.setSizeWithWindow(false);
        // Convertir les points en pixels du graphique en utilisant 96 pixels par pouce.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Utiliser un modèle**

La logique de dimensionnement est la même pour une présentation existante. Pour adapter l'exemple :
1. Chargez la présentation modèle au lieu de créer une présentation vide.
1. Vérifiez que la première diapositive contient au moins trois formes, puis utilisez la forme à l'index 2 comme espace réservé.
1. Prenez la largeur et la hauteur du cadre à partir de cette forme au lieu d'utiliser les valeurs fixes 684 et 288. Conservez les calculs de dimensionnement inchangés.
1. Ajoutez le cadre OLE à la position de l'espace réservé au lieu des coordonnées fixes 36 et 72.
1. Supprimez l'espace réservé avant d'enregistrer la présentation.

## **FAQ**

**Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**  
Cela se produit parce qu'Excel tente de restaurer la taille originale de la fenêtre lors de la première activation, tandis que le cadre d'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de maintenir le rapport d'aspect, ce qui peut entraîner le redimensionnement.

**Comment puis‑je maintenir la cohérence des tailles du graphique et du cadre OLE ?**  
Définissez des dimensions fixes pour le graphique qui correspondent au cadre OLE et utilisez une taille d'impression personnalisée du graphique avant d'intégrer le classeur. L'exemple ci‑dessus montre les paramètres requis et les conversions d'unités.

**Le fait d'aligner la taille de la fenêtre du classeur suffit‑il ?**  
Aligner uniquement la taille de la fenêtre du classeur ne suffit pas à empêcher de façon fiable le cadre OLE de changer de taille après l'activation. Utilisez des dimensions fixes pour le graphique comme indiqué dans l'exemple.

**Cette solution fonctionne‑t‑elle avec des présentations basées sur un modèle et avec de nouvelles présentations ?**  
Oui. Pour un modèle, utilisez les dimensions et la position de l'espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d'autres programmes de tableur ?**  
L'exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne montre pas le comportement d'activation pour d'autres programmes de tableur.

## **Sections connexes**

- [Créer des graphiques Excel et les intégrer en tant qu'objets OLE dans les présentations](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)