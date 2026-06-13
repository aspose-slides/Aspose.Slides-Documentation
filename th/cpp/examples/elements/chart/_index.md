---
title: แผนภูมิ
type: docs
weight: 60
url: /th/cpp/examples/elements/chart/
keywords:
- ตัวอย่างโค้ด
- แผนภูมิ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เชี่ยวชาญการสร้างแผนภูมิด้วย Aspose.Slides สำหรับ C++: สร้าง, จัดรูปแบบ, ผูกข้อมูล, และส่งออกแผนภูมิเป็น PPT, PPTX, และ ODP พร้อมตัวอย่าง C++."
---
ตัวอย่างการเพิ่ม, การเข้าถึง, การลบและการอัปเดตประเภทแผนภูมิต่าง ๆ ด้วย **Aspose.Slides for C++**. โค้ดตัวอย่างด้านล่างแสดงการดำเนินการพื้นฐานของแผนภูมิ

## **เพิ่มแผนภูมิ**

เมธอดนี้เพิ่มแผนภูมิพื้นที่แบบง่ายลงในสไลด์แรก

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มแผนภูมิพื้นที่แบบง่ายลงในสไลด์แรก.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **เข้าถึงแผนภูมิ**

หลังจากสร้างแผนภูมิแล้ว คุณสามารถดึงคืนได้ผ่านคอลเลกชันรูปทรง

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // เข้าถึงแผนภูมิแรกบนสไลด์.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบแผนภูมิ**

โค้ดต่อไปนี้จะลบแผนภูมิออกจากสไลด์

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // ลบแผนภูมิ.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **อัปเดตข้อมูลแผนภูมิ**

คุณสามารถเปลี่ยนแปลงคุณสมบัติของแผนภูมิ เช่น ชื่อเรื่อง

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // เปลี่ยนชื่อแผนภูมิ.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```