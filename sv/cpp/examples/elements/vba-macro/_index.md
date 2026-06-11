---
title: VBA-makro
type: docs
weight: 150
url: /sv/cpp/examples/elements/vba-macro/
keywords:
- kodexempel
- VBA
- makro
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Automatisera presentationer med Aspose.Slides för C++: skapa, köra, importera och säkra VBA-makron i PPT, PPTX och ODP med tydliga C++-exempel."
---
Denna artikel visar hur man lägger till, får åtkomst till och tar bort VBA-makron med **Aspose.Slides for C++**.

## **Lägg till ett VBA-makro**

Skapa en presentation med ett VBA-projekt och en enkel makro-modul.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **Få åtkomst till ett VBA-makro**

Hämta den första modulen från VBA-projektet.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **Ta bort ett VBA-makro**

Ta bort en modul från VBA-projektet.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```