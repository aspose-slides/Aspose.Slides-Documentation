---
title: Python を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/python-net/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクトのリンクと埋め込み
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

## **概要**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** は、あるアプリケーションで作成されたデータやオブジェクトを別のアプリケーションにリンクまたは埋め込むことができる Microsoft の技術です。

{{% /alert %}}

たとえば、Microsoft Excel で作成されたチャートを PowerPoint のスライドに配置した場合、それは OLE オブジェクトです。

- OLE オブジェクトはアイコンとして表示されることがあります。アイコンをダブルクリックすると、関連付けられたアプリケーション（例：Excel）でオブジェクトが開くか、開くまたは編集するアプリを選択するよう求められます。
- OLE オブジェクトは内容（例：チャート）を直接表示することがあります。この場合、PowerPoint は埋め込まれたオブジェクトをアクティブにし、チャートのインターフェイスをロードして、PowerPoint 内でチャートのデータを編集できるようにします。

Aspose.Slides for Python では、スライドに OLE オブジェクトを OLE オブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)）として挿入できます。

## **スライドへの OLE オブジェクトの追加**

既に Microsoft Excel でチャートを作成しており、Aspose.Slides for Python を使用して OLE オブジェクトフレームとしてスライドに埋め込みたい場合は、次の手順に従ってください。

1. **[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。**
1. **インデックスでスライドへの参照を取得します。**
1. **Excel ファイルをバイト配列として読み取ります。**
1. **スライドに [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加し、バイト配列やその他の OLE オブジェクトの詳細情報を提供します。**
1. **変更したプレゼンテーションを PPTX ファイルとして保存します。**

以下の例では、Excel ファイルからのチャートが [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) としてスライドに埋め込まれます。

**注意:** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクターは、埋め込み可能オブジェクトのファイル拡張子を第2パラメーターとして受け取ります。PowerPoint はこの拡張子を使用してファイルタイプを識別し、OLE オブジェクトを開く適切なアプリケーションを選択します。

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare the data for the OLE object.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Add an OLE object frame to the slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **リンクされた OLE オブジェクトの追加**

Aspose.Slides for Python では、データを埋め込む代わりにファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加できます。

以下の Python 例は、スライド上に Excel ファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加する方法を示しています。

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクトへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でアクセスできます。

1. **OLE オブジェクトが埋め込まれているプレゼンテーションを、Presentation クラスのインスタンスを作成してロードします。**
1. **インデックスでスライドへの参照を取得します。**
1. **OleObjectFrame シェイプにアクセスします。**
1. **OLE オブジェクトフレームを取得したら、必要な操作を実行します。**

以下の例は、OLE オブジェクトフレーム（埋め込まれた Excel チャート）にアクセスし、そのファイルデータを取得します。この例では、1 番目のスライドに 1 つのシェイプがある PPTX を使用しています。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Get the embedded file data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Get the extension of the embedded file.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **リンクされた OLE オブジェクトのプロパティへのアクセス**

Aspose.Slides では、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

以下の Python 例は、OLE オブジェクトがリンクされているかどうかを確認し、リンクされている場合はそのファイルへのパスを取得します。

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Check whether the OLE object is linked.
        if ole_frame.is_object_link:
            # Print the full path to the linked file.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print the relative path to the linked file, if present.
            # Only .ppt presentations can contain a relative path.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE オブジェクト データの変更**

{{% alert color="primary" %}}

このセクションでは、以下のコード例で [Aspose.Cells for Python via .NET](/cells/python-net/) を使用しています。

{{% /alert %}}

OLE オブジェクトが既に埋め込まれている場合、次の手順でデータを取得し、変更できます。

1. **Presentation クラスのインスタンスを作成してプレゼンテーションをロードします。**
1. **対象スライドをインデックスで取得します。**
1. **OleObjectFrame シェイプにアクセスします。**
1. **OLE オブジェクトフレームを取得したら、必要な操作を実行します。**
1. **`Workbook` オブジェクトを作成し、OLE データを読み取ります。**
1. **目的の `Worksheet` を開き、データを編集します。**
1. **更新した `Workbook` をストリームに保存します。**
1. **そのストリームを使用して OLE オブジェクトのデータを置き換えます。**

以下の例では、OLE オブジェクトフレーム（埋め込まれた Excel チャート）にアクセスし、ファイルデータを変更してチャートを更新します。サンプルは、1 番目のスライドに 1 つのシェイプがある PPTX を使用しています。

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Read the OLE object data as a Workbook object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modify the workbook data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Change the OLE frame object data.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドへのファイル埋め込み**

Excel チャートに加えて、Aspose.Slides for Python ではスライドに他のファイルタイプも埋め込めます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連付けられたアプリケーションで自動的に開くか、適切なプログラムを選択するよう促されます。

以下の Python コードは、スライドに HTML と ZIP ファイルを埋め込む方法を示しています。

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーション作業中に、古い OLE オブジェクトを新しいものに置き換えたり、サポート外の OLE オブジェクトをサポート対象に置き換える必要がある場合があります。Aspose.Slides for Python では、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータやファイル拡張子を更新できます。

以下の Python コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Change the file type to ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコンベースのプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に目にするものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Python でアイコン画像とタイトルを設定できます。

以下の Python コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Add an image to the presentation resources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Set a title and the image for the OLE preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクトフレームのサイズ変更と再配置を防止する**

リンクされた OLE オブジェクトをスライドに追加すると、プレゼンテーションを開いたときに PowerPoint がリンクの更新を促すことがあります。**Update Links** を選択すると、PowerPoint がリンクされたオブジェクトのデータでプレビューを再描画するため、OLE オブジェクトフレームのサイズや位置が変わることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) クラスの `update_automatic` プロパティを `False` に設定します。

```py
ole_frame.update_automatic = False
```

## **埋め込みファイルの抽出**

Aspose.Slides for Python では、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. **抽出したい OLE オブジェクトが含まれる [Presentation] クラスのインスタンスを作成します。**
2. **プレゼンテーション内のすべてのシェイプを走査し、OLEObjectFrame シェイプを見つけます。**
3. **各 [OLEObjectFrame] から埋め込みファイルデータを取得し、ディスクに書き込みます。**

以下の Python コードは、スライドに埋め込まれた OLE オブジェクトとしてのファイルを抽出する方法を示しています。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**スライドを PDF/画像 にエクスポートするとき、OLE コンテンツはレンダリングされますか？**

スライド上に表示されているものがレンダリングされます—アイコン/代替画像（プレビュー）です。ライブの OLE コンテンツはレンダリング時に実行されません。必要に応じて独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りの見た目になるようにしてください。

**PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにスライド上でロックするにはどうすればよいですか？**

シェイプをロックします。Aspose.Slides は [シェイプレベルのロック](/slides/ja/python-net/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作や意図しない移動・編集を効果的に防止します。

**リンクされた Excel オブジェクトが「ジャンプ」したり、サイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した表示を保つには、[ワークシートリサイズの実装例](/slides/ja/python-net/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームに合わせてスケーリングし、適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は利用できず、フルパスのみが保存されます。相対パスは旧形式の PPT にのみ存在します。可搬性を確保するには、信頼できる絶対パス/アクセス可能な URI を使用するか、埋め込みを検討してください。