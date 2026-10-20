---
title: ワークシートサイズ変更の実装ソリューション
type: docs
weight: 20
url: /ja/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "プレゼンテーションでの Excel ワークシート OLE サイズ変更を修正します。オブジェクトフレームを一貫させる方法は 2 つあり、フレームをスケールするかシートをスケールするかで、PPT と PPTX の両形式に対応します。"
---
{{% alert color="info" title="Note" %}}

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初にアクティブ化された後に予期せずサイズが変更されることがあります。この動作により、OLE オブジェクトのアクティブ化前後で目に見える視覚的差異が生じます。本記事ではこの問題を説明し、対処方法を 2 つ紹介します。

{{% /alert %}}

## **背景**

[OLE の管理](/slides/ja/php-java/manage-ole/) の記事では、Aspose.Slides for PHP via Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を解説しました。[オブジェクト プレビューの問題](/slides/ja/php-java/object-preview-issue-when-adding-oleobjectframe/) に対応するため、選択したワークシート領域の画像を OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示している OLE オブジェクト フレームをダブルクリックすると Excel ブックがアクティブ化されます。エンド ユーザーは実際の Excel ブックで任意の変更を行い、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わります。リサイズ係数は OLE オブジェクト フレームのサイズと埋め込まれた Excel ブックのサイズに応じて変わります。

## **サイズ変更の原因**

Excel ブックには独自のウィンドウサイズがあるため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームにも独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを交渉し、埋め込みプロセスの一環として正しい比率を保つようにします。リサイズは Excel ウィンドウサイズと OLE オブジェクト フレームのサイズおよび位置の差異に基づいて発生します。

## **実装ソリューション**

サイズ変更の影響を回避するための 2 つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の合計高さ・幅に合わせてスケーリングする。
- OLE フレームのサイズを固定し、選択した行と列をフレーム内に収まるようにスケーリングする。

### **OLEフレームサイズのスケーリング**

このアプローチは、埋め込まれた Excel ワークシートの選択した行と列の合計高さ・幅に合わせて OLE フレームのサイズを設定します。

例では既存の Excel ブックを読み込み、0 ベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) が表示範囲を定義します。プレビューは 96 DPI でレンダリングされ、ピクセル寸法は 1 インチあたり 72 ポイントに変換されます。[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) がその寸法でフレームに変更されたブックを埋め込みます。プレビューは [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を介して割り当てられ、保存されたプレゼンテーションの「EMBEDDED OLE OBJECT」プレースホルダーを置き換えます。

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // 変更したワークブックを埋め込み、Java のバイト配列にバイナリ データを保持します。
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

プレビュー ヘルパーは [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) を選択範囲に設定し、余白、ヘッダー、フッターを削除します。[ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) を有効にすると、[SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) が範囲を PNG 画像としてレンダリングします。ヘルパーは PNG 画像を含む新しい入力ストリームを返し、プレゼンテーションで使用できるよう先頭に配置します。

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **セル範囲サイズのスケーリング**

このアプローチは、選択した行の高さと列の幅をカスタム OLE フレーム サイズに合わせてスケーリングします。

例では既存の Excel ブックを読み込み、0 ベースのインデックスで最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) が表示範囲を定義し、以下のヘルパーがその範囲を幅 400 ポイント・高さ 100 ポイントのフレームに収まるようスケーリングします。変更されたブックをストリームに保存した後、[ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) が指定サイズで埋め込みます。96 DPI でレンダリングされたプレビューは [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を介して割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーの代わりに選択したセルを表示します。

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // 変更したワークブックを埋め込み、Java のバイト配列にバイナリ データを保持します。
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

スケーリング ヘルパーは選択範囲の幅と高さの比率を個別に計算し、列の相対幅と行の相対高さを保持します。計算された寸法はポイントからインチに変換され、[Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) と [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) で適用されます。選択範囲の幅と高さは 0 であってはなりません。

```php
use aspose\cells\CellsUnitType;

// Width and height are the expected dimensions of the cell range in points.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

このプレビュー ヘルパーは [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) を使用してリサイズされた範囲をレンダリングします。[PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) をその範囲に限定し、余白、ヘッダー、フッターを削除し、PNG ストリームを先頭に配置して返します。

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **結論**

{{% alert color="info" title="Note" %}}

ワークシートのサイズ変更問題を解決する方法は 2 つあります。要件とユースケースに最適なアプローチを選んでください。どちらのアプローチもテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。

{{% /alert %}}

## **よくある質問**

**埋め込まれた Excel ワークシートは、PowerPoint で最初にアクティブ化されたときにサイズが変わるのはなぜですか？**

Excel はアクティブ化時に元のウィンドウサイズを維持しようとし、PowerPoint の OLE オブジェクト フレームは独自の寸法を持っているためです。PowerPoint と Excel がサイズを交渉してアスペクト比を保つため、リサイズが発生します。

**このサイズ変更問題を完全に防ぐことはできますか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を希望の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防げます。

**どちらのスケーリング方法を使用すべきですか、OLE フレームのスケーリングですか、セル範囲のスケーリングですか？**

元の Excel の行と列のサイズを保持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーションで OLE フレームのサイズを固定したい場合は **セル範囲のスケーリング** を選択してください。

**テンプレートに基づくプレゼンテーションでもこれらの解決策は機能しますか？**

はい。両方の解決策はテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**これらの方法を使用する際、OLE フレームのサイズに制限はありますか？**

いいえ。適切にスケールを設定すれば、OLE オブジェクト フレームのサイズに制限はありません。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー テキストを回避する方法はありますか？**

はい。対象となる Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定することで、デフォルトのプレースホルダーの代わりにカスタム プレビュー画像を表示できます。

## **関連記事**

[Excel グラフを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint アドインを使用して OLE オブジェクトを自動的に更新する](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)