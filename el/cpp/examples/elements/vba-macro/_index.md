---
title: Μακροεντολή VBA
type: docs
weight: 150
url: /el/cpp/examples/elements/vba-macro/
keywords:
- παράδειγμα κώδικα
- VBA
- μακροεντολή
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Αυτοματοποιήστε παρουσιάσεις με Aspose.Slides for C++: δημιουργήστε, εκτελέστε, εισάγετε και ασφαλίστε μακροεντολές VBA σε PPT, PPTX και ODP χρησιμοποιώντας σαφή παραδείγματα C++."
---
Αυτό το άρθρο παρουσιάζει πώς να προσθέτετε, να έχετε πρόσβαση και να αφαιρείτε μακροεντολές VBA χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη μακροεντολής VBA**

Δημιουργήστε μια παρουσίαση με ένα έργο VBA και μια απλή μονάδα μακροεντολής.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **Πρόσβαση σε μακροεντολή VBA**

Ανακτήστε τη πρώτη μονάδα από το έργο VBA.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **Αφαίρεση μακροεντολής VBA**

Διαγράψτε μια μονάδα από το έργο VBA.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```