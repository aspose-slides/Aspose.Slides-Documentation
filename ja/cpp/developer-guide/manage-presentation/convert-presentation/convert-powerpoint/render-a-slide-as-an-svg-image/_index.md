---
title: C++でプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドからSVGへ
type: docs
weight: 50
url: /ja/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG へ
- プレゼンテーションから SVG へ
- スライドから SVG へ
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
description: "Aspose.Slides for C++ を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びましょう。シンプルなコード例で高品質なビジュアルを実現できます。"
---

## **SVG フォーマット**

SVG（Scalable Vector Graphics の略）は、2 次元画像を描画するために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像を XML のベクターとして保存し、その動作や外観を定義する詳細情報を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、これらの点で非常に高い基準を満たす数少ない画像フォーマットの一つです。そのため、Web 開発で広く使用されています。

You may want to use SVG files when you need to

- **プレゼンテーションを*非常に大きなフォーマット*で印刷する**。SVG 画像は任意の解像度やレベルに拡大できます。品質を損なうことなく、必要なだけ SVG 画像のサイズを変更できます。
- **スライドのチャートやグラフを*異なる媒体やプラットフォーム*で使用する**。ほとんどのリーダーは SVG ファイルを解釈できます。
- **画像を*できるだけ小さいサイズ*で使用する**。SVG ファイルは、特にビットマップベース（JPEG や PNG）のフォーマットと比較して、同等の高解像度画像よりも一般的にサイズが小さくなります。

## **スライドを SVG 画像としてレンダリング**

Aspose.Slides for C++ は、プレゼンテーション内のスライドを SVG 画像としてエクスポートできるようにします。以下の手順で SVG 画像を生成します:

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを繰り返し処理します。
3. 各スライドを FileStream を使用して個別の SVG ファイルに書き込みます。

{{% alert color="primary" %}} 
Aspose.Slides for C++ の PPT から SVG への変換機能を実装した、[無料のウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) をお試しください。
{{% /alert %}} 

この C++ のサンプルコードは、Aspose.Slides を使用して PPT を SVG に変換する方法を示しています：
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


## **FAQ**

**なぜ生成された SVG がブラウザ間で異なる見え方をすることがあるのでしょうか？**

特定の SVG 機能のサポートは、ブラウザエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) パラメータを使用すると、互換性の問題を緩和できます。

**スライドだけでなく個々のシェイプも SVG にエクスポートできますか？**

はい。[任意のシェイプを個別の SVG として保存できます](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)。アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを 1 つの SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオはスライド 1 枚につき SVG 1 ファイルです。複数のスライドを 1 つの SVG キャンバスに結合する場合は、アプリケーションレベルでのポストプロセスとして行います。