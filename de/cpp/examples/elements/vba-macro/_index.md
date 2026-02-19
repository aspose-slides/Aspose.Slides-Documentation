---
title: VBA-Makro
type: docs
weight: 150
url: /de/cpp/examples/elements/vba-macro/
keywords:
- Codebeispiel
- VBA
- Makro
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Automatisieren Sie Präsentationen mit Aspose.Slides für C++: Erstellen, ausführen, importieren und sichern Sie VBA-Makros in PPT, PPTX und ODP mittels klarer C++-Beispiele."
---
Dieser Artikel zeigt, wie man VBA-Makros mit **Aspose.Slides for C++** hinzufügt, darauf zugreift und sie entfernt.

## **VBA-Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA-Projekt und einem einfachen Makro-Modul.

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

## **Zugriff auf ein VBA-Makro**

Rufen Sie das erste Modul aus dem VBA-Projekt ab.

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

## **VBA-Makro entfernen**

Löschen Sie ein Modul aus dem VBA-Projekt.

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