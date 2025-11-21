---
title: OleObjectFrame を追加した際のオブジェクトプレビューの問題
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
description: "Aspose.Slides for .NET で OleObjectFrame を追加すると EMBEDDED OLE OBJECT が表示される理由と、PPT、PPTX、ODP プレゼンテーションのプレビュー問題を解決する方法を学びます。"
---

## **はじめに**

Aspose.Slides for .NET を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」というメッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細は、[Manage OLE](/slides/ja/net/manage-ole/) を参照してください。

## **説明と解決策**

Aspose.Slides は「EMBEDDED OLE OBJECT」メッセージを表示して、OLE オブジェクトが変更され、プレビュー画像を更新する必要があることを通知します。

たとえば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) としてスライドに追加した場合（詳細は「Manage OLE」記事参照）、プレゼンテーションを Microsoft PowerPoint で開くと、スライドに次の画像が表示されます。

![OLE object message](OLE_object_message.png)

「EMBEDDED OLE OBJECT」メッセージがスライドに追加されたことを確認したい場合は、メッセージをダブルクリックするか、右クリックして **Object > Edit** オプションを選択します。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE object data](OLE_object_data.png)

スライドは「EMBEDDED OLE OBJECT」メッセージを保持したままになることがあります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE object preview](OLE_object_preview.png)

このとき、プレゼンテーションを保存して OLE オブジェクトの画像が正しく更新されるようにします。保存後にプレゼンテーションを再度開くと、「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **その他の解決策**

### **解決策 1: 「Embedded OLE Object」メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開いて保存することなく「EMBEDDED OLE OBJECT」メッセージを削除したい場合は、メッセージを好みのプレビュー画像に置き換えることができます。以下のコード例がその手順を示しています。
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


`OleObjectFrame` を含むスライドは次のように変更されます。

![New OLE object image](OLE_object_new_image.png)

### **解決策 2: PowerPoint 用アドオンの作成**

Microsoft PowerPoint 用のアドオンを作成し、プレゼンテーションを開くたびにすべての OLE オブジェクトを更新することもできます。