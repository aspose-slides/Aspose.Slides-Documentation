---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 40
url: /fr/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l’utilisation d’objets OLE Excel intégrés avec Aspose.Slides pour Android via Java. Définit des dimensions fixes pour le graphique afin de maintenir la cohérence des tailles du graphique et du cadre OLE."
---
## **Vue d'ensemble**

Les graphiques Excel intégrés en tant qu’objets OLE dans des présentations PowerPoint à l’aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut entraîner une différence notable de l’apparence du graphique avant et après l’activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l’empêcher en faisant correspondre les dimensions fixes du graphique au cadre OLE.

Dans [Créer des graphiques Excel et les intégrer en tant qu’objets OLE dans les présentations](/slides/fr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for Android via Java et l’intégrer dans une présentation PowerPoint à l’aide d’Aspose.Slides for Android via Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/androidjava/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté l’image du graphique au cadre OLE du graphique. Dans la présentation de sortie, lorsque vous double‑cliquez sur le cadre OLE affichant l’image du graphique, le graphique Excel est activé. Les utilisateurs peuvent modifier le classeur Excel intégré puis revenir à la diapositive en cliquant en dehors du classeur activé. La taille du cadre OLE change lorsque l’utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d’origine du cadre OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Le classeur Excel intégré possède ses propres dimensions de fenêtre, que Excel tente de conserver lors de la première activation de l’objet. Le cadre OLE sur la diapositive a des dimensions définies indépendamment. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l’objet pour maintenir ses proportions dans le cadre du processus d’intégration. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc provoquer le redimensionnement de l’objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE sur la diapositive et maintenez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une nouvelle présentation ou un modèle existant.

L’exemple nécessite Aspose.Cells for Android via Java et Aspose.Slides for Android via Java. Il crée un simple graphique en colonnes sur une feuille de graphique active et intègre le classeur au format XLS. Appelez `FixedChartSize.createPresentation(getFilesDir())` depuis une activité Android pour enregistrer la sortie dans le répertoire interne des fichiers de l’application. L’activation OLE nécessite PowerPoint de bureau et une installation Excel compatible. Aucune image d’aperçu du graphique n’est attribuée ; le graphique devient visible lorsque l’objet OLE est activé dans PowerPoint.

L’exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces positionné à 0,5 pouce du bord gauche et à 1 pouce du haut. Les coordonnées et dimensions de la diapositive sont en points (72 points par pouce). Pour une présentation existante, voir [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) sur false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions du [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) via [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) et [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), en convertissant les points en pixels à raison de 96 pixels par pouce : un cadre de 684 × 288 points correspond à un graphique de 912 × 384 pixels. Définissez [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) sur la valeur CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). L’exemple intègre le classeur avec [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // Les coordonnées et dimensions de la diapositive sont en points (72 points par pouce).
                    float width = 684f; // 9,5 pouces.
                    float height = 288f; // 4 pouces.

                    chart.setSizeWithWindow(false);
                    // Convertir les points en pixels de graphique en utilisant 96 pixels par pouce.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
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

Cela se produit parce qu’Excel tente de restaurer la taille de fenêtre d’origine lors de la première activation, alors que le cadre OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille pour maintenir le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Comment puis‑je garder les tailles du graphique et du cadre OLE cohérentes ?**

Définissez des dimensions fixes du graphique qui correspondent au cadre OLE et utilisez une taille d’impression de graphique personnalisée avant d’intégrer le classeur. L’exemple ci‑dessus montre les paramètres requis et les conversions d’unité.

**Le fait d’adapter la taille de la fenêtre du classeur est‑il suffisant ?**

Adapter uniquement la taille de la fenêtre du classeur ne prévient pas de manière fiable le changement de taille du cadre OLE après activation. Utilisez des dimensions fixes du graphique comme indiqué dans l’exemple.

**Cette solution fonctionne‑t‑elle avec les présentations basées sur un modèle et les nouvelles présentations ?**

Oui. Pour un modèle, utilisez les dimensions et la position de l’espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d’autres programmes de tableur ?**

L’exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne démontre pas le comportement d’activation pour d’autres programmes de tableur.

## **Sections connexes**

- [Créer des graphiques Excel et les intégrer en tant qu’objets OLE dans les présentations](/slides/fr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)