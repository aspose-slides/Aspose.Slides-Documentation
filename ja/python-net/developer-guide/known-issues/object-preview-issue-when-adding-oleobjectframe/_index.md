---
title: OleObjectFrame を追加したときのオブジェクトプレビュー問題
linktitle: OLE オブジェクトの問題
type: docs
weight: 10
url: /ja/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- プレビューの問題
- 埋め込みオブジェクト
- 埋め込みファイル
- オブジェクトが変更された
- オブジェクトプレビュー
- プレゼンテーション
- PowerPoint
- Python
- Aspose.Slides
description: "Aspose.Slides for Python で OleObjectFrame を追加したときに EMBEDDED OLE OBJECT が表示される理由と、PPT、PPTX、ODP プレゼンテーションのプレビュー問題を解決する方法を学びます。"
---

## **概要**

Aspose.Slides for Python via .NET を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細は、[Manage OLE](/slides/ja/python-net/manage-ole/) を参照してください。

## **説明と解決策**

Aspose.Slides は、OLE オブジェクトが変更されプレビュー画像を更新する必要があることを通知するために「EMBEDDED OLE OBJECT」メッセージを表示します。

たとえば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) としてスライドに追加し（詳細は「Manage OLE」記事を参照）、そのプレゼンテーションを Microsoft PowerPoint で開くと、スライドに次の画像が表示されます。

![OLE object message](OLE_object_message.png)

スライドに OLE オブジェクトが正しく追加されたか確認するには、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **Object > Edit** を選択します。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE object data](OLE_object_data.png)

スライドは「EMBEDDED OLE OBJECT」メッセージのままになることがあります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE object preview](OLE_object_preview.png)

この画像が正しく更新されるようにプレゼンテーションを保存すると、保存後に再度開いた際に「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **その他の解決策**

### **解決策 1: 「Embedded OLE Object」メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開いて保存することで「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、任意のプレビュー画像にメッセージを置き換えることができます。以下のコード行がその手順を示しています。
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # プレゼンテーションのリソースに画像を追加します。
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE オブジェクトのプレビュー用にタイトルと画像を設定します。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


`OleObjectFrame` を含むスライドは次のように変更されます。

![New OLE object image](OLE_object_new_image.png)

### **解決策 2: PowerPoint 用のアドオンを作成する**

Microsoft PowerPoint 用のアドオンを作成し、プレゼンテーションを開いたときにすべての OLE オブジェクトを更新することもできます。