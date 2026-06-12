---
title: VBA makro
type: docs
weight: 150
url: /cs/net/examples/elements/vba-macro/
keywords:
- VBA makro
- přidat VBA makro
- přístup k VBA makru
- odstranit VBA makro
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Automatizujte prezentace pomocí Aspose.Slides for .NET: vytvářejte, spouštějte, importujte a zabezpečujte VBA makra v PPT, PPTX a ODP pomocí srozumitelných příkladů v C#."
---
Tento článek ukazuje, jak přidávat, přistupovat k a odstraňovat makra VBA pomocí **Aspose.Slides for .NET**.

## **Přidat makro VBA**

Vytvořte prezentaci s projektem VBA a jednoduchým modulem makra.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Přístup k makru VBA**

Získejte první modul z projektu VBA.

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

## **Odstranit makro VBA**

Odstraňte modul z projektu VBA.

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