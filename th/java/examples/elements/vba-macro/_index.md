---
title: มาโคร VBA
type: docs
weight: 150
url: /th/java/examples/elements/vba-macro/
keywords:
- ตัวอย่างโค้ด
- VBA
- มาโคร
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทำให้การนำเสนอเป็นอัตโนมัติด้วย Aspose.Slides for Java: สร้าง, รัน, นำเข้า และปกป้องมาโคร VBA ใน PPT, PPTX, และ ODP ด้วยตัวอย่าง Java ที่ชัดเจน"
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง และลบมาโคร VBA โดยใช้ **Aspose.Slides for Java**.

## **เพิ่มมาโคร VBA**

สร้างงานนำเสนอที่มีโครงการ VBA และโมดูลมาโครแบบง่าย

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

## **เข้าถึงมาโคร VBA**

ดึงโมดูลแรกจากโครงการ VBA

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

## **ลบมาโคร VBA**

ลบโมดูลออกจากโครงการ VBA

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