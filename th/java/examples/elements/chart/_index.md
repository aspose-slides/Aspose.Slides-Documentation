---
title: แผนภูมิ
type: docs
weight: 60
url: /th/java/examples/elements/chart/
keywords:
- ตัวอย่างโค้ด
- แผนภูมิ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เชี่ยวชาญการทำแผนภูมิด้วย Aspose.Slides for Java: สร้าง, จัดรูปแบบ, ผูกข้อมูล, และส่งออกแผนภูมิในรูปแบบ PPT, PPTX, และ ODP ด้วยตัวอย่าง Java."
---
ตัวอย่างสำหรับการเพิ่ม, การเข้าถึง, การลบ, และการอัปเดตประเภทแผนภูมิต่าง ๆ ด้วย **Aspose.Slides for Java**. โค้ดตัวอย่างด้านล่างแสดงการดำเนินการพื้นฐานของแผนภูมิ

## **เพิ่มแผนภูมิ**

เมธอดนี้จะเพิ่มแผนภูมิพื้นที่แบบง่ายลงในสไลด์แรก.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // เพิ่มแผนภูมิพื้นที่แบบง่ายลงในสไลด์แรก.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงแผนภูมิ**

หลังจากสร้างแผนภูมิแล้ว คุณสามารถเรียกคืนได้ผ่านคอลเลกชันรูปทรง.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // เข้าถึงแผนภูมิแรกบนสไลด์.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบแผนภูมิ**

โค้ดต่อไปนี้จะลบแผนภูมิออกจากสไลด์.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // ลบแผนภูมิ.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตข้อมูลแผนภูมิ**

คุณสามารถเปลี่ยนแปลงคุณสมบัติของแผนภูมิ เช่น ชื่อเรื่อง.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // เปลี่ยนชื่อแผนภูมิ.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```