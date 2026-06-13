---
title: ตาราง
type: docs
weight: 120
url: /th/cpp/examples/elements/table/
keywords:
- ตัวอย่างโค้ด
- ตาราง
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานกับตารางใน Aspose.Slides for C++: สร้าง, จัดรูปแบบ, รวมเซลล์, ใช้สไตล์, นำเข้าข้อมูล, และส่งออกพร้อมตัวอย่าง C++ สำหรับ PPT, PPTX และ ODP."
---
ตัวอย่างการเพิ่มตาราง, การเข้าถึงตาราง, การลบตาราง, และการรวมเซลล์โดยใช้ **Aspose.Slides for C++**.

## **เพิ่มตาราง**

สร้างตารางง่าย ๆ ที่มีสองแถวและสองคอลัมน์.

```cpp
static void AddTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    presentation->Dispose();
}
```

## **เข้าถึงตาราง**

ดึงรูปแบบตารางแรกบนสไลด์.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // เข้าถึงตารางแรกบนสไลด์.
    auto firstTable = SharedPtr<ITable>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            firstTable = ExplicitCast<ITable>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบตาราง**

ลบตารางจากสไลด์.

```cpp
static void RemoveTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    slide->get_Shapes()->Remove(table);

    presentation->Dispose();
}
```

## **รวมเซลล์ตาราง**

รวมเซลล์ที่อยู่ติดกันของตารางให้เป็นเซลล์เดียว.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // รวมเซลล์.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```