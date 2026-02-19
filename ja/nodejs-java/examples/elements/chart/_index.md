---
title: チャート
type: docs
weight: 60
url: /ja/nodejs-java/examples/elements/chart/
keywords:
- コード例
- チャート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用してチャートをマスターしましょう: 作成、書式設定、データバインド、そして PPT、PPTX、ODP 形式でのチャートエクスポートを JavaScript のサンプルと共に行えます。"
---
**Aspose.Slides for Node.js via Java** を使用して、さまざまなチャートタイプの追加、取得、削除、および更新の例です。以下のスニペットは基本的なチャート操作を示しています。

## **チャートの追加**

このメソッドは、最初のスライドにシンプルな面積チャートを追加します。

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のスライドにシンプルなエリアチャートを追加します。
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **チャートへのアクセス**

チャートを作成した後、シェイプコレクションを介して取得できます。

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // スライド上の最初のチャートにアクセスします。
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
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

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // チャートを削除します。
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **チャート データの更新**

タイトルなどのチャートプロパティを変更できます。

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // チャートのタイトルを変更します。
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```