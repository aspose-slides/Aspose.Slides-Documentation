---
title: チャート
type: docs
weight: 60
url: /ja/androidjava/examples/elements/chart/
keywords:
- コード例
- チャート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用してチャートをマスターしましょう。チャートの作成、書式設定、データバインディング、そして PPT、PPTX、ODP へのエクスポートを Java の例で実装できます。"
---
**Aspose.Slides for Android via Java** を使用した、さまざまなチャートタイプの追加、アクセス、削除、更新の例です。以下のスニペットは基本的なチャート操作を示しています。

## **チャートの追加**

このメソッドは、最初のスライドにシンプルなエリアチャートを追加します。

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 最初のスライドにシンプルなエリアチャートを追加します。
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **チャートへのアクセス**

チャートを作成した後、シェイプコレクションから取得できます。

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // スライド上の最初のチャートにアクセスします。
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **チャートの削除**

次のコードはスライドからチャートを削除します。

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // チャートを削除します。
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **チャート データの更新**

タイトルなど、チャートのプロパティを変更できます。

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // チャートのタイトルを変更します。
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```