---
title: Python でプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/python-net/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進行状況
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でプレゼンテーションを保存する方法を紹介します—レイアウト、フォント、効果を保持しながら PowerPoint または OpenDocument にエクスポートできます。"
---

## **概要**

[Open a Presentation in Python](/slides/ja/python-net/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本記事では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。新規にプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、作業が完了したら保存したくなります。Aspose.Slides for Python を使用すると、**ファイル** または **ストリーム** に保存できます。本記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **プレゼンテーションをファイルに保存**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの `save` メソッドを呼び出してプレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides for Python を使用してプレゼンテーションを保存する方法を示しています。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    
    # ここで何らかの処理を行います...

    # プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **プレゼンテーションをストリームに保存**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの `save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションは多数のストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、シェイプにテキストを追加して、ストリームに保存します。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # プレゼンテーションをストリームに保存します。
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```


## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides for Python を使用すると、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを [ViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) クラスで設定できます。`last_view` プロパティに [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) 列挙体の値を設定します。
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides を使用すると、プレゼンテーションを Strict Office Open XML 形式で保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) クラスを使用し、その conformance プロパティを設定します。`Conformance.ISO_29500_2008_STRICT` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存するものです。
```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # プレゼンテーションを Strict Office Open XML 形式で保存します。
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```


## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの非圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限を課し、またアーカイブ内のファイル数を 65,535 (2^16‑1) に制限します。ZIP64 形式拡張により、これらの制限が 2^64 まで緩和されます。

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) プロパティを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このプロパティは以下のモードを提供します:

- `IF_NECESSARY` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。これは既定のモードです。
- `NEVER` は、ZIP64 形式拡張を使用しません。
- `ALWAYS` は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX としてプレゼンテーションを保存する方法を示しています。
```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.NEVER` で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) プロパティは、PPTX にプレゼンテーションを保存する際のサムネイル生成を制御します：

- `True` に設定すると、保存時にサムネイルが更新されます。これは既定です。
- `False` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードでは、サムネイルを更新せずに PPTX としてプレゼンテーションが保存されます。
```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="Info" color="info" %}}
このオプションは、PPTX 形式でプレゼンテーションを保存するのにかかる時間を短縮するのに役立ちます。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose は独自の API を使用した [無料 PowerPoint Splitter アプリ](https://products.aspose.app/slides/splitter) を開発しました。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」(インクリメンタル保存) は、変更分だけを書き込むことがサポートされていますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します；インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数のスレッドから保存することはスレッドセーフですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスは[スレッドセーフではありません](/slides/ja/python-net/multithreading/); 単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/python-net/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例: 相対パスで指定されたビデオ）は自動的にコピーされませんので、参照先のパスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（作成者、タイトル、会社、日付）を設定/保存できますか？**

はい。標準の[ドキュメント プロパティ](/slides/ja/python-net/presentation-properties/) がサポートされており、保存時にファイルへ書き込まれます。