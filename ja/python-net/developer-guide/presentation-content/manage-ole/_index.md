---
title: Python を使用したプレゼンテーションでの OLE の管理
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

## **概要**

{{% alert title="情報" color="info" %}}

**OLE (Object Linking & Embedding)** は、あるアプリケーションで作成されたデータやオブジェクトを別のアプリケーションにリンクまたは埋め込むことができる Microsoft の技術です。

{{% /alert %}}

たとえば、Microsoft Excel で作成されたグラフを PowerPoint のスライドに配置した場合、それは OLE オブジェクトになります。

- OLE オブジェクトはアイコンとして表示されることがあります。アイコンをダブルクリックすると、関連付けられたアプリケーション（例: Excel）でオブジェクトが開かれるか、開く／編集するアプリの選択が求められます。
- OLE オブジェクトが内容を表示している場合（例: グラフ）、PowerPoint は埋め込まれたオブジェクトを有効化し、チャート インターフェイスを読み込んで PowerPoint 内でデータの編集を可能にします。

Aspose.Slides for Python を使用すると、スライドに OLE オブジェクト フレーム（[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)）として OLE オブジェクトを挿入できます。

## **スライドへの OLE オブジェクトの追加**

Microsoft Excel で作成したグラフを Aspose.Slides for Python を使って OLE オブジェクト フレームとしてスライドに埋め込みたい場合、次の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列とその他の OLE オブジェクト情報を指定して、スライドに [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、Excel ファイルから取得したチャートを [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) としてスライドに埋め込みます。

**注：** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) のコンストラクタは、埋め込むオブジェクトのファイル拡張子を第2引数に受け取ります。PowerPoint はこの拡張子を使用してファイル種別を判別し、適切なアプリケーションで OLE オブジェクトを開きます。

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

Aspose.Slides for Python では、データを埋め込むのではなくファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加できます。

次の Python の例は、スライドに Excel ファイルへのリンクを持つ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加する方法を示しています。

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクトへのアクセス**

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順でアクセスできます。

1. Presentation クラスのインスタンスを作成して、埋め込まれた OLE オブジェクトを含むプレゼンテーションをロードします。  
2. インデックスでスライドへの参照を取得します。  
3. OleObjectFrame シェイプにアクセスします。  
4. OLE オブジェクト フレームが取得できたら、必要な操作を実行します。

以下の例は、埋め込まれた Excel チャートの OLE オブジェクト フレームにアクセスし、ファイル データを取得する方法を示します。この例では、最初のスライドに 1 つだけシェイプがある PPTX を使用します。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 埋め込まれたファイル データを取得します。
        file_data = ole_frame.embedded_data.embedded_file_data

        # 埋め込まれたファイルの拡張子を取得します。
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **リンクされた OLE オブジェクト プロパティへのアクセス**

Aspose.Slides を使用すると、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

以下の Python の例は、OLE オブジェクトがリンクされているかどうかを確認し、リンクされている場合はリンク先ファイルへのパスを取得します。

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # OLE オブジェクトがリンクされているか確認します。
        if ole_frame.is_object_link:
            # リンクされたファイルへのフル パスを出力します。
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # 存在する場合は相対パスも出力します。
            # .ppt プレゼンテーションのみが相対パスを保持できます。
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE オブジェクト データの変更**

{{% alert color="primary" %}}

このセクションでは、以下のコード例で [Aspose.Cells for Python via .NET](/cells/python-net/) を使用しています。

{{% /alert %}}

スライドに既に埋め込まれた OLE オブジェクトがある場合、次の手順でデータを取得し、変更できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成してプレゼンテーションをロードします。  
2. インデックスで対象スライドを取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) シェイプにアクセスします。  
4. OLE オブジェクト フレームが取得できたら、必要な操作を実行します。  
5. `Workbook` オブジェクトを作成し、OLE データを読み取ります。  
6. 対象 `Worksheet` を開き、データを編集します。  
7. 更新した `Workbook` をストリームに保存します。  
8. そのストリームを使用して OLE オブジェクトのデータを置き換えます。

以下の例では、埋め込まれた Excel チャート（OLE オブジェクト フレーム）にアクセスし、ファイル データを変更してチャートを更新します。サンプルは、最初のスライドに 1 つだけシェイプがある PPTX を使用します。

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

Excel チャートに加えて、Aspose.Slides for Python はスライドに他のファイル形式も埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連付けられたアプリケーションで自動的に開くか、適切なプログラムの選択が求められます。

以下の Python コードは、スライドに HTML および ZIP ファイルを埋め込む方法を示します。

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

## **埋め込みオブジェクトのファイル種別設定**

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに差し替えたり、未サポートの OLE オブジェクトをサポートされているものに置き換えたりする必要があることがあります。Aspose.Slides for Python では、埋め込みオブジェクトのファイル種別を設定できるため、OLE フレーム データまたはファイル拡張子を更新できます。

以下の Python コードは、埋め込み OLE オブジェクトのファイル種別を `zip` に設定する方法を示します。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # ファイル種別を ZIP に変更します。
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **埋め込みオブジェクトのアイコン画像とタイトル設定**

OLE オブジェクトを埋め込むと、アイコンベースのプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に目にするものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Python でアイコン画像とタイトルを設定できます。

以下の Python コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示します。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # プレゼンテーションのリソースに画像を追加します。
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE プレビュー用のタイトルと画像を設定します。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE オブジェクト フレームのサイズ・位置変更を防止する**

リンクされた OLE オブジェクトをスライドに追加すると、プレゼンテーションを開いたときに PowerPoint がリンクの更新を促すことがあります。**リンクの更新** を選択すると、PowerPoint がリンク先オブジェクトのデータでプレビューを再生成するため、OLE オブジェクト フレームのサイズや位置が変わることがあります。PowerPoint がオブジェクト データの更新を促さないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) クラスの `update_automatic` プロパティを `False` に設定します。

```py
ole_frame.update_automatic = False
```

## **埋め込みファイルの抽出**

Aspose.Slides for Python を使用すると、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプを走査し、OleObjectFrame シェイプを見つけます。  
3. 各 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) から埋め込みファイル データを取得し、ディスクに書き込みます。

以下の Python コードは、スライドに埋め込まれた OLE オブジェクトとしてのファイルを抽出する方法を示します。

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

**スライドを PDF や画像にエクスポートしたとき、OLE コンテンツはレンダーされますか？**

スライド上に表示されるのはアイコン／代替画像（プレビュー）のみです。**「ライブ」** の OLE コンテンツはレンダー時に実行されません。必要に応じて、エクスポートされた PDF で期待通りの外観になるよう、プレビュー画像を独自に設定してください。

**PowerPoint でユーザーが OLE オブジェクトを移動・編集できないようにロックするには？**

シェイプをロックします。Aspose.Slides は [シェイプレベルのロック](/slides/ja/python-net/applying-protection-to-presentation/) を提供しています。暗号化ではありませんが、誤操作や移動を実質的に防止できます。

**リンクされた Excel オブジェクトをプレゼンテーションを開くたびに「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した外観を保つには、[ワークシートサイズ変更の作業ソリューション](/slides/ja/python-net/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケーリングし、適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX 形式では「相対パス」情報は保持されず、フル パスのみが保存されます。相対パスは旧形式の PPT のみで利用可能です。可搬性を重視する場合は、信頼できる絶対パス／アクセス可能な URI を使用するか、埋め込みを検討してください。