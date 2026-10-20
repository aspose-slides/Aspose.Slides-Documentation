---
title: PPTX のチャートサイズ変更に関する実用的解決策
type: docs
weight: 40
url: /ja/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートサイズ変更
- Excel チャート
- OLE オブジェクト
- チャート埋め込み
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して埋め込み Excel OLE オブジェクトを利用する際に、PPTX で発生する予期せぬチャートサイズ変更を修正します。チャートと OLE フレームのサイズを一致させるために、固定チャート寸法を設定します。"
---
## **概要**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel チャートは、最初にアクティブ化された後にサイズが変わることがあります。これにより、アクティブ化前後でチャートの外観に目立つ差が生じます。本記事では、サイズ変更が発生する理由を説明し、固定チャートサイズと OLE フレームを一致させることで防止する方法を示します。

「[Excelチャートを作成し、OLEオブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)」では、Aspose.Cells for Node.js via Java を使用して Excel チャートを作成し、Aspose.Slides for Node.js via Java を使用して PowerPoint プレゼンテーションに埋め込む方法を説明しました。「[オブジェクト プレビューの問題](/slides/ja/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)」に対処するため、チャート画像をチャートの OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションでは、チャート画像を表示する OLE オブジェクト フレームをダブルクリックすると Excel チャートがアクティブ化されます。ユーザーは埋め込まれた Excel ワークブックを編集でき、アクティブ化されたワークブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わり、リサイズ係数は OLE オブジェクト フレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **サイズ変更の原因**

埋め込まれた Excel ワークブックは独自のウィンドウサイズを持ち、オブジェクトが最初にアクティブ化される際に Excel がそのサイズを保持しようとします。一方、スライド上の OLE フレームは別個に定義されたサイズを持ちます。Excel ワークブックがアクティブ化されると、Excel と PowerPoint がオブジェクトのサイズを協調して、埋め込みプロセスの一部として比例を保つように交渉します。ワークブック ウィンドウと OLE フレームのサイズ差がオブジェクトのリサイズを引き起こす原因となります。

## **実装できるソリューション**

チャートのサイズをスライド上の OLE フレームに合わせ、チャートの寸法をワークブック ウィンドウから独立させます。このソリューションは新規プレゼンテーションでも既存テンプレートでも機能します。

この例は Aspose.Cells for Node.js via Java と Aspose.Slides for Node.js via Java が必要です。`aspose.cells`、`aspose.slides.via.java`、`java` の Node.js パッケージをインストールしてください。両方の Aspose パッケージがロード時に Java ブリッジを初期化するため、同じ作業ディレクトリで別々の Node.js プロセスとして以下の 2 つの CommonJS スクリプトを実行します。スクリプトはアクティブなチャートシートにシンプルな縦棒グラフを作成し、XLS 形式でワークブックを埋め込みます。チャートのプレビュー画像は割り当てず、PowerPoint で OLE オブジェクトがアクティブ化されたときにチャートが表示されます。

例は左端から 0.5 インチ、上端から 1 インチの位置に、9.5 × 4 インチの OLE フレームを作成します。スライド座標とサイズはポイント単位（1 インチ = 72 ポイント）です。既存プレゼンテーションの場合は、[テンプレートの使用](#use-a-template) を参照してください。

## **固定チャートサイズの設定**

`[setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow)` を false に設定し、チャート寸法をワークブック ウィンドウから独立させます。`[getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject)` のサイズは `[setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth)` と `[setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight)` で設定し、96 ピクセル/インチでポイントからピクセルに変換します。たとえばフレームが 684 × 288 ポイントの場合、チャートは 912 × 384 ピクセルに相当します。`[setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize)` を `PrintSizeType` の CUSTOM 値に設定します。例では `[addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame)` を使用してワークブックを埋め込み、9.5 × 4 インチの OLE フレームでプレゼンテーションを保存します。

この最初のスクリプトを `create-fixed-chart.js` として保存します。スクリプトは `chart-fixed-size.xls` を作成し、チャートは 912 × 384 ピクセルで、2 番目のスクリプトで使用する 684 × 288 ポイントのフレームに一致します。入力用ワークブックは不要です。

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // ポイント単位（1インチ=72ポイント）で OLE フレームのサイズと一致させます。
    const width = 684; // 9.5 インチ。
    const height = 288; // 4 インチ。

    chart.setSizeWithWindow(false);
    // ポイントを 1インチ=96 ピクセル の比率でチャートのピクセルに変換します。
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// すべての同期処理が完了しました。Java ブリッジプロセスを停止します。
process.exit(0);
```

2 番目のスクリプトを `embed-fixed-chart.js` として保存し、`create-fixed-chart.js` の実行後に実行します。生成された XLS ワークブックを読み込み、`chart-fixed-size.pptx` として保存します。Java ブリッジはワークブック データ用に明示的な Java バイト配列を、フレーム座標とサイズ用に Java の float 値を必要とします。`xls` 拡張子はワークブックの保存形式に対応しています。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // スライドの座標とサイズはポイント単位（1インチ=72ポイント）です。
    const width = 684; // 9.5 インチ。
    const height = 288; // 4 インチ。
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// すべての同期作業が完了しました。Java ブリッジプロセスを停止します。
process.exit(0);
```

## **テンプレートの使用**

既存プレゼンテーションでも同じサイズロジックを適用できます。例を適応する手順は次のとおりです。

1. 空のプレゼンテーションを作成する代わりにテンプレート プレゼンテーションをロードします。
1. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用します。
1. 固定値 684 と 288 の代わりに、そのシェイプからフレームの幅と高さを取得します。同じ寸法をワークブック作成スクリプトで使用し、サイズ計算は変更せずに XLS ワークブックを再生成してから埋め込みます。
1. 固定座標 36 と 72 の代わりに、プレースホルダーの位置に OLE フレームを追加します。
1. プレゼンテーションを保存する前にプレースホルダーを削除します。

## **よくある質問**

**PowerPoint でアクティブ化した後、埋め込まれた Excel チャートのサイズが変わるのはなぜですか？**

Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクト フレームは独自のサイズを持っています。PowerPoint と Excel がアスペクト比を保つようにサイズを協議するため、リサイズが発生します。

**チャートと OLE フレームのサイズを一致させるにはどうすればよいですか？**

固定チャートサイズを設定し、OLE フレームに合わせたカスタム印刷サイズを使用してワークブックを埋め込みます。上記の例が必要な設定と単位変換を示しています。

**ワークブック ウィンドウのサイズを合わせるだけで十分ですか？**

ワークブック ウィンドウのサイズを合わせるだけでは、アクティブ化後に OLE フレームのサイズ変更を確実に防げません。例に示すように固定チャートサイズを使用してください。

**このソリューションはテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**

はい。テンプレートの場合はプレースホルダーの寸法と位置を使用し、新規プレゼンテーションの場合はフレームの寸法と位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこの例を使用できますか？**

この例は Aspose.Cells で作成した Excel ワークブックを使用しています。他のスプレッドシートプログラムでのアクティベーション動作は示していません。

## **関連セクション**

- [Excelチャートを作成し、OLEオブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)