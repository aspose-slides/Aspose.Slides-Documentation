---
title: プレゼンテーションのチャートを.NETでエクスポート
linktitle: チャートのエクスポート
type: docs
weight: 90
url: /ja/net/export-chart/
keywords:
- チャート
- チャートから画像へ
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT および PPTX 形式に対応し、任意のワークフローへのレポート作成を効率化します。"
---

## **チャート画像の取得**
Aspose.Slides for .NET は、特定のチャートの画像抽出をサポートしています。以下にサンプル例が示されています。
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

**チャートをラスタ画像ではなくベクタ（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)を使用して SVG に保存できます。

**エクスポートされたチャートの正確なサイズ（ピクセル単位）を設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる image‑rendering のオーバーロードを使用します。ライブラリは指定された寸法/スケールでオブジェクトのレンダリングをサポートしています。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合はどうすればよいですか？**

必要なフォントは[必要なフォントをロード](/slides/ja/net/custom-font/) でロードし、[FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) を介して読み込むことで、チャートのレンダリングがメトリクスとテキストの外観を保持します。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が維持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

出力対象（[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/) など）や関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[documentation](/slides/ja/net/convert-powerpoint/) のエクスポートセクションをご覧ください。