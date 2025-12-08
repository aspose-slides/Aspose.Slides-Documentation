---
title: チャートのエクスポート
type: docs
weight: 90
url: /ja/net/export-chart/
keywords:
- チャート
- チャート画像
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションからチャート画像を取得する"
---

## **チャート画像を取得**
Aspose.Slides for .NET は特定のチャートの画像取得をサポートしています。以下にサンプル例を示します。  
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


## **FAQ**

**チャートをラスタ画像ではなくベクトル（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG saving method](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)を使用してSVGとして保存できます。

**エクスポートしたチャートのサイズをピクセル単位で正確に設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる画像レンダリングのオーバーロードを使用してください。ライブラリは指定された寸法/スケールでオブジェクトのレンダリングをサポートします。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合はどうすればよいですか？**

必要なフォントは[Load the required fonts](/slides/ja/net/custom-font/)でロードし、[FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)を使用してください。これにより、チャートのレンダリングがメトリックとテキストの外観を保持します。

**エクスポートはPowerPointのテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラはプレゼンテーションの書式設定（テーマ、スタイル、塗り、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

出力対象（[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/) など）および関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[documentation](/slides/ja/net/convert-powerpoint/) のエクスポートセクションをご覧ください。