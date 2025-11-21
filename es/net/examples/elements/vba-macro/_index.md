---
title: MacroVba
type: docs
weight: 150
url: /es/net/examples/elements/vba-macro/
keywords:
- ejemplo de macro vba
- agregar macro vba
- acceder macro vba
- eliminar macro vba
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con macros VBA en C# usando Aspose.Slides: agregue o edite proyectos y módulos, firme o elimine macros, y guarde presentaciones en PPT, PPTX y ODP."
---

Ilustra cómo agregar, acceder y eliminar macros VBA usando **Aspose.Slides for .NET**.

## Agregar una macro VBA

Crear una presentación con un proyecto VBA y un módulo de macro sencillo.
```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```


## Acceder a una macro VBA

Obtener el primer módulo del proyecto VBA.
```csharp
static void Access_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = pres.VbaProject.Modules[0];
}
```


## Eliminar una macro VBA

Eliminar un módulo del proyecto VBA.
```csharp
static void Remove_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    pres.VbaProject.Modules.Remove(module);
}
```
