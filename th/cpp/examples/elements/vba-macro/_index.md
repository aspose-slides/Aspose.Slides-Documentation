---
title: แมโคร VBA
type: docs
weight: 150
url: /th/cpp/examples/elements/vba-macro/
keywords:
- ตัวอย่างโค้ด
- VBA
- แมโคร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "อัตโนมัติการสร้างงานนำเสนอด้วย Aspose.Slides for C++: สร้าง, รัน, นำเข้าและปกป้องแมโคร VBA ใน PPT, PPTX และ ODP ด้วยตัวอย่าง C++ ที่ชัดเจน"
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง และลบแมโคร VBA ด้วย **Aspose.Slides for C++**.

## **Add a VBA Macro**
เพิ่มแมโคร VBA

Create a presentation with a VBA project and a simple macro module.
สร้างงานนำเสนอที่มีโปรเจ็กต์ VBA และโมดูลแมโครง่ายๆ

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **Access a VBA Macro**
เข้าถึงแมโคร VBA

Retrieve the first module from the VBA project.
ดึงโมดูลแรกจากโปรเจ็กต์ VBA

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **Remove a VBA Macro**
ลบแมโคร VBA

Delete a module from the VBA project.
ลบโมดูลจากโปรเจ็กต์ VBA

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```