---
title: .NET におけるローコード プレゼンテーション操作
linktitle: ローコード API
type: docs
weight: 50
url: /ja/net/low-code-presentation-operations/
keywords:
- ローコード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- スライドの反復
- シェイプの反復
- テキストの反復
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用マスター スライドの削除
- 未使用レイアウト スライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET で Aspose.Slides のローコード API を使用して、プレゼンテーションの変換と結合、コンテンツの反復、シェイプの収集、およびプレゼンテーションサイズの縮小を行います。"
---
## **概要**

[ Aspose.Slides.LowCode](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/) 名前空間は、一般的なプレゼンテーション操作用の静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドにラップするため、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの除去を少ないコードで実行できます。

低コードヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係に対して細かな制御が必要な場合は、完全な [Aspose.Slides オブジェクト モデル](https://reference.aspose.com/slides/ja/net/aspose.slides/) を使用してください。

以下の表は、利用可能なヘルパーをまとめたものです。

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/convert/) | 直接ファイル間で呼び出すことで、プレゼンテーションを別の形式に変換します。 |
| [Merger](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/merger/) | 同一形式のプレゼンテーション ファイル全体を結合します。 |
| [ForEach](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/) | すべてのスライド、シェイプ、段落、テキスト部分に対してアクションを実行します。 |
| [Collect](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/collect/) | 繰り返し処理や分析のために、プレゼンテーション全体からシェイプを取得します。 |
| [Compress](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/) | 未使用のマスターやレイアウトを削除し、埋め込みフォント データを縮小します。 |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を選択できる場合は、[Convert.AutoByExtension](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/convert/autobyextension/) を使用します。このメソッドはソース プレゼンテーションを開き、出力パスから必要な形式を判断して結果を書き出します。

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/convert/) クラスは PDF、SVG、JPEG、PNG、TIFF の出力用に専用メソッドも提供します。エクスポート前にプレゼンテーションを検査または変更したり、選択したヘルパーで公開されていないエクスポート オプションを構成する必要がある場合は、フル オブジェクト モデルを使用してください。形式固有のワークフローとオプションについては、[Convert Presentation](/net/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

[Merger.Process](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/merger/process/) を使用すると、1 回の呼び出しでプレゼンテーション ファイル全体を結合できます。入力プレゼンテーションは同じファイル形式である必要があります。

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

このヘルパーは、すべてのスライドを個別に選択したり再マッピングしたりせずに 1 つの結果に追加したい場合に適しています。選択したスライドの結合、宛先マスターやレイアウトの適用、セクションの明示的な保持、スライド サイズの調整が必要な場合は、フル オブジェクト モデルを使用してください。これらのシナリオについては、[Merge Presentations](/net/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/) クラスは、要求されたタイプのプレゼンテーション要素ごとにコールバックを呼び出します。入れ子になったコレクション ループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。

次の例は、[ForEach.Slide](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/slide/)、[ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/)、[ForEach.Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/paragraph/)、[ForEach.Portion](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/portion/) を使用して、対応する要素を検査します。

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

デフォルトでは、プレゼンテーション全体のシェイプとテキストの走査には通常スライド、マスター スライド、レイアウト スライドが含まれます。`includeNotes` パラメーターを持つオーバーロードを使用すると、ノート スライドも処理できます。走査順序、早期終了、コールバック呼び出し前のフィルタリング、詳細な親子制御が重要な場合は、直接コレクション ループを使用してください。

## **シェイプの収集**

[Collect.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/collect/shapes/) は、各シェイプごとのコールバックではなく、プレゼンテーション内のすべてのシェイプのコレクションが必要なときに使用します。同じセットを複数回フィルタリング、カウント、または処理する場合に便利です。

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

各シェイプをすぐに処理でき、収集結果を保持する必要がない場合は、代わりに [ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/) を使用してください。

## **プレゼンテーション コンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/) クラスは、未使用の構造要素を削除し、埋め込みフォント データを縮小できます。

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) は、通常スライドから参照されていないレイアウト スライドを削除します。
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) は、もはや使用されていないマスター スライドを削除します。
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/compressembeddedfonts/) は、埋め込みフォントから未使用文字を削除します。

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

未使用レイアウトを削除した後に未使用マスターを削除してください。レイアウトのクリーンアップ後に参照が失われたマスターも同時に削除できます。元のマスター、レイアウト、または完全な埋め込みフォント データが後で必要になる可能性がある場合は、最適化されたプレゼンテーションを新しいファイルに保存してください。詳細は、[Slide Master](/net/slide-master/) と [Embedded Font](/net/embedded-font/) を参照してください。

## **FAQ**

**低コード API をフル オブジェクト モデルの代わりに使用すべきケースは？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合に低コード ヘルパーを使用します。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、中間状態を検査したり、ヘルパーが提供しない動作を構成する必要がある場合は、フル オブジェクト モデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

できません。[Merger.Process](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/merger/process/) は、入力プレゼンテーションが同一形式であることを要求します。まず [Convert.AutoByExtension](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/convert/autobyextension/) などで入力ファイルを共通の形式に変換し、その後で変換後のファイルを結合してください。

**ForEach はマスター、レイアウト、ノート スライドも処理しますか？**

[ForEach.Slide](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/slide/) は通常のプレゼンテーション スライドを走査します。プレゼンテーション全体の [ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/)、[ForEach.Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/paragraph/)、[ForEach.Portion](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/portion/) はデフォルトで通常、マスター、レイアウト スライドを含みます。ノート スライドを含めるには、`includeNotes` を `true` に設定したオーバーロードを使用してください。

**ForEach.Shape と Collect.Shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理したい場合は [ForEach.Shape](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/shape/) を使用します。シェイプの列挙結果を保持し、後でフィルタリング、カウント、複数回走査したい場合は [Collect.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/collect/shapes/) を使用してください。

**Compress は常にプレゼンテーション ファイルを小さくしますか？**

必ずしもそうではありません。結果は、プレゼンテーションに未使用レイアウト、未使用マスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、該当する [Compress](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/) 操作はファイル サイズを縮小しないことがあります。

**ForEach または Compress による変更は自動的に保存されますか？**

いいえ。これらのヘルパーは、メモリ内のロードされた [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) オブジェクトに対して操作します。[ForEach](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/foreach/) コールバックや [Compress](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/) の実行後は、[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) を呼び出して結果を書き出してください。

## **関連記事**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)