---
title: فلاش
type: docs
weight: 10
url: /ar/cpp/flash/
---

## **استخراج كائنات الفلاش من العرض التقديمي**
توفر Aspose.Slides لـ C++ وسيلة لاستخراج كائنات الفلاش من عرض تقديمي. يمكنك الوصول إلى وحدة تحكم الفلاش بالاسم واستخراجها من العرض التقديمي بما في ذلك تخزين بيانات كائن SWF.

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```