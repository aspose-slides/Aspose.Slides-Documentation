---
title: OleObjectFrame を追加したときのオブジェクト プレビュー問題
linktitle: OLE オブジェクトの問題
type: docs
weight: 10
url: /ja/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- プレビューの問題
- 埋め込みオブジェクト
- 埋め込みファイル
- オブジェクトが変更された
- オブジェクトプレビュー
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で OleObjectFrame を追加した際に「EMBEDDED OLE OBJECT」が表示される理由と、PPT、PPTX、ODP プレゼンテーションにおけるプレビュー問題の修正方法を学びます。"
---

## **はじめに**

Aspose.Slides for Java を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細は、[Manage OLE](/slides/ja/java/manage-ole/) を参照してください。

## **説明とソリューション**

Aspose.Slides は、OLE オブジェクトが変更されプレビュー画像を更新する必要があることを通知するために「EMBEDDED OLE OBJECT」メッセージを表示します。

たとえば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) としてスライドに追加し（詳細は「Manage OLE」記事を参照）、そのプレゼンテーションを Microsoft PowerPoint で開くと、スライドに次の画像が表示されます。

![OLE オブジェクト メッセージ](OLE_object_message.png)

OLE オブジェクトがスライドに追加されたことを確認したい場合は、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **Object > Edit** オプションを選択します。

![OLE オブジェクト > 編集](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE オブジェクト データ](OLE_object_data.png)

スライドには「EMBEDDED OLE OBJECT」メッセージが残る場合があります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、「EMBEDDED OLE OBJECT」メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE オブジェクト プレビュー](OLE_object_preview.png)

この時点で、OLE オブジェクトの画像が正しく更新されるようにプレゼンテーションを保存したい場合があります。これにより、プレゼンテーションを保存した後、再度開いたときに「EMBEDDED OLE OBJECT」メッセージが表示されなくなります。

## **その他のソリューション**

### **ソリューション 1: 「Embedded OLE Object」メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開いて保存することで「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、好きなプレビュー画像にメッセージを置き換えることができます。以下のコード行がその手順を示しています:
```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // プレゼンテーションのリソースに画像を追加します。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // OLE オブジェクトのプレビュー用にタイトルと画像を設定します。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


`OleObjectFrame` を含むスライドは次のように変わります:

![新しい OLE オブジェクト画像](OLE_object_new_image.png)

### **ソリューション 2: PowerPoint 用のアドオンを作成する**

また、プレゼンテーションを開く際にすべての OLE オブジェクトを更新する Microsoft PowerPoint 用のアドオンを作成することもできます。