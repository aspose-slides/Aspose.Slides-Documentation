---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/net/examples/elements/vba-macro/
keywords:
- ماکرو VBA
- افزودن ماکرو VBA
- دسترسی به ماکرو VBA
- حذف ماکرو VBA
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اتوماتیک‌سازی ارائه‌ها با Aspose.Slides برای .NET: ایجاد، اجرا، وارد کردن و ایمن‌سازی ماکروهای VBA در PPT، PPTX و ODP با استفاده از مثال‌های واضح C#."
---
این مقاله نشان می‌دهد که چگونه می‌توان ماکروهای VBA را با استفاده از **Aspose.Slides for .NET** اضافه، دسترسی پیدا کرد و حذف کرد.

## **افزودن ماکرو VBA**

یک ارائه با پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **دسترسی به ماکرو VBA**

اولین ماژول را از پروژه VBA بازیابی کنید.

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

## **حذف ماکرو VBA**

یک ماژول را از پروژه VBA حذف کنید.

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