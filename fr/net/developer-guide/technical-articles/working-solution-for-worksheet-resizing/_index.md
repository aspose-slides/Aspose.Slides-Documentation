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
description: "Corriger le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux méthodes pour garder les cadres d'objets cohérents—mise à l'échelle du cadre ou de la feuille—pour les formats PPT et PPTX."
---

{{% alert color="primary" %}} 

Il a été constaté que les feuilles de calcul Excel intégrées en tant qu’objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle indéterminée après la première activation. Ce comportement crée une différence visuelle notable dans la présentation entre les états avant et après activation de l’objet OLE. Nous avons examiné ce problème en détail et proposé une solution, décrite dans cet article.

{{% /alert %}} 

## **Contexte**

Dans l’article [Manage OLE](/slides/fr/net/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides for .NET. Pour résoudre le problème d’[object preview issue](/slides/fr/net/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué une image de la zone de la feuille de calcul sélectionnée au cadre d’objet OLE. Dans la présentation générée, lorsque vous double-cliquez sur le cadre d’objet OLE affichant l’image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs peuvent apporter toutes les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre d’objet OLE changera lorsque l’utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre d’objet OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Étant donné que le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d’origine lors de la première activation. En revanche, le cadre d’objet OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir le maintien des proportions correctes dans le cadre du processus d’intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre d’objet OLE.

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l’effet de redimensionnement.

- Redimensionner la taille du cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur du nombre désiré de lignes et de colonnes dans le cadre OLE.
- Conserver la taille du cadre OLE constante et ajuster la taille des lignes et colonnes participantes pour qu’elles tiennent dans la taille du cadre OLE sélectionnée.

### **Redimensionner la taille du cadre OLE**

Dans cette approche, nous apprendrons comment définir la taille du cadre OLE du classeur Excel intégré afin qu’elle corresponde à la taille cumulative des lignes et colonnes participantes dans la feuille de calcul Excel.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation en tant que cadre OLE. Dans ce scénario, la taille du cadre d’objet OLE sera d’abord calculée en fonction des hauteurs cumulées des lignes et des largeurs cumulées des colonnes des lignes et colonnes participantes dans le classeur. Ensuite, nous définirons la taille du cadre OLE à cette valeur calculée. Pour éviter le message rouge « EMBEDDED OLE OBJECT » du cadre OLE dans PowerPoint, nous capturerons également une image des parties souhaitées des lignes et colonnes du classeur et l’utiliserons comme image du cadre OLE.
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
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

Dans cette approche, nous apprendrons comment ajuster les hauteurs des lignes participantes et la largeur des colonnes participantes afin de correspondre à une taille personnalisée du cadre OLE.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation en tant que cadre OLE. Dans ce scénario, nous définirons la taille du cadre OLE et ajusterons la taille des lignes et colonnes qui participent à la zone du cadre OLE. Nous enregistrerons ensuite le classeur dans un flux pour appliquer les modifications et le convertir en tableau d’octets afin de l’ajouter au cadre OLE. Pour éviter le message rouge « EMBEDDED OLE OBJECT » du cadre OLE dans PowerPoint, nous capturerons également une image des parties souhaitées des lignes et colonnes du classeur et l’utiliserons comme image du cadre OLE.
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Définir la taille affichée lorsque le fichier de classeur est utilisé comme objet OLE dans PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Redimensionner la plage de cellules pour l'adapter à la taille du cadre.
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

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

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

{{% alert color="primary" %}}

Il existe deux approches pour résoudre le problème de redimensionnement de la feuille de calcul. Le choix de l’approche appropriée dépend des exigences spécifiques et du cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’y a aucune limite à la taille du cadre d’objet OLE dans cette solution.

{{% /alert %}}

## FAQ

**Q : Pourquoi une feuille de calcul Excel intégrée change-t-elle de taille lors de la première activation dans PowerPoint ?**  
Cela se produit parce qu’Excel tente de conserver la taille originale de la fenêtre lorsqu’il est activé, tandis que le cadre d’objet OLE dans PowerPoint a ses propres dimensions. PowerPoint et Excel négocient la taille pour maintenir le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Q : Est‑il possible d’éviter complètement ce problème de redimensionnement ?**  
Oui. En redimensionnant le cadre OLE pour correspondre à la taille de la plage de cellules Excel ou en ajustant la plage de cellules pour correspondre à la taille souhaitée du cadre OLE, vous pouvez éviter le redimensionnement indésirable.

**Q : Quelle méthode de redimensionnement dois‑je utiliser, le redimensionnement du cadre OLE ou le redimensionnement de la plage de cellules ?**  
Choisissez le **redimensionnement du cadre OLE** si vous souhaitez conserver les tailles originales des lignes et colonnes Excel. Choisissez le **redimensionnement de la plage de cellules** si vous désirez une taille fixe pour le cadre OLE dans votre présentation.

**Q : Ces solutions fonctionneront‑elles si ma présentation est basée sur un modèle ?**  
Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles ainsi que pour celles créées à partir de zéro.

**Q : Existe‑t‑il une limite à la taille du cadre OLE lors de l’utilisation de ces méthodes ?**  
Non. Vous pouvez définir le cadre d’objet OLE à n’importe quelle taille tant que vous ajustez correctement l’échelle.

**Q : Existe‑t‑il un moyen d’éviter le texte de remplacement « EMBEDDED OLE OBJECT » dans PowerPoint ?**  
Oui. En capturant une image de la plage de cellules Excel cible et en l’utilisant comme image de remplacement du cadre OLE, vous pouvez afficher une image d’aperçu personnalisée à la place du texte de remplacement par défaut.

## **Related Articles**

[Créer un graphique Excel et l’intégrer dans une présentation en tant qu’objet OLE](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre à jour les objets OLE automatiquement à l’aide d’un add‑in MS PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)