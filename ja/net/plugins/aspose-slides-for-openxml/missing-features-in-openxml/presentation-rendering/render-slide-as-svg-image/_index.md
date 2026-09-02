---
title: スライドを SVG 画像としてレンダリング
type: docs
weight: 50
url: /ja/net/render-slide-as-svg-image/
---
SVG（Scalable Vector Graphics の略称）は、2 次元画像の描画に使用される標準的なグラフィックタイプまたはフォーマットです。SVG は、動作や外観を定義する詳細情報とともに、XML でベクターとして画像を保存します。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を備えた数少ない画像フォーマットのひとつです。このため、Web 開発で広く使用されています。

次のようなシナリオで SVG ファイルを使用したい場合があります：

- プレゼンテーションを非常に大きなサイズで印刷する場合。SVG 画像は任意の解像度やサイズに拡大でき、品質を損なうことなく何度でもリサイズできます。
- スライドのチャートやグラフを別の媒体やプラットフォームで使用したい場合。ほとんどのリーダーが SVG ファイルを解釈できます。
- できるだけ小さいサイズの画像が必要な場合。SVG ファイルは、特にビットマップ（JPEG や PNG）ベースのフォーマットに比べて、同等の高解像度画像よりも一般的にサイズが小さくなります。

Aspose.Slides for .NET を使用すると、プレゼンテーションのスライドを **SVG** 画像としてエクスポートできます。任意のスライドから SVG 画像を生成するには、次の手順を実行します：

- Presentation クラスのインスタンスを作成します。
- プレゼンテーション内のすべてのスライドを反復処理します。
- 各スライドを FileStream を使用して個別の SVG ファイルに書き出します。

{{% alert color="info" %}} 
Aspose.Slides for .NET の PPT から SVG への変換機能を実装した、弊社の[無料ウェブアプリケーション](https://products.aspose.app/slides/ja/conversion/ppt-to-svg)をぜひお試しください。
{{% /alert %}} 

以下の C# サンプルコードは、Aspose.Slides を使用して PPT を SVG に変換する方法を示しています：

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```