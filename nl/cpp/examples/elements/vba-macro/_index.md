---
title: VBA-macro
type: docs
weight: 150
url: /nl/cpp/examples/elements/vba-macro/
keywords:
- codevoorbeeld
- VBA
- macro
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Automatiseer presentaties met Aspose.Slides for C++: maak, voer uit, importeer en beveilig VBA-macro's in PPT, PPTX en ODP met duidelijke C++-voorbeelden."
---
Dit artikel toont hoe u VBA-macro's kunt toevoegen, benaderen en verwijderen met **Aspose.Slides for C++**.

## **VBA-macro toevoegen**

Maak een presentatie met een VBA-project en een eenvoudige macro-module.

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

## **VBA-macro benaderen**

Haal de eerste module op uit het VBA-project.

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

## **VBA-macro verwijderen**

Verwijder een module uit het VBA-project.

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