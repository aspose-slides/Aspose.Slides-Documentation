---
title: Macro VBA
type: docs
weight: 150
url: /it/cpp/examples/elements/vba-macro/
keywords:
- esempio di codice
- VBA
- macro
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Automatizza le presentazioni con Aspose.Slides per C++: crea, esegui, importa e proteggi le macro VBA in PPT, PPTX e ODP usando esempi chiari in C++."
---
Questo articolo dimostra come aggiungere, accedere e rimuovere le macro VBA utilizzando **Aspose.Slides for C++**.

## **Aggiungere una macro VBA**

Crea una presentazione con un progetto VBA e un semplice modulo macro.

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

## **Accedere a una macro VBA**

Recupera il primo modulo dal progetto VBA.

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

## **Rimuovere una macro VBA**

Elimina un modulo dal progetto VBA.

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