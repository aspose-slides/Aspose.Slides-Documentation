---
title: PHP を使用してプレゼンテーション内の円グラフをカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/php-java/pie-chart/
keywords:
- 円グラフ
- グラフ管理
- グラフカスタマイズ
- グラフオプション
- グラフ設定
- プロットオプション
- スライス色
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で円グラフを作成およびカスタマイズします。二次プロットを構成し、データラベルを表示し、PowerPoint で自動スライス色を適用します。"
---
## **概要**

この記事では、Aspose.Slidesで円グラフを操作する方法を説明します。Pie of Pie と Bar of Pie グラフの二次プロットオプションの構成方法と、標準の円グラフで自動スライス着色を有効にする方法を示します。

例では、スライドへのグラフ追加、系列やラベル設定の調整、既定のグラフデータをカスタムカテゴリと値に置き換える、更新されたプレゼンテーションの保存といったグラフカスタマイズ作業に焦点を当てています。

## **Pie of Pie および Bar of Pie グラフの二次プロットオプション**

Aspose.Slides for PHP via Java は Pie of Pie と Bar of Pie グラフの二次プロットオプションをサポートしています。これらのオプションは二次プロットのサイズと、データポイントが両方のプロットにどのように分割されるかを制御します。

次の例は、新しいプレゼンテーションに Pie of Pie グラフを作成し、データポイントの値をラベルとして表示します。[setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) メソッドは二次プロットのサイズをメインプロットの 149% に設定します。[setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) はパーセンテージベースの分割を選択し、[setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) は閾値を 53% に設定します。

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // 値を表示し、二次プロットを構成します。
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **二次プロットのカテゴリを選択する**

割合に関係なく特定のカテゴリを二次プロットにまとめたい場合は、カスタム分割を使用します。たとえば、売上レポートで Online と Events を一緒に表示し、読者がこれら 2 つのチャネルを比較できるようにします（全体の売上の 35% と 10% を占めていても）。

[setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) を [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) とともに呼び出し、[getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) でポイントを選択します。コレクションの [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) メソッドは系列のゼロベースインデックスを受け取り、[addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) を使用してデータポイントオブジェクトを追加します。この例では、インデックス 1 が Online を選択し、インデックス 3 のポイントが Events を選択します。Partners も一時的に追加され、その後 [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) で除外されます。

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // デフォルトのデータをチャネル別の売上に置き換えます。
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Online をゼロベースインデックスで、Events をデータポイントオブジェクトで選択します。
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Partners を選択から除外しますが、元データは削除しません。
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) と Events (10) は二次プロットで別々のスライスとして表示されます。一次プロットでは、Retail (40) と Partners (15) とともに、これらは値 45 の結合スライスとして表されます。カスタム選択から Partners を除外しても、一次プロットには残ります。カテゴリやその値がチャートの元データから削除されるわけではありません。

次の画像は PowerPoint で保存されたプレゼンテーションを示しています：

![二次プロットに Online と Events が表示され、一次プロットで 45 の合計値になる Pie of Pie グラフ](pie_of_pie_custom.png)

## **自動円グラフスライスの色付けを設定する**

Aspose.Slides for PHP via Java は円グラフのスライスに自動的に異なる色を割り当てることができます。次の例は、中央揃えのタイトルを持つ円グラフを作成し、既定のデータを 3 つの四半期カテゴリとその値に置き換えます。[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) メソッドは値 20、50、30 をラベルとして表示し、[setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) は各スライスに異なる色を設定します。

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // 中央揃えのチャートタイトルを追加します。
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // デフォルトのデータを最初のワークシートで置き換えます。
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // 値を表示し、スライスに異なる色を割り当てます。
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Pie of Pie と Bar of Pie のバリエーションはサポートされていますか？**

はい、ライブラリは Pie of Pie と Bar of Pie のタイプを含む、円グラフの二次プロットをサポートしています。[supports](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体をエクスポートせずに、チャート自体を画像（PNG など）としてエクスポートできます。[export the chart itself as an image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)