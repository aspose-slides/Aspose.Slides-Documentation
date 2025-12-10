---
title: ماكرو VBA
type: docs
weight: 150
url: /ar/net/examples/elements/vba-macro/
keywords:
- مثال ماكرو VBA
- إضافة ماكرو VBA
- الوصول إلى ماكرو VBA
- إزالة ماكرو VBA
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع ماكروات VBA في C# باستخدام Aspose.Slides: إضافة أو تعديل المشاريع والوحدات، توقيع أو إزالة الماكروات، وحفظ العروض التقديمية بصيغ PPT و PPTX و ODP."
---

يوضح كيفية إضافة، الوصول إلى، وإزالة وحدات ماكرو VBA باستخدام **Aspose.Slides for .NET**.

## **إضافة ماكرو VBA**

إنشاء عرض تقديمي يحتوي على مشروع VBA ووحدة ماكرو بسيطة.
```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```


## **الوصول إلى ماكرو VBA**

استرجاع الوحدة الأولى من مشروع VBA.
```csharp
static void Access_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = pres.VbaProject.Modules[0];
}
```


## **إزالة ماكرو VBA**

حذف وحدة من مشروع VBA.
```csharp
static void Remove_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    pres.VbaProject.Modules.Remove(module);
}
```
