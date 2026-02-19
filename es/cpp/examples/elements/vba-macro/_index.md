---
title: Macro VBA
type: docs
weight: 150
url: /es/cpp/examples/elements/vba-macro/
keywords:
- ejemplo de código
- VBA
- macro
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Automatiza presentaciones con Aspose.Slides for C++: crea, ejecuta, importa y protege macros VBA en PPT, PPTX y ODP mediante ejemplos claros en C++."
---
Este artículo muestra cómo añadir, acceder y eliminar macros VBA utilizando **Aspose.Slides for C++**.

## **Añadir una macro VBA**

Cree una presentación con un proyecto VBA y un módulo de macro sencillo.

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

## **Acceder a una macro VBA**

Recupere el primer módulo del proyecto VBA.

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

## **Eliminar una macro VBA**

Elimine un módulo del proyecto VBA.

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