---
title: プレゼンテーションを圧縮
description: 画像を圧縮し未使用のコンテンツを削除してプレゼンテーションのサイズを縮小します。
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

画像を圧縮し、不要になった切り抜かれた画像領域を削除し、保存前にプレゼンテーションの圧縮設定を選択します。これは大きな写真や繰り返し使用されるメディアを含むスライドデッキに便利です。節約できる量はコンテンツと選択した設定によって異なります。

## **使用例**

この C# の例は `input.pptx` を読み込み、プレゼンテーションを圧縮し、`compressed.pptx` として保存します。

Aspose.Slides for .NET 26.11 以降を使用してください。設定方法については[Aspose.Slides for .NET のインストール](/slides/ja/net/installation/)をご覧ください。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **よくある質問**

### **これは単一の全ファイル最適化スイッチですか？**

Aspose.Slides for .NET 26.11 は [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) を追加し、未使用のレイアウト/マスターの削除、埋め込みフォントのサブセット化、150 DPI の画像圧縮を組み合わせます。切り抜かれた画像領域を永久に削除します。画像のみの処理には [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) を使用します。より細かい制御については、[個別画像圧縮の例](/slides/ja/net/examples/optimization-batch/compression/) を参照してください。これらの新しいヘルパーは指定された .NET バージョンに固有です。他の SDK については該当するガイドを確認してください。

### **画像圧縮は編集可能なテキストやチャートを変更しますか？**

画像圧縮は画像データを対象とし、編集可能なテキストやチャートデータには影響しません。リサイズや再圧縮によりディテールが失われる可能性があるため、画像を確認してください。

### **プレゼンテーション画像の解像度はどのように選べばよいですか？**

表示される画像サイズと想定する画面または印刷の用途に基づいて目標解像度を選択します。大型ディスプレイ、印刷、詳細な図表の場合は高解像度を維持し、元データを破棄する前にレンダリング結果を比較してください。

## **ガイド**

- [.NET でプレゼンテーション全体を圧縮](/slides/ja/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [.NET でプレゼンテーションの画像管理を最適化](/slides/ja/net/image/)

関連機能: [未使用のマスター、レイアウト、メディアを削除](/slides/ja/features/remove-unused-content/).

## 実行可能な .NET 例

- [プレゼンテーションサイズの削減](/slides/ja/net/examples/optimization-batch/compression/)