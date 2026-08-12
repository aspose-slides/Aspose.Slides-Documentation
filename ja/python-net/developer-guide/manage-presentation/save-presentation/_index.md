---
title: Python でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/python-net/save-presentation/
keywords:
- PowerPoint の保存
- OpenDocument の保存
- プレゼンテーションの保存
- スライドの保存
- PPT の保存
- PPTX の保存
- ODP の保存
- ファイルへのプレゼンテーション出力
- ストリームへのプレゼンテーション出力
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進行状況
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でプレゼンテーションを保存する方法を紹介します。PowerPoint や OpenDocument 形式へレイアウト、フォント、エフェクトを保持したままエクスポートできます。"
---
## **概要**

[Open a Presentation in Python](/slides/ja/python-net/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法を説明しています。本記事では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、作業が完了したら保存したくなるでしょう。Aspose.Slides for Python を使用すると、**ファイル** または **ストリーム** に保存できます。本記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルへのプレゼンテーションの保存**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスの `save` メソッドを呼び出すことで、プレゼンテーションをファイルに保存できます。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides for Python を使用してプレゼンテーションを保存する方法を示しています。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    
    # ここで作業を行います...

    # プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ストリームへのプレゼンテーションの保存**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスの `save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # プレゼンテーションをストリームに保存します。
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides for Python では、[ViewProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/) クラスを介して、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを設定できます。`last_view` プロパティに [ViewType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewtype/) 列挙体から値を設定してください。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides では、Strict Office Open XML 形式でプレゼンテーションを保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/) クラスを使用し、その `conformance` プロパティを設定します。`Conformance.ISO_29500_2008_STRICT` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例はプレゼンテーションを作成し、Strict Office Open XML 形式で保存する方法を示しています。

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # プレゼンテーションを Strict Office Open XML 形式で保存します。
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Office Open XML 形式で Zip64 モードでプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、未圧縮サイズ・圧縮サイズ・アーカイブ全体のサイズが 4 GB (2^32 バイト) に制限され、ファイル数は 65 535 (2^16‑1) に制限されます。ZIP64 形式拡張により、これらの制限が 2^64 まで緩和されます。

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) プロパティを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このプロパティは次のモードを提供します:

- `IF_NECESSARY` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。デフォルトモードです。
- `NEVER` は ZIP64 形式拡張を使用しません。
- `ALWAYS` は常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.NEVER` で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **Office Open XML 形式で圧縮レベルを指定してプレゼンテーションを保存**

大容量のプレゼンテーションを扱う場合、圧縮レベルを調整してファイルサイズと処理時間のバランスを取ることができます。要件に応じて、処理速度を優先したり、出力ファイルを小さくしたり選択できます。

Aspose.Slides は、Office Open XML 形式で保存する際に使用する圧縮レベルを指定できる [PptxOptions.compression_level](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/compression_level/) プロパティを提供します。

利用可能な圧縮レベルは次のとおりです:

- [**NONE**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): 圧縮を行いません。ファイルはそのまま保存されます。
- [**LEVEL1**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): 最速の圧縮で、圧縮率は最低です。
- [**LEVEL2**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): **LEVEL1** より若干圧縮率が向上し、速度も高速です。
- [**LEVEL3**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): **LEVEL2** より圧縮率が高く、処理時間への影響は中程度です。
- [**LEVEL4**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): **LEVEL3** よりさらに圧縮率が向上します。
- [**LEVEL5**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): **LEVEL4** より圧縮率が向上し、追加の処理時間がかかります。
- [**LEVEL6**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): 標準的な圧縮で、処理速度とファイルサイズのバランスが良好です。*既定の圧縮レベル* です。
- [**LEVEL7**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): **LEVEL6** より圧縮率が高く、処理は遅くなります。
- [**LEVEL8**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): **LEVEL7** よりさらに圧縮率が向上します。
- [**LEVEL9**](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/compressionlevel/): 最大の圧縮率です。最小のファイルサイズになりますが、処理時間が最も長くなります。

以下の例は、圧縮なしで PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

この例は、最大圧縮で PPTX ファイルとしてプレゼンテーションを保存する方法を示しています。

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) プロパティは、PPTX に保存する際のサムネイル生成を制御します。

- `True` に設定すると、保存時にサムネイルが更新されます。これは既定値です。
- `False` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードは、サムネイルを更新せずに PPTX としてプレゼンテーションを保存する例です。

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
このオプションを使用すると、PPTX 形式での保存にかかる時間を短縮できます。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose は、独自 API を使用した無料の PowerPoint Splitter アプリ ([https://products.aspose.app/slides/ja/splitter](https://products.aspose.app/slides/ja/splitter)) を提供しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」(インクリメンタル保存) がサポートされ、変更分だけが書き込まれますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスは **スレッドセーフではありません** (/slides/ja/python-net/multithreading/)。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) は保持されます。外部リンクされたファイル (例: 相対パスで参照される動画) は自動的にコピーされません。参照先のパスが引き続きアクセス可能であることを確認してください。

**文書メタデータ (Author、Title、Company、Date) を設定/保存できますか？**

はい。標準の [document properties](/slides/ja/python-net/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。