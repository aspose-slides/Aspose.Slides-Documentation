---
title: チャートのエクスポート
type: docs
weight: 90
url: /ja/nodejs-java/export-chart/
---

## **チャート画像の取得**
Aspose.Slides for Node.js via Java は、特定のチャートの画像抽出をサポートしています。以下にサンプル例を示します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**チャートをラスタ画像ではなくベクタ (SVG) としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)を使用して SVG に保存できます。

**エクスポートしたチャートのピクセル単位の正確なサイズを設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる image-rendering のオーバーロードを使用します。ライブラリは指定された寸法やスケールでオブジェクトのレンダリングをサポートしています。

**エクスポート後にラベルや凡例のフォントが崩れている場合、どうすればよいですか？**

[必要なフォントをロード](/slides/ja/nodejs-java/custom-font/)し、[FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) を使用してチャートのレンダリングがメトリックとテキストの外観を保持するようにします。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

出力先（[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ja/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/), など）や関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/)/[documentation](/slides/ja/nodejs-java/convert-powerpoint/) を参照してください。