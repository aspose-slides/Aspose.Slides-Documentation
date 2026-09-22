---
title: Pythonで元のプレゼンテーション形式を判定する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/python-net/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、Python でロードされたプレゼンテーションの元の形式を読み取り、検出 API を比較し、ファイル、ストリーム、レガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションをロードした後、読み取り専用の[Presentation.source_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/source_format/) プロパティを読み取り、元の形式を判断します。現在のインスタンスがロードされた形式に依存する後続の処理が必要な場合に使用します。

ソース形式は、出力ファイル用に選択された[SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) とは異なります。別の形式で保存しても、既存のインスタンスのソース形式は変更されません。

## **ファイルのソース形式を読み取る**

この例は既存の `sample.pptx` ファイルが必要です。ファイルをロードし、ファイル名ではなく[Presentation.source_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/source_format/) を使用してアプリケーションの処理ポリシーを選択します。入力パスを変更して他の形式を試してください。例では選択されたポリシーを出力しますので、メッセージをアプリケーションのロジックに置き換えてください。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **サポートされている値を認識する**

[SourceFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sourceformat/) 列挙体は、以下のプレゼンテーション形式を区別します。以下の拡張子は慣例的なものであり、元のファイル名を再構築したものではありません。

| SourceFormat 値 | 拡張子 | 形式 |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 プレゼンテーション |
| `PPTX` | `.pptx` | Office Open XML プレゼンテーション |
| `PPTM` | `.pptm` | マクロ有効 Office Open XML プレゼンテーション |
| `PPS` | `.pps` | PowerPoint 97–2003 スライドショー |
| `PPSX` | `.ppsx` | Office Open XML スライドショー |
| `PPSM` | `.ppsm` | マクロ有効 Office Open XML スライドショー |
| `POT` | `.pot` | PowerPoint 97–2003 テンプレート |
| `POTX` | `.potx` | Office Open XML テンプレート |
| `POTM` | `.potm` | マクロ有効 Office Open XML テンプレート |
| `ODP` | `.odp` | OpenDocument プレゼンテーション |
| `OTP` | `.otp` | OpenDocument プレゼンテーションテンプレート |
| `FODP` | `.fodp` | Flat XML ODF プレゼンテーション |
| `XML` | `.xml` | PowerPoint XML プレゼンテーション |

## **ストリームのソース形式を読み取る**

この例は既存の `sample.pps` ファイルが必要です。そのバイトをメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで受け取った入力をシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) コンストラクタはストリームのみを受け取ります。

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT、PPS、POT は同じ基礎バイナリ形式を使用します。ファイルパスでロードする場合、拡張子はスライドショーやテンプレートを区別するのに役立ちます。ファイル名がない場合、従来の PPS や POT のコンテンツは `SourceFormat.PPT` と報告されることがあります；上記の PPS の例は `PPT` を報告します。

アプリケーションがこの区別を保持しなければならない場合は、元のファイル名またはサブタイプメタデータを別途保持してください。拡張子はこれらの従来サブタイプに対する有用なヒントですが、任意のプレゼンテーションコンテンツを識別する唯一の根拠にすべきではありません。

## **ロード前後の検出を比較する**

ファイルを完全なプレゼンテーション オブジェクト モデルとしてロードする前に検査する必要がある場合は、[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) と [PresentationInfo.load_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/load_format/) を使用します。インスタンスが既に存在する場合は、[Presentation.source_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/source_format/) を使用します。

この例は `sample.pptx` が必要で、両方のチェックで `PPTX` を出力します。本番環境では、処理段階に適した API を選択してください。既にロードされたプレゼンテーションは、ソース形式を取得するためだけに再度検査する必要はありません。

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

結果は異なる列挙型です: [LoadFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sourceformat/)。数値にキャストして比較したり、すべての形式が同一の検出結果を持つと想定しないでください。以下で説明する保存後再オープンのチェックでは、PowerPoint XML はロード前に `LoadFormat.UNKNOWN` と報告され、ロード後に `SourceFormat.XML` と報告されました。

## **ソース形式と出力形式を分離する**

この例は `sample.pptx` が必要で、`converted.odp` に書き込みます。元のインスタンスを保存する前後の両方で `PPTX` を出力します。ODP 出力からロードされた新しいインスタンスだけが `ODP` を報告します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

`slides.Presentation()` でスクラッチから作成したプレゼンテーションは `SourceFormat.PPTX` と報告します。入力ファイルがないため、これは新規作成インスタンスのデフォルト値であり、PPTX ファイルがロードされたという証拠ではありません。その区別が重要な場合は、アプリケーションがインスタンスを作成したかロードしたかを別途追跡してください。

## **ソース形式を拡張子にマッピングする**

以下の例は `sample.pptx` が必要です。現在サポートされているすべての [SourceFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sourceformat/) 値を、入力ファイル名を解析せずに慣例的な拡張子にマッピングします。フォールバックにより、認識されない値に対して拡張子が黙って割り当てられることを防ぎます。

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

このマッピングはファイルを変換したり、ストリーム読み込み時に失われた従来の PPS/POT サブタイプを復元したりするものではありません。実際に保存する際は、[SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) を明示的に選択するか、[Save Presentations in Their Original Format](/slides/ja/python-net/save-presentation/#save-presentations-in-their-original-format) に示された変換を使用してください。

## **保存と再オープンで形式を検証する**

この単体例はプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き込み、同名のファイルがあれば上書きします。各出力をパスで開き直すと同時に、メモリストリームでも再オープンします。PPTX と ODP の場合、両ルートとも保存された形式を報告します。PPS の場合、パスでロードすると `PPS` を報告しますが、ファイル名なしで同じバイト列をロードすると `PPT` を報告します。

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

上記のすべての形式で同様のチェックを行うと、拡張子が一致する生成されたプレゼンテーションについて以下の結果が得られました。

| 保存形式 | ファイルパスからの SourceFormat | 無名ストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectively | ファイルパスと同じ |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectively | ファイルパスと同じ |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectively | ファイルパスと同じ |
| ODP, OTP | `ODP`, `OTP` respectively | ファイルパスと同じ |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

これらのチェックでは、無名ストリームに対して PPS/POT が `PPT` に正規化された唯一のソース形式の正規化でした。表は形式の識別を示しており、変換時にすべてのプレゼンテーション機能が保持されることを意味するものではありません。

## **FAQ**

**ODP に保存すると、PPTX からロードされたプレゼンテーションのソース形式は変わりますか？**

いいえ。既存のインスタンスは依然として `PPTX` と報告します。保存された ODP ファイルからロードされたインスタンスは `ODP` と報告します。

**ストリームは常に従来のプレゼンテーション、スライドショー、テンプレートを区別できますか？**

いいえ。PPT、PPS、POT はバイナリ形式を共有します。区別が必要な場合は、ファイル名またはサブタイプメタデータを別途保持してください。

**プレゼンテーションが既にロードされている場合、どの API を使用すべきですか？**

[Presentation.source_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/source_format/) を読み取ります。ロード前の検査には [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用してください。