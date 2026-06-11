---
title: Makro VBA
type: docs
weight: 150
url: /pl/net/examples/elements/vba-macro/
keywords:
- Makro VBA
- dodaj makro VBA
- dostęp do makra VBA
- usuń makro VBA
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Automatyzuj prezentacje za pomocą Aspose.Slides dla .NET: twórz, uruchamiaj, importuj i zabezpieczaj makra VBA w formatach PPT, PPTX i ODP, korzystając z przejrzystych przykładów w C#."
---
Ten artykuł pokazuje, jak dodawać, uzyskiwać dostęp i usuwać makra VBA za pomocą **Aspose.Slides for .NET**.

## **Dodaj makro VBA**

Utwórz prezentację z projektem VBA i prostym modułem makr.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Uzyskaj dostęp do makra VBA**

Pobierz pierwszy moduł z projektu VBA.

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

## **Usuń makro VBA**

Usuń moduł z projektu VBA.

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