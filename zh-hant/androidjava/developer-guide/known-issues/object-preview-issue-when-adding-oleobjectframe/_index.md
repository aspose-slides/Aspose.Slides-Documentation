---
title: 加入 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解為何在 Android 版 Aspose.Slides（透過 Java）中加入 OleObjectFrame 時會顯示 EMBEDDED OLE OBJECT，以及如何在 PPT、PPTX 與 ODP 簡報中修復預覽問題。"
---
## **簡介**

在 Android 上透過 Java 使用 Aspose.Slides 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/oleobjectframe/) 加入投影片時，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息屬於預期行為，並非錯誤。

欲取得有關 OLE 物件操作的更多資訊，請參閱 [Manage OLE](/slides/zh-hant/androidjava/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已被修改，需更新預覽影像。

例如，若您將 Microsoft Excel 圖表作為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/oleobjectframe/) 加入投影片（欲了解更多細節，請參閱「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您會在投影片上看到以下影像：

![OLE object message](OLE_object_message.png)

若要檢查並確認您的 OLE 物件已加入投影片，您需要對「EMBEDDED OLE OBJECT」訊息進行雙擊，或右鍵點擊該訊息，然後選擇 **Object > Edit**。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 會開啟嵌入的 OLE 物件。

![OLE object data](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點擊 OLE 物件後，投影片的預覽會更新，「EMBEDDED OLE OBJECT」訊息會被 OLE 物件的實際影像取代。

![OLE object preview](OLE_object_preview.png)

現在，您可能想要儲存簡報，以確保 OLE 物件的影像正確更新。如此，在儲存簡報後再次開啟時，就不會再看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

### **解決方案 1：以影像取代「Embedded OLE Object」訊息**

如果您不想透過在 PowerPoint 中開啟簡報再儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以將該訊息替換為您偏好的預覽影像。以下程式碼示範此過程：

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 將影像新增至簡報資源。
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

包含 `OleObjectFrame` 的投影片會變更為以下內容：

![New OLE object image](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 建立附加元件**

您也可以為 Microsoft PowerPoint 建立附加元件，讓程式在開啟簡報時自動更新所有 OLE 物件。