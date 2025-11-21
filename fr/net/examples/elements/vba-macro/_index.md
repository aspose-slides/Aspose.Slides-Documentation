---
title: "MacroVBA"
type: docs
weight: 150
url: /fr/net/examples/elements/vba-macro/
keywords:
- "exemple de macro vba"
- "ajouter une macro vba"
- "accéder à une macro vba"
- "supprimer une macro vba"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Travaillez avec les macros VBA en C# à l'aide d'Aspose.Slides : ajoutez ou modifiez des projets et des modules, signez ou supprimez des macros, et enregistrez les présentations au format PPT, PPTX et ODP."
---

Illustre comment ajouter, accéder et supprimer des macros VBA à l'aide de **Aspose.Slides for .NET**.

## Ajouter une macro VBA

Créez une présentation avec un projet VBA et un module de macro simple.
```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```


## Accéder à une macro VBA

Récupérez le premier module du projet VBA.
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


## Supprimer une macro VBA

Supprimez un module du projet VBA.
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
