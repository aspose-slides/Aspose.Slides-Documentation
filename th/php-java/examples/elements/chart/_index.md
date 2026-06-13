---
title: แผนภูมิ
type: docs
weight: 60
url: /th/php-java/examples/elements/chart/
keywords:
- แผนภูมิ
- เพิ่มแผนภูมิ
- เข้าถึงแผนภูมิ
- ลบแผนภูมิ
- อัปเดตแผนภูมิ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิใน PHP ด้วย Aspose.Slides: เพิ่มข้อมูล, จัดรูปแบบซีรีส์, แกนและป้ายกำกับ, เปลี่ยนประเภท, และส่งออก—ทำงานได้กับ PPT, PPTX และ ODP."
---
ตัวอย่างการเพิ่ม, เข้าถึง, ลบ, และอัปเดตประเภทแผนภูมิต่างๆ ด้วย **Aspose.Slides for PHP via Java**. โค้ดตัวอย่างด้านล่างแสดงการดำเนินการพื้นฐานกับแผนภูมิ

## **เพิ่มแผนภูมิ**

วิธีนี้จะเพิ่มแผนภูมิแบบพื้นที่ง่ายๆ ไปยังสไลด์แรก

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เพิ่มแผนภูมิคอลัมน์แบบง่ายลงในสไลด์.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงแผนภูมิ**

ดึงแผนภูมิออกจากคอลเลกชันรูปทรง

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงแผนภูมิแรกบนสไลด์.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบแผนภูมิ**

โค้ดต่อไปนี้จะลบแผนภูมิออกจากสไลด์

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์คือแผนภูมิ.
        $chart = $slide->getShapes()->get_Item(0);

        // ลบแผนภูมิ.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **อัปเดตข้อมูลแผนภูมิ**

คุณสามารถเปลี่ยนแปลงคุณสมบัติของแผนภูมิ เช่น ชื่อเรื่อง

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์คือแผนภูมิ.
        $chart = $slide->getShapes()->get_Item(0);

        // เปลี่ยนชื่อเรื่องของแผนภูมิ.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```