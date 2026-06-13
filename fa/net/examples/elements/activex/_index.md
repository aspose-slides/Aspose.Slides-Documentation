---
title: ActiveX
type: docs
weight: 200
url: /fa/net/examples/elements/activex/
keywords:
- ActiveX
- افزودن ActiveX
- دسترسی به ActiveX
- حذف ActiveX
- ویژگی‌های ActiveX
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مثال‌های ActiveX در Aspose.Slides for .NET را ببینید: افزودن، پیکربندی و کنترل اشیای ActiveX در ارائه‌های PPT و PPTX با کد واضح C#."
---
این مقاله نشان می‌دهد که چگونه می‌توان کنترل‌های ActiveX را در یک ارائه با استفاده از **Aspose.Slides for .NET** اضافه، دسترسی یافت، حذف و پیکربندی کرد.

## **اضافه کردن یک کنترل ActiveX**

یک کنترل ActiveX جدید وارد کنید و به‌صورت اختیاری خصوصیات آن را تنظیم کنید.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // یک کنترل ActiveX جدید اضافه کنید.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // در صورت نیاز برخی ویژگی‌ها را تنظیم کنید.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **دسترسی به یک کنترل ActiveX**

اطلاعات اولین کنترل ActiveX روی اسلاید را بخوانید.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // دسترسی به اولین کنترل ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **حذف یک کنترل ActiveX**

یک کنترل ActiveX موجود را از اسلاید حذف کنید.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // حذف اولین کنترل ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **تنظیم خصوصیات ActiveX**

یک کنترل اضافه کنید و چندین خصوصیت ActiveX را پیکربندی کنید.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // افزودن CommandButton و پیکربندی ویژگی‌ها.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```