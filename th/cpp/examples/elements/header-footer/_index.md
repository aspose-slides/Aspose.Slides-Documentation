---
title: ส่วนหัวและส่วนท้าย
type: docs
weight: 220
url: /th/cpp/examples/elements/header-footer/
keywords:
- ตัวอย่างโค้ด
- ส่วนหัว
- ส่วนท้าย
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนท้ายของสไลด์ด้วย Aspose.Slides for C++: เพิ่มวันที่, หมายเลขสไลด์, และข้อความกำหนดเองในไฟล์ PPT, PPTX, และ ODP ด้วยตัวอย่าง C++."
---
บทความนี้แสดงวิธีการเพิ่มส่วนท้ายและอัปเดตตัวตำแหน่งวันที่และเวลาที่ใช้ **Aspose.Slides for C++**.

## **เพิ่มส่วนท้าย**

เพิ่มข้อความลงในส่วนท้ายของสไลด์และทำให้มองเห็นได้.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **อัปเดตวันที่และเวลา**

แก้ไขตัวตำแหน่งวันที่และเวลาบนสไลด์.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```