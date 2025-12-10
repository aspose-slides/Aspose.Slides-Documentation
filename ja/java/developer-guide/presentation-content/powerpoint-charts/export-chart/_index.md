---
title: Javaでプレゼンテーションのチャートをエクスポート
linktitle: エクスポートチャート
type: docs
weight: 90
url: /ja/java/export-chart/
keywords:
- チャート
- チャートから画像へ
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT と PPTX 形式をサポートし、任意のワークフローへのレポート作成を効率化します。"
---

## **チャート画像を取得**
Aspose.Slides for Java は、特定のチャートの画像抽出をサポートしています。以下にサンプル例を示します。
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


## **FAQ**

**チャートをラスタ画像ではなくベクタ画像（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)を使用してSVGとして保存できます。

**エクスポートされたチャートのピクセル単位の正確なサイズを設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる image-rendering のオーバーロードを使用してください。ライブラリは指定された寸法/スケールでオブジェクトのレンダリングをサポートします。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合、どうすればよいですか？**

[必要なフォントをロード](/slides/ja/java/custom-font/)し、[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) を使用してチャートのレンダリングがメトリックとテキストの外観を保持できるようにしてください。

**エクスポートはPowerPointのテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

[API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[documentation](/slides/ja/java/convert-powerpoint/) を参照し、出力対象（[PDF](/slides/ja/java/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/java/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/java/convert-powerpoint-to-html/) など）および関連するレンダリングオプションを確認してください。