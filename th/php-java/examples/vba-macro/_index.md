---
title: แมโคร VBA
type: docs
weight: 150
url: /th/php-java/examples/elements/vba-macro/
keywords:
- แมโคร VBA
- เพิ่มแมโคร VBA
- เข้าถึงแมโคร VBA
- ลบแมโคร VBA
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ทำงานกับแมโคร VBA ใน PHP ด้วย Aspose.Slides: เพิ่มหรือแก้ไขโครงการและโมดูล, ลงลายมือชื่อหรือลบแมโคร, และบันทึกงานนำเสนอเป็น PPT, PPTX และ ODP."
---
อธิบายวิธีการเพิ่ม, เข้าถึงและลบมาโคร VBA ด้วย **Aspose.Slides for PHP via Java**.

## **เพิ่มมาโคร VBA**

สร้างงานนำเสนอพร้อมโครงการ VBA และโมดูลมาโครแบบง่าย.

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

## **เข้าถึงมาโคร VBA**

ดึงโมดูลแรกจากโครงการ VBA.

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

## **ลบมาโคร VBA**

ลบโมดูลจากโครงการ VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // สมมติว่ามีอย่างน้อยหนึ่งโมดูลในโครงการ VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```