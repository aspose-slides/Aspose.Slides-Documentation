---
title: SmartArt
type: docs
weight: 140
url: /zh-hant/php-java/examples/elements/smartart/
keywords:
- SmartArt
- 新增 SmartArt
- 存取 SmartArt
- 移除 SmartArt
- SmartArt 版面配置
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中建立與編輯 SmartArt：新增節點、變更版面配置與樣式、精確轉換為圖形，並匯出為 PPT、PPTX 與 ODP。"
---
示範如何使用 **Aspose.Slides for PHP via Java** 新增 SmartArt 圖形、存取它們、移除它們，並變更版面配置。

## **新增 SmartArt**

使用內建版面配置插入 SmartArt 圖形。

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取 SmartArt**

取得投影片上的第一個 SmartArt 物件。

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 取得投影片上第一個 SmartArt。
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **移除 SmartArt**

從投影片中刪除 SmartArt 形狀。

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個圖形是 SmartArt。
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **變更 SmartArt 版面配置**

更新現有 SmartArt 圖形的版面配置類型。

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個圖形是 SmartArt。
        $smartArt = $slide->getShapes()->get_Item(0);

        // 變更 SmartArt 的版面配置。
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```