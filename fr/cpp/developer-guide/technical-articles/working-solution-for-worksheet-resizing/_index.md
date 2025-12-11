---
title: Solution fonctionnelle pour le redimensionnement des feuilles de calcul
type: docs
weight: 130
url: /fr/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- C++
- Aspose.Slides for C++
description: "Solution fonctionnelle pour le redimensionnement des feuilles de calcul dans les présentations PowerPoint utilisant C++"
---

{{% alert color="primary" %}}

Il a été observé que les feuilles de calcul Excel intégrées en tant qu’objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle indéterminée après la première activation. Ce comportement crée une différence visuelle notable dans la présentation entre les états pré‑ et post‑activation de l’objet OLE. Nous avons étudié ce problème en détail et fourni une solution, présentée dans cet article.

{{% /alert %}}

## **Contexte**

Dans l’article [Gérer OLE](/slides/fr/cpp/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides for C++. Pour résoudre le problème d’[aperçu d’objet](/slides/fr/cpp/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué une image de la zone de feuille de calcul sélectionnée au cadre d’objet OLE. Dans la présentation générée, lorsque vous double‑cliquez sur le cadre OLE affichant l’image de la feuille, le classeur Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre OLE changera lorsque l’utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre OLE et du classeur Excel intégré. 

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d’origine lors de la première activation. En revanche, le cadre OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de maintenir les proportions correctes dans le cadre du processus d’intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre OLE. 

## **Solution fonctionnelle**

Deux solutions possibles permettent d’éviter l’effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur du nombre souhaité de lignes et de colonnes dans le cadre OLE.
- Conserver la taille du cadre OLE constante et redimensionner la taille des lignes et colonnes participantes afin qu’elles s’ajustent à la taille du cadre OLE sélectionnée.

### **Redimensionner la taille du cadre OLE**

Dans cette approche, nous apprendrons comment définir la taille du cadre OLE du classeur Excel intégré afin qu’elle corresponde à la taille cumulative des lignes et colonnes participantes de la feuille Excel.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation sous forme de cadre OLE. Dans ce scénario, la taille du cadre OLE sera d’abord calculée à partir des hauteurs cumulées des lignes et des largeurs cumulées des colonnes participantes du classeur. Ensuite, nous définirons la taille du cadre OLE à cette valeur calculée. Pour éviter le message rouge « EMBEDDED OLE OBJECT » du cadre OLE dans PowerPoint, nous capturerons également une image des portions souhaitées des lignes et colonnes du classeur et la définirons comme image du cadre OLE.
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Définir la taille affichée lorsque le fichier de classeur est utilisé comme un objet OLE dans PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Obtenir la largeur et la hauteur de l'image OLE en points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Nous devons utiliser le classeur modifié.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Ajouter l'image OLE aux ressources de la présentation.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Créer le cadre d'objet OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```


### **Redimensionner la taille de la plage de cellules**

Dans cette approche, nous apprendrons comment redimensionner les hauteurs des lignes participantes et la largeur des colonnes participantes afin qu’elles correspondent à une taille de cadre OLE personnalisée.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation sous forme de cadre OLE. Dans ce scénario, nous définirons la taille du cadre OLE et redimensionnerons la taille des lignes et colonnes participant à la zone du cadre OLE. Nous enregistrerons ensuite le classeur dans un flux pour appliquer les modifications et le convertirons en tableau d’octets afin de l’ajouter au cadre OLE. Pour éviter le message rouge « EMBEDDED OLE OBJECT » du cadre OLE dans PowerPoint, nous capturerons également une image des portions souhaitées des lignes et colonnes du classeur et la définirons comme image du cadre OLE.
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Définir la taille affichée lorsque le fichier de classeur est utilisé comme objet OLE dans PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Redimensionner la plage de cellules pour l'adapter à la taille du cadre.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Nous devons utiliser le classeur modifié.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Ajouter l'image OLE aux ressources de la présentation.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Créer le cadre d'objet OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">La largeur attendue de la plage de cellules en points.</param>
/// <param name="height">La hauteur attendue de la plage de cellules en points.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```


## **Conclusion**

{{% alert color="primary" %}}

Il existe deux approches pour corriger le problème de redimensionnement de la feuille de calcul. Le choix de l’approche appropriée dépend des exigences spécifiques et du cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’y a aucune limite à la taille du cadre OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel intégrée change‑t‑elle de taille lors de sa première activation dans PowerPoint ?**

Cela se produit parce qu’Excel essaie de conserver la taille d’origine de sa fenêtre lors de l’activation, tandis que le cadre OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de maintenir le ratio d’aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible d’éliminer totalement ce problème de redimensionnement ?**

Oui. En redimensionnant le cadre OLE pour correspondre à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour correspondre à la taille de cadre OLE souhaitée, vous pouvez éviter le redimensionnement indésirable.

**Quelle méthode de redimensionnement devrais‑je utiliser, le redimensionnement du cadre OLE ou le redimensionnement de la plage de cellules ?**

Choisissez **le redimensionnement du cadre OLE** si vous souhaitez conserver les tailles originales des lignes et colonnes Excel. Choisissez **le redimensionnement de la plage de cellules** si vous voulez une taille fixe pour le cadre OLE dans votre présentation.

**Ces solutions fonctionneront‑elles si ma présentation est basée sur un modèle ?**

Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles et à partir de zéro.

**Existe‑t‑il une limite à la taille du cadre OLE lorsque l’on utilise ces méthodes ?**

Non. Vous pouvez définir le cadre OLE à n’importe quelle taille tant que vous ajustez correctement l’échelle.

**Y a‑t‑il un moyen d’éviter le texte de remplacement « EMBEDDED OLE OBJECT » dans PowerPoint ?**

Oui. En capturant une image de la plage de cellules Excel cible et en l’utilisant comme image de remplacement du cadre OLE, vous pouvez afficher une image d’aperçu personnalisée à la place du texte de remplacement par défaut.

## **Articles associés**

[Créer un graphique Excel et l’intégrer à une présentation en tant qu’objet OLE](/slides/fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)