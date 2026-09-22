---
title: Python（Java 経由）で元のプレゼンテーション形式を判定する
linktitle: ソース形式
type: docs
weight: 35
url: /ja/python-java/detect-presentation-source-format/
keywords:
- ソース形式
- プレゼンテーション形式の検出
- PowerPoint
- OpenDocument
- プレゼンテーション
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、Python（Java 経由）でロードされたプレゼンテーションの元の形式を読み取り、検出 API を比較し、ファイル、ストリーム、レガシーフォーマットを処理します。"
---
## **概要**

プレゼンテーションを読み込んだ後、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSourceFormat) メソッドを呼び出して元の形式を判定します。現在のインスタンスがロードされた形式に依存する後続の処理がある場合に使用します。

ソース形式は、出力ファイルに選択する [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) とは別物です。別の形式で保存しても、既存インスタンスのソース形式は変わりません。

この例は Aspose.Slides for Python via Java と、互換性のある Java ランタイムが必要です。各例は、JVM が起動していない場合に起動します。

## **ファイルのソース形式を読み取る**

この例は既存の `sample.pptx` ファイルが必要です。ファイル名ではなく [Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSourceFormat) を使用してアプリケーションの処理ポリシーを選択します。入力パスを変更すれば他の形式も試せます。例は選択されたポリシーを出力します。メッセージはアプリケーション固有のロジックに置き換えてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **サポートされている値を確認する**

[SourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sourceformat/) クラスは、以下のプレゼンテーション形式を区別する整数定数を定義しています。下記の拡張子は慣例的なもので、元のファイル名そのものを再構築したものではありません。

| SourceFormat の値 | 拡張子 | 形式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 プレゼンテーション |
| `Pptx` | `.pptx` | Office Open XML プレゼンテーション |
| `Pptm` | `.pptm` | マクロ有効 Office Open XML プレゼンテーション |
| `Pps` | `.pps` | PowerPoint 97–2003 スライドショー |
| `Ppsx` | `.ppsx` | Office Open XML スライドショー |
| `Ppsm` | `.ppsm` | マクロ有効 Office Open XML スライドショー |
| `Pot` | `.pot` | PowerPoint 97–2003 テンプレート |
| `Potx` | `.potx` | Office Open XML テンプレート |
| `Potm` | `.potm` | マクロ有効 Office Open XML テンプレート |
| `Odp` | `.odp` | OpenDocument プレゼンテーション |
| `Otp` | `.otp` | OpenDocument プレゼンテーションテンプレート |
| `Fodp` | `.fodp` | Flat XML ODF プレゼンテーション |
| `Xml` | `.xml` | PowerPoint XML プレゼンテーション |

## **ストリームのソース形式を読み取る**

この例は既存の `sample.pps` ファイルが必要です。バイト列をメモリストリームに読み込むことで、データベースの値やアップロードされたバイト配列など、ファイル名なしで入力が受け取られるシナリオをシミュレートします。[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクタはストリームのみを受け取ります。Python がファイルバイトを読み取り、JPype がそれらを Java のバイト配列に変換して Java メモリストリームに渡します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT、PPS、POT は同一のバイナリ形式を共有します。ファイルパスで読み込む場合、拡張子でスライドショーやテンプレートを区別できることがあります。ファイル名がない場合、レガシーな PPS や POT の内容は `SourceFormat.Ppt` と報告されることがあります。上記の PPS の例は `SourceFormat.Ppt` の整数値を出力します。

アプリケーション側でこの区別を保持する必要がある場合は、元のファイル名またはサブタイプメタデータを別途保持してください。拡張子はレガシーサブタイプへの有用なヒントとなりますが、任意のプレゼンテーションコンテンツを識別する唯一の根拠にすべきではありません。

## **ロード前後の検出を比較する**

ファイル全体のプレゼンテーションオブジェクトモデルをロードせずに事前に検査したい場合は [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) と [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#getLoadFormat) を使用します。インスタンスが既に存在する場合は [Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSourceFormat) を使用してください。

この例は `sample.pptx` が必要で、`LoadFormat.Pptx` と `SourceFormat.Pptx` の整数値をそれぞれ出力します。本番環境では処理段階に応じた API を選択してください。すでにロード済みのプレゼンテーションに対してソース形式を取得するためだけに再度検査する必要はありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

結果で使用されている定数は別クラスから取得しています: [LoadFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadformat/) と [SourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sourceformat/)。数値を直接比較したり、すべての形式で同一の検出結果が得られると想定しないでください。PowerPoint XML はロード前は `LoadFormat.Unknown` と報告され、ロード後は `SourceFormat.Xml` と報告されることがあります。

## **ソース形式と出力形式を分離して管理する**

この例は `sample.pptx` を入力に取り、`converted.odp` に書き出します。元インスタンスを保存前後に `SourceFormat.Pptx` の整数値を出力します。ODP に変換して新たにロードしたインスタンスだけが `Odp` を報告します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

`Presentation()` でゼロから作成したプレゼンテーションは `SourceFormat.Pptx` を報告します。入力ファイルがないため、これは新規作成インスタンスのデフォルト値であり、PPTX ファイルがロードされたことを示すものではありません。作成かロードかの区別が重要な場合は、アプリケーション側で別途追跡してください。

## **ソース形式を拡張子にマッピングする**

この例は `sample.pptx` が必要です。現在サポートされているすべての [SourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sourceformat/) の値を、入力ファイル名を解析せずに慣例的な拡張子へマッピングします。認識できない値に対しては、拡張子を黙って割り当てることを防ぐためにフォールバック処理を行います。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

このマッピングはファイルを変換したり、ストリームロード時に失われたレガシー PPS/POT サブタイプを復元したりするものではありません。実際に保存する場合は、[SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) を明示的に指定するか、[Save Presentations in Their Original Format](/slides/ja/python-java/save-presentation/#save-presentations-in-their-original-format) に示された変換手順を使用してください。

## **保存と再オープンで形式を検証する**

この自己完結型例はプレゼンテーションを作成し、作業ディレクトリに 3 つのファイルを書き出します。同名ファイルがある場合は上書きされます。各出力ファイルをパスからとメモリストリームからの 2 通りで再度開きます。PPTX と ODP では両方のルートで保存形式が報告されますが、PPS の場合はパスからのロードは `Pps`、ファイル名なしのバイトストリームからのロードは `Ppt` と報告されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

以下の表は、拡張子が一致するプレゼンテーションに対するソース形式の識別結果をまとめたものです。名前は定数を示し、Python の例ではそれらの整数値を出力しています。

| 保存形式 | ファイルパスからの SourceFormat | ファイル名なしストリームからの SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm`（それぞれ） | ファイルパスと同じ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm`（それぞれ） | ファイルパスと同じ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm`（それぞれ） | ファイルパスと同じ |
| ODP, OTP | `Odp`, `Otp`（それぞれ） | ファイルパスと同じ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT コンテンツは、ファイル名なしストリームの場合は `Ppt` と識別されます。この表は形式の識別結果を示すものであり、変換時にすべてのプレゼンテーション機能が保持されることを保証するものではありません。

## **FAQ**

**ODP に保存すると、PPTX からロードしたプレゼンテーションのソース形式は変わりますか？**

いいえ。既存のインスタンスは依然として `Pptx` を報告します。保存された ODP ファイルからロードしたインスタンスは `Odp` を報告します。

**ストリームだけでレガシーなプレゼンテーション、スライドショー、テンプレートを区別できますか？**

できません。PPT、PPS、POT は同一のバイナリ形式を共有しています。区別が必要な場合は、ファイル名またはサブタイプメタデータを別途保持してください。

**プレゼンテーションがすでにロード済みの場合、どの API を使用すべきですか？**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSourceFormat) を使用してください。ロード前の検査が必要な場合は [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用します。