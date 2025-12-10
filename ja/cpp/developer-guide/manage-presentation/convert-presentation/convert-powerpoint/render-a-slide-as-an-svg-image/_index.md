---
title: C++ でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドから SVG
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
description: "Aspose.Slides for C++ を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びます。シンプルなコード例で高品質なビジュアルを実現します。"
---

## **SVG 形式**

SVG（Scalable Vector Graphics の略称）は、2 次元画像を描画するために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は、画像を XML 形式のベクターとして保存し、その動作や外観を定義する詳細情報を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、極めて高い基準を満たす数少ない画像フォーマットのひとつです。このような理由から、Web 開発で広く利用されています。

以下のような場合に SVG ファイルを使用したいと思うでしょう

- **プレゼンテーションを *非常に大きなサイズ* で印刷する**。SVG 画像はあらゆる解像度やサイズにスケーリング可能です。品質を損なうことなく、必要なだけ画像サイズを変更できます。
- **スライドのチャートやグラフを *異なる媒体やプラットフォーム* で使用する**。ほとんどのリーダーは SVG ファイルを解釈できます。
- **画像の *可能な限り最小サイズ* を使用する**。SVG ファイルは、特にビットマップ（JPEG や PNG）ベースのフォーマットに比べ、同等の高解像度画像よりも一般的にサイズが小さくなります。

## **スライドを SVG 画像としてレンダリングする**

Aspose.Slides for C++ を使用すると、プレゼンテーションのスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成してください：

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileStream を使用して個別の SVG ファイルに書き出します。

{{% alert color="primary" %}} 
Aspose.Slides for C++ の PPT から SVG への変換機能を実装した、当社の [無料ウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) をお試しになるとよいでしょう。
{{% /alert %}} 

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

**結果として得られる SVG がブラウザー間で異なる見た目になる可能性があるのはなぜですか？**

特定の SVG 機能のサポートは、各ブラウザーエンジンによって実装が異なります。[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) パラメーターを使用すると、互換性の問題を緩和できます。

**スライドだけでなく、個々のシェイプも SVG にエクスポートできますか？**

はい。任意の [シェイプを個別の SVG として保存できます](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)、アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを単一の SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオは、スライド1枚につきSVG1枚です。複数のスライドを単一の SVG キャンバスに結合する場合は、アプリケーション側での後処理として行う必要があります。