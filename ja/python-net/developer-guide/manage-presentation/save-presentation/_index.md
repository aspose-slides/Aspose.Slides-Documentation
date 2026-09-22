---
title: Python でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
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
description: "Aspose.Slides を使用して、Python で PowerPoint および OpenDocument のプレゼンテーションをファイルまたはストリームに保存し、PPTX 出力オプションを構成します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/python-net/open-presentation/)と、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipresentation/save/) メソッドを使用して結果を書き出します。Aspose.Slides for Python via .NET は、PowerPoint、OpenDocument、PDF などの形式でプレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **ファイルにプレゼンテーションを保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipresentation/save/) メソッドに渡します。format の値は、Aspose.Slides が作成するファイルのタイプを決定します。

次の例は、プレゼンテーションを作成し、PPTX ファイルとして保存します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # プレゼンテーションのコンテンツを追加または変更します。

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **元の形式でプレゼンテーションを保存**

ファイルとストリームの検出例、新規作成されたプレゼンテーションの挙動、ソース形式と出力形式の違いについては、[Determine the Original Presentation Format](/slides/ja/python-net/detect-presentation-source-format/) を参照してください。

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルを読み込んだ後、[Presentation.source_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/source_format/) プロパティから元の形式を取得します。取得した [SourceFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sourceformat/) の値を [SlideUtil.to_save_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/to_save_format/) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) の値を取得し、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipresentation/save/) で変更後のプレゼンテーションを書き出します。

次の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新し、ロード元の形式で出力ディレクトリに保存します。

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/to_save_format/) は、PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、および PowerPoint XML をそれぞれのプレゼンテーション保存形式にマッピングします。これはプレゼンテーションのソース形式のみをマッピングし、PDF、HTML、TIFF、画像などのエクスポート形式を選択するためのものではありません。サポートされていない、または無効な [SourceFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sourceformat/) の値を渡すと例外がスローされます。

従来の PPT、PPS、POT ファイルは同じバイナリコンテナを使用します。このようなプレゼンテーションを拡張子なしのストリームから読み込んだ場合、PPS や POT ファイルが PPT と識別されることがあります。これらのレガシーサブタイプを維持する必要がある場合は、元のファイル名またはフォーマットメタデータを別途保持し、出力ファイル名と形式を選択する際に使用してください。

## **ストリームにプレゼンテーションを保存**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能な [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) ストリームと [SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipresentation/save/) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、またはメモリ内で処理する場合に便利です。

次の例は、新しいプレゼンテーションをファイルストリームに保存します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **事前定義されたビュータイプでプレゼンテーションを保存**

保存されたプレゼンテーションを PowerPoint が最初に開くビューを指定できます。保存前に [ViewProperties.last_view](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/last_view/) プロパティを [ViewType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewtype/) の値に設定します。

次の例は、Slide Master ビューを初期ビューとして設定します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Office Open XML の Strict プロファイルに準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/) のインスタンスを作成し、その [conformance](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/conformance/) プロパティを `Conformance.ISO_29500_2008_STRICT` に設定します。その後、オプションを [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ipresentation/save/) メソッドに渡します。

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

標準的な ZIP アーカイブは、各エントリの圧縮および非圧縮サイズ、アーカイブ全体のサイズ、エントリ数に制限があります。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。ZIP64 拡張機能は、該当するサイズおよびエントリ数の制限を拡大します。

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) プロパティを使用して、Aspose.Slides が ZIP64 拡張を書き込むかどうかを制御します：

- `IF_NECESSARY` は、プレゼンテーションが標準 ZIP 制限を超える場合にのみ ZIP64 を使用します。デフォルトのモードです。
- `NEVER` は ZIP64 拡張を無効にします。
- `ALWAYS` は常に ZIP64 拡張を書き込みます。

次の例は、出力プレゼンテーションに対して常に ZIP64 拡張を有効にします。

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode.NEVER` が使用され、プレゼンテーションが標準 ZIP 制限に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベルで Office Open XML 形式でプレゼンテーションを保存**

PPTX 出力では、[PptxOptions.compression_level](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/compression_level/) プロパティを設定することで、保存速度とファイルサイズのバランスを取ることができます。[CompressionLevel] 列挙体は以下の値を提供します：

- `NONE` は圧縮なしでデータを保存します。
- `LEVEL1` は最速の圧縮で、圧縮後の出力が最大になります。
- `LEVEL2` から `LEVEL5` は、保存速度よりも出力サイズの小ささを段階的に優先します。
- `LEVEL6` は保存速度とファイルサイズのバランスを取ります。デフォルトのレベルです。
- `LEVEL7` と `LEVEL8` は、保存速度よりもさらに出力サイズの小ささを優先します。
- `LEVEL9` は最強の圧縮を提供し、最も多くの処理時間が必要です。

次の例は、圧縮なしでプレゼンテーションを保存します。

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

次の例は、最大の圧縮レベルを使用します。

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **サムネイルを更新せずにプレゼンテーションを保存**

PPTX としてプレゼンテーションを保存する際、[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) プロパティがドキュメントのサムネイルを制御します：

- `True` は保存操作中にサムネイルを再生成します。デフォルト値です。
- `False` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides は生成しません。

次の例は、サムネイルを更新せずにプレゼンテーションを保存します。

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
サムネイルの更新を無効にすると、PPTX ファイルの保存にかかる時間を短縮できます。
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose は、Aspose.Slides API を使用して構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。これにより、プレゼンテーションから選択したスライドを個別の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタルまたは「高速保存」をサポートしていますか？**

いいえ。各保存操作は、変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドが同じ Presentation インスタンスを保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスは[スレッド セーフではありません](/slides/ja/python-net/multithreading/)。各インスタンスへのアクセスと保存は、同時に 1 つのスレッドからだけ行ってください。

**プレゼンテーションを保存すると、ハイパーリンクや外部リンクされたファイルはどうなりますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はプレゼンテーションに残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションはそれらの場所に引き続きアクセスできる必要があります。

**作者、タイトル、会社、作成日などのドキュメント メタデータを保存できますか？**

はい。保存前に適切な [document properties](/slides/ja/python-net/presentation-properties/) を設定すれば、Aspose.Slides がそれらを出力ファイルに書き込みます。