---
title: Java におけるローコード プレゼンテーション操作
linktitle: ローコード API
type: docs
weight: 50
url: /ja/java/low-code-presentation-operations/
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
  - Java
  - Aspose.Slides
description: "Java で Aspose.Slides ローコード API を使用してプレゼンテーションを変換・結合し、コンテンツを反復処理、シェイプを収集し、プレゼンテーションのサイズを縮小します。"
---
## **概要**

The [com.aspose.slides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/) package provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

low-code ヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、既定のワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides object model](https://reference.aspose.com/slides/ja/java/com.aspose.slides/) を使用してください。

以下の表に利用可能なヘルパーをまとめました。

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/) | ファイル間の直接呼び出しでプレゼンテーションを別の形式に変換します。 |
| [Merger](https://reference.aspose.com/slides/ja/java/com.aspose.slides/merger/) | 同一形式のプレゼンテーションファイル全体を結合します。 |
| [ForEach](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/) | 各スライド、シェイプ、段落、またはテキスト部分に対してアクションを実行します。 |
| [Collect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理や分析に使用します。 |
| [Compress](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを縮小します。 |

## **プレゼンテーションの変換**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/java/convert-presentation/) for format-specific workflows and options.

## **プレゼンテーションの結合**

Use [Merger.process](https://reference.aspose.com/slides/ja/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) to combine complete presentation files with one call. The input presentations must have the same file format.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/java/merge-presentation/) for those scenarios.

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

## **プレゼンテーションコンテンツの圧縮**

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/java/slide-master/) and [Embedded Font](/java/embedded-font/).

## **FAQ**

**When should I use the low-code API instead of the full object model?**  
標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合に low-code ヘルパーを使用します。個別のスライド選択やマスター・レイアウト間の関係制御、途中状態の検査、あるいはヘルパーが提供しない動作の設定が必要な場合は完全なオブジェクトモデルを使用してください。

**Can Merger combine presentations in different file formats?**  
いいえ。[Merger.process](https://reference.aspose.com/slides/ja/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) は同じ形式の入力プレゼンテーションが必要です。まず [Convert.autoByExtension](https://reference.aspose.com/slides/ja/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) などで共通形式に変換してから結合してください。

**Does ForEach process master, layout, and notes slides?**  
[ForEach.slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) は通常のプレゼンテーションスライドを反復します。プレゼンテーション全体の [ForEach.shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)、および [ForEach.portion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) はデフォルトで通常、マスター、レイアウトスライドを含みます。`includeNotes` パラメーターを `true` に設定したオーバーロードを使用するとノートスライドも含められます。

**What is the difference between ForEach.shape and Collect.shapes?**  
[ForEach.shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) はコールバックで各シェイプを即座に処理します。シェイプの結果を保持、フィルタリング、集計、複数回走査したい場合は [Collect.shapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) を使用してください。

**Does Compress always make the presentation file smaller?**  
必ずしもそうではありません。未使用のレイアウト、未使用のマスター、または未使用文字が含まれる埋め込みフォントが存在する場合にのみ、[Compress](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/) の各操作でサイズが削減されます。

**Are changes made by ForEach or Compress saved automatically?**  
いいえ。これらのヘルパーはメモリ上の [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) オブジェクトに対して操作を行います。変更後は [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) を呼び出して結果を書き出してください。

## **関連記事**

- [プレゼンテーションの変換](/java/convert-presentation/)
- [プレゼンテーションの結合](/java/merge-presentation/)
- [スライドマスター](/java/slide-master/)
- [テキストボックスの管理](/java/manage-textbox/)
- [埋め込みフォント](/java/embedded-font/)