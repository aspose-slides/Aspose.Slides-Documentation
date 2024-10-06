---
title: SVG画像としてスライドをレンダリング
type: docs
weight: 50
url: /ja/net/render-slide-as-svg-image/
---

SVG（スケーラブル・ベクター・グラフィックスの略）は、二次元画像をレンダリングするために使用される標準的なグラフィックタイプまたは形式です。SVGはXMLでベクターとして画像を保存し、その動作や外観を定義する詳細を含んでいます。

SVGは、スケーラビリティ、インタラクティビティ、パフォーマンス、アクセシビリティ、プログラマビリティなどの観点で非常に高い基準を満たす数少ない画像形式の一つです。これらの理由から、ウェブ開発で一般的に使用されています。

以下のシナリオでSVGファイルを使用することを検討しているかもしれません：

- プレゼンテーションを非常に大きなフォーマットで印刷する予定がある場合。SVG画像はどの解像度やレベルにも拡張可能です。品質を損なうことなく、必要に応じてSVG画像のサイズを何度でも変更できます。
- スライドから異なるメディアやプラットフォームにチャートやグラフを使用する意図がある場合。ほとんどのリーダーはSVGファイルを解釈できます。
- 可能な限り小さいサイズの画像を使用する必要がある場合。SVGファイルは一般に他の形式の高解像度の同等物よりも小さく、特にビットマップ（JPEGやPNG）に基づく形式ではその傾向が顕著です。

Aspose.Slides for .NETを使用すると、プレゼンテーションのスライドを**SVG**画像としてエクスポートできます。任意のスライドからSVG画像を生成するには、以下を実行します：

- Presentationクラスのインスタンスを作成します。
- プレゼンテーション内のすべてのスライドを反復処理します。
- 各スライドをFileStreamを介して自分のSVGファイルに書き込みます。

{{% alert color="primary" %}} 

Aspose.Slides for .NETからのPPTからSVGへの変換機能を実装した[無料のWebアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)を試してみることをお勧めします。

{{% /alert %}} 

以下のC#のサンプルコードは、Aspose.Slidesを使用してPPTをSVGに変換する方法を示しています：

``` csharp
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