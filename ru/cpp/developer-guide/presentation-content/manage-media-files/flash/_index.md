---
title: Флеш
type: docs
weight: 10
url: /ru/cpp/flash/
---

## **Извлечение флеш-объектов из презентации**
Aspose.Slides для C++ предоставляет возможность извлекать флеш-объекты из презентации. Вы можете получить доступ к флеш-контролю по имени и извлечь его из презентации, включая сохранение данных объекта SWF.

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