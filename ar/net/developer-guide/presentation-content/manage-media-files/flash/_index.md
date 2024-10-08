---
title: فلاش
type: docs
weight: 10
url: /ar/net/flash/
keywords: "استخراج فلاش، عرض باوربوينت، C#، Csharp، Aspose.Slides لـ .NET"
description: "استخراج كائن فلاش من عرض باوربوينت في C# أو .NET"
---

## **استخراج كائنات فلاش من العرض**
توفر Aspose.Slides لـ .NET وسيلة لاستخراج كائنات فلاش من العرض. يمكنك الوصول إلى وحدة فلاش بالاسم واستخراجها من العرض بما في ذلك تخزين بيانات كائن SWF.

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```