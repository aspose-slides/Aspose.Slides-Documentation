---
title: OleObjectFrame 追加時のオブジェクトプレビュー問題
linktitle: OLE オブジェクトの問題
type: docs
weight: 10
url: /ja/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- プレビューの問題
- 埋め込みオブジェクト
- 埋め込みファイル
- オブジェクトが変更された
- オブジェクトプレビュー
- プレゼンテーション
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で OleObjectFrame を追加した際に「EMBEDDED OLE OBJECT」が表示される理由と、PPT、PPTX、ODP プレゼンテーションのプレビュー問題の修正方法を学びます。"
---

## **はじめに**

Aspose.Slides for .NET を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図したものであり、バグではありません。

OLE オブジェクトの操作に関する詳細は、[Manage OLE](/slides/ja/net/manage-ole/) を参照してください。

## **説明と対策**

Aspose.Slides は「EMBEDDED OLE OBJECT」メッセージを表示して、OLE オブジェクトが変更されプレビュー画像を更新する必要があることを通知します。

たとえば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) としてスライドに追加し（詳細は「Manage OLE」記事をご覧ください）、Microsoft PowerPoint でプレゼンテーションを開くと、スライド上に次の画像が表示されます。

![OLE object message](OLE_object_message.png)

スライドに OLE オブジェクトが追加されたことを確認したい場合は、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **Object > Edit** を選択します。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE object data](OLE_object_data.png)

スライドには「EMBEDDED OLE OBJECT」メッセージが残ることがあります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE object preview](OLE_object_preview.png)

次に、プレゼンテーションを保存して OLE オブジェクトの画像が正しく更新されるようにします。これにより、保存後にプレゼンテーションを再度開いても「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **その他の対策**

### **対策 1: 「Embedded OLE Object」メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開いて保存することなく「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、好みのプレビュー画像に置き換えることができます。以下のコード例がその手順を示しています。
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


`OleObjectFrame` を含むスライドは次のように変わります。

![New OLE object image](OLE_object_new_image.png)

### **対策 2: PowerPoint 用アドオンを作成する**

Microsoft PowerPoint 用のアドオンを作成し、プレゼンテーションを開くたびにすべての OLE オブジェクトを更新することもできます。