---
title: 在加入 OleObjectFrame 時的物件預覽問題
linktitle: OLE 物件問題
type: docs
weight: 10
url: /zh-hant/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 預覽問題
- 嵌入物件
- 嵌入檔案
- 物件已變更
- 物件預覽
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解在 Aspose.Slides for PHP 中加入 OleObjectFrame 時為何會出現 EMBEDDED OLE OBJECT，以及如何修復 PPT、PPTX 與 ODP 簡報中的預覽問題。"
---
## **簡介**

使用 Aspose.Slides for PHP via Java 時，當您將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 新增至投影片，輸出投影片上會顯示「EMBEDDED OLE OBJECT」訊息。此訊息是有意的，且不是錯誤。

如需有關 OLE 物件的更多資訊，請參閱 [Manage OLE](/slides/zh-hant/php-java/manage-ole/)。

## **說明與解決方案**

Aspose.Slides 會顯示「EMBEDDED OLE OBJECT」訊息，以通知您 OLE 物件已被變更，且必須更新預覽圖片。

例如，若將 Microsoft Excel 圖表作為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/oleobjectframe/) 新增至投影片 (欲了解更多細節，請參閱「Manage OLE」文章)，然後在 Microsoft PowerPoint 中開啟簡報，您會在投影片上看到此圖像：

![OLE object message](OLE_object_message.png)

如果您想檢查並確認 OLE 物件已被新增至投影片，必須對「EMBEDDED OLE OBJECT」訊息進行雙擊，或右鍵點選該訊息並選取 **Object > Edit** 選項。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 隨即開啟嵌入的 OLE 物件。

![OLE object data](OLE_object_data.png)

投影片可能仍保留「EMBEDDED OLE OBJECT」訊息。當您點選 OLE 物件後，投影片的預覽會更新，「EMBEDDED OLE OBJECT」訊息將被 OLE 物件的實際圖像取代。

![OLE object preview](OLE_object_preview.png)

現在，您可能想要儲存簡報，以確保 OLE 物件的圖像正確更新。這樣，在儲存簡報後再次開啟時，您將不會再看到「EMBEDDED OLE OBJECT」訊息。

## **其他解決方案**

### **解決方案 1：將 "Embedded OLE Object" 訊息取代為圖像**

如果您不想透過在 PowerPoint 開啟簡報後再儲存的方式移除「EMBEDDED OLE OBJECT」訊息，您可以將該訊息取代為您偏好的預覽圖像。以下程式碼說明了此過程：

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // 新增圖像至簡報資源。
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // 設定 OLE 物件預覽的標題與圖像。
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

包含 `OleObjectFrame` 的投影片隨後會變更為如下：

![New OLE object image](OLE_object_new_image.png)

### **解決方案 2：為 PowerPoint 建立外掛程式**

您亦可為 Microsoft PowerPoint 建立外掛程式，於開啟簡報時自動更新所有 OLE 物件。