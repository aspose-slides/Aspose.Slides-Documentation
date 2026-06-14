---
title: 新增 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- 簡報
- PowerPoint
- Python
- Aspose.Slides
description: "了解在 Aspose.Slides for Python 中新增 OleObjectFrame 時為何會出現 EMBEDDED OLE OBJECT，以及如何在 PPT、PPTX 與 ODP 簡報中修復預覽問題。"
---
## **介紹**

使用 Aspose.Slides for Python via .NET 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 新增至投影片時，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息是刻意的，並非錯誤。

如需有關處理 OLE 物件的更多資訊，請參閱 [Manage OLE](/slides/zh-hant/python-net/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已被變更且必須更新預覽影像。

例如，若您將 Microsoft Excel 圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 新增至投影片（欲取得更多細節，請參閱「Manage OLE」文章），然後在 Microsoft PowerPoint 中開啟簡報，您將在投影片上看到此影像：

![OLE object message](OLE_object_message.png)

如果您想檢查並確認 OLE 物件已加入投影片，必須對「EMBEDDED OLE OBJECT」訊息進行雙擊，或右鍵點擊它，然後選擇 **Object > Edit** 選項。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 隨即開啟嵌入的 OLE 物件。

![OLE object data](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點擊 OLE 物件後，投影片的預覽會更新，且「EMBEDDED OLE OBJECT」訊息將被 OLE 物件的實際影像取代。

![OLE object preview](OLE_object_preview.png)

現在，您可能想要儲存簡報，以確保 OLE 物件的影像正確更新。如此一來，在儲存簡報後再次開啟時，您將不會看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

### **解決方案 1：以影像取代「Embedded OLE Object」訊息**

如果您不想透過在 PowerPoint 中開啟簡報後再儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以將該訊息替換為您偏好的預覽影像。以下程式碼行示範了此過程：

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # 新增影像至簡報資源。
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # 設定 OLE 物件預覽的標題與影像。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

包含 `OleObjectFrame` 的投影片隨即變更為以下圖示：

![New OLE object image](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 建立外掛程式**

您也可以為 Microsoft PowerPoint 建立外掛程式，以在程式中開啟簡報時更新所有 OLE 物件。