---
title: Vba 巨集
type: docs
weight: 150
url: /zh-hant/php-java/examples/elements/vba-macro/
keywords:
- VBA 巨集
- 新增 VBA 巨集
- 存取 VBA 巨集
- 移除 VBA 巨集
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 處理 VBA 巨集：新增或編輯專案與模組、簽署或移除巨集，並將簡報儲存為 PPT、PPTX 或 ODP 格式。"
---
說明如何使用 **Aspose.Slides for PHP via Java** 新增、存取和移除 VBA 巨集。

## **新增 VBA 巨集**

建立一個包含 VBA 專案與簡易巨集模組的簡報。

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取 VBA 巨集**

從 VBA 專案中取得第一個模組。

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **移除 VBA 巨集**

從 VBA 專案中刪除一個模組。

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // 假設 VBA 專案中至少有一個模組。
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```