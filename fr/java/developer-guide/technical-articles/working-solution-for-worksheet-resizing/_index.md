---
title: Solution fonctionnelle pour le redimensionnement des feuilles de calcul
type: docs
weight: 20
url: /fr/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Corrige le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux méthodes pour maintenir la cohérence des cadres d’objet—redimensionner le cadre ou la feuille—dans les formats PPT et PPTX."
---
{{% alert color="info" %}}

Il a été observé que les feuilles de calcul Excel intégrées comme objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle non identifiée après la première activation. Ce comportement crée une différence visuelle notable dans la présentation entre les états avant et après activation de l’objet OLE. Nous avons étudié ce problème en détail et fourni une solution, présentée dans cet article.

{{% /alert %}}

## **Contexte**

Dans l’article [Gérer OLE](/slides/fr/java/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides for Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/java/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué une image de la zone de la feuille de calcul sélectionnée au cadre d’objet OLE. Dans la présentation générée, lorsque vous double-cliquez sur le cadre OLE affichant l’image de la feuille, le classeur Excel est activé. Les utilisateurs peuvent alors apporter toutes les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre OLE change lorsque l’utilisateur revient à la diapositive. Le facteur de redimensionnement varie en fonction de la taille du cadre OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il essaie de conserver cette taille lors de la première activation. En revanche, le cadre OLE possède ses propres dimensions. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin qu’elle conserve les bonnes proportions dans le cadre de l’intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre OLE.

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l’effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur du nombre souhaité de lignes et de colonnes dans le cadre OLE.
- Conserver la taille du cadre OLE constante et redimensionner les lignes et colonnes participantes pour les adapter à la taille du cadre OLE sélectionnée.

### **Redimensionner la taille du cadre OLE**

Dans cette approche, nous apprendrons comment définir la taille du cadre OLE du classeur Excel intégré afin qu’elle corresponde à la taille cumulée des lignes et colonnes participantes dans la feuille de calcul Excel.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation en tant que cadre OLE. Dans ce scénario, la taille du cadre OLE sera d’abord calculée à partir des hauteurs cumulées des lignes et des largeurs cumulées des colonnes participantes du classeur. Ensuite, nous définirons la taille du cadre OLE à cette valeur calculée. Pour éviter le message rouge « EMBEDDED OLE OBJECT » du cadre OLE dans PowerPoint, nous capturerons également une image des portions désirées des lignes et colonnes du classeur et l’utiliserons comme image du cadre OLE.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

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
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

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

// Créer le cadre d'objet OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

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

### **Redimensionner la taille de la plage de cellules**

Dans cette approche, nous apprendrons comment redimensionner les hauteurs des lignes participantes et la largeur des colonnes participantes pour correspondre à une taille personnalisée du cadre OLE.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation en tant que cadre OLE. Dans ce scénario, nous définirons la taille du cadre OLE et redimensionnerons la taille des lignes et colonnes qui participent à la zone du cadre OLE. Nous enregistrerons ensuite le classeur dans un flux pour appliquer les modifications et le convertirons en tableau d’octets afin de l’ajouter au cadre OLE. Pour éviter le message rouge « EMBEDDED OLE OBJECT » du cadre OLE dans PowerPoint, nous capturerons également une image des portions désirées des lignes et colonnes du classeur et l’utiliserons comme image du cadre OLE.

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

// Redimensionner la plage de cellules pour l'adapter à la taille du cadre.
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

```java
/**
 * @param width     La largeur attendue de la plage de cellules en points.
 * @param height    La hauteur attendue de la plage de cellules en points.
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

{{% alert color="info" %}} 

Il existe deux approches pour résoudre le problème de redimensionnement de la feuille de calcul. Le choix de l’approche appropriée dépend des exigences spécifiques et du cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, aucune limite n’est imposée à la taille du cadre OLE dans cette solution.

{{% /alert %}}

## **FAQ**

### Pourquoi une feuille de calcul Excel intégrée change-t-elle de taille lors de sa première activation dans PowerPoint ?

Cela se produit parce qu’Excel tente de conserver la taille originale de sa fenêtre lors de l’activation, tandis que le cadre OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de maintenir le rapport d’aspect, ce qui peut entraîner le redimensionnement.

### Est‑il possible d’éliminer entièrement ce problème de redimensionnement ?

Oui. En redimensionnant le cadre OLE pour qu’il corresponde à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour qu’elle corresponde à la taille souhaitée du cadre OLE, vous pouvez empêcher le redimensionnement indésirable.

### Quelle méthode de redimensionnement devrais‑je utiliser, le redimensionnement du cadre OLE ou celui de la plage de cellules ?

Choisissez **le redimensionnement du cadre OLE** si vous souhaitez conserver les tailles originales des lignes et colonnes Excel. Choisissez **le redimensionnement de la plage de cellules** si vous désirez une taille fixe pour le cadre OLE dans votre présentation.

### Ces solutions fonctionnent‑elles si ma présentation est basée sur un modèle ?

Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles et à partir de zéro.

### Existe‑t‑il une limite à la taille du cadre OLE lorsque l’on utilise ces méthodes ?

Non. Vous pouvez définir le cadre OLE à n’importe quelle taille tant que vous ajustez correctement l’échelle.

### Existe‑t‑il un moyen d’éviter le texte de remplacement « EMBEDDED OLE OBJECT » dans PowerPoint ?

Oui. En capturant un instantané de la plage de cellules Excel cible et en l’utilisant comme image de remplacement du cadre OLE, vous pouvez afficher une image d’aperçu personnalisée à la place du texte par défaut.

## **Articles associés**

[Créer un graphique Excel et l’intégrer dans une présentation en tant qu’objet OLE](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre à jour les objets OLE automatiquement à l’aide d’un module complémentaire MS PowerPoint](/slides/fr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)