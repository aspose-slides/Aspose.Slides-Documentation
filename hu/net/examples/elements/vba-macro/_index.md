---
title: VBA makró
type: docs
weight: 150
url: /hu/net/examples/elements/vba-macro/
keywords:
- VBA makró
- VBA makró hozzáadása
- VBA makró elérése
- VBA makró eltávolítása
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Automatizálja a prezentációkat az Aspose.Slides for .NET segítségével: hozza létre, futtassa, importálja és biztosítsa a VBA makrókat PPT, PPTX és ODP formátumokban, világos C# példákkal."
---
Ez a cikk bemutatja, hogyan lehet VBA-makrókat hozzáadni, elérni és eltávolítani a **Aspose.Slides for .NET** használatával.

## **VBA-makró hozzáadása**

Készítsen egy prezentációt egy VBA-projekttel és egy egyszerű makrómodullal.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **VBA-makró elérése**

Szerezze meg a VBA-projekt első modulját.

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

## **VBA-makró eltávolítása**

Töröljön egy modult a VBA-projektből.

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