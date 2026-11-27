---
title: プレゼンテーションの圧縮
description: 画像を圧縮し、未使用のコンテンツを削除することでプレゼンテーションのサイズを縮小します。
type: docs
url: /ja/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **概要**

画像を圧縮し、不要になった切り抜き領域を削除し、保存前にプレゼンテーションの圧縮設定を選択します。これは、大きな写真や繰り返し使用されるメディアを含むスライドに便利です。節約できる量は、コンテンツと選択した設定によって異なります。

## **使用例**

この C# の例では `input.pptx` を読み込み、プレゼンテーションを圧縮し、`compressed.pptx` として保存します。

Aspose.Slides for .NET 26.11 以降を使用してください。セットアップについては、[Aspose.Slides for .NET のインストール](/slides/ja/net/installation/) を参照してください。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![圧縮前後で同一スケールの画像が表示され、測定された PPTX ファイルサイズバーと保存された画像寸法が続きます。](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*1つの合成ディテールグリッドフィクスチャで測定: 584,030 → 128,323 バイト。両方のレンダリングは同じスケールと 252 × 336 ポイントのフレームを使用しています。圧縮により切り抜きマージンが削除され、保存された画像は 525 × 700 ピクセルに縮小されます；サイズ削減は入力次第です。*
<!-- visual-explanation:compress-presentations:end -->

## **よくある質問**

### **これは単一のファイル全体最適化スイッチですか？**

Aspose.Slides for .NET 26.11 では、未使用のレイアウト/マスターの削除、埋め込みフォントのサブセット化、および 150 DPI の画像圧縮を組み合わせた [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) が追加されました。切り抜かれた画像領域は永久に削除されます。画像のみの処理には [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) を使用してください。より細かい制御が必要な場合は、[個別画像圧縮の例](/slides/ja/net/examples/optimization-batch/compression/) を参照してください。バージョン 26.11 以降、同じプレゼンテーション全体の呼び出しは Java、Node.js (Java 経由)、Python (.NET 経由) および C++ でも利用可能です。この例およびこのページのリンクは .NET 用です。

### **画像圧縮は編集可能なテキストやチャートを変更しますか？**

画像圧縮は画像データを対象とし、編集可能なテキストやチャートデータには影響しません。リサイズや再圧縮により詳細が失われる可能性があるため、画像を確認してください。

### **プレゼンテーション画像の解像度はどのように選べばよいですか？**

表示される画像サイズと、画面表示または印刷の用途に応じて目標解像度を選択してください。大画面、印刷、詳細な図表ではより高い解像度を維持し、元の画像を破棄する前にレンダリング結果を比較してください。

## **ガイド**

- [\.NET でプレゼンテーション全体を圧縮](/slides/ja/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [.NET でのプレゼンテーションにおける画像管理の最適化](/slides/ja/net/image/)

Related feature: [未使用のマスター、レイアウト、メディアの削除](/slides/ja/features/remove-unused-content/).

## **実行可能な .NET サンプル**

- [プレゼンテーションサイズの削減](/slides/ja/net/examples/optimization-batch/compression/)