---
title: PHP のロウコード プレゼンテーション操作
linktitle: ロウコード API
type: docs
weight: 50
url: /ja/php-java/low-code-presentation-operations/
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
- PHP
- Aspose.Slides
description: "PHP で Aspose.Slides のロウコード API を使用して、プレゼンテーションの変換と結合、コンテンツの反復、シェイプの収集、プレゼンテーションサイズの削減を行います。"
---
## **概要**

[aspose.slides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/) 名前空間は、一般的なプレゼンテーション操作のための静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルワークフローを集中したメソッドでラップし、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの削除を、より少ないコードで行えるようにします。

ロウコードヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係に対して細かな制御が必要な場合は、完全な [Aspose.Slides object model](https://reference.aspose.com/slides/ja/php-java/aspose.slides/) を使用してください。

以下の表は利用可能なヘルパーをまとめたものです。

| ヘルパー | 使用目的 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/php-java/aspose.slides/convert/) | 直接のファイル間呼び出しでプレゼンテーションを別の形式に変換する。 |
| [Merger](https://reference.aspose.com/slides/ja/php-java/aspose.slides/merger/) | 同じ形式のプレゼンテーションファイルを完全に結合する。 |
| [ForEach_](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/) | 各スライド、シェイプ、段落、またはテキスト部分に対してコールバックを実行する。 |
| [Collect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理や分析に使用する。 |
| [Compress](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減する。 |

## **プレゼンテーションの変換**

[Convert::autoByExtension](https://reference.aspose.com/slides/ja/php-java/aspose.slides/convert/#autoByExtension) は、出力ファイルの拡張子だけでエクスポート形式を選択できる場合に使用します。このメソッドはソースプレゼンテーションを開き、出力パスから必要な形式を決定し、結果を書き込みます。

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/ja/php-java/aspose.slides/convert/) クラスは、PDF、SVG、JPEG、PNG、TIFF の出力用の専用メソッドも提供します。エクスポート前にプレゼンテーションを検査または変更する必要がある場合や、選択したヘルパーで提供されていないエクスポートオプションを設定する場合は、完全なオブジェクトモデルを使用してください。形式固有のワークフローとオプションについては、[Convert Presentation](/slides/ja/php-java/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

[Merger::process](https://reference.aspose.com/slides/ja/php-java/aspose.slides/merger/#process) を使用すると、1 回の呼び出しでプレゼンテーションファイル全体を結合できます。入力プレゼンテーションは同じファイル形式である必要があります。

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

すべてのスライドを個別に選択または再マッピングせずに 1 つの結果に追加するだけの場合に、このヘルパーは適しています。選択したスライドを結合したり、宛先のマスターまたはレイアウトを適用したり、セクションを明示的に保持したり、異なるスライドサイズを調整したりする必要がある場合は、完全なオブジェクトモデルを使用してください。これらのシナリオについては、[Merge Presentations](/slides/ja/php-java/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach_](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/) クラスは、要求されたプレゼンテーション要素のタイプごとにコールバックを呼び出します。入れ子になったコレクションループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。

以下の例は、[ForEach_::slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#slide)、[ForEach_::shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#paragraph)、[ForEach_::portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#portion) を使用して、対応する要素を検査します。

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

デフォルトでは、プレゼンテーション全体のシェイプおよびテキストの走査は、通常のスライド、マスター、レイアウトスライドを含みます。`includeNotes` パラメータを持つオーバーロードを使用すると、ノートスライドも処理できます。走査順序、早期終了、コールバック呼び出し前のフィルタリング、または詳細な親子制御が重要な場合は、直接のコレクションループを使用してください。

## **シェイプの収集**

[Collect::shapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/collect/#shapes) は、各シェイプに対するコールバックではなく、プレゼンテーション内のすべてのシェイプのコレクションが必要な場合に使用します。同じセットを複数回フィルタリング、カウント、または処理する場合に便利です。

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

各シェイプをすぐに処理でき、収集した結果を保持する必要がない場合は、代わりに [ForEach_::shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#shape) を使用してください。

## **プレゼンテーションコンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/) クラスは、未使用の構造要素を削除し、埋め込みフォントデータを削減できます。

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) は、通常のスライドが参照していないレイアウトスライドを削除します。
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/#removeUnusedMasterSlides) は、もはや使用されていないマスタースライドを削除します。
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/#compressEmbeddedFonts) は、埋め込みフォントから未使用の文字を削除します。

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

未使用のレイアウトは未使用のマスターより先に削除してください。レイアウトのクリーンアップ後に参照されなくなったマスターも削除されます。最適化されたプレゼンテーションを新しいファイルに保存してください。元のマスター、レイアウト、または完全な埋め込みフォントデータが後で必要になる可能性がある場合に備えてです。詳細については、[Slide Master](/slides/ja/php-java/slide-master/) と [Embedded Font](/slides/ja/php-java/embedded-font/) を参照してください。

## **よくある質問**

**低コード API をフルオブジェクトモデルの代わりに使用すべきタイミングはいつですか？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が必要ない場合にロウコードヘルパーを使用します。個々のスライドを選択したり、マスターやレイアウトの関係を制御したり、中間状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

いいえ。[Merger::process](https://reference.aspose.com/slides/ja/php-java/aspose.slides/merger/#process) は、同じ形式の入力プレゼンテーションが必要です。まず、[Convert::autoByExtension](https://reference.aspose.com/slides/ja/php-java/aspose.slides/convert/#autoByExtension) などで入力ファイルを共通の形式に変換し、変換後のファイルを結合してください。

**ForEach_ はマスター、レイアウト、ノートスライドも処理しますか？**

[ForEach_::slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#slide) は通常のプレゼンテーションスライドのみを反復します。プレゼンテーション全体の [ForEach_::shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#shape)、[ForEach_::paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#paragraph)、[ForEach_::portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#portion) の操作は、デフォルトで通常、マスター、レイアウトスライドを含みます。ノートスライドを含めるには、`includeNotes` を `true` に設定したオーバーロードを使用してください。

**ForEach_::shape と Collect::shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理する場合は [ForEach_::shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_/#shape) を使用します。シェイプのイテラブルな結果を保持し、フィルタリング、カウント、または複数回走査したい場合は [Collect::shapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/collect/#shapes) を使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果は、プレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字が含まれる埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、対応する [Compress](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/) 操作はファイルサイズを減少させない可能性があります。

**ForEach_ や Compress で行った変更は自動的に保存されますか？**

いいえ。これらのヘルパーは、メモリ内のロードされた [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) オブジェクトに対して操作します。[ForEach_](https://reference.aspose.com/slides/ja/php-java/aspose.slides/foreach_) のコールバック内や [Compress](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/) を実行した後は、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) を呼び出して結果を書き出してください。

## **関連記事**

- [プレゼンテーションの変換](/slides/ja/php-java/convert-presentation/)
- [プレゼンテーションの結合](/slides/ja/php-java/merge-presentation/)
- [スライドマスター](/slides/ja/php-java/slide-master/)
- [テキストボックスの管理](/slides/ja/php-java/manage-textbox/)
- [埋め込みフォント](/slides/ja/php-java/embedded-font/)