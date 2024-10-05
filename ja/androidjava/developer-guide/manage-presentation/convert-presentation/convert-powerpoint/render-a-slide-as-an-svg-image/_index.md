---
title: スライドをSVG画像としてレンダリングする
type: docs
weight: 50
url: /androidjava/render-a-slide-as-an-svg-image/
---

SVG（スケーラブルベクターグラフィックスの略）は、2次元画像をレンダリングするために使用される標準的なグラフィックタイプまたはフォーマットです。SVGは、動作や外観を定義する詳細を持つXML内にベクトルとして画像を格納します。

SVGは、スケーラビリティ、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなどの点で非常に高い基準を満たす数少ない画像フォーマットの1つです。これらの理由から、Web開発で一般的に使用されています。

次のような場合にSVGファイルを使用することをお勧めします。

- **プレゼンテーションを*非常に大きなフォーマット*で印刷する。** SVG画像は、任意の解像度やレベルにスケールアップできます。品質を犠牲にすることなく、必要な回数だけSVG画像のサイズを変更できます。
- **スライドのチャートやグラフを*異なるメディアやプラットフォーム*で使用する。** ほとんどのリーダーはSVGファイルを解釈することができます。
- **画像の*最小限のサイズ*を使用する。** SVGファイルは、特にビットマップ（JPEGやPNG）に基づく他のフォーマットの高解像度の同等物よりも一般的に小さいです。

Aspose.Slides for Android via Javaでは、プレゼンテーション内のスライドをSVG画像としてエクスポートできます。SVG画像を生成するための手順は次のとおりです。

1. Presentationクラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを繰り返します。
3. FileOutputStreamを介して各スライドを独自のSVGファイルに書き込みます。

{{% alert color="primary" %}} 

Aspose.Slides for Android via JavaからのPPTからSVGへの変換機能を実装した[無料ウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)を試してみることをお勧めします。

{{% /alert %}} 

以下のサンプルコードは、Aspose.Slidesを使用してPPTをSVGに変換する方法を示しています。

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```