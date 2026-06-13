---
title: ActiveX
type: docs
weight: 200
url: /th/php-java/examples/elements/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- เพิ่ม ActiveX
- เข้าถึง ActiveX
- ลบ ActiveX
- คุณสมบัติ ActiveX
- ตัวอย่างโค้ด
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีค้นหา, แก้ไขและลบคอนโทรล ActiveX ใน PHP ด้วย Aspose.Slides รวมถึงการอัปเดตคุณสมบัติสำหรับการนำเสนอ PowerPoint"
---
สาธิตวิธีเพิ่ม, เข้าถึง, ลบและกำหนดค่า ActiveX control ในการนำเสนอโดยใช้ **Aspose.Slides for PHP via Java**.

## **Add an ActiveX Control**
เพิ่ม ActiveX Control

Insert a new ActiveX control.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เพิ่มคอนโทรล ActiveX ใหม่.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // ทำลายการนำเสนอ.
        $presentation->dispose();
    }
}
```

## **Access an ActiveX Control**
เข้าถึง ActiveX Control

Read information from the first ActiveX control on the slide.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงคอนโทรล ActiveX ตัวแรก.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // ทำลายการนำเสนอ.
        $presentation->dispose();
    }
}
```

## **Remove an ActiveX Control**
ลบ ActiveX Control

Delete an existing ActiveX control from the slide.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // ลบคอนโทรล ActiveX ตัวแรก.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // ทำลายการนำเสนอ.
        $presentation->dispose();
    }
}
```

## **Set ActiveX Properties**
ตั้งค่า ActiveX Properties

Configure several ActiveX properties.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่าคอนโทรลแรกเป็นคอนโทรลที่เราเพิ่มไว้.
        $control = $slide->getControls()->get_Item(0);

        // กำหนดคุณสมบัติ.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // ทำลายการนำเสนอ.
        $presentation->dispose();
    }
}
```