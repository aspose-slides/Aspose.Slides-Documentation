---
title: ActiveX
type: docs
weight: 200
url: /ar/net/examples/elements/activex/
keywords:
- مثال ActiveX
- تحكم ActiveX
- إضافة ActiveX
- الوصول إلى ActiveX
- إزالة ActiveX
- خصائص ActiveX
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية العثور على عناصر تحكم ActiveX وتعديلها وإزالتها في C# باستخدام Aspose.Slides، بما في ذلك تحديث الخصائص لعروض PowerPoint التقديمية."
---

يوضح كيفية إضافة والوصول وإزالة وتكوين عناصر التحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for .NET**.

## **إضافة عنصر تحكم ActiveX**
إدراج عنصر تحكم ActiveX جديد وتعيين خصائصه اختياريًا.
```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // إضافة عنصر تحكم ActiveX جديد (TextBox)
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // اختياريًا تعيين بعض الخصائص
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```


## **الوصول إلى عنصر تحكم ActiveX**
قراءة المعلومات من أول عنصر تحكم ActiveX على الشريحة.
```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // الوصول إلى أول عنصر تحكم ActiveX
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```


## **إزالة عنصر تحكم ActiveX**
حذف عنصر تحكم ActiveX موجود من الشريحة.
```csharp
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // إزالة أول عنصر تحكم ActiveX
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```


## **تعيين خصائص ActiveX**
إضافة عنصر تحكم وتكوين عدة خصائص لـ ActiveX.
```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // إضافة زر أمر وتكوين الخصائص
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
