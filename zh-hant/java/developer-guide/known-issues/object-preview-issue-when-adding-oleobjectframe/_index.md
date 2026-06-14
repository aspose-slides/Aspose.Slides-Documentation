---
title: 新增 OleObjectFrame 時的物件預覽問題
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
description: "了解為什麼在 Aspose.Slides for Java 中新增 OleObjectFrame 會出現 EMBEDDED OLE OBJECT，以及如何在 PPT、PPTX 與 ODP 簡報中解決預覽問題。"
---
## **簡介**

使用 Aspose.Slides for Java 時，將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe/) 新增至投影片，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息是預期行為，並非錯誤。

如需瞭解更多 OLE 物件的使用方式，請參閱 [Manage OLE](/slides/zh-hant/java/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知 OLE 物件已變更且必須更新預覽圖像。

例如，若將 Microsoft Excel 圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/oleobjectframe/) 方式新增至投影片（詳情請參考「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您會在投影片上看到以下圖示：

![OLE object message](OLE_object_message.png)

若想確認 OLE 物件已正確加入投影片，您可以雙擊「EMBEDDED OLE OBJECT」訊息，或右鍵點擊它並選取 **Object > Edit**。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 隨即開啟嵌入的 OLE 物件。

![OLE object data](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點選 OLE 物件後，投影片的預覽會更新，「EMBEDDED OLE OBJECT」訊息會被實際的 OLE 物件圖像取代。

![OLE object preview](OLE_object_preview.png)

此時，您可以儲存簡報，以確保 OLE 物件的圖像正確更新。如此一來，重新開啟簡報時，就不會再看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

### **解決方案 1：以圖像取代「Embedded OLE Object」訊息**

如果不想透過在 PowerPoint 中開啟簡報再儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以將該訊息換成您想要的預覽圖像。以下程式碼示範了此過程：

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 將圖像新增至簡報資源。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // 設定 OLE 物件預覽的標題與圖像。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

包含 `OleObjectFrame` 的投影片將會變為以下樣子：

![New OLE object image](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 建立外掛程式**

您也可以為 Microsoft PowerPoint 開發一個外掛程式，在開啟簡報時自動更新所有 OLE 物件。