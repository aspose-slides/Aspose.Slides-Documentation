---
title: แมโคร VBA
type: docs
weight: 150
url: /th/net/examples/elements/vba-macro/
keywords:
- แมโคร VBA
- เพิ่มแมโคร VBA
- เข้าถึงแมโคร VBA
- ลบแมโคร VBA
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "อัตโนมัติงานนำเสนอด้วย Aspose.Slides สำหรับ .NET: สร้าง, เรียกใช้, นำเข้า และปกป้องแมโคร VBA ในไฟล์ PPT, PPTX และ ODP ด้วยตัวอย่าง C# ที่ชัดเจน"
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง และลบแมโคร VBA ด้วย **Aspose.Slides for .NET**.

## **เพิ่มแมโคร VBA**

สร้างงานนำเสนอที่มีโครงการ VBA และโมดูลแมโครอย่างง่าย

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **เข้าถึงแมโคร VBA**

ดึงโมดูลแรกจากโครงการ VBA

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **ลบแมโคร VBA**

ลบโมดูลจากโครงการ VBA

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```