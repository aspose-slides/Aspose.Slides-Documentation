---
title: 章节
type: docs
weight: 90
url: /zh/php-java/examples/elements/section/
keywords:
- 章节
- 幻灯片章节
- 添加章节
- 访问章节
- 删除章节
- 重命名章节
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中管理幻灯片章节：轻松创建、重命名、重新排序，移动幻灯片到不同章节，并控制 PPT、PPTX 和 ODP 的可见性。"
---
示例演示使用 **Aspose.Slides for PHP via Java** 以编程方式管理演示文稿章节——添加、访问、删除和重命名。

## **添加章节**

创建一个从特定幻灯片开始的章节。

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 指定标记章节开始的幻灯片。
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **访问章节**

从演示文稿中读取章节信息。

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // 通过索引访问章节。
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **删除章节**

删除先前添加的章节。

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // 移除章节。
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **重命名章节**

更改现有章节的名称。

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