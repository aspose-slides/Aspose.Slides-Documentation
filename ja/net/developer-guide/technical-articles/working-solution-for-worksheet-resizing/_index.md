---
title: ワークシートリサイズに対する実装ソリューション
type: docs
weight: 40
url: /ja/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "プレゼンテーションで Excel ワークシート OLE のリサイズを修正: オブジェクトフレームを一貫させる2つの方法―フレームをスケーリングするかシートをスケーリングするか―PPT と PPTX 形式に対応。"
---

{{% alert color="primary" %}}
Excel ワークシートが Aspose コンポーネントを介して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれると、最初のアクティベート後に未特定のスケールにリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティベート前後でプレゼンテーションに目立つ視覚的差異が生じます。本記事ではこの問題を詳細に調査し、解決策を提供しています。
{{% /alert %}}

## **背景**

記事[OLE の管理](/slides/ja/net/manage-ole/)では、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/)に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示する OLE オブジェクトフレームをダブルクリックすると Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックに任意の変更を加え、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ることができます。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ率は OLE オブジェクトフレームと埋め込まれた Excel ブックのサイズに応じて変わります。

## **リサイズの原因**

Excel ブックは独自のウィンドウサイズを持っているため、最初のアクティベーション時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームには独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは、Excel ウィンドウサイズと OLE オブジェクトフレームのサイズ・位置の差に基づいて発生します。

## **実装ソリューション**

リサイズ効果を回避するための2つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームサイズを、OLE フレーム内で必要な行数と列数の高さと幅に合わせてスケーリングする。
- OLE フレームサイズを固定したまま、対象となる行と列のサイズをスケーリングして選択した OLE フレームサイズに収める。

### **OLE フレームサイズのスケーリング**

このアプローチでは、埋め込まれた Excel ワークブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の合計サイズに合わせて設定する方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まずブック内の対象行と列の合計行高さと列幅に基づいて OLE オブジェクトフレームのサイズを計算します。その後、計算した値を OLE フレームのサイズとして設定します。PowerPoint で OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の必要な部分の画像を取得し、OLE フレームの画像として設定します。
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


### **セル範囲サイズのスケーリング**

このアプローチでは、対象となる行の高さと列の幅をスケーリングして、カスタム OLE フレームサイズに合わせる方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLE フレームのサイズを設定し、対象となる行と列のサイズをスケーリングして OLE フレーム領域に合わせます。その後、変更を適用するためにブックをストリームに保存し、OLE フレームに追加するためにバイト配列に変換します。PowerPoint で OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の必要な部分の画像を取得し、OLE フレームの画像として設定します。
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// ワークブック ファイルが PowerPoint で OLE オブジェクトとして使用される際の表示サイズを設定します。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// フレームサイズに合わせてセル範囲をスケーリングします。
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 修正したワークブックを使用する必要があります。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// プレゼンテーションのリソースに OLE 画像を追加します。
var oleImage = presentation.Images.AddImage(imageStream);

// OLE オブジェクト フレームを作成します。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">セル範囲の幅（ポイント）の期待値。</param>
/// <param name="height">セル範囲の高さ（ポイント）の期待値。</param>
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


## **結論**
{{% alert color="primary" %}}
ワークシートのリサイズ問題を解決するためのアプローチは2つあります。適切なアプローチの選択は、具体的な要件と使用ケースに依存します。テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも、両方のアプローチは同様に機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。
{{% /alert %}}

## よくある質問

**Q: なぜ埋め込まれた Excel ワークシートは PowerPoint で最初にアクティブ化されるとサイズが変わるのですか？**  
これは、Excel がアクティブ化時に元のウィンドウサイズを維持しようとし、PowerPoint の OLE オブジェクトフレームは独自の寸法を持つためです。PowerPoint と Excel がサイズを協議してアスペクト比を保つことで、リサイズが発生することがあります。

**Q: このリサイズ問題を完全に防止することは可能ですか？**  
はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を希望の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

**Q: どちらのスケーリング手法を使用すべきですか、OLE フレームのスケーリングですかセル範囲のスケーリングですか？**  
プレゼンテーションで元の Excel 行と列のサイズを維持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーション内で OLE フレームのサイズを固定したい場合は **セル範囲のスケーリング** を選択してください。

**Q: プレゼンテーションがテンプレートベースの場合でもこれらの解決策は機能しますか？**  
はい。これらのソリューションはテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**Q: これらの方法を使用する際に OLE フレームのサイズに制限はありますか？**  
いいえ。スケールを適切に設定すれば、OLE オブジェクトフレームは任意のサイズに設定可能です。

**Q: PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー文字列を回避する方法はありますか？**  
はい。対象の Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダーではなくカスタムのプレビュー画像を表示できます。

## **関連記事**

[Excel グラフを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint アドインを使用して OLE オブジェクトを自動的に更新する](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)