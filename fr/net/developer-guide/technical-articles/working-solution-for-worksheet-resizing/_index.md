---
title: Solution fonctionnelle pour le redimensionnement des feuilles de calcul
type: docs
weight: 40
url: /fr/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Corriger le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux façons de garder les cadres d'objets cohérents—redimensionner le cadre ou la feuille—dans les formats PPT et PPTX."
---
{{% alert color="info" title="Note" %}}

Les feuilles de calcul Excel intégrées en tant qu'objets OLE dans une présentation PowerPoint utilisant les composants Aspose peuvent changer de taille de manière inattendue après leur première activation. Ce comportement crée une différence visuelle notable entre l'objet OLE avant et après l'activation. Cet article explique le problème et décrit deux solutions pour le résoudre.

{{% /alert %}} 

## **Contexte**

Dans l'article [Gérer OLE](/slides/fr/net/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint à l'aide d'Aspose.Slides for .NET. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/net/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté une image de la zone de feuille de calcul sélectionnée au cadre de l'objet OLE. Dans la présentation de sortie, lorsque vous double-cliquez sur le cadre de l'objet OLE affichant l'image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant à l'extérieur du classeur Excel activé. La taille du cadre de l'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre de l'objet OLE et du classeur Excel incorporé. 

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d'origine lors de la première activation. D'autre part, le cadre de l'objet OLE possède sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir le maintien des bonnes proportions dans le cadre du processus d'intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre de l'objet OLE. 

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l'effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées.  
- Conserver la taille du cadre OLE constante et redimensionner les lignes et colonnes sélectionnées pour les adapter.

### **Redimensionner la taille du cadre OLE**

Cette approche définit la taille du cadre OLE pour correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées dans la feuille de calcul Excel incorporée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille en utilisant des indices zéro‑based. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) définit la plage affichée. L'aperçu est rendu à 96 DPI, et ses dimensions en pixels sont converties en points en utilisant 72 points par pouce. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) intègre le classeur modifié dans un cadre avec ces dimensions. L'aperçu est attribué via [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) pour remplacer le texte de substitution « EMBEDDED OLE OBJECT » dans la présentation enregistrée.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Définir la taille affichée lorsque le fichier du classeur est utilisé comme objet OLE dans PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Nous devons utiliser le classeur modifié.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

L'assistant d'aperçu définit [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) sur la plage sélectionnée et supprime les marges, en‑têtes et pieds de page. Avec [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) activé, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) rend la plage en image PNG. L'assistant remet le flux d'image à zéro avant de le renvoyer pour utilisation dans la présentation.

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Redimensionner la taille de la plage de cellules**

Cette approche redimensionne les hauteurs des lignes sélectionnées et les largeurs des colonnes sélectionnées pour correspondre à une taille de cadre OLE personnalisée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille en utilisant des indices zéro‑based. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) définit la plage affichée, et l'assistant ci‑dessous redimensionne cette plage pour l'adapter à un cadre de 400 points de large et 100 points de haut. Après avoir enregistré le classeur modifié dans un flux, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) l'intègre à la taille spécifiée. Un aperçu rendu à 96 DPI est attribué via [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), de sorte que la présentation enregistrée affiche les cellules sélectionnées au lieu du texte de substitution par défaut.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Définir la taille affichée lorsque le fichier du classeur est utilisé comme objet OLE dans PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Redimensionner la plage de cellules pour s'adapter à la taille du cadre.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Nous devons utiliser le classeur modifié.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Ajouter l'image OLE aux ressources de la présentation.
var oleImage = presentation.Images.AddImage(imageStream);

// Créer le cadre d'objet OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

L'assistant de redimensionnement calcule des rapports de largeur et de hauteur séparés pour la plage sélectionnée, en préservant les largeurs relatives de ses colonnes et les hauteurs relatives de ses lignes. Il convertit les dimensions calculées de points en pouces avant de les appliquer avec [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) et [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). La plage sélectionnée doit avoir une largeur et une hauteur non nulles.

```cs
/// <param name="width">La largeur attendue de la plage de cellules en points.</param>
/// <param name="height">La hauteur attendue de la plage de cellules en points.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Cet assistant d'aperçu rend la plage redimensionnée à l'aide de [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Il limite [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) à cette plage, supprime les marges, en‑têtes et pieds de page, et renvoie un flux PNG positionné au début.

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Conclusion**

{{% alert color="info" title="Note" %}}

Il existe deux approches pour corriger le problème de redimensionnement de la feuille de calcul. Choisissez celle qui correspond le mieux à vos exigences et à votre cas d'utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d'un modèle ou à partir de zéro. De plus, il n'y a aucune limite à la taille du cadre OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel incorporée change-t-elle de taille lors de sa première activation dans PowerPoint ?**

Cela se produit parce qu'Excel tente de conserver la taille de fenêtre d'origine lors de l'activation, tandis que le cadre OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille pour maintenir le rapport d'aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible d'éviter complètement ce problème de redimensionnement ?**

Oui. En redimensionnant le cadre OLE pour correspondre à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour s'adapter à la taille du cadre OLE souhaitée, vous pouvez empêcher le redimensionnement indésirable.

**Quelle méthode de redimensionnement devrais‑je utiliser, le redimensionnement du cadre OLE ou celui de la plage de cellules ?**

Choisissez le **redimensionnement du cadre OLE** si vous voulez conserver les tailles de lignes et colonnes Excel d'origine. Choisissez le **redimensionnement de la plage de cellules** si vous souhaitez une taille fixe pour le cadre OLE dans votre présentation.

**Ces solutions fonctionnent‑elles si ma présentation est basée sur un modèle ?**

Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles et pour celles créées à partir de zéro.

**Existe‑t‑il une limite à la taille du cadre OLE lors de l’utilisation de ces méthodes ?**

Non. Vous pouvez définir le cadre OLE à n’importe quelle taille tant que vous ajustez correctement l'échelle.

**Y a‑t‑il un moyen d'éviter le texte de substitution « EMBEDDED OLE OBJECT » dans PowerPoint ?**

Oui. En capturant une image de la plage de cellules Excel cible et en la définissant comme image de substitution du cadre OLE, vous pouvez afficher une image d'aperçu personnalisée à la place du texte de substitution par défaut.

## **Articles associés**

[Créer un graphique Excel et l’intégrer dans une présentation en tant qu’objet OLE](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre à jour automatiquement les objets OLE à l’aide d’un complément MS PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)