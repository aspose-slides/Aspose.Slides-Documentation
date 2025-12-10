---
title: .NET でプレゼンテーションのチャートをエクスポート
linktitle: チャートをエクスポート
type: docs
weight: 90
url: /ja/net/export-chart/
keywords:
- チャート
- チャート画像化
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT と PPTX 形式をサポートし、任意のワークフローへのレポート作成を効率化します。"
---

## **チャート画像を取得する**
Aspose.Slides for .NET は特定のチャートの画像抽出をサポートします。以下にサンプル例を示します。
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```


## **よくある質問**

**チャートをラスタ画像ではなくベクトル（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)を使用してSVGとして保存できます。

**エクスポートしたチャートのピクセル単位の正確なサイズを設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる画像レンダリングのオーバーロードを使用します。ライブラリは指定された寸法/スケールでオブジェクトのレンダリングをサポートしています。

**エクスポート後にラベルや凡例のフォントが崩れている場合はどうすればよいですか？**

[必要なフォントをロード](/slides/ja/net/custom-font/)し、[FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)を使用してチャートのレンダリングがメトリクスとテキストの外観を保持するようにします。

**エクスポートはPowerPointのテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

[API](https://reference.aspose.com/slides/net/aspose.slides.export/)[ドキュメント](/slides/ja/net/convert-powerpoint/) のエクスポートセクションで、出力先（[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、など）と関連するレンダリングオプションをご確認ください。