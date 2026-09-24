---
title: JavaScript を使用してプレゼンテーション内のチャート データテーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/nodejs-java/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーションのチャート データテーブルのフォント、枠線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for Node.js via Java を使用すると、チャートのデータテーブルを表示し、テキストの書式設定、枠線、および凡例キーをカスタマイズできます。本記事では、テーブルの有効化、テキストの書式設定、各種枠線の制御、凡例キーの表示・非表示方法について説明します。例では、設定したチャートを PPTX ファイルに保存します。

## **フォント プロパティの設定**

チャートのデータテーブルを表示するには、`true` を [setDataTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/setdatatable/) に渡します。テーブルにアクセスしてテキスト書式を設定するには、[getChartDataTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/getchartdatatable/) を使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションをロードします。
2. 最初のスライドにクラスター化列チャートを追加します。
3. チャートのデータテーブルを有効にします。
4. [setFontBold](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setfontbold) で太字を有効にし、[setFontHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setfontheight) に `20` を渡して 20 ポイントのテキストにします。
5. 変更したプレゼンテーションを保存します。

以下の例は、作業ディレクトリに少なくとも 1 枚のスライドが含まれる `input.pptx` が必要です。位置 (50, 50)、幅 600 ポイント、高さ 400 ポイントでデフォルト データのチャートを追加します。保存された `output.pptx` には、データテーブルが有効化され、指定したフォント設定が適用されたチャートが含まれます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **データテーブルの枠線のカスタマイズ**

[Chart.setDataTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/setdatatable/) でテーブルを有効にし、[Chart.getChartDataTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/getchartdatatable/) で取得します。枠線は次の 3 種類を個別に制御できます。

- [setBorderHorizontal](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datatable/setborderhorizontal/) で水平セル枠線を制御します。
- [setBorderVertical](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datatable/setbordervertical/) で垂直セル枠線を制御します。
- [setBorderOutline](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datatable/setborderoutline/) でテーブルの外枠を制御します。

各メソッドに `true` を渡すと枠線が表示され、`false` を渡すと非表示になります。以下の例は、デフォルト データのクラスター化列チャートを作成し、水平枠線と外枠を表示し、垂直枠線を非表示にします。入力ファイルは不要で、位置とサイズはポイント単位で指定されています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下の比較は、同じチャート データと凡例キー設定を 4 パターンで示しています。すべての枠線を有効にした状態から、各パターンでひとつずつ枠線設定を無効にしています。左下のパターンが例の枠線設定と一致します。

![すべての枠線が有効、水平枠線なし、垂直枠線なし、外枠なしのチャート データテーブル](data-table-borders.png)

## **凡例キーの表示または非表示**

凡例キーは、データテーブル内の系列名の横に表示される小さな色付きマーカーです。テーブルの各行とチャート系列を対応させるのに役立ちます。これらのマーカーを表示するには `true` を [setShowLegendKey](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datatable/setshowlegendkey/) に、非表示にするには `false` を渡します。

別個のチャート凡例は [Chart.setLegend](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/setlegend/) で制御します。これらの設定は独立しており、別個の凡例を非表示にしてもデータテーブル内のキーは影響を受けず、テーブルのキーを非表示にしても別個の凡例は表示されたままです。

以下の例は、デフォルト データのチャートを作成し、データテーブルを有効にして凡例キーを表示し、別個の凡例を非表示にします。すべてのテーブル枠線は明示的に有効化されています。入力プレゼンテーションは不要です。テーブルのキーだけを非表示にしたい場合は、[setShowLegendKey](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datatable/setshowlegendkey/) に `false` を渡します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下の比較は、凡例キーを有効にしたテーブルと無効にしたテーブルを示しています。すべての枠線は引き続き有効で、別個のチャート凡例は両方とも非表示です。

![左側に凡例キーが表示され、右側に非表示のチャート データテーブル](data-table-legend-keys.png)

## **FAQ**

**チャートのデータテーブルに凡例キーを表示できますか？**

はい。`true` を [setShowLegendKey](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datatable/setshowlegendkey/) に渡すと凡例キーが表示され、`false` を渡すと非表示になります。

**データテーブルは PDF、HTML、画像へのエクスポート時に保持されますか？**

はい。Aspose.Slides は、エクスポート時にスライドの一部としてチャートと表示されたデータテーブルを [PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/)、または [画像](/slides/ja/nodejs-java/convert-powerpoint-to-png/) にレンダリングします。

**テンプレートから読み込んだチャートでもデータテーブルを操作できますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込んだチャートについては、[hasDataTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/hasdatatable/) と [setDataTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/setdatatable/) を使用して、データテーブルの表示有無を確認または変更できます。

**データテーブルが有効になっているチャートをどうやって見つけますか？**

各スライド上のシェイプを走査し、チャートを特定してその [hasDataTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/hasdatatable/) メソッドを呼び出します。戻り値が `true` の場合、そのチャートのデータテーブルは有効化されています。