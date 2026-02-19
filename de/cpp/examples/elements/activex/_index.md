---
title: ActiveX
type: docs
weight: 200
url: /de/cpp/examples/elements/activex/
keywords:
- Codebeispiel
- ActiveX
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Siehe Aspose.Slides for C++ ActiveX-Beispiele: Einfügen, Konfigurieren und Steuern von ActiveX-Objekten in PPT- und PPTX-Präsentationen mit klarem C++-Code."
---
Dieser Artikel demonstriert, wie man ActiveX-Steuerelemente in einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for C++** verwendet wird.

## **ActiveX-Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX-Steuerelement ein und setzen Sie optional dessen Eigenschaften.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Fügt ein neues ActiveX-Steuerelement hinzu.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Optional einige Eigenschaften setzen.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Zugriff auf ein ActiveX-Steuerelement**

Lesen Sie Informationen vom ersten ActiveX-Steuerelement auf der Folie.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Greift auf das erste ActiveX-Steuerelement zu.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **ActiveX-Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX-Steuerelement von der Folie.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Entfernt das erste ActiveX-Steuerelement.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX-Eigenschaften festlegen**

Fügen Sie ein Steuerelement hinzu und konfigurieren Sie mehrere ActiveX-Eigenschaften.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Fügt ein Windows Media Player-Steuerelement hinzu und konfiguriert Eigenschaften.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```