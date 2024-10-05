---
title: スライドをSVG画像としてレンダリングする
type: docs
weight: 50
url: /cpp/render-a-slide-as-an-svg-image/
---

SVGはスケーラブルベクターグラフィックスの略で、2次元画像をレンダリングするために使用される標準的なグラフィックタイプまたはフォーマットです。SVGは、画像の動作や外観を定義する詳細情報を持つXML形式でベクターとして画像を保存します。

SVGは、スケーラビリティ、インタラクティビティ、パフォーマンス、アクセシビリティ、プログラマビリティなどの高い基準を満たす数少ない画像フォーマットの1つです。これらの理由から、ウェブ開発で一般的に使用されます。

次のような場合にはSVGファイルを使用したいかもしれません。

- **プレゼンテーションを*非常に大きなフォーマット*で印刷する**。SVG画像は、解像度やレベルに関係なくスケールアップできます。品質を犠牲にすることなく、必要に応じてSVG画像のサイズを何度でも変更できます。
- **スライドのチャートやグラフを*異なるメディアやプラットフォーム*で使用する**。ほとんどのリーダーはSVGファイルを解釈できます。
- **画像の*可能な限り小さいサイズ*を使用する**。SVGファイルは、他のフォーマットの高解像度の同等品よりも通常は小さく、特にビットマップ（JPEGやPNG）ベースのフォーマットではそうです。

Aspose.Slides for C++では、プレゼンテーション内のスライドをSVG画像としてエクスポートできます。SVG画像を生成するための手順は次のとおりです。

1. Presentationクラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを繰り返します。
3. 各スライドをFileStreamを通じてそれぞれのSVGファイルに書き込みます。

{{% alert color="primary" %}} 

Aspose.Slides for C++から実装したPPTをSVGに変換する機能を持つ[無料のウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)を試してみることをお勧めします。

{{% /alert %}} 

このC++のサンプルコードでは、Aspose.Slidesを使用してPPTをSVGに変換する方法を示しています。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```