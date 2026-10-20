---
title: Solution fonctionnelle pour le redimensionnement de la feuille de calcul
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
- Aspose.Slides pour C++
description: "Solution fonctionnelle pour le redimensionnement de la feuille de calcul dans les présentations PowerPoint utilisant C++"
---
{{% alert color="info" title="Note" %}}

Les feuilles de calcul Excel intégrées en tant qu'objets OLE dans une présentation PowerPoint à l'aide des composants Aspose peuvent être redimensionnées de manière inattendue après leur première activation. Ce comportement crée une différence visuelle notable entre l'objet OLE avant et après l'activation. Cet article explique le problème et décrit deux façons de le résoudre.

{{% /alert %}}

## **Contexte**

Dans l'article [Gérer OLE](/slides/fr/cpp/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides for C++. Pour résoudre le [probleme d'aperçu d'objet](/slides/fr/cpp/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté une image de la zone de la feuille de calcul sélectionnée au cadre d'objet OLE. Dans la présentation résultante, lorsque vous double-cliquez sur le cadre d'objet OLE affichant l'image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre d'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre d'objet OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Puisque le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d'origine lors de la première activation. D'autre part, le cadre d'objet OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir le maintien des bonnes proportions dans le cadre du processus d'intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre d'objet OLE.

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l'effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint afin qu'il corresponde à la hauteur et à la largeur totales des lignes et colonnes sélectionnées.
- Conserver la taille du cadre OLE constante et redimensionner les lignes et colonnes sélectionnées pour qu'elles s'adaptent à celui‑ci.

### **Redimensionner la taille du cadre OLE**

Cette approche définit la taille du cadre OLE afin qu'elle corresponde à la hauteur et à la largeur totales des lignes et colonnes sélectionnées dans la feuille de calcul Excel intégrée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices basés à zéro. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) définit la plage affichée. L'aperçu est rendu à 96 DPI, et ses dimensions en pixels sont converties en points en utilisant 72 points par pouce. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) intègre le classeur modifié dans un cadre avec ces dimensions. L'aperçu est affecté via [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) pour remplacer l'espace réservé « EMBEDDED OLE OBJECT » dans la présentation enregistrée.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

L’assistant d’aperçu utilise [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) pour sélectionner la plage et supprime les marges, en‑têtes et pieds de page. Avec [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) activé, [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) rend la plage sous forme d’image PNG. L’assistant copie les données d’image rendues dans un nouveau flux mémoire positionné au début pour être utilisé dans la présentation.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

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

Cette approche redimensionne les hauteurs des lignes sélectionnées et les largeurs des colonnes sélectionnées afin qu'elles correspondent à une taille de cadre OLE personnalisée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices basés à zéro. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) définit la plage affichée, et l’assistant ci‑dessous redimensionne cette plage pour l’adapter à un cadre de 400 points de large sur 100 points de haut. Après avoir enregistré le classeur modifié dans un tableau d’octets, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) l’intègre à la taille spécifiée. Un aperçu rendu à 96 DPI est affecté via [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), de sorte que la présentation enregistrée affiche les cellules sélectionnées au lieu de l’espace réservé par défaut.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

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

// Redimensionner la plage de cellules pour correspondre à la taille du cadre.
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

L’assistant de mise à l’échelle calcule des rapports séparés de largeur et de hauteur pour la plage sélectionnée, préservant les largeurs relatives de ses colonnes et les hauteurs relatives de ses lignes. Il convertit les dimensions calculées de points en pouces avant de les appliquer avec [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) et [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). La plage sélectionnée doit avoir une largeur et une hauteur non nulles.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

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

Cet assistant d’aperçu rend la plage redimensionnée en utilisant [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Il utilise [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) pour limiter l’impression à cette plage, supprime les marges, en‑têtes et pieds de page, et renvoie un flux PNG positionné au début.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

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

{{% alert color="info" title="Note" %}}

Il existe deux approches pour corriger le problème de redimensionnement de la feuille de calcul. Choisissez l’approche qui correspond le mieux à vos exigences et à votre cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’y a aucune limite à la taille du cadre d’objet OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel intégrée change‑t‑elle de taille lors de sa première activation dans PowerPoint ?**  
Cela se produit parce qu’Excel tente de maintenir la taille originale de sa fenêtre lors de l’activation, tandis que le cadre d’objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de conserver le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible d’éviter complètement ce problème de redimensionnement ?**  
Oui. En redimensionnant le cadre OLE pour qu’il corresponde à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour qu’elle s’adapte à la taille souhaitée du cadre OLE, vous pouvez empêcher le redimensionnement indésirable.

**Quelle méthode de redimensionnement devrais‑je utiliser, le redimensionnement du cadre OLE ou le redimensionnement de la plage de cellules ?**  
Choisissez **le redimensionnement du cadre OLE** si vous souhaitez conserver les tailles d’origine des lignes et colonnes Excel. Choisissez **le redimensionnement de la plage de cellules** si vous avez besoin d’une taille fixe pour le cadre OLE dans votre présentation.

**Ces solutions fonctionneront‑elles si ma présentation est basée sur un modèle ?**  
Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles ainsi que pour celles créées à partir de zéro.

**Existe‑t‑il une limite à la taille du cadre OLE lorsque l’on utilise ces méthodes ?**  
Non. Vous pouvez donner au cadre d’objet OLE n’importe quelle taille tant que vous définissez correctement l’échelle.

**Y a‑t‑il un moyen d’éviter le texte d’espace réservé « EMBEDDED OLE OBJECT » dans PowerPoint ?**  
Oui. En capturant une image de la plage de cellules Excel cible et en l’affectant comme image d’espace réservé du cadre OLE, vous pouvez afficher une image d’aperçu personnalisée à la place de l’espace réservé par défaut.

## **Articles associés**

[Créer un graphique Excel et l'intégrer dans une présentation en tant qu'objet OLE](/slides/fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)