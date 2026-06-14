---
title: 加入 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解在 Aspose.Slides for Node.js 中加入 OleObjectFrame 時為何會出現 EMBEDDED OLE OBJECT，並學習如何修復 PPT、PPTX 與 ODP 簡報中的預覽問題。"
---
## **簡介**

使用 Aspose.Slides for Java 時，將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleobjectframe/) 新增至投影片，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息屬於預期行為，並非錯誤。

如需了解更多有關 OLE 物件的操作資訊，請參閱 [Manage OLE](/slides/zh-hant/nodejs-java/manage-ole/)。 

## **說明與解決方案**

Aspose.Slides 顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已變更，必須更新預覽圖像。

例如，若您將 Microsoft Excel 圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleobjectframe/) 方式加入投影片（更多細節請參閱「Manage OLE」文章），再於 Microsoft PowerPoint 開啟簡報，您會在投影片上看到下圖：

![OLE object message](OLE_object_message.png)

若要檢查並確認 OLE 物件已成功加入投影片，必須對「EMBEDDED OLE OBJECT」訊息進行雙擊，或右鍵點擊並選取 **Object > Edit**。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 會開啟嵌入的 OLE 物件。

![OLE object data](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。點擊 OLE 物件後，投影片的預覽將更新，該訊息會被 OLE 物件的實際圖像取代。

![OLE object preview](OLE_object_preview.png)

此時，您可能需要儲存簡報，以確保 OLE 物件的圖像正確更新。如此，在儲存簡報後再次開啟時，就不會看到「EMBEDDED OLE OBJECT」訊息。 

## **其他解決方案**

### **解決方案 1：以圖像取代「Embedded OLE Object」訊息**

如果不想透過在 PowerPoint 中開啟簡報並儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以將該訊息替換為您偏好的預覽圖像。以下程式碼示範此過程：

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // 新增影像至簡報資源。
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // 設定 OLE 物件預覽的標題與影像。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

包含 `OleObjectFrame` 的投影片將變為以下樣式：

![New OLE object image](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 建立外掛程式**

您也可以為 Microsoft PowerPoint 建立外掛程式，在開啟簡報時自動更新所有 OLE 物件。