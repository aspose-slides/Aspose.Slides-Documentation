---
title: ワークシートのリサイズに対する実装済みソリューション
type: docs
weight: 130
url: /ja/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides for C++
description: "C++ を使用した PowerPoint プレゼンテーションにおけるワークシートリサイズの実装済みソリューション"
---
{{% alert color="info" title="Note" %}}
Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初にアクティブ化された後に予期せずサイズが変わることがあります。この動作により、アクティブ化前後の OLE オブジェクトに目立つ視覚的な違いが生じます。本記事ではこの問題を説明し、対処する2つの方法を紹介します。
{{% /alert %}}

## **背景**

記事[OLE の管理](/slides/ja/cpp/manage-ole/)では、Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/cpp/object-preview-issue-when-adding-oleobjectframe/)に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示する OLE オブジェクトフレームをダブルクリックすると、Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックに任意の変更を加え、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ることができます。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズの係数は OLE オブジェクトフレームと埋め込まれた Excel ブックのサイズに応じて変わります。

## **リサイズの原因**

Excel ブックには独自のウィンドウサイズがあるため、最初にアクティブ化された際には元のサイズを保持しようとします。一方、OLE オブジェクトフレームには独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを調整し、埋め込みプロセスの一部として正しい比率を保つように交渉します。リサイズは、Excel ウィンドウのサイズと OLE オブジェクトフレームのサイズ・位置の差に基づいて発生します。

## **実装済みソリューション**

リサイズ効果を回避するための2つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の合計高さと幅に合わせてスケーリングする。
- OLE フレームのサイズを固定したまま、選択した行と列をスケーリングしてフレーム内に収める。

### **OLE フレームサイズのスケーリング**

この方法は、埋め込まれた Excel ワークシートの選択された行と列の合計高さと幅に合わせて OLE フレームサイズを設定します。

この例では、既存の Excel ワークブックを読み込み、0 ベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) が表示範囲を定義します。プレビューは 96 DPI でレンダリングされ、ピクセル寸法は 1 インチ当たり 72 ポイントを使用してポイントに変換されます。[ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) は、変更されたワークブックをその寸法のフレームに埋め込みます。プレビューは [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) を通じて割り当てられ、保存されたプレゼンテーションの「EMBEDDED OLE OBJECT」プレースホルダーを置き換えます。

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

プレビュー ヘルパーは [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) を使用して範囲を選択し、余白、ヘッダー、フッターを削除します。[ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) を有効にすると、[SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) が範囲を PNG 画像としてレンダリングします。ヘルパーはレンダリングされた画像データを新しいメモリストリームにコピーし、先頭に位置付けてプレゼンテーションで使用できるようにします。

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

### **セル範囲のスケーリング**

この方法は、選択した行の高さと列の幅をスケーリングして、カスタム OLE フレームサイズに合わせます。

この例では、既存の Excel ワークブックを読み込み、0 ベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) が表示範囲を定義し、以下のヘルパーがその範囲を幅 400 ポイント、高さ 100 ポイントのフレームに合わせてスケーリングします。変更されたワークブックをバイト配列に保存した後、[ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) が指定サイズで埋め込みます。96 DPI でレンダリングされたプレビューは [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) を介して割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーではなく選択されたセルを表示します。

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

// PowerPoint でワークブック ファイルが OLE オブジェクトとして使用される場合の表示サイズを設定します。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// フレームサイズに合わせてセル範囲をスケーリングします。
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// 変更されたワークブックを使用する必要があります。
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE 画像をプレゼンテーションのリソースに追加します。
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// OLE オブジェクト フレームを作成します。
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

スケーリング ヘルパーは選択範囲の幅と高さの比率を個別に計算し、列の相対幅と行の相対高さを保持します。計算された寸法はポイントからインチに変換され、[Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) と [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) を使用して適用されます。選択範囲の幅と高さはゼロであってはなりません。

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">セル範囲の期待される幅（ポイント単位）。</param>
/// <param name="height">セル範囲の期待される高さ（ポイント単位）。</param>
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

このプレビュー ヘルパーは [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) を使用してリサイズされた範囲をレンダリングします。[PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) を使用して印刷をその範囲に限定し、余白、ヘッダー、フッターを削除し、先頭に位置付けた PNG ストリームを返します。

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

## **結論**

{{% alert color="info" title="Note" %}}
ワークシートのリサイズ問題を解決するためのアプローチは2つあります。要件やユースケースに最適な方法を選択してください。どちらのアプローチも、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同じように機能します。さらに、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。
{{% /alert %}}

## **よくある質問**

**PowerPoint で最初にアクティブ化されたときに埋め込まれた Excel ワークシートのサイズが変わるのはなぜですか？**

これは、Excel がアクティブ化時に元のウィンドウサイズを維持しようとする一方で、PowerPoint の OLE オブジェクトフレームは独自のサイズを持つために起こります。PowerPoint と Excel がサイズを交渉してアスペクト比を保つため、リサイズが発生することがあります。

**このリサイズ問題を完全に防ぐことは可能ですか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を希望の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

**どちらのスケーリング方法を使用すべきですか、OLE フレームのスケーリングですか、セル範囲のスケーリングですか？**

元の Excel の行・列サイズを維持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーションで OLE フレームのサイズを固定したい場合は **セル範囲のスケーリング** を選択してください。

**プレゼンテーションがテンプレートベースの場合でもこれらのソリューションは機能しますか？**

はい。テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも、両方のソリューションは機能します。

**これらの方法を使用する際、OLE フレームのサイズに制限はありますか？**

いいえ。スケールを適切に設定すれば、OLE オブジェクトフレームを任意のサイズにすることができます。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー テキストを回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定することで、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **関連記事**

[Excel チャートを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)