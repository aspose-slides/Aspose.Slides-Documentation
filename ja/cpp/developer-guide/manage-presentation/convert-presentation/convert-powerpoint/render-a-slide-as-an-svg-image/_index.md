---
title: C++ でプレゼンテーション スライドを SVG 画像としてレンダリング
linktitle: スライドから SVG へ
type: docs
weight: 50
url: /ja/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG へ
- プレゼンテーション から SVG へ
- スライド から SVG へ
- PPT から SVG へ
- PPTX から SVG へ
- PPT を SVG として保存
- PPTX を SVG として保存
- PPT を SVG にエクスポート
- PPTX を SVG にエクスポート
- スライドをレンダリング
- スライドを変換
- スライドをエクスポート
- ベクター画像
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びます。シンプルなコード例で高品質なビジュアルを実現します。"
---

## **SVG フォーマット**

SVG は Scalable Vector Graphics の略称で、2 次元画像をレンダリングするために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像を XML のベクトルとして保存し、その動作や外観を定義する詳細情報を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を満たす数少ない画像フォーマットの一つです。このため、ウェブ開発で広く利用されています。

以下のようなケースで SVG ファイルを使用したい場合があります

- **プレゼンテーションを *非常に大きなサイズ* で印刷する**。SVG 画像は任意の解像度やレベルにスケール可能です。品質を犠牲にすることなく、必要なだけ SVG 画像のサイズ変更ができます。
- **スライドのチャートやグラフを *異なる媒体やプラットフォーム* で使用する**。ほとんどのビューアが SVG ファイルを解釈できます。
- **画像を *できるだけ小さいサイズ* で使用する**。SVG ファイルは、特にビットマップベース（JPEG や PNG）の形式と比較して、同等の高解像度画像よりも一般的にサイズが小さくなります。

## **スライドを SVG 画像としてレンダリング**

Aspose.Slides for C++ を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成します。

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileStream を使用して個別の SVG ファイルに書き出します。

{{% alert color="primary" %}} 
Aspose.Slides for C++ の PPT から SVG への変換機能を実装した、[無料の Web アプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) をぜひお試しください。
{{% /alert %}} 

この C++ のサンプルコードは、Aspose.Slides を使用して PPT を SVG に変換する方法を示しています。
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


## **よくある質問**

**生成された SVG がブラウザ間で異なる見た目になる可能性があるのはなぜですか？**

特定の SVG 機能のサポートはブラウザエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) パラメータを使用すると、互換性の問題を緩和できます。

**スライドだけでなく個々のシェイプを SVG にエクスポートすることは可能ですか？**

はい。任意の[シェイプを個別の SVG として保存できます](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)、これはアイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを単一の SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオはスライド1枚につきSVG1枚です。複数のスライドを単一の SVG キャンバスに結合する場合は、アプリケーション側での後処理として行う必要があります。