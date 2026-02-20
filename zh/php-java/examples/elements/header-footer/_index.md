---
title: 页眉页脚
type: docs
weight: 220
url: /zh/php-java/examples/elements/header-footer/
keywords:
- 页眉页脚
- 添加页眉页脚
- 更新页眉页脚
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中控制页眉和页脚：添加或编辑日期/时间、幻灯片编号和页脚文本，在 PPT、PPTX 和 ODP 中显示或隐藏占位符。"
---
展示如何使用 **Aspose.Slides for PHP via Java** 添加页脚并更新日期和时间占位符。

## **添加页脚**

向幻灯片的页脚区域添加文本并使其可见。

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **更新日期和时间**

修改幻灯片上的日期和时间占位符。

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```