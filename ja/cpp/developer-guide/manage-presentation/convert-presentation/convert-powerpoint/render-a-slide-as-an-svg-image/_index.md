---
title: C++ でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドを SVG に変換
type: docs
weight: 50
url: /ja/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint を SVG に変換
- プレゼンテーションを SVG に変換
- スライドを SVG に変換
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
description: "Aspose.Slides for C++ を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びます。シンプルなコード例で高品質なビジュアルを実現できます。"
---

## **SVG フォーマット**

SVG（Scalable Vector Graphics の略称）は、2 次元画像をレンダリングするために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像を XML のベクターとして保存し、その動作や外観を定義する詳細情報を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を満たす数少ない画像フォーマットの一つです。このため、ウェブ開発で広く使用されています。

SVG ファイルを使用したいケースは次の通りです。

- **プレゼンテーションを*非常に大きなフォーマット*で印刷したい場合**。SVG 画像は任意の解像度やサイズに拡大でき、品質を損なうことなく必要なだけサイズ変更が可能です。
- **スライドのチャートやグラフを*異なる媒体やプラットフォーム*で使用したい場合**。ほとんどのリーダーは SVG ファイルを解釈できます。
- **画像の*最小サイズ*を使用したい場合**。SVG ファイルは、特にビットマップベースの JPEG や PNG などの他フォーマットに比べて、一般的に高解像度版よりもサイズが小さくなります。

## **スライドを SVG 画像としてレンダリング**

Aspose.Slides for C++ を使用すると、プレゼンテーションのスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成してください。

1. Presentation クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileStream を使用して個別の SVG ファイルに書き込みます。

{{% alert color="primary" %}} 
Aspose.Slides for C++ の PPT から SVG への変換機能を実装した、当社の[無料ウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)をぜひお試しください。
{{% /alert %}} 

以下の C++ サンプルコードは、Aspose.Slides を使用して PPT を SVG に変換する方法を示しています：
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

**なぜ生成された SVG がブラウザー間で見た目が異なることがあるのでしょうか？**

特定の SVG 機能のサポートは、ブラウザーエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) パラメーターを使用すると、互換性の問題を緩和できます。

**スライドだけでなく、個々のシェイプを SVG としてエクスポートすることはできますか？**

はい。任意の[シェイプを個別の SVG として保存できます](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)。アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを 1 つの SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオはスライド 1 枚につき 1 つの SVG です。複数のスライドを単一の SVG キャンバスに結合することは、アプリケーションレベルで実行される後処理のステップです。