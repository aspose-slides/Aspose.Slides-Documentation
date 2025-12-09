---
title: OleObjectFrame を追加した際のオブジェクトプレビュー問題
linktitle: OLE オブジェクトの問題
type: docs
weight: 10
url: /ja/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- プレビュー問題
- 埋め込みオブジェクト
- 埋め込みファイル
- オブジェクトが変更された
- オブジェクトプレビュー
- プレゼンテーション
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で OleObjectFrame を追加した際に表示される EMBEDDED OLE OBJECT の原因と、PPT、PPTX、ODP プレゼンテーションにおけるプレビュー問題の修正方法を学びます。"
---

## **はじめに**

Aspose.Slides for .NET を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) を追加すると、出力スライドに "EMBEDDED OLE OBJECT" メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細情報は、[Manage OLE](/slides/ja/net/manage-ole/) を参照してください。

## **説明と解決策**

Aspose.Slides は、OLE オブジェクトが変更され、プレビュー画像を更新する必要があることを通知するために "EMBEDDED OLE OBJECT" メッセージを表示します。

例えば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) としてスライドに追加し（詳細は「Manage OLE」記事を参照）、Microsoft PowerPoint でプレゼンテーションを開くと、スライドに次の画像が表示されます:

![OLEオブジェクトメッセージ](OLE_object_message.png)

スライドに OLE オブジェクトが追加されたことを確認したい場合は、"EMBEDDED OLE OBJECT" メッセージをダブルクリックするか、右クリックして **Object > Edit** オプションを選択します。

![OLEオブジェクト > 編集](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLEオブジェクトデータ](OLE_object_data.png)

スライドは "EMBEDDED OLE OBJECT" メッセージを保持したままになることがあります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、"EMBEDDED OLE OBJECT" メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLEオブジェクトプレビュー](OLE_object_preview.png)

この時点で、プレゼンテーションを保存して OLE オブジェクトの画像が正しく更新されるようにすることができます。これにより、プレゼンテーションを保存した後、再度開いたときに "EMBEDDED OLE OBJECT" メッセージが表示されなくなります。

## **その他の解決策**

### **Solution 1: "Embedded OLE Object" メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開いて保存することで "EMBEDDED OLE OBJECT" メッセージを削除したくない場合は、メッセージを希望のプレビュー画像に置き換えることができます。以下のコード行がその手順を示しています:
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


`OleObjectFrame` を含むスライドは次のように変わります:

![新しい OLE オブジェクト画像](OLE_object_new_image.png)

### **Solution 2: PowerPoint 用アドオンを作成する**

Microsoft PowerPoint 用のアドオンを作成し、プログラムでプレゼンテーションを開くとすべての OLE オブジェクトを更新することもできます。