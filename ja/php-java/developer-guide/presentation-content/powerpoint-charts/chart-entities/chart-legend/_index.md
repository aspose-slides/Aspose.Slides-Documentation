---
title: PHP を使用したプレゼンテーションのチャート凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/php-java/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してチャート凡例をカスタマイズし、調整された凡例書式設定で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for PHP via Java は、PowerPoint プレゼンテーションのチャート凡例をカスタマイズするオプションを提供します。この記事では、凡例の位置とサイズの指定、凡例全体のフォントサイズの設定、個々の凡例エントリの書式設定、および選択したエントリの非表示または復元の方法を示します。

FAQ では、凡例のための領域を確保することや、複数行ラベルの表示、プレゼンテーションテーマからの書式継承など、関連する動作について説明します。

## **凡例の位置指定**

凡例の位置とサイズをチャートの寸法の割合として指定するには、凡例の [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/)、[setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/)、[setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/)、および [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) メソッドを使用します。

この例では、プレゼンテーションを作成し、デフォルト データを持つクラスター化された縦棒グラフを最初のスライドに追加します。凡例のオフセットとサイズをチャートの幅と高さで割ることで相対値に変換します。凡例はチャートの左上隅から 50 ポイントオフセットされ、サイズは 100×100 ポイントになります。この例は、java_values を使用して PHP/Java Bridge が返すチャートの寸法を PHP の数値に変換し、除算を行います。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // 凡例の位置とサイズをチャートに対する相対値で指定します。
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **凡例のフォントサイズの設定**

凡例のテキスト書式設定にアクセスするには [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) を使用し、ポイント単位でフォントサイズを設定するには [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を使用します。

この例では、デフォルト データのチャートを作成し、凡例のテキストを 20 ポイントに設定します。また、垂直軸の自動境界を無効にし、範囲を -5 から 10 に設定します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **個々の凡例エントリのフォントサイズの設定**

凡例の [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) メソッドが返すコレクションを使用して、特定のエントリの書式設定にアクセスします。エントリのインデックスはゼロベースで、インデックス `1` は 2 番目のエントリを指します。

この例では、デフォルト データに少なくとも 2 つの系列が含まれるクラスター化された縦棒グラフを作成します。2 番目の凡例エントリを太字、斜体、20 ポイントの青色テキストで書式設定します。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **個別の凡例エントリの非表示**

データは表示したままで補助系列を凡例から除外するには、[ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/) を介して `true` を渡して [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) を呼び出します。これにより選択した凡例エントリのみが非表示になり、系列やデータポイントは削除されません。対照的に、`false` を渡して [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) を呼び出すと、凡例全体が非表示になります。

以下の例では、デフォルト データを使用して複数系列のクラスター化された縦棒グラフを作成します。2 番目の系列の凡例エントリ（インデックス `1`）を非表示にしてプレゼンテーションを保存します。その後、`false` を渡して [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) を呼び出しエントリを復元し、2 番目のコピーを保存します。どちらのファイルでも列は表示されたままです。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // 同じエントリをチャート データを変更せずに復元します。
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以下の比較では、すべてのエントリが表示された状態と、2 番目のエントリが非表示にされた状態の同一チャートを示します。2 番目の系列の列は変わりません。

![すべての凡例エントリが表示されたチャートと、シリーズ 2 が凡例から非表示にされたチャートの比較。すべての列は表示されたままです。](hide-legend-entry.png)

縦棒、棒、折れ線グラフでは、凡例エントリは系列を識別します。円グラフの場合、凡例エントリは個々のデータポイント（スライス）を識別するため、選択したスライスで [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) を使用します。API はこのデータポイント メソッドを `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie`、`BarOfPie` のチャートタイプについて文書化しています。ドーナツ チャートには適用されないことに注意してください。

## **よくある質問**

**チャートが凡例の上に重なるのではなく、凡例用に領域を確保するようにできますか？**

はい。`false` を渡して [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) を呼び出すと、プロット領域に重なるのを防ぎ、凡例用に領域を確保します。

**複数行の凡例ラベルを作成できますか？**

はい。利用可能な幅が不足している場合、長いラベルは自動的に折り返されます。また、系列名に改行文字を入れることで改行を要求することもできます。

**凡例をプレゼンテーションテーマのカラースキームに従わせるにはどうすればよいですか？**

凡例の色、塗りつぶし、フォントを設定せずに残しておくと、テーマの書式設定を継承します。明示的に書式設定すると、対応するテーマ設定が上書きされます。