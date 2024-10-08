---
title: Flash
type: docs
weight: 10
url: /fr/cpp/flash/
---

## **Extraire des objets Flash de la présentation**
Aspose.Slides pour C++ fournit une fonctionnalité pour extraire des objets flash d'une présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation en incluant les données de l'objet SWF.

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