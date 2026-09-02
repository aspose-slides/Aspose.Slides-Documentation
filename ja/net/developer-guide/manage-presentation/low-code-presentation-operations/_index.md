---
title: .NET における Low-Code プレゼンテーション操作
linktitle: Low-Code API
type: docs
weight: 50
url: /ja/net/low-code-presentation-operations/
keywords:
- Low-Code プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- スライドの反復
- シェイプの反復
- テキストの反復
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用のマスタースライドの削除
- 未使用のレイアウトスライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET で Aspose.Slides の Low-Code API を使用して、プレゼンテーションの変換と結合、コンテンツの反復、シェイプの収集、プレゼンテーションサイズの削減を行います。"
---
## **概要**

Aspose.Slides.LowCode 名前空間は、一般的なプレゼンテーション操作のための静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドでラップし、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの削除を、少ないコードで実現できます。

Low-code ヘルパーは、操作がファイルまたはプレゼンテーション全体に対して適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides object model](https://reference.aspose.com/slides/ja/net/aspose.slides/) を使用してください。

以下の表に利用可能なヘルパーをまとめます。

| ヘルパー | 利用用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/convert/) | プレゼンテーションを別の形式に変換するための、直接的なファイル間呼び出し。 |
| [Merger](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/merger/) | 同じ形式のプレゼンテーションファイル全体を結合する。 |
| [ForEach](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/) | 各スライド、シェイプ、段落、またはテキスト部分に対してアクションを実行する。 |
| [Collect](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理や分析に利用する。 |
| [Compress](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/) | 未使用のマスターとレイアウトを削除し、埋め込まれたフォントデータを削減する。 |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を選択できる場合は、[Convert.AutoByExtension](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/convert/autobyextension/) を使用します。このメソッドはソースのプレゼンテーションを開き、出力パスから必要な形式を判断し、結果を書き込みます。

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert] クラスは、PDF、SVG、JPEG、PNG、TIFF 出力用の専用メソッドも提供します。エクスポート前にプレゼンテーションを検査・修正したり、選択したヘルパーで提供されていないエクスポートオプションを構成する必要がある場合は、完全なオブジェクトモデルを使用してください。形式固有のワークフローやオプションについては、[Convert Presentation](/slides/ja/net/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

1 回の呼び出しでプレゼンテーションファイル全体を結合するには、[Merger.Process](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/merger/process/) を使用します。入力プレゼンテーションは同じファイル形式である必要があります。

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

個々のスライドを選択したり再マッピングしたりせず、すべてのスライドを 1 つの結果に結合する場合にこのヘルパーは適しています。選択したスライドをマージしたり、対象のマスターやレイアウトを適用したり、セクションを明示的に保持したり、スライドサイズの違いを調整したりする必要がある場合は、完全なオブジェクトモデルを使用してください。これらのシナリオについては、[Merge Presentations](/slides/ja/net/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach] クラスは、要求された種類のプレゼンテーション要素ごとにコールバックを呼び出します。入れ子になったコレクションループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。

以下の例は、[ForEach.Slide](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/slide/)、[ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/)、[ForEach.Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/paragraph/)、[ForEach.Portion](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/portion/) を使用して、対応する要素を検査します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

デフォルトでは、プレゼンテーション全体のシェイプとテキストの走査には、通常のスライド、マスター、レイアウトスライドが含まれます。`includeNotes` パラメーターを持つオーバーロードを使用すると、ノートスライドも処理できます。走査順序、早期終了、コールバック呼び出し前のフィルタリング、または詳細な親子制御が重要な場合は、直接的なコレクションループを使用してください。

## **シェイプの収集**

各シェイプごとのコールバックではなく、プレゼンテーション内のすべてのシェイプのコレクションが必要な場合は、[Collect.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/collect/shapes/) を使用してください。同じセットを複数回フィルタリング、カウント、または処理する場合に便利です。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

各シェイプを即座に処理でき、収集した結果を保持する必要がない場合は、代わりに [ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/) を使用してください。

## **プレゼンテーションコンテンツの圧縮**

[Compress] クラスは、未使用の構造要素を削除し、埋め込まれたフォントデータを削減できます。

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) は、通常のスライドが参照していないレイアウトスライドを削除します。
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) は、もはや使用されていないマスタースライドを削除します。
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/compressembeddedfonts/) は、埋め込まれたフォントから未使用の文字を削除します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

レイアウトのクリーンアップの後に参照されなくなるマスターも削除できるよう、未使用のレイアウトを未使用のマスターより先に削除してください。最適化されたプレゼンテーションを新しいファイルに保存すれば、後で元のマスター、レイアウト、または完全な埋め込みフォントデータが必要になる場合に備えられます。詳細については、[Slide Master](/slides/ja/net/slide-master/) と [Embedded Font](/slides/ja/net/embedded-font/) を参照してください。

## **よくある質問**

**低コード API をフルオブジェクトモデルの代わりに使用すべきタイミングは？**

標準的な操作がファイルまたはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合は、低コードヘルパーを使用してください。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、中間状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

いいえ。[Merger.Process](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/merger/process/) は、入力プレゼンテーションが同じ形式であることを要求します。まず入力ファイルを共通の形式に変換してください（例: [Convert.AutoByExtension](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/convert/autobyextension/) を使用）。その後、変換したファイルをマージします。

**ForEach はマスター、レイアウト、およびノートスライドも処理しますか？**

[ForEach.Slide](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/slide/) は通常のプレゼンテーションスライドを反復します。プレゼンテーション全体の [ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/)、[ForEach.Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/paragraph/)、および [ForEach.Portion](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/portion/) の操作は、デフォルトで通常、マスター、レイアウトスライドを含みます。ノートスライドを含めるには、`includeNotes` を `true` に設定したオーバーロードを使用してください。

**ForEach.Shape と Collect.Shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理するには、[ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/) を使用してください。結果を保持・フィルタリング・カウント・複数回走査できる enumerable が必要な場合は、[Collect.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/collect/shapes/) を使用します。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果は、プレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、該当する [Compress](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/) 操作はファイルサイズを削減しないことがあります。

**ForEach や Compress による変更は自動的に保存されますか？**

いいえ。これらのヘルパーは、メモリ内にロードされた [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) オブジェクトに対して動作します。[ForEach](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/) コールバックで要素を変更したり、[Compress](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/) を実行したりした後は、[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) を呼び出して結果を書き出してください。

## **関連記事**

- [プレゼンテーションの変換](/slides/ja/net/convert-presentation/)
- [プレゼンテーションの結合](/slides/ja/net/merge-presentation/)
- [スライドマスター](/slides/ja/net/slide-master/)
- [テキストボックスの管理](/slides/ja/net/manage-textbox/)
- [埋め込みフォント](/slides/ja/net/embedded-font/)