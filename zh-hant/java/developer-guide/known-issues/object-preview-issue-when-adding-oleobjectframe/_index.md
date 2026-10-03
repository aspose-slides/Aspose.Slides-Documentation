---
title: 在新增 OleObjectFrame 時的物件預覽佔位符
linktitle: OLE 預覽佔位符
type: docs
weight: 10
url: /zh-hant/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 預覽佔位符
- 設計如此
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "說明為何使用 Aspose.Slides for Java 新增的 OLE 物件會在其預覽更新之前顯示「EMBEDDED OLE OBJECT」佔位符，以及如何自行設定預覽圖像。"
---
## **簡介**

使用 Aspose.Slides for Java 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe/) 新增至投影片，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息屬於預期行為，並非錯誤。

若需了解更多 OLE 物件的使用方式，請參閱 [Manage OLE](/slides/zh-hant/java/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已變更且需要更新預覽圖像。

例如，若您將 Microsoft Excel 圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe/) 的方式加入投影片（更多細節請參考「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您會在投影片上看到下圖所示的畫面：

![OLE object message](OLE_object_message.png)

如果您想確認 OLE 物件已正確加入投影片，必須雙擊「EMBEDDED OLE OBJECT」訊息，或是右鍵點選該訊息，然後選擇 **物件 > 編輯**。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 會開啟嵌入的 OLE 物件。

![OLE object data](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點選 OLE 物件後，投影片的預覽會更新，該訊息會被 OLE 物件的實際圖像取代。

![OLE object preview](OLE_object_preview.png)

接著，您可能需要儲存簡報，以確保 OLE 物件的圖像已正確更新。如此，在再次開啟簡報時，就不會再看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

如果您不想透過在 PowerPoint 中開啟簡報並儲存的方式移除「EMBEDDED OLE OBJECT」訊息，亦可將該訊息替換為您自行選擇的預覽圖像。以下程式碼示範了此流程。程式碼假設 *embeddedOLE.pptx* 的第一張投影片的第一個圖形即為 OLE 物件框，且 *myImage.png* 為欲顯示的圖像，最終結果會儲存為 *embeddedOLE-newImage.pptx*：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 將影像新增至簡報資源。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // 設定 OLE 物件預覽的影像。
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

包含 `OleObjectFrame` 的投影片會變更為下圖所示：

![New OLE object image](OLE_object_new_image.png)