---
title: 新增 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- 簡報
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "了解在 Aspose.Slides for .NET 中新增 OleObjectFrame 時為何會出現 EMBEDDED OLE OBJECT，以及如何修復 PPT、PPTX 與 ODP 簡報的預覽問題。"
---
## **簡介**

使用 Aspose.Slides for .NET 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe) 新增到投影片上，輸出投影片會顯示「EMBEDDED OLE OBJECT」訊息。此訊息為預期行為，並非錯誤。

如需了解更多 OLE 物件的操作，請參閱 [Manage OLE](/slides/zh-hant/net/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已變更，必須更新預覽圖像。

例如，若您將 Microsoft Excel 圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe) 的形式加入投影片（詳細說明請參考「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您會在投影片上看到如下圖像：

![OLE 物件訊息](OLE_object_message.png)

若要檢查並確認您的 OLE 物件已加入投影片，您需要雙擊「EMBEDDED OLE OBJECT」訊息，或右鍵點擊後選取 **Object > Edit** 選項。

![OLE 物件 > 編輯](OLE_object_edit.png)

PowerPoint 隨即開啟嵌入的 OLE 物件。

![OLE 物件資料](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點選 OLE 物件後，投影片預覽會更新，訊息會被 OLE 物件的實際圖像取代。

![OLE 物件預覽](OLE_object_preview.png)

此時，您可以儲存簡報，以確保 OLE 物件的圖像正確更新。如此一來，儲存並再次開啟簡報時，就不會再看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

### **解決方案 1：以圖像取代「Embedded OLE Object」訊息**

如果您不想透過在 PowerPoint 開啟簡報後再儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以將該訊息替換為您偏好的預覽圖像。以下程式碼示範了此過程：

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

包含 `OleObjectFrame` 的投影片將變為以下圖示：

![新的 OLE 物件圖像](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 開發外掛程式**

您也可以為 Microsoft PowerPoint 開發外掛程式，於開啟簡報時自動更新所有 OLE 物件。