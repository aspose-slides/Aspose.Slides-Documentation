---
title: 加入 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解在 Aspose.Slides for Python via Java 中加入 OleObjectFrame 時為何會出現 EMBEDDED OLE OBJECT，以及如何修正 PPT、PPTX 與 ODP 簡報的預覽問題。"
---
## **簡介**

當您使用 Aspose.Slides for Python via Java 將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 新增至投影片時，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息是有意的，並非錯誤。

如需了解有關 OLE 物件的更多資訊，請參閱 [管理 OLE](/slides/zh-hant/python-java/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已變更，必須更新預覽圖像。

例如，若您將 Microsoft Excel 圖表作為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 新增至投影片（請參閱「管理 OLE」文章取得更多細節），然後在 Microsoft PowerPoint 中開啟簡報，您將在投影片上看到此圖像：

![OLE 物件訊息](OLE_object_message.png)

若要確認 OLE 物件已加入投影片，請雙擊「EMBEDDED OLE OBJECT」訊息，或右鍵點選後選擇 **Object > Edit**。

![OLE 物件 > 編輯](OLE_object_edit.png)

PowerPoint 會開啟嵌入的 OLE 物件。

![OLE 物件資料](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點擊 OLE 物件後，投影片預覽會更新，「EMBEDDED OLE OBJECT」訊息會被 OLE 物件的實際圖像取代。

![OLE 物件預覽](OLE_object_preview.png)

儲存您的簡報以保留已更新的 OLE 物件預覽圖像。再次開啟簡報時，將不再看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

如果您不想透過在 PowerPoint 中開啟簡報再儲存來移除「EMBEDDED OLE OBJECT」訊息，您可以使用您偏好的預覽圖像取代該訊息。以下程式碼示範此過程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # 將影像新增至簡報資源。
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # 設定 OLE 物件預覽的標題與影像。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

包含 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 的投影片將變更為以下圖示：

![新 OLE 物件影像](OLE_object_new_image.png)

## **常見問題**

**為何會出現「EMBEDDED OLE OBJECT」訊息？**

此訊息表示 OLE 物件已變更，需要更新其預覽圖像。此行為是有意的。

**如何在 PowerPoint 中更新預覽？**

雙擊訊息或選取 **Object > Edit** 開啟嵌入的 OLE 物件。點擊 OLE 物件以更新預覽，然後儲存簡報。

**是否可以在不開啟 PowerPoint 簡報的情況下取代此訊息？**

可以。您可以如上例所示，為 OLE 物件指派您偏好的預覽圖像。