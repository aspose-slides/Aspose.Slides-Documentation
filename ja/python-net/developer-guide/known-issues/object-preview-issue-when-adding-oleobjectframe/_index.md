---
title: OleObjectFrame を追加したときのオブジェクトプレビュー問題
linktitle: OLE オブジェクト問題
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
description: "Aspose.Slides for Python で OleObjectFrame を追加すると EMBEDDED OLE OBJECT が表示される理由と、PPT、PPTX、ODP プレゼンテーションでのプレビュー問題の修正方法を学びます。"
---

## **イントロダクション**

.NET 経由で Python 用 Aspose.Slides を使用して、スライドに [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細は、[Manage OLE](/slides/ja/python-net/manage-ole/) を参照してください。

## **説明と解決策**

Aspose.Slides は、OLE オブジェクトが変更され、プレビュー画像を更新する必要があることを通知するために「EMBEDDED OLE OBJECT」メッセージを表示します。

例えば、Microsoft Excel グラフを [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) としてスライドに追加し（詳細は「Manage OLE」記事を参照）、その後 Microsoft PowerPoint でプレゼンテーションを開くと、スライドに次の画像が表示されます。

![OLE オブジェクト メッセージ](OLE_object_message.png)

OLE オブジェクトがスライドに追加されたことを確認したい場合は、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **Object > Edit** オプションを選択します。

![OLE オブジェクト > 編集](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE オブジェクト データ](OLE_object_data.png)

スライドには「EMBEDDED OLE OBJECT」メッセージが残っている場合があります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、「EMBEDDED OLE OBJECT」メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE オブジェクト プレビュー](OLE_object_preview.png)

この時点で、プレゼンテーションを保存して OLE オブジェクトの画像が正しく更新されるようにしたいと思うかもしれません。このようにプレゼンテーションを保存すれば、再度開いたときに「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **その他の解決策**

### **解決策 1: 「Embedded OLE Object」メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開き保存することで「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、メッセージを好みのプレビュー画像に置き換えることができます。以下のコード行がその手順を示しています。
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # プレゼンテーションリソースに画像を追加します。
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE オブジェクトプレビュー用にタイトルと画像を設定します。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


`OleObjectFrame` を含むスライドは次のように変わります。

![新しい OLE オブジェクト画像](OLE_object_new_image.png)

### **解決策 2: PowerPoint 用アドオンを作成する**

Microsoft PowerPoint 用のアドオンを作成し、プログラムでプレゼンテーションを開くとすべての OLE オブジェクトを更新できるようにすることもできます。