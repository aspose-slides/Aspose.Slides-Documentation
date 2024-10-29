---
title: Flash
type: docs
weight: 10
url: /zh/cpp/flash/
---

## **从演示文稿中提取 Flash 对象**
Aspose.Slides for C++ 提供了一种从演示文稿中提取 Flash 对象的功能。您可以通过名称访问 Flash 控件，并将其从演示文稿中提取，包括存储 SWF 对象数据。

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
