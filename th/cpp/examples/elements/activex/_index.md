---
title: ActiveX
type: docs
weight: 200
url: /th/cpp/examples/elements/activex/
keywords:
- ตัวอย่างโค้ด
- ActiveX
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ดูตัวอย่าง ActiveX ของ Aspose.Slides for C++: แทรก, กำหนดค่า, และควบคุมวัตถุ ActiveX ในงานนำเสนอ PPT และ PPTX ด้วยโค้ด C++ ที่ชัดเจน"
---
บทความนี้แสดงวิธีเพิ่ม, เข้าถึง, ลบ และกำหนดค่า ActiveX control ในงานนำเสนอโดยใช้ **Aspose.Slides for C++**.

## **Add an ActiveX Control**
แทรก ActiveX control ใหม่และกำหนดคุณสมบัติตามต้องการ.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่ม ActiveX control ใหม่.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // ตั้งค่าบางคุณสมบัติตามต้องการ.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Access an ActiveX Control**
อ่านข้อมูลจาก ActiveX control แรกบนสไลด์.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // เข้าถึง ActiveX control ตัวแรก.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Remove an ActiveX Control**
ลบ ActiveX control ที่มีอยู่จากสไลด์.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // ลบ ActiveX control ตัวแรก.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Set ActiveX Properties**
เพิ่ม control และกำหนดค่าคุณสมบัติหลายอย่างของ ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มคอนโทรล Windows Media Player และกำหนดคุณสมบัติ.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```