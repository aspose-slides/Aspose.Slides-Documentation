---
title: Macro VBA
type: docs
weight: 150
url: /it/net/examples/elements/vba-macro/
keywords:
- macro VBA
- aggiungi macro VBA
- accedi macro VBA
- rimuovi macro VBA
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Automatizza le presentazioni con Aspose.Slides per .NET: crea, esegui, importa e proteggi macro VBA in PPT, PPTX e ODP usando esempi chiari in C#."
---
Questo articolo dimostra come aggiungere, accedere e rimuovere macro VBA utilizzando **Aspose.Slides for .NET**.

## **Aggiungi una macro VBA**

Crea una presentazione con un progetto VBA e un semplice modulo macro.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Accedi a una macro VBA**

Recupera il primo modulo dal progetto VBA.

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

## **Rimuovi una macro VBA**

Elimina un modulo dal progetto VBA.

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