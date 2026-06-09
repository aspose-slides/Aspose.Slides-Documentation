---
title: Macro VBA
type: docs
weight: 150
url: /pt/cpp/examples/elements/vba-macro/
keywords:
- exemplo de código
- VBA
- macro
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Automatize apresentações com Aspose.Slides for C++: crie, execute, importe e proteja macros VBA em PPT, PPTX e ODP usando exemplos claros em C++."
---
Este artigo demonstra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for C++**.

## **Adicionar uma Macro VBA**

Crie uma apresentação com um projeto VBA e um módulo de macro simples.

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

## **Acessar uma Macro VBA**

Recupere o primeiro módulo do projeto VBA.

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

## **Remover uma Macro VBA**

Exclua um módulo do projeto VBA.

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