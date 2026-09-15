---
title: OleObjectFrame 追加時のオブジェクトプレビュー問題
linktitle: OLE オブジェクト問題
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
description: "Aspose.Slides for Java で OleObjectFrame を追加すると「EMBEDDED OLE OBJECT」が表示される理由と、PPT、PPTX、ODP プレゼンテーションのプレビュー問題を解決する方法を学びます。"
---
## **はじめに**

Aspose.Slides for Java を使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」メッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

詳しい情報は、[OLE の管理](/slides/ja/java/manage-ole/) を参照してください。

## **説明とソリューション**

Aspose.Slides は、OLE オブジェクトが変更され、プレビュー画像を更新する必要があることを通知するために「EMBEDDED OLE OBJECT」メッセージを表示します。

たとえば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/oleobjectframe/) としてスライドに追加した場合（詳細は「OLE の管理」記事を参照）、その後 Microsoft PowerPoint でプレゼンテーションを開くと、スライドに次の画像が表示されます：

![OLE オブジェクト メッセージ](OLE_object_message.png)

OLE オブジェクトがスライドに追加されたことを確認したい場合は、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **オブジェクト > 編集** オプションを選択します。

![OLE オブジェクト > 編集](OLE_object_edit.png)

PowerPoint は埋め込み OLE オブジェクトを開きます。

![OLE オブジェクト データ](OLE_object_data.png)

スライドには「EMBEDDED OLE OBJECT」メッセージが残ることがあります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、「EMBEDDED OLE OBJECT」メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE オブジェクト プレビュー](OLE_object_preview.png)

これで、プレゼンテーションを保存して OLE オブジェクトの画像が正しく更新されていることを確認できます。この方法でプレゼンテーションを保存し、再度開くと「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **その他の解決策**

PowerPoint でプレゼンテーションを開いて保存することで「EMBEDDED OLE OBJECT」メッセージを削除したくない場合は、好きなプレビュー画像に置き換えることができます。以下のコード行がその手順を示しています：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // プレゼンテーションリソースに画像を追加します。
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

`OleObjectFrame` を含むスライドは次のように変更されます。

![新しい OLE オブジェクト画像](OLE_object_new_image.png)