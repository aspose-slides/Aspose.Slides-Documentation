---
title: Solution fonctionnelle pour le redimensionnement de la feuille de calcul
type: docs
weight: 20
url: /fr/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Corrigez le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux méthodes pour maintenir la cohérence des cadres d'objets—mettre à l'échelle le cadre ou la feuille—dans les formats PPT et PPTX."
---
{{% alert color="info" title="Note" %}}

Les feuilles de calcul Excel intégrées en tant qu'objets OLE dans une présentation PowerPoint à l'aide des composants Aspose peuvent changer de taille de façon inattendue après leur première activation. Ce comportement crée une différence visuelle perceptible entre l'objet OLE avant et après l'activation. Cet article explique le problème et décrit deux moyens de le résoudre.

{{% /alert %}}

## **Contexte**

Dans l'article [Gérer OLE](/slides/fr/androidjava/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides pour Android via Java. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/androidjava/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué une image de la zone de feuille de calcul sélectionnée au cadre de l'objet OLE. Dans la présentation générée, lorsque vous double-cliquez sur le cadre OLE affichant l'image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs finaux peuvent effectuer toutes les modifications souhaitées du classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Étant donné que le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d'origine lors de la première activation. En revanche, le cadre de l'objet OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir qu'elle conserve les bonnes proportions dans le cadre du processus d'intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre de l'objet OLE.

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l'effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées.
- Conserver la taille du cadre OLE constante et mettre à l'échelle les lignes et colonnes sélectionnées pour qu'elles s'adaptent à l'intérieur.

### **Mise à l'échelle de la taille du cadre OLE**

Cette approche définit la taille du cadre OLE pour correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées dans la feuille de calcul Excel intégrée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices à base zéro. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) définit la plage affichée. L'aperçu est rendu à 96 DPI, et ses dimensions en pixels sont converties en points en utilisant 72 points par pouce. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) intègre le classeur modifié dans un cadre avec ces dimensions. L'aperçu est attribué via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) pour remplacer l'espace réservé « EMBEDDED OLE OBJECT » dans la présentation enregistrée.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Définir la taille affichée lorsque le fichier classeur est utilisé comme objet OLE dans PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Obtenir la largeur et la hauteur de l'image OLE en points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Nous devons utiliser le classeur modifié.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Ajouter l'image OLE aux ressources de la présentation.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

L'utilitaire d'aperçu définit [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) sur la plage sélectionnée et supprime les marges, en‑têtes et pieds de page. Avec [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) activé, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) rend la plage sous forme d'image PNG. L'utilitaire renvoie un nouveau flux d'entrée contenant l'image PNG, positionné au début pour être utilisé dans la présentation.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Mise à l'échelle de la taille de la plage de cellules**

Cette approche met à l'échelle les hauteurs des lignes sélectionnées et les largeurs des colonnes sélectionnées pour correspondre à une taille de cadre OLE personnalisée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices à base zéro. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) définit la plage affichée, et l'utilitaire ci‑dessous met à l'échelle cette plage pour l'adapter à un cadre de 400 points de largeur et 100 points de hauteur. Après avoir enregistré le classeur modifié dans un flux, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) l'intègre à la taille spécifiée. Un aperçu rendu à 96 DPI est attribué via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), de sorte que la présentation enregistrée affiche les cellules sélectionnées au lieu de l'espace réservé par défaut.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Définir la taille affichée lorsque le fichier classeur est utilisé comme objet OLE dans PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Mettre à l'échelle la plage de cellules pour l'adapter à la taille du cadre.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Nous devons utiliser le classeur modifié.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Ajouter l'image OLE aux ressources de la présentation.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Créer le cadre d'objet OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

L'utilitaire de mise à l'échelle calcule des rapports de largeur et de hauteur séparés pour la plage sélectionnée, préservant les largeurs relatives de ses colonnes et les hauteurs relatives de ses lignes. Il convertit les dimensions calculées de points en pouces avant de les appliquer avec [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) et [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). La plage sélectionnée doit avoir une largeur et une hauteur non nulles.

```java
/**
 * @param width     Largeur attendue de la plage de cellules en points.
 * @param height    Hauteur attendue de la plage de cellules en points.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

Cet utilitaire d'aperçu rend la plage redimensionnée en utilisant [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Il limite [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) à cette plage, supprime les marges, en‑têtes et pieds de page, et renvoie un flux PNG positionné au début.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Conclusion**

{{% alert color="info" title="Note" %}}

Il existe deux approches pour corriger le problème de redimensionnement de la feuille de calcul. Choisissez l'approche qui correspond le mieux à vos exigences et à votre cas d'utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d'un modèle ou de zéro. De plus, il n'y a aucune limite à la taille du cadre OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel intégrée change-t-elle de taille lors de sa première activation dans PowerPoint ?**

Cela se produit parce qu'Excel essaie de conserver la taille originale de la fenêtre lors de l'activation, tandis que le cadre OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille pour maintenir le rapport d'aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible d'éviter complètement ce problème de redimensionnement ?**

Oui. En mettant à l'échelle le cadre OLE pour correspondre à la taille de la plage de cellules Excel ou en mettant à l'échelle la plage de cellules pour correspondre à la taille souhaitée du cadre OLE, vous pouvez éviter le redimensionnement indésirable.

**Quelle méthode de mise à l'échelle devrais‑je utiliser, la mise à l'échelle du cadre OLE ou celle de la plage de cellules ?**

Sélectionnez **mise à l'échelle du cadre OLE** si vous souhaitez conserver les tailles originales des lignes et colonnes Excel. Sélectionnez **mise à l'échelle de la plage de cellules** si vous voulez une taille fixe pour le cadre OLE dans votre présentation.

**Ces solutions fonctionneront‑elles si ma présentation est basée sur un modèle ?**

Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles et de zéro.

**Y a‑t‑il une limite à la taille du cadre OLE lors de l'utilisation de ces méthodes ?**

Non. Vous pouvez donner au cadre OLE n'importe quelle taille tant que vous ajustez l'échelle correctement.

**Existe‑t‑il un moyen d'éviter le texte d'espace réservé « EMBEDDED OLE OBJECT » dans PowerPoint ?**

Oui. En capturant une image de la plage de cellules Excel cible et en l'utilisant comme image d'espace réservé du cadre OLE, vous pouvez afficher une image d'aperçu personnalisée à la place de l'espace réservé par défaut.

## **Articles associés**

[Créer un graphique Excel et l'intégrer dans une présentation en tant qu'objet OLE](/slides/fr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre à jour automatiquement les objets OLE à l'aide d'un add‑in MS PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)