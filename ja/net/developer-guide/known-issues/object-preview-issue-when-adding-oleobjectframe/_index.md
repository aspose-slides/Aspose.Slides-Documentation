---
title: OleObjectFrame を追加したときのオブジェクト プレビュー プレースホルダー
linktitle: OLE プレビュー プレースホルダー
type: docs
weight: 10
url: /ja/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- プレビューの問題
- プレビュー プレースホルダー
- 設計上の仕様
- 埋め込みオブジェクト
- 埋め込みファイル
- オブジェクトが変更された
- オブジェクト プレビュー
- プレゼンテーション
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で追加された OLE オブジェクトが、プレビューが更新されるまで「EMBEDDED OLE OBJECT」プレースホルダーとして表示される理由と、独自のプレビュー画像を設定する方法。"
---
## **はじめに**

Aspose.Slides for .NET を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細情報は、[Manage OLE](/slides/ja/net/manage-ole/) を参照してください。

## **説明とソリューション**

Aspose.Slides は、OLE オブジェクトが変更され、プレビュー画像を更新する必要があることを通知するために「EMBEDDED OLE OBJECT」メッセージを表示します。

例として、Microsoft Excel のグラフを [OleObjectFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/oleobjectframe/) としてスライドに追加し（詳細は「Manage OLE」記事を参照）、そのプレゼンテーションを Microsoft PowerPoint で開くと、スライドに次の画像が表示されます：

![OLE オブジェクト メッセージ](OLE_object_message.png)

OLE オブジェクトがスライドに追加されたことを確認したい場合は、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **Object > Edit** オプションを選択してください。

![OLE オブジェクト > 編集](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE オブジェクト データ](OLE_object_data.png)

スライドには「EMBEDDED OLE OBJECT」メッセージが残っている場合があります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、「EMBEDDED OLE OBJECT」メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE オブジェクト プレビュー](OLE_object_preview.png)

ここで、OLE オブジェクトの画像が正しく更新されるようにプレゼンテーションを保存したい場合があります。これにより、プレゼンテーションを保存した後に再度開くと、「EMBEDDED OLE OBJECT」メッセージが表示されなくなります。

## **その他のソリューション**

### **ソリューション 1: "Embedded OLE Object" メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開いて保存することで「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、好きなプレビュー画像にメッセージを置き換えることができます。以下のコード行がその手順を示しています：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

`OleObjectFrame` を含むスライドは次のように変わります。

![新しい OLE オブジェクト 画像](OLE_object_new_image.png)

### **ソリューション 2: PowerPoint 用アドオンを作成する**

Microsoft PowerPoint 用のアドオンを作成し、プレゼンテーションを開く際にすべての OLE オブジェクトを更新することもできます。