---
title: PPTX のチャートリサイズに関する実装済み解決策
type: docs
weight: 40
url: /ja/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートリサイズ
- Excel チャート
- OLE オブジェクト
- チャート埋め込み
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java で埋め込み Excel OLE オブジェクトを使用する際の PPTX の予期せぬチャートリサイズを修正します。固定チャート寸法を設定して、チャートと OLE フレームのサイズを一致させます。"
---
## **概要**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel チャートは、最初にアクティブ化された後にサイズが変わることがあります。このため、アクティブ化前後でチャートの外観に目立つ違いが生じます。本稿ではサイズ変更が発生する理由を説明し、固定チャートサイズを OLE フレームに合わせることでそれを防止する方法を示します。

[プレゼンテーションに OLE オブジェクトとして埋め込み Excel チャートを作成する](/slides/ja/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for PHP via Java で Excel チャートを作成し、Aspose.Slides for PHP via Java で PowerPoint プレゼンテーションに埋め込む方法を解説しました。[オブジェクトプレビューの問題](/slides/ja/php-java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、チャート画像をチャートの OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、チャート画像が表示されている OLE オブジェクトフレームをダブルクリックすると Excel チャートがアクティブ化されます。ユーザーは埋め込まれた Excel ワークブックを編集でき、アクティブ化されたワークブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わり、リサイズ倍率は OLE オブジェクトフレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **サイズ変更の原因**

埋め込まれた Excel ワークブックは独自のウィンドウサイズを持ち、オブジェクトが最初にアクティブ化されたときに Excel はそのサイズを保持しようとします。スライド上の OLE フレームは別個に定義されたサイズを持ちます。Excel ワークブックがアクティブになると、Excel と PowerPoint は埋め込みプロセスの一環としてオブジェクトのサイズを協議し、比例を保つようにします。ワークブックウィンドウと OLE フレームのサイズ差がオブジェクトのリサイズを引き起こす原因となります。

## **実装済みの解決策**

スライド上の OLE フレームにチャートサイズを合わせ、チャートの寸法をワークブックウィンドウから独立させます。この解決策は新規プレゼンテーションでも既存のテンプレートでも機能します。

このサンプルには Aspose.Cells for PHP via Java と Aspose.Slides for PHP via Java が必要です。両方の製品を同じ PHP/Java Bridge インスタンスで構成し、両方の PHP ラッパーをロードし、両方の Java ライブラリをブリッジで利用可能にします。入力ファイルは不要です。アクティブなチャートシートにシンプルな縦棒グラフを作成し、ワークブックを XLS 形式で埋め込みます。チャートプレビュー画像は割り当てず、PowerPoint で OLE オブジェクトがアクティブ化されたときにチャートが表示されます。

サンプルは左端から 0.5 インチ、上端から 1 インチの位置に 9.5 × 4 インチの OLE フレームを持つ新規プレゼンテーションを作成します。スライド座標とサイズはポイント単位（1 インチ＝72 ポイント）です。既存のプレゼンテーションについては、[テンプレートの使用](#use-a-template) を参照してください。

## **固定チャートサイズの設定**

[Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) を false に設定して、チャートの寸法がワークブックウィンドウに依存しないようにします。[Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) の寸法は [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) と [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height) を使って設定し、ポイントを 1 インチ 96 ピクセルでピクセルに変換します。たとえば 684 × 288 ポイントのフレームは 912 × 384 ピクセルのチャートに相当します。[Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) を [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/) の CUSTOM 値に設定します。サンプルは [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) を使ってワークブックを埋め込み、9.5 × 4 インチの OLE フレームを持つプレゼンテーションを保存します。

Java の数値結果は `java_values` で変換され、PHP のインデックスとして使用される前に処理されます。ワークブックのバイト列は Java のバイト配列のまま [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) に渡されます。

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライドの座標とサイズはポイント単位です（1インチ = 72 ポイント）。
        $width = 684; // 9.5 インチ。
        $height = 288; // 4 インチ。

        $chart->setSizeWithWindow(false);
        // ポイントを 1インチ 96 ピクセルでチャートピクセルに変換します。
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **テンプレートの使用**

既存のプレゼンテーションでも同じサイズロジックが適用されます。サンプルを適用する手順は次のとおりです。

1. 空のプレゼンテーションを作成する代わりに、テンプレートプレゼンテーションをロードします。
2. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用します。
3. 固定値 684 と 288 を使用する代わりに、そのシェイプからフレームの幅と高さを取得します。サイズ計算は変更しません。
4. 固定座標 36 と 72 を使うのではなく、プレースホルダーの位置に OLE フレームを追加します。
5. プレゼンテーションを保存する前にプレースホルダーを削除します。

## **よくある質問**

**PowerPoint で埋め込んだ Excel チャートをアクティブ化した後にサイズが変わるのはなぜですか？**

Excel が最初にアクティブ化されたときに元のウィンドウサイズを復元しようとし、PowerPoint の OLE オブジェクトフレームは独自のサイズを持つためです。PowerPoint と Excel がアスペクト比を保つためにサイズを協議し、結果としてリサイズが発生します。

**チャートと OLE フレームのサイズを一致させるにはどうすればよいですか？**

OLE フレームに合わせた固定チャートサイズを設定し、ワークブックを埋め込む前にカスタムのチャート印刷サイズを使用します。上記のサンプルに必要な設定と単位変換の例が示されています。

**ワークブックウィンドウのサイズを合わせるだけで十分ですか？**

ワークブックウィンドウのサイズを合わせるだけでは、アクティブ化後に OLE フレームのサイズ変更を確実に防げません。サンプルに示すように固定チャートサイズを使用してください。

**この解決策はテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**

はい。テンプレートの場合はプレースホルダーの寸法と位置を使用し、新規プレゼンテーションの場合はフレームの寸法と位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこのサンプルを使用できますか？**

本サンプルは Aspose.Cells で作成した Excel ワークブックを使用しています。他のスプレッドシートプログラムでのアクティブ化動作は示していません。

## **関連セクション**

- [プレゼンテーションに OLE オブジェクトとして埋め込み Excel チャートを作成する](/slides/ja/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)