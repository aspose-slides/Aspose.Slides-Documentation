---
title: OleObjectFrame の追加時に発生するオブジェクトプレビューの問題
linktitle: OLE オブジェクトの問題
type: docs
weight: 10
url: /ja/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- プレビューの問題
- 埋め込みオブジェクト
- 埋め込みファイル
- オブジェクトが変更された
- オブジェクトのプレビュー
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で OleObjectFrame を追加した際に「EMBEDDED OLE OBJECT」が表示される理由と、PPT、PPTX、ODP プレゼンテーションのプレビュー問題を解決する方法を学びます。"
---
## **はじめに**

Aspose.Slides for Python via Java を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細情報は、[OLE の管理](/slides/ja/python-java/manage-ole/)をご覧ください。

## **説明とソリューション**

Aspose.Slides は、OLE オブジェクトが変更されプレビュー画像を更新する必要があることを通知するために「EMBEDDED OLE OBJECT」メッセージを表示します。

たとえば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) としてスライドに追加した場合（詳細は「OLE の管理」記事をご参照ください）、Microsoft PowerPoint でプレゼンテーションを開くと、スライドに次の画像が表示されます：

![OLE object message](OLE_object_message.png)

OLE オブジェクトがスライドに追加されたことを確認するには、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **Object > Edit** を選択します。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE object data](OLE_object_data.png)

スライドには「EMBEDDED OLE OBJECT」メッセージが残る場合があります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、「EMBEDDED OLE OBJECT」メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE object preview](OLE_object_preview.png)

プレゼンテーションを保存して、更新された OLE オブジェクトのプレビュー画像を保持してください。再度プレゼンテーションを開くと、「EMBEDDED OLE OBJECT」メッセージは表示されなくなります。

## **その他の解決策**

PowerPoint でプレゼンテーションを開いて保存することで「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、メッセージを任意のプレビュー画像に置き換えることができます。以下のコードがその手順を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # プレゼンテーションのリソースに画像を追加します。
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # OLE オブジェクトのプレビュー用にタイトルと画像を設定します。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[OleObjectFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleobjectframe/) を含むスライドは次のように変更されます：

![New OLE object image](OLE_object_new_image.png)

## **FAQ**

**「EMBEDDED OLE OBJECT」メッセージが表示されるのはなぜですか？**

このメッセージは、OLE オブジェクトが変更されプレビュー画像の更新が必要であることを示す意図的な動作です。

**PowerPoint でプレビューを更新するにはどうすればよいですか？**

メッセージをダブルクリックするか、**Object > Edit** を選択して埋め込み OLE オブジェクトを開きます。OLE オブジェクトをクリックしてプレビューを更新し、プレゼンテーションを保存してください。

**PowerPoint でプレゼンテーションを開かずにメッセージを置き換えることはできますか？**

はい。上記のコード例のように、OLE オブジェクトに任意のプレビュー画像を割り当てることでメッセージを置き換えることができます。