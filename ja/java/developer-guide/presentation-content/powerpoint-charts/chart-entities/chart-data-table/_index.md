---
title: Java を使用してプレゼンテーションのチャート データ テーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/java/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PPT および PPTX のチャート データ テーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データテーブルのフォントプロパティを設定する**
Aspose.Slides for Java は、シリーズの色内のカテゴリの色を変更するサポートを提供します。

1. インスタンス化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスオブジェクト。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
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


## **FAQ**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[legend keys](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-)をサポートしており、オンまたはオフに切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートする際にデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/java/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/java/convert-powerpoint-to-html/)/[image](/slides/ja/java/convert-powerpoint-to-png/) にはデータテーブルを含むチャートが含まれます。

**テンプレートファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれたチャートについても、チャートのプロパティを使用してデータテーブルが[表示されているか](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) を確認および変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく確認するにはどうすればよいですか？**

データテーブルが[表示されているか](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--) を示す各チャートのプロパティを確認し、スライドを順に走査して有効になっているチャートを特定します。