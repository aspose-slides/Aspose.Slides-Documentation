---
title: 節
type: docs
weight: 90
url: /zh-hant/php-java/examples/elements/section/
keywords:
- 節
- 投影片節
- 新增節
- 存取節
- 移除節
- 重新命名節
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 管理投影片節：輕鬆建立、重新命名、重新排序、在節之間移動投影片，並控制 PPT、PPTX 與 ODP 的可見性。"
---
範例說明如何以程式方式使用 **Aspose.Slides for PHP via Java** 管理投影片簡報的節——新增、存取、移除與重新命名它們。

## **新增節**

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 指定標示此節開始的投影片。
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取節**

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // 依索引存取節。
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **移除節**

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // 移除節。
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **重新命名節**

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```