---
title: ActiveX
type: docs
weight: 200
url: /zh/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX 控件
- 添加 ActiveX
- 访问 ActiveX
- 删除 ActiveX
- ActiveX 属性
- 代码示例
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中使用 Aspose.Slides 查找、编辑和删除 ActiveX 控件，以及为 PowerPoint 演示文稿更新属性。"
---
演示如何在演示文稿中添加、访问、删除和配置 ActiveX 控件，使用 **Aspose.Slides for PHP via Java**。

## **添加 ActiveX 控件**

插入一个新的 ActiveX 控件。

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 添加新的 ActiveX 控件。
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // 释放演示文稿。
        $presentation->dispose();
    }
}
```

## **访问 ActiveX 控件**

读取幻灯片上第一个 ActiveX 控件的信息。

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问第一个 ActiveX 控件。
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // 释放演示文稿。
        $presentation->dispose();
    }
}
```

## **删除 ActiveX 控件**

从幻灯片中删除现有的 ActiveX 控件。

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // 删除第一个 ActiveX 控件。
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // 释放演示文稿。
        $presentation->dispose();
    }
}
```

## **设置 ActiveX 属性**

配置多个 ActiveX 属性。

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设第一个控件是我们添加的那个。
        $control = $slide->getControls()->get_Item(0);

        // 配置属性。
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // 释放演示文稿。
        $presentation->dispose();
    }
}
```