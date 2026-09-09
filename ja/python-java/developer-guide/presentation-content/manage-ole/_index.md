---
title: Python を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/python-java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンク & 埋め込み
- OLE を追加
- OLE を埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
- リンクされたオブジェクト
- リンクされたファイル
- OLE を変更
- OLE アイコン
- OLE タイトル
- OLE を抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument ファイルにおける OLE オブジェクトの管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **はじめに**

{{% alert color="info" title="Note" %}}
OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。
{{% /alert %}}

MS Excelで作成したチャートを考えてみてください。そのチャートがPowerPointのスライドに配置されます。このExcelチャートはOLEオブジェクトと見なされます。

- OLEオブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトを開くまたは編集するアプリケーションの選択が求められます。
- OLEオブジェクトはチャートの内容など、実際のコンテンツを表示することもあります。この場合、PowerPoint内でチャートがアクティブになり、チャートインターフェイスがロードされ、PowerPoint上でチャートのデータを変更できます。

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ja/python-java/) を使用すると、OLEオブジェクトをスライドに OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/)）として挿入できます。

## **スライドへの OLE オブジェクト フレームの追加**

Microsoft Excelで既にチャートを作成し、Aspose.Slides for Python via Java を使用してスライドに OLE オブジェクト フレームとして埋め込みたいとします。以下の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. Excel ファイルをバイト配列として読み取ります。
1. バイト配列および OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) をスライドに追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルのチャートを Aspose.Slides for Python via Java を使用してスライドに OLE オブジェクト フレームとして追加しました。**注**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleembeddeddatainfo/) コンストラクタは、第二パラメータとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により、PowerPoint はファイルタイプを正しく解釈し、この OLE オブジェクトを開く適切なアプリケーションを選択できます。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # OLE オブジェクト用のデータを準備します。
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # スライドに OLE オブジェクト フレームを追加します。
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for Python via Java を使用すると、埋め込みデータの代わりにファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) を追加できます。

以下の Python コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) をスライドに追加する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # リンクされた Excel ファイルを使用して OLE オブジェクト フレームを追加します。
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順で簡単に検索またはアクセスできます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、1枚目のスライドに1つだけシェイプがある以前に作成した PPTX を使用しました。オブジェクトが [OleObjectFrame] であることを確認し、目的の OLE オブジェクト フレームにアクセスしました。
4. OLE オブジェクト フレームにアクセスしたら、任意の操作を実行できます。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）とそのファイルデータにアクセスしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # 埋め込まれたファイルデータを取得します。
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # 埋め込まれたファイルの拡張子を取得します。
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **リンクされた OLE オブジェクト フレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

以下の Python コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # OLE オブジェクトがリンクされているか確認します。
        if ole_frame.isObjectLink():
            # リンクされたファイルへのフルパスを出力します。
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # 存在する場合、リンクされたファイルへの相対パスを出力します。
            # 相対パスを含められるのは PPT プレゼンテーションのみです。
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE オブジェクト データの変更**

{{% alert color="info" title="Note" %}}
このセクションでは、以下のコード例で [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) を使用しています。
{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、以下の手順でオブジェクトにアクセスし、データを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. OLE オブジェクト フレーム シェイプにアクセスします。例では、1枚目のスライドに1つだけシェイプがある以前に作成した PPTX を使用しました。オブジェクトが [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) であることを確認し、目的の OLE オブジェクト フレームにアクセスしました。
4. OLE オブジェクト フレームにアクセスしたら、任意の操作を実行できます。
5. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) オブジェクトを作成し、OLE データにアクセスします。
6. 目的の [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) にアクセスし、データを変更します。
7. 更新された [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) をストリームに保存します。
8. ストリームから OLE オブジェクトのデータを変更します。

以下の例では、OLE オブジェクト フレーム（スライドに埋め込まれた Excel チャート オブジェクト）にアクセスし、ファイルデータを変更してチャート データを更新しています。

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # ワークブック データを変更します。
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE フレーム オブジェクト データを変更します。
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **スライドに他のファイルタイプを埋め込む**

Excel チャートに加えて、Aspose.Slides for Python via Java では、スライドに他の種類のファイルを埋め込むこともできます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムを選択するように求められます。

以下の Python コードは、HTML と ZIP をスライドに埋め込む方法を示しています：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **埋め込みオブジェクトのファイルタイプの設定**

プレゼンテーションを操作する際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要がある場合があります。Aspose.Slides for Python via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。

以下の Python コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # ファイルタイプを ZIP に変更します。
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトが埋め込まれると、アイコン画像で構成されたプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されます。特定の画像とテキストをプレビューの要素として使用したい場合、Aspose.Slides for Python via Java を使用してアイコン画像とタイトルを設定できます。

以下の Python コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # プレゼンテーションのリソースに画像を追加します。
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # OLE プレビュー用にタイトルと画像を設定します。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE オブジェクト フレームのサイズ変更と再配置を防止する**

リンクされた OLE オブジェクトをプレゼンテーションのスライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新し、オブジェクトのプレビューをリフレッシュするため、OLE オブジェクト フレームのサイズや位置が変更される可能性があります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) クラスの [setUpdateAutomatic](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) メソッドを `False` に設定します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **埋め込みファイルの抽出**

Aspose.Slides for Python via Java を使用すると、スライドに埋め込まれたファイルを OLE オブジェクトとして以下の手順で抽出できます。

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OleObjectFrame] シェイプにアクセスします。
3. OLE オブジェクト フレームから埋め込みファイルのデータにアクセスし、ディスクに書き込みます。

以下の Python コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**スライドを PDF/画像 にエクスポートする際に OLE コンテンツはレンダリングされますか？**

スライド上に表示されているもの、すなわちアイコンや代替画像（プレビュー）がレンダリングされます。実際の「ライブ」OLE コンテンツはレンダリング時に実行されません。必要に応じて、エクスポートされた PDF で期待どおりの外観になるよう、独自のプレビュー画像を設定してください。

**PowerPoint でユーザーが OLE オブジェクトをスライド上で移動または編集できないようにロックするにはどうすればよいですか？**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/python-java/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤って編集や移動することを効果的に防止します。

**リンクされた Excel オブジェクトをプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューをリフレッシュすることがあります。安定した外観を保つには、[Working Solution for Worksheet Resizing](/slides/ja/python-java/working-solution-for-worksheet-resizing/) の手順に従ってください。フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定します。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは旧形式の PPT に存在します。移植性を考える場合、信頼できる絶対パス/アクセス可能な URI、または埋め込みを使用することを推奨します。