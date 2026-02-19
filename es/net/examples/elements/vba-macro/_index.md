---
title: Macro VBA
type: docs
weight: 150
url: /es/net/examples/elements/vba-macro/
keywords:
- macro VBA
- añadir macro VBA
- acceder a macro VBA
- eliminar macro VBA
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Automatiza presentaciones con Aspose.Slides para .NET: crea, ejecuta, importa y protege macros VBA en PPT, PPTX y ODP mediante ejemplos claros en C#."
---
Este artículo muestra cómo agregar, acceder y eliminar macros VBA usando **Aspose.Slides for .NET**.

## **Añadir un macro VBA**

Cree una presentación con un proyecto VBA y un módulo de macro sencillo.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Acceder a un macro VBA**

Recupere el primer módulo del proyecto VBA.

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

## **Eliminar un macro VBA**

Elimine un módulo del proyecto VBA.

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