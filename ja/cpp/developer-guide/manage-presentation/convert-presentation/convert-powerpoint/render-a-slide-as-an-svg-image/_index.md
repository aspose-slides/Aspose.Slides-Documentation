---
title: C++でプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドからSVGへ
type: docs
weight: 50
url: /ja/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint を SVG に変換
- プレゼンテーション を SVG に変換
- スライド を SVG に変換
- PPT を SVG に変換
- PPTX を SVG に変換
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

SVGは Scalable Vector Graphics の頭字語で、2 次元画像をレンダリングするために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像を XML のベクターとして保存し、動作や外観を定義する詳細情報を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を満たす数少ない画像フォーマットの一つです。そのため、Web 開発で一般的に使用されています。

以下のような場合に SVG ファイルを使用したいかもしれません

- **プレゼンテーションを *非常に大きなサイズ* で印刷する**。SVG 画像は任意の解像度やレベルに拡大できます。品質を損なうことなく、必要なだけ何度でも SVG 画像のサイズを変更できます。
- **スライドのチャートやグラフを *異なる媒体やプラットフォーム* で使用する**。ほとんどのリーダーは SVG ファイルを解釈できます。
- **可能な限り最小サイズの画像を使用する**。SVG ファイルは、他のフォーマットの高解像度版に比べて一般的にサイズが小さく、特にビットマップベースのフォーマット（JPEG や PNG）よりも小さくなります。

## **スライドを SVG 画像としてレンダリング**

Aspose.Slides for C++ を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成してください。

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileStream を介して個別の SVG ファイルに書き込みます。

{{% alert color="primary" %}} 
Aspose.Slides for C++ の PPT から SVG への変換機能を実装した、[無料のウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) を試してみると良いでしょう。
{{% /alert %}} 

このサンプルコードは C++ で PPT を SVG に変換する方法を示しています:
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

**生成された SVG がブラウザ間で異なる見た目になる可能性がある理由は何ですか？**

特定の SVG 機能に対するサポートは、ブラウザエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) のパラメータを使用すると、互換性の問題を緩和できます。

**スライドだけでなく、個々のシェイプも SVG にエクスポートできますか？**

はい。任意の [シェイプを個別の SVG として保存できます](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) を使用すると、アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを 1 つの SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオは、1 スライド → 1 SVG です。複数のスライドを 1 つの SVG キャンバスに結合することは、アプリケーションレベルで実行されるポストプロセスのステップです。