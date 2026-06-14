---
title: 在加入 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解在 Aspose.Slides for C++ 中加入 OleObjectFrame 時為何會出現「EMBEDDED OLE OBJECT」，以及如何在 PPT、PPTX 和 ODP 簡報中修復預覽問題。"
---
## **簡介**

使用 Aspose.Slides for C++ 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 加入投影片中，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息是有意顯示的，並非錯誤。

如需有關 OLE 物件的更多資訊，請參閱 [Manage OLE](/slides/zh-hant/cpp/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已變更，需更新預覽圖像。

例如，若您將 Microsoft Excel 圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 加入投影片（詳情請參閱「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您會在投影片上看到此圖像：

![OLE 物件訊息](OLE_object_message.png)

如果您想檢查並確認 OLE 物件已加入投影片，必須對「EMBEDDED OLE OBJECT」訊息進行雙擊，或右鍵點選該訊息並選取 **Object > Edit** 選項。

![OLE 物件 > 編輯](OLE_object_edit.png)

PowerPoint 會打開嵌入的 OLE 物件。

![OLE 物件資料](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點擊 OLE 物件後，投影片預覽會更新，該訊息會被 OLE 物件的實際圖像取代。

![OLE 物件預覽](OLE_object_preview.png)

現在，您可能想儲存簡報，以確保 OLE 物件的圖像正確更新。如此一來，儲存後再次開啟簡報時，就不會看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

### **解決方案 1：以圖像取代「Embedded OLE Object」訊息**

如果您不想透過在 PowerPoint 中開啟簡報再儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以以自己偏好的預覽圖像取代該訊息。以下程式碼行示範了此過程：

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

包含 `OleObjectFrame` 的投影片會變更為下圖：

![新 OLE 物件圖像](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 建立外掛程式**

您也可以為 Microsoft PowerPoint 建立外掛程式，於開啟簡報時自動更新所有 OLE 物件。