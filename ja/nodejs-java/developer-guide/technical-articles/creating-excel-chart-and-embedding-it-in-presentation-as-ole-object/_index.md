---
title: Excel グラフを作成し、プレゼンテーションに OLE オブジェクトとして埋め込む
type: docs
weight: 30
url: /ja/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel グラフ
- チャートを埋め込む
- OLE オブジェクト
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Cells for Node.js via Java を使用して Excel グラフを作成し、Aspose.Slides を使用して PowerPoint プレゼンテーションにワークブックを埋め込み、チャートのプレビューも含めます。"
---
## **概要**

この記事では、Aspose.Cells for Node.js via Java を使用して Excel の縦棒グラフを作成し、Aspose.Slides for Node.js via Java を使用してそのワークブックを PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたワークブックには、元データとグラフの両方が含まれます。別個の PNG プレビューが、OLE オブジェクトがアクティブになる前にスライド上にグラフを表示します。

結果はネイティブな PowerPoint グラフではなく、埋め込まれた Excel オブジェクトです。OLE を介してワークブックを編集するには、OLE のアクティベーションをサポートし、互換性のある Excel がインストールされたデスクトップアプリケーションが必要です。

## **前提条件**

`aspose.cells`、`aspose.slides.via.java`、および `java` の Node.js パッケージをインストールします。例は 2 つの CommonJS スクリプトとして別々の Node.js プロセスで実行します：最初に `create-chart.js`、次に `embed-chart.js` を同じ作業ディレクトリで実行します。両方の Aspose パッケージはロード時に Java ブリッジを初期化するため、これらの例ではプロセスを分けています。これらのライブラリを使用してプレゼンテーションを生成するには Microsoft Office は不要です。

既存のワークブックや画像は必要ありません。最初のスクリプトは `ChartWorkbook.xlsx` と `ChartPreview.png` を作成し、2 番目のスクリプトはそれらのファイルを読み取って `OutputChart.pptx` を現在の作業ディレクトリに書き出します。評価モード外で実行する場合は、両製品のライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つワークブックを作成します。
2. チャート シートをアクティブにし、ワークブックがチャート上で開くようにします。
3. ワークブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
4. ワークブックを XLSX として保存し、そのバイト列を別々の Node.js プロセス内のスライドに埋め込みます。
5. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ワークブックの表示範囲とスライド上のフレームは異なる役割を持ちます。[setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) はゼロベースの開始/終了行・列インデックスを受け取ります。[ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) は代わりに上端行、左端列、下端行、右端列を受け取ります。例では下右境界として行インデックス 55 と列インデックス 25 を使用していますが、これらの値はレイアウトの選択であり、データ行や列の数を表すものではありません。

スライドのフレームはポイント単位です。例ではフレームをスライド内に収め、PNG のアスペクト比を保持したまま中央に配置しています。プレビューをスライド全体に引き伸ばすことはありません。

## **チャートの作成と埋め込み**

最初の例を `create-chart.js` として保存します。`DataSheet` に 4 行 5 列の値を設定します。各行がチャートの系列となります。ワークブックを保存する前に `ChartSheet` をアクティブ シートとして選択します。

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // チャートのプレビューをレンダリングし、編集可能なワークブックを別々にシリアライズします。
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// すべての同期処理が完了しました。Java ブリッジプロセスを停止します。
process.exit(0);
```

以下の例を `embed-chart.js` として保存します。`create-chart.js` が両方の入力ファイルを作成した後に実行してください。OLE フレームを中央に配置し、プレビュー画像のアスペクト比を保持します。

2 番目のスクリプトは保存されたワークブックを埋め込み、PNG をプレビューとして使用します。ワークブックは明示的に XLSX として保存され、[OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) に渡す `xlsx` 拡張子と一致させます。PNG は中間のビットマップ変換を行わずにバイト列から直接読み込まれます。Java ブリッジは画像とワークブック データに対して明示的な Java バイト配列、スライド フレーム座標に対して Java の float 値を必要とします。[getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を通じて割り当てることで、デフォルトの OLE プレースホルダーが置き換えられます。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // プレビューをスライド内にフィットさせ、アスペクト比を変更しないようにします。
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// すべての同期処理が完了しました。Java ブリッジプロセスを停止します。
process.exit(0);
```

## **期待結果**

`OutputChart.pptx` には、埋め込まれた Excel ワークブックとチャート プレビューを含む 1 枚のスライドが含まれます。ワークブックには元のデータと 4 系列の縦棒グラフが含まれます。プレビューはスライドの中央に配置され、比例を保ちます。

![埋め込みワークブックのプレビューとして表示された Excel の縦棒グラフ](excel-chart-ole-preview.png)

Excel が利用可能な互換性のあるデスクトップ PowerPoint 環境では、オブジェクトをダブルクリックして埋め込まれたワークブックをアクティブ化および編集できます。アクティブ化と編集は、ホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **よくある質問**

**プレビュー画像が必要な理由は何ですか？**

埋め込まれたワークブックとそのスライド プレビューは別々のコンテンツです。チャート画像を提供すると、スライドにデフォルトの「EMBEDDED OLE OBJECT」プレースホルダーの代わりにチャートが表示されます。[Object Preview Issue when Adding OleObjectFrame](/slides/ja/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) を参照してください。

**コードでワークブックを変更した場合、プレビューは自動的に更新されますか？**

プレビューはスナップショットとして扱ってください。プログラムでワークブック データを更新する場合は、チャート画像を再生成し、プレビューと埋め込まれたワークブック データの両方を置き換える必要があります。

**XLS を使用できますか、XLSX の代わりに？**

はい。ワークブックを XLS 形式で保存し、埋め込みデータの拡張子として `xls` を使用します。拡張子は実際のワークブック形式と一致している必要があり、拡張子を変更するだけではデータは変換されません。

**アクティブ化後にオブジェクトのサイズが変わることがあるのはなぜですか？**

ホスト アプリケーションは、ワークブックをアクティブ化した際に OLE オブジェクトの表示を更新することがあります。ワークブックの OLE 表示範囲とスライド フレームの寸法の両方が重要です。[Working Solution for Chart Resizing in PPTX](/slides/ja/java/working-solution-for-chart-resizing-in-pptx/) を参照してください。

## **関連セクション**

- [PPTX におけるチャートサイズ変更の実装例](/slides/ja/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 追加時のオブジェクトプレビュー問題](/slides/ja/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)