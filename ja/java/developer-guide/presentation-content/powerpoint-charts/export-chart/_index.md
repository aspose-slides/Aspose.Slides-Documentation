---
title: Javaでプレゼンテーションのチャートをエクスポート
linktitle: チャートをエクスポート
type: docs
weight: 90
url: /ja/java/export-chart/
keywords:
- チャート
- チャートから画像へ
- 画像としてのチャート
- チャート画像を抽出
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT と PPTX フォーマットをサポートし、レポート作成をあらゆるワークフローに統合します。"
---

## **チャート画像の取得**
Aspose.Slides for Java は特定のチャートの画像抽出をサポートしています。以下にサンプル例を示します。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**チャートをラスター画像ではなくベクタ（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は [shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) を使用して SVG に保存できます。

**エクスポートしたチャートのピクセル単位の正確なサイズを設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる image‑rendering のオーバーロードを使用します。ライブラリは指定された寸法・スケールでオブジェクトのレンダリングをサポートします。

**ラベルや凡例のフォントがエクスポート後に崩れて見える場合、どうすればよいですか？**

[必要なフォントをロードする](/slides/ja/java/custom-font/) を [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) で実行し、チャートのレンダリングがメトリックとテキストの外観を保持するようにします。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング／エクスポート機能はどこで確認できますか？**

出力先（[PDF](/slides/ja/java/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/java/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/java/convert-powerpoint-to-html/) など）と関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[ドキュメント](/slides/ja/java/convert-powerpoint/) を参照してください。