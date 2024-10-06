---
title: Solution Fonctionnelle pour le Redimensionnement de Worksheet
type: docs
weight: 40
url: /net/solution-fonctionnelle-pour-le-redimensionnement-de-worksheet/
---

{{% alert color="primary" %}} 

Il a été observé que les feuilles de calcul Excel intégrées en tant qu'OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle indéfinie après leur première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états avant et après l'activation du graphique. Nous avons étudié ce problème en détail et trouvé la solution à ce problème qui est couverte dans cet article.

{{% /alert %}} 
## **Contexte**
Dans l'[article Ajouter des cadres Ole]() , nous avons expliqué comment ajouter un cadre Ole dans une présentation PowerPoint en utilisant Aspose.Slides pour .NET. Afin de tenir compte de [l'issue d'objet modifié](/slides/net/object-changed-issue-when-adding-oleobjectframe/), nous avons assigné l'image de la feuille de calcul de la zone sélectionnée au cadre d'objet OLE de graphique. Dans la présentation de sortie, lorsque nous double-cliquons sur le cadre d'objet OLE affichant l'image de la feuille de calcul, le graphique Excel est activé. Les utilisateurs peuvent apporter toutes les modifications désirées dans le classeur Excel réel, puis revenir à la diapositive concernée en cliquant à l'extérieur du classeur Excel activé. La taille du cadre d'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement sera différent pour les différentes tailles de cadres d'objet OLE et de classeurs Excel intégrés.
## **Cause du Redimensionnement**
Étant donné que le classeur Excel a sa propre taille de fenêtre, il essaie de conserver sa taille originale lors de la première activation. D'un autre côté, le cadre d'objet OLE aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'intégration. En fonction des différences de taille de fenêtre Excel et de taille / position du cadre d'objet OLE, le redimensionnement a lieu.
## **Solution Fonctionnelle**
Il existe deux solutions possibles pour éviter l'effet de redimensionnement.

- Échelonner la taille du cadre Ole dans PPT pour correspondre à la taille en termes de hauteur/largeur du nombre désiré de lignes/colonnes dans le cadre Ole.
- Garder la taille du cadre Ole constante et échelonner la taille des lignes/colonnes participantes pour s'adapter à la taille du cadre Ole sélectionné.
## **Échelonner la taille du cadre Ole à la taille des lignes/colonnes sélectionnées de la feuille de calcul**
Dans cette approche, nous allons apprendre à définir la taille du cadre Ole du classeur Excel intégré équivalente à la taille cumulative du nombre de lignes et de colonnes participantes dans la feuille de calcul Excel.
## **Exemple**
Supposons que nous ayons défini une feuille Excel modèle et que nous souhaitions l'ajouter à la présentation en tant que cadre Ole. Dans ce scénario, la taille du cadre d'objet OLE sera d'abord calculée en fonction de la hauteur cumulative des lignes et des largeurs des colonnes du classeur participants respectivement. Ensuite, nous définirons la taille du cadre Ole à cette valeur calculée. Afin d'éviter le message rouge **Objet Intégré** pour le cadre Ole dans PowerPoint, nous obtiendrons également l'image des portions désirées de lignes et de colonnes dans le classeur et définirons cela comme image du cadre Ole.

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol,Int32 endCol, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //Définir la nouvelle hauteur et largeur des lignes et colonnes

    return new Size((int)(Math.Round(actualWidth, 2) * 576), (int)(Math.Round(actualHeight, 2) * 576));
}
```
```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //Définir l'index de la feuille active du classeur
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Obtenir le classeur et la feuille de calcul sélectionnée  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //Définir la taille Ole en fonction des lignes et colonnes sélectionnées
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //Définir la taille Ole dans le classeur
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Définir les options d'image pour prendre l'image de la feuille de calcul
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Ajouter l'image à la collection d'images de diapositive
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Sauvegarder le classeur dans un flux et le copier dans un tableau d'octets
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Ajouter le cadre d'objet Ole
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //Définir le nom de l'image et la propriété Texte Alternatif du cadre ole    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```


## **Échelonner la hauteur des lignes et la largeur des colonnes de la feuille de calcul selon la taille du cadre Ole**
Dans cette approche, nous allons apprendre à échelonner les hauteurs des lignes participantes et la largeur des colonnes participantes en fonction de la taille du cadre ole définie sur mesure.
## **Exemple**
Supposons que nous ayons défini une feuille Excel modèle et que nous souhaitions l'ajouter à la présentation en tant que cadre Ole. Dans ce scénario, nous allons définir la taille du cadre Ole et échelonner la taille des lignes et des colonnes participant dans la zone du cadre Ole. Ensuite, nous allons sauvegarder le classeur dans un flux pour enregistrer les modifications et le convertir en tableau d'octets pour l'ajouter dans le cadre Ole. Afin d'éviter le message rouge **Objet Intégré** pour le cadre Ole dans PowerPoint, nous obtiendrons également l'image des portions désirées de lignes et de colonnes dans le classeur et définirons cela comme image du cadre Ole.

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static void SetOleAccordingToCustomHeighWidth(Workbook workbook, Int32 startRow,
    Int32 endRow, Int32 startCol, Int32 endCol, double slideWidth, double slideHeight, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;
    double newWidth = slideWidth;
    double tem = 0;
    double newTem = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    ///Définir la nouvelle hauteur et largeur des lignes et colonnes

    for (int i = startRow; i <= endRow; i++)
    {
        tem = work.Cells.GetRowHeightInch(i);
        newTem = (tem / actualHeight) * newHeight;
        work.Cells.SetRowHeightInch(i, newTem);
    }

    for (int i = startCol; i <= endCol; i++)
    {
        tem = work.Cells.GetColumnWidthInch(i);
        newTem = (tem / actualWidth) * newWidth;
        work.Cells.SetColumnWidthInch(i, newTem);

    }
}

```

```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //Définir l'index de la feuille active du classeur
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Obtenir le classeur et la feuille de calcul sélectionnée  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //Définir la taille Ole en fonction des lignes et colonnes sélectionnées
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //Définir la taille Ole dans le classeur
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Définir les options d'image pour prendre l'image de la feuille de calcul
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Ajouter l'image à la collection d'images de diapositive
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Sauvegarder le classeur dans un flux et le copier dans un tableau d'octets
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Ajouter le cadre d'objet Ole
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //Définir le nom de l'image et la propriété Texte Alternatif du cadre ole    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```


## **Conclusion**


{{% alert color="primary" %}}  Il existe deux approches pour résoudre le problème de redimensionnement de la feuille de calcul. Le choix de l'approche appropriée dépend des besoins et du cas d'utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d'un modèle ou créées à partir de zéro. De plus, il n'y a pas de limite de taille pour le cadre d'objet OLE dans la solution. {{% /alert %}} 
## **Sections Connexes**
[Créer et intégrer un graphique Excel en tant qu'objet OLE dans une présentation](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre à jour automatiquement les objets OLE](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)