---
title: فلاش
type: docs
weight: 10
url: /ar/java/flash/
description: استخراج كائنات فلاش من عرض PowerPoint باستخدام Java
---

## **استخراج كائنات فلاش من العرض**

توفر Aspose.Slides لJava إمكانية استخراج كائنات الفلاش من العرض. يمكنك الوصول إلى وحدة التحكم الخاصة بالفلاش بالاسم واستخراجها من العرض بما في ذلك تخزين بيانات كائن SWF.

```java
// إنشاء مثيل لفئة Presentation التي تمثل PPTX
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