---
title: チャート データテーブル
type: docs
url: /ja/nodejs-java/chart-data-table/
---

## **チャート データテーブルのフォント プロパティの設定**

Aspose.Slides for Node.js via Java は、シリーズのカテゴリの色を変更する機能をサポートしています。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャート テーブルを設定します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。
```javascript
// 空のプレゼンテーションを作成
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[legend keys](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datatable/setshowlegendkey/) をサポートしており、オンまたはオフに切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートしたときにデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/ja/nodejs-java/convert-powerpoint-to-png/) にはデータテーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれたチャートについては、チャートのプロパティを使用してデータテーブルが[is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) を確認し、変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく見つけるにはどうすればよいですか？**

データテーブルが[is shown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/hasdatatable/) を示す各チャートのプロパティを確認し、スライドを順に走査して有効になっているチャートを特定します。