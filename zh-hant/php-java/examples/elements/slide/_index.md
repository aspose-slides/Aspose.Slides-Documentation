---
title: 投影片
type: docs
weight: 10
url: /zh-hant/php-java/examples/elements/slide/
keywords:
- 投影片
- 新增投影片
- 存取投影片
- 投影片索引
- 複製投影片
- 重新排序投影片
- 移除投影片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中管理投影片：建立、複製、重新排序、隱藏、設定背景與尺寸、套用轉場效果，並匯出為 PowerPoint 和 OpenDocument。"
---
這篇文章提供一系列範例，示範如何使用 **Aspose.Slides for PHP via Java** 來操作投影片。您將學習如何使用 `Presentation` 類別新增、存取、複製、重新排序以及移除投影片。

以下每個範例皆包含簡要說明，接著是 PHP 程式碼片段。

## **新增投影片**

要新增投影片，必須先選取版面配置。本範例使用 `Blank` 版面，並向簡報加入一張空白投影片。

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // 每張投影片基於版面配置，而版面配置本身來源於母片。
        // 使用 Blank 版面配置來建立新投影片。
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // 使用選取的版面配置新增一張空白投影片。
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **提示:** 每個投影片版面皆來源於母片，母片定義了整體設計與版位結構。下圖說明了母片與其相關版面在 PowerPoint 中的組織方式。

![Master and Layout Relationship](master-layout-slide.png)

## **依索引存取投影片**

您可以依索引取得投影片。

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // 依索引存取投影片。
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **複製投影片**

此範例示範如何複製已存在的投影片。複製的投影片會自動加入投影片集合的最後。

```php
function cloneSlide() {
    // 預設情況下，簡報包含一張空白投影片。
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 複製第一張投影片；它會被加入簡報的最後。
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // 複製後的投影片索引為 1（簡報中的第二張投影片）。
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **重新排序投影片**

您可以透過將投影片移動至新索引來變更順序。在此範例中，我們將投影片移至第一個位置。

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // 將投影片移至第一個位置（其他投影片往下移動）。
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **移除投影片**

要移除投影片，只需參考它並呼叫 `remove`。此範例示範依索引與依參考兩種方式移除投影片。

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // 依索引移除投影片。
        $presentation->getSlides()->removeAt(0);

        // 依參考移除投影片。
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```