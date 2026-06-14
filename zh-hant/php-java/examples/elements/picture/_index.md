---
title: 圖片
type: docs
weight: 50
url: /zh-hant/php-java/examples/elements/picture/
keywords:
- 圖片
- 圖框
- 新增圖片
- 取得圖片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 處理圖片：插入、取代、裁切、壓縮、調整透明度與效果、填充形狀，並匯出為 PPT、PPTX 與 ODP。"
---
顯示如何使用 **Aspose.Slides for PHP via Java** 插入和存取圖片。以下範例會在投影片上放置影像，然後取得它。

## **新增圖片**

此程式碼將影像作為圖片框插入第一張投影片。

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // 將影像新增至簡報資源。
        // 在第一張投影片上插入顯示影像的圖片框。
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取圖片**

此範例確保投影片中有圖片框，然後存取它所找到的第一個圖片框。

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取投影片上的第一個 PictureFrame。
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```