---
title: Vba宏
type: docs
weight: 150
url: /zh/php-java/examples/elements/vba-macro/
keywords:
- vba 宏
- 添加 vba 宏
- 访问 vba 宏
- 删除 vba 宏
- 代码 示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 处理 VBA 宏：添加或编辑项目和模块，签署或删除宏，并将演示文稿保存为 PPT、PPTX 和 ODP。"
---
演示如何使用 **Aspose.Slides for PHP via Java** 添加、访问和删除 VBA 宏。

## **添加 VBA 宏**

创建一个包含 VBA 项目和简单宏模块的演示文稿。

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

## **访问 VBA 宏**

检索 VBA 项目中的第一个模块。

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

## **删除 VBA 宏**

从 VBA 项目中删除一个模块。

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // 假设 VBA 项目中至少有一个模块。
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```