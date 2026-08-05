---
title: OleObjectFrame 追加時のオブジェクトプレビュー問題
linktitle: OLE オブジェクトの問題
type: docs
weight: 10
url: /ja/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
  - OLE
  - プレビュー問題
  - 埋め込みオブジェクト
  - 埋め込みファイル
  - オブジェクト変更
  - オブジェクトプレビュー
  - PowerPoint
  - プレゼンテーション
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js で OleObjectFrame を追加した際に「EMBEDDED OLE OBJECT」が表示される理由と、PPT、PPTX、ODP プレゼンテーションのプレビュー問題を解決する方法を学びます。"
---
## **はじめに**

Aspose.Slides for Java を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細情報は、[OLE の管理](/slides/ja/nodejs-java/manage-ole/) を参照してください。

## **説明と解決策**

Aspose.Slides は、OLE オブジェクトが変更されプレビュー画像を更新する必要があることを通知するために「EMBEDDED OLE OBJECT」メッセージを表示します。

例えば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/oleobjectframe/) としてスライドに追加し（詳細は「Manage OLE」記事を参照）、その後 Microsoft PowerPoint でプレゼンテーションを開くと、スライド上に次の画像が表示されます：

![OLE オブジェクト メッセージ](OLE_object_message.png)

OLE オブジェクトがスライドに追加されたことを確認したい場合は、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **Object > Edit** オプションを選択してください。

![OLE オブジェクト > 編集](OLE_object_edit.png)

PowerPoint は埋め込まれた OLE オブジェクトを開きます。

![OLE オブジェクト データ](OLE_object_data.png)

スライドは「EMBEDDED OLE OBJECT」メッセージを保持したままになることがあります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、「EMBEDDED OLE OBJECT」メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE オブジェクト プレビュー](OLE_object_preview.png)

ここで、プレゼンテーションを保存して OLE オブジェクトの画像が正しく更新されるようにしたい場合があります。これにより、プレゼンテーションを保存した後、再度開いたときに「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **その他の解決策**

### **ソリューション 1: "Embedded OLE Object" メッセージを画像に置き換える**

PowerPoint でプレゼンテーションを開いて保存することで「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、メッセージを好きなプレビュー画像に置き換えることができます。以下のコード行がその手順を示しています：

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // プレゼンテーションのリソースに画像を追加します。
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // OLE オブジェクトのプレビュー用にタイトルと画像を設定します。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

`OleObjectFrame` を含むスライドは次のように変わります：

![新しい OLE オブジェクト画像](OLE_object_new_image.png)

### **ソリューション 2: PowerPoint 用アドオンの作成**

プレゼンテーションをプログラムで開く際にすべての OLE オブジェクトを更新する Microsoft PowerPoint 用のアドオンを作成することもできます。