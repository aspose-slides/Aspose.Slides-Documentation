---
title: ActiveX
type: docs
weight: 200
url: /th/net/examples/elements/activex/
keywords:
- ActiveX
- เพิ่ม ActiveX
- เข้าถึง ActiveX
- ลบ ActiveX
- คุณสมบัติของ ActiveX
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ดูตัวอย่าง ActiveX ของ Aspose.Slides for .NET: แทรก, กำหนดค่า และควบคุมวัตถุ ActiveX ในการนำเสนอ PPT และ PPTX ด้วยโค้ด C# ที่ชัดเจน."
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง, ลบ และกำหนดค่าคอนโทรล ActiveX ในการนำเสนอโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มคอนโทรล ActiveX**

แทรกคอนโทรล ActiveX ใหม่และตั้งค่าคุณสมบัติตามต้องการ.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // เพิ่มคอนโทรล ActiveX ใหม่.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // ตั้งค่าบางคุณสมบัติตามต้องการ.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **เข้าถึงคอนโทรล ActiveX**

อ่านข้อมูลจากคอนโทรล ActiveX ตัวแรกบนสไลด์.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // เข้าถึงคอนโทรล ActiveX ตัวแรก.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **ลบคอนโทรล ActiveX**

ลบคอนโทรล ActiveX ที่มีอยู่จากสไลด์.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // ลบคอนโทรล ActiveX ตัวแรก.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ตั้งค่าคุณสมบัติของ ActiveX**

เพิ่มคอนโทรลและกำหนดค่าคุณสมบัติคอนโทรล ActiveX หลายรายการ.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // เพิ่ม CommandButton และกำหนดค่าคุณสมบัติ.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```