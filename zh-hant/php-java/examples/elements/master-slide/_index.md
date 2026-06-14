---
title: 母片
type: docs
weight: 30
url: /zh-hant/php-java/examples/elements/master-slide/
keywords:
- 母片
- 新增母片
- 存取母片
- 移除母片
- 未使用的母片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中管理母片：建立、編輯、複製，並格式化主題、背景、佔位符，以統一 PowerPoint 與 OpenDocument 的投影片。"
---
母片在 PowerPoint 的投影片繼承階層中位於最上層。**master slide** 定義背景、標誌和文字格式等共同設計元素。**Layout slides** 繼承自母片，且 **normal slides** 繼承自 Layout slides。

本文示範如何使用 Aspose.Slides for PHP via Java 建立、修改與管理母片。

## **新增母片**

此範例示範如何透過複製預設母片來建立新的母片。

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // 複製預設母片。
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** 母片提供在所有投影片上套用一致品牌或共享設計元素的方式。對母片所做的任何變更都會自動反映在相依的版面母片和普通投影片上。  
> 
> 💡 **Tip 2:** 在母片上加入的任何形狀或格式都會被版面母片繼承，進而被使用該版面的所有普通投影片繼承。下方圖片說明了在母片中加入的文字方塊如何自動顯示在最終投影片上。

![母片繼承範例](master-slide-banner.png)

## **存取母片**

您可以使用 `Presentation::getMasters` 方法存取母片。以下說明如何取得並操作它們：

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 存取第一個母片。
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **移除母片**

母片可以依索引或參考方式移除。

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 依索引移除。
        $presentation->getMasters()->removeAt(0);

        // 或依參考移除。
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **移除未使用的母片**

某些簡報包含未使用的母片。移除這些母片可以協助減少檔案大小。

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // 移除所有未使用的母片（即使已標記為 Preserve）。
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **提示:** 使用 `removeUnused(true)` 來清除未使用的母片，並最小化簡報大小。