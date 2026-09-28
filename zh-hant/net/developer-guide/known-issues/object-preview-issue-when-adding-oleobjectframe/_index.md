---
title: 在添加 OleObjectFrame 時的物件預覽佔位符
linktitle: OLE 預覽佔位符
type: docs
weight: 10
url: /zh-hant/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 預覽佔位符
- 依設計
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- 簡報
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "為什麼使用 Aspose.Slides for .NET 新增的 OLE 物件會顯示 EMBEDDED OLE OBJECT 佔位符，直到其預覽更新為止，以及如何設定自己的預覽圖像。"
---
## **介紹**

使用 Aspose.Slides for .NET 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe/) 新增到投影片，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息是有意為之，並非錯誤。

如需取得有關 OLE 物件的更多資訊，請參閱 [Manage OLE](/slides/zh-hant/net/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已變更，必須更新預覽圖像。

例如，若您將 Microsoft Excel 圖表作為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe/) 新增至投影片（更多細節請參閱「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您將在投影片上看到此圖像：

![OLE 物件訊息](OLE_object_message.png)

若要檢查並確認您的 OLE 物件已加入投影片，必須對「EMBEDDED OLE OBJECT」訊息執行雙擊，或右鍵點擊該訊息，並選擇 **Object > Edit**。

![OLE 物件 > 編輯](OLE_object_edit.png)

PowerPoint 隨即開啟嵌入的 OLE 物件。

![OLE 物件資料](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點擊 OLE 物件後，投影片預覽會更新，且「EMBEDDED OLE OBJECT」訊息會被 OLE 物件的實際圖像取代。

![OLE 物件預覽](OLE_object_preview.png)

現在，您可能想儲存簡報，以確保 OLE 物件的圖像正確更新。如此，在儲存簡報後再次開啟時，您將不會看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

### **解決方案 1：將「EMBEDDED OLE OBJECT」訊息取代為影像**

如果您不想透過在 PowerPoint 中開啟簡報並儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以將該訊息取代為您偏好的預覽圖像。以下程式碼說明了此過程：

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

包含 `OleObjectFrame` 的投影片會變更為以下內容：

![新的 OLE 物件影像](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 建立外掛程式**

您也可以為 Microsoft PowerPoint 建立外掛程式，以在開啟簡報時更新所有 OLE 物件。