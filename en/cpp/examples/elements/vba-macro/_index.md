---
title: VBA Macro
type: docs
weight: 150
url: /cpp/examples/elements/vbamacro/
keywords:
- code example
- VBA
- macro
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Automate presentations with Aspose.Slides for C++: create, run, import, and secure VBA macros in PPT, PPTX, and ODP using clear C++ examples."
---

This article demonstrates how to add, access, and remove VBA macros using **Aspose.Slides for C++**.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

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

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

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

## **Remove a VBA Macro**

Delete a module from the VBA project.

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
