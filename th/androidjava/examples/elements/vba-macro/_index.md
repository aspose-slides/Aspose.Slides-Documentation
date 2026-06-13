---
title: แมโคร VBA
type: docs
weight: 150
url: /th/androidjava/examples/elements/vba-macro/
keywords:
- ตัวอย่างโค้ด
- VBA
- มาโคร
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "อัตโนมัติกระบวนการนำเสนอด้วย Aspose.Slides for Android: สร้าง, รัน, นำเข้า และปกป้องแมโคร VBA ในไฟล์ PPT, PPTX, และ ODP ด้วยตัวอย่าง Java ที่ชัดเจน"
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง, และลบแมโคร VBA โดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มแมโคร VBA**

สร้างงานนำเสนอพร้อมกับโปรเจกต์ VBA และโมดูลแมโครแบบง่าย

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงแมโคร VBA**

ดึงโมดูลแรกจากโปรเจกต์ VBA

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบแมโคร VBA**

ลบโมดูลจากโปรเจกต์ VBA

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```