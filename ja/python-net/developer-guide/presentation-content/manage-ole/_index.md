---
title: Python を使用したプレゼンテーションの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/python-net/manage-ole/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument ファイル内の OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

## **概要**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** は、データとオブジェクトを 1 つのアプリケーションで作成し、別のアプリケーションにリンクまたは埋め込むことができる Microsoft の技術です。

{{% /alert %}}

例えば、Microsoft Excel で作成し PowerPoint のスライドに配置したチャートは OLE オブジェクトです。

- OLE オブジェクトはアイコンとして表示されることがあります。アイコンをダブルクリックすると、関連付けられたアプリケーション（例: Excel）でオブジェクトが開くか、開くまたは編集するアプリを選択するように求められます。
- OLE オブジェクトは内容を表示することがあります（例: チャート）。この場合、PowerPoint は埋め込みオブジェクトをアクティブ化し、チャートインターフェイスをロードして、PowerPoint 内でチャートのデータを編集できるようにします。

Aspose.Slides for Python を使用すると、スライドに OLE オブジェクトを OLE オブジェクト フレームとして挿入できます ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **スライドへの OLE オブジェクトの追加**

Microsoft Excel で作成したチャートを Aspose.Slides for Python を使って OLE オブジェクト フレームとしてスライドに埋め込みたい場合は、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. Excel ファイルをバイト配列として読み取ります。
4. バイト配列と他の OLE オブジェクトの詳細を指定して、スライドに [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加します。
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルからのチャートが [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) としてスライドに埋め込まれます。

**注:** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは、埋め込むオブジェクトのファイル拡張子を第2パラメータとして受け取ります。PowerPoint はこの拡張子を使用してファイルタイプを特定し、OLE オブジェクトを開く適切なアプリケーションを選択します。
```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # OLE オブジェクトのデータを準備します。
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # スライドに OLE オブジェクト フレームを追加します。
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **リンクされた OLE オブジェクトの追加**

Aspose.Slides for Python を使用すると、データを埋め込む代わりにファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加できます。

以下の Python の例は、スライド上で Excel ファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加する方法を示しています。
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **OLE オブジェクトへのアクセス**

スライドに OLE オブジェクトがすでに埋め込まれている場合、次の手順でアクセスできます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、Presentation クラスのインスタンスを作成してロードします。
2. インデックスでスライドへの参照を取得します。
3. OleObjectFrame シェイプにアクセスします。
4. OLE オブジェクト フレームを取得したら、必要な操作を実行します。

以下の例では、埋め込まれた Excel チャートの OLE オブジェクト フレームにアクセスし、ファイルデータを取得します。この例では、最初のスライドに単一のシェイプがある PPTX を使用します。
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 埋め込みファイルデータを取得します。
        file_data = ole_frame.embedded_data.embedded_file_data

        # 埋め込みファイルの拡張子を取得します。
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```


### **リンクされた OLE オブジェクト プロパティへのアクセス**

Aspose.Slides は、リンクされた OLE オブジェクト フレームのプロパティにアクセスする機能を提供します。

以下の Python の例は、OLE オブジェクトがリンクされているかどうかを確認し、リンクされている場合はリンク先ファイルへのパスを取得します。
```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # OLE オブジェクトがリンクされているか確認します。
        if ole_frame.is_object_link:
            # リンクされたファイルへのフルパスを出力します。
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # リンクされたファイルへの相対パスが存在する場合に出力します。
            # .ppt プレゼンテーションのみが相対パスを含めることができます。
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```


## **OLE オブジェクト データの変更**

{{% alert color="primary" %}}

このセクションでは、以下のコード例は [Aspose.Cells for Python via .NET](/cells/python-net/) を使用します。

{{% /alert %}}

スライドに OLE オブジェクトがすでに埋め込まれている場合、次の手順でアクセスしデータを変更できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成してプレゼンテーションをロードします。
2. インデックスで対象スライドを取得します。
3. [OleObjectFrame] シェイプにアクセスします。
4. OLE オブジェクト フレームを取得したら、必要な操作を実行します。
5. `Workbook` オブジェクトを作成し、OLE データを読み取ります。
6. 目的の `Worksheet` を開き、データを編集します。
7. 更新した `Workbook` をストリームに保存します。
8. そのストリームを使用して OLE オブジェクトのデータを置き換えます。

以下の例では、埋め込み Excel チャートの OLE オブジェクト フレームにアクセスし、ファイルデータを変更してチャートを更新します。サンプルは、最初のスライドに単一のシェイプがある事前作成済みの PPTX を使用します。
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
            # OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # ワークブック データを変更します。
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE フレーム オブジェクト データを変更します。
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドへのファイル埋め込み**

Excel チャートに加えて、Aspose.Slides for Python はスライドに他のファイルタイプも埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連付けられたアプリケーションで自動的に開くか、適切なプログラムを選択するように求められます。

この Python のコードは、HTML と ZIP ファイルをスライドに埋め込む方法を示しています。
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

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換える、またはサポートされていない OLE オブジェクトをサポートされているものに入れ替える必要がある場合があります。Aspose.Slides for Python は埋め込みオブジェクトのファイルタイプを設定できるため、OLE フレームのデータやファイル拡張子を更新できます。

この Python のコードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # ファイルタイプを ZIP に変更します。
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコンベースのプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Python を使用してアイコン画像とタイトルを設定できます。

この Python のコードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # プレゼンテーションリソースに画像を追加します。
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE プレビュー用にタイトルと画像を設定します。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **OLE オブジェクト フレームのサイズ変更と位置変更を防止する**

リンクされた OLE オブジェクトをスライドに追加した後、PowerPoint はプレゼンテーションを開くときにリンクの更新を促すことがあります。リンクの更新を選択すると、PowerPoint がリンク先オブジェクトのデータでプレビューを更新するため、OLE オブジェクト フレームのサイズと位置が変わることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) クラスの `update_automatic` プロパティを `False` に設定します。
```py
ole_frame.update_automatic = False
```


## **埋め込みファイルの抽出**

Aspose.Slides for Python は、スライドに埋め込まれたファイルを OLE オブジェクトとして次の手順で抽出できます。

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプを列挙し、OLEObjectFrame シェイプを見つけます。
3. 各 [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) から埋め込みファイルデータを取得し、ディスクに書き込みます。

以下の Python コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。
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

**スライドを PDF/画像 にエクスポートするときに OLE コンテンツはレンダリングされますか？**

スライド上で表示されているもの（アイコン/代替画像（プレビュー））がレンダリングされます。実際の OLE コンテンツはレンダリング時に実行されません。必要に応じて独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りの外観になるようにしてください。

**スライド上の OLE オブジェクトをロックし、PowerPoint でユーザーが移動/編集できないようにするにはどうすればよいですか？**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/python-net/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を実質的に防止します。

**リンクされた Excel オブジェクトがプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した表示にするには、[Working Solution for Worksheet Resizing](/slides/ja/python-net/working-solution-for-worksheet-resizing/) の手順に従ってください。フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定します。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は利用できず、フルパスしか保存されません。相対パスは古い PPT 形式でのみ見られます。移植性を考える場合は、信頼できる絶対パスやアクセス可能な URI、または埋め込みを使用してください。