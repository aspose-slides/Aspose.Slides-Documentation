---
title: JavaScript におけるロウコード プレゼンテーション操作
linktitle: ロウコード API
type: docs
weight: 50
url: /ja/nodejs-java/low-code-presentation-operations/
keywords:
- ロウコード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- スライドの反復
- シェイプの反復
- テキストの反復
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用マスタースライドの削除
- 未使用レイアウトスライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で Aspose.Slides のロウコード API を使用して、プレゼンテーションを変換および結合し、コンテンツを反復処理し、シェイプを収集し、プレゼンテーションのサイズを縮小します。"
---
## **概要**

`aspose.slides` 名前空間は、一般的なプレゼンテーション操作用の静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドでラップしているため、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの削除をより少ないコードで行えます。

ローコードヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides object model](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/) を使用してください。

以下の表は利用可能なヘルパーをまとめたものです。

| ヘルパー | 使用目的 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/convert/) | 直接ファイル間の呼び出しでプレゼンテーションを別形式に変換する。 |
| [Merger](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/merger/) | 同一形式のプレゼンテーションファイル全体を結合する。 |
| [ForEach](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/) | 各スライド、シェイプ、段落、テキスト部分に対してアクションを実行する。 |
| [Collect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理または分析に利用する。 |
| [Compress](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減する。 |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を選択できる場合は、[Convert.autoByExtension](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/convert/#autoByExtension) を使用します。このメソッドはソースプレゼンテーションを開き、出力パスから必要な形式を判定し、結果を書き込みます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/convert/) クラスは、PDF、SVG、JPEG、PNG、TIFF への出力用の専用メソッドも提供します。エクスポート前にプレゼンテーションを確認・修正する必要がある場合や、選択したヘルパーが提供しないエクスポートオプションを設定したい場合は、完全なオブジェクトモデルを使用してください。フォーマット固有のワークフローやオプションについては、[Convert Presentation](/slides/ja/nodejs-java/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

同一形式のプレゼンテーションファイルを1回の呼び出しで結合するには、[Merger.process](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/merger/#process) を使用します。入力プレゼンテーションは同じファイル形式である必要があります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

このヘルパーは、すべてのスライドを1つの結果に順番に追加し、個別に選択や再マッピングを行わないシナリオに適しています。選択したスライドだけを結合したり、宛先マスターやレイアウトを適用したり、セクションを明示的に保持したり、異なるスライドサイズを調整したりする必要がある場合は、完全なオブジェクトモデルを使用してください。これらのシナリオについては、[Merge Presentations](/slides/ja/nodejs-java/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/) クラスは、要求された種類のプレゼンテーション要素ごとにコールバックを呼び出します。ネストしたコレクションループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。Node.js では、`java.newProxy` を使用してコールバックインターフェイスの実装を作成します。

以下の例は、[ForEach.slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#paragraph)、および [ForEach.portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#portion) を使用して、対応する要素を検査します：

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

デフォルトでは、プレゼンテーション全体のシェイプとテキストの走査には、通常スライド、マスタースライド、レイアウトスライドが含まれます。`includeNotes` パラメーターを持つオーバーロードを使用すると、ノートスライドも処理できます。走査順序や早期終了、コールバック呼び出し前のフィルタリング、詳細な親子制御が重要な場合は、直接コレクションループを使用してください。

## **シェイプの収集**

プレゼンテーション内のすべてのシェイプのコレクションが必要で、各シェイプに対するコールバックではなく結果を保持したい場合は、[Collect.shapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/collect/#shapes) を使用します。同じセットを複数回フィルタリング、カウント、または処理する場合に便利です。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

各シェイプを直ちに処理でき、収集結果を保持する必要がない場合は、代わりに [ForEach.shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#shape) を使用してください。

## **プレゼンテーションコンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/) クラスは、未使用の構造要素を削除し、埋め込みフォントデータを削減できます：

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) 未使用のレイアウトスライド（通常スライドが参照していないレイアウトスライド）を削除します。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) 未使用のマスタースライド（使用されなくなったマスタースライド）を削除します。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) 埋め込みフォントから未使用の文字を削除します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

未使用のレイアウトを先に削除し、その後に未使用のマスターを削除してください。レイアウトのクリーンアップ後に参照がなくなったマスターも削除できます。最適化したプレゼンテーションは、新しいファイルに保存してください。元のマスター、レイアウト、または完全な埋め込みフォントデータが後で必要になる可能性がある場合です。詳細については、[Slide Master](/slides/ja/nodejs-java/slide-master/) と [Embedded Font](/slides/ja/nodejs-java/embedded-font/) を参照してください。

## **FAQ**

**低コード API をフルオブジェクトモデルの代わりに使用すべきタイミングは？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合はローコードヘルパーを使用してください。個別のスライドを選択したり、マスターやレイアウトの関係を制御したり、途中の状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

できません。[Merger.process](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/merger/#process) は、同じ形式の入力プレゼンテーションが必要です。まず、たとえば [Convert.autoByExtension](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/convert/#autoByExtension) で入力ファイルを共通の形式に変換し、変換後のファイルを結合してください。

**ForEach はマスター、レイアウト、ノートスライドも処理しますか？**

[ForEach.slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#slide) は通常のプレゼンテーションスライドを走査します。プレゼンテーション全体の [ForEach.shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#paragraph)、および [ForEach.portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#portion) はデフォルトで通常スライド、マスタースライド、レイアウトスライドを含みます。ノートスライドを含めるには、`includeNotes` を `true` に設定したオーバーロードを使用してください。

**ForEach.shape と Collect.shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理したい場合は [ForEach.shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#shape) を使用します。シェイプのイテラブル結果を保持し、フィルタリング、カウント、複数回走査したい場合は [Collect.shapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/collect/#shapes) を使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうとは限りません。結果は、プレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、該当する [Compress](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/) 操作はファイルサイズを削減しないことがあります。

**ForEach や Compress による変更は自動的に保存されますか？**

いいえ。これらのヘルパーはメモリ上の [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) オブジェクトに対して動作します。[ForEach](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/) コールバック内で要素を変更したり、[Compress](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/) を実行した後は、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) を呼び出して結果を書き込んでください。

## **関連記事**

- [Convert Presentation](/slides/ja/nodejs-java/convert-presentation/)
- [Merge Presentations](/slides/ja/nodejs-java/merge-presentation/)
- [Slide Master](/slides/ja/nodejs-java/slide-master/)
- [Manage Text Box](/slides/ja/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/ja/nodejs-java/embedded-font/)