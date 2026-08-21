---
title: Android 用 ローコード プレゼンテーション操作
linktitle: ローコード API
type: docs
weight: 50
url: /ja/androidjava/low-code-presentation-operations/
keywords:
- ローコード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- スライドの反復処理
- シェイプの反復処理
- テキストの反復処理
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用マスタースライドの削除
- 未使用レイアウトスライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android で Aspose.Slides のローコード API を使用して、プレゼンテーションの変換と結合、コンテンツの反復処理、シェイプの収集、そしてプレゼンテーションサイズの削減を行います。"
---
## **概要**

The [com.aspose.slides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) package provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code ヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides object model](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) を使用してください。

以下の表は、利用可能なヘルパーを要約しています。

| ヘルパー | 使用用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/) | 直接的なファイル間呼び出しでプレゼンテーションを別の形式に変換します。 |
| [Merger](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/merger/) | 同じ形式の完全なプレゼンテーションファイルを結合します。 |
| [ForEach](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/) | 各スライド、シェイプ、段落、またはテキスト部分に対してアクションを実行します。 |
| [Collect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理や分析に利用します。 |
| [Compress](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減します。 |

## **プレゼンテーションの変換**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/androidjava/convert-presentation/) for format-specific workflows and options.

## **プレゼンテーションの結合**

Use [Merger.process](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) to combine complete presentation files with one call. The input presentations must have the same file format.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/androidjava/merge-presentation/) for those scenarios.

## **プレゼンテーション要素の反復処理**

The [ForEach](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) to inspect the corresponding elements:

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

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **シェイプの収集**

Use [Collect.shapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **プレゼンテーションコンテンツの圧縮**

The [Compress](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) removes layout slides that no normal slide references.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) removes master slides that are no longer used.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/androidjava/slide-master/) and [Embedded Font](/androidjava/embedded-font/).

## **よくある質問**

**低コード API をフルオブジェクトモデルの代わりに使用すべきタイミングはいつですか？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合は、低コードヘルパーを使用してください。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、途中の状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

いいえ。[Merger.process](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) は、入力プレゼンテーションが同じ形式であることを要求します。まず入力ファイルを共通の形式に変換してください（例: [Convert.autoByExtension](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) を使用）。その後、変換されたファイルをマージします。

**ForEach はマスター、レイアウト、ノートスライドも処理しますか？**

[ForEach.slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) は通常のプレゼンテーションスライドを走査します。プレゼンテーション全体の [ForEach.shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、[ForEach.portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) の操作は、デフォルトで通常、マスター、レイアウトスライドを含みます。ノートスライドを含めるには、`includeNotes` を `true` に設定したオーバーロードを使用してください。

**ForEach.shape と Collect.shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理する場合は [ForEach.shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) を使用します。取得した結果を保持したり、フィルタリング、カウント、または複数回走査できるイテラブル結果が必要な場合は [Collect.shapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) を使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果は、プレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、該当する [Compress] 操作はファイルサイズを削減しないことがあります。

**ForEach や Compress による変更は自動的に保存されますか？**

いいえ。これらのヘルパーは、メモリ上にロードされた [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) オブジェクトに対して操作します。[ForEach] のコールバックで要素を変更したり、[Compress] を実行した後は、結果を書き込むために [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) を呼び出してください。

## **関連記事**

- [プレゼンテーションの変換](/androidjava/convert-presentation/)
- [プレゼンテーションの結合](/androidjava/merge-presentation/)
- [スライドマスター](/androidjava/slide-master/)
- [テキストボックスの管理](/androidjava/manage-textbox/)
- [埋め込みフォント](/androidjava/embedded-font/)