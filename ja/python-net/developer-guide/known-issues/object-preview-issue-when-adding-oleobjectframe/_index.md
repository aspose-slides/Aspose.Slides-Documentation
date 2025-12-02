---
title: OleObjectFrame を追加したときのオブジェクトプレビューの問題
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
description: "Aspose.Slides for Python で OleObjectFrame を追加した際に「EMBEDDED OLE OBJECT」が表示される理由と、PPT、PPTX、ODP プレゼンテーションのプレビュー問題を解決する方法を学びます。"
---

## **Introduction**

.NET を介した Python 用 Aspose.Slides を使用して、スライドに [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細は、[Manage OLE](/slides/ja/python-net/manage-ole/) を参照してください。

## **Explanation and Solution**

Aspose.Slides は「EMBEDDED OLE OBJECT」メッセージを表示し、OLE オブジェクトが変更されたこととプレビュー画像を更新する必要があることを通知します。

たとえば、Microsoft Excel チャートを [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) としてスライドに追加し（詳細は「Manage OLE」記事を参照）そのプレゼンテーションを Microsoft PowerPoint で開くと、スライドに次の画像が表示されます。

![OLE オブジェクト メッセージ](OLE_object_message.png)

「EMBEDDED OLE OBJECT」メッセージが正しくスライドに追加されたことを確認したい場合は、そのメッセージをダブルクリックするか、右クリックして **Object > 編集** オプションを選択します。

![OLE オブジェクト > 編集](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE オブジェクト データ](OLE_object_data.png)

スライドは「EMBEDDED OLE OBJECT」メッセージを保持する場合があります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、「EMBEDDED OLE OBJECT」メッセージは OLE オブジェクトの実際の画像に置き換えられます。

![OLE オブジェクト プレビュー](OLE_object_preview.png)

これで、OLE オブジェクトの画像が正しく更新されるようにプレゼンテーションを保存したくなるでしょう。こうすれば、プレゼンテーションを保存した後、再度開いたときに「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **Other Solutions**

### **Solution 1: Replace the "Embedded OLE Object" Message with an Image**

「EMBEDDED OLE OBJECT」メッセージを PowerPoint でプレゼンテーションを開いて保存することで削除したくない場合は、メッセージを希望のプレビュー画像に置き換えることができます。以下のコード行がその手順を示しています:
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


`OleObjectFrame` を含むスライドは次のように変わります。

![新しい OLE オブジェクト 画像](OLE_object_new_image.png)

### **Solution 2: Create an Add-On for PowerPoint**

Microsoft PowerPoint 用のアドオンを作成し、プログラムでプレゼンテーションを開くたびにすべての OLE オブジェクトを更新することもできます。