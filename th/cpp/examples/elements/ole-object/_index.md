---
title: อ็อบเจกต์ OLE
type: docs
weight: 210
url: /th/cpp/examples/elements/ole-object/
keywords:
- ตัวอย่างโค้ด
- อ็อบเจกต์ OLE
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการอ็อบเจกต์ OLE ใน Aspose.Slides for C++: แทรก, เชื่อมโยง, อัปเดตและดึงข้อมูลที่ฝังไว้ด้วย C++ สำหรับการนำเสนอในรูปแบบ PPT, PPTX และ ODP"
---
บทความนี้แสดงการฝังไฟล์เป็นอ็อบเจกต์ OLE และอัปเดตข้อมูลของมันโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มอ็อบเจกต์ OLE**

ฝังไฟล์ PDF ลงในงานนำเสนอ.

```cpp
static void AddOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    presentation->Dispose();
}
```

## **เข้าถึงอ็อบเจกต์ OLE**

ดึงเฟรมอ็อบเจกต์ OLE ตัวแรกบนสไลด์.

```cpp
static void AccessOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto firstOleFrame = SharedPtr<IOleObjectFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IOleObjectFrame>(shape))
        {
            firstOleFrame = ExplicitCast<IOleObjectFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบอ็อบเจกต์ OLE**

ลบอ็อบเจกต์ OLE ที่ฝังอยู่จากสไลด์.

```cpp
static void RemoveOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide->get_Shapes()->Remove(oleFrame);

    presentation->Dispose();
}
```

## **อัปเดตข้อมูลอ็อบเจกต์ OLE**

แทนที่ข้อมูลที่ฝังอยู่ในอ็อบเจกต์ OLE ที่มีอยู่.

```cpp
static void UpdateOleObjectData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto newData = File::ReadAllBytes(u"Picture.png");
    auto newDataInfo = MakeObject<OleEmbeddedDataInfo>(newData, u"png");
    oleFrame->SetEmbeddedData(newDataInfo);

    presentation->Dispose();
}
```