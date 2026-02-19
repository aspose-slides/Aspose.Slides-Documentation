---
title: Macro VBA
type: docs
weight: 150
url: /fr/net/examples/elements/vba-macro/
keywords:
- macro VBA
- ajouter macro VBA
- accéder macro VBA
- supprimer macro VBA
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Automatisez les présentations avec Aspose.Slides pour .NET : créez, exécutez, importez et sécurisez les macros VBA dans PPT, PPTX et ODP à l'aide d'exemples C# clairs."
---
Cet article décrit comment ajouter, accéder et supprimer des macros VBA à l'aide de **Aspose.Slides for .NET**.

## **Ajouter une macro VBA**

Créez une présentation avec un projet VBA et un module de macro simple.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Accéder à une macro VBA**

Récupérez le premier module du projet VBA.

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

## **Supprimer une macro VBA**

Supprimez un module du projet VBA.

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