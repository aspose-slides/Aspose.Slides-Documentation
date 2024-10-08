---
title: Flash
type: docs
weight: 10
url: /de/cpp/flash/
---

## **Flash-Objekte aus der Präsentation extrahieren**
Aspose.Slides für C++ bietet eine Funktion zum Extrahieren von Flash-Objekten aus einer Präsentation. Sie können das Flash-Steuerelement nach Name aufrufen und aus der Präsentation extrahieren, einschließlich der Speicherung von SWF-Objektdaten.

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