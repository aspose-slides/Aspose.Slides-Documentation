---
title: Java のロウコード プレゼンテーション操作
linktitle: ロウコード API
type: docs
weight: 50
url: /ja/java/low-code-presentation-operations/
keywords:
- ロウコード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- スライドの反復処理
- シェイプの反復処理
- テキストの反復処理
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用のマスタースライドの削除
- 未使用のレイアウトスライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java で Aspose.Slides のロウコード API を使用してプレゼンテーションを変換・結合し、コンテンツを反復処理し、シェイプを収集し、プレゼンテーションサイズを削減します。"
---
## **概要**

The [com.aspose.slides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/) package provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides オブジェクトモデル](https://reference.aspose.com/slides/ja/java/com.aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| ヘルパー | 使用目的 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/) | 直接のファイル間呼び出しでプレゼンテーションを別の形式に変換します。 |
| [Merger](https://reference.aspose.com/slides/ja/java/com.aspose.slides/merger/) | 同じ形式の完全なプレゼンテーションファイルを結合します。 |
| [ForEach](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/) | 各スライド、シェイプ、段落、またはテキスト部分に対してアクションを実行します。 |
| [Collect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/collect/) | 繰り返しの処理や分析のために、プレゼンテーション全体からシェイプを取得します。 |
| [Compress](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減します。 |

## **プレゼンテーションの変換**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [プレゼンテーションの変換](/slides/ja/java/convert-presentation/) for format-specific workflows and options.

## **プレゼンテーションの結合**

Use [Merger.process](https://reference.aspose.com/slides/ja/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) to combine complete presentation files with one call. The input presentations must have the same file format.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [プレゼンテーションの結合](/slides/ja/java/merge-presentation/) for those scenarios.

## **プレゼンテーション要素の反復処理**

The [ForEach](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) to inspect the corresponding elements:

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

Use [Collect.shapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **プレゼンテーション コンテンツの圧縮**

The [Compress](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) removes layout slides that no normal slide references.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) removes master slides that are no longer used.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [スライドマスター](/slides/ja/java/slide-master/) and [埋め込みフォント](/slides/ja/java/embedded-font/).

## **よくある質問**

**低コード API をフル オブジェクトモデルの代わりに使用すべきはいつですか？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合はロウコードヘルパーを使用してください。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、途中状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

いいえ。[Merger.process](https://reference.aspose.com/slides/ja/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) は同じ形式の入力プレゼンテーションが必要です。まず、たとえば [Convert.autoByExtension](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) を使用して入力ファイルを共通の形式に変換し、変換したファイルを結合してください。

**ForEach はマスター、レイアウト、およびノートスライドを処理しますか？**

[ForEach.slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) は通常のプレゼンテーションスライドを走査します。プレゼンテーション全体の [ForEach.shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、および [ForEach.portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) 操作はデフォルトで通常、マスター、レイアウトスライドを含みます。`includeNotes` を `true` に設定したオーバーロードを使用すると、ノートスライドも含めることができます。

**ForEach.shape と Collect.shapes の違いは何ですか？**

[ForEach.shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) はコールバックで各シェイプを即座に処理します。Collect.shapes はイテラブルな結果を取得し、保持、フィルタリング、カウント、または複数回走査できる場合に使用します。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果は、プレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、対応する [Compress](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/) 操作はファイルサイズを削減しないことがあります。

**ForEach や Compress によって行われた変更は自動的に保存されますか？**

いいえ。これらのヘルパーはメモリ内の [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) オブジェクトに対して操作します。[ForEach] コールバックや [Compress] を実行した後は、[Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) を呼び出して結果を書き出してください。

## **関連記事**

- [プレゼンテーションの変換](/slides/ja/java/convert-presentation/)
- [プレゼンテーションの結合](/slides/ja/java/merge-presentation/)
- [スライドマスター](/slides/ja/java/slide-master/)
- [テキストボックスの管理](/slides/ja/java/manage-textbox/)
- [埋め込みフォント](/slides/ja/java/embedded-font/)