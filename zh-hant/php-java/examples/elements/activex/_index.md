---
title: ActiveX
type: docs
weight: 200
url: /zh-hant/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 新增 ActiveX
- 存取 ActiveX
- 移除 ActiveX
- ActiveX 屬性
- 程式碼範例
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中使用 Aspose.Slides 查找、編輯和移除 ActiveX 控制項，以及在 PowerPoint 簡報中更新屬性。"
---
示範如何在簡報中使用 **Aspose.Slides for PHP via Java** 新增、存取、移除及設定 ActiveX 控制項。

## **新增 ActiveX 控制項**

插入新的 ActiveX 控制項。

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 新增 ActiveX 控制項.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // 釋放簡報.
        $presentation->dispose();
    }
}
```

## **存取 ActiveX 控制項**

讀取投影片上第一個 ActiveX 控制項的資訊。

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取第一個 ActiveX 控制項.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // 釋放簡報.
        $presentation->dispose();
    }
}
```

## **移除 ActiveX 控制項**

從投影片中刪除現有的 ActiveX 控制項。

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // 移除第一個 ActiveX 控制項.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // 釋放簡報.
        $presentation->dispose();
    }
}
```

## **設定 ActiveX 屬性**

設定多個 ActiveX 屬性。

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設第一個控制項是我們新增的那個。
        $control = $slide->getControls()->get_Item(0);

        // 設定屬性。
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // 釋放簡報。
        $presentation->dispose();
    }
}
```