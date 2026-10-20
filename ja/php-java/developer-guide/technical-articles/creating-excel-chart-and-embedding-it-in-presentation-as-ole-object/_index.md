---
title: Excelチャートを作成し、OLEオブジェクトとしてプレゼンテーションに埋め込む
type: docs
weight: 30
url: /ja/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excelチャート
- チャートを埋め込む
- OLEオブジェクト
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Cells for PHP via Java を使用して Excel チャートを作成し、Aspose.Slides for PHP via Java を使用してブックを PowerPoint プレゼンテーションに埋め込み、チャートのプレビューを含めます。"
---
## **概要**

この記事では、Aspose.Cells for PHP via Java を使用して Excel の縦棒グラフを作成し、Aspose.Slides for PHP via Java を使用してそのブックを PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたブックには元データとグラフの両方が含まれます。OLE オブジェクトがアクティブになる前に、スライド上にグラフを表示する PNG プレビューが別途表示されます。

結果はネイティブな PowerPoint グラフではなく、埋め込み Excel オブジェクトです。OLE 経由でブックを編集するには、OLE のアクティベーションをサポートし、互換性のある Excel がインストールされたデスクトップ アプリケーションが必要です。

## **前提条件**

Aspose.Cells for PHP via Java と Aspose.Slides for PHP via Java を同一の PHP/Java Bridge インスタンスで構成します。両方の PHP ラッパーをロードし、両製品の Java ライブラリをブリッジで利用できるようにします。Microsoft Office は、これらのライブラリを使用してプレゼンテーションを生成するために必要ありません。

入力ファイルは不要です。サンプルはデータとチャートをメモリ内で作成し、`OutputChart.pptx` を現在の作業ディレクトリに書き出します。評価モード以外で実行する場合は、両製品のライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つブックを作成します。
2. ブックがチャートで開くように、チャート シートをアクティブにします。
3. ブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
4. ブックをメモリ内で XLSX として保存し、そのバイト列をスライドに埋め込みます。
5. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ブックの表示範囲とスライド上のフレームは異なる役割を持ちます。[WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) はゼロベースの開始/終了行・列インデックスを受け取ります。一方、[ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) は上端行、左端列、下端行、右端列を指定します。サンプルでは下右端の境界として行インデックス 55 と列インデックス 25 を使用していますが、これらの値はレイアウト上の選択であり、データ行や列の数を表すものではありません。

スライドのフレームはポイント単位です。サンプルではスライド内に収めて中央に配置し、PNG のアスペクト比を保持したままプレビューがスライド全体に伸びないようにしています。

## **チャートの作成と埋め込み**

以下の完全なサンプルは、`DataSheet` に 4 行 5 列の値を設定します。各行がチャート系列になります。ブックを保存する前に、`ChartSheet` をアクティブ シートとして選択します。

ブックは明示的に XLSX として保存され、[OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) に渡された `xlsx` 拡張子と一致します。Java の数値結果は PHP が演算を行う前に `java_values` で変換され、バイナリ データは Java のバイト配列のままです。PNG は中間のビットマップ変換を行わずにバイトから直接読み込まれます。[OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を介して割り当てることで、デフォルトの OLE プレースホルダーが置き換えられます。

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Slides に渡す際、PNG と XLSX を Java のバイト配列として保持します。
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // プレビューのアスペクト比を保持しつつ、サイズ合わせと中央寄せを行います。
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **期待結果**

`OutputChart.pptx` には埋め込み Excel ブックとチャート プレビューを含む 1 枚のスライドが入っています。ブックには元のデータと 4 系列の縦棒グラフが含まれます。プレビューはスライドの中央に配置され、比例が保たれます。

![埋め込みブックのプレビューとして表示された Excel 縦棒チャート](excel-chart-ole-preview.png)

Excel が利用可能な互換性のあるデスクトップ PowerPoint 環境では、オブジェクトをダブルクリックして埋め込みブックをアクティブ化および編集できます。アクティブ化と編集は、ホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **よくある質問**

**プレビュー画像が必要な理由は何ですか？**

埋め込みブックとスライド上のプレビューは別々のコンテンツです。デフォルトの「EMBEDDED OLE OBJECT」プレースホルダーの代わりにチャート画像を提供し、スライドにチャートを表示させます。詳細は[OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/php-java/object-preview-issue-when-adding-oleobjectframe/)をご覧ください。

**コードでブックを変更したときにプレビューは自動的に更新されますか？**

プレビューはスナップショットとして扱ってください。プログラムでブックのデータを更新する場合は、チャート画像を再生成し、プレビューと埋め込みブック データの両方を置き換える必要があります。

**XLS を使用できますか？**

はい。ブックを XLS 形式で保存し、埋め込みデータの拡張子として `xls` を使用します。拡張子は実際のブック形式と一致している必要があり、拡張子だけを変更してもデータは変換されません。

**アクティブ化後にオブジェクトのサイズが変わる理由は何ですか？**

ホスト アプリケーションはブックをアクティブ化するときに OLE オブジェクトの表示を更新することがあります。ブックの OLE 表示範囲とスライド フレームのサイズの両方が影響します。詳細は[PPTX におけるチャート サイズ変更の実装例](/slides/ja/java/working-solution-for-chart-resizing-in-pptx/)をご覧ください。

## **関連セクション**

- [PPTX におけるチャート サイズ変更の実装例](/slides/ja/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE オブジェクトの管理](/slides/ja/php-java/manage-ole/)