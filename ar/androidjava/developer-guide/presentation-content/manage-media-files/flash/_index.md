---
title: فلاش
type: docs
weight: 10
url: /androidjava/flash/
description: استخراج كائنات Flash من عرض PowerPoint باستخدام Java
---

## **استخراج كائنات Flash من العرض**

توفر Aspose.Slides لنظام Android عبر Java إمكانية استخراج كائنات فلاش من العرض. يمكنك الوصول إلى وحدة الفلاش بالاسم واستخراجها من العرض بما في ذلك تخزين بيانات كائن SWF.

```java
// إنشاء كائن Presentation الذي يمثل PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```