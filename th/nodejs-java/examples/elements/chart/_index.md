---
title: แผนภูมิ
type: docs
weight: 60
url: /th/nodejs-java/examples/elements/chart/
keywords:
- ตัวอย่างโค้ด
- แผนภูมิ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมแผนภูมิด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java: สร้าง, จัดรูปแบบ, ผูกข้อมูล, และส่งออกแผนภูมิในรูปแบบ PPT, PPTX, และ ODP พร้อมตัวอย่าง JavaScript."
---
ตัวอย่างการเพิ่ม, เข้าถึง, การลบและการอัปเดตประเภทแผนภูมิต่าง ๆ ด้วย **Aspose.Slides for Node.js via Java**. โค้ดตัวอย่างด้านล่างแสดงการดำเนินการพื้นฐานกับแผนภูมิ

## **เพิ่มแผนภูมิ**

เมธอดนี้เพิ่มแผนภูมิแบบพื้นที่ง่าย ๆ ไปยังสไลด์แรก

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เพิ่มแผนภูมิแบบพื้นที่ง่าย ๆ ไปยังสไลด์แรก.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงแผนภูมิ**

หลังจากสร้างแผนภูมิ คุณสามารถดึงคืนได้ผ่านคอลเลกชันรูปทรง

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงแผนภูมิแรกบนสไลด์.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบแผนภูมิ**

โค้ดต่อไปนี้จะลบแผนภูมิออกจากสไลด์

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ลบแผนภูมิ.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตข้อมูลแผนภูมิ**

คุณสามารถเปลี่ยนแปลงคุณสมบัติของแผนภูมิ เช่น ชื่อเรื่อง

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // เปลี่ยนชื่อแผนภูมิ.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```