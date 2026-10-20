---
title: ワークシートのリサイズに関する実装ソリューション
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
description: "プレゼンテーション内の Excel ワークシート OLE リサイズを修正します：オブジェクト フレームの一貫性を保つための 2 つの方法—フレームをスケールするかシートをスケールするか—を PPT および PPTX 形式で提供します。"
---
{{% alert color="info" title="Note" %}}
Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初に有効化された後に予期せずサイズが変更されることがあります。この動作により、OLE オブジェクトの有効化前後で目に見える違いが生じます。本記事ではこの問題を説明し、対処方法を 2 つ紹介します。
{{% /alert %}} 

## **Background**

記事 [Manage OLE](/slides/ja/net/manage-ole/) では、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[object preview issue](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示する OLE オブジェクト フレームをダブルクリックすると、Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックで任意の変更を行い、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わります。リサイズの度合いは OLE オブジェクト フレームと埋め込まれた Excel ブックのサイズに依存します。

## **Cause of Resizing**

Excel ブックは独自のウィンドウサイズを持っているため、最初にアクティブ化されたときに元のサイズを保持しようとします。一方、OLE オブジェクト フレームには独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを調整し、埋め込みプロセスの一部として正しい比率を保つように交渉します。リサイズは Excel ウィンドウサイズと OLE オブジェクト フレームのサイズおよび位置の差に基づいて発生します。

## **Working Solution**

リサイズ効果を回避するための 2 つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の合計高さと幅に合わせてスケーリングする。
- OLE フレームのサイズを固定し、選択した行と列をその中に収まるようにスケーリングする。

### **Scale the OLE Frame Size**

このアプローチは、埋め込まれた Excel ワークシート内の選択された行と列の合計高さと幅に合わせて OLE フレームのサイズを設定します。

この例は、既存の Excel ブックをロードし、ゼロベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) は表示範囲を定義します。プレビューは 96 DPI でレンダリングされ、そのピクセル寸法は 1 インチ 72 ポイントでポイントに変換されます。[ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) は、変更されたブックをそれらの寸法のフレームに埋め込みます。プレビューは [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) を通じて割り当てられ、保存されたプレゼンテーションの "EMBEDDED OLE OBJECT" プレースホルダーを置き換えます。

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

プレビュー ヘルパーは、選択された範囲に対して [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) を設定し、余白、ヘッダー、フッターを削除します。[ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) を有効にすると、[SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) が範囲を PNG 画像としてレンダリングします。ヘルパーは画像ストリームを巻き戻し、プレゼンテーションで使用できるように返します。

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

### **Scale the Cell Range Size**

このアプローチは、選択された行の高さと列の幅をスケーリングして、カスタム OLE フレームサイズに合わせます。

この例は、既存の Excel ブックをロードし、ゼロベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) は表示範囲を定義し、以下のヘルパーはその範囲を幅 400 ポイント、高さ 100 ポイントのフレームに合わせてスケーリングします。変更されたブックをストリームに保存した後、[ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) が指定サイズで埋め込みます。96 DPI でレンダリングされたプレビューは [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) を介して割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーではなく選択されたセルを表示します。

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

// PowerPoint でワークブック ファイルが OLE オブジェクトとして使用されるときの表示サイズを設定します。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// フレームサイズに合わせてセル範囲のスケールを調整します。
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 変更されたワークブックを使用する必要があります。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE 画像をプレゼンテーションのリソースに追加します。
var oleImage = presentation.Images.AddImage(imageStream);

// OLE オブジェクト フレームを作成します。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

スケーリング ヘルパーは、選択された範囲の幅と高さの比率を個別に計算し、列の相対幅と行の相対高さを保持します。計算された寸法をポイントからインチに変換し、[Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) および [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) で適用します。選択された範囲は幅と高さがゼロであってはなりません。

```cs
/// <param name="width">セル範囲の期待される幅（ポイント単位）。</param>
/// <param name="height">セル範囲の期待される高さ（ポイント単位）。</param>
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

このプレビュー ヘルパーは、[SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) を使用してリサイズされた範囲をレンダリングします。[PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) をその範囲に限定し、余白、ヘッダー、フッターを削除し、先頭に位置付けられた PNG ストリームを返します。

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
ワークシートのリサイズ問題を解決するための 2 つのアプローチがあります。要件やユースケースに最適な方法を選択してください。どちらのアプローチも、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。さらに、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。
{{% /alert %}}

## **FAQ**

**なぜ埋め込まれた Excel ワークシートは PowerPoint で最初にアクティブ化されたときにサイズが変わるのですか？**  
これは、Excel がアクティブ化時に元のウィンドウサイズを保持しようとし、PowerPoint の OLE オブジェクト フレームは独自の寸法を持っているために起こります。PowerPoint と Excel がサイズを交渉してアスペクト比を維持するため、リサイズが発生することがあります。

**このリサイズ問題を完全に防ぐことは可能ですか？**  
はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

**どのスケーリング方法を使用すべきですか、OLE フレーム スケーリングですかセル範囲 スケーリングですか？**  
元の Excel の行と列のサイズを維持したい場合は **OLE フレーム スケーリング** を選択してください。プレゼンテーションで OLE フレームを固定サイズにしたい場合は **セル範囲 スケーリング** を選択してください。

**プレゼンテーションがテンプレートベースの場合でも、これらの解決策は機能しますか？**  
はい。どちらの解決策もテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**これらの方法を使用する場合、OLE フレームのサイズに制限はありますか？**  
いいえ。適切にスケールを設定すれば、OLE オブジェクト フレームは任意のサイズにできます。

**PowerPoint の "EMBEDDED OLE OBJECT" プレースホルダー テキストを回避する方法はありますか？**  
はい。対象の Excel セル範囲のスナップショットを取得し、それを OLE フレームのプレースホルダー画像として設定することで、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **Related Articles**

[Excel チャートの作成と OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint アドインを使用した OLE オブジェクトの自動更新](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)