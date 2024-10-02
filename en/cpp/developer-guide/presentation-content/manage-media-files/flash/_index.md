---
title: Flash
type: docs
weight: 10
url: /cpp/flash/
---

## **Extract Flash Objects from Presentation**
Aspose.Slides for C++ provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

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
