---
title: ماكرو VBA
type: docs
weight: 150
url: /ar/net/examples/elements/vba-macro/
keywords:
- ماكرو VBA
- إضافة ماكرو VBA
- الوصول إلى ماكرو VBA
- إزالة ماكرو VBA
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بأتمتة العروض التقديمية باستخدام Aspose.Slides for .NET: إنشاء، تشغيل، استيراد، وتأمين ماكروات VBA في صيغ PPT، PPTX، و ODP باستخدام أمثلة C# واضحة."
---
توضح هذه المقالة كيفية إضافة، الوصول إلى، وإزالة ماكروات VBA باستخدام **Aspose.Slides for .NET**.

## **إضافة ماكرو VBA**

إنشاء عرض تقديمي يحتوي على مشروع VBA ووحدة ماكرو بسيطة.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **الوصول إلى ماكرو VBA**

استرجاع الوحدة الأولى من مشروع VBA.

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

## **إزالة ماكرو VBA**

حذف وحدة من مشروع VBA.

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