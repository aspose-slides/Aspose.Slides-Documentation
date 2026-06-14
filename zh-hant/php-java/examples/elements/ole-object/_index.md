---
title: OLE 物件
type: docs
weight: 210
url: /zh-hant/php-java/examples/elements/ole-object/
keywords:
- OLE 物件
- 新增 OLE 物件
- 存取 OLE 物件
- 移除 OLE 物件
- 更新 OLE 物件
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中操作 OLE 物件：插入或更新嵌入的檔案、設定圖示或連結、擷取內容，並控制 PPT、PPTX 與 ODP 的行為。"
---
示範如何將檔案嵌入為 OLE 物件，並使用 **Aspose.Slides for PHP via Java** 更新其資料。

## **加入 OLE 物件**

將 PDF 檔案嵌入簡報中。

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取 OLE 物件**

取得投影片上第一個 OLE 物件框架。

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取投影片上的第一個 OLE 框架。
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **移除 OLE 物件**

從投影片中刪除已嵌入的 OLE 物件。

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個圖形就是 OLE 框架。
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **更新 OLE 物件資料**

取代已存在 OLE 物件中嵌入的資料。

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個圖形就是 OLE 框架。
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```