---
title: Python でプレゼンテーションの OLE を管理する
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
description: "Aspose.Slides for Python を使用して、PowerPoint および OpenDocument ファイルで OLE オブジェクトの管理を最適化します。OLE コンテンツの埋め込み、更新、エクスポートをシームレスに行います。"
---

{{% alert title="情報" color="info" %}}

OLE (オブジェクトリンク＆埋め込み)は、Microsoftの技術で、一つのアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みを通じて別のアプリケーションに配置することを可能にします。 

{{% /alert %}} 

MS Excelで作成されたチャートを考えてみてください。そのチャートはPowerPointスライド内に配置されます。ExcelチャートはOLEオブジェクトと見なされます。 

- OLEオブジェクトはアイコンとして表示される場合があります。この場合、アイコンをダブルクリックすると、そのチャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトを開いたり編集したりするアプリケーションを選択するよう求められます。 
- OLEオブジェクトは実際のコンテンツを表示する場合があります。たとえば、チャートの内容です。この場合、チャートはPowerPoint内でアクティブになり、チャートインターフェースがロードされ、PowerPointアプリ内でチャートのデータを変更できます。

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net)を使用すると、OLEオブジェクトをOLEオブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)）としてスライドに挿入することができます。

## **スライドにOLEオブジェクトフレームを追加する**
Microsoft Excelでチャートをすでに作成し、そのチャートをOLEオブジェクトフレームとしてスライドに埋め込みたい場合は、次のようにします：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Excelチャートオブジェクトを含むExcelファイルを開き、`MemoryStream`に保存します。
1. OLEオブジェクトに関するバイト配列とその他の情報を含むスライドにOLEオブジェクトフレームを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下の例では、Excelファイルからチャートをスライドに[Aspose.Slides for Python via .NET](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)を使用して追加しました。  
**注意**： [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/)コンストラクタは、埋め込み可能なオブジェクト拡張子を第二のパラメータとして受け取ります。この拡張子により、PowerPointはファイルタイプを正しく解釈し、このOLEオブジェクトを開くための適切なアプリケーションを選択できます。

```py 
import aspose.slides as slides

# PPTXを表すPresentationクラスのインスタンスを生成
with slides.Presentation() as pres:
    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # ストリームにエクセルファイルを読み込む
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # 埋め込むためのデータオブジェクトを作成
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # Oleオブジェクトフレームを追加
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # PPTXファイルをディスクに書き出す
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **OLEオブジェクトフレームにアクセスする**
OLEオブジェクトがすでにスライドに埋め込まれている場合は、次のようにして簡単にそのオブジェクトを見つけたりアクセスしたりできます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。

1. インデックスを使用してスライドの参照を取得します。

1. [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)シェイプにアクセスします。

   私たちの例では、最初のスライドに1つのシェイプしかない以前に作成されたPPTXを使用しました。そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)として*キャスト*しました。これがアクセスしたいOLEオブジェクトフレームです。

1. OLEオブジェクトフレームにアクセスすると、その上で任意の操作を行うことができます。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータを書き出します：

```py 
import aspose.slides as slides

# PPTXをプレゼンテーションオブジェクトに読み込む
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # シェイプをOleObjectFrameとしてキャスト
    oleObjectFrame = sld.shapes[0]

    # OLEオブジェクトを読み込み、ディスクに書き出す
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # 埋め込まれたファイルデータを取得
        data = oleObjectFrame.embedded_data.embedded_file_data

        # 埋め込まれたファイル拡張子を取得
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # 抽出したファイルを保存するパスを作成
        extractedPath = "excelFromOLE_out" + fileExtention

        # 抽出データを保存
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **OLEオブジェクトデータの変更**

OLEオブジェクトがすでにスライドに埋め込まれている場合、Aspose.Slides for Python via .NETを使用してそのオブジェクトに簡単にアクセスし、データを変更することができます：

1. 埋め込まれたOLEオブジェクトを持つプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成して開きます。

1. インデックスを使用してスライドの参照を取得します。

1. [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)シェイプにアクセスします。

   私たちの例では、最初のスライドに1つのシェイプしかない以前に作成されたPPTXを使用しました。そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)として*キャスト*しました。これがアクセスしたいOLEオブジェクトフレームです。

1. OLEオブジェクトフレームにアクセスすると、その上で任意の操作を行うことができます。

1. ワークブックオブジェクトを作成し、OLEデータにアクセスします。

1. 希望するワークシートにアクセスし、データを修正します。

1. 更新されたワークブックをストリームに保存します。

1. ストリームデータからOLEオブジェクトデータを変更します。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータを変更してチャートデータを変更します。

```py 
# [TODO:require Aspose.Cells for Python via .NET]
```

## スライドへのその他のファイルタイプの埋め込み

Excelチャートに加えて、Aspose.Slides for Python via .NETは、スライドに他のタイプのファイルを埋め込むことを許可します。たとえば、HTML、PDF、ZIPファイルをオブジェクトとしてスライドに挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、そのオブジェクトは自動的に関連プログラムで起動されるか、ユーザーはオブジェクトを開くための適切なプログラムを選択するよう指示されます。

このPythonコードは、スライドにHTMLとZIPを埋め込む方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## 埋め込まれたオブジェクトのファイルタイプの設定

プレゼンテーションで作業しているとき、古いOLEオブジェクトを新しいものと置き換える必要がある場合があります。または、サポートされていないOLEオブジェクトをサポートされているものと置き換える必要があるかもしれません。 

Aspose.Slides for Python via .NETを使用すると、埋め込まれたオブジェクトのファイルタイプを設定できます。これによりOLEフレームデータやその拡張子を変更できます。 

このPythonコードは、埋め込まれたOLEオブジェクトのファイルタイプを設定する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("現在の埋め込まれたデータ拡張子は: " + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## 埋め込まれたオブジェクトのアイコン画像とタイトルの設定

OLEオブジェクトを埋め込むと、アイコン画像とタイトルからなるプレビューが自動的に追加されます。プレビューは、ユーザーがOLEオブジェクトにアクセスまたは開く前に見るものです。 

特定の画像やテキストをプレビューの要素として使用したい場合は、Aspose.Slides for Python via .NETを使用してアイコン画像とタイトルを設定できます。 

このPythonコードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "私のタイトル"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```

## **OLEオブジェクトフレームのサイズ変更と位置変更を防ぐ**

リンクされたOLEオブジェクトをプレゼンテーションスライドに追加した後、PowerPointでプレゼンテーションを開くと、リンクを更新するかどうかを尋ねるメッセージが表示される場合があります。「リンクを更新」ボタンをクリックすると、OLEオブジェクトフレームのサイズと位置が変更される可能性があります。これは、PowerPointがリンクされたOLEオブジェクトからデータを更新し、オブジェクトのプレビューをリフレッシュするためです。PowerPointがオブジェクトのデータを更新するプロンプトを表示しないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)クラスの`update_automatic`プロパティを`False`に設定します：

```py
oleObjectFrame.update_automatic = False
```

## 埋め込まれたファイルの抽出

Aspose.Slides for Python via .NETは、次のようにしてスライドに埋め込まれたOLEオブジェクトのファイルを抽出できます：

1. 抽出するOLEオブジェクトを含む[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)のインスタンスを作成します。
2. プレゼンテーションのすべてのシェイプをループし、[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)シェイプにアクセスします。
3. OLEオブジェクトフレームから埋め込まれたファイルのデータにアクセスし、ディスクに書き出します。 

このPythonコードは、スライドに埋め込まれたファイルをOLEオブジェクトとして抽出する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
```