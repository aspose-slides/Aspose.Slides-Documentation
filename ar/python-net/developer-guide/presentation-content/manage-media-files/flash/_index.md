---
title: فلاش
type: docs
weight: 10
url: /ar/python-net/flash/
keywords: "استخراج فلاش، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "استخراج كائن فلاش من عرض PowerPoint باستخدام Python"
---

## **استخراج كائنات فلاش من العرض**
توفر Aspose.Slides لـ Python عبر .NET وسيلة لاستخراج كائنات الفلاش من العرض. يمكنك الوصول إلى وحدة الفلاش بالاسم واستخراجها من العرض بما في ذلك تخزين بيانات كائن SWF.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```