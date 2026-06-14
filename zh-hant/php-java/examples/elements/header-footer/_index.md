---
title: 頁首頁腳
type: docs
weight: 220
url: /zh-hant/php-java/examples/elements/header-footer/
keywords:
- 頁首頁腳
- 新增頁首頁腳
- 更新頁首頁腳
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 控制頁首與頁腳：新增或編輯日期/時間、投影片編號與頁腳文字，顯示或隱藏 PPT、PPTX 和 ODP 中的佔位符。"
---
顯示如何使用 **Aspose.Slides for PHP via Java** 新增頁腳並更新日期與時間佔位符。

## **新增頁腳**
在投影片的頁腳區域加入文字並使其可見。

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

## **更新日期與時間**
修改投影片上的日期與時間佔位符。

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