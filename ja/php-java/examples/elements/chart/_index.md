---
title: チャート
type: docs
weight: 60
url: /ja/php-java/examples/elements/chart/
keywords:
- チャート
- チャートの追加
- チャートへのアクセス
- チャートの削除
- チャートの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でチャートを作成およびカスタマイズします：データの追加、系列・軸・ラベルの書式設定、タイプの変更、エクスポートが可能で、PPT、PPTX、ODP に対応しています。"
---
**Aspose.Slides for PHP via Java** を使用して、さまざまなチャートタイプの追加、アクセス、削除、更新の例です。以下のスニペットは基本的なチャート操作を示しています。

## **チャートの追加**

このメソッドは、最初のスライドにシンプルなエリアチャートを追加します。

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライドにシンプルな列グラフを追加します。
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **チャートへのアクセス**

シェイプコレクションからチャートを取得します。

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のチャートにアクセスします。
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **チャートの削除**

以下のコードはスライドからチャートを削除します。

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプがチャートであると想定します。
        $chart = $slide->getShapes()->get_Item(0);

        // チャートを削除します。
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **チャート データの更新**

タイトルなどのチャートプロパティを変更できます。

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // スライド上の最初のシェイプがチャートであると想定します。
        $chart = $slide->getShapes()->get_Item(0);

        // チャートのタイトルを変更します。
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```