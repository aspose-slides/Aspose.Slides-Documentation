---
title: ActiveX
type: docs
weight: 200
url: /th/java/examples/elements/activex/
keywords:
- ตัวอย่างโค้ด
- ActiveX
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ดูตัวอย่าง ActiveX ของ Aspose.Slides for Java: แทรก, กำหนดค่า และควบคุมวัตถุ ActiveX ในงานนำเสนอ PPT และ PPTX ด้วยโค้ด Java ที่ชัดเจน"
---
บทความนี้สาธิตวิธีการเพิ่ม, เข้าถึง, ลบและกำหนดค่า ActiveX controls ในงานนำเสนอด้วย **Aspose.Slides for Java**.

## **เพิ่ม ActiveX Control**

แทรก ActiveX control ใหม่และกำหนดค่าคุณสมบัติตามต้องการ.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // เพิ่ม ActiveX control ใหม่.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // ตั้งค่าบางคุณสมบัติตามต้องการ.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึง ActiveX Control**

อ่านข้อมูลจาก ActiveX control ตัวแรกบนสไลด์.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // เข้าถึง ActiveX control ตัวแรก.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบ ActiveX Control**

ลบ ActiveX control ที่มีอยู่จากสไลด์.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // ลบ ActiveX control ตัวแรก.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่า ActiveX Properties**

เพิ่ม control และกำหนดค่า ActiveX properties หลายอย่าง.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // เพิ่มคอนโทรล Windows Media Player และกำหนดค่าคุณสมบัติ.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```