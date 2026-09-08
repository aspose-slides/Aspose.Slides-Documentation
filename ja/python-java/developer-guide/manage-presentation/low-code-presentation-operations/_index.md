---
title: Python via Java のローコード プレゼンテーション操作
linktitle: ローコード API
type: docs
weight: 50
url: /ja/python-java/low-code-presentation-operations/
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
- Python
- Java
- Aspose.Slides
description: "Python via Java の Aspose.Slides ローコード API を使用して、プレゼンテーションの変換と結合、コンテンツの反復処理、シェイプの収集、プレゼンテーションサイズの削減を行います。"
---
## **概要**

The [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/ja/python-java/aspose.slides/) API は、一般的なプレゼンテーション操作のための静的ヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドでラップし、ファイルの変換や結合、プレゼンテーション要素の処理、シェイプの収集、未使用コンテンツの削除を、少ないコードで実行できるようにします。

ローコードヘルパーは、操作がファイルまたはプレゼンテーション全体に適用され、既定のワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係を細かく制御する必要がある場合は、完全な [Aspose.Slides object model](https://reference.aspose.com/slides/ja/python-java/aspose.slides/) を使用してください。

以下の表は利用可能なヘルパーをまとめたものです。

| ヘルパー | 使用目的 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/python-java/aspose.slides/convert/) | ファイル間の直接呼び出しでプレゼンテーションを別の形式に変換します。 |
| [Merger](https://reference.aspose.com/slides/ja/python-java/aspose.slides/merger/) | 同じ形式のプレゼンテーションファイル全体を結合します。 |
| [ForEach](https://reference.aspose.com/slides/ja/python-java/aspose.slides/foreach/) | 各スライド、シェイプ、段落、またはテキスト部分に対してアクションを実行します。 |
| [Collect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理または分析に使用します。 |
| [Compress](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減します。 |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を選択できる場合は、[Convert.autoByExtension](https://reference.aspose.com/slides/ja/python-java/aspose.slides/convert/#autoByExtension) を使用します。このメソッドはソースのプレゼンテーションを開き、出力パスから必要な形式を判定し、結果を書き込みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/ja/python-java/aspose.slides/convert/) クラスは、PDF、SVG、JPEG、PNG、TIFF の出力用の専用メソッドも提供します。エクスポート前にプレゼンテーションを検査・変更する必要がある場合や、選択したヘルパーで提供されていないエクスポートオプションを設定する場合は、完全なオブジェクトモデルを使用してください。フォーマット固有のワークフローとオプションについては、[Convert Presentation](/slides/ja/python-java/convert-presentation/) を参照してください。

## **プレゼンテーションのマージ**

1 回の呼び出しでプレゼンテーションファイル全体を結合するには、[Merger.process](https://reference.aspose.com/slides/ja/python-java/aspose.slides/merger/#process) を使用します。入力プレゼンテーションは同じファイル形式である必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

すべてのスライドを個別に選択・再マッピングせずに1つの結果に追加するだけの場合、このヘルパーが適しています。選択したスライドをマージしたり、宛先のマスターやレイアウトを適用したり、セクションを明示的に保持したり、スライドサイズが異なる場合に調整したりする必要がある場合は、完全なオブジェクトモデルを使用してください。これらのシナリオについては、[Merge Presentations](/slides/ja/python-java/merge-presentation/) を参照してください。

## **プレゼンテーション要素の反復処理**

[ForEach](https://reference.aspose.com/slides/ja/python-java/aspose.slides/foreach/) クラスは、要求されたプレゼンテーション要素のタイプごとにコールバックを呼び出します。これにより入れ子になったコレクションループを回避でき、プレゼンテーション全体の検査や書式変更に便利です。

次の例は、[ForEach.slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/foreach/#paragraph)、[ForEach.portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/foreach/#portion) を使用して、対応する要素を検査します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

デフォルトでは、プレゼンテーション全体のシェイプおよびテキストの走査は、通常スライド、マスタースライド、レイアウトスライドを含みます。`includeNotes` パラメーター付きのオーバーロードを使用すると、ノートスライドも処理できます。走査順序、早期終了、コールバック呼び出し前のフィルタリング、親子関係の詳細な制御が重要な場合は、直接的なコレクションループを使用してください。

## **シェイプの収集**

各シェイプごとのコールバックではなく、プレゼンテーション内のすべてのシェイプのコレクションが必要な場合は、[Collect.shapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/collect/#shapes) を使用してください。同じセットを複数回フィルタリング、カウント、または処理する必要がある場合に便利です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

各シェイプをすぐに処理でき、収集した結果を保持する必要がない場合は、代わりに [ForEach.shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/foreach/#shape) を使用してください。

## **プレゼンテーションコンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/) クラスは、未使用の構造要素を削除し、埋め込みフォントデータを削減できます：

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) は、通常のスライドから参照されていないレイアウトスライドを削除します。
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedMasterSlides) は、もはや使用されていないマスタースライドを削除します。
- [compressEmbeddedFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#compressEmbeddedFonts) は、埋め込みフォントから未使用の文字を削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

未使用のレイアウトは、未使用のマスターの前に削除してください。レイアウトのクリーンアップ後に参照されなくなったマスターも同様に削除されます。後で元のマスター、レイアウト、または完全な埋め込みフォントデータが必要になる可能性がある場合は、最適化されたプレゼンテーションを新しいファイルに保存してください。詳細については、[Slide Master](/slides/ja/python-java/slide-master/) と [Embedded Font](/slides/ja/python-java/embedded-font/) を参照してください。

## **FAQ**

**ローコード API をフルオブジェクトモデルの代わりに使用すべきタイミングはいつですか？**

標準的な操作がファイルまたはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合は、ローコードヘルパーを使用してください。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、中間状態を検査したり、ヘルパーが提供しない動作を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

いいえ。[Merger.process] は、入力プレゼンテーションが同じ形式であることを要求します。まず入力ファイルを共通の形式に変換してください。例えば [Convert.autoByExtension] を使用し、変換したファイルをマージします。

**ForEach はマスター、レイアウト、ノートスライドも処理しますか？**

[ForEach.slide] は通常のプレゼンテーションスライドを走査します。プレゼンテーション全体の [ForEach.shape]、[ForEach.paragraph]、[ForEach.portion] は、デフォルトで通常、マスター、レイアウトスライドを含みます。ノートスライドも含めるには、`includeNotes` を `True` に設定したオーバーロードを使用してください。

**ForEach.shape と Collect.shapes の違いは何ですか？**

各シェイプをコールバックで即座に処理するには [ForEach.shape] を使用します。保持、フィルタリング、カウント、または複数回の走査が可能なイテラブルな結果が必要な場合は [Collect.shapes] を使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうとは限りません。結果は、プレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、対応する [Compress] 操作はファイルサイズを縮小しないことがあります。

**ForEach または Compress によって行われた変更は自動的に保存されますか？**

いいえ。これらのヘルパーは、メモリ内のロードされた [Presentation] オブジェクトで動作します。[ForEach] コールバックで要素を変更したり、[Compress] を実行した後は、[Presentation.save] を呼び出して結果を書き込んでください。

## **Related Articles**

- [Convert Presentation](/slides/ja/python-java/convert-presentation/)
- [Merge Presentations](/slides/ja/python-java/merge-presentation/)
- [Slide Master](/slides/ja/python-java/slide-master/)
- [Manage Text Box](/slides/ja/python-java/manage-textbox/)
- [Embedded Font](/slides/ja/python-java/embedded-font/)