---
title: Java を使用したプレゼンテーションのチャート データ テーブルのカスタマイズ
linktitle: データ テーブル
type: docs
url: /ja/java/chart-data-table/
keywords:
- チャート データ
- データ テーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PPT および PPTX のチャート データ テーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データ テーブルのフォント プロパティの設定**
Aspose.Slides for Java は、系列の色のカテゴリの色を変更する機能を提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャート テーブルを設定します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。  
```java
// 空のプレゼンテーションを作成
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**Can I show small legend keys next to the values in the chart’s data table?**  
はい。データテーブルは[legend keys](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) をサポートしており、オンまたはオフに切り替えることができます。

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**  
はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/java/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/java/convert-powerpoint-to-html/)/[image](/slides/ja/java/convert-powerpoint-to-png/) にはデータテーブル付きのチャートが含まれます。

**Are data tables supported for charts that come from a template file?**  
はい。既存のプレゼンテーションまたはテンプレートからロードされたチャートについては、チャートのプロパティを使用してデータテーブルが[is shown](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) を確認し、変更できます。

**How can I quickly find which charts in a file have the data table enabled?**  
各チャートのデータテーブルが[is shown](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) を示すプロパティを確認し、スライドを走査して有効になっているチャートを特定します。