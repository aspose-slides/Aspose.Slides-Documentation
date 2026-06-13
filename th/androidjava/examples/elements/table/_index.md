---
title: ตาราง
type: docs
weight: 120
url: /th/androidjava/examples/elements/table/
keywords:
- ตัวอย่างโค้ด
- ตาราง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำงานกับตารางใน Aspose.Slides for Android: สร้าง, จัดรูปแบบ, รวมเซลล์, ใช้สไตล์, นำเข้าข้อมูล, และส่งออกด้วยตัวอย่าง Java สำหรับ PPT, PPTX, และ ODP."
---
ตัวอย่างการเพิ่มตาราง, การเข้าถึงตาราง, การลบตาราง, และการรวมเซลล์โดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มตาราง**

สร้างตารางแบบง่ายที่มีสองแถวและสองคอลัมน์.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงตาราง**

ดึงรูปร่างตารางแรกบนสไลด์.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // เข้าถึงตารางแรกบนสไลด์.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบตาราง**

ลบตารางออกจากสไลด์.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **รวมเซลล์ตาราง**

รวมเซลล์ที่อยู่ติดกันของตารางให้เป็นเซลล์เดียว.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // รวมเซลล์.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```