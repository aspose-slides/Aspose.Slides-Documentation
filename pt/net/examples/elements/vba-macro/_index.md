---
title: Macro VBA
type: docs
weight: 150
url: /pt/net/examples/elements/vba-macro/
keywords:
- macro VBA
- adicionar macro VBA
- acessar macro VBA
- remover macro VBA
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Automatize apresentações com Aspose.Slides for .NET: crie, execute, importe e proteja macros VBA em PPT, PPTX e ODP usando exemplos claros em C#."
---
Este artigo demonstra como adicionar, acessar e remover macros VBA usando **Aspose.Slides for .NET**.

## **Adicionar uma Macro VBA**

Crie uma apresentação com um projeto VBA e um módulo de macro simples.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Acessar uma Macro VBA**

Recupere o primeiro módulo do projeto VBA.

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **Remover uma Macro VBA**

Exclua um módulo do projeto VBA.

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```