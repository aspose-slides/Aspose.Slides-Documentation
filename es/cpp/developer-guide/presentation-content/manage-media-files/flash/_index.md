---
title: Flash
type: docs
weight: 10
url: /cpp/flash/
---

## **Extraer objetos Flash de la presentación**
Aspose.Slides para C++ proporciona una herramienta para extraer objetos flash de una presentación. Puedes acceder al control flash por su nombre y extraerlo de la presentación, incluyendo el almacenamiento de datos del objeto SWF.

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