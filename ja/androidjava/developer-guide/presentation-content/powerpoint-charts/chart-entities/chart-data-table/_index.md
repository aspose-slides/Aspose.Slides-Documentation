---
title: Android のプレゼンテーションにおけるチャート データテーブルのカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/androidjava/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で PPT と PPTX のチャート データテーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データテーブルのフォント プロパティを設定する**
Aspose.Slides for Android via Java は、シリーズ内のカテゴリの色変更をサポートします。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 変更したプレゼンテーションを保存します。

以下にサンプル例を示します。
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

はい。データテーブルは[凡例キー](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-)をサポートしており、オンまたはオフにできます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートするとき、データテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/)/[image](/slides/ja/androidjava/convert-powerpoint-to-png/)にはデータテーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれたすべてのチャートについて、チャートのプロパティを使用してデータテーブルが[表示されているか](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--)を確認および変更できます。

**ファイル内でデータテーブルが有効になっているチャートをすばやく見つけるにはどうすればよいですか？**

データテーブルが[表示されているか](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--)を示す各チャートのプロパティを確認し、スライドを走査して有効になっているチャートを特定します。