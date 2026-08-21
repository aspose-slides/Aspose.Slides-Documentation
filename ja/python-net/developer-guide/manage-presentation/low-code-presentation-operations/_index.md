---
title: Python における低コードプレゼンテーション操作
linktitle: 低コード API
type: docs
weight: 50
url: /ja/python-net/low-code-presentation-operations/
keywords:
- 低コード プレゼンテーション API
- プレゼンテーションの変換
- プレゼンテーションの結合
- シェイプの収集
- プレゼンテーションの圧縮
- 未使用マスタースライドの削除
- 未使用レイアウトスライドの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で Aspose.Slides の低コード API を使用して、プレゼンテーションを変換・結合し、シェイプを収集し、プレゼンテーションのサイズを縮小します。"
---
## **概要**

[aspose.slides.lowcode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/) モジュールは、一般的なプレゼンテーション操作のためのヘルパークラスを提供します。これらのヘルパーは、頻繁に使用されるオブジェクトモデルのワークフローを集中したメソッドにラップし、ファイルの変換や結合、シェイプの収集、未使用コンテンツの削除を少ないコードで実現できます。

低コードヘルパーは、操作がファイル全体またはプレゼンテーション全体に適用され、デフォルトのワークフローが要件に合致する場合に最も有用です。個々のスライド、マスター、レイアウト、シェイプ、エクスポート設定、またはプレゼンテーション要素間の関係に対して細かい制御が必要な場合は、フル [Aspose.Slides オブジェクトモデル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/) を使用してください。

以下の表は利用可能なヘルパーをまとめたものです。

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/) | 直接ファイル間の呼び出しでプレゼンテーションを別形式に変換する場合。 |
| [Merger](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/merger/) | 同一形式のプレゼンテーションファイルを結合する場合。 |
| [Collect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/collect/) | 繰り返し処理や分析のために、プレゼンテーション全体からシェイプを取得する場合。 |
| [Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) | 未使用のマスターやレイアウトを削除し、埋め込みフォントデータを削減する場合。 |

## **プレゼンテーションの変換**

出力ファイルの拡張子だけでエクスポート形式を決定できる場合は、[Convert.auto_by_extension](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/auto_by_extension/) を使用します。このメソッドはソースプレゼンテーションを開き、出力パスから必要な形式を判定し、結果を書き込みます。

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/) クラスは PDF、SVG、JPEG、PNG、TIFF の出力用に特化したメソッドも提供します。エクスポート前にプレゼンテーションを検査・変更したり、ヘルパーが提供しないエクスポートオプションを構成する必要がある場合は、フルオブジェクトモデルを使用してください。形式別のワークフローとオプションについては [Convert Presentation](/python-net/convert-presentation/) を参照してください。

## **プレゼンテーションの結合**

[Merger.process](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/merger/process/) を使用すると、1 回の呼び出しで完全なプレゼンテーションファイルを結合できます。入力プレゼンテーションは同一のファイル形式である必要があります。

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

このヘルパーは、すべてのスライドを個別に選択したり再マッピングしたりせずに、1 つの結果に順次追加したい場合に適しています。選択的にスライドを結合したり、宛先マスターやレイアウトを適用したり、セクションを明示的に保持したり、スライドサイズが異なる場合の調整が必要な場合は、フルオブジェクトモデルを使用してください。これらのシナリオについては [Merge Presentations](/python-net/merge-presentation/) を参照してください。

## **シェイプの収集**

[Collect.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/collect/shapes/) は、プレゼンテーション内のすべてのシェイプのコレクションが必要なときに使用します。同じセットをフィルタリング、カウント、または複数回処理する場合に便利です。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

走査順序、早期終了、処理前のフィルタリング、または親子関係の詳細な制御が重要な場合は、直接コレクションループを使用してください。

## **プレゼンテーションコンテンツの圧縮**

[Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) クラスは、未使用の構造要素を削除し、埋め込みフォントデータを削減できます。

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) は、通常のスライドが参照していないレイアウトスライドを削除します。
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) は、もはや使用されていないマスタースライドを削除します。
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) は、埋め込みフォントから未使用文字を削除します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

未使用レイアウトを先に削除し、その後未使用マスターを削除してください。レイアウトのクリーンアップ後に参照がなくなったマスターも削除対象になります。元のマスター、レイアウト、または完全な埋め込みフォントデータが後で必要になる可能性がある場合は、最適化したプレゼンテーションを別ファイルに保存してください。詳細は [Slide Master](/python-net/slide-master/) と [Embedded Font](/python-net/embedded-font/) を参照してください。

## **FAQ**

**低コード API をフルオブジェクトモデルの代わりに使用すべきタイミングは？**

標準的な操作がファイル全体またはプレゼンテーション全体に適用され、個々の要素に対する詳細な制御が不要な場合に低コードヘルパーを使用します。特定のスライドを選択したり、マスターとレイアウトの関係を制御したり、途中状態を検査したり、ヘルパーが提供しない挙動を設定する必要がある場合は、フルオブジェクトモデルを使用してください。

**Merger は異なるファイル形式のプレゼンテーションを結合できますか？**

できません。[Merger.process](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/merger/process/) は入力プレゼンテーションが同一形式であることを要求します。まず [Convert.auto_by_extension](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/convert/auto_by_extension/) などで入力ファイルを共通形式に変換してから結合してください。

**Collect.shapes が取得する対象は何ですか？**

[Collect.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/collect/shapes/) はプレゼンテーションからシェイプを取得し、保持、フィルタ、カウント、または複数回走査できるようにします。スライドタイプや入れ子オブジェクトの訪問を正確に制御したい場合は、直接コレクションループを使用してください。

**Compress は常にプレゼンテーションファイルを小さくしますか？**

必ずしもそうではありません。結果はプレゼンテーションに未使用レイアウト、未使用マスター、または未使用文字を含む埋め込みフォントがあるかどうかに依存します。これらが存在しない場合、対応する [Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) 操作はファイルサイズを減少させないことがあります。

**Compress による変更は自動的に保存されますか？**

いいえ。これらのヘルパーはメモリ内のロード済み [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトに対して動作します。[Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) 実行後は、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) を呼び出して結果を書き出してください。

## **関連記事**

- [Convert Presentation](/python-net/convert-presentation/)
- [Merge Presentations](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)