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
description: "C++ を使用した PowerPoint プレゼンテーションでのワークシートリサイズに対する実装済みソリューション"
---

{{% alert color="primary" %}}

Excel ワークシートを OLE オブジェクトとして Aspose コンポーネント経由で PowerPoint プレゼンテーションに埋め込むと、最初にアクティブ化した後に不明なスケールでサイズが変更されることが確認されています。この動作により、OLE オブジェクトのアクティブ化前後でプレゼンテーションの見た目に顕著な差が生じます。本記事ではこの問題を詳細に調査し、解決策をご紹介します。

{{% /alert %}}

## **背景**

記事 [OLE の管理](/slides/ja/cpp/manage-ole/) で、Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/cpp/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示している OLE オブジェクト フレームをダブルクリックすると Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックで任意の変更を行い、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。スライドに戻ると OLE オブジェクト フレームのサイズが変わります。リサイズの係数は OLE オブジェクト フレームと埋め込まれた Excel ブックのサイズに応じて変わります。

## **リサイズの原因**

Excel ブックは独自のウィンドウサイズを持っているため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームには独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは、Excel ウィンドウサイズと OLE オブジェクト フレームのサイズ・位置の差に基づいて発生します。

## **実装済みの解決策**

リサイズ効果を回避するための 2 つの解決策があります。

- OLE フレームのサイズを PowerPoint プレゼンテーション内で、目的の行数と列数に合わせた高さと幅にスケーリングする。
- OLE フレームのサイズを固定し、対象となる行と列のサイズをスケーリングしてフレーム内に収める。

### **OLE フレーム サイズのスケーリング**

このアプローチでは、埋め込まれた Excel ブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の合計サイズに合わせて設定する方法を学びます。

テンプレート Excel シートがあり、プレゼンテーションに OLE フレームとして追加したいとします。このシナリオでは、まずブック内の対象行の高さと列の幅を合計して OLE オブジェクト フレームのサイズを計算します。その後、計算された値で OLE フレームのサイズを設定します。PowerPoint の OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の画像を取得し、OLE フレーム画像として設定します。
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// ワークブック ファイルが PowerPoint で OLE オブジェクトとして使用されるときの表示サイズを設定します。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 画像の幅と高さをポイント単位で取得します。
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// 修正されたワークブックを使用する必要があります。
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE 画像をプレゼンテーションのリソースに追加します。
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// OLE オブジェクト フレームを作成します。
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


### **セル範囲サイズのスケーリング**

このアプローチでは、対象行の高さと対象列の幅をカスタム OLE フレーム サイズに合わせてスケーリングする方法を学びます。

テンプレート Excel シートがあり、プレゼンテーションに OLE フレームとして追加したいとします。このシナリオでは、まず OLE フレームのサイズを設定し、フレーム領域に参加する行と列のサイズをスケーリングします。その後、ブックをストリームに保存して変更を適用し、OLE フレームに追加するためにバイト配列に変換します。PowerPoint の OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の画像を取得し、OLE フレーム画像として設定します。
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// ワークブック ファイルが PowerPoint で OLE オブジェクトとして使用されるときの表示サイズを設定します。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// セル範囲をフレームサイズに合わせてスケーリングします。
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

```cpp
/// <param name="width">セル範囲の期待幅（ポイント単位）。</param>
/// <param name="height">セル範囲の期待高さ（ポイント単位）。</param>
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


## **結論**

{{% alert color="primary" %}}

ワークシートのリサイズ問題を解決する方法は 2 つあります。どちらのアプローチを選択するかは、具体的な要件とユースケースに依存します。プレゼンテーションがテンプレートから作成された場合でも、ゼロから作成された場合でも、両方の方法は同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。

{{% /alert %}}

## **FAQ**

**埋め込まれた Excel ワークシートは、PowerPoint で最初にアクティブ化するとサイズが変わるのはなぜですか？**

Excel はアクティブ化時に元のウィンドウサイズを保持しようとし、PowerPoint の OLE オブジェクト フレームは独自の寸法を持っています。PowerPoint と Excel がサイズを協議してアスペクト比を保つため、リサイズが発生します。

**このリサイズ問題を完全に防ぐことはできますか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

**どちらのスケーリング方法を選べばよいですか、OLE フレーム スケーリングですかセル範囲 スケーリングですか？**

元の Excel の行・列サイズを保持したい場合は **OLE フレーム スケーリング** を選択してください。プレゼンテーション内で OLE フレームのサイズを固定したい場合は **セル範囲 スケーリング** を選択してください。

**テンプレートをベースにしたプレゼンテーションでもこれらの解決策は機能しますか？**

はい。両方の解決策はテンプレートから作成されたプレゼンテーションでも、ゼロから作成されたプレゼンテーションでも機能します。

**これらの方法を使用した場合、OLE フレームのサイズに制限はありますか？**

いいえ。スケールを適切に設定すれば、OLE オブジェクト フレームは任意のサイズにできます。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー文字列を回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、プレースホルダー画像として設定すれば、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **関連記事**

[Excel グラフを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)