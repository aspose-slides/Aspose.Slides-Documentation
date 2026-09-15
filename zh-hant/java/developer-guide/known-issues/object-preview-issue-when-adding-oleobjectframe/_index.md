---
title: 加入 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解在 Aspose.Slides for Java 中加入 OleObjectFrame 時為何會出現 EMBEDDED OLE OBJECT，並學習如何修復 PPT、PPTX 與 ODP 簡報的預覽問題。"
---
## **簡介**

使用 Aspose.Slides for Java 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe/) 新增至投影片上，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息是有意為之，且不是錯誤。

欲了解更多有關 OLE 物件的操作資訊，請參閱 [Manage OLE](/slides/zh-hant/java/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已變更，必須更新預覽圖像。

例如，若您將 Microsoft Excel 圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe/) 新增至投影片（欲取得更多細節，請參閱「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您將會在投影片上看到此圖像：

![OLE 物件訊息](OLE_object_message.png)

如果您想檢查並確認 OLE 物件已新增至投影片，必須對「EMBEDDED OLE OBJECT」訊息進行雙擊，或右鍵點擊該訊息，然後選擇 **Object > Edit** 選項。

![OLE 物件 > 編輯](OLE_object_edit.png)

PowerPoint 隨即開啟嵌入的 OLE 物件。

![OLE 物件資料](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點擊 OLE 物件後，投影片預覽會更新，且「EMBEDDED OLE OBJECT」訊息會被 OLE 物件的實際影像取代。

![OLE 物件預覽](OLE_object_preview.png)

現在，您可能想儲存簡報，以確保 OLE 物件的影像正確更新。如此一來，儲存簡報後再次開啟時，您將不會看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

如果您不想透過在 PowerPoint 中開啟簡報後再儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以改以您偏好的預覽影像取代該訊息。以下程式碼行示範了此過程：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 將影像加入簡報資源。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // 設定 OLE 物件預覽的標題與影像。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

包含 `OleObjectFrame` 的投影片接著會變更為以下內容：

![新的 OLE 物件影像](OLE_object_new_image.png)