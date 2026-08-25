---
title: Android での低コード プレゼンテーション操作
linktitle: 低コード API
type: docs
weight: 50
url: /ja/androidjava/low-code-presentation-operations/
keywords:
- 低コード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- スライドの反復
- シェイプの反復
- テキストの反復
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用マスタスライドの削除
- 未使用レイアウトスライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android で Aspose.Slides の低コード API を使用してプレゼンテーションを変換・結合し、コンテンツを反復処理、シェイプを収集し、プレゼンテーションのサイズを削減します。"
---
## **概要**

[com.aspose.slides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) パッケージは、一般的なプレゼンテーション操作のための静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドにラップし、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの削除を少ないコードで実行できます。

低コードヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、既定のワークフローが要件に合致する場合に最も有用です。個々のスライド、マスタ、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides オブジェクトモデル](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) を使用してください。

以下の表は利用可能なヘルパーをまとめたものです:

| ヘルパー | 用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/) | ファイル間の直接呼び出しでプレゼンテーションを別形式に変換します。 |
| [Merger](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/merger/) | 同一形式のプレゼンテーションファイル全体を結合します。 |
| [ForEach](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/) | 各スライド、シェイプ、段落、テキスト部分に対して処理を実行します。 |
| [Collect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/collect/) | 繰り返し処理や分析のためにプレゼンテーション全体からシェイプを取得します。 |
| [Compress](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/) | 未使用のマスタとレイアウトを削除し、埋め込みフォントデータを縮小します。 |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を決定できる場合は、[Convert.autoByExtension](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) を使用します。このメソッドはソースプレゼンテーションを開き、出力パスから必要な形式を判別し、結果を書き込みます。

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/) クラスは PDF、SVG、JPEG、PNG、TIFF への出力用に専用メソッドも提供しています。エクスポート前にプレゼンテーションを検査・変更したり、選択したヘルパーが公開していないエクスポートオプションを設定したりする必要がある場合は、完全なオブジェクトモデルを使用してください。形式固有のワークフローとオプションについては [Convert Presentation](/slides/ja/androidjava/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

[Merger.process](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) を使用すると、1 回の呼び出しでプレゼンテーションファイル全体を結合できます。入力プレゼンテーションは同じファイル形式である必要があります。

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

すべてのスライドを 1 つの結果に順次追加したい場合にこのヘルパーは適しています。個別にスライドを選択したり、宛先マスタやレイアウトを適用したり、セクションを明示的に保持したり、異なるスライドサイズを調整したりする必要がある場合は、完全なオブジェクトモデルを使用してください。これらのシナリオについては [Merge Presentations](/slides/ja/androidjava/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/) クラスは、要求されたタイプのプレゼンテーション要素ごとにコールバックを呼び出します。ネストしたコレクションループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。

次の例は、[ForEach.slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)、[ForEach.shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、および [ForEach.portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) を使用して対応する要素を検査します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

デフォルトでは、プレゼンテーション全体のシェイプとテキストの走査は通常スライド、マスタスライド、レイアウトスライドを含みます。`includeNotes` パラメーターを持つオーバーロードを使用すれば、ノートスライドも処理できます。走査順序や早期終了、コールバック呼び出し前のフィルタリング、親子関係の詳細な制御が重要な場合は、直接コレクションループを使用してください。

## **シェイプの収集**

[Collect.shapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) は、各シェイプに対するコールバックではなく、プレゼンテーション内のすべてのシェイプのコレクションが必要なときに使用します。同じセットを複数回フィルタリング、カウント、または処理したい場合に便利です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

各シェイプをすぐに処理でき、収集結果を保持する必要がない場合は、代わりに [ForEach.shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) を使用してください。

## **プレゼンテーションコンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/) クラスは、未使用の構造要素を削除し、埋め込みフォントデータを縮小できます:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) は、通常スライドから参照されていないレイアウトスライドを削除します。
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) は、使用されていないマスタスライドを削除します。
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) は、埋め込みフォントから未使用文字を削除します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

未使用レイアウトを削除した後に未使用マスタを削除してください。レイアウトのクリーンアップで参照が失われたマスタも同時に削除できます。元のマスタ、レイアウト、または完全な埋め込みフォントデータが後で必要になる可能性がある場合は、最適化されたプレゼンテーションを新しいファイルに保存してください。詳細は [Slide Master](/slides/ja/androidjava/slide-master/) と [Embedded Font](/slides/ja/androidjava/embedded-font/) を参照してください。

## **FAQ**

**低コード API をフルオブジェクトモデルの代わりに使用すべきタイミングは？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合に低コードヘルパーを使用します。特定のスライドを選択したり、マスタやレイアウトの関係を制御したり、途中状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

できません。`[Merger.process](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-)` は同一形式の入力プレゼンテーションが必要です。まず [Convert.autoByExtension](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) などで入力ファイルを共通形式に変換し、変換後のファイルを結合してください。

**ForEach はマスタ、レイアウト、ノートスライドも処理しますか？**

`[ForEach.slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)` は通常のプレゼンテーションスライドを走査します。プレゼンテーション全体の `[ForEach.shape]`、`[ForEach.paragraph]`、`[ForEach.portion]` 操作はデフォルトで通常、マスタ、レイアウトスライドを含みます。ノートスライドを含めたい場合は、`includeNotes` を `true` に設定したオーバーロードを使用してください。

**ForEach.shape と Collect.shapes の違いは？**

`[ForEach.shape]` はコールバックを介して各シェイプを即座に処理します。`[Collect.shapes]` はシェイプのイテラブル結果を取得でき、保持・フィルタリング・集計・複数回走査が可能です。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。未使用レイアウト、未使用マスタ、または未使用文字を含む埋め込みフォントが存在するかどうかに依存します。これらが存在しない場合、`[Compress]` 系の操作はファイルサイズを減少させないことがあります。

**ForEach や Compress で行った変更は自動的に保存されますか？**

いいえ。これらのヘルパーはメモリ上の `[Presentation]` オブジェクトに対して動作します。`[ForEach]` コールバックや `[Compress]` 実行後は、`[Presentation.save]` を呼び出して結果を書き出す必要があります。

## **関連記事**

- [Convert Presentation](/slides/ja/androidjava/convert-presentation/)
- [Merge Presentations](/slides/ja/androidjava/merge-presentation/)
- [Slide Master](/slides/ja/androidjava/slide-master/)
- [Manage Text Box](/slides/ja/androidjava/manage-textbox/)
- [Embedded Font](/slides/ja/androidjava/embedded-font/)