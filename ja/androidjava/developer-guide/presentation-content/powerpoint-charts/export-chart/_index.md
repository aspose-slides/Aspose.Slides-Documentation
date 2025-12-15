---
title: Androidでプレゼンテーションのチャートをエクスポート
linktitle: チャートをエクスポート
type: docs
weight: 90
url: /ja/androidjava/export-chart/
keywords:
- チャート
- チャートを画像へ
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT と PPTX 形式をサポートし、任意のワークフローへのレポート作成を効率化します。"
---

## **チャート画像の取得**
Aspose.Slides for Android via Java は、特定のチャートの画像取得をサポートしています。以下にサンプル例を示します。
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

**チャートをラスタ画像ではなくベクタ（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)を使用して SVG に保存できます。

**エクスポートされたチャートの正確なサイズ（ピクセル）を設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる image‑rendering のオーバーロードを使用します。ライブラリは指定された寸法/スケールでオブジェクトのレンダリングをサポートしています。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合はどうすればよいですか？**

[必要なフォントをロードする](/slides/ja/androidjava/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) でチャートのレンダリングがメトリックとテキストの外観を保持するようにします。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

出力対象（[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/androidjava/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) など）および関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)/[ドキュメント](/slides/ja/androidjava/convert-powerpoint/) を参照してください。