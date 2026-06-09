---
title: Μακροεντολή VBA
type: docs
weight: 150
url: /el/net/examples/elements/vba-macro/
keywords:
- μακροεντολή VBA
- προσθήκη μακροεντολής VBA
- πρόσβαση σε μακροεντολή VBA
- αφαίρεση μακροεντολής VBA
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Αυτοματοποιήστε τις παρουσιάσεις με το Aspose.Slides για .NET: δημιουργήστε, εκτελέστε, εισάγετε και διασφαλίστε μακροεντολές VBA σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα C#."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να αποκτήσετε πρόσβαση και να αφαιρέσετε μακροεντολές VBA χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη μακροεντολής VBA**

Δημιουργήστε μια παρουσίαση με ένα έργο VBA και ένα απλό μοντέλο μακροεντολών.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Πρόσβαση σε μακροεντολή VBA**

Ανακτήστε το πρώτο μοντέλο από το έργο VBA.

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

## **Αφαίρεση μακροεντολής VBA**

Διαγράψτε ένα μοντέλο από το έργο VBA.

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