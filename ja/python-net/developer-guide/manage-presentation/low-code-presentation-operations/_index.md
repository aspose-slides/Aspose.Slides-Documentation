---
title: Python におけるローコード プレゼンテーション操作
linktitle: ローコード API
type: docs
weight: 50
url: /ja/python-net/low-code-presentation-operations/
keywords:
- ローコード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用マスター スライドの削除
- 未使用レイアウト スライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で Aspose.Slides のローコード API を使用して、プレゼンテーションを変換・結合し、シェイプを収集し、プレゼンテーションのサイズを削減します。"
---
## **概要**

[aspose.slides.lowcode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/) モジュールは、一般的なプレゼンテーション操作のためのヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドでラップし、ファイルの変換やマージ、シェイプの収集、未使用コンテンツの削除を少ないコードで実行できるようにします。

Low-code ヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係に対して細かい制御が必要な場合は、完全な [Aspose.Slides オブジェクト モデル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/) を使用してください。

以下の表は利用可能なヘルパーをまとめたものです：

| ヘルパー | 使用用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/) | プレゼンテーションを別の形式に変換し、ファイル間の直接呼び出しで実行する。 |
| [Merger](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/merger/) | 同じ形式のプレゼンテーションファイル全体を結合する。 |
| [Collect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/collect/) | プレゼンテーション全体からシェイプを取得し、繰り返し処理や分析に使用する。 |
| [Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) | 未使用のマスターとレイアウトを削除し、埋め込みフォントデータを削減する。 |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を選択できる場合は、[Convert.auto_by_extension](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/auto_by_extension/) を使用してください。このメソッドはソースプレゼンテーションを開き、出力パスから必要な形式を判定し、結果を書き出します。

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/) クラスは、PDF、SVG、JPEG、PNG、TIFF の出力用の専用メソッドも提供します。エクスポート前にプレゼンテーションを検査または変更する必要がある場合や、選択したヘルパーでは提供されていないエクスポートオプションを設定する必要がある場合は、完全なオブジェクトモデルを使用してください。[Convert Presentation](/slides/ja/python-net/convert-presentation/) で形式固有のワークフローとオプションを確認できます。

## **プレゼンテーションのマージ**

[Merger.process](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/merger/process/) を使用して、1 回の呼び出しでプレゼンテーションファイル全体を結合します。入力プレゼンテーションは同じファイル形式である必要があります。

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

このヘルパーは、すべてのスライドを 1 つの結果に追加し、個別に選択またはリマッピングする必要がない場合に適しています。選択したスライドをマージしたり、宛先マスターやレイアウトを適用したり、セクションを明示的に保持したり、異なるスライドサイズを調整したりする必要がある場合は、完全なオブジェクトモデルを使用してください。[Merge Presentations](/slides/ja/python-net/merge-presentation/) でこれらのシナリオを確認できます。

## **シェイプの収集**

[Collect.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/collect/shapes/) を使用すると、プレゼンテーション内のすべてのシェイプのコレクションを取得できます。同じセットをフィルタリング、カウント、または複数回処理する場合に便利です。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

走査順序、早期終了、処理前のフィルタリング、または詳細な親子制御が重要な場合は、直接コレクションループを使用してください。

## **プレゼンテーション コンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) クラスは、未使用の構造要素を削除し、埋め込みフォントデータを削減できます。

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) は、通常のスライドから参照されていないレイアウトスライドを削除します。
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) は、使用されなくなったマスタースライドを削除します。
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) は、埋め込みフォントから未使用文字を削除します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

未使用のレイアウトは未使用のマスターより先に削除してください。レイアウトのクリーンアップ後に参照されなくなったマスターも削除できます。最適化されたプレゼンテーションを新しいファイルに保存すれば、元のマスター、レイアウト、または完全な埋め込みフォントデータが後で必要になる場合に備えられます。詳細は [Slide Master](/slides/ja/python-net/slide-master/) と [Embedded Font](/slides/ja/python-net/embedded-font/) を参照してください。

## **FAQ**

**低コード API をフルオブジェクトモデルの代わりに使用すべき場合はいつですか？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要なときに低コードヘルパーを使用してください。特定のスライドを選択したり、マスターやレイアウトの関係を制御したり、途中状態を検査したり、ヘルパーが提供しない動作を構成する必要がある場合はフルオブジェクトモデルを使用します。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

いいえ。[Merger.process](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/merger/process/) は入力プレゼンテーションが同じ形式であることを前提としています。まず [Convert.auto_by_extension](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/auto_by_extension/) などで共通形式に変換し、その後で結合してください。

**Collect.shapes に含まれるものは何ですか？**

[Collect.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/collect/shapes/) はプレゼンテーションからシェイプを取得し、保持、フィルタリング、カウント、または複数回走査できるようにします。走査するスライド種別や入れ子オブジェクトを正確に制御したい場合は、直接コレクションループを使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果はプレゼンテーションに未使用のレイアウト、未使用のマスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、対応する [Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) 操作はファイルサイズを削減しないことがあります。

**Compress による変更は自動的に保存されますか？**

いいえ。これらのヘルパーはメモリ内の [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトに対して操作します。[Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) 実行後は、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) を呼び出して結果を書き出してください。

## **関連記事**

- [Convert Presentation](/slides/ja/python-net/convert-presentation/)
- [Merge Presentations](/slides/ja/python-net/merge-presentation/)
- [Slide Master](/slides/ja/python-net/slide-master/)
- [Manage Text Box](/slides/ja/python-net/manage-textbox/)
- [Embedded Font](/slides/ja/python-net/embedded-font/)