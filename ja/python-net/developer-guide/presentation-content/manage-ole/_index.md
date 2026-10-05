---
title: Python を使用したプレゼンテーションでの OLE 管理
linktitle: OLE を管理
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument ファイル内の OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **導入**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** は、あるアプリケーションで作成されたデータやオブジェクトを別のアプリケーションにリンクまたは埋め込むことができる Microsoft の技術です。

{{% /alert %}}

たとえば、Microsoft Excel で作成したグラフを PowerPoint のスライドに配置した場合、それは OLE オブジェクトになります。

- OLE オブジェクトはアイコンとして表示されることがあります。アイコンをダブルクリックすると、関連付けられたアプリケーション（例: Excel）でオブジェクトが開くか、開くまたは編集するアプリの選択を求められます。
- OLE オブジェクトが内容を表示している場合（例: グラフ）。この場合、PowerPoint は埋め込まれたオブジェクトをアクティブ化し、グラフのインターフェイスを読み込み、PowerPoint 内でグラフのデータを編集できるようにします。

Aspose.Slides for Python を使用すると、スライドに OLE オブジェクトを OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)）として挿入できます。

## **スライドへの OLE オブジェクトの追加**

Microsoft Excel で作成したグラフを Aspose.Slides for Python で OLE オブジェクト フレームとして埋め込みたい場合は、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. Excel ファイルをバイト配列として読み取ります。  
1. バイト配列とその他の OLE オブジェクト情報を指定して、スライドに [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルからのグラフを [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) としてスライドに埋め込んでいます。

**注意:** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) コンストラクタは、埋め込むオブジェクトのファイル拡張子を第2パラメータとして受け取ります。PowerPoint はこの拡張子を使用してファイルタイプを識別し、適切なアプリケーションで OLE オブジェクトを開きます。

```py
import aspose.slides as slides

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

以下の Python サンプルは、スライド上で Excel ファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクトへのアクセス**

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順でアクセスできます。

1. Presentation クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションを読み込みます。  
1. インデックスでスライドへの参照を取得します。  
1. OleObjectFrame シェイプにアクセスします。  
1. OLE オブジェクト フレームを取得したら、必要な操作を実行します。

以下の例では、埋め込まれた Excel グラフの OLE オブジェクト フレームにアクセスし、そのファイルデータを取得しています。この例では、最初のスライドに 1 つのシェイプだけがある PPTX を使用しています。

```py
import aspose.slides as slides

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

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

以下の Python サンプルは、OLE オブジェクトがリンクされているかどうかを確認し、リンクされている場合はリンク先ファイルのパスを取得します。

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # OLE オブジェクトがリンクされているか確認します。
        if ole_frame.is_object_link:
            # リンクされたファイルへのフルパスを表示します。
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # 存在する場合、リンクされたファイルへの相対パスを表示します。
            # .ppt プレゼンテーションのみが相対パスを含むことができます。
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE オブジェクト データの変更**

{{% alert color="info" title="Note" %}}

このセクションのコード例は、[Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/) を使用しています。

{{% /alert %}}

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順でデータにアクセスして変更できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成してプレゼンテーションを読み込みます。  
1. インデックスで対象スライドを取得します。  
1. [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) シェイプにアクセスします。  
1. OLE オブジェクト フレームを取得したら、必要な操作を実行します。  
1. `Workbook` オブジェクトを作成し、OLE データを読み取ります。  
1. 対象の `Worksheet` を開いてデータを編集します。  
1. 更新した `Workbook` をストリームに保存します。  
1. そのストリームを使用して OLE オブジェクト のデータを置き換えます。

以下の例では、埋め込まれた Excel グラフの OLE オブジェクト フレームにアクセスし、ファイルデータを変更してグラフを更新しています。サンプルは、最初のスライドに 1 つのシェイプだけがある既存の PPTX を使用しています。

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
            # Workbook データを変更します。
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE フレーム オブジェクトのデータを変更します。
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドへのファイル埋め込み**

Excel グラフに加えて、Aspose.Slides for Python はスライドに他のファイルタイプも埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、自動的に関連付けられたアプリケーションで開くか、適切なプログラムの選択を求められます。

以下の Python コードは、HTML と ZIP ファイルをスライドに埋め込む方法を示しています。

```py
import aspose.slides as slides

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

プレゼンテーションを操作する際、古い OLE オブジェクトを新しいものに差し替えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換えたりする必要があることがあります。Aspose.Slides for Python を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレーム データまたはファイル拡張子を更新できます。

以下の Python コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

```py
import aspose.slides as slides

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

OLE オブジェクトを埋め込むと、アイコンベースのプレビューが自動的に追加されます。これはユーザーが OLE オブジェクトにアクセスまたは開く前に目にするプレビューです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Python でアイコン画像とタイトルを設定できます。

以下の Python コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # プレゼンテーションのリソースに画像を追加します。
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE プレビュー用にタイトルと画像を設定します。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクト フレームのサイズ変更と再配置の防止**

リンクされた OLE オブジェクトをスライドに追加すると、プレゼンテーションを開いたときに PowerPoint がリンクの更新を求めることがあります。**Update Links** を選択すると、PowerPoint がリンクオブジェクトから取得したデータでプレビューを更新するため、OLE オブジェクト フレームのサイズと位置が変わることがあります。オブジェクトのデータ更新を求められないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) クラスの `update_automatic` プロパティを `False` に設定します。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **埋め込みファイルの抽出**

Aspose.Slides for Python を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. プレゼンテーション内のすべてのシェイプを走査し、OleObjectFrame シェイプを特定します。  
1. 各 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) から埋め込みファイルデータを取得し、ディスクに書き出します。

以下の Python コードは、スライド上の OLE オブジェクトとして埋め込まれたファイルを抽出する方法を示しています。

```py
import aspose.slides as slides

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

**スライドを PDF/画像にエクスポートしたときに OLE コンテンツはレンダリングされますか？**

スライドに表示されているものがレンダリングされます――つまりアイコン／代替画像（プレビュー）です。**ライブ** の OLE コンテンツはレンダリング時に実行されません。必要に応じて独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りに見えるようにしてください。

埋め込みファイルを PDF 添付ファイルとして保持したい場合は、[PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) を `True` に設定します。このオプションはデフォルトで無効です。例と添付ファイルの確認手順については、[Preserve Embedded OLE Files as PDF Attachments](/slides/ja/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) を参照してください。

**スライド上の OLE オブジェクトをロックして、ユーザーが PowerPoint で移動・編集できないようにするには？**

シェイプをロックします：Aspose.Slides は [shape-level locks](/slides/ja/python-net/applying-protection-to-presentation/) を提供します。これは暗号化ではありませんが、誤操作や移動を効果的に防止します。

**リンクされた Excel オブジェクトが「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した表示を保つには、[Working Solution for Worksheet Resizing](/slides/ja/python-net/working-solution-for-worksheet-resizing/) のガイドラインに従い、フレームを範囲に合わせるか、範囲を固定フレームにスケーリングして適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されません――フルパスのみです。相対パスは旧形式の PPT に存在します。可搬性を確保するには、信頼できる絶対パス／アクセス可能な URI、または埋め込みを使用することを推奨します。