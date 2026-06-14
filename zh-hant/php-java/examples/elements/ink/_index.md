---
title: 墨跡
type: docs
weight: 180
url: /zh-hant/php-java/examples/elements/ink/
keywords:
- 墨跡
- 存取墨跡
- 移除墨跡
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 處理投影片上的數位墨跡：新增筆劃、編輯路徑、設定顏色與寬度，並將結果匯出為 PowerPoint 和 OpenDocument。"
---
提供使用 **Aspose.Slides for PHP via Java** 存取現有墨跡形狀並將其移除的範例。

> ❗ **注意：** 墨跡形狀代表來自特殊裝置的使用者輸入。Aspose.Slides 無法以程式方式建立新的墨跡筆畫，但您可以讀取並修改現有的墨跡。

## **存取墨跡**

取得投影片上的第一個墨跡形狀。

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取投影片上的第一個墨跡形狀。
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **移除墨跡**

從投影片中刪除墨跡形狀。

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個形狀是墨跡形狀。
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```