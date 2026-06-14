---
title: "Macro VBA"
type: docs
weight: 150
url: /vi/php-java/examples/elements/vba-macro/
keywords:
- "macro vba"
- "thêm macro vba"
- "truy cập macro vba"
- "xóa macro vba"
- "ví dụ mã"
- PowerPoint
- OpenDocument
- "bản trình chiếu"
- PHP
- Aspose.Slides
description: "Làm việc với macro VBA trong PHP bằng Aspose.Slides: thêm hoặc chỉnh sửa dự án và mô-đun, ký hoặc xóa macro, và lưu bản trình chiếu dưới dạng PPT, PPTX và ODP."
---
Minh họa cách thêm, truy cập và xóa macro VBA bằng **Aspose.Slides for PHP via Java**.

## **Thêm macro VBA**

Tạo một bản trình chiếu có dự án VBA và một mô-đun macro đơn giản.

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

## **Truy cập macro VBA**

Lấy mô-đun đầu tiên từ dự án VBA.

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

## **Xóa macro VBA**

Xóa một mô-đun khỏi dự án VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Giả sử có ít nhất một mô-đun trong dự án VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```