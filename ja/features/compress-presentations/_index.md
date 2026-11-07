---
title: プレゼンテーションの圧縮
description: 画像圧縮と設定の保存でプレゼンテーションのサイズを削減します。
type: docs
url: /ja/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **概要**

画像を圧縮し、不要になった切り抜き領域を削除し、保存前にプレゼンテーションの圧縮設定を選択します。これは、大きな写真や繰り返し使用されるメディアを含むスライドデッキに便利です。節約量はコンテンツと選択した設定に依存します。

## **使用例**

この C# の例は Aspose.Slides for .NET を使用しています。1600 × 900 ピクセルのグラデーション PNG を生成し、小さな画像フレームに挿入して *before.pptx* として保存します。その後、その画像を 96 DPI の目標解像度に圧縮し、*compressed.pptx* として保存します。両方のファイルサイズとプレビューを比較してください。節約量は入力画像と表示サイズに依存します。

セットアップについては、[Aspose.Slides for .NET のインストール](/slides/ja/net/installation/) を参照してください。

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **よくある質問**

### **これは単一ファイル全体の最適化スイッチですか？**

Aspose.Slides for .NET 26.11 では [Compress.CompressPresentation](/slides/ja/net/low-code-presentation-operations/#compress-the-whole-presentation) が追加され、未使用のレイアウト／マスターの削除、埋め込みフォントのサブセット化、150 DPI の画像圧縮を組み合わせます。切り抜かれた画像領域は永続的に削除されます。画像のみを対象にする場合は Compress.CompressImages を使用してください。より細かな制御が必要な場合は、上記の画像ごとのワークフローを維持してください。これらの新しいヘルパーは対象の .NET バージョンに固有です。他の SDK については対応するガイドを確認してください。

### **画像圧縮は編集可能なテキストやチャートを変更しますか？**

画像圧縮は画像データを対象としており、編集可能なテキストやチャートデータは変更しません。リサイズや再圧縮により画像の詳細が失われる可能性があるため、画像を確認してください。

### **プレゼンテーション画像の解像度はどのように選択すべきですか？**

表示される画像サイズや、画面表示か印刷かといった使用目的に基づいて目標解像度を選択してください。大画面や印刷、詳細な図表では高解像度を維持し、元の画像を破棄する前にレンダリング結果を比較しましょう。

## **ガイド**

- [.NET のプレゼンテーションにおける画像管理の最適化](/slides/ja/net/image/)

関連機能: [未使用のマスター、レイアウト、メディアの削除](/slides/ja/features/remove-unused-content/).

## 実行可能な .NET サンプル

- [プレゼンテーションサイズの削減](/slides/ja/net/examples/optimization-batch/compression/)