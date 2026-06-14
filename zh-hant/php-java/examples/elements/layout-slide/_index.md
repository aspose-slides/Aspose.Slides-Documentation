---
title: 版面投影片
type: docs
weight: 20
url: /zh-hant/php-java/examples/elements/layout-slide/
keywords:
- 版面投影片
- 新增版面投影片
- 存取版面投影片
- 移除版面投影片
- 未使用的版面投影片
- 複製版面投影片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 PHP 搭配 Aspose.Slides 來管理版面投影片：在 PPT、PPTX 與 ODP 簡報中建立、套用、複製、重新命名及自訂佔位符與主題。"
---
本文示範如何在 Aspose.Slides for PHP via Java 中使用 **Layout Slides**。版面投影片定義了普通投影片所繼承的設計與格式。您可以新增、存取、複製與移除版面投影片，亦可清除未使用的版面以減少簡報檔案大小。

## **Add a Layout Slide**

您可以建立自訂版面投影片以定義可重複使用的格式。例如，您可以新增一個文字方塊，使所有使用此版面的投影片皆顯示該文字方塊。

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // 建立一個使用空白版面類型且具有自訂名稱的版面投影片。
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** 版面投影片充當個別投影片的模板。您只需定義一次共用元素，便可在多張投影片中重複使用。  
> 💡 **Tip 2:** 當您在版面投影片上新增形狀或文字時，所有基於該版面的投影片都會自動顯示此共用內容。  
> 以下的螢幕截圖顯示兩張投影片，各自繼承自同一版面的文字方塊。

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 依索引存取。
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // 依版面類型存取。
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Layout Slide**

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 依類型取得版面投影片並將其移除。
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove Unused Layout Slides**

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 自動移除所有未被任何投影片參照的版面投影片。
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clone a Layout Slide**

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 依類型取得現有的版面投影片。
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // 複製版面投影片至版面投影片集合的末端。
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Summary:** 版面投影片是管理投影片間一致格式的強大工具。Aspose.Slides 提供完整的建立、管理與最佳化版面投影片的控制權。