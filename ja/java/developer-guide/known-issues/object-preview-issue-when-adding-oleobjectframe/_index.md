---
title: OleObjectFrame を追加する際のオブジェクト プレビュー プレースホルダー
linktitle: OLE プレビュー プレースホルダー
type: docs
weight: 10
url: /ja/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- プレビュー問題
- プレビュー プレースホルダー
- 設計上の仕様
- 埋め込みオブジェクト
- 埋め込みファイル
- オブジェクトが変更された
- オブジェクト プレビュー
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で追加された OLE オブジェクトがプレビューが更新されるまで「EMBEDDED OLE OBJECT」プレースホルダーを表示する理由と、独自のプレビュー画像を設定する方法"
---
## **はじめに**

Aspose.Slides for Java でスライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/oleobjectframe/) を追加すると、出力スライドに「EMBEDDED OLE OBJECT」というメッセージが表示されます。このメッセージは意図されたものであり、バグではありません。

OLE オブジェクトの操作に関する詳細は、[OLE の管理](/slides/ja/java/manage-ole/) を参照してください。

## **説明と解決策**

Aspose.Slides は「EMBEDDED OLE OBJECT」メッセージを表示し、OLE オブジェクトが変更されたこととプレビュー画像を更新する必要があることを通知します。

たとえば、Microsoft Excel のチャートを [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/oleobjectframe/) としてスライドに追加し（詳細は「OLE の管理」記事を参照）、そのプレゼンテーションを Microsoft PowerPoint で開くと、スライド上に次の画像が表示されます。

![OLE オブジェクト メッセージ](OLE_object_message.png)

OLE オブジェクトがスライドに正しく追加されたか確認したい場合は、「EMBEDDED OLE OBJECT」メッセージをダブルクリックするか、右クリックして **オブジェクト > 編集** オプションを選択します。

![OLE オブジェクト > 編集](OLE_object_edit.png)

PowerPoint が埋め込み OLE オブジェクトを開きます。

![OLE オブジェクト データ](OLE_object_data.png)

スライドには「EMBEDDED OLE OBJECT」メッセージが残ることがあります。OLE オブジェクトをクリックすると、スライドのプレビューが更新され、メッセージは OLE オブジェクトの実際の画像に置き換わります。

![OLE オブジェクト プレビュー](OLE_object_preview.png)

これで、プレゼンテーションを保存すると OLE オブジェクトの画像が正しく更新されます。保存後にプレゼンテーションを再度開いても、「EMBEDDED OLE OBJECT」メッセージは表示されません。

## **その他の解決策**

PowerPoint でプレゼンテーションを開いて保存することなく「EMBEDDED OLE OBJECT」メッセージを削除したい場合は、好きなプレビュー画像に差し替えることができます。以下のコードはその手順を示しています。*embeddedOLE.pptx* の最初のスライドの最初のシェイプが OLE オブジェクト フレームであり、*myImage.png* に表示したい画像があると仮定し、結果を *embeddedOLE-newImage.pptx* として保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // プレゼンテーションのリソースに画像を追加します。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // OLE オブジェクト プレビュー用の画像を設定します。
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`OleObjectFrame` を含むスライドは次のように変更されます。

![新しい OLE オブジェクト画像](OLE_object_new_image.png)