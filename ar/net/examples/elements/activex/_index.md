---
title: ActiveX
type: docs
weight: 200
url: /ar/net/examples/elements/activex/
keywords:
- ActiveX
- إضافة ActiveX
- الوصول إلى ActiveX
- إزالة ActiveX
- خصائص ActiveX
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اطلع على أمثلة ActiveX في Aspose.Slides for .NET: إدراج، تكوين، والتحكم في عناصر ActiveX في عروض PPT و PPTX مع شفرة C# واضحة."
---
توضح هذه المقالة كيفية إضافة، الوصول، إزالة وتكوين عناصر تحكم ActiveX في عرض تقديمي باستخدام **Aspose.Slides for .NET**.

## **إضافة عنصر تحكم ActiveX**

أدرج عنصر تحكم ActiveX جديدًا واختر تعديل خصائصه اختياريًا.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // إضافة عنصر تحكم ActiveX جديد.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // تعيين بعض الخصائص اختيارياً.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **الوصول إلى عنصر تحكم ActiveX**

اقرأ المعلومات من أول عنصر تحكم ActiveX على الشريحة.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // الوصول إلى أول عنصر تحكم ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **إزالة عنصر تحكم ActiveX**

احذف عنصر تحكم ActiveX موجودًا من الشريحة.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // إزالة أول عنصر تحكم ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **تعيين خصائص ActiveX**

أضف عنصر تحكم وقم بتكوين عدة خصائص لـ ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // إضافة زر أمر وتكوين الخصائص.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```