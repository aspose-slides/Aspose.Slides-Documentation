---
title: プレゼンテーションで PHP を使用してチャート データテーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/php-java/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションのチャート データテーブルのフォント、罫線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for PHP via Java を使用すると、チャートのデータ テーブルを表示し、そのテキスト書式設定、罫線、凡例キーをカスタマイズできます。この記事では、テーブルの有効化、テキストの書式設定、各種罫線の制御、凡例キーの表示/非表示方法について説明します。サンプルは設定したチャートを PPTX ファイルに保存します。

## **フォント プロパティの設定**

チャートのデータ テーブルを表示するには、`true` を [setDataTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/setdatatable/) に渡します。[getChartDataTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/getchartdatatable/) を使用してテーブルにアクセスし、テキスト書式設定を構成します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
1. 最初のスライドにクラスタ化された縦棒グラフを追加します。
1. チャートのデータテーブルを有効にします。
1. [setFontBold](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setFontBold) で太字テキストを有効にし、20 ポイントのテキストにするために [setFontHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setFontHeight) に `20` を渡します。
1. 変更したプレゼンテーションを保存します。

以下の例は、作業ディレクトリに少なくとも 1 枚のスライドが含まれる `test.pptx` が必要です。位置 (50, 50) に幅 600 ポイント、高さ 400 ポイントのデフォルト データのチャートを追加します。保存された `output.pptx` には、データテーブルが有効化され、指定したフォント設定が適用されたチャートが含まれます。

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **データテーブル罫線のカスタマイズ**

テーブルは [Chart::setDataTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/setdatatable/) で有効化し、[Chart::getChartDataTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/getchartdatatable/) で取得します。3 種類の罫線を個別に制御できます。

- [setBorderHorizontal](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datatable/setborderhorizontal/) は横方向のセル罫線を制御します。
- [setBorderVertical](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datatable/setbordervertical/) は縦方向のセル罫線を制御します。
- [setBorderOutline](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datatable/setborderoutline/) はテーブルの外枠罫線を制御します。

`true` を各メソッドに渡すと罫線が表示され、`false` を渡すと非表示になります。以下の例はデフォルト データのクラスタ化縦棒グラフを作成し、横罫線と外枠罫線を表示し、縦罫線を非表示にします。入力ファイルは必要ありません。チャートの位置とサイズはポイント単位で指定します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以下の比較は、すべてのケースで同じチャート データと凡例キー設定を使用しています。すべての罫線を有効にした状態から、各バリエーションは 1 つの罫線設定だけを無効にします。左下のバリエーションは例の罫線設定と一致します。

![すべての罫線が有効、横罫線なし、縦罫線なし、外枠罫線なしのチャート データテーブル](data-table-borders.png)

## **凡例キーの表示/非表示**

凡例キーはデータテーブルの系列名の横に表示される小さな色付きマーカーです。読者が各テーブル行とチャート系列を対応付けるのに役立ちます。[setShowLegendKey](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datatable/setshowlegendkey/) に `true` を渡すとこれらのマーカーが表示され、`false` を渡すと非表示になります。

チャートの個別凡例は [Chart::setLegend](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/setlegend/) で制御します。これらの設定は独立しており、個別凡例を非表示にしてもデータテーブル内のキーは非表示にならず、テーブルのキーを非表示にしても個別凡例は非表示になりません。

以下の例はデフォルト データのチャートを作成し、データテーブルを有効にし、個別凡例を非表示にした状態でテーブル内に凡例キーを表示します。すべてのテーブル罫線は明示的に有効化されています。入力プレゼンテーションは不要です。テーブルのキーだけを非表示にするには、[setShowLegendKey](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datatable/setshowlegendkey/) に `false` を渡します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以下の比較は、凡例キーが有効な場合と無効な場合の同じテーブルを示します。すべての罫線は有効なままで、個別のチャート凡例は両方とも非表示です。

![左側に凡例キーが表示され、右側に非表示のチャート データテーブル](data-table-legend-keys.png)

## **FAQ**

**チャートのデータテーブルに凡例キーを表示できますか？**

はい。[setShowLegendKey](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datatable/setshowlegendkey/) に `true` を渡すと凡例キーが表示され、`false` を渡すと非表示になります。

**プレゼンテーションを PDF、HTML、または画像にエクスポートしたときにデータテーブルは保持されますか？**

はい。Aspose.Slides はエクスポート時にスライドの一部としてチャートと表示されたデータテーブルをレンダリングします。PDF (/slides/ja/php-java/convert-powerpoint-to-pdf/)、HTML (/slides/ja/php-java/convert-powerpoint-to-html/)、画像 (/slides/ja/php-java/convert-powerpoint-to-png/) へのエクスポートでも同様です。

**テンプレートからロードしたチャートでデータテーブルを操作できますか？**

はい。既存のプレゼンテーションまたはテンプレートからロードしたチャートの場合、[hasDataTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/hasdatatable/) と [setDataTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/setdatatable/) を使用してデータテーブルの表示有無を確認または変更できます。

**データテーブルが有効になっているチャートをどのように見つけられますか？**

各スライドのシェイプを走査し、チャートを特定してそれらの [hasDataTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/hasdatatable/) メソッドを呼び出します。`true` が返された場合、データテーブルが有効になっています。