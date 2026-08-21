---
title: JavaScript のローコード プレゼンテーション操作
linktitle: ローコード API
type: docs
weight: 50
url: /ja/nodejs-java/low-code-presentation-operations/
keywords:
- ローコード プレゼンテーション API
- プレゼンテーション変換
- プレゼンテーション結合
- スライド反復
- シェイプ反復
- テキスト反復
- シェイプ収集
- プレゼンテーション圧縮
- 未使用マスタースライドの削除
- 未使用レイアウトスライドの削除
- 埋め込みフォント圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で Aspose.Slides のローコード API を使用して、プレゼンテーションの変換および結合、コンテンツの反復、シェイプの収集、プレゼンテーションサイズの削減を行います。"
---
## **概要**

`aspose.slides` 名前空間は、一般的なプレゼンテーション操作のための静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドでラップし、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの削除を少ないコードで実現できます。

ローコードヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、既定のワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides オブジェクトモデル](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/) を使用してください。

次の表は利用可能なヘルパーをまとめたものです。

| ヘルパー | 用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/convert/) | プレゼンテーションを別の形式に変換し、直接ファイル間で呼び出す。 |
| [Merger](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/merger/) | 同じ形式のプレゼンテーションファイル全体を結合する。 |
| [ForEach](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/) | 各スライド、シェイプ、段落、またはテキスト部分に対してアクションを実行する。 |
| [Collect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理または分析に使用する。 |
| [Compress](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減する。 |

## **プレゼンテーションの変換**

`[Convert.autoByExtension](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/convert/#autoByExtension)` を使用すると、出力ファイルの拡張子だけでエクスポート形式を選択できる場合に便利です。このメソッドはソースプレゼンテーションを開き、出力パスから必要な形式を判断し、結果を書き込みます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/convert/) クラスは PDF、SVG、JPEG、PNG、TIFF 出力用の専用メソッドも提供します。エクスポート前にプレゼンテーションを検査・変更する必要がある場合や、選択されたヘルパーでは提供されていないエクスポートオプションを設定する場合は、完全なオブジェクトモデルを使用してください。形式固有のワークフローやオプションについては、[Convert Presentation](/nodejs-java/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

`[Merger.process](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/merger/#process)` を使用すると、1 回の呼び出しでプレゼンテーションファイル全体を結合できます。入力プレゼンテーションは同じファイル形式である必要があります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

すべてのスライドを個別に選択・再マッピングせずに1つの結果に付加したい場合にこのヘルパーは適しています。選択したスライドを結合したり、宛先マスターやレイアウトを適用したり、セクションを明示的に保持したり、異なるスライドサイズを調整する必要がある場合は、完全なオブジェクトモデルを使用してください。これらのシナリオについては、[Merge Presentations](/nodejs-java/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/) クラスは、要求されたプレゼンテーション要素の型ごとにコールバックを呼び出します。ネストしたコレクションループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。Node.js では、`java.newProxy` を使用してコールバックインターフェイスの実装を作成します。

以下の例では、[ForEach.slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#paragraph)、[ForEach.portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#portion) を使用してそれぞれの要素を検査します：

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

デフォルトでは、プレゼンテーション全体のシェイプおよびテキストの走査は通常スライド、マスタースライド、レイアウトスライドを含みます。`includeNotes` パラメーターを持つオーバーロードを使用すると、ノートスライドも処理できます。走査順序、早期終了、コールバック呼び出し前のフィルタリング、または詳細な親子関係の制御が重要な場合は、直接コレクションループを使用してください。

## **シェイプの収集**

各シェイプごとのコールバックではなく、プレゼンテーション内のすべてのシェイプのコレクションが必要な場合は、[Collect.shapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/collect/#shapes) を使用してください。同じセットを複数回フィルタリング、カウント、または処理する場合に便利です。

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

各シェイプをすぐに処理でき、収集した結果を保持する必要がない場合は、代わりに [ForEach.shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/foreach/#shape) を使用してください。

## **プレゼンテーションコンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/) クラスは未使用の構造要素を削除し、埋め込みフォントデータを削減できます。

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) は、通常のスライドから参照されていないレイアウトスライドを削除します。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) は、もはや使用されていないマスタースライドを削除します。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) は、埋め込みフォントから未使用の文字を削除します。

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

未使用のレイアウトは未使用のマスターより先に削除してください。レイアウトのクリーンアップ後に参照がなくなったマスターも削除できます。元のマスター、レイアウト、または完全な埋め込みフォントデータが後で必要になる可能性がある場合は、最適化されたプレゼンテーションを新しいファイルに保存してください。詳細については、[Slide Master](/nodejs-java/slide-master/) と [Embedded Font](/nodejs-java/embedded-font/) を参照してください。

## **FAQ**

**低コード API をフルオブジェクトモデルの代わりに使用すべき場面はいつですか？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合は、ローコードヘルパーを使用してください。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、中間状態を検査したり、ヘルパーが提供しない動作を設定したりする必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

いいえ。[Merger.process] は入力プレゼンテーションが同じ形式であることを前提としています。まず入力ファイルを共通の形式に変換してください（例: [Convert.autoByExtension] を使用）。その後、変換されたファイルを結合します。

**ForEach はマスター、レイアウト、ノートスライドも処理しますか？**

[ForEach.slide] は通常のプレゼンテーションスライドのみを走査します。プレゼンテーション全体の [ForEach.shape]、[ForEach.paragraph]、[ForEach.portion] はデフォルトで通常スライド、マスタースライド、レイアウトスライドを含みます。ノートスライドも含めるには、`includeNotes` を `true` に設定したオーバーロードを使用してください。

**ForEach.shape と Collect.shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理したい場合は [ForEach.shape] を使用します。結果を保持したり、フィルタリング、カウント、または複数回走査したりできる反復可能なコレクションが必要な場合は [Collect.shapes] を使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果はプレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、該当する [Compress] の操作はファイルサイズを削減しないことがあります。

**ForEach や Compress で行われた変更は自動的に保存されますか？**

いいえ。これらのヘルパーはメモリ内のロード済み [Presentation] オブジェクトに対して動作します。[ForEach] コールバックで要素を変更したり、[Compress] を実行した後は、結果を書き込むために [Presentation.save] を呼び出してください。

## **関連記事**

- [プレゼンテーションの変換](/nodejs-java/convert-presentation/)
- [プレゼンテーションの結合](/nodejs-java/merge-presentation/)
- [スライド マスター](/nodejs-java/slide-master/)
- [テキスト ボックスの管理](/nodejs-java/manage-textbox/)
- [埋め込みフォント](/nodejs-java/embedded-font/)