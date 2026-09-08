---
title: "Python を使用したプレゼンテーションの OLE 管理"
linktitle: "OLE の管理"
type: docs
weight: 40
url: /ja/python-java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクトのリンクと埋め込み
- OLE の追加
- OLE の埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの追加
- ファイルの埋め込み
- リンクされたオブジェクト
- リンクされたファイル
- OLE の変更
- OLE アイコン
- OLE タイトル
- OLE の抽出
- オブジェクトの抽出
- ファイルの抽出
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **イントロダクション**

{{% alert color="info" title="Note" %}}
OLE（Object Linking & Embedding）は、Microsoft の技術で、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できるようにします。
{{% /alert %}}

MS Excel で作成されたチャートを考えてみましょう。そのチャートが PowerPoint のスライドに配置されます。その Excel のチャートは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開封または編集用のアプリケーションを選択するよう求められます。
- OLE オブジェクトは、チャートの内容など実際のコンテンツを表示することもあります。この場合、PowerPoint 内でチャートがアクティブになり、チャートインターフェイスが読み込まれ、PowerPoint 内でチャートのデータを変更できます。

Aspose.Slides for Python via Java は、スライドに OLE オブジェクトを OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/)）として挿入できるようにします。

## **スライドに OLE オブジェクトフレームを追加する**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for Python via Java を使用して OLE オブジェクトフレームとしてスライドに埋め込みたいとします。その方法は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. Excel ファイルをバイト配列として読み取ります。
1. [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) をバイト配列および OLE オブジェクトに関するその他の情報を含む形でスライドに追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Python via Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。**注意**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleembeddeddatainfo/) コンストラクタは、第二パラメータとして埋め込むオブジェクトの拡張子を受け取ります。この拡張子により、PowerPoint はファイルタイプを正しく解釈し、この OLE オブジェクトを開く適切なアプリケーションを選択できます。

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

### **リンクされた OLE オブジェクトフレームの追加**

Aspose.Slides for Python via Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) を追加できます。

以下の Python コードは、リンクされた Excel ファイルを使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) を追加する方法を示しています：

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

## **OLE オブジェクトフレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に見つけたりアクセスしたりできます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある先に作成した PPTX を使用しました。その後、オブジェクトが [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) であることを確認しました。これがアクセス対象の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。

以下の例では、OLE オブジェクトフレーム（スライドに埋め込まれた Excel チャートオブジェクト）とそのファイルデータにアクセスしています。

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

        # （省略）
finally:
    presentation.dispose()
```

### **リンクされた OLE オブジェクトフレームのプロパティにアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

以下の Python コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされたファイルのパスを取得する方法を示しています：

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
            # 相対パスを含められるのは PPT プレゼンテーションだけです。
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

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でそのオブジェクトに簡単にアクセスし、データを変更できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. OLE オブジェクトフレームシェイプにアクセスします。例では、最初のスライドに 1 つのシェイプがある先に作成した PPTX を使用しました。その後、オブジェクトが [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) であることを確認しました。これがアクセス対象の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。
5. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) オブジェクトを作成し、OLE データにアクセスします。
6. 目的の [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) にアクセスし、データを修正します。
7. 更新された [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) をストリームに保存します。
8. ストリームから OLE オブジェクトデータを変更します。

以下の例では、OLE オブジェクトフレーム（スライドに埋め込まれた Excel チャートオブジェクト）にアクセスし、ファイルデータを変更してチャートデータを更新しています。

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

        # OLE オブジェクトデータを Workbook オブジェクトとして読み取ります。
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # ワークブックデータを変更します。
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE フレームオブジェクトのデータを変更します。
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **スライドに他のファイルタイプを埋め込む**

Excel チャートに加えて、Aspose.Slides for Python via Java を使用すると、スライドに他のタイプのファイルを埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、自動的に関連プログラムで開くか、適切なプログラムを選択するよう促されます。

以下の Python コードは、HTML および ZIP をスライドに埋め込む方法を示しています：

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

## **埋め込みオブジェクトのファイルタイプを設定する**

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換える必要がある場合があります。Aspose.Slides for Python via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。

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

## **埋め込みオブジェクトのアイコン画像とタイトルを設定する**

OLE オブジェクトを埋め込むと、自動的にアイコン画像からなるプレビューが追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューの要素として使用したい場合、Aspose.Slides for Python via Java を使用してアイコン画像とタイトルを設定できます。

以下の Python コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # プレゼンテーションリソースに画像を追加します。
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

## **OLE オブジェクトフレームがサイズ変更や位置変更されるのを防止する**

リンクされた OLE オブジェクトをプレゼンテーションスライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。 「Update Links」 ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新し、オブジェクトのプレビューを再描画するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促すのを防ぐには、[OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) クラスの [setUpdateAutomatic](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) メソッドを `False` に設定します：

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

## **埋め込まれたファイルの抽出**

Aspose.Slides for Python via Java を使用すると、スライドに埋め込まれたファイルを OLE オブジェクトとして次の手順で抽出できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、抽出対象の OLE オブジェクトを含めます。
2. プレゼンテーション内のすべてのシェイプをループし、[OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。
3. OleObjectFrame から埋め込まれたファイルのデータにアクセスし、ディスクに書き出します。

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

**スライドを PDF/画像にエクスポートするときに OLE コンテンツはレンダリングされますか？**

スライド上に表示されているもの、すなわちアイコン/代替画像（プレビュー）がレンダリングされます。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りの外観になるようにしてください。

**PowerPoint でユーザーが OLE オブジェクトを移動または編集できないようにロックするにはどうすればよいですか？**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/python-java/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤って編集や移動されるのを実質的に防止します。

**リンクされた Excel オブジェクトがプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint がリンクされた OLE のプレビューを再描画することがあります。安定した外観を保つには、[Working Solution for Worksheet Resizing](/slides/ja/python-java/working-solution-for-worksheet-resizing/) の手順に従ってください。フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定します。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは古い PPT 形式で使用されます。移植性を考えるなら、確実な絶対パスやアクセス可能な URI、あるいは埋め込みを使用することを推奨します。